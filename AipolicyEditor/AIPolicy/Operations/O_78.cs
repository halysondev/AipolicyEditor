using System;
using System.ComponentModel;
using System.IO;
using AipolicyEditor.AIPolicy.Operations.CustomEditors;

namespace AipolicyEditor.AIPolicy.Operations
{

	public class O_78 : IOperation, ICloneable
	{
		[Browsable(false)]
		public int FromVersion => 33;

		[Browsable(false)]
		public int OperID => 78;

		[Browsable(false)]
		public string Name => MainWindow.Provider.GetLocalizedString("o78");

		[LocalizedCategory("OperationParam")]
		[LocalizedDisplayName("Value1")]
		public int Value1 { get; set; }

		[LocalizedCategory("OperationParam")]
		[LocalizedDisplayName("Value1Type")]
		public VarType Value1Type { get; set; }

		[LocalizedCategory("OperationParam")]
		[LocalizedDisplayName("Value3")]
		public int Value2 { get; set; }

		[LocalizedCategory("OperationParam")]
		[LocalizedDisplayName("Value2Type")]
		public VarType Value2Type { get; set; }

		[LocalizedCategory("OperationParam")]
		[LocalizedDisplayName("Value3")]
		public int Value3 { get; set; }

		[LocalizedCategory("OperationParam")]
		[LocalizedDisplayName("Value3Type")]
		public VarType Value3Type { get; set; }

		[LocalizedDisplayName("Value4")]
		[LocalizedCategory("OperationParam")]
		public int Value4 { get; set; }

		[LocalizedCategory("OperationParam")]
		[LocalizedDisplayName("Value4Type")]
		public VarType Value4Type { get; set; }

		[LocalizedCategory("OperationParam")]
		[LocalizedDisplayName("iTargetID")]
		public int iTargetID { get; set; }

		[LocalizedCategory("OperationParam")]
		[LocalizedDisplayName("uTargetType")]
		public VarType uTargetType { get; set; }

		[LocalizedCategory("TargetParam")]
		[LocalizedDisplayName("Target")]
		public TargetParam Target { get; set; }

		public O_78()
		{
			Value1 = 0;
            Value1Type = 0;
            Value2 = 0;
            Value2Type = 0;
            Value3 = 0;
            Value3Type = 0;
            Value4 = 0;
            Value4Type = 0;
            iTargetID = 0;
            uTargetType = 0;
            Target = new TargetParam();
		}

		public void Read(BinaryReader br)
		{
			Value1 = br.ReadInt32();
            Value1Type = (VarType)br.ReadInt32();
            Value2 = br.ReadInt32();
            Value2Type = (VarType)br.ReadInt32();
            Value3 = br.ReadInt32();
            Value3Type = (VarType)br.ReadInt32();
            Value4 = br.ReadInt32();
            Value4Type = (VarType)br.ReadInt32();
            iTargetID = br.ReadInt32();
            uTargetType = (VarType)br.ReadInt32();
			Target = TargetStream.Read(br);
		}

		public void Write(BinaryWriter bw)
		{
			bw.Write(Value1);
			bw.Write(Convert.ToUInt32(Value1Type));
			bw.Write(Value2);
			bw.Write(Convert.ToUInt32(Value2Type));
			bw.Write(Value3);
			bw.Write(Convert.ToUInt32(Value3Type));
			bw.Write(Value4);
			bw.Write(Convert.ToUInt32(Value4Type));
			bw.Write(iTargetID);
			bw.Write(Convert.ToUInt32(uTargetType));
			TargetStream.Save(bw, Target);
		}

		public bool Search(string str)
		{
			if (Value1.ToString().Contains(str) || Value1Type.ToString().Contains(str) || Value2.ToString().Contains(str) 
				|| Value2Type.ToString().Contains(str) || Value3.ToString().Contains(str) || Value3Type.ToString().Contains(str) 
				|| Value4.ToString().Contains(str) || Value4Type.ToString().Contains(str) || iTargetID.ToString().Contains(str) || uTargetType.ToString().Contains(str))
			{
				return true;
			}
			return false;
		}

		public object Clone()
		{
			return new O_78
			{
				Value1 = Value1,
                Value1Type = Value1Type,
                Value2 = Value2,
                Value2Type = Value2Type,
                Value3 = Value3,
                Value3Type = Value3Type,
                Value4 = Value4,
                Value4Type = Value4Type,
                iTargetID = iTargetID,
                uTargetType = uTargetType,
				Target = (Target.Clone() as TargetParam)
			};
		}
	}
}
