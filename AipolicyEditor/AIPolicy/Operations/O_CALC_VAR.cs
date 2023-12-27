using AipolicyEditor.AIPolicy.Operations.CustomEditors;
using System;
using System.ComponentModel;
using System.IO;
using WPFLocalizeExtension.Extensions;

namespace AipolicyEditor.AIPolicy.Operations
{
    public class O_CALC_VAR : IOperation, ICloneable
    {
        [Browsable(false)]
        public int FromVersion => 20;
        [Browsable(false)]
        public int OperID => 23;
        [Browsable(false)]
        public string Name => MainWindow.Provider.GetLocalizedString("o23");

        //Trigger param
        [LocalizedCategory("OperationParam")]
        [LocalizedDisplayName("Dst")]
        public int Dst { get; set; }
        [LocalizedCategory("OperationParam")]
        [LocalizedDisplayName("DstType")]
        public VarType DstType { get; set; }
        [LocalizedCategory("OperationParam")]
        [LocalizedDisplayName("Src1")]
        public int Src1 { get; set; }
        [LocalizedCategory("OperationParam")]
        [LocalizedDisplayName("Src1Type")]
        public VarType Src1Type { get; set; }
        [LocalizedCategory("OperationParam")]
        [LocalizedDisplayName("Op")]
        public OperatorType Op { get; set; }
        [LocalizedCategory("OperationParam")]
        [LocalizedDisplayName("Src2")]
        public int Src2 { get; set; }
        [LocalizedCategory("OperationParam")]
        [LocalizedDisplayName("Src2Type")]
        public VarType Src2Type { get; set; }
        // Target param
        [LocalizedCategory("TargetParam")]
        [LocalizedDisplayName("Target")]
        public TargetParam Target { get; set; }

        public O_CALC_VAR()
        {
            Dst = 0;
            DstType = VarType.GlobalVarID;
            Src1 = 0;
            Src1Type = VarType.GlobalVarID;
            Op = OperatorType.Add;
            Src2 = 0;
            Src2Type = VarType.GlobalVarID;
            Target = new TargetParam();
        }

        public void Read(BinaryReader br)
        {
            Dst = br.ReadInt32();
            DstType = (VarType)br.ReadInt32();
            Src1 = br.ReadInt32();
            Src1Type = (VarType)br.ReadInt32();
            Op = (OperatorType)br.ReadInt32();
            Src2 = br.ReadInt32();
            Src2Type = (VarType)br.ReadInt32();
            Target = TargetStream.Read(br);
        }

        public void Write(BinaryWriter bw)
        {
            bw.Write(Dst);
            bw.Write((int)DstType);
            bw.Write(Src1);
            bw.Write((int)Src1Type);
            bw.Write((int)Op);
            bw.Write(Src2);
            bw.Write((int)Src2Type);
            TargetStream.Save(bw, Target);
        }

        public bool Search(string str)
        {
            if (Dst.ToString().Contains(str) || DstType.ToString().Contains(str) || Src1.ToString().Contains(str) ||
                Src1Type.ToString().Contains(str) || Op.ToString().Contains(str) || Src2.ToString().Contains(str) || Src2Type.ToString().Contains(str))
                return true;
            else
                return false;
        }

        public object Clone()
        {
            return new O_CALC_VAR() { Dst = Dst, DstType = DstType, Src1 = Src1, Src1Type = Src1Type, Op = Op, Src2 = Src2, Src2Type = Src2Type, Target = Target.Clone() as TargetParam  };
        }
    }
}
