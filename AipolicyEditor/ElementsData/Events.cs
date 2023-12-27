namespace KuklusDataEditor.Core
{
    public class Events
    {
        public delegate void LoadDataHandler(byte t);

        public delegate void SetStatusTextHandler(string text);
        public delegate void SetProgressMaxHandler(int value);
        public delegate void SetProgressValueHandler(int value);
        public delegate void SetProgressNextHandler();
    }
}
