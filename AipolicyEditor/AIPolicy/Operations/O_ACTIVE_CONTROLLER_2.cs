using AipolicyEditor.AIPolicy.Operations.CustomEditors;
using System;
using System.ComponentModel;
using System.IO;
using WPFLocalizeExtension.Extensions;

namespace AipolicyEditor.AIPolicy.Operations
{
    public class O_ACTIVE_CONTROLLER_2 : IOperation, ICloneable
    {
        [Browsable(false)]
        public int FromVersion => 20;
        [Browsable(false)]
        public int OperID => 27;
        [Browsable(false)]
        public string Name => MainWindow.Provider.GetLocalizedString("o27");

        //Trigger param
        [LocalizedCategory("OperationParam")]
        [LocalizedDisplayName("ID")]
        public uint ID { get; set; }
        [LocalizedCategory("OperationParam")]
        [LocalizedDisplayName("IDType")]
        public uint IDType { get; set; }
        [LocalizedCategory("OperationParam")]
        [LocalizedDisplayName("Stop")]
        public bool Stop { get; set; }
        // Target param
        [LocalizedCategory("TargetParam")]
        [LocalizedDisplayName("Target")]
        public TargetParam Target { get; set; }

        public O_ACTIVE_CONTROLLER_2()
        {
            ID = 0;
            IDType = 0;
            Stop = false;
            Target = new TargetParam();
        }

        public void Read(BinaryReader br)
        {
            ID = br.ReadUInt32();
            IDType = br.ReadUInt32();
            Stop = br.ReadBoolean();
            br.ReadBytes(3);
            Target = TargetStream.Read(br);
        }

        public void Write(BinaryWriter bw)
        {
            bw.Write(ID);
            bw.Write(IDType);
            bw.Write(Stop);
            bw.Write(new byte[] { 0, 0, 0 });
            TargetStream.Save(bw, Target);
        }

        public bool Search(string str)
        {
            if (ID.ToString().Contains(str) || IDType.ToString().Contains(str) || Stop.ToString().Contains(str))
                return true;
            else
                return false;
        }

        public object Clone()
        {
            return new O_ACTIVE_CONTROLLER_2() { ID = ID, IDType = IDType, Stop = Stop, Target = Target.Clone() as TargetParam  };
        }
    }
}
