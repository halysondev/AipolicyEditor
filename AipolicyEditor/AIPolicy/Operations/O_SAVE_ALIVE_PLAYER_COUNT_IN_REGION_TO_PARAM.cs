using AipolicyEditor.AIPolicy.Operations.CustomEditors;
using System;
using System.ComponentModel;
using System.IO;
using WPFLocalizeExtension.Extensions;

namespace AipolicyEditor.AIPolicy.Operations
{
    public class O_SAVE_ALIVE_PLAYER_COUNT_IN_REGION_TO_PARAM : IOperation, ICloneable
    {
        [Browsable(false)]
        public int FromVersion => 28;
        [Browsable(false)]
        public int OperID => 43;
        [Browsable(false)]
        public string Name => MainWindow.Provider.GetLocalizedString("o43");

        //Trigger param
        [LocalizedCategory("OperationParam")]
        [LocalizedDisplayName("MinX")]
        public float MinX { get; set; }

        [LocalizedDisplayName("MinY")]
        [LocalizedCategory("OperationParam")]
        public float MinY { get; set; }

        [LocalizedCategory("OperationParam")]
        [LocalizedDisplayName("MinZ")]
        public float MinZ { get; set; }

        [LocalizedCategory("OperationParam")]
        [LocalizedDisplayName("MaxX")]
        public float MaxX { get; set; }

        [LocalizedDisplayName("MaxY")]
        [LocalizedCategory("OperationParam")]
        public float MaxY { get; set; }

        [LocalizedCategory("OperationParam")]
        [LocalizedDisplayName("MaxZ")]
        public float MaxZ { get; set; }
        public int iTargetID { get; set; }
        [LocalizedCategory("OperationParam")]
        [LocalizedDisplayName("uTargetType")]
        public uint uTargetType { get; set; }
        // Target param
        [LocalizedCategory("TargetParam")]
        [LocalizedDisplayName("Target")]
        public TargetParam Target { get; set; }

        public O_SAVE_ALIVE_PLAYER_COUNT_IN_REGION_TO_PARAM()
        {
            MinX = 0f;
            MinY = 0f;
            MinZ = 0f;
            MaxX = 0f;
            MaxY = 0f;
            MaxZ = 0f;
            Target = new TargetParam();
        }

        public void Read(BinaryReader br)
        {
            MinX = br.ReadSingle();
            MinY = br.ReadSingle();
            MinZ = br.ReadSingle();
            MaxX = br.ReadSingle();
            MaxY = br.ReadSingle();
            MaxZ = br.ReadSingle();
            iTargetID = br.ReadInt32();
            uTargetType = br.ReadUInt32();
            Target = TargetStream.Read(br);
        }

        public void Write(BinaryWriter bw)
        {
            bw.Write(MinX);
            bw.Write(MinY);
            bw.Write(MinZ);
            bw.Write(MaxX);
            bw.Write(MaxY);
            bw.Write(MaxZ);
            bw.Write(iTargetID);
            bw.Write(uTargetType);
            TargetStream.Save(bw, Target);
        }

        public bool Search(string str)
        {
            if (iTargetID.ToString().Contains(str) || uTargetType.ToString().Contains(str) || MinX.ToString().Contains(str) || MinY.ToString().Contains(str) || MinZ.ToString().Contains(str) || MaxX.ToString().Contains(str) || MaxY.ToString().Contains(str) || MaxZ.ToString().Contains(str))
                return true;
            else
                return false;
        }

        public object Clone()
        {
            return new O_SAVE_ALIVE_PLAYER_COUNT_IN_REGION_TO_PARAM() {
                MinX = MinX,
                MinY = MinY,
                MinZ = MinZ,
                MaxX = MaxX,
                MaxY = MaxY,
                MaxZ = MaxZ,
                iTargetID = iTargetID, uTargetType = uTargetType, Target = Target.Clone() as TargetParam  };
        }
    }
}
