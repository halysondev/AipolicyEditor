using AipolicyEditor.AIPolicy.Operations.CustomEditors;
using System;
using System.ComponentModel;
using System.IO;
using WPFLocalizeExtension.Extensions;

namespace AipolicyEditor.AIPolicy.Operations
{
    public class O_CHANGE_MONSTER_FIGHTING_STATE : IOperation, ICloneable
    {
        [Browsable(false)]
        public int FromVersion => 30;
        [Browsable(false)]
        public int OperID => 56;
        [Browsable(false)]
        public string Name => MainWindow.Provider.GetLocalizedString("o56");

        //Trigger param
        [LocalizedCategory("OperationParam")]
        [LocalizedDisplayName("iChangeState")]
        public int iChangeState { get; set; }

        // Target param
        [LocalizedCategory("TargetParam")]
        [LocalizedDisplayName("Target")]
        public TargetParam Target { get; set; }

        public O_CHANGE_MONSTER_FIGHTING_STATE()
        {
            iChangeState = 0;
            Target = new TargetParam();
        }

        public void Read(BinaryReader br)
        {
            iChangeState = br.ReadInt32();
            Target = TargetStream.Read(br);
        }

        public void Write(BinaryWriter bw)
        {
            bw.Write(iChangeState);
            TargetStream.Save(bw, Target);
        }

        public bool Search(string str)
        {
            if (iChangeState.ToString().Contains(str))
                return true;
            else
                return false;
        }

        public object Clone()
        {
            return new O_CHANGE_MONSTER_FIGHTING_STATE() { iChangeState = iChangeState, Target = Target.Clone() as TargetParam  };
        }
    }
}
