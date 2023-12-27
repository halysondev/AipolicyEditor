using System;
using System.ComponentModel;
using System.IO;
using AipolicyEditor.AIPolicy.Operations.CustomEditors;

namespace AipolicyEditor.AIPolicy.Operations
{

	public class O_86 : IOperation, ICloneable
	{
		[Browsable(false)]
		public int FromVersion => 35;

		[Browsable(false)]
		public int OperID => 86;

		[Browsable(false)]
		public string Name => MainWindow.Provider.GetLocalizedString("o86");

		[LocalizedDisplayName("MonsterID")]
		[LocalizedCategory("OperationParam")]
		public int MonsterID { get; set; }

		[LocalizedDisplayName("Value2")]
		[LocalizedCategory("OperationParam")]
		public int Value2 { get; set; }

		[LocalizedDisplayName("Value3")]
		[LocalizedCategory("OperationParam")]
		public int Value3 { get; set; }

		[LocalizedDisplayName("Target")]
		[LocalizedCategory("TargetParam")]
		public TargetParam Target { get; set; }

		public O_86()
		{
            MonsterID = 0;
			Value2 = 0;
			Value3 = 0;
			Target = new TargetParam();
		}

		public void Read(BinaryReader br)
		{
            MonsterID = br.ReadInt32();
			Value2 = br.ReadInt32();
			Value3 = br.ReadInt32();
			Target = TargetStream.Read(br);
		}

		public void Write(BinaryWriter bw)
		{
			bw.Write(MonsterID);
			bw.Write(Value2);
			bw.Write(Value3);
			TargetStream.Save(bw, Target);
		}

		public bool Search(string str)
		{
			if (MonsterID.ToString().Contains(str) || Value2.ToString().Contains(str) || Value3.ToString().Contains(str))
			{
				return true;
			}
			return false;
		}

		public object Clone()
		{
			return new O_86
			{
                MonsterID = MonsterID,
				Value2 = Value2,
				Value3 = Value3,
				Target = (Target.Clone() as TargetParam)
			};
		}
	}
}
