using AipolicyEditor.AIPolicy.Operations.CustomEditors;
using System;
using System.ComponentModel;
using System.IO;
using WPFLocalizeExtension.Extensions;

namespace AipolicyEditor.AIPolicy.Operations
{
    public class O_DELIVER_FACTION_PVP_POINTS : IOperation, ICloneable
    {
        [Browsable(false)]
        public int FromVersion => 20;
        [Browsable(false)]
        public int OperID => 22;
        [Browsable(false)]
        public string Name => MainWindow.Provider.GetLocalizedString("o22");

        //Trigger param
        [LocalizedCategory("OperationParam")]
        [LocalizedDisplayName("Type")]
        public FactionPVPPointType Type { get; set; }
        // Target param
        [LocalizedCategory("TargetParam")]
        [LocalizedDisplayName("Target")]
        public TargetParam Target { get; set; }

        public O_DELIVER_FACTION_PVP_POINTS()
        {
            Type = FactionPVPPointType.MineCar;
            Target = new TargetParam();
        }

        public void Read(BinaryReader br)
        {
            Type = (FactionPVPPointType)br.ReadUInt32();
            Target = TargetStream.Read(br);
        }

        public void Write(BinaryWriter bw)
        {
            bw.Write((uint)Type);
            TargetStream.Save(bw, Target);
        }

        public bool Search(string str)
        {
            if (Type.ToString().Contains(str))
                return true;
            else
                return false;
        }

        public object Clone()
        {
            return new O_DELIVER_FACTION_PVP_POINTS() { Type = Type, Target = Target.Clone() as TargetParam  };
        }
    }
}
