using System;
using System.ComponentModel;
using System.IO;
using AipolicyEditor.AIPolicy.Operations.CustomEditors;

namespace AipolicyEditor.AIPolicy.Operations
{
	public class O_BOSS_RUSH_AWARD : IOperation, ICloneable
	{
		[Browsable(false)]
		public int FromVersion => 33;

		[Browsable(false)]
		public int OperID => 65;

		[Browsable(false)]
		public string Name => MainWindow.Provider.GetLocalizedString("o65");

        private byte[] bytes = new byte[3];

        [LocalizedCategory("OperationParam")]
		[LocalizedDisplayName("Active")]
		public bool Active { get; set; }

		[LocalizedDisplayName("ItemId_1")]
		[LocalizedCategory("OperationParam")]
		public int ItemId_1 { get; set; }

		[LocalizedCategory("OperationParam")]
		[LocalizedDisplayName("Qnt_1")]
		public int Qnt_1 { get; set; }

		[LocalizedDisplayName("ItemId_2")]
		[LocalizedCategory("OperationParam")]
		public int ItemId_2 { get; set; }

		[LocalizedCategory("OperationParam")]
		[LocalizedDisplayName("Qnt_2")]
		public int Qnt_2 { get; set; }

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

		[LocalizedDisplayName("Target")]
		[LocalizedCategory("TargetParam")]
		public TargetParam Target { get; set; }

		public O_BOSS_RUSH_AWARD()
		{
			Active = false;
			bytes = new byte[3];
			ItemId_1 = 0;
			Qnt_1 = 0;
			ItemId_2 = 0;
			Qnt_2 = 0;
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
            Active = br.ReadBoolean();
			bytes = br.ReadBytes(3);
            ItemId_1 = br.ReadInt32();
            Qnt_1 = br.ReadInt32();
            ItemId_2 = br.ReadInt32();
            Qnt_2 = br.ReadInt32();
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
			bw.Write(Active);
			bw.Write(bytes);
			bw.Write(ItemId_1);
			bw.Write(Qnt_1);
			bw.Write(ItemId_2);
			bw.Write(Qnt_2);
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
			if (Active.ToString().Contains(str) || ItemId_1.ToString().Contains(str) || ItemId_2.ToString().Contains(str) || Qnt_2.ToString().Contains(str) || 
				zvMin_X.ToString().Contains(str) || zvMin_Y.ToString().Contains(str) || zvMin_Z.ToString().Contains(str) || zvMax_X.ToString().Contains(str) ||
                zvMax_Y.ToString().Contains(str) || zvMax_Z.ToString().Contains(str) || Qnt_1.ToString().Contains(str))
            {
				return true;
			}
			return false;
		}

		public object Clone()
		{
			return new O_BOSS_RUSH_AWARD
            {
                Active = Active,
                ItemId_1 = ItemId_1,
                Qnt_1 = Qnt_1,
                ItemId_2 = ItemId_2,
                Qnt_2 = Qnt_2,
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
