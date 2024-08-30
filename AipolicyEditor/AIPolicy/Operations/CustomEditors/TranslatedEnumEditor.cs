using Syncfusion.Windows.PropertyGrid;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Controls;
using System.Windows.Data;
using System.ComponentModel;
using System.Windows.Input;

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
            var enumValues = Enum.GetValues(info.Value.GetType());
            var enumNames = Enum.GetNames(info.Value.GetType());

            // Get the last index
            int lastIndex = enumValues.Length - 1;

            // Loop through enum values, except the last one
            for (int i = 0; i < lastIndex; i++)
            {
                var v = enumValues.GetValue(i);
                Values.Add((uint)v);
            }

            // Loop through enum names, except the last one
            for (int i = 0; i < lastIndex; i++)
            {
                string name = enumNames[i];
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
            BindingOperations.SetBinding(Control, ComboBox.SelectedValueProperty, binding);
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
            if (Control.SelectedIndex >= 0 && Control.SelectedIndex < Values.Count)
            {
                Control.Tag = Values[Control.SelectedIndex];
            }
        }

        public void Detach(PropertyViewItem property)
        {
        }

        public object Create(PropertyDescriptor PropertyInfo)
        {
            return null;
        }

        public bool ShouldPropertyGridTryToHandleKeyDown(Key key)
        {
            return false;
        }
    }
}
