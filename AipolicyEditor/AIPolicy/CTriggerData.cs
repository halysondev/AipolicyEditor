using System;
using System.Collections.ObjectModel;
using System.IO;

namespace AipolicyEditor.AIPolicy
{
    public class CTriggerData : ICloneable
    {
        public static int MaxVersion { get; set; } = 0;

        public int Version { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }
        public bool Run { get; set; }
        public bool AttackValid { get; set; }
        public int ID { get; set; }
        public Condition RootConditon { get; set; }
        public ObservableCollection<IOperation> Operations { get; set; }

        public CTriggerData()
        {
            Version = 0;
            Name = "new trigger";
            Active = false;
            Run = false;
            AttackValid = false;
            ID = 1;
            RootConditon = new Condition();
            Operations = new ObservableCollection<IOperation>();
        }

        public void Read(BinaryReader br)
        {
            Version = br.ReadInt32();
            if (MaxVersion < Version)
                MaxVersion = Version;
            ID = br.ReadInt32();
            Active = br.ReadBoolean();
            Run = br.ReadBoolean();
            AttackValid = br.ReadBoolean();
            Name = br.ReadBytes(128).ToGBK();
            RootConditon = new Condition();
            RootConditon.Read(br);
            int count = br.ReadInt32();
            Operations = new ObservableCollection<IOperation>();
            for (int i = 0; i < count; ++i)
            {
                int id = br.ReadInt32();
                IOperation p = Operation.Read(br, Version, id);
                Operations.Add(p);
            }
        }

        public void Write(BinaryWriter bw)
        {
            bw.Write(Version);
            bw.Write(ID);
            bw.Write(Active);
            bw.Write(Run);
            bw.Write(AttackValid);
            bw.Write(Name.FromGBK(128));
            RootConditon.Save(bw);
            bw.Write(Operations.Count);
            for (int i = 0; i < Operations.Count; ++i)
            {
                bw.Write(Operations[i].OperID);
                Operations[i].Write(bw);
            }
        }

        public object Clone()
        {
            var data = new CTriggerData() { Version = Version, ID = ID, Active = Active, Run = Run, AttackValid = AttackValid, Name = Name, RootConditon = RootConditon.Clone() as Condition };
            foreach (IOperation o in Operations)
            {
                data.Operations.Add((o as ICloneable).Clone() as IOperation);
            }
            return data;
        }
    }
}
