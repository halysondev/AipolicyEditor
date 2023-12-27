using AipolicyEditor.AIPolicy.Operations.CustomEditors;
using System;
using System.ComponentModel;
using System.IO;
using WPFLocalizeExtension.Extensions;

namespace AipolicyEditor.AIPolicy.Operations
{
    public class O_AUTO_BIND_CARRIER : IOperation, ICloneable
    {
        [Browsable(false)]
        public int FromVersion => 28;
        [Browsable(false)]
        public int OperID => 40;
        [Browsable(false)]
        public string Name => MainWindow.Provider.GetLocalizedString("o40");

        //Trigger param
        [LocalizedCategory("OperationParam")]
        [LocalizedDisplayName("range")]
        public float range { get; set; }

        // Target param
        [LocalizedCategory("TargetParam")]
        [LocalizedDisplayName("Target")]
        public TargetParam Target { get; set; }

        public O_AUTO_BIND_CARRIER()
        {
            range = 0;
            Target = new TargetParam();
        }

        public void Read(BinaryReader br)
        {
            range = br.ReadSingle();
            Target = TargetStream.Read(br);
        }

        public void Write(BinaryWriter bw)
        {
            bw.Write(range);
            TargetStream.Save(bw, Target);
        }

        public bool Search(string str)
        {
            if (range.ToString().Contains(str))
                return true;
            else
                return false;
        }

        public object Clone()
        {
            return new O_AUTO_BIND_CARRIER() { range = range, Target = Target.Clone() as TargetParam  };
        }
    }
}
