using Syncfusion.Windows.PropertyGrid;
using System;
using System.Reflection;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows;
using System.Windows.Input;
using System.ComponentModel;
using API = UdE.API; // Supondo que API esteja no namespace UdE
using WinForms = System.Windows.Forms; // Adicione a referência para Windows Forms

namespace AipolicyEditor.AIPolicy.Operations.CustomEditors
{
    public class NpcSelector : ITypeEditor
    {
        private BtnText Control { get; set; }
        private System.Windows.Controls.ToolTip toolTip;

        public void Attach(PropertyViewItem property, PropertyItem info)
        {
            var binding = new System.Windows.Data.Binding("Value.Value")
            {
                Mode = BindingMode.TwoWay,
                Source = info,
                ValidatesOnExceptions = true,
                ValidatesOnDataErrors = true,
                Converter = new StringFormatToIntConverter(),
                UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged,
            };
            BindingOperations.SetBinding(Control.Text, System.Windows.Controls.TextBox.TextProperty, binding);
        }

        public object Create(PropertyInfo PropertyInfo)
        {
            Control = new BtnText();
            Control.Text.TextChanged += TextChanged;
            Control.Btn.Click += Click;
            Control.MouseEnter += new System.Windows.Input.MouseEventHandler(ShowToolTip);
            Control.MouseLeave += new System.Windows.Input.MouseEventHandler(HideToolTip);
            Control.MouseMove += new System.Windows.Input.MouseEventHandler(ShowToolTip);
            toolTip = new System.Windows.Controls.ToolTip();
            return Control;
        }

        private void TextChanged(object sender, TextChangedEventArgs e)
        {
            if (int.TryParse(Control.Text.Text, out int id))
            {
                Control.Btn.Content = CustomData.GetMobName(id);
            }
        }

        private void Click(object sender, RoutedEventArgs e)
        {
            if (API.IsElementsEditorRunning)
            {
                Window ownerWindow = System.Windows.Application.Current.MainWindow;
                IntPtr ownerHandle = new System.Windows.Interop.WindowInteropHelper(ownerWindow).Handle;
                IntPtr dialogHandle = API.CreateSelectItemDialog(ownerHandle);
                if (dialogHandle != IntPtr.Zero)
                {
                    int currentItem = 0;
                    if (int.TryParse(Control.Text.Text, out int id))
                    {
                        currentItem = id;
                    }

                    int selectedItemId = API.ShowSelectItemDialogByID(UdE.ItemType.PW_NPC_ESSENCE, currentItem);
                    if (selectedItemId > 0)
                    {
                        Control.Text.Text = selectedItemId.ToString();
                    }
                    API.DestroySelectItemDialog();
                }
                else
                {
                    CustomDataSelector cds = new CustomDataSelector(CustomData.Mobs);
                    cds.ChangeValue += ChangeValue;
                    cds.ShowDialog();
                }
            }
            else
            {
                CustomDataSelector cds = new CustomDataSelector(CustomData.Mobs);
                cds.ChangeValue += ChangeValue;
                cds.ShowDialog();
            }
        }

        private void ShowToolTip(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (int.TryParse(Control.Text.Text, out int id) && id > 0)
            {
                API.ShowToolTip(UdE.ItemType.PW_NPC_ESSENCE, id);
            }
        }

        private void HideToolTip(object sender, System.Windows.Input.MouseEventArgs e)
        {
            API.fHideToolTip();
        }

        public void ShowToolTipUnderCell(object sender, WinForms.DataGridViewCellMouseEventArgs e, int id_column_index, UdE.ItemType type)
        {
            API.ShowToolTipUnderCell(sender, e, id_column_index, type);
        }

        private void ChangeValue(int value)
        {
            Control.Text.Text = value.ToString();
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
