using System;
using System.ComponentModel;
using System.IO;
using AipolicyEditor.AIPolicy.Operations.CustomEditors;

namespace AipolicyEditor.AIPolicy.Operations
{

	public class O_70 : IOperation, ICloneable
	{
		[Browsable(false)]
		public int FromVersion => 33;

		[Browsable(false)]
		public int OperID => 70;

		[Browsable(false)]
		public string Name => MainWindow.Provider.GetLocalizedString("o70");

		[LocalizedDisplayName("Value1")]
		[LocalizedCategory("OperationParam")]
		public float fRadius { get; set; }

		[LocalizedDisplayName("Target")]
		[LocalizedCategory("TargetParam")]
		public TargetParam Target { get; set; }

		public O_70()
		{
            fRadius = 0;
			Target = new TargetParam();
		}

		public void Read(BinaryReader br)
		{
            fRadius = br.ReadSingle();
			Target = TargetStream.Read(br);
		}

		public void Write(BinaryWriter bw)
		{
			bw.Write(fRadius);
			TargetStream.Save(bw, Target);
		}

		public bool Search(string str)
		{
			if (fRadius.ToString().Contains(str))
			{
				return true;
			}
			return false;
		}

		public object Clone()
		{
			return new O_70
			{
                fRadius = fRadius,
				Target = (Target.Clone() as TargetParam)
			};
		}
	}
}
