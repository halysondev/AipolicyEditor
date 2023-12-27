using System;
using System.ComponentModel;
using System.IO;
using AipolicyEditor.AIPolicy.Operations.CustomEditors;

namespace AipolicyEditor.AIPolicy.Operations
{

	public class O_95 : IOperation, ICloneable
	{
		[Browsable(false)]
		public int FromVersion => 39;

		[Browsable(false)]
		public int OperID => 95;

		[Browsable(false)]
		public string Name => MainWindow.Provider.GetLocalizedString("o95");

		[LocalizedDisplayName("Value1")]
		[LocalizedCategory("OperationParam")]
		public byte Value1 { get; set; }

		[LocalizedDisplayName("Target")]
		[LocalizedCategory("TargetParam")]
		public TargetParam Target { get; set; }

		public O_95()
		{
			Value1 = 0;
			Target = new TargetParam();
		}

		public void Read(BinaryReader br)
		{
			Value1 = br.ReadByte();
			Target = TargetStream.Read(br);
		}

		public void Write(BinaryWriter bw)
		{
			bw.Write(Value1);
			TargetStream.Save(bw, Target);
		}

		public bool Search(string str)
		{
			if (Value1.ToString().Contains(str))
			{
				return true;
			}
			return false;
		}

		public object Clone()
		{
			return new O_95
			{
				Value1 = Value1,
				Target = (Target.Clone() as TargetParam)
			};
		}
	}
}
