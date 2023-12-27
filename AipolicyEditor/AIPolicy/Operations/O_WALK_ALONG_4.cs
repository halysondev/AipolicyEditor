using AipolicyEditor.AIPolicy.Operations.CustomEditors;
using System;
using System.ComponentModel;
using System.IO;
using WPFLocalizeExtension.Extensions;

namespace AipolicyEditor.AIPolicy.Operations
{
    public class O_WALK_ALONG_4 : IOperation, ICloneable
    {
        [Browsable(false)]
        public int FromVersion => 28;
        [Browsable(false)]
        public int OperID => 45;
        [Browsable(false)]
        public string Name => MainWindow.Provider.GetLocalizedString("o45");

        //Trigger param
        [LocalizedCategory("OperationParam")]
        [LocalizedDisplayName("iWorldID")]
        public int iWorldID { get; set; }
        [LocalizedCategory("OperationParam")]
        [LocalizedDisplayName("iStartPathID")]
        public int iStartPathID { get; set; }
        [LocalizedCategory("OperationParam")]
        [LocalizedDisplayName("iStartPathIDType")]
        public int iStartPathIDType { get; set; }
        [LocalizedCategory("OperationParam")]
        [LocalizedDisplayName("iEndPathID")]
        public int iEndPathID { get; set; }
        [LocalizedCategory("OperationParam")]
        [LocalizedDisplayName("iEndPathIDType")]
        public int iEndPathIDType { get; set; }
        [LocalizedCategory("OperationParam")]
        [LocalizedDisplayName("iMinPathID")]
        public int iMinPathID { get; set; }
        [LocalizedCategory("OperationParam")]
        [LocalizedDisplayName("iMinPathIDType")]
        public int iMinPathIDType { get; set; }
        [LocalizedCategory("OperationParam")]
        [LocalizedDisplayName("iMaxPathID")]
        public int iMaxPathID { get; set; }
        [LocalizedCategory("OperationParam")]
        [LocalizedDisplayName("iMaxPathIDType")]
        public int iMaxPathIDType { get; set; }
        [LocalizedCategory("OperationParam")]
        [LocalizedDisplayName("iPatrolType")]
        public int iPatrolType { get; set; }
        [LocalizedCategory("OperationParam")]
        [LocalizedDisplayName("iSpeedType")]
        public int iSpeedType { get; set; }
        [LocalizedCategory("OperationParam")]
        [LocalizedDisplayName("iOrientationType")]
        public int iOrientationType { get; set; }

        // Target param
        [LocalizedCategory("TargetParam")]
        [LocalizedDisplayName("Target")]
        public TargetParam Target { get; set; }

        public O_WALK_ALONG_4()
        {
            iWorldID = 0;
            iStartPathID = 0;
            iStartPathIDType = 0;
            iEndPathID = 0;
            iEndPathIDType = 0;
            iMinPathID = 0;
            iMinPathIDType = 0;
            iMaxPathID = 0;
            iMaxPathIDType = 0;
            iPatrolType = 0;
            iSpeedType = 0;
            iOrientationType = 0;
            Target = new TargetParam();
        }

        public void Read(BinaryReader br)
        {
            iWorldID = br.ReadInt32();
            iStartPathID = br.ReadInt32();
            iStartPathIDType = br.ReadInt32();
            iEndPathID = br.ReadInt32();
            iEndPathIDType = br.ReadInt32();
            iMinPathID = br.ReadInt32();
            iMinPathIDType = br.ReadInt32();
            iMaxPathID = br.ReadInt32();
            iMaxPathIDType = br.ReadInt32();
            iPatrolType = br.ReadInt32();
            iSpeedType = br.ReadInt32();
            iOrientationType = br.ReadInt32();
            Target = TargetStream.Read(br);
        }

        public void Write(BinaryWriter bw)
        {
            bw.Write(iWorldID);
            bw.Write(iStartPathID);
            bw.Write(iStartPathIDType);
            bw.Write(iEndPathID);
            bw.Write(iEndPathIDType);
            bw.Write(iMinPathID);
            bw.Write(iMinPathIDType);
            bw.Write(iMaxPathID);
            bw.Write(iMaxPathIDType);
            bw.Write(iPatrolType);
            bw.Write(iSpeedType);
            bw.Write(iOrientationType);
            TargetStream.Save(bw, Target);
        }

        public bool Search(string str)
        {
            if (iWorldID.ToString().Contains(str) || iStartPathID.ToString().Contains(str) || iStartPathIDType.ToString().Contains(str) ||
                iEndPathID.ToString().Contains(str) || iEndPathIDType.ToString().Contains(str) ||
                iMinPathID.ToString().Contains(str) ||
                iMinPathIDType.ToString().Contains(str) ||
                iMaxPathID.ToString().Contains(str) ||
                iMaxPathIDType.ToString().Contains(str) ||
                iPatrolType.ToString().Contains(str) || iSpeedType.ToString().Contains(str) || iOrientationType.ToString().Contains(str))
                return true;
            else
                return false;
        }

        public object Clone()
        {
            return new O_WALK_ALONG_4() { iWorldID = iWorldID, 
                iStartPathID = iStartPathID, 
                iStartPathIDType = iStartPathIDType, 
                iEndPathID = iEndPathID, iEndPathIDType = iEndPathIDType, 
                iMinPathID = iMinPathID, iMinPathIDType= iMinPathIDType,
                iMaxPathID = iMaxPathID, iMaxPathIDType = iMaxPathIDType,
                iOrientationType = iOrientationType,
                iPatrolType = iPatrolType, iSpeedType = iSpeedType, Target = Target.Clone() as TargetParam  };
        }
    }
}
