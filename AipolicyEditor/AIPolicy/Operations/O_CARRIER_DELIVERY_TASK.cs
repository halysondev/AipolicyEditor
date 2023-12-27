using AipolicyEditor.AIPolicy.Operations.CustomEditors;
using System;
using System.ComponentModel;
using System.IO;
using WPFLocalizeExtension.Extensions;

namespace AipolicyEditor.AIPolicy.Operations
{
    public class O_CARRIER_DELIVERY_TASK : IOperation, ICloneable
    {
        [Browsable(false)]
        public int FromVersion => 30;
        [Browsable(false)]
        public int OperID => 51;
        [Browsable(false)]
        public string Name => MainWindow.Provider.GetLocalizedString("o51");

        //Trigger param
        [LocalizedCategory("OperationParam")]
        [LocalizedDisplayName("iTaskID")]
        public int iTaskID { get; set; }

        [LocalizedCategory("OperationParam")]
        [LocalizedDisplayName("iTaskIDType")]
        public int iTaskIDType { get; set; }

        // Target param
        [LocalizedCategory("TargetParam")]
        [LocalizedDisplayName("Target")]
        public TargetParam Target { get; set; }

        public O_CARRIER_DELIVERY_TASK()
        {
            iTaskID = 0;
            iTaskIDType = 0;
            Target = new TargetParam();
        }

        public void Read(BinaryReader br)
        {
            iTaskID = br.ReadInt32();
            iTaskIDType = br.ReadInt32();
            Target = TargetStream.Read(br);
        }

        public void Write(BinaryWriter bw)
        {
            bw.Write(iTaskID);
            bw.Write(iTaskIDType);
            TargetStream.Save(bw, Target);
        }

        public bool Search(string str)
        {
            if (iTaskID.ToString().Contains(str) || iTaskIDType.ToString().Contains(str))
                return true;
            else
                return false;
        }

        public object Clone()
        {
            return new O_CARRIER_DELIVERY_TASK() { iTaskID = iTaskID, iTaskIDType = iTaskIDType, Target = Target.Clone() as TargetParam  };
        }
    }
}
