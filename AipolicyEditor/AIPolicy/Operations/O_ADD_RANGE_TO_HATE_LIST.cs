using AipolicyEditor.AIPolicy.Operations.CustomEditors;
using System;
using System.ComponentModel;
using System.IO;
using WPFLocalizeExtension.Extensions;

namespace AipolicyEditor.AIPolicy.Operations
{
    public class O_ADD_RANGE_TO_HATE_LIST : IOperation, ICloneable
    {
        [Browsable(false)]
        public int FromVersion => 28;
        [Browsable(false)]
        public int OperID => 41;
        [Browsable(false)]
        public string Name => MainWindow.Provider.GetLocalizedString("o41");

        //Trigger param
        [LocalizedCategory("OperationParam")]
        [LocalizedDisplayName("range")]
        public int range { get; set; }

        [LocalizedCategory("OperationParam")]
        [LocalizedDisplayName("rangeType")]

        public uint rangeType { get; set; }

        // Target param
        [LocalizedCategory("TargetParam")]
        [LocalizedDisplayName("Target")]
        public TargetParam Target { get; set; }

        public O_ADD_RANGE_TO_HATE_LIST()
        {
            range = 0;
            rangeType = 0;
            Target = new TargetParam();
        }

        public void Read(BinaryReader br)
        {
            range = br.ReadInt32();
            rangeType = br.ReadUInt32();
            Target = TargetStream.Read(br);
        }

        public void Write(BinaryWriter bw)
        {
            bw.Write(range);
            bw.Write(rangeType);
            TargetStream.Save(bw, Target);
        }

        public bool Search(string str)
        {
            if (range.ToString().Contains(str) || rangeType.ToString().Contains(str))
                return true;
            else
                return false;
        }

        public object Clone()
        {
            return new O_ADD_RANGE_TO_HATE_LIST() { range = range, rangeType = rangeType, Target = Target.Clone() as TargetParam  };
        }
    }
}
