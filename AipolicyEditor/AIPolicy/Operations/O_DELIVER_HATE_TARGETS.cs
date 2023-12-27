using AipolicyEditor.AIPolicy.Operations.CustomEditors;
using System;
using System.ComponentModel;
using System.IO;
using WPFLocalizeExtension.Extensions;

namespace AipolicyEditor.AIPolicy.Operations
{
    public class O_DELIVER_HATE_TARGETS : IOperation, ICloneable
    {
        [Browsable(false)]
        public int FromVersion => 33;
        [Browsable(false)]
        public int OperID => 60;
        [Browsable(false)]
        public string Name => MainWindow.Provider.GetLocalizedString("o59");

        //Trigger param
        [LocalizedCategory("OperationParam")]
        [LocalizedDisplayName("iMonsterID")]
        public int iMonsterID { get; set; }

        // Target param
        [LocalizedCategory("TargetParam")]
        [LocalizedDisplayName("Target")]
        public TargetParam Target { get; set; }

        public O_DELIVER_HATE_TARGETS()
        {
            iMonsterID = 0;
            Target = new TargetParam();
        }

        public void Read(BinaryReader br)
        {
            iMonsterID = br.ReadInt32();
            Target = TargetStream.Read(br);
        }

        public void Write(BinaryWriter bw)
        {
            bw.Write(iMonsterID);
            TargetStream.Save(bw, Target);
        }

        public bool Search(string str)
        {
            if (iMonsterID.ToString().Contains(str))
                return true;
            else
                return false;
        }

        public object Clone()
        {
            return new O_DELIVER_HATE_TARGETS() { iMonsterID = iMonsterID, Target = Target.Clone() as TargetParam  };
        }
    }
}
