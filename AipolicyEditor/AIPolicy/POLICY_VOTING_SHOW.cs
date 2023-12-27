using AipolicyEditor.AIPolicy.Operations.CustomEditors;
using System.IO;

namespace AipolicyEditor.AIPolicy
{
    public class POLICY_VOTING_SHOW
    {
        public int iVoteID { get; set; }
        public int iSelect { get; set; }

        public POLICY_VOTING_SHOW() { }
        public POLICY_VOTING_SHOW(BinaryReader br)
        {
            iVoteID = br.ReadInt32();
            iSelect = br.ReadInt32();
        }

        public void Write(BinaryWriter bw)
        {
            bw.Write(iVoteID);
            bw.Write(iSelect);
        }
    }
}
