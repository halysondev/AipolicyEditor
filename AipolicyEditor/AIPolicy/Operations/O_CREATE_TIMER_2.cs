using AipolicyEditor.AIPolicy.Operations.CustomEditors;
using System;
using System.ComponentModel;
using System.IO;
using WPFLocalizeExtension.Extensions;

namespace AipolicyEditor.AIPolicy.Operations
{
    public class O_CREATE_TIMER_2 : IOperation, ICloneable
    {
        [Browsable(false)]
        public int FromVersion => 30;
        [Browsable(false)]
        public int OperID => 54;
        [Browsable(false)]
        public string Name => MainWindow.Provider.GetLocalizedString("o54");

        //Trigger param
        [LocalizedCategory("OperationParam")]
        [LocalizedDisplayName("uID")]
        public uint uID { get; set; }
        [LocalizedCategory("OperationParam")]
        [LocalizedDisplayName("iIDType")]
        public VarType iIDType { get; set; }
        [LocalizedCategory("OperationParam")]
        [LocalizedDisplayName("uPeriod")]
        public uint uPeriod { get; set; }
        [LocalizedCategory("OperationParam")]
        [LocalizedDisplayName("iPeriodType")]
        public VarType iPeriodType { get; set; }
        [LocalizedCategory("OperationParam")]
        [LocalizedDisplayName("uCounter")]
        public uint uCounter { get; set; }
        [LocalizedCategory("OperationParam")]
        [LocalizedDisplayName("iCounterType")]
        public VarType iCounterType { get; set; }
        // Target param
        [LocalizedCategory("TargetParam")]
        [LocalizedDisplayName("Target")]
        public TargetParam Target { get; set; }

        public O_CREATE_TIMER_2()
        {
            uID = 0;
            iIDType = 0;
            uPeriod = 0;
            iPeriodType = 0;
            uCounter = 0;
            iCounterType = 0;
            Target = new TargetParam();
        }

        public void Read(BinaryReader br)
        {
            uID = br.ReadUInt32();
            iIDType = (VarType)br.ReadInt32();
            uPeriod = br.ReadUInt32();
            iPeriodType = (VarType)br.ReadInt32();
            uCounter = br.ReadUInt32();
            iCounterType = (VarType)br.ReadInt32();
            Target = TargetStream.Read(br);
        }

        public void Write(BinaryWriter bw)
        {
            bw.Write(uID);
            bw.Write(Convert.ToUInt32(iIDType));
            bw.Write(uPeriod);
            bw.Write(Convert.ToUInt32(iPeriodType));
            bw.Write(uCounter);
            bw.Write(Convert.ToUInt32(iCounterType));
            TargetStream.Save(bw, Target);
        }

        public bool Search(string str)
        {
            if (uID.ToString().Contains(str) || iIDType.ToString().Contains(str) || uPeriod.ToString().Contains(str) || iPeriodType.ToString().Contains(str) || uCounter.ToString().Contains(str) || iCounterType.ToString().Contains(str))
                return true;
            else
                return false;
        }

        public object Clone()
        {
            return new O_CREATE_TIMER_2() { uID = uID, iIDType = iIDType, uPeriod = uPeriod, iPeriodType = iPeriodType, uCounter = uCounter, iCounterType = iCounterType, Target = Target.Clone() as TargetParam  };
        }
    }
}
