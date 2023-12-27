using AipolicyEditor.AIPolicy.Operations.CustomEditors;
using System;
using System.ComponentModel;
using System.IO;
using WPFLocalizeExtension.Extensions;

namespace AipolicyEditor.AIPolicy.Operations
{
    public class O_SET_HISTORY : IOperation, ICloneable
    {
        [Browsable(false)]
        public int FromVersion => 14;
        [Browsable(false)]
        public int OperID => 21;
        [Browsable(false)]
        public string Name => MainWindow.Provider.GetLocalizedString("o21");

        //Trigger param
        [LocalizedCategory("OperationParam")]
        [LocalizedDisplayName("ID")]
        public int ID { get; set; }
        [LocalizedCategory("OperationParam")]
        [LocalizedDisplayName("Value")]
        public int Value { get; set; }
        [LocalizedCategory("OperationParam")]
        [LocalizedDisplayName("IsHistoryValue")]
        public bool IsHistoryValue { get; set; }
        // Target param
        [LocalizedCategory("TargetParam")]
        [LocalizedDisplayName("Target")]
        public TargetParam Target { get; set; }

        public O_SET_HISTORY()
        {
            ID = 0;
            Value = 0;
            IsHistoryValue = false;
            Target = new TargetParam();
        }

        public void Read(BinaryReader br)
        {
            ID = br.ReadInt32();
            Value = br.ReadInt32();
            IsHistoryValue = br.ReadBoolean();
            br.ReadBytes(3);
            Target = TargetStream.Read(br);
        }

        public void Write(BinaryWriter bw)
        {
            bw.Write(ID);
            bw.Write(Value);
            bw.Write(IsHistoryValue);
            bw.Write(new byte[] { 0, 0, 0 });
            TargetStream.Save(bw, Target);
        }

        public bool Search(string str)
        {
            if (ID.ToString().Contains(str) || Value.ToString().Contains(str) || IsHistoryValue.ToString().Contains(str))
                return true;
            else
                return false;
        }
        public object Clone()
        {
            return new O_SET_HISTORY() { ID = ID, Value = Value, IsHistoryValue = IsHistoryValue, Target = Target.Clone() as TargetParam  };
        }
    }
}
