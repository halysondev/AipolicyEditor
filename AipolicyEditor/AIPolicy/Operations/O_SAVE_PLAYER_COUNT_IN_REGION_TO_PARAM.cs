using AipolicyEditor.AIPolicy.Operations.CustomEditors;
using System;
using System.ComponentModel;
using System.IO;
using WPFLocalizeExtension.Extensions;

namespace AipolicyEditor.AIPolicy.Operations
{
    public class O_SAVE_PLAYER_COUNT_IN_REGION_TO_PARAM : IOperation, ICloneable
    {
        [Browsable(false)]
        public int FromVersion => 23;
        [Browsable(false)]
        public int OperID => 35;
        [Browsable(false)]
        public string Name => MainWindow.Provider.GetLocalizedString("o35");

        //Trigger param
        [LocalizedCategory("OperationParam")]
        [LocalizedDisplayName("MinX")]
        public float MinX { get; set; }
        [LocalizedCategory("OperationParam")]
        [LocalizedDisplayName("MinY")]
        public float MinY { get; set; }
        [LocalizedCategory("OperationParam")]
        [LocalizedDisplayName("MinZ")]
        public float MinZ { get; set; }

        [LocalizedCategory("OperationParam")]
        [LocalizedDisplayName("MaxX")]
        public float MaxX { get; set; }
        [LocalizedCategory("OperationParam")]
        [LocalizedDisplayName("MaxY")]
        public float MaxY { get; set; }
        [LocalizedCategory("OperationParam")]
        [LocalizedDisplayName("MaxZ")]
        public float MaxZ { get; set; }

        [LocalizedCategory("OperationParam")]
        [LocalizedDisplayName("TargetID")]
        public int TargetID { get; set; }
        [LocalizedCategory("OperationParam")]
        [LocalizedDisplayName("TargetType")]
        public uint Target_Type { get; set; }
        // Target param
        [LocalizedCategory("TargetParam")]
        [LocalizedDisplayName("Target")]
        public TargetParam Target { get; set; }

        public O_SAVE_PLAYER_COUNT_IN_REGION_TO_PARAM()
        {
            MinX = 0;
            MinY = 0;
            MinZ = 0;
            MaxX = 0;
            MaxY = 0;
            MaxZ = 0;
            TargetID = 0;
            Target_Type = 0;
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
            TargetID = br.ReadInt32();
            Target_Type = br.ReadUInt32();
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
            bw.Write(TargetID);
            bw.Write(Target_Type);
            TargetStream.Save(bw, Target);
        }

        public bool Search(string str)
        {
            if (MinX.ToString().Contains(str) || MinY.ToString().Contains(str) || MinZ.ToString().Contains(str) ||
                MaxX.ToString().Contains(str) || MaxY.ToString().Contains(str) || MaxZ.ToString().Contains(str) ||
                TargetID.ToString().Contains(str) || Target_Type.ToString().Contains(str))
                return true;
            else
                return false;
        }

        public object Clone()
        {
            return new O_SAVE_PLAYER_COUNT_IN_REGION_TO_PARAM() { MinX = MinX, MinY = MinY, MinZ = MinZ, MaxX = MaxX, MaxY = MaxY, MaxZ = MaxZ, TargetID = TargetID, Target_Type = Target_Type, Target = Target.Clone() as TargetParam  };
        }
    }
}
