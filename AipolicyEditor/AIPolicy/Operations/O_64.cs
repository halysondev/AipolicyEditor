using System;
using System.ComponentModel;
using System.IO;
using AipolicyEditor.AIPolicy.Operations.CustomEditors;

namespace AipolicyEditor.AIPolicy.Operations
{
	public class O_64 : IOperation, ICloneable
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
        [LocalizedCategory("ControllersParam")]
        public int ID1 { get; set; }

        [LocalizedDisplayName("ID1Type")]
        [LocalizedCategory("ControllersParam")]
        public int ID1Type { get; set; }

        [LocalizedDisplayName("ID2")]
        [LocalizedCategory("ControllersParam")]
        public int ID2 { get; set; }
        [LocalizedDisplayName("ID2Type")]
        [LocalizedCategory("ControllersParam")]
        public int ID2Type { get; set; }

        [LocalizedDisplayName("ID3")]
        [LocalizedCategory("ControllersParam")]
        public int ID3 { get; set; }
        [LocalizedDisplayName("ID3Type")]
        [LocalizedCategory("ControllersParam")]
        public int ID3Type { get; set; }

        [LocalizedDisplayName("ID4")]
        [LocalizedCategory("ControllersParam")]
        public int ID4 { get; set; }
        [LocalizedDisplayName("ID4Type")]
        [LocalizedCategory("ControllersParam")]
        public int ID4Type { get; set; }

        [LocalizedDisplayName("ID5")]
        [LocalizedCategory("ControllersParam")]
        public int ID5 { get; set; }
        [LocalizedDisplayName("ID5Type")]
        [LocalizedCategory("ControllersParam")]
        public int ID5Type { get; set; }

        [LocalizedDisplayName("ID6")]
        [LocalizedCategory("ControllersParam")]
        public int ID6 { get; set; }
        [LocalizedDisplayName("ID6Type")]
        [LocalizedCategory("ControllersParam")]
        public int ID6Type { get; set; }

        [LocalizedDisplayName("ID7")]
        [LocalizedCategory("ControllersParam")]
        public int ID7 { get; set; }
        [LocalizedDisplayName("ID7Type")]
        [LocalizedCategory("ControllersParam")]
        public int ID7Type { get; set; }

        [LocalizedDisplayName("ID8")]
        [LocalizedCategory("ControllersParam")]
        public int ID8 { get; set; }
        [LocalizedDisplayName("ID8Type")]
        [LocalizedCategory("ControllersParam")]
        public int ID8Type { get; set; }

        [LocalizedDisplayName("ID9")]
        [LocalizedCategory("ControllersParam")]
        public int ID9 { get; set; }
        [LocalizedDisplayName("ID9Type")]
        [LocalizedCategory("ControllersParam")]
        public int ID9Type { get; set; }

        [LocalizedDisplayName("ID10")]
        [LocalizedCategory("ControllersParam")]
        public int ID10 { get; set; }
        [LocalizedDisplayName("ID10Type")]
        [LocalizedCategory("ControllersParam")]
        public int ID10Type { get; set; }


        public O_64()
		{
			bStop = false;
			bytes = new byte[3];
            ID1 = 0;
            ID1Type = 0;
            ID2 = 0;
            ID2Type = 0;
            ID3 = 0;
            ID3Type = 0;
            ID4 = 0;
            ID4Type = 0;
            ID5 = 0;
            ID5Type = 0;
            ID6 = 0;
            ID6Type = 0;
            ID7 = 0;
            ID7Type = 0;
            ID8 = 0;
            ID8Type = 0;
            ID9 = 0;
            ID9Type = 0;
            ID10 = 0;
            ID10Type = 0;
            Target = new TargetParam();
		}

		public void Read(BinaryReader br)
		{
			bStop = br.ReadBoolean();
			bytes = br.ReadBytes(3);
            ID1 = br.ReadInt32();
            ID1Type = br.ReadInt32();
            ID2 = br.ReadInt32();
            ID2Type = br.ReadInt32();
            ID3 = br.ReadInt32();
            ID3Type = br.ReadInt32();
            ID4 = br.ReadInt32();
            ID4Type = br.ReadInt32();
            ID5 = br.ReadInt32();
            ID5Type = br.ReadInt32();
            ID6 = br.ReadInt32();
            ID6Type = br.ReadInt32();
            ID7 = br.ReadInt32();
            ID7Type = br.ReadInt32();
            ID8 = br.ReadInt32();
            ID8Type = br.ReadInt32();
            ID9 = br.ReadInt32();
            ID9Type = br.ReadInt32();
            ID10 = br.ReadInt32();
            ID10Type = br.ReadInt32();
            Target = TargetStream.Read(br);
		}

		public void Write(BinaryWriter bw)
		{
			bw.Write(bStop);
			bw.Write(bytes);
            bw.Write(ID1);
            bw.Write(ID1Type);
            bw.Write(ID2);
            bw.Write(ID2Type);
            bw.Write(ID3);
            bw.Write(ID3Type);
            bw.Write(ID4);
            bw.Write(ID4Type);
            bw.Write(ID5);
            bw.Write(ID5Type);
            bw.Write(ID6);
            bw.Write(ID6Type);
            bw.Write(ID7);
            bw.Write(ID7Type);
            bw.Write(ID8);
            bw.Write(ID8Type);
            bw.Write(ID9);
            bw.Write(ID9Type);
            bw.Write(ID10);
            bw.Write(ID10Type);
            TargetStream.Save(bw, Target);
		}

		public bool Search(string str)
		{
			if (bStop.ToString().Contains(str))
			{
				return true;
			}
			return false;
		}

		public object Clone()
		{
			return new O_64
			{
                bStop = bStop,
                Target = (Target.Clone() as TargetParam)
			};
		}
	}
}
