using System;
using System.ComponentModel;
using System.IO;
using AipolicyEditor.AIPolicy.Operations.CustomEditors;

namespace AipolicyEditor.AIPolicy.Operations
{

	public class O_90 : IOperation, ICloneable
	{
		[Browsable(false)]
		public int FromVersion => 39;

		[Browsable(false)]
		public int OperID => 90;

		[Browsable(false)]
		public string Name => MainWindow.Provider.GetLocalizedString("o90");

		[LocalizedCategory("OperationParam")]
		[LocalizedDisplayName("Value1")]
		public float Value1 { get; set; }

		[LocalizedCategory("OperationParam")]
		[LocalizedDisplayName("Value2")]
		public int Value2 { get; set; }

		[LocalizedCategory("OperationParam")]
		[LocalizedDisplayName("Value3")]
		public int Value3 { get; set; }

		[LocalizedCategory("OperationParam")]
		[LocalizedDisplayName("Value4")]
		public int Value4 { get; set; }

		[LocalizedCategory("TargetParam")]
		[LocalizedDisplayName("Target")]
		public TargetParam Target { get; set; }

		public O_90()
		{
			Value1 = 0;
			Value2 = 0;
			Value3 = 0;
			Value4 = 0;
			Target = new TargetParam();
		}

		public void Read(BinaryReader br)
		{
			Value1 = br.ReadSingle();
			Value2 = br.ReadInt32();
			Value3 = br.ReadInt32();
			Value4 = br.ReadInt32();
			Target = TargetStream.Read(br);
		}

		public void Write(BinaryWriter bw)
		{
			bw.Write(Value1);
			bw.Write(Value2);
			bw.Write(Value3);
			bw.Write(Value4);
			TargetStream.Save(bw, Target);
		}

		public bool Search(string str)
		{
			if (Value1.ToString().Contains(str) || Value2.ToString().Contains(str) || Value3.ToString().Contains(str) || Value4.ToString().Contains(str))
			{
				return true;
			}
			return false;
		}

		public object Clone()
		{
			return new O_90
			{
				Value1 = Value1,
				Value2 = Value2,
				Value3 = Value3,
				Value4 = Value4,
				Target = (Target.Clone() as TargetParam)
			};
		}
	}
}
