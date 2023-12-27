using AipolicyEditor.AIPolicy.Operations.CustomEditors;
using System;
using System.ComponentModel;
using System.IO;
using WPFLocalizeExtension.Extensions;

namespace AipolicyEditor.AIPolicy.Operations
{
    public class O_VOTING_RESULT : IOperation, ICloneable
    {
        [Browsable(false)]
        public int FromVersion => 30;
        [Browsable(false)]
        public int OperID => 49;
        [Browsable(false)]
        public string Name => MainWindow.Provider.GetLocalizedString("o49");

        //Trigger param
        [LocalizedCategory("OperationParam")]
        [LocalizedDisplayName("iVoteID")]
        public int iVoteID { get; set; }

        [LocalizedCategory("OperationParam")]
        [LocalizedDisplayName("iVoteIDType")]
        public int iVoteIDType { get; set; }

        [LocalizedCategory("OperationParam")]
        [LocalizedDisplayName("iSelect")]
        public int iSelect { get; set; }

        [LocalizedCategory("OperationParam")]
        [LocalizedDisplayName("iSelectType")]
        public int iSelectType { get; set; }

        [LocalizedCategory("OperationParam")]
        [LocalizedDisplayName("iSaveResult")]
        public int iSaveResult { get; set; }

        [LocalizedCategory("OperationParam")]
        [LocalizedDisplayName("iSaveResultType")]
        public int iSaveResultType { get; set; }

        // Target param
        [LocalizedCategory("TargetParam")]
        [LocalizedDisplayName("Target")]
        public TargetParam Target { get; set; }

        public O_VOTING_RESULT()
        {
            iVoteID = 0;
            iVoteIDType = 0;
            Target = new TargetParam();
        }

        public void Read(BinaryReader br)
        {
            iVoteID = br.ReadInt32();
            iVoteIDType = br.ReadInt32();
            iSelect = br.ReadInt32();
            iSelectType = br.ReadInt32();
            iSaveResult = br.ReadInt32();
            iSaveResultType = br.ReadInt32();
            Target = TargetStream.Read(br);
        }

        public void Write(BinaryWriter bw)
        {
            bw.Write(iVoteID);
            bw.Write(iVoteIDType);
            bw.Write(iSelect);
            bw.Write(iSelectType);
            bw.Write(iSaveResult);
            bw.Write(iSaveResultType);
            TargetStream.Save(bw, Target);
        }

        public bool Search(string str)
        {
            if (iVoteID.ToString().Contains(str) || iVoteIDType.ToString().Contains(str)
                || iSelect.ToString().Contains(str)
                || iSelectType.ToString().Contains(str)
                || iSaveResult.ToString().Contains(str)
                || iSaveResultType.ToString().Contains(str))
                return true;
            else
                return false;
        }

        public object Clone()
        {
            return new O_VOTING_RESULT() { iVoteID = iVoteID, iVoteIDType = iVoteIDType, iSelect = iSelect, iSelectType = iSelectType, iSaveResult = iSaveResult, iSaveResultType = iSaveResultType,   Target = Target.Clone() as TargetParam  };
        }
    }
}
