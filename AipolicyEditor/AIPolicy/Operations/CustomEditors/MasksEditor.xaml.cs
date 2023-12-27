using MahApps.Metro.Controls;
using System.Windows.Controls;

namespace AipolicyEditor.AIPolicy.Operations.CustomEditors
{
    /// <summary>
    /// Interaction logic for MasksEditor.xaml
    /// </summary>
    public partial class MasksEditor : MetroWindow
    {
        private int Value { get; set; }
        private bool OnLoad = true;
        public event SetIntValue ChangeValue;

        public MasksEditor(int v = 0)
        {
            InitializeComponent();
            Value = v;
            var list = Utils.GetMask((uint)Value);
            for (int i = 0; i < list.Count; ++i)
            {
                if (list[i] == 1)
                    (FindName($"Class{i + 1}") as CheckBox).IsChecked = true;
            }
            Masks.Text = Value.ToString();
            OnLoad = false;
        }

        private void Checked(object sender, System.Windows.RoutedEventArgs e)
        {
            if (OnLoad)
                return;
            CheckBox s = sender as CheckBox;
            if (s.IsChecked == true)
                Value += s.Tag.ToString().ToInt32();
            else
                Value -= s.Tag.ToString().ToInt32();
            Masks.Text = Value.ToString();
        }

        private void SaveClick(object sender, System.Windows.RoutedEventArgs e)
        {
            ChangeValue?.Invoke(Masks.Text.ToInt32());
            Close();
        }
    }
}
