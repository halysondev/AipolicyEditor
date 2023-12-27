using AipolicyEditor.AIPolicy.Operations.CustomEditors;
using System;
using System.ComponentModel;
using System.IO;
using WPFLocalizeExtension.Extensions;

namespace AipolicyEditor.AIPolicy.Operations
{
    public class O_SET_HATE_FIFTY_PERCENT : IOperation, ICloneable
    {
        [Browsable(false)]
        public int FromVersion => 1;
        [Browsable(false)]
        public int OperID => 12;
        [Browsable(false)]
        public string Name => MainWindow.Provider.GetLocalizedString("o12");

        // Target param
        [LocalizedCategory("TargetParam")]
        [LocalizedDisplayName("Target")]
        public TargetParam Target { get; set; }

        public O_SET_HATE_FIFTY_PERCENT()
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
            return new O_SET_HATE_FIFTY_PERCENT() { Target = Target.Clone() as TargetParam  };
        }
    }
}
