using System.Collections.Generic;

namespace KuklusDataEditor.Core
{
    public class EList
    {
        public string Name { get; set; }
        public int Offset { get; set; }
        public byte[] Header { get; set; }
        public List<string> Fields { get; set; }
        public List<string> FieldsTranslated { get; set; }
        public List<EDataTypes> Types { get; set; }
        public Dictionary<int, object> TypeValue { get; set; }
        public List<EItem> Items { get; set; }

        // Special fields
        public bool HasIcon { get; set; }
        public int IDIndex { get; set; }
        public int NameIndex { get; set; }
        public int IconIndex { get; set; }

        public EList()
        {
            Name = "";
            Offset = 0;
            Header = new byte[0];
            Fields = new List<string>();
            FieldsTranslated = new List<string>();
            Types = new List<EDataTypes>();
            TypeValue = new Dictionary<int, object>();
            Items = new List<EItem>();
            HasIcon = false;
            IDIndex = 0;
            NameIndex = 1;
            IconIndex = -1;
        }

        public string GetSpecialValue(EDataTypes e, int index)
        {
            switch(e)
            {
                case EDataTypes.EID:
                    return Items[index].Values[IDIndex].ToString();
                case EDataTypes.EName:
                    return Items[index].Values[NameIndex].ToString();
                case EDataTypes.EIcon:
                    return HasIcon ? Items[index].Values[IconIndex].ToString() : "";
                default:
                    return "";
            }
        }
    }
}
