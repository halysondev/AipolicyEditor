using AipolicyEditor.AIPolicy.Operations.CustomEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using WPFLocalizeExtension.Extensions;

namespace AipolicyEditor.AIPolicy.Operations
{
    public class O_ATTACK_TYPE : IOperation, ICloneable
    {
        [Browsable(false)]
        public int FromVersion => 1;
        [Browsable(false)]
        public int OperID => 0;
        [Browsable(false)]
        public string Name => MainWindow.Provider.GetLocalizedString("o0");

        //Trigger param
        [LocalizedCategory("OperationParam")]
        [LocalizedDisplayName("Type")]
        public uint Type { get; set; }
        // Target param
        [LocalizedCategory("TargetParam")]
        [LocalizedDisplayName("Target")]
        public TargetParam Target { get; set; }

        public O_ATTACK_TYPE()
        {
            Type = 0;
            Target = new TargetParam();
        }

        public void Read(BinaryReader br)
        {
            Type = br.ReadUInt32();
            Target = TargetStream.Read(br);
        }

        public void Write(BinaryWriter bw)
        {
            bw.Write(Type);
            TargetStream.Save(bw, Target);
        }

        public bool Search(string str)
        {
            if (Type.ToString().Contains(str))
                return true;
            else
                return false;
        }

        public object Clone()
        {
            return new O_ATTACK_TYPE() { Type = Type, Target = Target.Clone() as TargetParam  };
        }
    }
}
