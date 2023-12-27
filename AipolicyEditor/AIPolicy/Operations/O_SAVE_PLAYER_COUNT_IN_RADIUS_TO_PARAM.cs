using AipolicyEditor.AIPolicy.Operations.CustomEditors;
using System;
using System.ComponentModel;
using System.IO;
using WPFLocalizeExtension.Extensions;

namespace AipolicyEditor.AIPolicy.Operations
{
    public class O_SAVE_PLAYER_COUNT_IN_RADIUS_TO_PARAM : IOperation, ICloneable
    {
        [Browsable(false)]
        public int FromVersion => 23;
        [Browsable(false)]
        public int OperID => 34;
        [Browsable(false)]
        public string Name => MainWindow.Provider.GetLocalizedString("o34");

        //Trigger param
        [LocalizedCategory("OperationParam")]
        [LocalizedDisplayName("RadiusValue")]
        public float RadiusValue { get; set; }
        [LocalizedCategory("OperationParam")]
        [LocalizedDisplayName("RadiusType")]
        public uint RadiusType { get; set; }
        [LocalizedCategory("OperationParam")]
        [LocalizedDisplayName("TargetID")]
        public int TargetID { get; set; }
        [LocalizedCategory("OperationParam")]
        [LocalizedDisplayName("TargetType")]
        public uint Target_Type { get; set; }
        // Target param
        [LocalizedCategory("TargetParam")]
        [LocalizedDisplayName("Target")]
        public TargetParam Target { get; set; }

        public O_SAVE_PLAYER_COUNT_IN_RADIUS_TO_PARAM()
        {
            RadiusValue = 0;
            RadiusType = 0;
            TargetID = 0;
            Target_Type = 0;
            Target = new TargetParam();
        }

        public void Read(BinaryReader br)
        {
            RadiusValue = br.ReadSingle();
            RadiusType = br.ReadUInt32();
            TargetID = br.ReadInt32();
            Target_Type = br.ReadUInt32();
            Target = TargetStream.Read(br);
        }

        public void Write(BinaryWriter bw)
        {
            bw.Write(RadiusValue);
            bw.Write(RadiusType);
            bw.Write(TargetID);
            bw.Write(Target_Type);
            TargetStream.Save(bw, Target);
        }

        public bool Search(string str)
        {
            if (RadiusValue.ToString().Contains(str) || RadiusType.ToString().Contains(str) || TargetID.ToString().Contains(str) || Target_Type.ToString().Contains(str))
                return true;
            else
                return false;
        }

        public object Clone()
        {
            return new O_SAVE_PLAYER_COUNT_IN_RADIUS_TO_PARAM() { RadiusValue = RadiusValue, RadiusType = RadiusType, TargetID = TargetID, Target_Type = Target_Type, Target = Target.Clone() as TargetParam  };
        }
    }
}
