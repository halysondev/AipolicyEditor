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
    public class O_TALK_TEXT_2 : IOperation, ICloneable
    {
        [Browsable(false)]
        public int FromVersion => 30;
        [Browsable(false)]
        public int OperID => 53;
        [Browsable(false)]
        public string Name => MainWindow.Provider.GetLocalizedString("o53");

        //Trigger param
        [LocalizedDisplayName("Text")]
        [LocalizedCategory("OperationParam")]
        public string Text { get; set; }

        [LocalizedDisplayName("Value1")]
        [LocalizedCategory("OperationParam")]
        public int Mask { get; set; }

        [LocalizedDisplayName("Value2")]
        [LocalizedCategory("OperationParam")]
        public int iChannelKinds { get; set; }

        [LocalizedDisplayName("Value3")]
        [LocalizedCategory("OperationParam")]
        public int iChannelKindsType { get; set; }

        [LocalizedCategory("OperationParam")]
        [LocalizedDisplayName("Value4")]
        public int iChannelID { get; set; }

        [LocalizedDisplayName("Value5")]
        [LocalizedCategory("OperationParam")]
        public int iChannelIDType { get; set; }

        [LocalizedDisplayName("Target")]
        [LocalizedCategory("TargetParam")]
        public TargetParam Target { get; set; }

        public O_TALK_TEXT_2()
        {
            Text = "";
            Mask = 0;
            iChannelKinds = 0;
            iChannelKindsType = 0;
            iChannelID = 0;
            iChannelIDType = 0;
            Target = new TargetParam();
        }

        public void Read(BinaryReader br)
        {
            int count = br.ReadInt32();
            Text = br.ReadBytes(count).ToUnicode();
            Mask = br.ReadInt32();
            iChannelKinds = br.ReadInt32();
            iChannelKindsType = br.ReadInt32();
            iChannelID = br.ReadInt32();
            iChannelIDType = br.ReadInt32();
            Target = TargetStream.Read(br);
        }

        public void Write(BinaryWriter bw)
        {
            byte[] bytes = Encoding.Unicode.GetBytes(Text);
            bytes = bytes.Append((System.Byte)0).ToArray();
            bytes = bytes.Append((System.Byte)0).ToArray();
            bw.Write(bytes.Length);
            bw.Write(bytes);
            bw.Write(Mask);
            bw.Write(iChannelKinds);
            bw.Write(iChannelKindsType);
            bw.Write(iChannelID);
            bw.Write(iChannelIDType);
            TargetStream.Save(bw, Target);
        }

        public bool Search(string str)
        {
            if (Text.ToString().Contains(str) || Mask.ToString().Contains(str) || iChannelKinds.ToString().Contains(str) || iChannelKindsType.ToString().Contains(str) || iChannelID.ToString().Contains(str) || iChannelIDType.ToString().Contains(str))
            {
                return true;
            }
                return false;
        }

        public object Clone()
        {
            return new O_TALK_TEXT_2() {
                Text = Text,
                Mask = Mask,
                iChannelKinds = iChannelKinds,
                iChannelKindsType = iChannelKindsType,
                iChannelID = iChannelID,
                iChannelIDType = iChannelIDType,
                Target = Target.Clone() as TargetParam  };
        }
    }
}
