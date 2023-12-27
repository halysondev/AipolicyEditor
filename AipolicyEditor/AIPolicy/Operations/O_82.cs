using System;
using System.ComponentModel;
using System.IO;
using AipolicyEditor.AIPolicy.Operations.CustomEditors;

namespace AipolicyEditor.AIPolicy.Operations
{

	public class O_82 : IOperation, ICloneable
	{
		[Browsable(false)]
		public int FromVersion => 35;

		[Browsable(false)]
		public int OperID => 82;

		[Browsable(false)]
		public string Name => MainWindow.Provider.GetLocalizedString("o82");

		[LocalizedDisplayName("MineID")]
		[LocalizedCategory("OperationParam")]
		public int MineID { get; set; }

		[LocalizedDisplayName("fRange")]
		[LocalizedCategory("OperationParam")]
		public float fRange { get; set; }

		[LocalizedDisplayName("Var")]
		[LocalizedCategory("OperationParam")]
		public int Var { get; set; }

		[LocalizedCategory("OperationParam")]
		[LocalizedDisplayName("Value4")]
		public int Value4 { get; set; }

		[LocalizedCategory("OperationParam")]
		[LocalizedDisplayName("Value5")]
		public int Value5 { get; set; }

		[LocalizedCategory("OperationParam")]
		[LocalizedDisplayName("Value6")]
		public int Value6 { get; set; }

		[LocalizedDisplayName("Value7")]
		[LocalizedCategory("OperationParam")]
		public int Value7 { get; set; }

		[LocalizedDisplayName("Target")]
		[LocalizedCategory("TargetParam")]
		public TargetParam Target { get; set; }

		public O_82()
		{
            MineID = 0;
            fRange = 0;
            Var = 0;
			Value4 = 0;
			Value5 = 0;
			Value6 = 0;
			Value7 = 0;
			Target = new TargetParam();
		}

		public void Read(BinaryReader br)
		{
            MineID = br.ReadInt32();
            fRange = br.ReadSingle();
            Var = br.ReadInt32();
			Value4 = br.ReadInt32();
			Value5 = br.ReadInt32();
			Value6 = br.ReadInt32();
			Value7 = br.ReadInt32();
			Target = TargetStream.Read(br);
		}

		public void Write(BinaryWriter bw)
		{
			bw.Write(MineID);
			bw.Write(fRange);
			bw.Write(Var);
			bw.Write(Value4);
			bw.Write(Value5);
			bw.Write(Value6);
			bw.Write(Value7);
			TargetStream.Save(bw, Target);
		}

		public bool Search(string str)
		{
			if (MineID.ToString().Contains(str) || fRange.ToString().Contains(str) || Var.ToString().Contains(str) || Value4.ToString().Contains(str) || Value5.ToString().Contains(str) || Value6.ToString().Contains(str) || Value7.ToString().Contains(str))
			{
				return true;
			}
			return false;
		}

		public object Clone()
		{
			return new O_82
			{
                MineID = MineID,
                fRange = fRange,
                Var = Var,
				Value4 = Value4,
				Value5 = Value5,
				Value6 = Value6,
				Value7 = Value7,
				Target = (Target.Clone() as TargetParam)
			};
		}
	}
}
