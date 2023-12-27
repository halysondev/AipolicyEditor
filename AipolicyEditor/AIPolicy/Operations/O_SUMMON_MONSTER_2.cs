using AipolicyEditor.AIPolicy.Operations.CustomEditors;
using System;
using System.ComponentModel;
using System.IO;
using WPFLocalizeExtension.Extensions;

namespace AipolicyEditor.AIPolicy.Operations
{
    public class O_SUMMON_MONSTER_2 : IOperation, ICloneable
    {
        [Browsable(false)]
        public int FromVersion => 20;
        [Browsable(false)]
        public int OperID => 24;
        [Browsable(false)]
        public string Name => MainWindow.Provider.GetLocalizedString("o24");

        //Trigger param
        [LocalizedCategory("OperationParam")]
        [LocalizedDisplayName("DispearCondition")]
        public SummoneeDisppearType DispearCondition { get; set; }
        [LocalizedCategory("OperationParam")]
        [LocalizedDisplayName("MonsterID")]
        public MobID MonsterID { get; set; }
        [LocalizedCategory("OperationParam")]
        [LocalizedDisplayName("MonsterIDType")]
        public int MonsterIDType { get; set; }
        [LocalizedCategory("OperationParam")]
        [LocalizedDisplayName("Range")]
        public int Range { get; set; }
        [LocalizedCategory("OperationParam")]
        [LocalizedDisplayName("Life")]
        public int Life { get; set; }
        [LocalizedCategory("OperationParam")]
        [LocalizedDisplayName("PathID")]
        public int PathID { get; set; }
        [LocalizedCategory("OperationParam")]
        [LocalizedDisplayName("PathIDType")]
        public int PathIDType { get; set; }
        [LocalizedCategory("OperationParam")]
        [LocalizedDisplayName("MonsterNum")]
        public int MonsterNum { get; set; }
        [LocalizedCategory("OperationParam")]
        [LocalizedDisplayName("MonsterNumType")]
        public int MonsterNumType { get; set; }
        // Target param
        [LocalizedCategory("TargetParam")]
        [LocalizedDisplayName("Target")]
        public TargetParam Target { get; set; }

        public O_SUMMON_MONSTER_2()
        {
            DispearCondition = SummoneeDisppearType.Never;
            MonsterID = new MobID();
            MonsterIDType = 0;
            Range = 0;
            Life = 0;
            PathID = 0;
            PathIDType = 0;
            MonsterNum = 0;
            MonsterNumType = 0;
            Target = new TargetParam();
        }

        public void Read(BinaryReader br)
        {
            DispearCondition = (SummoneeDisppearType)br.ReadInt32();
            MonsterID = new MobID() { Value = br.ReadUInt32() };
            MonsterIDType = br.ReadInt32();
            Range = br.ReadInt32();
            Life = br.ReadInt32();
            PathID = br.ReadInt32();
            PathIDType = br.ReadInt32();
            MonsterNum = br.ReadInt32();
            MonsterNumType = br.ReadInt32();
            Target = TargetStream.Read(br);
        }

        public void Write(BinaryWriter bw)
        {
            bw.Write((int)DispearCondition);
            bw.Write(MonsterID.Value);
            bw.Write(MonsterIDType);
            bw.Write(Range);
            bw.Write(Life);
            bw.Write(PathID);
            bw.Write(PathIDType);
            bw.Write(MonsterNum);
            bw.Write(MonsterNumType);
            TargetStream.Save(bw, Target);
        }

        public bool Search(string str)
        {
            if (DispearCondition.ToString().Contains(str) || MonsterID.Value.ToString().Contains(str) || MonsterIDType.ToString().Contains(str) ||
                Range.ToString().Contains(str) || Life.ToString().Contains(str) || PathID.ToString().Contains(str) ||
                PathIDType.ToString().Contains(str) || MonsterNum.ToString().Contains(str) || MonsterNumType.ToString().Contains(str))
                return true;
            else
                return false;
        }

        public object Clone()
        {
            return new O_SUMMON_MONSTER_2() { DispearCondition = DispearCondition, MonsterID = MonsterID, MonsterIDType = MonsterIDType, Range = Range, Life = Life, PathID = PathID, PathIDType = PathIDType, MonsterNum = MonsterNum, MonsterNumType = MonsterNumType, Target = Target.Clone() as TargetParam  };
        }
    }
}
