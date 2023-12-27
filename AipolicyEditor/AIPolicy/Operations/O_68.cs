using System;
using System.ComponentModel;
using System.IO;
using AipolicyEditor.AIPolicy.Operations.CustomEditors;

namespace AipolicyEditor.AIPolicy.Operations
{

	public class O_68 : IOperation, ICloneable
	{
		[Browsable(false)]
		public int FromVersion => 33;

		[Browsable(false)]
		public int OperID => 68;

		[Browsable(false)]
		public string Name => MainWindow.Provider.GetLocalizedString("o68");

		[LocalizedDisplayName("Value1")]
		[LocalizedCategory("OperationParam")]
		public float Value1 { get; set; }

		[LocalizedCategory("OperationParam")]
		[LocalizedDisplayName("Value1Type")]
		public VarType Value1Type { get; set; }

		[LocalizedDisplayName("Value3")]
		[LocalizedCategory("OperationParam")]
		public float Value3 { get; set; }

		[LocalizedCategory("TargetParam")]
		[LocalizedDisplayName("Target")]
		public TargetParam Target { get; set; }

		public O_68()
		{
			Value1 = 0;
            Value1Type = 0;
			Value3 = 0;
			Target = new TargetParam();
		}

		public void Read(BinaryReader br)
		{
			Value1 = br.ReadSingle();
            Value1Type = (VarType)br.ReadInt32();
			Value3 = br.ReadSingle();
			Target = TargetStream.Read(br);
		}

		public void Write(BinaryWriter bw)
		{
			bw.Write(Value1);
			bw.Write((int)Value1Type);
			bw.Write(Value3);
			TargetStream.Save(bw, Target);
		}

		public bool Search(string str)
		{
			if (Value1.ToString().Contains(str) || Value1Type.ToString().Contains(str) || Value3.ToString().Contains(str))
			{
				return true;
			}
			return false;
		}

		public object Clone()
		{
			return new O_68
			{
				Value1 = Value1,
                Value1Type = Value1Type,
				Value3 = Value3,
				Target = (Target.Clone() as TargetParam)
			};
		}
	}
}
