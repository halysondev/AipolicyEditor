using System.Collections.Generic;
using System.Windows;
using MahApps.Metro.Controls;
using WPFLocalizeExtension.Extensions;

namespace AipolicyEditor.AIPolicy.Operations
{
    public partial class OperationSelector : MetroWindow
    {
        private List<IOperation> Ops { get; set; } = new List<IOperation>();
        public IOperation Op { get; set; }

        public OperationSelector(int version)
        {
            InitializeComponent();
            for (int i = 0; i < 107; ++i)
            {
                IOperation op = Operation.Read(null, version, i);
                if (op.FromVersion <= version)
                {
                    Ops.Add(op);
                }
            }
            foreach (IOperation op in Ops)
            {
                Operations.Items.Add($"{op.Name} ({MainWindow.Provider.GetLocalizedString("Version")} {op.FromVersion})");
            }
        }

        private void SelectionClick(object sender, RoutedEventArgs e)
        {
            if (Operations.SelectedIndex > -1)
                Op = Ops[Operations.SelectedIndex];
            Close();
        }
    }
}
