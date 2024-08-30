using System;
using System.ComponentModel;
using System.IO;
using System.Management;
using AipolicyEditor.AIPolicy.Operations.CustomEditors;

namespace AipolicyEditor.AIPolicy.Operations
{
	public class O_MASS_ACTIVE_CONTROLLER : IOperation, ICloneable
	{
		[Browsable(false)]
		public int FromVersion => 33;

		[Browsable(false)]
		public int OperID => 64;

		[Browsable(false)]
		public string Name => MainWindow.Provider.GetLocalizedString("o64");

        [LocalizedDisplayName("Target")]
		[LocalizedCategory("TargetParam")]
		
		public TargetParam Target { get; set; }

        private byte[] bytes = new byte[3];

        [LocalizedDisplayName("bStop")]
        [LocalizedCategory("OperationParam")]
        public bool bStop { get; set; }

        //[LocalizedDisplayName("clControllers")]
        //[LocalizedCategory("ControllersParam")]
        //public POLICY_CONTROLLER_LIST[] clControllers { get; set; } = new POLICY_CONTROLLER_LIST[10];

        [LocalizedDisplayName("ID1")]
        [LocalizedCategory("OperationParam")]
        public int ID1 { get; set; }

        [LocalizedDisplayName("ID1Type")]
        [LocalizedCategory("OperationParam")]
        public VarType ID1Type { get; set; }

        [LocalizedDisplayName("ID2")]
        [LocalizedCategory("OperationParam")]
        public int ID2 { get; set; }
        [LocalizedDisplayName("ID2Type")]
        [LocalizedCategory("OperationParam")]
        public VarType ID2Type { get; set; }

        [LocalizedDisplayName("ID3")]
        [LocalizedCategory("OperationParam")]
        public int ID3 { get; set; }
        [LocalizedDisplayName("ID3Type")]
        [LocalizedCategory("OperationParam")]
        public VarType ID3Type { get; set; }

        [LocalizedDisplayName("ID4")]
        [LocalizedCategory("OperationParam")]
        public int ID4 { get; set; }
        [LocalizedDisplayName("ID4Type")]
        [LocalizedCategory("OperationParam")]
        public VarType ID4Type { get; set; }

        [LocalizedDisplayName("ID5")]
        [LocalizedCategory("OperationParam")]
        public int ID5 { get; set; }
        [LocalizedDisplayName("ID5Type")]
        [LocalizedCategory("OperationParam")]
        public VarType ID5Type { get; set; }

        [LocalizedDisplayName("ID6")]
        [LocalizedCategory("OperationParam")]
        public int ID6 { get; set; }
        [LocalizedDisplayName("ID6Type")]
        [LocalizedCategory("OperationParam")]
        public VarType ID6Type { get; set; }

        [LocalizedDisplayName("ID7")]
        [LocalizedCategory("OperationParam")]
        public int ID7 { get; set; }
        [LocalizedDisplayName("ID7Type")]
        [LocalizedCategory("OperationParam")]
        public VarType ID7Type { get; set; }

        [LocalizedDisplayName("ID8")]
        [LocalizedCategory("OperationParam")]
        public int ID8 { get; set; }
        [LocalizedDisplayName("ID8Type")]
        [LocalizedCategory("OperationParam")]
        public VarType ID8Type { get; set; }

        [LocalizedDisplayName("ID9")]
        [LocalizedCategory("OperationParam")]
        public int ID9 { get; set; }
        [LocalizedDisplayName("ID9Type")]
        [LocalizedCategory("OperationParam")]
        public VarType ID9Type { get; set; }

        [LocalizedDisplayName("ID10")]
        [LocalizedCategory("OperationParam")]
        public int ID10 { get; set; }
        [LocalizedDisplayName("ID10Type")]
        [LocalizedCategory("OperationParam")]
        public VarType ID10Type { get; set; }


