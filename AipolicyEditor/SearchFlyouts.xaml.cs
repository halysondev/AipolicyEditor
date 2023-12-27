using AipolicyEditor.AIPolicy;
using AipolicyEditor.AIPolicy.Conditions;
using MahApps.Metro.Controls;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace AipolicyEditor
{
    public partial class SearchFlyouts : Flyout
    {
        public AIFile Aipolicy { get; set; }
        private List<int[]> res = new List<int[]>();
        private List<int[]> res_index = new List<int[]>();

        public SearchFlyouts()
        {
            InitializeComponent();
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            res.Clear();
            res_index.Clear();
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
            SearchResults.Items.Clear();
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
    }
}
