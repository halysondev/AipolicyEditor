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

        public int CurrentVersion { get; private set; }

        public OperationSelector(int version)
        {
            InitializeComponent();
            CurrentVersion = version; // Initialize CurrentVersion with the passed version
            for (int i = 0; i < 202; ++i)
            {
                IOperation op = Operation.Read(null, version, i);
                if (op != null)
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
            {
                Op = Ops[Operations.SelectedIndex];
                // Only update the version if the selected operation's version is greater than the current version
                if (Op.FromVersion > CurrentVersion)
                {
                    CurrentVersion = Op.FromVersion;
                }
                Close();
            }
        }

        public int GetUpdatedVersion()
        {
            return CurrentVersion;
        }
    }
}
