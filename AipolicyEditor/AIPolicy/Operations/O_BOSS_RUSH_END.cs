using System;
using System.ComponentModel;
using System.IO;
using AipolicyEditor.AIPolicy.Operations.CustomEditors;

namespace AipolicyEditor.AIPolicy.Operations
{

	public class O_BOSS_RUSH_END : IOperation, ICloneable
	{
		[Browsable(false)]
		public int FromVersion => 33;

		[Browsable(false)]
		public int OperID => 66;

		[Browsable(false)]
		public string Name => MainWindow.Provider.GetLocalizedString("o66");

		[LocalizedCategory("OperationParam")]
		[LocalizedDisplayName("id")]
		public int id { get; set; }

		[LocalizedCategory("OperationParam")]
		[LocalizedDisplayName("interfaces")]
		public int interfaces { get; set; }

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

		public O_BOSS_RUSH_END()
		{
			id = 0;
            interfaces = 0;
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
			id = br.ReadInt32();
            interfaces = br.ReadInt32();
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
			bw.Write(id);
			bw.Write(interfaces);
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
			if (id.ToString().Contains(str) || interfaces.ToString().Contains(str)
                || zvMin_X.ToString().Contains(str) || zvMin_Y.ToString().Contains(str) || zvMin_Z.ToString().Contains(str)
                || zvMax_X.ToString().Contains(str) || zvMax_Y.ToString().Contains(str) || zvMax_Z.ToString().Contains(str))
			{
				return true;
			}
			return false;
		}

		public object Clone()
		{
			return new O_BOSS_RUSH_END
			{
				id = id,
                interfaces = interfaces,
                zvMin_X = zvMin_X,
                zvMin_Y = zvMin_Y,
                zvMin_Z = zvMin_Z,
                zvMax_X = zvMax_X,
                zvMax_Y = zvMax_Y,
                zvMax_Z = zvMax_Z,
				Target = (Target.Clone() as TargetParam)
			};
		}
	}
}
