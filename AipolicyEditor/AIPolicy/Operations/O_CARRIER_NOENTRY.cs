using AipolicyEditor.AIPolicy.Operations.CustomEditors;
using System;
using System.ComponentModel;
using System.IO;
using WPFLocalizeExtension.Extensions;

namespace AipolicyEditor.AIPolicy.Operations
{
    public class O_CARRIER_NOENTRY : IOperation, ICloneable
    {
        [Browsable(false)]
        public int FromVersion => 30;
        [Browsable(false)]
        public int OperID => 52;
        [Browsable(false)]
        public string Name => MainWindow.Provider.GetLocalizedString("o52");

        //Trigger param
        [LocalizedCategory("OperationParam")]
        [LocalizedDisplayName("iOpen")]
        public int iOpen { get; set; }

        // Target param
        [LocalizedCategory("TargetParam")]
        [LocalizedDisplayName("Target")]
        public TargetParam Target { get; set; }

        public O_CARRIER_NOENTRY()
        {
            iOpen = 0;
            Target = new TargetParam();
        }

        public void Read(BinaryReader br)
        {
            iOpen = br.ReadInt32();
            Target = TargetStream.Read(br);
        }

        public void Write(BinaryWriter bw)
        {
            bw.Write(iOpen);
            TargetStream.Save(bw, Target);
        }

        public bool Search(string str)
        {
            if (iOpen.ToString().Contains(str))
                return true;
            else
                return false;
        }

        public object Clone()
        {
            return new O_CARRIER_NOENTRY() { iOpen = iOpen, Target = Target.Clone() as TargetParam  };
        }
    }
}
