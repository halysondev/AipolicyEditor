using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace AipolicyEditor.AIPolicy.Conditions
{
    public partial class ConditionControl : UserControl
    {
        private Condition _Cond;
        public Condition Cond
        {
            get
            {
                return _Cond;
            }
            set
            {
                if (_Cond != value)
                {
                    _Cond = value;
                    Reload();
                }
            }
        }
        public bool IsCentral = false;

        public ConditionControl()
        {
            InitializeComponent();
            //WPF не могет
            HorizontalContentAlignment = HorizontalAlignment.Center;
            VerticalAlignment = VerticalAlignment.Center;
        }

        public void Reload()
        {
            BaseGrid.Children.Clear();
            if (Cond == null)
                return;
            int index = 0;
            if (Cond.Type == 1)
            {
                if (Cond.ConditionLeft == null) Cond.ConditionLeft = Conditions.CreateEmpty();
                index = Array.IndexOf(Conditions.Non_central, Cond.ConditionLeft.ID);
                if (index > -1)
                {
                    BaseGrid.Children.Add(CreateLabel(Cond.ConditionLeft));
                }
                else
                {
                    ConditionControl cl = new ConditionControl()
                    {
                        Cond = Cond.ConditionLeft,
                        Margin = new Thickness(5)
                    };
                    BaseGrid.Children.Add(cl);
                    cl.Reload();
                }
            }
            BaseGrid.Children.Add(CreateLabel(Cond, IsCentral));
            if (Cond.Type <= 2)
            {
                if (Cond.ConditionRight == null) Cond.ConditionRight = Conditions.CreateEmpty();
                index = Array.IndexOf(Conditions.Non_central, Cond.ConditionRight.ID);
                if (index > -1)
                {
                    BaseGrid.Children.Add(CreateLabel(Cond.ConditionRight));
                }
                else
                {
                    ConditionControl cl = new ConditionControl()
                    {
                        Cond = Cond.ConditionRight,
                        Margin = new Thickness(5)
                    };
                    BaseGrid.Children.Add(cl);
                    cl.Reload();
                }
            }
        }

        UIElement CreateLabel(Condition cond, bool IsCentral = false)
        {
            string text = Conditions.GetName(cond.ID);
            if (cond.Value.Length == 1)
                text = $"{text}({cond.Value[0]})";
            else if (cond.Value.Length == 2)
                text = $"{text}({cond.Value[0]}, {cond.Value[1]})";
            ConditionLabel label = new ConditionLabel(cond)
            {
                Content = text,
                Height = 30,
                FontSize = 16
            };
            if (IsCentral)
            {
                label.Background = Brushes.Black;
            }
            label.MouseEnter += Label_MouseEnter;
            label.MouseLeave += Label_MouseLeave;
            label.MouseUp += Label_MouseUp;
            return label;
        }

        private void Label_MouseUp(object sender, MouseButtonEventArgs e)
        {
            // Only open edit dialog on left mouse button click
            if (e.ChangedButton == MouseButton.Left)
            {
                ConditionEdit conditionEdit = new ConditionEdit((sender as ConditionLabel).cond);
                conditionEdit.Reload += Reload;
                conditionEdit.ShowDialog();
            }
        }

        private void Label_MouseLeave(object sender, MouseEventArgs e)
        {
            (sender as ConditionLabel).Foreground = Brushes.White;
            BaseGrid.Background = Brushes.Black;
        }

        private void Label_MouseEnter(object sender, MouseEventArgs e)
        {
            (sender as ConditionLabel).Foreground = new SolidColorBrush(Color.FromArgb(204, 17, 158, 218));
            BaseGrid.Background = Brushes.LightYellow;
        }

        private void AddCondition_Click(object sender, RoutedEventArgs e)
        {
            if (Cond == null)
                return;

            if (Cond.Type == 3) // Terminal condition
            {
                // Convert to logical operator (AND or OR)
                Cond.Type = 1; // Logical operator
                Cond.ID = 7; // Set to AND operator (7 is AND, 6 is OR)
                
                // Create a new right condition
                Cond.ConditionRight = Conditions.CreateEmpty();
                
                // Move current condition values to left
                Condition leftCond = new Condition
                {
                    ID = Cond.ID,
                    Type = 3,
                    Value = Cond.Value
                };
                Cond.ConditionLeft = leftCond;
                
                // Reset current condition values
                Cond.Value = new object[0];
            }
            else if (Cond.Type == 1 || Cond.Type == 2)
            {
                // Add a new condition to the right
                if (Cond.ConditionRight == null)
                    Cond.ConditionRight = Conditions.CreateEmpty();
                
                // Or show the edit dialog for the right condition
                ConditionEdit conditionEdit = new ConditionEdit(Cond.ConditionRight);
                conditionEdit.Reload += Reload;
                conditionEdit.ShowDialog();
            }
            
            Reload();
        }

        private void DeleteCondition_Click(object sender, RoutedEventArgs e)
        {
            if (Cond == null)
                return;

            // Get the parent condition control if this is a nested condition
            ConditionControl parentControl = this.Parent as ConditionControl;
            
            if (parentControl != null && parentControl.Cond != null)
            {
                // If this is a left or right condition of a parent
                if (parentControl.Cond.ConditionLeft == Cond)
                {
                    parentControl.Cond.ConditionLeft = Conditions.CreateEmpty();
                    parentControl.Reload();
                }
                else if (parentControl.Cond.ConditionRight == Cond)
                {
                    parentControl.Cond.ConditionRight = Conditions.CreateEmpty();
                    parentControl.Reload();
                }
            }
            else
            {
                // If this is the root condition, reset it to an empty condition
                Cond = Conditions.CreateEmpty();
                Reload();
            }
        }
    }
}
