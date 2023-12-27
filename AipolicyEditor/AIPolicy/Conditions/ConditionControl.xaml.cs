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
                label.Background = Brushes.LightGray;
            }
            label.MouseEnter += Label_MouseEnter;
            label.MouseLeave += Label_MouseLeave;
            label.MouseUp += Label_MouseUp;
            return label;
        }

        private void Label_MouseUp(object sender, MouseButtonEventArgs e)
        {
            ConditionEdit conditionEdit = new ConditionEdit((sender as ConditionLabel).cond);
            conditionEdit.Reload += Reload;
            conditionEdit.ShowDialog();
        }

        private void Label_MouseLeave(object sender, MouseEventArgs e)
        {
            (sender as ConditionLabel).Foreground = Brushes.Black;
            BaseGrid.Background = Brushes.White;
        }

        private void Label_MouseEnter(object sender, MouseEventArgs e)
        {
            (sender as ConditionLabel).Foreground = new SolidColorBrush(Color.FromArgb(204, 17, 158, 218));
            BaseGrid.Background = Brushes.LightYellow;
        }
    }
}
