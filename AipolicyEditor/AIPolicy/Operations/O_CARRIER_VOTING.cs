using AipolicyEditor.AIPolicy.Operations.CustomEditors;
using System;
using System.ComponentModel;
using System.IO;
using WPFLocalizeExtension.Extensions;

namespace AipolicyEditor.AIPolicy.Operations
{
    public class O_CARRIER_VOTING : IOperation, ICloneable
    {
        [Browsable(false)]
        public int FromVersion => 30;
        [Browsable(false)]
        public int OperID => 48;
        [Browsable(false)]
        public string Name => MainWindow.Provider.GetLocalizedString("o48");

        //Trigger param
        [LocalizedCategory("OperationParam")]
        [LocalizedDisplayName("iVoteID")]
        public int iVoteID { get; set; }

        [LocalizedCategory("OperationParam")]
        [LocalizedDisplayName("iVoteIDType")]
        public int iVoteIDType { get; set; }

        // Target param
        [LocalizedCategory("TargetParam")]
        [LocalizedDisplayName("Target")]
        public TargetParam Target { get; set; }

        public O_CARRIER_VOTING()
        {
            iVoteID = 0;
            iVoteIDType = 0;
            Target = new TargetParam();
        }

        public void Read(BinaryReader br)
        {
            iVoteID = br.ReadInt32();
            iVoteIDType = br.ReadInt32();
            Target = TargetStream.Read(br);
        }

        public void Write(BinaryWriter bw)
        {
            bw.Write(iVoteID);
            bw.Write(iVoteIDType);
            TargetStream.Save(bw, Target);
        }

        public bool Search(string str)
        {
            if (iVoteID.ToString().Contains(str) || iVoteIDType.ToString().Contains(str))
                return true;
            else
                return false;
        }

        public object Clone()
        {
            return new O_CARRIER_VOTING() { iVoteID = iVoteID, iVoteIDType = iVoteIDType, Target = Target.Clone() as TargetParam  };
        }
    }
}
