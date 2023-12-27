using AipolicyEditor.AIPolicy.Operations.CustomEditors;
using System;
using System.ComponentModel;
using System.IO;
using WPFLocalizeExtension.Extensions;

namespace AipolicyEditor.AIPolicy.Operations
{
    public class O_SUMMON_MINE : IOperation, ICloneable
    {
        [Browsable(false)]
        public int FromVersion => 24;
        [Browsable(false)]
        public int OperID => 29;
        [Browsable(false)]
        public string Name => MainWindow.Provider.GetLocalizedString("o29");

        //Trigger param
        [LocalizedCategory("OperationParam")]
        [LocalizedDisplayName("LifeType")]
        public int LifeType { get; set; }
        [LocalizedCategory("OperationParam")]
        [LocalizedDisplayName("MineID")]
        public MineID MineID { get; set; }
        [LocalizedCategory("OperationParam")]
        [LocalizedDisplayName("MineIDType")]
        public int MineIDType { get; set; }
        [LocalizedCategory("OperationParam")]
        [LocalizedDisplayName("Range")]
        public int Range { get; set; }
        [LocalizedCategory("OperationParam")]
        [LocalizedDisplayName("Life")]
        public int Life { get; set; }
        [LocalizedCategory("OperationParam")]
        [LocalizedDisplayName("MineNum")]
        public int MineNum { get; set; }
        [LocalizedCategory("OperationParam")]
        [LocalizedDisplayName("MineNumType")]
        public int MineNumType { get; set; }
        [LocalizedCategory("OperationParam")]
        [LocalizedDisplayName("Unknown")]
        //public bool bSetOwnerAsMonsterOwner { get; set; }
        public byte[] Unknown { get; set; } // wtf
        // Target param
        [LocalizedCategory("TargetParam")]
        [LocalizedDisplayName("Target")]
        public TargetParam Target { get; set; }

        public O_SUMMON_MINE()
        {
            LifeType = 0;
            MineID = new MineID();
            MineIDType = 0;
            Range = 0;
            Life = 0;
            MineNum = 0;
            MineNumType = 0;
            //bSetOwnerAsMonsterOwner = false;
            Unknown = new byte[4];
            Target = new TargetParam();
        }

        public void Read(BinaryReader br)
        {
            LifeType = br.ReadInt32();
            MineID = new MineID() { Value = br.ReadUInt32() };
            MineIDType = br.ReadInt32();
            Range = br.ReadInt32();
            Life = br.ReadInt32();
            MineNum = br.ReadInt32();
            MineNumType = br.ReadInt32();
             //bw.Write(bSetOwnerAsMonsterOwner);
            Unknown = br.ReadBytes(4);
            Target = TargetStream.Read(br);
        }

        public void Write(BinaryWriter bw)
        {
            bw.Write(LifeType);
            bw.Write(MineID.Value);
            bw.Write(MineIDType);
            bw.Write(Range);
            bw.Write(Life);
            bw.Write(MineNum);
            bw.Write(MineNumType);
            //bw.Write(bSetOwnerAsMonsterOwner);
            bw.Write(Unknown);
            TargetStream.Save(bw, Target);
        }

        public bool Search(string str)
        {
            if (LifeType.ToString().Contains(str) || MineID.Value.ToString().Contains(str) || MineIDType.ToString().Contains(str) ||
                Range.ToString().Contains(str) || Life.ToString().Contains(str) || MineNum.ToString().Contains(str) ||
                MineNumType.ToString().Contains(str))
                return true;
            else
                return false;
        }

        public object Clone()
        {
            return new O_SUMMON_MINE() { LifeType = LifeType, MineID = MineID, MineIDType = MineIDType, Range = Range, Life = Life, MineNum = MineNum, MineNumType = MineNumType, Unknown = Unknown, Target = Target.Clone() as TargetParam  };
        }
    }
}
