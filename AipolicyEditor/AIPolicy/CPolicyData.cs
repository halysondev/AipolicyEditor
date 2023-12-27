using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;

namespace AipolicyEditor.AIPolicy
{
    public class CPolicyData : ICloneable
    {
        public static int MaxVersion { get; set; } = 0;

        public int Version { get; set; }
        public int ID { get; set; }
        public ObservableCollection<CTriggerData> Triggers { get; set; }

        public CPolicyData()
        {
            Version = 0;
            ID = 0;
            Triggers = new ObservableCollection<CTriggerData>();
        }

        public void Read(BinaryReader br)
        {
            Version = br.ReadInt32();
            if (MaxVersion < Version)
                MaxVersion = Version;
            ID = br.ReadInt32();
            int count = br.ReadInt32();
            Triggers = new ObservableCollection<CTriggerData>();
            for (int i = 0; i < count; ++i)
            {
                CTriggerData t = new CTriggerData();
                t.Read(br);
                Triggers.Add(t);
            }
        }

        public void Write(BinaryWriter bw)
        {
            bw.Write(Version);
            bw.Write(ID);
            bw.Write(Triggers.Count);
            for (int i = 0; i < Triggers.Count; ++i)
            {
                Triggers[i].Write(bw);
            }
        }

        public object Clone()
        {
            var data = new CPolicyData() { Version = Version, ID = ID };
            foreach (CTriggerData t in Triggers)
            {
                data.Triggers.Add(t.Clone() as CTriggerData);
            }
            return data;
        }
    }
}
