using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Documents;
using System.Windows.Forms;
using MahApps.Metro.Controls;

namespace AipolicyEditor.AIPolicy.Operations.CustomEditors
{
    public partial class CustomDataSelector : MetroWindow, INotifyPropertyChanged
    {
        private string _Filter = "";
        public string Filter
        {
            get => _Filter;
            set
            {
                if (_Filter != value)
                {
                    _Filter = value;
                    OnPropertyChanged("Filter");
                    OnPropertyChanged("Items");
                }
            }
        }

        private ObservableCollection<CustomDataCollection> _Items = new ObservableCollection<CustomDataCollection>();
        public ObservableCollection<CustomDataCollection> Items
        {
            get
            {
                if (Filter.Length > 0)
                {
                    var data = _Items.Where(x => x.ID.ToString().Contains(Filter)
                    || x.Name.Contains(Filter)
                    || x.Desc.Contains(Filter));
                    return new ObservableCollection<CustomDataCollection>(data);
                }
                return _Items;
            }
            set
            {
                if (_Items != value)
                {
                    _Items = value;
                    OnPropertyChanged("Items");
                }
            }
        }

        private int _Index = -1;
        public int Index
        {
            get => _Index;
            set
            {
                if (_Index != value)
                {
                    _Index = value;
                    OnPropertyChanged("Index");
                    ProItemDesc(Item.Desc);
                }
            }
        }

        public CustomDataCollection Item
        {
            get
            {
                if (Index > -1)
                    return Items[Index];
                return null;
            }
        }

        public void ProItemDesc(string desc)
        {
            if (desc.Length < 2)
                return;
            try
            {
                string output = desc.Replace("\\r", " \\r");
                output = output.Replace("r", "");
                output = output.Replace("\\", "\n");
                List<string> colors = new List<string>();
                List<int> simbvols = new List<int>();
                for (int a = 0; a < output.Length; ++a)
                {
                    int b = output.IndexOf("^", a);
                    if (b >= 0)
                    {
                        colors.Add(output.Substring(b + 1, 6));
                        output = output.Remove(b, 7);
                        if (b == 0)
                        {
                            simbvols.Add(b);
                        }
                        else
                        {
                            simbvols.Add(b - 1);
                        }
                    }
                }
                (Desc.Child as RichTextBox).Text = output;
                for (int b = 0; b < simbvols.Count; ++b)
                {
                    (Desc.Child as RichTextBox).Select(simbvols[b], Desc.Child.Text.Length);
                    (Desc.Child as RichTextBox).SelectionColor = Color.FromArgb(int.Parse(colors[b].Substring(0, 2), System.Globalization.NumberStyles.AllowHexSpecifier), int.Parse(colors[b].Substring(2, 2), System.Globalization.NumberStyles.AllowHexSpecifier), int.Parse(colors[b].Substring(4, 2), System.Globalization.NumberStyles.AllowHexSpecifier));
                }
            }
            catch { (Desc.Child as RichTextBox).Text = "Text parse error"; }
        }

        public CustomDataSelector(List<CustomDataCollection> items)
        {
            InitializeComponent();
            DataContext = this;
            Items = new ObservableCollection<CustomDataCollection>(items);
        }

        private void SelectClick(object sender, System.Windows.RoutedEventArgs e)
        {
            ChangeValue?.Invoke(Item.ID);
            Close();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public event SetIntValue ChangeValue;
        public void OnPropertyChanged(string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
