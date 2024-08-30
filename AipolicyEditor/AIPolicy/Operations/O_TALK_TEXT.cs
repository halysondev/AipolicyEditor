using AipolicyEditor.AIPolicy.Operations.CustomEditors;
using Syncfusion.Windows.PropertyGrid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using WPFLocalizeExtension.Extensions;

namespace AipolicyEditor.AIPolicy.Operations
{
    public class O_TALK_TEXT : IOperation, ICloneable
    {
        [Browsable(false)]
        public int FromVersion => 16;
        [Browsable(false)]
        public int OperID => 2;
        [Browsable(false)]
        public string Name => MainWindow.Provider.GetLocalizedString("o2");

        //Trigger param
        [LocalizedCategory("OperationParam")]
        [LocalizedDisplayName("ChatChannel")]
        public ChatChannels2 ChatChannel { get; set; }
        [LocalizedCategory("OperationParam")]
        [LocalizedDisplayName("Text")]
        public string Text { get; set; }
        [LocalizedCategory("OperationParam")]
        [LocalizedDisplayName("AppendDataMask")]
        public TalkTextAppendDataMask AppendDataMask { get; set; }
        // Target param
        [LocalizedCategory("TargetParam")]
        [LocalizedDisplayName("Target")]
        public TargetParam Target { get; set; }

        public O_TALK_TEXT()
        {
            ChatChannel = ChatChannels2.Normal;
            Text = "";
            AppendDataMask = TalkTextAppendDataMask.None;
            Target = new TargetParam();
        }

        public void Read(BinaryReader br)
        {
            int size = br.ReadInt32();
            Text = br.ReadBytes(size).ToUnicode();
            if (Text.StartsWith("$"))
            {
                string c = Text.Substring(0, 2);
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
                Text = Text.Remove(0, 2);
            }
            AppendDataMask = (TalkTextAppendDataMask)br.ReadUInt32();
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
            byte[] data = Encoding.Unicode.GetBytes(channel + Text + '\0');
            bw.Write(data.Length);
            bw.Write(data);
            bw.Write(Convert.ToUInt32(AppendDataMask));
            TargetStream.Save(bw, Target);
        }

        public bool Search(string str)
        {
            if (Text.Contains(str) || AppendDataMask.ToString().Contains(str))
                return true;
            else
                return false;
        }

        public object Clone()
        {
            return new O_TALK_TEXT() { Text = Text, AppendDataMask = AppendDataMask, Target = Target.Clone() as TargetParam  };
        }
    }
}
