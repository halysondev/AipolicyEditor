using AipolicyEditor.AIPolicy.Operations.CustomEditors;
using System;
using System.ComponentModel;
using System.IO;
using WPFLocalizeExtension.Extensions;

namespace AipolicyEditor.AIPolicy.Operations
{
    public class O_REVISE_GLOBAL : IOperation, ICloneable
    {
        [Browsable(false)]
        public int FromVersion => 7;
        [Browsable(false)]
        public int OperID => 16;
        [Browsable(false)]
        public string Name => MainWindow.Provider.GetLocalizedString("o16");

        //Trigger param
        [LocalizedCategory("OperationParam")]
        [LocalizedDisplayName("ID")]
        public int ID { get; set; }
        [LocalizedCategory("OperationParam")]
        [LocalizedDisplayName("Value")]
        public int Value { get; set; }
        // Target param
        [LocalizedCategory("TargetParam")]
        [LocalizedDisplayName("Target")]
        public TargetParam Target { get; set; }

        public O_REVISE_GLOBAL()
        {
            ID = 0;
            Value = 0;
            Target = new TargetParam();
        }

        public void Read(BinaryReader br)
        {
            ID = br.ReadInt32();
            Value = br.ReadInt32();
            Target = TargetStream.Read(br);
        }

        public void Write(BinaryWriter bw)
        {
            bw.Write(ID);
            bw.Write(Value);
            TargetStream.Save(bw, Target);
        }

        public bool Search(string str)
        {
            if (ID.ToString().Contains(str) || Value.ToString().Contains(str))
                return true;
            else
                return false;
        }

        public object Clone()
        {
            return new O_REVISE_GLOBAL() { ID = ID, Value = Value, Target = Target.Clone() as TargetParam  };
        }
    }
}
