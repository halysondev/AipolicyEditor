namespace AipolicyEditor.ElementsData
{
    public class EItem
    {
        public object[] Values { get; set; }

        public EItem(int len)
        {
            Values = new object[len];
        }
    }
}
