using MahApps.Metro.Controls;
using System;
using System.ComponentModel;
using System.Windows;

namespace AipolicyEditor.AIPolicy.Conditions
{
    public delegate void Reload();

    public partial class ConditionEdit : MetroWindow, INotifyPropertyChanged
    {
        public Condition C { get; set; }

        public event Reload Reload;

        public string Param1Name
        {
            get
            {
                string[] fields = Conditions.GetFileds(C.ID);
                if (fields.Length > 0)
                    return fields[0];
                else
                    return "";
            }
        }

        public string Param2Name
        {
            get
            {
                string[] fields = Conditions.GetFileds(C.ID);
                if (fields.Length > 1)
                    return fields[1];
                else
                    return "";
            }
        }

        public string Param3Name
        {
            get
            {
                string[] fields = Conditions.GetFileds(C.ID);
                if (fields.Length > 1)
                    return fields[2];
                else
                    return "";
            }
        }

        public string Param4Name
        {
            get
            {
                string[] fields = Conditions.GetFileds(C.ID);
                if (fields.Length > 1)
                    return fields[3];
                else
                    return "";
            }
        }

        public string Param5Name
        {
            get
            {
                string[] fields = Conditions.GetFileds(C.ID);
                if (fields.Length > 1)
                    return fields[4];
                else
                    return "";
            }
        }

        public string Param6Name
        {
            get
            {
                string[] fields = Conditions.GetFileds(C.ID);
                if (fields.Length > 1)
                    return fields[5];
                else
                    return "";
            }
        }

        public object Param1
        {
            get
            {
                return C.Value.Length > 0 ? C.Value[0] : "";
            }
            set
            {
                if (C.Value.Length > 0 && C.Value[0] != value)
                {
                    C.Value[0] = value;
                    OnPropertyChanged("Param1");
                    Reload?.Invoke();
                }
            }
        }

        public object Param2
        {
            get
            {
                return C.Value.Length > 1 ? C.Value[1] : "";
            }
            set
            {
                if (C.Value.Length > 1 && C.Value[1] != value)
                {
                    C.Value[1] = value;
                    OnPropertyChanged("Param2");
                    Reload?.Invoke();
                }
            }
        }

        public object Param3
        {
            get
            {
                return C.Value.Length > 1 ? C.Value[2] : "";
            }
            set
            {
                if (C.Value.Length > 1 && C.Value[2] != value)
                {
                    C.Value[2] = value;
                    OnPropertyChanged("Param3");
                    Reload?.Invoke();
                }
            }
        }

        public object Param4
        {
            get
            {
                return C.Value.Length > 1 ? C.Value[3] : "";
            }
            set
            {
                if (C.Value.Length > 1 && C.Value[3] != value)
                {
                    C.Value[2] = value;
                    OnPropertyChanged("Param4");
                    Reload?.Invoke();
                }
            }
        }

        public object Param5
        {
            get
            {
                return C.Value.Length > 1 ? C.Value[4] : "";
            }
            set
            {
                if (C.Value.Length > 1 && C.Value[4] != value)
                {
                    C.Value[2] = value;
                    OnPropertyChanged("Param4");
                    Reload?.Invoke();
                }
            }
        }

        public object Param6
        {
            get
            {
                return C.Value.Length > 1 ? C.Value[5] : "";
            }
            set
            {
                if (C.Value.Length > 1 && C.Value[5] != value)
                {
                    C.Value[2] = value;
                    OnPropertyChanged("Param5");
                    Reload?.Invoke();
                }
            }
        }

        public int ConditionIndex
        {
            get => C.ID;
            set
            {
                if (C.ID != value)
                {
                    C.ID = value;
                    C.Value = Conditions.CreateEmptyValue(value);
                    C.Type = Conditions.TypeByID(value);
                    (C.SubNodeL, C.SubNodeR) = Conditions.GetSubNodeByType(C.Type);
                    OnPropertyChanged("Param1Name");
                    OnPropertyChanged("Param2Name");
                    OnPropertyChanged("Param3Name");
                    OnPropertyChanged("Param4Name");
                    OnPropertyChanged("Param5Name");
                    OnPropertyChanged("Param1");
                    OnPropertyChanged("Param2");
                    OnPropertyChanged("Param3");
                    OnPropertyChanged("Param4");
                    OnPropertyChanged("Param5");
                    OnPropertyChanged("ConditionIndex");
                    OnPropertyChanged("Visible1");
                    OnPropertyChanged("Visible2");
                    OnPropertyChanged("Visible3");
                    OnPropertyChanged("Visible4");
                    OnPropertyChanged("Visible5");
                    Reload?.Invoke();
                }
            }
        }

        public Visibility Visible1 => C.Value.Length > 0 ? Visibility.Visible : Visibility.Hidden;

        public Visibility Visible2 => C.Value.Length > 1 ? Visibility.Visible : Visibility.Hidden;

        public Visibility Visible3 => C.Value.Length > 2 ? Visibility.Visible : Visibility.Hidden;
        public Visibility Visible4 => C.Value.Length > 3 ? Visibility.Visible : Visibility.Hidden;
        public Visibility Visible5 => C.Value.Length > 4 ? Visibility.Visible : Visibility.Hidden;
        public Visibility Visible6 => C.Value.Length > 5 ? Visibility.Visible : Visibility.Hidden;

        public ConditionEdit(Condition c)
        {
            InitializeComponent();
            C = c;
            var data = Conditions.GetConditions();
            for (int i = 0; i < data.Count; ++i)
                ConditionBox.Items.Add(data[i]);
            DataContext = this;
            OnPropertyChanged("ConditionIndex");
            Visibility = Visibility.Visible;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
