using AipolicyEditor.AIPolicy.Operations.CustomEditors;
using System;
using System.ComponentModel;
using System.IO;
using WPFLocalizeExtension.Extensions;

namespace AipolicyEditor.AIPolicy.Operations
{
    public class O_WALK_ALONG_3 : IOperation, ICloneable
    {
        [Browsable(false)]
        public int FromVersion => 28;
        [Browsable(false)]
        public int OperID => 44;
        [Browsable(false)]
        public string Name => MainWindow.Provider.GetLocalizedString("o44");

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
        [LocalizedDisplayName("iPatrolType")]
        public int iPatrolType { get; set; }
        [LocalizedCategory("OperationParam")]
        [LocalizedDisplayName("iPatrolType")]
        public int iSpeedType { get; set; }

        // Target param
        [LocalizedCategory("TargetParam")]
        [LocalizedDisplayName("Target")]
        public TargetParam Target { get; set; }

        public O_WALK_ALONG_3()
        {
            iWorldID = 0;
            iStartPathID = 0;
            iStartPathIDType = 0;
            iEndPathID = 0;
            iEndPathIDType = 0;
            iPatrolType = 0;
            iSpeedType = 0;
            Target = new TargetParam();
        }

        public void Read(BinaryReader br)
        {
            iWorldID = br.ReadInt32();
            iStartPathID = br.ReadInt32();
            iStartPathIDType = br.ReadInt32();
            iEndPathID = br.ReadInt32();
            iEndPathIDType = br.ReadInt32();
            iPatrolType = br.ReadInt32();
            iSpeedType = br.ReadInt32();
            Target = TargetStream.Read(br);
        }

        public void Write(BinaryWriter bw)
        {
            bw.Write(iWorldID);
            bw.Write(iStartPathID);
            bw.Write(iStartPathIDType);
            bw.Write(iEndPathID);
            bw.Write(iEndPathIDType);
            bw.Write(iPatrolType);
            bw.Write(iSpeedType);
            TargetStream.Save(bw, Target);
        }

        public bool Search(string str)
        {
            if (iWorldID.ToString().Contains(str) || iStartPathID.ToString().Contains(str) || iStartPathIDType.ToString().Contains(str) ||
                iEndPathID.ToString().Contains(str) || iEndPathIDType.ToString().Contains(str) || iPatrolType.ToString().Contains(str) || iSpeedType.ToString().Contains(str))
                return true;
            else
                return false;
        }

        public object Clone()
        {
            return new O_WALK_ALONG_3() { iWorldID = iWorldID, iStartPathID = iStartPathID, iStartPathIDType = iStartPathIDType, iEndPathID = iEndPathID, iEndPathIDType = iEndPathIDType, iPatrolType = iPatrolType, iSpeedType = iSpeedType, Target = Target.Clone() as TargetParam  };
        }
    }
}
