using AipolicyEditor.AIPolicy.Operations.CustomEditors;
using System;
using System.ComponentModel;
using System.IO;
using WPFLocalizeExtension.Extensions;

namespace AipolicyEditor.AIPolicy.Operations
{
    public class O_CHILD_CARRIER_PARENT_MONSTER : IOperation, ICloneable
    {
        [Browsable(false)]
        public int FromVersion => 33;
        [Browsable(false)]
        public int OperID => 58;
        [Browsable(false)]
        public string Name => MainWindow.Provider.GetLocalizedString("o58");

        //Trigger param
        [LocalizedCategory("OperationParam")]
        [LocalizedDisplayName("fRange")]
        public float fRange { get; set; }

        [LocalizedCategory("OperationParam")]
        [LocalizedDisplayName("iPos")]
        public int iPos { get; set; }

        // Target param
        [LocalizedCategory("TargetParam")]
        [LocalizedDisplayName("Target")]
        public TargetParam Target { get; set; }

        public O_CHILD_CARRIER_PARENT_MONSTER()
        {
            fRange = 0;
            iPos = 0;
            Target = new TargetParam();
        }

        public void Read(BinaryReader br)
        {
            fRange = br.ReadSingle();
            iPos = br.ReadInt32();
            Target = TargetStream.Read(br);
        }

        public void Write(BinaryWriter bw)
        {
            bw.Write(fRange);
            bw.Write(iPos);
            TargetStream.Save(bw, Target);
        }

        public bool Search(string str)
        {
            if (fRange.ToString().Contains(str))
                return true;
            else
                return false;
        }

        public object Clone()
        {
            return new O_CHILD_CARRIER_PARENT_MONSTER() { fRange = fRange, iPos = iPos, Target = Target.Clone() as TargetParam  };
        }
    }
}
