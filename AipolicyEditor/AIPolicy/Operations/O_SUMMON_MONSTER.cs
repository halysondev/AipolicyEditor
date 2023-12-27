using AipolicyEditor.AIPolicy.Operations.CustomEditors;
using System;
using System.ComponentModel;
using System.IO;
using WPFLocalizeExtension.Extensions;

namespace AipolicyEditor.AIPolicy.Operations
{
    public class O_SUMMON_MONSTER : IOperation, ICloneable
    {
        [Browsable(false)]
        public int FromVersion => 7;
        [Browsable(false)]
        public int OperID => 17;
        [Browsable(false)]
        public string Name => MainWindow.Provider.GetLocalizedString("o17");

        //Trigger param
        [LocalizedCategory("OperationParam")]
        [LocalizedDisplayName("MonsterID")]
        public MobID MonsterID { get; set; }
        [LocalizedCategory("OperationParam")]
        [LocalizedDisplayName("Range")]
        public int Range { get; set; }
        [LocalizedCategory("OperationParam")]
        [LocalizedDisplayName("Life")]
        public int Life { get; set; }
        [LocalizedCategory("OperationParam")]
        [LocalizedDisplayName("DispearCondition")]
        public SummoneeDisppearType DispearCondition { get; set; }
        [LocalizedCategory("OperationParam")]
        [LocalizedDisplayName("PathID")]
        public int PathID { get; set; }
        [LocalizedCategory("OperationParam")]
        [LocalizedDisplayName("MonsterNum")]
        public int MonsterNum { get; set; }
        // Target param
        [LocalizedCategory("TargetParam")]
        [LocalizedDisplayName("Target")]
        public TargetParam Target { get; set; }

        public O_SUMMON_MONSTER()
        {
            MonsterID = new MobID();
            Range = 0;
            Life = 0;
            DispearCondition = SummoneeDisppearType.Never;
            PathID = 0;
            MonsterNum = 0;
            Target = new TargetParam();
        }

        public void Read(BinaryReader br)
        {
            MonsterID = new MobID() { Value = br.ReadUInt32() };
            Range = br.ReadInt32();
            Life = br.ReadInt32();
            DispearCondition = (SummoneeDisppearType)br.ReadInt32();
            PathID = br.ReadInt32();
            MonsterNum = br.ReadInt32();
            Target = TargetStream.Read(br);
        }

        public void Write(BinaryWriter bw)
        {
            bw.Write(MonsterID.Value);
            bw.Write(Range);
            bw.Write(Life);
            bw.Write((int)DispearCondition);
            bw.Write(PathID);
            bw.Write(MonsterNum);
            TargetStream.Save(bw, Target);
        }

        public bool Search(string str)
        {
            if (MonsterID.Value.ToString().Contains(str) || Range.ToString().Contains(str) || Life.ToString().Contains(str) ||
                DispearCondition.ToString().Contains(str) || PathID.ToString().Contains(str) || MonsterNum.ToString().Contains(str))
                return true;
            else
                return false;
        }

        public object Clone()
        {
            return new O_SUMMON_MONSTER() { MonsterID = MonsterID, Range = Range, Life = Life, DispearCondition = DispearCondition, PathID = PathID, MonsterNum = MonsterNum, Target = Target.Clone() as TargetParam  };
        }
    }
}
