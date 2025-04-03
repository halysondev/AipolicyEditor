using AipolicyEditor.AIPolicy.Operations.CustomEditors;
using System;
using System.ComponentModel;
using System.IO;
using WPFLocalizeExtension.Extensions;

namespace AipolicyEditor.AIPolicy.Operations
{
    public class O_CALC_VAR_MULTI : IOperation, ICloneable
    {
        [Browsable(false)]
        public int FromVersion => 100;
        [Browsable(false)]
        public int OperID => 201;
        [Browsable(false)]
        public string Name => MainWindow.Provider.GetLocalizedString("o201");

        //Trigger param
        [LocalizedCategory("CalcDestParam")]
        [LocalizedDisplayName("Dst")]
        public int Dst { get; set; }
        [LocalizedCategory("CalcDestParam")]
        [LocalizedDisplayName("DstType")]
        public VarType DstType { get; set; }
        //-------------------------------------- // 1st operation
        [LocalizedCategory("CalcParam1")]
        [LocalizedDisplayName("Src1VarTypeConst")]
        public VarTypeConst Src1VarTypeConst { get; set; }
        [LocalizedCategory("CalcParam1")]
        [LocalizedDisplayName("Src1")]
        public float Src1 { get; set; }
        [LocalizedCategory("CalcParam1")]
        [LocalizedDisplayName("Src1Type")]
        public VarType Src1Type { get; set; }
        [LocalizedCategory("CalcParam1")]
        [LocalizedDisplayName("Op1")]
        public OperatorType Op1 { get; set; }
        //-------------------------------------- // 2nd operation
        [LocalizedCategory("CalcParam2")]
        [LocalizedDisplayName("Src2VarTypeConst")]
        public VarTypeConst Src2VarTypeConst { get; set; }
        [LocalizedCategory("CalcParam2")]
        [LocalizedDisplayName("Src2")]
        public float Src2 { get; set; }
        [LocalizedCategory("CalcParam2")]
        [LocalizedDisplayName("Src2Type")]
        public VarType Src2Type { get; set; }
        [LocalizedCategory("CalcParam2")]
        [LocalizedDisplayName("Op2")]
        public OperatorType Op2 { get; set; }
        //-------------------------------------- // 3rd operation
        [LocalizedCategory("CalcParam3")]
        [LocalizedDisplayName("Src3VarTypeConst")]
        public VarTypeConst Src3VarTypeConst { get; set; }
        [LocalizedCategory("CalcParam3")]
        [LocalizedDisplayName("Src3")]
        public float Src3 { get; set; }
        [LocalizedCategory("CalcParam3")]
        [LocalizedDisplayName("Src3Type")]
        public VarType Src3Type { get; set; }
        [LocalizedCategory("CalcParam3")]
        [LocalizedDisplayName("Op3")]
        public OperatorType Op3 { get; set; }
        //-------------------------------------- // 4th operation
        [LocalizedCategory("CalcParam4")]
        [LocalizedDisplayName("Src4VarTypeConst")]
        public VarTypeConst Src4VarTypeConst { get; set; }
        [LocalizedCategory("CalcParam4")]
        [LocalizedDisplayName("Src4")]
        public float Src4 { get; set; }
        [LocalizedCategory("CalcParam4")]
        [LocalizedDisplayName("Src4Type")]
        public VarType Src4Type { get; set; }
        [LocalizedCategory("CalcParam4")]
        [LocalizedDisplayName("Op4")]
        public OperatorType Op4 { get; set; }
        //-------------------------------------- // 5th operation
        [LocalizedCategory("CalcParam5")]
        [LocalizedDisplayName("Src5VarTypeConst")]
        public VarTypeConst Src5VarTypeConst { get; set; }
        [LocalizedCategory("CalcParam5")]
        [LocalizedDisplayName("Src5")]
        public float Src5 { get; set; }
        [LocalizedCategory("CalcParam5")]
        [LocalizedDisplayName("Src5Type")]
        public VarType Src5Type { get; set; }
        [LocalizedCategory("CalcParam5")]
        [LocalizedDisplayName("Op5")]
        public OperatorType Op5 { get; set; }
        //--------------------------------------
        // Target param
        [LocalizedCategory("TargetParam")]
        [LocalizedDisplayName("Target")]
        public TargetParam Target { get; set; }

        public O_CALC_VAR_MULTI()
        {
            Dst = 0;
            DstType = VarType.GlobalVarID;
            //-------------------------------------- // 1st operation
            Src1VarTypeConst = VarTypeConst.NoCalc;
            Src1 = 0.0F;
            Src1Type = VarType.Const;
            Op1 = OperatorType.Add;
            //-------------------------------------- // 2nd operation
            Src2VarTypeConst = VarTypeConst.NoCalc;
            Src2 = 0.0F;
            Src2Type = VarType.Const;
            Op2 = OperatorType.Add;
            //-------------------------------------- // 3rd operation
            Src3VarTypeConst = VarTypeConst.NoCalc;
            Src3 = 0.0F;
            Src3Type = VarType.Const;
            Op3 = OperatorType.Add;
            //-------------------------------------- // 4th operation
            Src4VarTypeConst = VarTypeConst.NoCalc;
            Src4 = 0.0F;
            Src4Type = VarType.Const;
            Op4 = OperatorType.Add;
            //-------------------------------------- // 5th operation
            Src5VarTypeConst = VarTypeConst.NoCalc;
            Src5 = 0.0F;
            Src5Type = VarType.Const;
            Op5 = OperatorType.Add;
            //--------------------------------------
            Target = new TargetParam();
        }

