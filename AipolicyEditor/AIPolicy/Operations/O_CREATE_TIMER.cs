using AipolicyEditor.AIPolicy.Operations.CustomEditors;
using System;
using System.ComponentModel;
using System.IO;
using WPFLocalizeExtension.Extensions;

namespace AipolicyEditor.AIPolicy.Operations
{
    public class O_CREATE_TIMER : IOperation, ICloneable
    {
        [Browsable(false)]
        public int FromVersion => 1;
        [Browsable(false)]
        public int OperID => 7;
        [Browsable(false)]
        public string Name => MainWindow.Provider.GetLocalizedString("o7");

        //Trigger param
        [LocalizedCategory("OperationParam")]
        [LocalizedDisplayName("ID")]
        public uint ID { get; set; }
        [LocalizedCategory("OperationParam")]
        [LocalizedDisplayName("Period")]
        public uint Period { get; set; }
        [LocalizedCategory("OperationParam")]
        [LocalizedDisplayName("Counter")]
        public uint Counter { get; set; }
        // Target param
        [LocalizedCategory("TargetParam")]
        [LocalizedDisplayName("Target")]
        public TargetParam Target { get; set; }

        public O_CREATE_TIMER()
        {
            ID = 0;
            Period = 0;
            Counter = 0;
            Target = new TargetParam();
        }

        public void Read(BinaryReader br)
        {
            ID = br.ReadUInt32();
            Period = br.ReadUInt32();
            Counter = br.ReadUInt32();
            Target = TargetStream.Read(br);
        }

        public void Write(BinaryWriter bw)
        {
            bw.Write(ID);
            bw.Write(Period);
            bw.Write(Counter);
            TargetStream.Save(bw, Target);
        }

        public bool Search(string str)
        {
            if (ID.ToString().Contains(str) || Period.ToString().Contains(str) || Counter.ToString().Contains(str))
                return true;
            else
                return false;
        }

        public object Clone()
        {
            return new O_CREATE_TIMER() { ID = ID, Period = Period, Counter = Counter, Target = Target.Clone() as TargetParam  };
        }
    }
}
