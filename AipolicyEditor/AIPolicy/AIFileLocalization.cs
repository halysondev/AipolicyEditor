namespace AipolicyEditor.AIPolicy
{
    public partial class AIFile
    {
        public string TriggersHeader
        {
            get
            {
                return $"{MainWindow.Provider.GetLocalizedString("Triggers")} ({MainWindow.Provider.GetLocalizedString("Version")} {CurrentController?.Version})";
            }
            private set { }
        }

        public string OperationsHeader
        {
            get
            {
                return $"{MainWindow.Provider.GetLocalizedString("Operations")} ({MainWindow.Provider.GetLocalizedString("Version")} {CurrentTrigger?.Version})";
            }
            private set { }
        }
    }
}
