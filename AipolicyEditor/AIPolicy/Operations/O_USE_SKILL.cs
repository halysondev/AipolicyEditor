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
    public class O_USE_SKILL : IOperation, ICloneable
    {
        [Browsable(false)]
        public int FromVersion => 1;
        [Browsable(false)]
        public int OperID => 1;
        [Browsable(false)]
        public string Name => MainWindow.Provider.GetLocalizedString("o1");

        //Trigger param
        [LocalizedCategory("OperationParam")]
        [LocalizedDisplayName("Skill")]
        public SkillID Skill { get; set; }
        [LocalizedCategory("OperationParam")]
        [LocalizedDisplayName("Level")]
        public uint Level { get; set; }
        // Target param
        [LocalizedCategory("TargetParam")]
        [LocalizedDisplayName("Target")]
        public TargetParam Target { get; set; }

        public O_USE_SKILL()
        {
            Skill = new SkillID();
            Level = 0;
            Target = new TargetParam();
        }

        public void Read(BinaryReader br)
        {
            Skill = new SkillID() { Value = br.ReadUInt32() };
            Level = br.ReadUInt32();
            Target = TargetStream.Read(br);
        }

        public void Write(BinaryWriter bw)
        {
            bw.Write(Skill.Value);
            bw.Write(Level);
            TargetStream.Save(bw, Target);
        }

        public bool Search(string str)
        {
            if (Skill.Value.ToString().Contains(str) || Level.ToString().Contains(str))
                return true;
            else
                return false;
        }

        public object Clone()
        {
            return new O_USE_SKILL() { Skill = Skill, Level = Level, Target = Target.Clone() as TargetParam  };
        }
    }
}
