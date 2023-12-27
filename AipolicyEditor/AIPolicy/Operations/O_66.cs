using System;
using System.ComponentModel;
using System.IO;
using AipolicyEditor.AIPolicy.Operations.CustomEditors;

namespace AipolicyEditor.AIPolicy.Operations
{

	public class O_66 : IOperation, ICloneable
	{
		[Browsable(false)]
		public int FromVersion => 33;

		[Browsable(false)]
		public int OperID => 66;

		[Browsable(false)]
		public string Name => MainWindow.Provider.GetLocalizedString("o66");

		[LocalizedCategory("OperationParam")]
		[LocalizedDisplayName("Value1")]
		public int Value1 { get; set; }

		[LocalizedCategory("OperationParam")]
		[LocalizedDisplayName("Value2")]
		public int Value2 { get; set; }

        [LocalizedCategory("OperationParam")]
        [LocalizedDisplayName("zvMin_X")]
        public float zvMin_X { get; set; }

        [LocalizedDisplayName("zvMin_Y")]
        [LocalizedCategory("OperationParam")]
        public float zvMin_Y { get; set; }

        [LocalizedCategory("OperationParam")]
        [LocalizedDisplayName("zvMin_Z")]
        public float zvMin_Z { get; set; }

        [LocalizedCategory("OperationParam")]
        [LocalizedDisplayName("zvMax_X")]
        public float zvMax_X { get; set; }

        [LocalizedDisplayName("zvMax_Y")]
        [LocalizedCategory("OperationParam")]
        public float zvMax_Y { get; set; }

        [LocalizedDisplayName("zvMax_Z")]
        [LocalizedCategory("OperationParam")]
        public float zvMax_Z { get; set; }

        [LocalizedCategory("TargetParam")]
		[LocalizedDisplayName("Target")]
		public TargetParam Target { get; set; }

		public O_66()
		{
			Value1 = 0;
			Value2 = 0;
            zvMin_X = 0;
            zvMin_Y = 0;
            zvMin_Z = 0;
            zvMax_X = 0;
            zvMax_Y = 0;
            zvMax_Z = 0;
            Target = new TargetParam();
		}

		public void Read(BinaryReader br)
		{
			Value1 = br.ReadInt32();
			Value2 = br.ReadInt32();
            zvMin_X = br.ReadSingle();
            zvMin_Y = br.ReadSingle();
            zvMin_Z = br.ReadSingle();
            zvMax_X = br.ReadSingle();
            zvMax_Y = br.ReadSingle();
            zvMax_Z = br.ReadSingle();
            Target = TargetStream.Read(br);
		}

		public void Write(BinaryWriter bw)
		{
			bw.Write(Value1);
			bw.Write(Value2);
            bw.Write(zvMin_X);
            bw.Write(zvMin_Y);
            bw.Write(zvMin_Z);
            bw.Write(zvMax_X);
            bw.Write(zvMax_Y);
            bw.Write(zvMax_Z);
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
			return new O_66
			{
				Value1 = Value1,
				Value2 = Value2,
				Target = (Target.Clone() as TargetParam)
			};
		}
	}
}
