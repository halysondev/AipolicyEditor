using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using AipolicyEditor.AIPolicy.Operations.CustomEditors;

namespace AipolicyEditor.AIPolicy.Operations
{

	public class O_106 : IOperation, ICloneable
	{
		[Browsable(false)]
		public int FromVersion => 40;

		[Browsable(false)]
		public int OperID => 106;

		[Browsable(false)]
		public string Name => MainWindow.Provider.GetLocalizedString("o106");

        [LocalizedCategory("OperationParam")]
        [LocalizedDisplayName("uSize")]
        public int uSize { get; set; }

        [LocalizedDisplayName("ChatChannel")]
        [LocalizedCategory("OperationParam")]
        public ChatChannels2 ChatChannel { get; set; }

        [LocalizedDisplayName("szData")]
        [LocalizedCategory("OperationParam")]
        public string szData { get; set; }

        [LocalizedDisplayName("uAppendDataMask")]
        [LocalizedCategory("OperationParam")]
        public TalkTextAppendDataMask uAppendDataMask { get; set; }

        [LocalizedCategory("OperationParam")]
		[LocalizedDisplayName("Value1")]
		public int Value1 { get; set; }

		[LocalizedCategory("OperationParam")]
		[LocalizedDisplayName("Value2")]
		public int Value2 { get; set; }

		[LocalizedCategory("OperationParam")]
		[LocalizedDisplayName("Value3")]
		public int Value3 { get; set; }

		[LocalizedDisplayName("Value4")]
		[LocalizedCategory("OperationParam")]
		public int Value4 { get; set; }

        [LocalizedDisplayName("Value5")]
        [LocalizedCategory("OperationParam")]
        public int Value5 { get; set; }

        [LocalizedDisplayName("Value6")]
        [LocalizedCategory("OperationParam")]
        public int Value6 { get; set; }

        [LocalizedDisplayName("Value7")]
        [LocalizedCategory("OperationParam")]
        public int Value7 { get; set; }

        [LocalizedDisplayName("Value8")]
        [LocalizedCategory("OperationParam")]
        public int Value8 { get; set; }

        [LocalizedDisplayName("Value9")]
        [LocalizedCategory("OperationParam")]
        public int Value9 { get; set; }

        [LocalizedDisplayName("Value10")]
        [LocalizedCategory("OperationParam")]
        public int Value10 { get; set; }

        [LocalizedDisplayName("Value11")]
        [LocalizedCategory("OperationParam")]
        public int Value11 { get; set; }

        [LocalizedDisplayName("Value12")]
        [LocalizedCategory("OperationParam")]
        public int Value12 { get; set; }

        [LocalizedDisplayName("Value13")]
        [LocalizedCategory("OperationParam")]
        public int Value13 { get; set; }

        [LocalizedDisplayName("Target")]
		[LocalizedCategory("TargetParam")]

		public TargetParam Target { get; set; }

		public O_106()
		{
            szData = "";
            uSize = 0;
            ChatChannel = 0;
            uAppendDataMask = 0;
            Value1 = 0;
			Value2 = 0;
			Value3 = 0;
			Value4 = 0;
            Value5 = 0;
            Value6 = 0;
            Value7 = 0;
            Value8 = 0;
            Value9 = 0;
            Value10 = 0;
            Value11 = 0;
            Value12 = 0;
            Value13 = 0;
            Target = new TargetParam();
		}

		public void Read(BinaryReader br)
		{
            int count = br.ReadInt32();
            szData = br.ReadBytes(count).ToUnicode();
            if (szData.StartsWith("$"))
            {
                string c = szData.Substring(0, 2);
                switch (c)
                {
                    case "$F":
                        ChatChannel = ChatChannels2.Faction;
                        break;
                    case "$S":
                        ChatChannel = ChatChannels2.System;
                        break;
                    case "$A":
                        ChatChannel = ChatChannels2.Anonymous;
                        break;
                    case "$B":
                        ChatChannel = ChatChannels2.Broadcast;
                        break;
                    case "$I":
                        ChatChannel = ChatChannels2.Instance;
                        break;
                    case "$X":
                        ChatChannel = ChatChannels2.InstanceCenterScreen;
                        break;
                    case "$W":
                        ChatChannel = ChatChannels2.Whisper;
                        break;
                    default:
                        ChatChannel = ChatChannels2.Normal;
                        break;
                }
            }
            else
            {
                ChatChannel = ChatChannels2.Normal;
            }
            if (ChatChannel != ChatChannels2.Normal)
            {
                szData = szData.Remove(0, 2);
            }
            uAppendDataMask = (TalkTextAppendDataMask)br.ReadInt32();
            Value1 = br.ReadInt32();
			Value2 = br.ReadInt32();
			Value3 = br.ReadInt32();
			Value4 = br.ReadInt32();
            Value5 = br.ReadInt32();
            Value6 = br.ReadInt32();
            Value7 = br.ReadInt32();
            Value8 = br.ReadInt32();
            Value9 = br.ReadInt32();
            Value10 = br.ReadInt32();
            Value11 = br.ReadInt32();
            Value12 = br.ReadInt32();
            Value13 = br.ReadInt32();
            Target = TargetStream.Read(br);
		}

		public void Write(BinaryWriter bw)
		{
            string channel = "";
            switch (ChatChannel)
            {
                case ChatChannels2.Faction:
                    channel = "$F";
                    break;
                case ChatChannels2.System:
                    channel = "$S";
                    break;
                case ChatChannels2.Anonymous:
                    channel = "$A";
                    break;
                case ChatChannels2.Broadcast:
                    channel = "$B";
                    break;
                case ChatChannels2.Instance:
                    channel = "$I";
                    break;
                case ChatChannels2.InstanceCenterScreen:
                    channel = "$X";
                    break;
                case ChatChannels2.Whisper:
                    channel = "$W";
                    break;
            }
            byte[] data = Encoding.Unicode.GetBytes(channel + szData + '\0');
            //data = data.Append((System.Byte)0).ToArray();
            //data = data.Append((System.Byte)0).ToArray();
            bw.Write(data.Length);
            bw.Write(data);
            bw.Write(Convert.ToUInt32(uAppendDataMask));
            bw.Write(Value1);
			bw.Write(Value2);
			bw.Write(Value3);
			bw.Write(Value4);
            bw.Write(Value5);
            bw.Write(Value6);
            bw.Write(Value7);
            bw.Write(Value8);
            bw.Write(Value9);
            bw.Write(Value10);
            bw.Write(Value11);
            bw.Write(Value12);
            bw.Write(Value13);
            TargetStream.Save(bw, Target);
		}

		public bool Search(string str)
		{
			if (Value1.ToString().Contains(str) || Value2.ToString().Contains(str) || Value3.ToString().Contains(str) || Value4.ToString().Contains(str))
			{
				return true;
			}
			return false;
		}

		public object Clone()
		{
			return new O_106
			{
                szData = szData,
                uAppendDataMask = uAppendDataMask,
                Value1 = Value1,
				Value2 = Value2,
				Value3 = Value3,
				Value4 = Value4,
                Value5 = Value5,
                Value6 = Value6,
                Value7 = Value7,
                Value8 = Value8,
                Value9 = Value9,
                Value10 = Value10,
                Value11 = Value11,
                Value12 = Value12,
                Value13 = Value13,
                Target = (Target.Clone() as TargetParam)
			};
		}
	}
}
