using AipolicyEditor.AIPolicy.Operations.CustomEditors;
using System;
using System.ComponentModel;
using System.IO;
using System.Windows;
using WPFLocalizeExtension.Extensions;

namespace AipolicyEditor.AIPolicy.Operations
{
    public class O_VOTING_SHOW : IOperation, ICloneable
    {
        [Browsable(false)]
        public int FromVersion => 30;
        [Browsable(false)]
        public int OperID => 50;
        [Browsable(false)]
        public string Name => MainWindow.Provider.GetLocalizedString("o50");

        //Trigger param
        [LocalizedDisplayName("iStyle")]
        [LocalizedCategory("OperationParam")]
        public int iStyle { get; set; }

        [LocalizedDisplayName("iVoteID0")]
        [LocalizedCategory("OperationParam")]
        public int iVoteID0 { get; set; }

        [LocalizedCategory("OperationParam")]
        [LocalizedDisplayName("iSelect0")]
        public int iSelect0 { get; set; }

        [LocalizedCategory("OperationParam")]
        [LocalizedDisplayName("iVoteID1")]
        public int iVoteID1 { get; set; }

        [LocalizedCategory("OperationParam")]
        [LocalizedDisplayName("iSelect1")]
        public int iSelect1 { get; set; }

        [LocalizedCategory("OperationParam")]
        [LocalizedDisplayName("iVoteID2")]
        public int iVoteID2 { get; set; }

        [LocalizedCategory("OperationParam")]
        [LocalizedDisplayName("iSelect2")]
        public int iSelect2 { get; set; }

        [LocalizedDisplayName("iVoteID3")]
        [LocalizedCategory("OperationParam")]
        public int iVoteID3 { get; set; }

        [LocalizedCategory("OperationParam")]
        [LocalizedDisplayName("iSelect3")]
        public int iSelect3{ get; set; }

        [LocalizedCategory("OperationParam")]
        [LocalizedDisplayName("iVoteID4")]
        public int iVoteID4 { get; set; }

        [LocalizedCategory("OperationParam")]
        [LocalizedDisplayName("iSelect4")]
        public int iSelect4 { get; set; }

        [LocalizedDisplayName("iVoteID5")]
        [LocalizedCategory("OperationParam")]
        public int iVoteID5 { get; set; }

        [LocalizedCategory("OperationParam")]
        [LocalizedDisplayName("iSelect5")]
        public int iSelect5 { get; set; }

        [LocalizedDisplayName("iVoteID6")]
        [LocalizedCategory("OperationParam")]
        public int iVoteID6 { get; set; }

        [LocalizedDisplayName("iSelect6")]
        [LocalizedCategory("OperationParam")]
        public int iSelect6 { get; set; }

        [LocalizedCategory("OperationParam")]
        [LocalizedDisplayName("iVoteID7")]
        public int iVoteID7 { get; set; }

        [LocalizedDisplayName("iSelect7")]
        [LocalizedCategory("OperationParam")]
        public int iSelect7 { get; set; }

        [LocalizedDisplayName("Target")]
        [LocalizedCategory("TargetParam")]
        public TargetParam Target { get; set; }

        public O_VOTING_SHOW()
        {
            iStyle = 0;
            iVoteID0 = 0;
            iSelect0 = 0;
            iVoteID1 = 0;
            iSelect1 = 0; 
            iVoteID2 = 0;
            iSelect2 = 0; 
            iVoteID3 = 0;
            iSelect3 = 0; 
            iVoteID4 = 0;
            iSelect4 = 0; 
            iVoteID5 = 0;
            iSelect5 = 0; 
            iVoteID6 = 0;
            iSelect6 = 0; 
            iVoteID7 = 0;
            iSelect7 = 0; 
            Target = new TargetParam();
        }

        public void Read(BinaryReader br)
        {
            iStyle = br.ReadInt32();
            iVoteID0 = br.ReadInt32();
            iSelect0 = br.ReadInt32();
            iVoteID1 = br.ReadInt32();
            iSelect1 = br.ReadInt32();
            iVoteID2 = br.ReadInt32();
            iSelect2 = br.ReadInt32();
            iVoteID3 = br.ReadInt32();
            iSelect3 = br.ReadInt32();
            iVoteID4 = br.ReadInt32();
            iSelect4 = br.ReadInt32();
            iVoteID5 = br.ReadInt32();
            iSelect5 = br.ReadInt32();
            iVoteID6 = br.ReadInt32();
            iSelect6 = br.ReadInt32();
            iVoteID7 = br.ReadInt32();
            iSelect7 = br.ReadInt32();
            Target = TargetStream.Read(br);
        }

        public void Write(BinaryWriter bw)
        {
            bw.Write(iStyle);
            bw.Write(iVoteID0);
            bw.Write(iSelect0);
            bw.Write(iVoteID1);
            bw.Write(iSelect1);
            bw.Write(iVoteID2);
            bw.Write(iSelect2);
            bw.Write(iVoteID3);
            bw.Write(iSelect3);
            bw.Write(iVoteID4);
            bw.Write(iSelect4);
            bw.Write(iVoteID5);
            bw.Write(iSelect5);
            bw.Write(iVoteID6);
            bw.Write(iSelect6);
            bw.Write(iVoteID7);
            bw.Write(iSelect7);
            TargetStream.Save(bw, Target);
        }

        public bool Search(string str)
        {
            if (iStyle.ToString().Contains(str) || iVoteID0.ToString().Contains(str) || iSelect0.ToString().Contains(str) || iVoteID1.ToString().Contains(str) || iSelect1.ToString().Contains(str) || iVoteID2.ToString().Contains(str) || iSelect2.ToString().Contains(str) || iVoteID3.ToString().Contains(str) || iSelect3.ToString().Contains(str) || iVoteID4.ToString().Contains(str) || iSelect4.ToString().Contains(str) || iVoteID5.ToString().Contains(str) || iSelect5.ToString().Contains(str) || iVoteID6.ToString().Contains(str) || iSelect6.ToString().Contains(str) || iVoteID7.ToString().Contains(str) || iSelect7.ToString().Contains(str))
            {
                return true;
            }
            return false;
        }

        public object Clone()
        {
            return new O_VOTING_SHOW() {
                iStyle = iStyle,
                iVoteID0 = iVoteID0,
                iSelect0 = iSelect0,
                iVoteID1 = iVoteID1,
                iSelect1 = iSelect1,
                iVoteID2 = iVoteID2,
                iSelect2 = iSelect2,
                iVoteID3 = iVoteID3,
                iSelect3 = iSelect3,
                iVoteID4 = iVoteID4,
                iSelect4 = iSelect4,
                iVoteID5 = iVoteID5,
                iSelect5 = iSelect5,
                iVoteID6 = iVoteID6,
                iSelect6 = iSelect6,
                iVoteID7 = iVoteID7,
                iSelect7 = iSelect7,
                Target = Target.Clone() as TargetParam  };
        }
    }
}
