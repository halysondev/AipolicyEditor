using System.Windows.Controls;

namespace AipolicyEditor.AIPolicy.Conditions
{
    class ConditionLabel : Label
    {
        public Condition cond { get; set; }

        public ConditionLabel(Condition cond)
        {
            this.cond = cond;
        }
    }
}
