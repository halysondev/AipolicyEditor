using AipolicyEditor.AIPolicy.Operations.CustomEditors;
using System;
using System.ComponentModel;
using System.IO;
using WPFLocalizeExtension.Extensions;

namespace AipolicyEditor.AIPolicy.Operations
{
    public class O_ACTIVE_TRIGGER : IOperation, ICloneable
    {
        [Browsable(false)]
        public int FromVersion => 1;
        [Browsable(false)]
        public int OperID => 6;
        [Browsable(false)]
        public string Name => MainWindow.Provider.GetLocalizedString("o6");

        //Trigger param
        [LocalizedCategory("OperationParam")]
        [LocalizedDisplayName("ID")]
        public uint ID { get; set; }
        // Target param
        [LocalizedCategory("TargetParam")]
        [LocalizedDisplayName("Target")]
        public TargetParam Target { get; set; }

        public O_ACTIVE_TRIGGER()
        {
            ID = 0;
            Target = new TargetParam();
        }

        public void Read(BinaryReader br)
        {
            ID = br.ReadUInt32();
            Target = TargetStream.Read(br);
        }

        public void Write(BinaryWriter bw)
        {
            bw.Write(ID);
            TargetStream.Save(bw, Target);
        }

        public bool Search(string str)
        {
            if (ID.ToString().Contains(str))
                return true;
            else
                return false;
        }

        public object Clone()
        {
            return new O_ACTIVE_TRIGGER() { ID = ID, Target = Target.Clone() as TargetParam  };
        }
    }
}