        public O_MASS_ACTIVE_CONTROLLER()
        {
            bStop = false;
            bytes = new byte[3];
            ID1 = 0;
            ID1Type = VarType.Const;
            ID2 = 0;
            ID2Type = VarType.Const;
            ID3 = 0;
            ID3Type = VarType.Const;
            ID4 = 0;
            ID4Type = VarType.Const;
            ID5 = 0;
            ID5Type = VarType.Const;
            ID6 = 0;
            ID6Type = VarType.Const;
            ID7 = 0;
            ID7Type = VarType.Const;
            ID8 = 0;
            ID8Type = VarType.Const;
            ID9 = 0;
            ID9Type = VarType.Const;
            ID10 = 0;
            ID10Type = VarType.Const;
            Target = new TargetParam();
        }

        public void Read(BinaryReader br)
        {
            bStop = br.ReadBoolean();
            bytes = br.ReadBytes(3);
            ID1 = br.ReadInt32();
            ID1Type = (VarType)br.ReadUInt32();
            ID2 = br.ReadInt32();
            ID2Type = (VarType)br.ReadUInt32();
            ID3 = br.ReadInt32();
            ID3Type = (VarType)br.ReadUInt32();
            ID4 = br.ReadInt32();
            ID4Type = (VarType)br.ReadUInt32();
            ID5 = br.ReadInt32();
            ID5Type = (VarType)br.ReadUInt32();
            ID6 = br.ReadInt32();
            ID6Type = (VarType)br.ReadUInt32();
            ID7 = br.ReadInt32();
            ID7Type = (VarType)br.ReadUInt32();
            ID8 = br.ReadInt32();
            ID8Type = (VarType)br.ReadUInt32();
            ID9 = br.ReadInt32();
            ID9Type = (VarType)br.ReadUInt32();
            ID10 = br.ReadInt32();
            ID10Type = (VarType)br.ReadUInt32();
            Target = TargetStream.Read(br);
        }

        public void Write(BinaryWriter bw)
        {
            bw.Write(bStop);
            bw.Write(bytes);
            bw.Write(ID1);
            bw.Write(Convert.ToUInt32(ID1Type));
            bw.Write(ID2);
            bw.Write(Convert.ToUInt32(ID2Type));
            bw.Write(ID3);
            bw.Write(Convert.ToUInt32(ID3Type));
            bw.Write(ID4);
            bw.Write(Convert.ToUInt32(ID4Type));
            bw.Write(ID5);
            bw.Write(Convert.ToUInt32(ID5Type));
            bw.Write(ID6);
            bw.Write(Convert.ToUInt32(ID6Type));
            bw.Write(ID7);
            bw.Write(Convert.ToUInt32(ID7Type));
            bw.Write(ID8);
            bw.Write(Convert.ToUInt32(ID8Type));
            bw.Write(ID9);
            bw.Write(Convert.ToUInt32(ID9Type));
            bw.Write(ID10);
            bw.Write(Convert.ToUInt32(ID10Type));
            TargetStream.Save(bw, Target);
        }

        public bool Search(string str)
        {
            if (bStop.ToString().Contains(str) || ID1.ToString().Contains(str) || ID2.ToString().Contains(str) || ID3.ToString().Contains(str) || ID4.ToString().Contains(str) || ID5.ToString().Contains(str)
                || ID6.ToString().Contains(str) || ID7.ToString().Contains(str) || ID8.ToString().Contains(str) || ID9.ToString().Contains(str) || ID10.ToString().Contains(str))
            {
                return true;
            }
            return false;
        }

        public object Clone()
        {
            return new O_MASS_ACTIVE_CONTROLLER
            {
                bStop = bStop,
                Target = (Target.Clone() as TargetParam),
                ID1 = ID1,
                ID1Type = ID1Type,
                ID2 = ID2,
                ID2Type = ID2Type,
                ID3 = ID3,
                ID3Type = ID3Type,
                ID4 = ID4,
                ID4Type = ID4Type,
                ID5 = ID5,
                ID5Type = ID5Type,
                ID6 = ID6,
                ID6Type = ID6Type,
                ID7 = ID7,
                ID7Type = ID7Type,
                ID8 = ID8,
                ID8Type = ID8Type,
                ID9 = ID9,
                ID9Type = ID9Type,
                ID10 = ID10,
                ID10Type = ID10Type,
            };
        }
    }
}