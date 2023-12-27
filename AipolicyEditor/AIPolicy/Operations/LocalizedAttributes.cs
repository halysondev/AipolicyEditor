using System.ComponentModel;
using System.IO;
using WPFLocalizeExtension.Extensions;

namespace AipolicyEditor.AIPolicy.Operations
{
    public class LocalizedCategoryAttribute : CategoryAttribute
    {
        public LocalizedCategoryAttribute(string categoryKey) : base(categoryKey) { }

        protected override string GetLocalizedString(string value)
        {
            string s = MainWindow.Provider.GetLocalizedString("O_" + value);
            return s ?? value;
        }
    }

    public class LocalizedDisplayNameAttribute : DisplayNameAttribute
    {
        private string Value { get; set; }

        public LocalizedDisplayNameAttribute(string nameKey) : base(nameKey) { Value = nameKey; }

        public override string DisplayName
        {
            get
            {
                string s = MainWindow.Provider.GetLocalizedString("O_" + Value);
                return s ?? Value;
            }
        }
    }
}
