using AipolicyEditor.AIPolicy.Operations.CustomEditors;
using System;
using System.ComponentModel;
using System.IO;
using WPFLocalizeExtension.Extensions;

namespace AipolicyEditor.AIPolicy.Operations
{
    public class O_DELIVER_TASK_IN_HATE_LIST : IOperation, ICloneable
    {
        [Browsable(false)]
        public int FromVersion => 20;
        [Browsable(false)]
        public int OperID => 32;
        [Browsable(false)]
        public string Name => MainWindow.Provider.GetLocalizedString("o32");

        //Trigger param
        [LocalizedCategory("OperationParam")]
        [LocalizedDisplayName("ID")]
        public uint ID { get; set; }
        [LocalizedCategory("OperationParam")]
        [LocalizedDisplayName("IDType")]
        public uint IDType { get; set; }
        [LocalizedCategory("OperationParam")]
        [LocalizedDisplayName("Range")]
        public int Range { get; set; }
        [LocalizedCategory("OperationParam")]
        [LocalizedDisplayName("PlayerNum")]
        public int PlayerNum { get; set; }
        // Target param
        [LocalizedCategory("TargetParam")]
        [LocalizedDisplayName("Target")]
        public TargetParam Target { get; set; }

        public O_DELIVER_TASK_IN_HATE_LIST()
        {
            ID = 0;
            IDType = 0;
            Range = 0;
            PlayerNum = 0;
            Target = new TargetParam();
        }

        public void Read(BinaryReader br)
        {
            ID = br.ReadUInt32();
            IDType = br.ReadUInt32();
            Range = br.ReadInt32();
            PlayerNum = br.ReadInt32();
            Target = TargetStream.Read(br);
        }

        public void Write(BinaryWriter bw)
        {
            bw.Write(ID);
            bw.Write(IDType);
            bw.Write(Range);
            bw.Write(PlayerNum);
            TargetStream.Save(bw, Target);
        }

        public bool Search(string str)
        {
            if (ID.ToString().Contains(str) || IDType.ToString().Contains(str) ||
                Range.ToString().Contains(str) || PlayerNum.ToString().Contains(str))
                return true;
            else
                return false;
        }

        public object Clone()
        {
            return new O_DELIVER_TASK_IN_HATE_LIST() { ID = ID, IDType = IDType, Range = Range, PlayerNum = PlayerNum, Target = Target.Clone() as TargetParam  };
        }
    }
}
