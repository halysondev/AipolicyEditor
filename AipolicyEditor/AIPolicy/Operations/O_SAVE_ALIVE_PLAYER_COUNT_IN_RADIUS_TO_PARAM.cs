using AipolicyEditor.AIPolicy.Operations.CustomEditors;
using System;
using System.ComponentModel;
using System.IO;
using WPFLocalizeExtension.Extensions;

namespace AipolicyEditor.AIPolicy.Operations
{
    public class O_SAVE_ALIVE_PLAYER_COUNT_IN_RADIUS_TO_PARAM : IOperation, ICloneable
    {
        [Browsable(false)]
        public int FromVersion => 28;
        [Browsable(false)]
        public int OperID => 42;
        [Browsable(false)]
        public string Name => MainWindow.Provider.GetLocalizedString("o42");

        //Trigger param
        [LocalizedCategory("OperationParam")]
        [LocalizedDisplayName("fRadiusValue")]
        public float fRadiusValue { get; set; }
        [LocalizedCategory("OperationParam")]
        [LocalizedDisplayName("uRadiusType")]
        public VarType uRadiusType { get; set; }
        [LocalizedCategory("OperationParam")]
        [LocalizedDisplayName("iTargetID")]
        public int iTargetID { get; set; }
        [LocalizedCategory("OperationParam")]
        [LocalizedDisplayName("uTargetType")]
        public VarType uTargetType { get; set; }
        // Target param
        [LocalizedCategory("TargetParam")]
        [LocalizedDisplayName("Target")]
        public TargetParam Target { get; set; }

        public O_SAVE_ALIVE_PLAYER_COUNT_IN_RADIUS_TO_PARAM()
        {
            fRadiusValue = 0;
            uRadiusType = VarType.GlobalVarID;
            iTargetID = 0;
            uTargetType = VarType.GlobalVarID;
            Target = new TargetParam();
        }

        public void Read(BinaryReader br)
        {
            fRadiusValue = br.ReadSingle();
            uRadiusType = (VarType)br.ReadUInt32();
            iTargetID = br.ReadInt32();
            uTargetType = (VarType)br.ReadUInt32();
            Target = TargetStream.Read(br);
        }

        public void Write(BinaryWriter bw)
        {
            bw.Write(fRadiusValue);
            bw.Write(Convert.ToUInt32(uRadiusType));
            bw.Write(iTargetID);
            bw.Write(Convert.ToUInt32(uTargetType));
            TargetStream.Save(bw, Target);
        }

        public bool Search(string str)
        {
            if (fRadiusValue.ToString().Contains(str) || uRadiusType.ToString().Contains(str) || iTargetID.ToString().Contains(str) || uTargetType.ToString().Contains(str))
                return true;
            else
                return false;
        }

        public object Clone()
        {
            return new O_SAVE_ALIVE_PLAYER_COUNT_IN_RADIUS_TO_PARAM() { fRadiusValue = fRadiusValue, uRadiusType = uRadiusType, iTargetID = iTargetID, uTargetType = uTargetType, Target = Target.Clone() as TargetParam  };
        }
    }
}
