using Syncfusion.Windows.PropertyGrid;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Controls;
using System.Windows.Data;
using WPFLocalizeExtension.Extensions;

namespace AipolicyEditor.AIPolicy.Operations.CustomEditors
{
    public class TranslatedEnumEditor : ITypeEditor
    {
        private ComboBox Control { get; set; }
        private uint Value { get; set; }
        private List<uint> Values { get; set; }

        public void Attach(PropertyViewItem property, PropertyItem info)
        {
            Value = (uint)info.Value;
            Values = new List<uint>();
            foreach (var v in Enum.GetValues(info.Value.GetType()))
            {
                Values.Add((uint)v);
            }
            foreach (var name in Enum.GetNames(info.Value.GetType()))
            {
                string t = MainWindow.Provider.GetLocalizedString("O_" + name);
                Control.Items.Add(t ?? name);
            }
            var binding = new Binding("Value")
            {
                Mode = BindingMode.TwoWay,
                Source = info,
                ValidatesOnExceptions = true,
                ValidatesOnDataErrors = true,
                Converter = new EnumUIntConverter(),
                ConverterParameter = info.Value.GetType()
            };
            BindingOperations.SetBinding(Control, ComboBox.TagProperty, binding);
            Control.SelectedIndex = Values.IndexOf(Value);
        }

        public object Create(PropertyInfo PropertyInfo)
        {
            Control = new ComboBox();
            Control.SelectionChanged += SelectionChanged;
            return Control;
        }

        private void SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Control.Tag = Values[Control.SelectedIndex];
        }

        public void Detach(PropertyViewItem property)
        {

        }
    }
}
