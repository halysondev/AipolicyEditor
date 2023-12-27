using System;
using System.ComponentModel;
using System.IO;
using AipolicyEditor.AIPolicy.Operations.CustomEditors;

namespace AipolicyEditor.AIPolicy.Operations
{

	public class O_100 : IOperation, ICloneable
	{
		[Browsable(false)]
		public int FromVersion => 40;

		[Browsable(false)]
		public int OperID => 100;

		[Browsable(false)]
		public string Name => MainWindow.Provider.GetLocalizedString("o100");

		[LocalizedDisplayName("Value1")]
		[LocalizedCategory("OperationParam")]
		public int Value1 { get; set; }

		[LocalizedDisplayName("Value2")]
		[LocalizedCategory("OperationParam")]
		public int Value2 { get; set; }

		[LocalizedCategory("TargetParam")]
		[LocalizedDisplayName("Target")]
		public TargetParam Target { get; set; }

		public O_100()
		{
			Value1 = 0;
			Value2 = 0;
			Target = new TargetParam();
		}

		public void Read(BinaryReader br)
		{
			Value1 = br.ReadInt32();
			Value2 = br.ReadInt32();
			Target = TargetStream.Read(br);
		}

		public void Write(BinaryWriter bw)
		{
			bw.Write(Value1);
			bw.Write(Value2);
			TargetStream.Save(bw, Target);
		}

		public bool Search(string str)
		{
			if (Value1.ToString().Contains(str) || Value2.ToString().Contains(str))
			{
				return true;
			}
			return false;
		}

		public object Clone()
		{
			return new O_100
			{
				Value1 = Value1,
				Value2 = Value2,
				Target = (Target.Clone() as TargetParam)
			};
		}
	}
}
