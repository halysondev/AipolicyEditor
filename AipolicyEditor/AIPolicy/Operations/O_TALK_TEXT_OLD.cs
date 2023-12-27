using AipolicyEditor.AIPolicy.Operations.CustomEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using WPFLocalizeExtension.Extensions;

namespace AipolicyEditor.AIPolicy.Operations
{
    public class O_TALK_TEXT_OLD : IOperation, ICloneable
    {
        [Browsable(false)]
        public int FromVersion => 1;
        [Browsable(false)]
        public int OperID => 2;
        [Browsable(false)]
        public string Name => MainWindow.Provider.GetLocalizedString("o2");

        //Trigger param
        [LocalizedCategory("OperationParam")]
        [LocalizedDisplayName("Text")]
        public string Text { get; set; }
        // Target param
        [LocalizedCategory("TargetParam")]
        [LocalizedDisplayName("Target")]
        public TargetParam Target { get; set; }

        public O_TALK_TEXT_OLD()
        {
            Text = "";
            Target = new TargetParam();
        }

        public void Read(BinaryReader br)
        {
            int size = br.ReadInt32();
            Text = br.ReadBytes(size).ToUnicode();
            Target = TargetStream.Read(br);
        }

        public void Write(BinaryWriter bw)
        {
            byte[] data = Encoding.Unicode.GetBytes(Text + '\0');
            bw.Write(data.Length);
            bw.Write(data);
            TargetStream.Save(bw, Target);
        }

        public bool Search(string str)
        {
            if (Text.Contains(str))
                return true;
            else
                return false;
        }

        public object Clone()
        {
            return new O_TALK_TEXT_OLD() { Text = Text, Target = Target.Clone() as TargetParam  };
        }
    }
}
