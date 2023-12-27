using AipolicyEditor.AIPolicy.Operations.CustomEditors;
using System;
using System.ComponentModel;
using System.IO;
using WPFLocalizeExtension.Extensions;

namespace AipolicyEditor.AIPolicy.Operations
{
    public class O_CHANGE_MONSTER_ATTACK_POLICY : IOperation, ICloneable
    {
        [Browsable(false)]
        public int FromVersion => 33;
        [Browsable(false)]
        public int OperID => 61;
        [Browsable(false)]
        public string Name => MainWindow.Provider.GetLocalizedString("o61");

        //Trigger param
        [LocalizedCategory("OperationParam")]
        [LocalizedDisplayName("iChangeState")]
        public int iAttackPolicyID { get; set; }

        // Target param
        [LocalizedCategory("TargetParam")]
        [LocalizedDisplayName("Target")]
        public TargetParam Target { get; set; }

        public O_CHANGE_MONSTER_ATTACK_POLICY()
        {
            iAttackPolicyID = 0;
            Target = new TargetParam();
        }

        public void Read(BinaryReader br)
        {
            iAttackPolicyID = br.ReadInt32();
            Target = TargetStream.Read(br);
        }

        public void Write(BinaryWriter bw)
        {
            bw.Write(iAttackPolicyID);
            TargetStream.Save(bw, Target);
        }

        public bool Search(string str)
        {
            if (iAttackPolicyID.ToString().Contains(str))
                return true;
            else
                return false;
        }

        public object Clone()
        {
            return new O_CHANGE_MONSTER_ATTACK_POLICY() { iAttackPolicyID = iAttackPolicyID, Target = Target.Clone() as TargetParam  };
        }
    }
}
