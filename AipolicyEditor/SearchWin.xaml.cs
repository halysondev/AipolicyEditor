using System.Collections.Generic;
using System.Windows;
using AipolicyEditor.AIPolicy;
using AipolicyEditor.AIPolicy.Conditions;
using AipolicyEditor.Localization;
using MahApps.Metro.Controls;
using WPFLocalizeExtension.Engine;
using WPFLocalizeExtension.Extensions;

namespace AipolicyEditor
{
    public partial class SearchWin : MetroWindow
    {
        public AIFile Aipolicy { get; set; }
        private List<int[]> res = new List<int[]>();
        private List<int[]> res_index = new List<int[]>();
        private List<IOperation> Ops { get; set; } = new List<IOperation>();

        public SearchWin()
        {
            InitializeComponent();
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            res.Clear();
            res_index.Clear();
            SearchResults.Items.Clear();
            string pattern = SearchPattern.Text.ToLower();
            foreach (CPolicyData cpd in Aipolicy.Controllers)
            {
                if (cpd.ID.ToString().Contains(pattern))
                {
                    res.Add(new[] { cpd.ID });
                    res_index.Add(new[] { Aipolicy.Controllers.IndexOf(cpd) });
                }
                foreach (CTriggerData ctd in cpd.Triggers)
                {
                    if (ctd.ID.ToString().Contains(pattern) || ctd.Name.ToString().Contains(pattern) || Conditions.Search(ctd.RootConditon, pattern))
                    {
                        res.Add(new[] { cpd.ID, ctd.ID });
                        res_index.Add(new[] { Aipolicy.Controllers.IndexOf(cpd), cpd.Triggers.IndexOf(ctd) });
                    }
                    foreach (IOperation iop in ctd.Operations)
                    {
                        if (iop.Search(pattern))
                        {
                            res.Add(new[] { cpd.ID, ctd.ID, ctd.Operations.IndexOf(iop) });
                            res_index.Add(new[] { Aipolicy.Controllers.IndexOf(cpd), cpd.Triggers.IndexOf(ctd), ctd.Operations.IndexOf(iop) });
                        }
                    }
                }
            }
            foreach (var r in res)
            {
                switch (r.Length)
                {
                    case 1:
                        SearchResults.Items.Add($"Controller {r[0]}");
                        break;
                    case 2:
                        SearchResults.Items.Add($"Controller {r[0]}, Trigger {r[1]}");
                        break;
                    case 3:
                        SearchResults.Items.Add($"Controller {r[0]}, Trigger {r[1]}, Operation {r[2]}");
                        break;
                }
            }
        }

        private void SearchResults_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (SearchResults.SelectedIndex > -1)
            {
                if (res[SearchResults.SelectedIndex].Length > 0)
                {
                    Aipolicy.ControllerIndex = res_index[SearchResults.SelectedIndex][0];
                }
                if (res[SearchResults.SelectedIndex].Length > 1)
                {
                    Aipolicy.TriggerIndex = res_index[SearchResults.SelectedIndex][1];
                }
                if (res[SearchResults.SelectedIndex].Length > 2)
                {
                    Aipolicy.OperationIndex = res_index[SearchResults.SelectedIndex][2];
                }
            }
        }

        private void TypeChange(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            Types.Items.Clear();
            if (SearchType.SelectedIndex == 0)
            {
                foreach (string v in Conditions.GetConditions())
                {
                    Types.Items.Add(v);
                }
            }
            else if (SearchType.SelectedIndex == 1)
            {
                for (int i = 0; i < 107; ++i)
                {
                    IOperation op = Operation.Read(null, CTriggerData.MaxVersion, i);
                    if (op.FromVersion <= CTriggerData.MaxVersion)
                    {
                        Ops.Add(op);
                    }
                }
                foreach (IOperation op in Ops)
                {
                    Types.Items.Add($"{op.Name} ({MainWindow.Provider.GetLocalizedString("Version")} {op.FromVersion})");
                }
            }
        }

        private void SearchTypeClick(object sender, RoutedEventArgs e)
        {
            res.Clear();
            res_index.Clear();
            SearchResults.Items.Clear();
            if (SearchType.SelectedIndex == 0)
            {
                foreach (CPolicyData cpd in Aipolicy.Controllers)
                {
                    foreach (CTriggerData ctd in cpd.Triggers)
                    {
                        if (Conditions.Search(ctd.RootConditon, Types.SelectedIndex))
                        {
                            res.Add(new[] { cpd.ID, ctd.ID });
                            res_index.Add(new[] { Aipolicy.Controllers.IndexOf(cpd), cpd.Triggers.IndexOf(ctd) });
                        }
                    }
                }
            }
            else if (SearchType.SelectedIndex == 1)
            {
                foreach (CPolicyData cpd in Aipolicy.Controllers)
                {
                    foreach (CTriggerData ctd in cpd.Triggers)
                    {
                        foreach (IOperation iop in ctd.Operations)
                        {
                            if (iop.OperID == Ops[Types.SelectedIndex].OperID)
                            {
                                res.Add(new[] { cpd.ID, ctd.ID, ctd.Operations.IndexOf(iop) });
                                res_index.Add(new[] { Aipolicy.Controllers.IndexOf(cpd), cpd.Triggers.IndexOf(ctd), ctd.Operations.IndexOf(iop) });
                            }
                        }
                    }
                }
            }
            foreach (var r in res)
            {
                switch (r.Length)
                {
                    case 1:
                        SearchResults.Items.Add($"Controller {r[0]}");
                        break;
                    case 2:
                        SearchResults.Items.Add($"Controller {r[0]}, Trigger {r[1]}");
                        break;
                    case 3:
                        SearchResults.Items.Add($"Controller {r[0]}, Trigger {r[1]}, Operation {r[2]}");
                        break;
                }
            }
        }
    }
}
