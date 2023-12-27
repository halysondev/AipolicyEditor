using Syncfusion.Windows.PropertyGrid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Controls;
using System.Windows.Data;

namespace AipolicyEditor.AIPolicy.Operations.CustomEditors
{
    public class MineSelector : ITypeEditor
    {
        private BtnText Control { get; set; }

        public void Attach(PropertyViewItem property, PropertyItem info)
        {
            var binding = new Binding("Value.Value")
            {
                Mode = BindingMode.TwoWay,
                Source = info,
                ValidatesOnExceptions = true,
                ValidatesOnDataErrors = true,
                Converter = new StringFormatToIntConverter(),
                UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged
            };
            BindingOperations.SetBinding(Control.Text, TextBox.TextProperty, binding);
        }

        public object Create(PropertyInfo PropertyInfo)
        {
            Control = new BtnText();
            Control.Text.TextChanged += TextChanged;
            Control.Btn.Click += Click;
            return Control;
        }

        private void TextChanged(object sender, TextChangedEventArgs e)
        {
            if (int.TryParse(Control.Text.Text, out int id))
            {
                Control.Btn.Content = CustomData.GetMineName(id);
            }
        }

        private void Click(object sender, System.Windows.RoutedEventArgs e)
        {
            CustomDataSelector cds = new CustomDataSelector(CustomData.Mines);
            cds.ChangeValue += ChangeValue;
            cds.ShowDialog();
        }

        private void ChangeValue(int value)
        {
            Control.Text.Text = value.ToString();
        }

        public void Detach(PropertyViewItem property)
        {

        }
    }
}
