using Syncfusion.Windows.PropertyGrid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using WPFLocalizeExtension.Extensions;

namespace AipolicyEditor.AIPolicy.Operations.CustomEditors
{
    public class TargetEditor : ITypeEditor
    {
        private ComboboxText Control { get; set; }
        private TargetParam Value { get; set; }
        private List<uint> Values { get; set; }

        public void Attach(PropertyViewItem property, PropertyItem info)
        {
            Value = (TargetParam)info.Value;
            Values = new List<uint>();
            foreach (var v in Enum.GetValues(Value.Target.GetType()))
            {
                Values.Add((uint)v);
            }
            foreach (var name in Enum.GetNames(Value.Target.GetType()))
            {
                string t = MainWindow.Provider.GetLocalizedString("O_" + name);
                Control.CBox.Items.Add(t ?? name);
            }
            var binding1 = new Binding("Value.Target")
            {
                Mode = BindingMode.TwoWay,
                Source = info,
                ValidatesOnExceptions = true,
                ValidatesOnDataErrors = true,
                Converter = new EnumUIntConverter(),
                ConverterParameter = Value.Target.GetType()
            };
            BindingOperations.SetBinding(Control.CBox, ComboBox.TagProperty, binding1);
            var binding2 = new Binding("Value.Occupations")
            {
                Mode = BindingMode.TwoWay,
                Source = info,
                ValidatesOnExceptions = true,
                ValidatesOnDataErrors = true,
                Converter = new StringFormatToIntConverter(),
                UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged
            };
            BindingOperations.SetBinding(Control.Btn, Button.TagProperty, binding2);
            Control.CBox.SelectedIndex = Values.IndexOf((uint)Value.Target);
            Control.Btn.IsEnabled = (EnumTarget)Control.CBox.Tag == EnumTarget.occupation_list;
            Control.Btn.Content = Value.Occupations.ToString();
        }

        public object Create(PropertyInfo PropertyInfo)
        {
            Control = new ComboboxText();
            Control.CBox.SelectionChanged += SelectionChanged;
            Control.Btn.Click += Click;
            return Control;
        }

        private void SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Control.CBox.Tag = Values[Control.CBox.SelectedIndex];
            Control.Btn.IsEnabled = (EnumTarget)Control.CBox.Tag == EnumTarget.occupation_list;
        }

        private void Click(object sender, RoutedEventArgs e)
        {
            MasksEditor me = new MasksEditor((int)Value.Occupations);
            me.ChangeValue += ChangeValue;
            me.ShowDialog();
        }

        private void ChangeValue(int value)
        {
            Control.Btn.Tag = value;
            Control.Btn.Content = value.ToString();
        }

        public void Detach(PropertyViewItem property)
        {

        }
    }
}
