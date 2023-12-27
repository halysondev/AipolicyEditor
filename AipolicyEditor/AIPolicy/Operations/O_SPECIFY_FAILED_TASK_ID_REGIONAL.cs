using AipolicyEditor.AIPolicy.Operations.CustomEditors;
using System;
using System.ComponentModel;
using System.IO;
using WPFLocalizeExtension.Extensions;

namespace AipolicyEditor.AIPolicy.Operations
{
    public class O_SPECIFY_FAILED_TASK_ID_REGIONAL : IOperation, ICloneable
    {
        [Browsable(false)]
        public int FromVersion => 33;
        [Browsable(false)]
        public int OperID => 63;
        [Browsable(false)]
        public string Name => MainWindow.Provider.GetLocalizedString("o63");

        //Trigger param
        [LocalizedCategory("OperationParam")]
        [LocalizedDisplayName("iTaskID")]
        public int iTaskID { get; set; }

        [LocalizedCategory("OperationParam")]
        [LocalizedDisplayName("iTaskIDType")]
        public int iTaskIDType { get; set; }
        [LocalizedCategory("OperationParam")]
        [LocalizedDisplayName("zvMinx")]
        public float zvMinx { get; set; }

        [LocalizedCategory("OperationParam")]
        [LocalizedDisplayName("zvMiny")]
        public float zvMiny { get; set; }

        [LocalizedDisplayName("zvMinz")]
        [LocalizedCategory("OperationParam")]
        public float zvMinz { get; set; }

        [LocalizedDisplayName("zvMaxx")]
        [LocalizedCategory("OperationParam")]
        public float zvMaxx { get; set; }

        [LocalizedDisplayName("zvMaxy")]
        [LocalizedCategory("OperationParam")]
        public float zvMaxy { get; set; }

        [LocalizedDisplayName("zvMaxz")]
        [LocalizedCategory("OperationParam")]
        public float zvMaxz { get; set; }

        // Target param
        [LocalizedCategory("TargetParam")]
        [LocalizedDisplayName("Target")]
        public TargetParam Target { get; set; }

        public O_SPECIFY_FAILED_TASK_ID_REGIONAL()
        {
            iTaskID = 0;
            iTaskIDType = 0;
            zvMinx = 0;
            zvMiny = 0;
            zvMinz = 0;
            zvMaxx = 0;
            zvMaxy = 0;
            zvMaxz = 0;
            Target = new TargetParam();
        }

        public void Read(BinaryReader br)
        {
            iTaskID = br.ReadInt32();
            iTaskIDType = br.ReadInt32();
            zvMinx = br.ReadSingle();
            zvMiny = br.ReadSingle();
            zvMinz = br.ReadSingle();
            zvMaxx = br.ReadSingle();
            zvMaxy = br.ReadSingle();
            zvMaxz = br.ReadSingle();
            Target = TargetStream.Read(br);
        }

        public void Write(BinaryWriter bw)
        {
            bw.Write(iTaskID);
            bw.Write(iTaskIDType);
            bw.Write(zvMinx);
            bw.Write(zvMiny);
            bw.Write(zvMinz);
            bw.Write(zvMaxx);
            bw.Write(zvMaxy);
            bw.Write(zvMaxz);
            TargetStream.Save(bw, Target);
        }

        public bool Search(string str)
        {
            if (iTaskID.ToString().Contains(str))
                return true;
            else
                return false;
        }

        public object Clone()
        {
            return new O_SPECIFY_FAILED_TASK_ID_REGIONAL() { iTaskID = iTaskID, iTaskIDType = iTaskIDType,
                zvMinx = zvMinx,
                zvMiny = zvMiny,
                zvMinz = zvMinz,
                zvMaxx = zvMaxx,
                zvMaxy = zvMaxy,
                zvMaxz = zvMaxz, Target = Target.Clone() as TargetParam  };
        }
    }
}
