using System;
using System.ComponentModel;
using System.IO;
using AipolicyEditor.AIPolicy.Operations.CustomEditors;

namespace AipolicyEditor.AIPolicy.Operations
{

	public class O_97 : IOperation, ICloneable
	{
		[Browsable(false)]
		public int FromVersion => 39;

		[Browsable(false)]
		public int OperID => 97;

		[Browsable(false)]
		public string Name => MainWindow.Provider.GetLocalizedString("o97");

		[LocalizedDisplayName("Target")]
		[LocalizedCategory("TargetParam")]
		public TargetParam Target { get; set; }

		public O_97()
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
			return new O_97
			{
				Target = (Target.Clone() as TargetParam)
			};
		}
	}
}
