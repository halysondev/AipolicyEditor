using AipolicyEditor.AIPolicy.Operations.CustomEditors;
using System;
using System.ComponentModel;
using System.IO;
using WPFLocalizeExtension.Extensions;

namespace AipolicyEditor.AIPolicy.Operations
{
    public class O_RANDOM_ASSIGNMENT : IOperation, ICloneable
    {
        [Browsable(false)]
        public int FromVersion => 30;
        [Browsable(false)]
        public int OperID => 47;
        [Browsable(false)]
        public string Name => MainWindow.Provider.GetLocalizedString("o47");

        //Trigger param
        [LocalizedCategory("OperationParam")]
        [LocalizedDisplayName("iRandomMin")]
        public int iRandomMin { get; set; }
        [LocalizedCategory("OperationParam")]
        [LocalizedDisplayName("iRandomMax")]
        public int iRandomMax { get; set; }
        [LocalizedCategory("OperationParam")]
        [LocalizedDisplayName("iQuantity")]
        public int iQuantity { get; set; }
        [LocalizedCategory("OperationParam")]
        [LocalizedDisplayName("iTargetID")]
        public int iTargetID { get; set; }

        // Target param
        [LocalizedCategory("TargetParam")]
        [LocalizedDisplayName("Target")]
        public TargetParam Target { get; set; }

        public O_RANDOM_ASSIGNMENT()
        {
            iRandomMin = 0;
            iRandomMax = 0;
            iQuantity = 0;
            iTargetID = 0;
            Target = new TargetParam();
        }

        public void Read(BinaryReader br)
        {
            iRandomMin = br.ReadInt32();
            iRandomMax = br.ReadInt32();
            iQuantity = br.ReadInt32();
            iTargetID = br.ReadInt32();
            Target = TargetStream.Read(br);
        }

        public void Write(BinaryWriter bw)
        {
            bw.Write(iRandomMin);
            bw.Write(iRandomMax);
            bw.Write(iQuantity);
            bw.Write(iTargetID);
            TargetStream.Save(bw, Target);
        }

        public bool Search(string str)
        {
            if (iRandomMin.ToString().Contains(str) || iRandomMax.ToString().Contains(str) || iQuantity.ToString().Contains(str) || iTargetID.ToString().Contains(str))
                return true;
            else
                return false;
        }

        public object Clone()
        {
            return new O_RANDOM_ASSIGNMENT() {
                iRandomMin = iRandomMin,
                iRandomMax = iRandomMax,
                iQuantity = iQuantity,
                iTargetID = iTargetID,
                Target = Target.Clone() as TargetParam  };
        }
    }
}
