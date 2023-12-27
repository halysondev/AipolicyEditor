using System;
using System.ComponentModel;
using System.IO;
using AipolicyEditor.AIPolicy.Operations.CustomEditors;

namespace AipolicyEditor.AIPolicy.Operations
{

	public class O_104 : IOperation, ICloneable
	{
		[Browsable(false)]
		public int FromVersion => 40;

		[Browsable(false)]
		public int OperID => 104;

		[Browsable(false)]
		public string Name => MainWindow.Provider.GetLocalizedString("o104");

		[LocalizedCategory("OperationParam")]
		[LocalizedDisplayName("Value1")]
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

		[LocalizedCategory("OperationParam")]
		[LocalizedDisplayName("Value5")]
		public int Value5 { get; set; }

		[LocalizedCategory("OperationParam")]
		[LocalizedDisplayName("Value6")]
		public int Value6 { get; set; }

		[LocalizedDisplayName("Value7")]
		[LocalizedCategory("OperationParam")]
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

		[LocalizedDisplayName("Value12")]
		[LocalizedCategory("OperationParam")]
		public int Value12 { get; set; }

		[LocalizedDisplayName("Value13")]
		[LocalizedCategory("OperationParam")]
		public int Value13 { get; set; }

		[LocalizedDisplayName("Value14")]
		[LocalizedCategory("OperationParam")]
		public int Value14 { get; set; }

		[LocalizedCategory("OperationParam")]
		[LocalizedDisplayName("Value15")]
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

		[LocalizedDisplayName("Value21")]
		[LocalizedCategory("OperationParam")]
		public int Value21 { get; set; }

		[LocalizedDisplayName("Value22")]
		[LocalizedCategory("OperationParam")]
		public int Value22 { get; set; }

		[LocalizedCategory("OperationParam")]
		[LocalizedDisplayName("Value23")]
		public int Value23 { get; set; }

		[LocalizedDisplayName("Value24")]
		[LocalizedCategory("OperationParam")]
		public int Value24 { get; set; }

		[LocalizedDisplayName("Value25")]
		[LocalizedCategory("OperationParam")]
		public int Value25 { get; set; }

		[LocalizedCategory("OperationParam")]
		[LocalizedDisplayName("Value26")]
		public int Value26 { get; set; }

		[LocalizedDisplayName("Target")]
		[LocalizedCategory("TargetParam")]
		public TargetParam Target { get; set; }

		public O_104()
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
			Value21 = 0;
			Value22 = 0;
			Value23 = 0;
			Value24 = 0;
			Value25 = 0;
			Value26 = 0;
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
			Value21 = br.ReadInt32();
			Value22 = br.ReadInt32();
			Value23 = br.ReadInt32();
			Value24 = br.ReadInt32();
			Value25 = br.ReadInt32();
			Value26 = br.ReadInt32();
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
			bw.Write(Value21);
			bw.Write(Value22);
			bw.Write(Value23);
			bw.Write(Value24);
			bw.Write(Value25);
			bw.Write(Value26);
			TargetStream.Save(bw, Target);
		}

		public bool Search(string str)
		{
			if (Value1.ToString().Contains(str) || Value2.ToString().Contains(str) || Value3.ToString().Contains(str) || Value4.ToString().Contains(str) || Value5.ToString().Contains(str) || Value6.ToString().Contains(str) || Value7.ToString().Contains(str) || Value8.ToString().Contains(str) || Value8.ToString().Contains(str) || Value10.ToString().Contains(str) || Value11.ToString().Contains(str) || Value12.ToString().Contains(str) || Value13.ToString().Contains(str) || Value14.ToString().Contains(str) || Value15.ToString().Contains(str) || Value16.ToString().Contains(str) || Value17.ToString().Contains(str) || Value18.ToString().Contains(str) || Value19.ToString().Contains(str) || Value20.ToString().Contains(str) || Value21.ToString().Contains(str) || Value22.ToString().Contains(str) || Value23.ToString().Contains(str) || Value24.ToString().Contains(str) || Value25.ToString().Contains(str) || Value26.ToString().Contains(str))
			{
				return true;
			}
			return false;
		}

		public object Clone()
		{
			return new O_104
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
				Value21 = Value21,
				Value22 = Value22,
				Value23 = Value23,
				Value24 = Value24,
				Value25 = Value25,
				Value26 = Value26,
				Target = (Target.Clone() as TargetParam)
			};
		}
	}
}
