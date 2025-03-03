using System;
using System.ComponentModel;
using System.IO;
using AipolicyEditor.AIPolicy.Operations.CustomEditors;

namespace AipolicyEditor.AIPolicy.Operations
{

	public class O_99 : IOperation, ICloneable
	{
		[Browsable(false)]
		public int FromVersion => 39;

		[Browsable(false)]
		public int OperID => 99;

		[Browsable(false)]
		public string Name => MainWindow.Provider.GetLocalizedString("o99");

		[LocalizedCategory("OperationParam")]
		[LocalizedDisplayName("Value1")]
		public int Value1 { get; set; }

		[LocalizedCategory("OperationParam")]
		[LocalizedDisplayName("Value2")]
		public int Value2 { get; set; }

		[LocalizedDisplayName("Value3")]
		[LocalizedCategory("OperationParam")]
		public int Value3 { get; set; }

		[LocalizedCategory("OperationParam")]
		[LocalizedDisplayName("Value4")]
		public int Value4 { get; set; }

		[LocalizedDisplayName("Value5")]
		[LocalizedCategory("OperationParam")]
		public int Value5 { get; set; }

		[LocalizedDisplayName("Value6")]
		[LocalizedCategory("OperationParam")]
		public int Value6 { get; set; }

		[LocalizedCategory("OperationParam")]
		[LocalizedDisplayName("Value7")]
		public int Value7 { get; set; }

		[LocalizedCategory("OperationParam")]
		[LocalizedDisplayName("Value8")]
		public int Value8 { get; set; }

		[LocalizedDisplayName("Value9")]
		[LocalizedCategory("OperationParam")]
		public int Value9 { get; set; }

		[LocalizedCategory("OperationParam")]
		[LocalizedDisplayName("Value10")]
		public int Value10 { get; set; }

		[LocalizedDisplayName("Value11")]
		[LocalizedCategory("OperationParam")]
		public int Value11 { get; set; }

		[LocalizedDisplayName("Value12")]
		[LocalizedCategory("OperationParam")]
		public int Value12 { get; set; }

		[LocalizedCategory("OperationParam")]
		[LocalizedDisplayName("Value13")]
		public int Value13 { get; set; }

		[LocalizedCategory("OperationParam")]
		[LocalizedDisplayName("Value14")]
		public int Value14 { get; set; }

		[LocalizedDisplayName("Value15")]
		[LocalizedCategory("OperationParam")]
		public int Value15 { get; set; }

		[LocalizedDisplayName("Value16")]
		[LocalizedCategory("OperationParam")]
		public int Value16 { get; set; }

		[LocalizedCategory("OperationParam")]
		[LocalizedDisplayName("Value17")]
		public int Value17 { get; set; }

		[LocalizedDisplayName("Value18")]
		[LocalizedCategory("OperationParam")]
		public int Value18 { get; set; }

		[LocalizedDisplayName("Value19")]
		[LocalizedCategory("OperationParam")]
		public int Value19 { get; set; }

		[LocalizedDisplayName("Value20")]
		[LocalizedCategory("OperationParam")]
		public int Value20 { get; set; }

		[LocalizedCategory("TargetParam")]
		[LocalizedDisplayName("Target")]
		public TargetParam Target { get; set; }

		public O_99()
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
			Value12 = 0;
			Value13 = 0;
			Value14 = 0;
			Value15 = 0;
			Value16 = 0;
			Value17 = 0;
			Value18 = 0;
			Value19 = 0;
			Value20 = 0;
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
			Value12 = br.ReadInt32();
			Value13 = br.ReadInt32();
			Value14 = br.ReadInt32();
			Value15 = br.ReadInt32();
			Value16 = br.ReadInt32();
			Value17 = br.ReadInt32();
			Value18 = br.ReadInt32();
			Value19 = br.ReadInt32();
			Value20 = br.ReadInt32();
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
			bw.Write(Value12);
			bw.Write(Value13);
			bw.Write(Value14);
			bw.Write(Value15);
			bw.Write(Value16);
			bw.Write(Value17);
			bw.Write(Value18);
			bw.Write(Value19);
			bw.Write(Value20);
			TargetStream.Save(bw, Target);
		}

		public bool Search(string str)
		{
			if (Value1.ToString().Contains(str) || Value2.ToString().Contains(str) || Value3.ToString().Contains(str) || Value4.ToString().Contains(str) || Value5.ToString().Contains(str) || Value6.ToString().Contains(str) || Value7.ToString().Contains(str) || Value8.ToString().Contains(str) || Value9.ToString().Contains(str) || Value10.ToString().Contains(str) || Value11.ToString().Contains(str) || Value12.ToString().Contains(str) || Value13.ToString().Contains(str) || Value14.ToString().Contains(str) || Value15.ToString().Contains(str) || Value16.ToString().Contains(str) || Value17.ToString().Contains(str) || Value18.ToString().Contains(str) || Value19.ToString().Contains(str) || Value20.ToString().Contains(str))
			{
				return true;
			}
			return false;
		}

		public object Clone()
		{
			return new O_99
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
				Value12 = Value12,
				Value13 = Value13,
				Value14 = Value14,
				Value15 = Value15,
				Value16 = Value16,
				Value17 = Value17,
				Value18 = Value18,
				Value19 = Value19,
				Value20 = Value20,
				Target = (Target.Clone() as TargetParam)
			};
		}
	}
}
