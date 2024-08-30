using System;
using System.ComponentModel;
using System.IO;
using AipolicyEditor.AIPolicy.Operations.CustomEditors;

namespace AipolicyEditor.AIPolicy.Operations
{

	public class O_80 : IOperation, ICloneable
	{
		[Browsable(false)]
		public int FromVersion => 35;

		[Browsable(false)]
		public int OperID => 80;

		[Browsable(false)]
		public string Name => MainWindow.Provider.GetLocalizedString("o80");

		[LocalizedDisplayName("posX")]
		[LocalizedCategory("OperationParam")]
		public float posX { get; set; }

		[LocalizedCategory("OperationParam")]
		[LocalizedDisplayName("posY")]
		public float posY { get; set; }

		[LocalizedCategory("OperationParam")]
		[LocalizedDisplayName("posZ")]
		public float posZ { get; set; }

		[LocalizedCategory("OperationParam")]
		[LocalizedDisplayName("Const")]
		public int Const { get; set; }

		[LocalizedDisplayName("Var")]
		[LocalizedCategory("OperationParam")]
		public int Var { get; set; }

		[LocalizedCategory("OperationParam")]
		[LocalizedDisplayName("VarType")]
		public VarType VarType { get; set; }

		[LocalizedCategory("TargetParam")]
		[LocalizedDisplayName("Target")]
		public TargetParam Target { get; set; }

		public O_80()
		{
			posX = 0;
            posY = 0;
            posZ = 0;
            Const = 0;
            Var = 0;
            VarType = 0;
			Target = new TargetParam();
		}

		public void Read(BinaryReader br)
		{
            posX = br.ReadSingle();
            posY = br.ReadSingle();
            posZ = br.ReadSingle();
            Const = br.ReadInt32();
            Var = br.ReadInt32();
            VarType = (VarType)br.ReadInt32();
			Target = TargetStream.Read(br);
		}

		public void Write(BinaryWriter bw)
		{
			bw.Write(posX);
			bw.Write(posY);
			bw.Write(posZ);
			bw.Write(Const);
			bw.Write(Var);
			bw.Write(Convert.ToUInt32(VarType));
			TargetStream.Save(bw, Target);
		}

		public bool Search(string str)
		{
			if (posX.ToString().Contains(str) || posY.ToString().Contains(str) || posZ.ToString().Contains(str) || Const.ToString().Contains(str) || Var.ToString().Contains(str) || VarType.ToString().Contains(str))
			{
				return true;
			}
			return false;
		}

		public object Clone()
		{
			return new O_80
			{
                posX = posX,
                posY = posY,
                posZ = posZ,
                Const = Const,
                Var = Var,
                VarType = VarType,
				Target = (Target.Clone() as TargetParam)
			};
		}
	}
}
