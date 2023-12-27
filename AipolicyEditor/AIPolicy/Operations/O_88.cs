using System;
using System.ComponentModel;
using System.IO;
using AipolicyEditor.AIPolicy.Operations.CustomEditors;

namespace AipolicyEditor.AIPolicy.Operations
{

	public class O_88 : IOperation, ICloneable
	{
		[Browsable(false)]
		public int FromVersion => 35;

		[Browsable(false)]
		public int OperID => 88;

		[Browsable(false)]
		public string Name => MainWindow.Provider.GetLocalizedString("o88");

		[LocalizedCategory("OperationParam")]
		[LocalizedDisplayName("SkillID")]
		public int SkillID { get; set; }

		[LocalizedCategory("OperationParam")]
		[LocalizedDisplayName("SkillType")]
		public int SkillType { get; set; }

		[LocalizedDisplayName("MonsterID")]
		[LocalizedCategory("OperationParam")]
		public int MonsterID { get; set; }

		[LocalizedDisplayName("Target")]
		[LocalizedCategory("TargetParam")]
		public TargetParam Target { get; set; }

		public O_88()
		{
            SkillID = 0;
            SkillType = 0;
            MonsterID = 0;
			Target = new TargetParam();
		}

		public void Read(BinaryReader br)
		{
            SkillID = br.ReadInt32();
            SkillType = br.ReadInt32();
            MonsterID = br.ReadInt32();
			Target = TargetStream.Read(br);
		}

		public void Write(BinaryWriter bw)
		{
			bw.Write(SkillID);
			bw.Write(SkillType);
			bw.Write(MonsterID);
			TargetStream.Save(bw, Target);
		}

		public bool Search(string str)
		{
			if (SkillID.ToString().Contains(str) || SkillType.ToString().Contains(str) || MonsterID.ToString().Contains(str))
			{
				return true;
			}
			return false;
		}

		public object Clone()
		{
			return new O_88
			{
                SkillID = SkillID,
                SkillType = SkillType,
                MonsterID = MonsterID,
				Target = (Target.Clone() as TargetParam)
			};
		}
	}
}
