using AipolicyEditor.AIPolicy.Operations.CustomEditors;
using System;
using System.ComponentModel;
using System.IO;
using WPFLocalizeExtension.Extensions;

namespace AipolicyEditor.AIPolicy.Operations
{
    public class O_SAVE_TIME : IOperation, ICloneable
    {
        [Browsable(false)]
        public int FromVersion => 28;
        [Browsable(false)]
        public int OperID => 46;
        [Browsable(false)]
        public string Name => MainWindow.Provider.GetLocalizedString("o46");

        //Trigger param
        [LocalizedCategory("OperationParam")]
        [LocalizedDisplayName("iTimeType")]
        public TimeType iTimeType { get; set; }
        [LocalizedCategory("OperationParam")]
        [LocalizedDisplayName("iParamID")]
        public int iParamID { get; set; }
        [LocalizedCategory("OperationParam")]
        [LocalizedDisplayName("iParamIDType")]
        public VarType iParamIDType { get; set; }

        // Target param
        [LocalizedCategory("TargetParam")]
        [LocalizedDisplayName("Target")]
        public TargetParam Target { get; set; }

        public O_SAVE_TIME()
        {
            iTimeType = TimeType.Year;
            iParamID = 0;
            iParamIDType = VarType.GlobalVarID;
            Target = new TargetParam();
        }

        public void Read(BinaryReader br)
        {
            iTimeType = (TimeType)br.ReadInt32();
            iParamID = br.ReadInt32();
            iParamIDType = (VarType)br.ReadInt32();
            Target = TargetStream.Read(br);
        }

        public void Write(BinaryWriter bw)
        {
            bw.Write(Convert.ToUInt32(iTimeType));
            bw.Write(iParamID);
            bw.Write(Convert.ToUInt32(iParamIDType));
            TargetStream.Save(bw, Target);
        }

        public bool Search(string str)
        {
            if (iTimeType.ToString().Contains(str) || iParamID.ToString().Contains(str) || iParamIDType.ToString().Contains(str))
                return true;
            else
                return false;
        }

        public object Clone()
        {
            return new O_SAVE_TIME() {
                iTimeType = iTimeType,
                iParamID = iParamID,
                iParamIDType = iParamIDType, 
                Target = Target.Clone() as TargetParam  };
        }
    }
}
