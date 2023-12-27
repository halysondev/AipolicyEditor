using System;
using System.ComponentModel;
using System.IO;
using AipolicyEditor.AIPolicy.Operations.CustomEditors;

namespace AipolicyEditor.AIPolicy.Operations
{

	public class O_91 : IOperation, ICloneable
	{
		[Browsable(false)]
		public int FromVersion => 39;

		[Browsable(false)]
		public int OperID => 91;

		[Browsable(false)]
		public string Name => MainWindow.Provider.GetLocalizedString("o91");

		[LocalizedCategory("OperationParam")]
		[LocalizedDisplayName("ID")]
		public int ID { get; set; }

		[LocalizedCategory("OperationParam")]
		[LocalizedDisplayName("Value1")]
		public int Value1 { get; set; }

		[LocalizedDisplayName("Value2")]
		[LocalizedCategory("OperationParam")]
		public int Value2 { get; set; }

		[LocalizedDisplayName("Value3")]
		[LocalizedCategory("OperationParam")]
		public int Value3 { get; set; }

		[LocalizedDisplayName("Value4")]
		[LocalizedCategory("OperationParam")]
		public int Value4 { get; set; }

		[LocalizedDisplayName("Value5")]
		[LocalizedCategory("OperationParam")]
		public int Value5 { get; set; }

		[LocalizedCategory("TargetParam")]
		[LocalizedDisplayName("Target")]
		public TargetParam Target { get; set; }

		public O_91()
		{
			ID = 0;
			Value1 = 0;
			Value2 = 0;
			Value3 = 0;
			Value4 = 0;
			Value5 = 0;
			Target = new TargetParam();
		}

		public void Read(BinaryReader br)
		{
			ID = br.ReadInt32();
			Value1 = br.ReadInt32();
			Value2 = br.ReadInt32();
			Value3 = br.ReadInt32();
			Value4 = br.ReadInt32();
			Value5 = br.ReadInt32();
			Target = TargetStream.Read(br);
		}

		public void Write(BinaryWriter bw)
		{
			bw.Write(ID);
			bw.Write(Value1);
			bw.Write(Value2);
			bw.Write(Value3);
			bw.Write(Value4);
			bw.Write(Value5);
			TargetStream.Save(bw, Target);
		}

		public bool Search(string str)
		{
			if (Value1.ToString().Contains(str) || Value2.ToString().Contains(str) || Value3.ToString().Contains(str) || Value4.ToString().Contains(str) || Value5.ToString().Contains(str))
			{
				return true;
			}
			return false;
		}

		public object Clone()
		{
			return new O_91
			{
				ID = ID,
				Value1 = Value1,
				Value2 = Value2,
				Value3 = Value3,
				Value4 = Value4,
				Value5 = Value5,
				Target = (Target.Clone() as TargetParam)
			};
		}
	}
}
