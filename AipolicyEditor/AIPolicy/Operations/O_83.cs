using System;
using System.ComponentModel;
using System.IO;
using AipolicyEditor.AIPolicy.Operations.CustomEditors;

namespace AipolicyEditor.AIPolicy.Operations
{

	public class O_83 : IOperation, ICloneable
	{
		[Browsable(false)]
		public int FromVersion => 35;

		[Browsable(false)]
		public int OperID => 83;

		[Browsable(false)]
		public string Name => MainWindow.Provider.GetLocalizedString("o83");

		[LocalizedDisplayName("Min_X")]
		[LocalizedCategory("OperationParam")]
		public float Min_X { get; set; }

		[LocalizedCategory("OperationParam")]
		[LocalizedDisplayName("Min_Y")]
		public float Min_Y { get; set; }

		[LocalizedDisplayName("Min_Z")]
		[LocalizedCategory("OperationParam")]
		public float Min_Z { get; set; }

		[LocalizedCategory("OperationParam")]
		[LocalizedDisplayName("Max_X")]
		public float Max_X { get; set; }

		[LocalizedDisplayName("Max_Y")]
		[LocalizedCategory("OperationParam")]
		public float Max_Y { get; set; }

		[LocalizedDisplayName("Max_Z")]
		[LocalizedCategory("OperationParam")]
		public float Max_Z { get; set; }

		[LocalizedCategory("OperationParam")]
		[LocalizedDisplayName("MonsterID")]
		public float MonsterID { get; set; }

		[LocalizedCategory("OperationParam")]
		[LocalizedDisplayName("Var")]
		public int Var { get; set; }

		[LocalizedDisplayName("Value8")]
		[LocalizedCategory("OperationParam")]
		public int Value8 { get; set; }

		[LocalizedDisplayName("Value9")]
		[LocalizedCategory("OperationParam")]
		public int Value9 { get; set; }

        [LocalizedDisplayName("Value10")]
        [LocalizedCategory("OperationParam")]
        public int Value10 { get; set; }

        [LocalizedCategory("TargetParam")]
		[LocalizedDisplayName("Target")]
		public TargetParam Target { get; set; }

		public O_83()
		{
            Min_X = 0;
            Min_Y = 0;
            Min_Z = 0;
            Max_X = 0;
            Max_Y = 0;
            Max_Z = 0;
            MonsterID = 0;
            Var = 0;
			Value8 = 0;
			Value9 = 0;
			Value10 = 0;
			Target = new TargetParam();
		}

		public void Read(BinaryReader br)
		{
            Min_X = br.ReadSingle();
            Min_Y = br.ReadSingle();
            Min_Z = br.ReadSingle();
            Max_X = br.ReadSingle();
            Max_Y = br.ReadSingle();
            Max_Z = br.ReadSingle();
            MonsterID = br.ReadInt32();
            Var = br.ReadInt32();
            Value8 = br.ReadInt32();
            Value9 = br.ReadInt32();
            Value10 = br.ReadInt32();
			Target = TargetStream.Read(br);
		}

		public void Write(BinaryWriter bw)
		{
			bw.Write(Min_X);
			bw.Write(Min_Y);
			bw.Write(Min_Z);
			bw.Write(Max_X);
			bw.Write(Max_Y);
			bw.Write(Max_Z);
			bw.Write(MonsterID);
			bw.Write(Var);
			bw.Write(Value8);
			bw.Write(Value9);
			bw.Write(Value10);
			TargetStream.Save(bw, Target);
		}

		public bool Search(string str)
		{
			if (Min_X.ToString().Contains(str) 
				|| Min_Y.ToString().Contains(str) 
				|| Min_Z.ToString().Contains(str) 
				|| Max_X.ToString().Contains(str) 
				|| Max_Y.ToString().Contains(str) 
				|| Max_Z.ToString().Contains(str) 
				|| MonsterID.ToString().Contains(str) 
				|| Var.ToString().Contains(str) 
				|| Value8.ToString().Contains(str) 
				|| Value9.ToString().Contains(str) 
				|| Value10.ToString().Contains(str))
			{
				return true;
			}
			return false;
		}

		public object Clone()
		{
			return new O_83
			{
                Min_X = Min_X,
                Min_Y = Min_Y,
                Min_Z = Min_Z,
                Max_X = Max_X,
                Max_Y = Max_Y,
                Max_Z = Max_Z,
                MonsterID = MonsterID,
                Var = Var,
                Value8 = Value8,
                Value9 = Value9,
                Value10 = Value10,
				Target = (Target.Clone() as TargetParam)
			};
		}
	}
}
