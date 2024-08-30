using System;
using System.ComponentModel;
using System.IO;
using AipolicyEditor.AIPolicy.Operations.CustomEditors;

namespace AipolicyEditor.AIPolicy.Operations
{

	public class O_79 : IOperation, ICloneable
	{
		[Browsable(false)]
		public int FromVersion => 33;

		[Browsable(false)]
		public int OperID => 79;

		[Browsable(false)]
		public string Name => MainWindow.Provider.GetLocalizedString("o79");

		[LocalizedCategory("OperationParam")]
		[LocalizedDisplayName("Value1")]
		public int iTargetID { get; set; }

		[LocalizedCategory("OperationParam")]
		[LocalizedDisplayName("Value2")]
		public VarType uTargetType { get; set; }

		[LocalizedCategory("TargetParam")]
		[LocalizedDisplayName("Target")]
		public TargetParam Target { get; set; }

		public O_79()
		{
            iTargetID = 0;
            uTargetType = 0;
			Target = new TargetParam();
		}

		public void Read(BinaryReader br)
		{
            iTargetID = br.ReadInt32();
            uTargetType = (VarType)br.ReadInt32();
			Target = TargetStream.Read(br);
		}

		public void Write(BinaryWriter bw)
		{
			bw.Write(iTargetID);
			bw.Write(Convert.ToUInt32(uTargetType));
			TargetStream.Save(bw, Target);
		}

		public bool Search(string str)
		{
			if (iTargetID.ToString().Contains(str) || uTargetType.ToString().Contains(str))
			{
				return true;
			}
			return false;
		}

		public object Clone()
		{
			return new O_79
			{
                iTargetID = iTargetID,
                uTargetType = uTargetType,
				Target = (Target.Clone() as TargetParam)
			};
		}
	}
}
