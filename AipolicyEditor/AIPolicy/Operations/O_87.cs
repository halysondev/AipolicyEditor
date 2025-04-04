using System;
using System.ComponentModel;
using System.IO;
using AipolicyEditor.AIPolicy.Operations.CustomEditors;

namespace AipolicyEditor.AIPolicy.Operations
{

	public class O_87 : IOperation, ICloneable
	{
		[Browsable(false)]
		public int FromVersion => 35;

		[Browsable(false)]
		public int OperID => 87;

		[Browsable(false)]
		public string Name => MainWindow.Provider.GetLocalizedString("o87");

		[LocalizedDisplayName("Value1")]
		[LocalizedCategory("OperationParam")]
		public int Value1 { get; set; }

		[LocalizedCategory("OperationParam")]
		[LocalizedDisplayName("Value2")]
		public int Value2 { get; set; }

		[LocalizedCategory("OperationParam")]
		[LocalizedDisplayName("Value3")]
		public int Value3 { get; set; }

		[LocalizedCategory("OperationParam")]
		[LocalizedDisplayName("Value4")]
		public int Value4 { get; set; }

		[LocalizedDisplayName("Value5")]
		[LocalizedCategory("OperationParam")]
		public int Value5 { get; set; }

		[LocalizedCategory("OperationParam")]
		[LocalizedDisplayName("Value6")]
		public int Value6 { get; set; }

		[LocalizedCategory("OperationParam")]
		[LocalizedDisplayName("Value7")]
		public int Value7 { get; set; }

		[LocalizedDisplayName("Value8")]
		[LocalizedCategory("OperationParam")]
		public int Value8 { get; set; }

		[LocalizedDisplayName("Value9")]
		[LocalizedCategory("OperationParam")]
		public int Value9 { get; set; }

		[LocalizedCategory("OperationParam")]
		[LocalizedDisplayName("Value10")]
		public int Value10 { get; set; }

		[LocalizedCategory("OperationParam")]
		[LocalizedDisplayName("Value11")]
		public int Value11 { get; set; }

		[LocalizedCategory("TargetParam")]
		[LocalizedDisplayName("Target")]
		public TargetParam Target { get; set; }

		public O_87()
		{
			Value1 = 0;
			Value2 = 0;
			Value3 = 0;
			Value4 = 0;
			Value5 = 0;
			Value6 = 0;
			Value7 = 0;
			Value8 = 0;
			Value9 = 0;
			Value10 = 0;
			Value11 = 0;
			Target = new TargetParam();
		}

		public void Read(BinaryReader br)
		{
			Value1 = br.ReadInt32();
			Value2 = br.ReadInt32();
			Value3 = br.ReadInt32();
			Value4 = br.ReadInt32();
			Value5 = br.ReadInt32();
			Value6 = br.ReadInt32();
			Value7 = br.ReadInt32();
			Value8 = br.ReadInt32();
			Value9 = br.ReadInt32();
			Value10 = br.ReadInt32();
			Value11 = br.ReadInt32();
			Target = TargetStream.Read(br);
		}

		public void Write(BinaryWriter bw)
		{
			bw.Write(Value1);
			bw.Write(Value2);
			bw.Write(Value3);
			bw.Write(Value4);
			bw.Write(Value5);
			bw.Write(Value6);
			bw.Write(Value7);
			bw.Write(Value8);
			bw.Write(Value9);
			bw.Write(Value10);
			bw.Write(Value11);
			TargetStream.Save(bw, Target);
		}

		public bool Search(string str)
		{
			if (Value1.ToString().Contains(str) || Value2.ToString().Contains(str) || Value3.ToString().Contains(str) || Value4.ToString().Contains(str) || Value5.ToString().Contains(str) || Value6.ToString().Contains(str) || Value7.ToString().Contains(str) || Value8.ToString().Contains(str) || Value9.ToString().Contains(str) || Value10.ToString().Contains(str) || Value11.ToString().Contains(str))
			{
				return true;
			}
			return false;
		}

		public object Clone()
		{
			return new O_87
			{
				Value1 = Value1,
				Value2 = Value2,
				Value3 = Value3,
				Value4 = Value4,
				Value5 = Value5,
				Value6 = Value6,
				Value7 = Value7,
				Value8 = Value8,
				Value9 = Value9,
				Value10 = Value10,
				Value11 = Value11,
				Target = (Target.Clone() as TargetParam)
			};
		}
	}
}
