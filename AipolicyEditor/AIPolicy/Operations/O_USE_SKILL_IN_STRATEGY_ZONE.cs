using System;
using System.ComponentModel;
using System.IO;
using AipolicyEditor.AIPolicy.Operations.CustomEditors;

namespace AipolicyEditor.AIPolicy.Operations
{

	public class O_USE_SKILL_IN_STRATEGY_ZONE : IOperation, ICloneable
	{
		[Browsable(false)]
		public int FromVersion => 33;

		[Browsable(false)]
		public int OperID => 74;

		[Browsable(false)]
		public string Name => MainWindow.Provider.GetLocalizedString("o74");

        [LocalizedDisplayName("ID1")]
        [LocalizedCategory("ControllersParam")]
        public int ID1 { get; set; }

        [LocalizedDisplayName("ID1Type")]
        [LocalizedCategory("ControllersParam")]
        public int ID1Type { get; set; }

        [LocalizedDisplayName("ID2")]
        [LocalizedCategory("ControllersParam")]
        public int ID2 { get; set; }
        [LocalizedDisplayName("ID2Type")]
        [LocalizedCategory("ControllersParam")]
        public int ID2Type { get; set; }

        [LocalizedDisplayName("ID3")]
        [LocalizedCategory("ControllersParam")]
        public int ID3 { get; set; }
        [LocalizedDisplayName("ID3Type")]
        [LocalizedCategory("ControllersParam")]
        public int ID3Type { get; set; }

        [LocalizedDisplayName("ID4")]
        [LocalizedCategory("ControllersParam")]
        public int ID4 { get; set; }
        [LocalizedDisplayName("ID4Type")]
        [LocalizedCategory("ControllersParam")]
        public int ID4Type { get; set; }

        [LocalizedDisplayName("ID5")]
        [LocalizedCategory("ControllersParam")]
        public int ID5 { get; set; }
        [LocalizedDisplayName("ID5Type")]
        [LocalizedCategory("ControllersParam")]
        public int ID5Type { get; set; }

        [LocalizedDisplayName("ID6")]
        [LocalizedCategory("ControllersParam")]
        public int ID6 { get; set; }
        [LocalizedDisplayName("ID6Type")]
        [LocalizedCategory("ControllersParam")]
        public int ID6Type { get; set; }

        [LocalizedCategory("OperationParam")]
		[LocalizedDisplayName("Value2")]
		public int Value2 { get; set; }

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

		public O_USE_SKILL_IN_STRATEGY_ZONE()
		{
            ID1 = 0;
            ID1Type = 0;
            ID2 = 0;
            ID2Type = 0;
            ID3 = 0;
            ID3Type = 0;
            ID4 = 0;
            ID4Type = 0;
            ID5 = 0;
            ID5Type = 0;
            ID6 = 0;
            ID6Type = 0;
            Value2 = 0;
            uSkill = 0;
            uSkillType = 0;
            uLevel = 0;
            uLevelType = 0;
			Target = new TargetParam();
		}

		public void Read(BinaryReader br)
		{
            ID1 = br.ReadInt32();
            ID1Type = br.ReadInt32();
            ID2 = br.ReadInt32();
            ID2Type = br.ReadInt32();
            ID3 = br.ReadInt32();
            ID3Type = br.ReadInt32();
            ID4 = br.ReadInt32();
            ID4Type = br.ReadInt32();
            ID5 = br.ReadInt32();
            ID5Type = br.ReadInt32();
            ID6 = br.ReadInt32();
            ID6Type = br.ReadInt32();
            Value2 = br.ReadInt32();
            uSkill = br.ReadInt32();
            uSkillType = (VarType)br.ReadInt32();
            uLevel = br.ReadInt32();
            uLevelType = (VarType)br.ReadInt32();
			Target = TargetStream.Read(br);
		}

		public void Write(BinaryWriter bw)
		{
            bw.Write(ID1);
            bw.Write(ID1Type);
            bw.Write(ID2);
            bw.Write(ID2Type);
            bw.Write(ID3);
            bw.Write(ID3Type);
            bw.Write(ID4);
            bw.Write(ID4Type);
            bw.Write(ID5);
            bw.Write(ID5Type);
            bw.Write(ID6);
            bw.Write(ID6Type);
            bw.Write(Value2);
			bw.Write(uSkill);
			bw.Write(Convert.ToUInt32(uSkillType));
			bw.Write(uLevel);
			bw.Write(Convert.ToUInt32(uLevelType));
			TargetStream.Save(bw, Target);
		}

		public bool Search(string str)
		{
			if (ID1.ToString().Contains(str) || ID1Type.ToString().Contains(str) || ID2.ToString().Contains(str) || ID2Type.ToString().Contains(str)
                || ID3.ToString().Contains(str) || ID3Type.ToString().Contains(str) || ID4.ToString().Contains(str) || ID4Type.ToString().Contains(str)
                || ID5.ToString().Contains(str) || ID5Type.ToString().Contains(str) || ID6.ToString().Contains(str) || ID6Type.ToString().Contains(str)
                || Value2.ToString().Contains(str) || uSkill.ToString().Contains(str) || uSkillType.ToString().Contains(str) || uLevel.ToString().Contains(str) || uLevelType.ToString().Contains(str)
                )
			{
				return true;
			}
			return false;
		}
            
		public object Clone()
		{
			return new O_USE_SKILL_IN_STRATEGY_ZONE
			{
				ID1 = ID1,
                ID1Type = ID1Type,
                ID2 = ID2,
                ID2Type = ID2Type,
                ID3 = ID3,
                ID3Type = ID3Type,
                ID4 = ID4,
                ID4Type = ID4Type,
                ID5 = ID5,
                ID5Type = ID5Type,
                ID6 = ID6,
                ID6Type = ID6Type,
                Value2 = Value2,
                uSkill = uSkill,
                uSkillType = uSkillType,
                uLevel = uLevel,
                uLevelType = uLevelType,
				Target = (Target.Clone() as TargetParam)
			};
		}
	}
}
