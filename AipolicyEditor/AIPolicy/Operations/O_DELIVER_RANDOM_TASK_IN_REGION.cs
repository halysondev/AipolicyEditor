using AipolicyEditor.AIPolicy.Operations.CustomEditors;
using System;
using System.ComponentModel;
using System.IO;
using WPFLocalizeExtension.Extensions;

namespace AipolicyEditor.AIPolicy.Operations
{
    public class O_DELIVER_RANDOM_TASK_IN_REGION : IOperation, ICloneable
    {
        [Browsable(false)]
        public int FromVersion => 20;
        [Browsable(false)]
        public int OperID => 31;
        [Browsable(false)]
        public string Name => MainWindow.Provider.GetLocalizedString("o31");

        //Trigger param
        [LocalizedCategory("OperationParam")]
        [LocalizedDisplayName("ID")]
        public uint ID { get; set; }

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
        // Target param
        [LocalizedCategory("TargetParam")]
        [LocalizedDisplayName("Target")]
        public TargetParam Target { get; set; }

        public O_DELIVER_RANDOM_TASK_IN_REGION()
        {
            ID = 0;
            MinX = 0;
            MinY = 0;
            MinZ = 0;
            MaxX = 0;
            MaxY = 0;
            MaxZ = 0;
            Target = new TargetParam();
        }

        public void Read(BinaryReader br)
        {
            ID = br.ReadUInt32();
            MinX = br.ReadSingle();
            MinY = br.ReadSingle();
            MinZ = br.ReadSingle();
            MaxX = br.ReadSingle();
            MaxY = br.ReadSingle();
            MaxZ = br.ReadSingle();
            Target = TargetStream.Read(br);
        }

        public void Write(BinaryWriter bw)
        {
            bw.Write(ID);
            bw.Write(MinX);
            bw.Write(MinY);
            bw.Write(MinZ);
            bw.Write(MaxX);
            bw.Write(MaxY);
            bw.Write(MaxZ);
            TargetStream.Save(bw, Target);
        }

        public bool Search(string str)
        {
            if (ID.ToString().Contains(str) || MinX.ToString().Contains(str) || MinY.ToString().Contains(str) || MinZ.ToString().Contains(str) ||
                MaxX.ToString().Contains(str) || MaxY.ToString().Contains(str) || MaxZ.ToString().Contains(str))
                return true;
            else
                return false;
        }

        public object Clone()
        {
            return new O_DELIVER_RANDOM_TASK_IN_REGION() { ID = ID, MinX = MinX, MinY = MinY, MinZ = MinZ, MaxX = MaxX, MaxY = MaxY, MaxZ = MaxZ, Target = Target.Clone() as TargetParam  };
        }
    }
}
