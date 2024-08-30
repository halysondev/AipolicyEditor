using AipolicyEditor.AIPolicy.Operations.CustomEditors;
using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using WPFLocalizeExtension.Extensions;

namespace AipolicyEditor.AIPolicy.Operations
{
    public class O_SKILL_WITH_TALK : IOperation
    {
        [Browsable(false)]
        public int FromVersion => 24;
        [Browsable(false)]
        public int OperID => 36;
        [Browsable(false)]
        public string Name => MainWindow.Provider.GetLocalizedString("o36");

        //Trigger param
        [LocalizedDisplayName("uSkill")]
        [LocalizedCategory("OperationParam")]
        public uint uSkill { get; set; }

        [LocalizedDisplayName("uSkillType")]
        [LocalizedCategory("OperationParam")]
        public uint uSkillType { get; set; }

        [LocalizedDisplayName("uLevel")]
        [LocalizedCategory("OperationParam")]
        public uint uLevel { get; set; }

        [LocalizedCategory("OperationParam")]
        [LocalizedDisplayName("Value3")]
        public uint uLevelType { get; set; }

        [LocalizedCategory("OperationParam")]
        [LocalizedDisplayName("Text")]
        public string Text { get; set; }

        [LocalizedDisplayName("Mask")]
        [LocalizedCategory("OperationParam")]
        public int Mask { get; set; }

        [LocalizedDisplayName("Target")]
        [LocalizedCategory("TargetParam")]
        public TargetParam Target { get; set; }

        public O_SKILL_WITH_TALK()
        {
            uSkill = 0;
            uSkillType = 0;
            uLevel = 0;
            uLevelType = 0;
            Text = "";
            Mask = 0;
            Target = new TargetParam();
        }

        public void Read(BinaryReader br)
        {
            uSkill = br.ReadUInt32();
            uSkillType = br.ReadUInt32();
            uLevel = br.ReadUInt32();
            uLevelType = br.ReadUInt32();
            int count = br.ReadInt32();
            Text = br.ReadBytes(count).ToUnicode();
            Mask = br.ReadInt32();
            Target = TargetStream.Read(br);
        }

        public void Write(BinaryWriter bw)
        {
            bw.Write(uSkill);
            bw.Write(uSkillType);
            bw.Write(uLevel);
            bw.Write(uLevelType);
            byte[] bytes = Encoding.Unicode.GetBytes(Text);
            bytes = bytes.Append((System.Byte)0).ToArray();
            bytes = bytes.Append((System.Byte)0).ToArray();
            bw.Write(bytes.Length);
            bw.Write(bytes);
            bw.Write(Mask);
            TargetStream.Save(bw, Target);
        }

        public bool Search(string str)
        {
            if (Text.ToString().Contains(str) || uSkill.ToString().Contains(str) || uSkillType.ToString().Contains(str) || uLevel.ToString().Contains(str) ||
                uLevelType.ToString().Contains(str))
            {
                return true;
            }
            return false;
        }
        
        public object Clone()
        {
            return new O_SKILL_WITH_TALK() { uSkill = uSkill, uSkillType = uSkillType, uLevel = uLevel, uLevelType = uLevelType, Text = Text, Mask = Mask, Target = Target.Clone() as TargetParam };
        }
        
    }
}
