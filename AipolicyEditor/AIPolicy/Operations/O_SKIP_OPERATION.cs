using AipolicyEditor.AIPolicy.Operations.CustomEditors;
using System;
using System.ComponentModel;
using System.IO;
using WPFLocalizeExtension.Extensions;

namespace AipolicyEditor.AIPolicy.Operations
{
    public class O_SKIP_OPERATION : IOperation, ICloneable
    {
        [Browsable(false)]
        public int FromVersion => 1;
        [Browsable(false)]
        public int OperID => 13;
        [Browsable(false)]
        public string Name => MainWindow.Provider.GetLocalizedString("o13");

        // Target param
        [LocalizedCategory("TargetParam")]
        [LocalizedDisplayName("Target")]
        public TargetParam Target { get; set; }

        public O_SKIP_OPERATION()
        {
            Target = new TargetParam();
        }

        public void Read(BinaryReader br)
        {
            Target = TargetStream.Read(br);
        }

        public void Write(BinaryWriter bw)
        {
            TargetStream.Save(bw, Target);
        }

        public bool Search(string str)
        {
            return false;
        }
        public object Clone()
        {
            return new O_SKIP_OPERATION() { Target = Target.Clone() as TargetParam  };
        }
    }
}
