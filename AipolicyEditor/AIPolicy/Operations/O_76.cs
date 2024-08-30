using System;
using System.ComponentModel;
using System.IO;
using AipolicyEditor.AIPolicy.Operations.CustomEditors;

namespace AipolicyEditor.AIPolicy.Operations {

	public class O_76 : IOperation, ICloneable
	{
		[Browsable(false)]
		public int FromVersion => 33;

		[Browsable(false)]
		public int OperID => 76;

		[Browsable(false)]
		public string Name => MainWindow.Provider.GetLocalizedString("o76");

        [LocalizedDisplayName("uSkill")]
        [LocalizedCategory("OperationParam")]
        public int uSkill { get; set; }

        [LocalizedCategory("OperationParam")]
        [LocalizedDisplayName("uSkillType")]
        public VarType uSkillType { get; set; }

        [LocalizedDisplayName("uLevel")]
        [LocalizedCategory("OperationParam")]
        public int uLevel { get; set; }

        [LocalizedDisplayName("uLevelType")]
        [LocalizedCategory("OperationParam")]
        public VarType uLevelType { get; set; }

        [LocalizedDisplayName("Target")]
        [LocalizedCategory("TargetParam")]
        public TargetParam Target { get; set; }

		public O_76()
		{
            uSkill = 0;
            uSkillType = 0;
            uLevel = 0;
            uLevelType = 0;
            Target = new TargetParam();
		}

		public void Read(BinaryReader br)
		{
            uSkill = br.ReadInt32();
            uSkillType = (VarType)br.ReadInt32();
            uLevel = br.ReadInt32();
            uLevelType = (VarType)br.ReadInt32();
            Target = TargetStream.Read(br);
		}

		public void Write(BinaryWriter bw)
		{
            bw.Write(uSkill);
            bw.Write(Convert.ToUInt32(uSkillType));
            bw.Write(uLevel);
            bw.Write(Convert.ToUInt32(uLevelType));
            TargetStream.Save(bw, Target);
		}

		public bool Search(string str)
		{
			if (uSkill.ToString().Contains(str) || uSkillType.ToString().Contains(str) || uLevel.ToString().Contains(str) || uLevelType.ToString().Contains(str))
			{
				return true;
			}
			return false;
		}

		public object Clone()
		{
			return new O_76
			{
                uSkill = uSkill,
                uSkillType = uSkillType,
                uLevel = uLevel,
                uLevelType = uLevelType,
				Target = (Target.Clone() as TargetParam)
			};
		}
	}
}
