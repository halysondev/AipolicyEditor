using System;
using System.ComponentModel;
using System.IO;
using AipolicyEditor.AIPolicy.Operations.CustomEditors;

namespace AipolicyEditor.AIPolicy.Operations
{

	public class O_84 : IOperation, ICloneable
	{
		[Browsable(false)]
		public int FromVersion => 35;

		[Browsable(false)]
		public int OperID => 84;

		[Browsable(false)]
		public string Name => MainWindow.Provider.GetLocalizedString("o84");

		[LocalizedCategory("TargetParam")]
		[LocalizedDisplayName("Target")]
		public TargetParam Target { get; set; }

		public O_84()
		{
			Target = new TargetParam();
		}

		public void Read(BinaryReader br)
		{
			Target = TargetStream.Read(br);
		}

		public void Write(BinaryWriter bw)
		{
			TargetStream.Save(bw, Target);
		}

		public bool Search(string str)
		{
			return false;
		}

		public object Clone()
		{
			return new O_84
			{
				Target = (Target.Clone() as TargetParam)
			};
		}
	}
}
