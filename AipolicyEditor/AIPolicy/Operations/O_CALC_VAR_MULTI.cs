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
        [LocalizedCategory("OperationParam")]
        [LocalizedDisplayName("Dst")]
        public int Dst { get; set; }
        [LocalizedCategory("OperationParam")]
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
        [LocalizedDisplayName("Op")]
        public OperatorType Op { get; set; }
        [LocalizedCategory("CalcParam1")]
        [LocalizedDisplayName("Src2VarTypeConst")]
        public VarTypeConst Src2VarTypeConst { get; set; }
        [LocalizedCategory("CalcParam1")]
        [LocalizedDisplayName("Src2")]
        public float Src2 { get; set; }
        [LocalizedCategory("CalcParam1")]
        [LocalizedDisplayName("Src2Type")]
        public VarType Src2Type { get; set; }
        //-------------------------------------- // 2nd operation
        [LocalizedCategory("CalcParam2")]
        [LocalizedDisplayName("Src3VarTypeConst")]
        public VarTypeConst Src3VarTypeConst { get; set; }
        [LocalizedCategory("CalcParam2")]
        [LocalizedDisplayName("Src3")]
        public float Src3 { get; set; }
        [LocalizedCategory("CalcParam2")]
        [LocalizedDisplayName("Src3Type")]
        public VarType Src3Type { get; set; }
        [LocalizedCategory("CalcParam2")]
        [LocalizedDisplayName("Op2")]
        public OperatorType Op2 { get; set; }
        [LocalizedCategory("CalcParam2")]
        [LocalizedDisplayName("Src4VarTypeConst")]
        public VarTypeConst Src4VarTypeConst { get; set; }
        [LocalizedCategory("CalcParam2")]
        [LocalizedDisplayName("Src4")]
        public float Src4 { get; set; }
        [LocalizedCategory("CalcParam2")]
        [LocalizedDisplayName("Src4Type")]
        public VarType Src4Type { get; set; }
        //-------------------------------------- // 3rd operation
        [LocalizedCategory("CalcParam3")]
        [LocalizedDisplayName("Src5VarTypeConst")]
        public VarTypeConst Src5VarTypeConst { get; set; }
        [LocalizedCategory("CalcParam3")]
        [LocalizedDisplayName("Src5")]
        public float Src5 { get; set; }
        [LocalizedCategory("CalcParam3")]
        [LocalizedDisplayName("Src5Type")]
        public VarType Src5Type { get; set; }
        [LocalizedCategory("CalcParam3")]
        [LocalizedDisplayName("Op3")]
        public OperatorType Op3 { get; set; }
        [LocalizedCategory("CalcParam3")]
        [LocalizedDisplayName("Src6VarTypeConst")]
        public VarTypeConst Src6VarTypeConst { get; set; }
        [LocalizedCategory("CalcParam3")]
        [LocalizedDisplayName("Src6")]
        public float Src6 { get; set; }
        [LocalizedCategory("CalcParam3")]
        [LocalizedDisplayName("Src6Type")]
        public VarType Src6Type { get; set; }
        //-------------------------------------- // 4th operation
        [LocalizedCategory("CalcParam4")]
        [LocalizedDisplayName("Src7VarTypeConst")]
        public VarTypeConst Src7VarTypeConst { get; set; }
        [LocalizedCategory("CalcParam4")]
        [LocalizedDisplayName("Src7")]
        public float Src7 { get; set; }
        [LocalizedCategory("CalcParam4")]
        [LocalizedDisplayName("Src7Type")]
        public VarType Src7Type { get; set; }
        [LocalizedCategory("CalcParam4")]
        [LocalizedDisplayName("Op4")]
        public OperatorType Op4 { get; set; }
        [LocalizedCategory("CalcParam4")]
        [LocalizedDisplayName("Src8VarTypeConst")]
        public VarTypeConst Src8VarTypeConst { get; set; }
        [LocalizedCategory("CalcParam4")]
        [LocalizedDisplayName("Src8")]
        public float Src8 { get; set; }
        [LocalizedCategory("CalcParam4")]
        [LocalizedDisplayName("Src8Type")]
        public VarType Src8Type { get; set; }
        //-------------------------------------- // 5th operation
        [LocalizedCategory("CalcParam5")]
        [LocalizedDisplayName("Src9VarTypeConst")]
        public VarTypeConst Src9VarTypeConst { get; set; }
        [LocalizedCategory("CalcParam5")]
        [LocalizedDisplayName("Src9")]
        public float Src9 { get; set; }
        [LocalizedCategory("CalcParam5")]
        [LocalizedDisplayName("Src9Type")]
        public VarType Src9Type { get; set; }
        [LocalizedCategory("CalcParam5")]
        [LocalizedDisplayName("Op5")]
        public OperatorType Op5 { get; set; }
        [LocalizedCategory("CalcParam5")]
        [LocalizedDisplayName("Src10VarTypeConst")]
        public VarTypeConst Src10VarTypeConst { get; set; }
        [LocalizedCategory("CalcParam5")]
        [LocalizedDisplayName("Src10")]
        public float Src10 { get; set; }
        [LocalizedCategory("CalcParam5")]
        [LocalizedDisplayName("Src10Type")]
        public VarType Src10Type { get; set; }
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
            Src1VarTypeConst = VarTypeConst.Int;
            Src1 = 0.0F;
            Src1Type = VarType.GlobalVarID;
            Op = OperatorType.Add;
            Src2VarTypeConst = VarTypeConst.Int;
            Src2 = 0.0F;
            Src2Type = VarType.GlobalVarID;
            //-------------------------------------- // 2nd operation
            Src3VarTypeConst = VarTypeConst.Int;
            Src3 = 0.0F;
            Src3Type = VarType.GlobalVarID;
            Op2 = OperatorType.Add;
            Src4VarTypeConst = VarTypeConst.Int;
            Src4 = 0.0F;
            Src4Type = VarType.GlobalVarID;
            //-------------------------------------- // 3rd operation
            Src5VarTypeConst = VarTypeConst.Int;
            Src5 = 0.0F;
            Src5Type = VarType.GlobalVarID;
            Op3 = OperatorType.Add;
            Src6VarTypeConst = VarTypeConst.Int;
            Src6 = 0.0F;
            Src6Type = VarType.GlobalVarID;
            //-------------------------------------- // 4th operation
            Src7VarTypeConst = VarTypeConst.Int;
            Src7 = 0.0F;
            Src7Type = VarType.GlobalVarID;
            Op4 = OperatorType.Add;
            Src8VarTypeConst = VarTypeConst.Int;
            Src8 = 0.0F;
            Src8Type = VarType.GlobalVarID;
            //-------------------------------------- // 5th operation
            Src9VarTypeConst = VarTypeConst.Int;
            Src9 = 0.0F;
            Src9Type = VarType.GlobalVarID;
            Op5 = OperatorType.Add;
            Src10VarTypeConst = VarTypeConst.Int;
            Src10 = 0.0F;
            Src10Type = VarType.GlobalVarID;
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
            Op = (OperatorType)br.ReadInt32();
            Src2VarTypeConst = (VarTypeConst)br.ReadInt32();
            Src2 = br.ReadSingle();
            Src2Type = (VarType)br.ReadInt32();
            //-------------------------------------- // 2nd operation
            Src3VarTypeConst = (VarTypeConst)br.ReadInt32();
            Src3 = br.ReadSingle();
            Src3Type = (VarType)br.ReadInt32();
            Op2 = (OperatorType)br.ReadInt32();
            Src4VarTypeConst = (VarTypeConst)br.ReadInt32();
            Src4 = br.ReadSingle();
            Src4Type = (VarType)br.ReadInt32();
            //-------------------------------------- // 3rd operation
            Src5VarTypeConst = (VarTypeConst)br.ReadInt32();
            Src5 = br.ReadSingle();
            Src5Type = (VarType)br.ReadInt32();
            Op3 = (OperatorType)br.ReadInt32();
            Src6VarTypeConst = (VarTypeConst)br.ReadInt32();
            Src6 = br.ReadSingle();
            Src6Type = (VarType)br.ReadInt32();
            //-------------------------------------- // 4th operation
            Src7VarTypeConst = (VarTypeConst)br.ReadInt32();
            Src7 = br.ReadSingle();
            Src7Type = (VarType)br.ReadInt32();
            Op4 = (OperatorType)br.ReadInt32();
            Src8VarTypeConst = (VarTypeConst)br.ReadInt32();
            Src8 = br.ReadSingle();
            Src8Type = (VarType)br.ReadInt32();
            //-------------------------------------- // 5th operation
            Src9VarTypeConst = (VarTypeConst)br.ReadInt32();
            Src9 = br.ReadSingle();
            Src9Type = (VarType)br.ReadInt32();
            Op5 = (OperatorType)br.ReadInt32();
            Src10VarTypeConst = (VarTypeConst)br.ReadInt32();
            Src10 = br.ReadSingle();
            Src10Type = (VarType)br.ReadInt32();
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
            bw.Write(Convert.ToUInt32(Op));
            bw.Write(Convert.ToUInt32(Src2VarTypeConst));
            bw.Write(Src2);
            bw.Write(Convert.ToUInt32(Src2Type));
            //-------------------------------------- // 2nd operation
            bw.Write(Convert.ToUInt32(Src3VarTypeConst));
            bw.Write(Src3);
            bw.Write(Convert.ToUInt32(Src3Type));
            bw.Write(Convert.ToUInt32(Op2));
            bw.Write(Convert.ToUInt32(Src4VarTypeConst));
            bw.Write(Src4);
            bw.Write(Convert.ToUInt32(Src4Type));
            //-------------------------------------- // 3rd operation
            bw.Write(Convert.ToUInt32(Src5VarTypeConst));
            bw.Write(Src5);
            bw.Write(Convert.ToUInt32(Src5Type));
            bw.Write(Convert.ToUInt32(Op3));
            bw.Write(Convert.ToUInt32(Src6VarTypeConst));
            bw.Write(Src6);
            bw.Write(Convert.ToUInt32(Src6Type));
            //-------------------------------------- // 4th operation
            bw.Write(Convert.ToUInt32(Src7VarTypeConst));
            bw.Write(Src7);
            bw.Write(Convert.ToUInt32(Src7Type));
            bw.Write(Convert.ToUInt32(Op4));
            bw.Write(Convert.ToUInt32(Src8VarTypeConst));
            bw.Write(Src8);
            bw.Write(Convert.ToUInt32(Src8Type));
            //-------------------------------------- // 5th operation
            bw.Write(Convert.ToUInt32(Src9VarTypeConst));
            bw.Write(Src9);
            bw.Write(Convert.ToUInt32(Src9Type));
            bw.Write(Convert.ToUInt32(Op5));
            bw.Write(Convert.ToUInt32(Src10VarTypeConst));
            bw.Write(Src10);
            bw.Write(Convert.ToUInt32(Src10Type));
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
                || Op.ToString().Contains(str) 
                || Src2VarTypeConst.ToString().Contains(str)
                || Src2.ToString().Contains(str) 
                || Src2Type.ToString().Contains(str)
                //-------------------------------------- // 2nd operation
                || Src3VarTypeConst.ToString().Contains(str)
                || Src3.ToString().Contains(str)
                || Src3Type.ToString().Contains(str)
                || Op2.ToString().Contains(str)
                || Src4VarTypeConst.ToString().Contains(str)
                || Src4.ToString().Contains(str)
                || Src4Type.ToString().Contains(str)
                //-------------------------------------- // 3rd operation
                || Src5VarTypeConst.ToString().Contains(str)
                || Src5.ToString().Contains(str)
                || Src5Type.ToString().Contains(str)
                || Op3.ToString().Contains(str)
                || Src6VarTypeConst.ToString().Contains(str)
                || Src6.ToString().Contains(str)
                || Src6Type.ToString().Contains(str)
                //-------------------------------------- // 4th operation
                || Src7VarTypeConst.ToString().Contains(str)
                || Src7.ToString().Contains(str)
                || Src7Type.ToString().Contains(str)
                || Op4.ToString().Contains(str)
                || Src8VarTypeConst.ToString().Contains(str)
                || Src8.ToString().Contains(str)
                || Src8Type.ToString().Contains(str)
                //-------------------------------------- // 5th operation
                || Src9VarTypeConst.ToString().Contains(str)
                || Src9.ToString().Contains(str)
                || Src9Type.ToString().Contains(str)
                || Op5.ToString().Contains(str)
                || Src10VarTypeConst.ToString().Contains(str)
                || Src10.ToString().Contains(str)
                || Src10Type.ToString().Contains(str))
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
                Op = Op, 
                Src2VarTypeConst = Src2VarTypeConst,
                Src2 = Src2, 
                Src2Type = Src2Type, 
                //-------------------------------------- // 2nd operation
                Src3VarTypeConst = Src3VarTypeConst,
                Src3 = Src3,
                Src3Type = Src3Type,
                Op2 = Op2,
                Src4VarTypeConst = Src4VarTypeConst,
                Src4 = Src4,
                Src4Type = Src4Type,
                //-------------------------------------- // 3rd operation
                Src5VarTypeConst = Src5VarTypeConst,
                Src5 = Src5,
                Src5Type = Src5Type,
                Op3 = Op3,
                Src6VarTypeConst = Src6VarTypeConst,
                Src6 = Src6,
                Src6Type = Src6Type,
                //-------------------------------------- // 4th operation
                Src7VarTypeConst = Src7VarTypeConst,
                Src7 = Src7,
                Src7Type = Src7Type,
                Op4 = Op4,
                Src8VarTypeConst = Src8VarTypeConst,
                Src8 = Src8,
                Src8Type = Src8Type,
                //-------------------------------------- // 5th operation
                Src9VarTypeConst = Src9VarTypeConst,
                Src9 = Src9,
                Src9Type = Src9Type,
                Op5 = Op5,
                Src10VarTypeConst = Src10VarTypeConst,
                Src10 = Src10,
                Src10Type = Src10Type,
                //--------------------------------------
                Target = Target.Clone() as TargetParam
            };
        }
    }
}