        public void Read(BinaryReader br)
        {
            Dst = br.ReadInt32();
            DstType = (VarType)br.ReadInt32();
            //-------------------------------------- // 1st operation
            Src1VarTypeConst = (VarTypeConst)br.ReadInt32();
            Src1 = br.ReadSingle();
            Src1Type = (VarType)br.ReadInt32();
            Op1 = (OperatorType)br.ReadInt32();
            //-------------------------------------- // 2nd operation
            Src2VarTypeConst = (VarTypeConst)br.ReadInt32();
            Src2 = br.ReadSingle();
            Src2Type = (VarType)br.ReadInt32();
            Op2 = (OperatorType)br.ReadInt32();
            //-------------------------------------- // 3rd operation
            Src3VarTypeConst = (VarTypeConst)br.ReadInt32();
            Src3 = br.ReadSingle();
            Src3Type = (VarType)br.ReadInt32();
            Op3 = (OperatorType)br.ReadInt32();
            //-------------------------------------- // 4th operation
            Src4VarTypeConst = (VarTypeConst)br.ReadInt32();
            Src4 = br.ReadSingle();
            Src4Type = (VarType)br.ReadInt32();
            Op4 = (OperatorType)br.ReadInt32();
            //-------------------------------------- // 5th operation
            Src5VarTypeConst = (VarTypeConst)br.ReadInt32();
            Src5 = br.ReadSingle();
            Src5Type = (VarType)br.ReadInt32();
            Op5 = (OperatorType)br.ReadInt32();
            //--------------------------------------
            Target = TargetStream.Read(br);
        }

        public void Write(BinaryWriter bw)
        {
            bw.Write(Dst);
            bw.Write(Convert.ToUInt32(DstType));
            //-------------------------------------- // 1st operation
            bw.Write(Convert.ToUInt32(Src1VarTypeConst));
            bw.Write(Src1);
            bw.Write(Convert.ToUInt32(Src1Type));
            bw.Write(Convert.ToUInt32(Op1));
            //-------------------------------------- // 2nd operation
            bw.Write(Convert.ToUInt32(Src2VarTypeConst));
            bw.Write(Src2);
            bw.Write(Convert.ToUInt32(Src2Type));
            bw.Write(Convert.ToUInt32(Op2));
            //-------------------------------------- // 3rd operation
            bw.Write(Convert.ToUInt32(Src3VarTypeConst));
            bw.Write(Src3);
            bw.Write(Convert.ToUInt32(Src3Type));
            bw.Write(Convert.ToUInt32(Op3));
            //-------------------------------------- // 4th operation
            bw.Write(Convert.ToUInt32(Src4VarTypeConst));
            bw.Write(Src4);
            bw.Write(Convert.ToUInt32(Src4Type));
            bw.Write(Convert.ToUInt32(Op4));
            //-------------------------------------- // 5rd operation
            bw.Write(Convert.ToUInt32(Src5VarTypeConst));
            bw.Write(Src5);
            bw.Write(Convert.ToUInt32(Src5Type));
            bw.Write(Convert.ToUInt32(Op5));
            //--------------------------------------
            TargetStream.Save(bw, Target);
        }

        public bool Search(string str)
        {
            if (Dst.ToString().Contains(str) 
                || DstType.ToString().Contains(str)
                //-------------------------------------- // 1st operation
                || Src1VarTypeConst.ToString().Contains(str)
                || Src1.ToString().Contains(str) 
                || Src1Type.ToString().Contains(str) 
                || Op1.ToString().Contains(str)
                //-------------------------------------- // 2nd operation
                || Src2VarTypeConst.ToString().Contains(str)
                || Src2.ToString().Contains(str) 
                || Src2Type.ToString().Contains(str)
                || Op2.ToString().Contains(str)
                //-------------------------------------- // 3rd operation
                || Src3VarTypeConst.ToString().Contains(str)
                || Src3.ToString().Contains(str)
                || Src3Type.ToString().Contains(str)
                || Op3.ToString().Contains(str)
                //-------------------------------------- // 4rd operation
                || Src4VarTypeConst.ToString().Contains(str)
                || Src4.ToString().Contains(str)
                || Src4Type.ToString().Contains(str)
                || Op4.ToString().Contains(str)
                //-------------------------------------- // 5rd operation
                || Src5VarTypeConst.ToString().Contains(str)
                || Src5.ToString().Contains(str)
                || Src5Type.ToString().Contains(str)
                || Op5.ToString().Contains(str))
                return true;
            else
                return false;
        }

        public object Clone()
        {
            return new O_CALC_VAR_MULTI()
            {
                Dst = Dst, 
                DstType = DstType, 
                //-------------------------------------- // 1st operation
                Src1VarTypeConst = Src1VarTypeConst,
                Src1 = Src1, 
                Src1Type = Src1Type, 
                Op1 = Op1,
                //-------------------------------------- // 2nd operation
                Src2VarTypeConst = Src2VarTypeConst,
                Src2 = Src2, 
                Src2Type = Src2Type,
                Op2 = Op2,
                //-------------------------------------- // 3rd operation
                Src3VarTypeConst = Src3VarTypeConst,
                Src3 = Src3,
                Src3Type = Src3Type,
                Op3 = Op3,
                //-------------------------------------- // 4th operation
                Src4VarTypeConst = Src4VarTypeConst,
                Src4 = Src4,
                Src4Type = Src4Type,
                Op4 = Op4,
                //-------------------------------------- // 5th operation
                Src5VarTypeConst = Src5VarTypeConst,
                Src5 = Src5,
                Src5Type = Src5Type,
                Op5 = Op5,
                //--------------------------------------
                Target = Target.Clone() as TargetParam
            };
        }
    }
}
