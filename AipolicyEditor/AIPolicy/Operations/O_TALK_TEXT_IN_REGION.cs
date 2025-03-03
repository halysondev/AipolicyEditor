using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using AipolicyEditor.AIPolicy.Operations.CustomEditors;
using static System.Net.Mime.MediaTypeNames;

namespace AipolicyEditor.AIPolicy.Operations
{

	public class O_TALK_TEXT_IN_REGION : IOperation, ICloneable
	{
		[Browsable(false)]
		public int FromVersion => 33;

		[Browsable(false)]
		public int OperID => 72;

		[Browsable(false)]
		public string Name => MainWindow.Provider.GetLocalizedString("o72");

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
        [LocalizedDisplayName("zvMin_X")]
        public float zvMin_X { get; set; }

        [LocalizedDisplayName("zvMin_Y")]
        [LocalizedCategory("OperationParam")]
        public float zvMin_Y { get; set; }

        [LocalizedCategory("OperationParam")]
        [LocalizedDisplayName("zvMin_Z")]
        public float zvMin_Z { get; set; }

        [LocalizedCategory("OperationParam")]
        [LocalizedDisplayName("zvMax_X")]
        public float zvMax_X { get; set; }

        [LocalizedDisplayName("zvMax_Y")]
        [LocalizedCategory("OperationParam")]
        public float zvMax_Y { get; set; }

        [LocalizedDisplayName("zvMax_Z")]
        [LocalizedCategory("OperationParam")]
        public float zvMax_Z { get; set; }
        public TargetParam Target { get; set; }

		public O_TALK_TEXT_IN_REGION()
		{
            szData = "";
            uSize = 0;
            ChatChannel = 0;
            uAppendDataMask = 0;
            zvMin_X = 0;
            zvMin_Y = 0;
            zvMin_Z = 0;
            zvMax_X = 0;
            zvMax_Y = 0;
            zvMax_Z = 0;
            Target = new TargetParam();
		}

		public void Read(BinaryReader br)
		{
			int count = br.ReadInt32();
            szData = br.ReadBytes(count).ToUnicode();
            if(szData.StartsWith("$"))
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
            zvMin_X = br.ReadSingle();
            zvMin_Y = br.ReadSingle();
            zvMin_Z = br.ReadSingle();
            zvMax_X = br.ReadSingle();
            zvMax_Y = br.ReadSingle();
            zvMax_Z = br.ReadSingle();
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
            data = data.Append((System.Byte)0).ToArray();
            data = data.Append((System.Byte)0).ToArray();
            bw.Write(data.Length);
            bw.Write(data);
            bw.Write(Convert.ToUInt32(uAppendDataMask));
            bw.Write(zvMin_X);
            bw.Write(zvMin_Y);
            bw.Write(zvMin_Z);
            bw.Write(zvMax_X);
            bw.Write(zvMax_Y);
            bw.Write(zvMax_Z);
            TargetStream.Save(bw, Target);
		}

		public bool Search(string str)
		{
			if (szData.ToString().Contains(str) || uAppendDataMask.ToString().Contains(str) || ChatChannel.ToString().Contains(str) || zvMin_X.ToString().Contains(str) || zvMin_Y.ToString().Contains(str) || zvMin_Z.ToString().Contains(str) || zvMax_X.ToString().Contains(str) || zvMax_Y.ToString().Contains(str) || zvMax_Z.ToString().Contains(str))
			{
				return true;
			}
			return false;
		}

		public object Clone()
		{
			return new O_TALK_TEXT_IN_REGION
			{
                uSize = uSize,
                szData = szData,
                ChatChannel = ChatChannel,
                uAppendDataMask = uAppendDataMask,
                zvMin_X = zvMin_X,
                zvMin_Y = zvMin_Y,
                zvMin_Z = zvMin_Z,
                zvMax_X = zvMax_X,
                zvMax_Y = zvMax_Y,
                zvMax_Z = zvMax_Z,
				Target = (Target.Clone() as TargetParam)
			};
		}
	}
}
