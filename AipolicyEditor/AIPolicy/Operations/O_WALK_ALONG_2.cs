using AipolicyEditor.AIPolicy.Operations.CustomEditors;
using System;
using System.ComponentModel;
using System.IO;
using WPFLocalizeExtension.Extensions;

namespace AipolicyEditor.AIPolicy.Operations
{
    public class O_WALK_ALONG_2 : IOperation, ICloneable
    {
        [Browsable(false)]
        public int FromVersion => 20;
        [Browsable(false)]
        public int OperID => 25;
        [Browsable(false)]
        public string Name => MainWindow.Provider.GetLocalizedString("o25");

        //Trigger param
        [LocalizedCategory("OperationParam")]
        [LocalizedDisplayName("WorldID")]
        public int WorldID { get; set; }
        [LocalizedCategory("OperationParam")]
        [LocalizedDisplayName("PathID")]
        public int PathID { get; set; }
        [LocalizedCategory("OperationParam")]
        [LocalizedDisplayName("PathIDType")]
        public int PathIDType { get; set; }
        [LocalizedCategory("OperationParam")]
        [LocalizedDisplayName("PatrolType")]
        public MonsterPatrolType PatrolType { get; set; }
        [LocalizedCategory("OperationParam")]
        [LocalizedDisplayName("SpeedType")]
        public MonsterPatrolSpeedType SpeedType { get; set; }
        // Target param
        [LocalizedCategory("TargetParam")]
        [LocalizedDisplayName("Target")]
        public TargetParam Target { get; set; }

        public O_WALK_ALONG_2()
        {
            WorldID = 0;
            PathID = 0;
            PathIDType = 0;
            PatrolType = MonsterPatrolType.StopAtEnd;
            SpeedType = MonsterPatrolSpeedType.Begin;
            Target = new TargetParam();
        }

        public void Read(BinaryReader br)
        {
            WorldID = br.ReadInt32();
            PathID = br.ReadInt32();
            PathIDType = br.ReadInt32();
            PatrolType = (MonsterPatrolType)br.ReadInt32();
            SpeedType = (MonsterPatrolSpeedType)br.ReadInt32();
            Target = TargetStream.Read(br);
        }

        public void Write(BinaryWriter bw)
        {
            bw.Write(WorldID);
            bw.Write(PathID);
            bw.Write(PathIDType);
            bw.Write((int)PatrolType);
            bw.Write((int)SpeedType);
            TargetStream.Save(bw, Target);
        }

        public bool Search(string str)
        {
            if (WorldID.ToString().Contains(str) || PathID.ToString().Contains(str) || PathIDType.ToString().Contains(str) ||
                PatrolType.ToString().Contains(str) || SpeedType.ToString().Contains(str))
                return true;
            else
                return false;
        }

        public object Clone()
        {
            return new O_WALK_ALONG_2() { WorldID = WorldID, PathID = PathID, PathIDType = PathIDType, PatrolType = PatrolType, SpeedType = SpeedType, Target = Target.Clone() as TargetParam  };
        }
    }
}
