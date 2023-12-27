using System;
using System.ComponentModel;
using System.IO;
using AipolicyEditor.AIPolicy.Operations.CustomEditors;

namespace AipolicyEditor.AIPolicy.Operations
{

	public class O_75 : IOperation, ICloneable
	{
		[Browsable(false)]
		public int FromVersion => 33;

		[Browsable(false)]
		public int OperID => 75;

		[Browsable(false)]
		public string Name => MainWindow.Provider.GetLocalizedString("o75");

		[LocalizedDisplayName("uID")]
		[LocalizedCategory("OperationParam")]
		public int uID { get; set; }

		[LocalizedCategory("TargetParam")]
		[LocalizedDisplayName("Target")]
		public TargetParam Target { get; set; }

		public O_75()
		{
            uID = 0;
			Target = new TargetParam();
		}

		public void Read(BinaryReader br)
		{
            uID = br.ReadInt32();
			Target = TargetStream.Read(br);
		}

		public void Write(BinaryWriter bw)
		{
			bw.Write(uID);
			TargetStream.Save(bw, Target);
		}

		public bool Search(string str)
		{
			if (uID.ToString().Contains(str))
			{
				return true;
			}
			return false;
		}

		public object Clone()
		{
			return new O_75
			{
                uID = uID,
				Target = (Target.Clone() as TargetParam)
			};
		}
	}
}
