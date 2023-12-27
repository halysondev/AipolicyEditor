using System;
using System.ComponentModel;
using System.IO;
using AipolicyEditor.AIPolicy.Operations.CustomEditors;

namespace AipolicyEditor.AIPolicy.Operations
{

	public class O_67 : IOperation, ICloneable
	{
		[Browsable(false)]
		public int FromVersion => 33;

		[Browsable(false)]
		public int OperID => 67;

		[Browsable(false)]
		public string Name => MainWindow.Provider.GetLocalizedString("o67");

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

        [LocalizedCategory("OperationParam")]
		[LocalizedDisplayName("uSkill")]
		public int uSkill { get; set; }

		[LocalizedCategory("TargetParam")]
		[LocalizedDisplayName("Target")]
		public TargetParam Target { get; set; }

		public O_67()
		{
            zvMin_X = 0;
            zvMin_Y = 0;
            zvMin_Z = 0;
            zvMax_X = 0;
            zvMax_Y = 0;
            zvMax_Z = 0;
            uSkill = 0;
			Target = new TargetParam();
		}

		public void Read(BinaryReader br)
		{
            zvMin_X = br.ReadSingle();
            zvMin_Y = br.ReadSingle();
            zvMin_Z = br.ReadSingle();
            zvMax_X = br.ReadSingle();
            zvMax_Y = br.ReadSingle();
            zvMax_Z = br.ReadSingle();
            uSkill = br.ReadInt32();
			Target = TargetStream.Read(br);
		}

		public void Write(BinaryWriter bw)
		{
            bw.Write(zvMin_X);
            bw.Write(zvMin_Y);
            bw.Write(zvMin_Z);
            bw.Write(zvMax_X);
            bw.Write(zvMax_Y);
			bw.Write(zvMax_Z);
            bw.Write(uSkill);
			TargetStream.Save(bw, Target);
		}

		public bool Search(string str)
		{
			if (uSkill.ToString().Contains(str))
			{
				return true;
			}
			return false;
		}

		public object Clone()
		{
			return new O_67
			{
                uSkill = uSkill,
				Target = (Target.Clone() as TargetParam)
			};
		}
	}
}