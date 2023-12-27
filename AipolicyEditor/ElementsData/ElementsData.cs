using AipolicyEditor;
using KuklusDataEditor.Core.Dialogs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using static KuklusDataEditor.Core.Events;

namespace KuklusDataEditor.Core
{
    public class ElementsData
    {
        public short Version { get; set; }
        public short Signature { get; set; }
        public int DialogListIndex { get; set; }
        public List<EList> Lists { get; set; }
        public EDialogList DialogList { get; set; }

        public int CurrentListIndex { get; set; }
        public EList CurrentList
        {
            get => CurrentListIndex > -1 ? Lists[CurrentListIndex] : null;
            set
            {
                if (CurrentListIndex > -1)
                {
                    Lists[CurrentListIndex] = value;
                }
            }
        }

        public List<int> CurrentItems { get; set; }

        public event LoadDataHandler LoadData;

        public event SetStatusTextHandler SetStatusText;
        public event SetProgressMaxHandler SetProgressMax;
        public event SetProgressValueHandler SetProgressValue;
        public event SetProgressNextHandler SetProgressNext;

        public ElementsData()
        {
            Version = 0;
            Signature = 0;
            Lists = new List<EList>();
            DialogList = new EDialogList();
            CurrentListIndex = -1;
            CurrentItems = new List<int>();
        }

        public void Load(string path)
        {
            SetStatusText?.Invoke("Loading Elements.data");
            BinaryReader br = new BinaryReader(File.OpenRead(path));
            Version = br.ReadInt16();
            (Lists, DialogListIndex) = EConfigLoader.LoadConfig(Version);
            if (Lists == null)
            {
                Utils.ShowMessage($"No config for version: {Version}");
                return;
            }
            Signature = br.ReadInt16();
            SetProgressMax?.Invoke(Lists.Count);
            for (int i = 0; i < Lists.Count; ++i)
            {
                SetProgressNext?.Invoke();
                if (Lists[i].Offset > 0)
                    Lists[i].Header = br.ReadBytes(Lists[i].Offset);
                else if (Lists[i].Offset == -1)
                    Lists[i].Header = ReadCustomHeader(br, i);
                if (i == DialogListIndex)
                    DialogList.Load(br);
                else
                {
                    int count = br.ReadInt32();
                    for (int j = 0; j < count; ++j)
                    {
                        EItem item = new EItem(Lists[i].Types.Count);
                        for (int k = 0; k < Lists[i].Types.Count; ++k)
                        {
                            item.Values[k] = ReadValue(br, Lists[i].Types[k], Lists[i].TypeValue.ContainsKey(k) ? Lists[i].TypeValue[k] : 0);
                        }
                        Lists[i].Items.Add(item);
                    }
                }
            }
            br.Close();
            SetProgressValue?.Invoke(0);
            SetStatusText?.Invoke("Elements.data success loaded");
            LoadData?.Invoke(0);
        }

        public void Save(string path)
        {

        }

        private object ReadValue(BinaryReader br, EDataTypes type, object value)
        {
            switch (type)
            {
                case EDataTypes.EInt32:
                case EDataTypes.EID:
                case EDataTypes.EItem:
                case EDataTypes.EItemProb:
                case EDataTypes.EItemCount:
                case EDataTypes.EAddon:
                case EDataTypes.EAddonProb:
                case EDataTypes.EMask:
                case EDataTypes.EColor:
                case EDataTypes.ELink:
                    return br.ReadInt32();
                case EDataTypes.EFloat:
                    return br.ReadSingle();
                case EDataTypes.ECString:
                case EDataTypes.EIcon:
                case EDataTypes.EModel:
                    return br.ReadBytes(value.ToInt32()).ToGBK().Split('\0')[0];
                case EDataTypes.EUString:
                case EDataTypes.EName:
                    return br.ReadBytes(value.ToInt32()).ToUnicode().Split('\0')[0];
                case EDataTypes.ENull:
                default:
                    return "";
            }
        }

        private byte[] ReadCustomHeader(BinaryReader br, int list)
        {
            byte[] head, count, body, tail, header;
            switch(list)
            {
                case 20:
                    head = br.ReadBytes(4);
                    count = br.ReadBytes(4);
                    body = br.ReadBytes(BitConverter.ToInt32(count, 0));
                    tail = br.ReadBytes(4);
                    header = new byte[12 + body.Length];
                    Array.Copy(head, header, 4);
                    Array.Copy(count, 0, header, 4, 4);
                    Array.Copy(body, 0, header, 8, body.Length);
                    Array.Copy(tail, 0, header, 8 + body.Length, 4);
                    return header;
                case 100:
                    head = br.ReadBytes(4);
                    count = br.ReadBytes(4);
                    body = br.ReadBytes(BitConverter.ToInt32(count, 0));
                    header = new byte[8 + body.Length];
                    Array.Copy(head, header, 4);
                    Array.Copy(count, 0, header, 4, 4);
                    Array.Copy(body, 0, header, 8, body.Length);
                    return header;
                default:
                    return new byte[0];
            }
        }
    }
}
