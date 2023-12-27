using AipolicyEditor.AIPolicy.Operations.CustomEditors;
using System;
using System.ComponentModel;
using System.IO;
using WPFLocalizeExtension.Extensions;

namespace AipolicyEditor.AIPolicy.Operations
{
    public class O_SUMMON_NPC : IOperation, ICloneable
    {
        [Browsable(false)]
        public int FromVersion => 20;
        [Browsable(false)]
        public int OperID => 30;
        [Browsable(false)]
        public string Name => MainWindow.Provider.GetLocalizedString("o30");

        //Trigger param
        [LocalizedCategory("OperationParam")]
        [LocalizedDisplayName("LifeType")]
        public int LifeType { get; set; }
        [LocalizedCategory("OperationParam")]
        [LocalizedDisplayName("NPCID")]
        public NpcID NPCID { get; set; }
        [LocalizedCategory("OperationParam")]
        [LocalizedDisplayName("NPCIDType")]
        public int NPCIDType { get; set; }
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
        [LocalizedDisplayName("NPCNum")]
        public int NPCNum { get; set; }
        [LocalizedCategory("OperationParam")]
        [LocalizedDisplayName("NPCNumType")]
        public int NPCNumType { get; set; }
        // Target param
        [LocalizedCategory("TargetParam")]
        [LocalizedDisplayName("Target")]
        public TargetParam Target { get; set; }

        public O_SUMMON_NPC()
        {
            LifeType = 0;
            NPCID = new NpcID();
            NPCIDType = 0;
            Range = 0;
            Life = 0;
            PathID = 0;
            PathIDType = 0;
            NPCNum = 0;
            NPCNumType = 0;
            Target = new TargetParam();
        }

        public void Read(BinaryReader br)
        {
            LifeType = br.ReadInt32();
            NPCID = new NpcID() { Value = br.ReadUInt32() };
            NPCIDType = br.ReadInt32();
            Range = br.ReadInt32();
            Life = br.ReadInt32();
            PathID = br.ReadInt32();
            PathIDType = br.ReadInt32();
            NPCNum = br.ReadInt32();
            NPCNumType = br.ReadInt32();
            Target = TargetStream.Read(br);
        }

        public void Write(BinaryWriter bw)
        {
            bw.Write(LifeType);
            bw.Write(NPCID.Value);
            bw.Write(NPCIDType);
            bw.Write(Range);
            bw.Write(Life);
            bw.Write(PathID);
            bw.Write(PathIDType);
            bw.Write(NPCNum);
            bw.Write(NPCNumType);
            TargetStream.Save(bw, Target);
        }

        public bool Search(string str)
        {
            if (LifeType.ToString().Contains(str) || NPCID.Value.ToString().Contains(str) || NPCIDType.ToString().Contains(str) ||
                Range.ToString().Contains(str) || Life.ToString().Contains(str) || PathID.ToString().Contains(str) ||
                PathIDType.ToString().Contains(str) || NPCNum.ToString().Contains(str) || NPCNumType.ToString().Contains(str))
                return true;
            else
                return false;
        }

        public object Clone()
        {
            return new O_SUMMON_NPC() { LifeType = LifeType, NPCID = NPCID, NPCIDType = NPCIDType, Range = Range, Life = Life, PathID = PathID, PathIDType = PathIDType, NPCNum = NPCNum, NPCNumType = NPCNumType, Target = Target.Clone() as TargetParam  };
        }
    }
}
