using AipolicyEditor.AIPolicy.Operations.CustomEditors;
using System;
using System.ComponentModel;
using System.IO;
using WPFLocalizeExtension.Extensions;

namespace AipolicyEditor.AIPolicy.Operations
{
    public class O_USE_SKILL_2 : IOperation, ICloneable
    {
        [Browsable(false)]
        public int FromVersion => 20;
        [Browsable(false)]
        public int OperID => 26;
        [Browsable(false)]
        public string Name => MainWindow.Provider.GetLocalizedString("o26");

        //Trigger param
        [LocalizedCategory("OperationParam")]
        [LocalizedDisplayName("Skill")]
        public SkillID Skill { get; set; }
        [LocalizedCategory("OperationParam")]
        [LocalizedDisplayName("SkillType")]
        public uint SkillType { get; set; }
        [LocalizedCategory("OperationParam")]
        [LocalizedDisplayName("Level")]
        public uint Level { get; set; }
        [LocalizedCategory("OperationParam")]
        [LocalizedDisplayName("LevelType")]
        public uint LevelType { get; set; }
        // Target param
        [LocalizedCategory("TargetParam")]
        [LocalizedDisplayName("Target")]
        public TargetParam Target { get; set; }

        public O_USE_SKILL_2()
        {
            Skill = new SkillID();
            SkillType = 0;
            Level = 0;
            LevelType = 0;
            Target = new TargetParam();
        }

        public void Read(BinaryReader br)
        {
            Skill = new SkillID() { Value = br.ReadUInt32() };
            SkillType = br.ReadUInt32();
            Level = br.ReadUInt32();
            LevelType = br.ReadUInt32();
            Target = TargetStream.Read(br);
        }

        public void Write(BinaryWriter bw)
        {
            bw.Write(Skill.Value);
            bw.Write(SkillType);
            bw.Write(Level);
            bw.Write(LevelType);
            TargetStream.Save(bw, Target);
        }

        public bool Search(string str)
        {
            if (Skill.Value.ToString().Contains(str) || SkillType.ToString().Contains(str) ||
                Level.ToString().Contains(str) || LevelType.ToString().Contains(str))
                return true;
            else
                return false;
        }

        public object Clone()
        {
            return new O_USE_SKILL_2() { Skill = Skill, SkillType = SkillType, Level = Level, LevelType = LevelType, Target = Target.Clone() as TargetParam  };
        }
    }
}
