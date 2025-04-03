using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace AipolicyEditor.AIPolicy.Conditions
{
    class ConditionLabel : Label
    {
        public Condition cond { get; set; }

        public ConditionLabel(Condition cond)
        {
            this.cond = cond;
            
            // Create context menu
            ContextMenu = new ContextMenu();
            
            // Add menu items
            MenuItem addItem = new MenuItem { Header = "ADD" };
            addItem.Click += AddItem_Click;
            
            MenuItem delItem = new MenuItem { Header = "DEL" };
            delItem.Click += DelItem_Click;
            
            ContextMenu.Items.Add(addItem);
            ContextMenu.Items.Add(delItem);
        }
        
        private void AddItem_Click(object sender, RoutedEventArgs e)
        {
            if (cond == null)
                return;

            if (cond.Type == 3) // Terminal condition
            {
                // Convert to logical operator (AND or OR)
                cond.Type = 1; // Logical operator
                cond.ID = 7; // Set to AND operator (7 is AND, 6 is OR)
                
                // Create a new right condition
                cond.ConditionRight = Conditions.CreateEmpty();
                
                // Create a copy of current condition as left
                Condition leftCond = new Condition
                {
                    ID = cond.ID,
                    Type = 3,
                    Value = cond.Value
                };
                cond.ConditionLeft = leftCond;
                
                // Reset current condition values
                cond.Value = new object[0];
            }
            else if (cond.Type == 1 || cond.Type == 2)
            {
                // Add a new condition to the right
                if (cond.ConditionRight == null)
                    cond.ConditionRight = Conditions.CreateEmpty();
                
                // Or show the edit dialog for the right condition
                ConditionEdit conditionEdit = new ConditionEdit(cond.ConditionRight);
                conditionEdit.Reload += () => RefreshParentControl();
                conditionEdit.ShowDialog();
            }
            
            RefreshParentControl();
        }
        
        private void DelItem_Click(object sender, RoutedEventArgs e)
        {
            // Find the parent ConditionControl
            ConditionControl parentControl = FindParentConditionControl();
            if (parentControl == null || parentControl.Cond == null)
                return;
                
            // Check if this is a left or right condition
            if (parentControl.Cond.ConditionLeft?.ID == cond.ID)
            {
                parentControl.Cond.ConditionLeft = Conditions.CreateEmpty();
            }
            else if (parentControl.Cond.ConditionRight?.ID == cond.ID)
            {
                parentControl.Cond.ConditionRight = Conditions.CreateEmpty();
            }
            else
            {
                // If this is the root condition
                parentControl.Cond = Conditions.CreateEmpty();
            }
            
            // Refresh the parent control
            parentControl.Reload();
        }
        
        private ConditionControl FindParentConditionControl()
        {
            DependencyObject parent = VisualTreeHelper.GetParent(this);
            while (parent != null && !(parent is ConditionControl))
            {
                parent = VisualTreeHelper.GetParent(parent);
            }
            return parent as ConditionControl;
        }
        
        private void RefreshParentControl()
        {
            ConditionControl parentControl = FindParentConditionControl();
            if (parentControl != null)
            {
                parentControl.Reload();
            }
        }
    }
}
