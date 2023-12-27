using AipolicyEditor.AIPolicy.Operations.CustomEditors;
using System;
using System.ComponentModel;
using System.IO;
using WPFLocalizeExtension.Extensions;

namespace AipolicyEditor.AIPolicy.Operations
{
    public class O_PLAY_ACTION_VERSION8 : IOperation, ICloneable
    {
        [Browsable(false)]
        public int FromVersion => 8;
        [Browsable(false)]
        public int OperID => 19;
        [Browsable(false)]
        public string Name => MainWindow.Provider.GetLocalizedString("o19");

        //Trigger param
        [LocalizedCategory("OperationParam")]
        [LocalizedDisplayName("ActionName")]
        public string ActionName { get; set; }
        [LocalizedCategory("OperationParam")]
        [LocalizedDisplayName("Loop")]
        public bool Loop { get; set; }
        [LocalizedCategory("OperationParam")]
        [LocalizedDisplayName("Interval")]
        public int Interval { get; set; }
        // Target param
        [LocalizedCategory("TargetParam")]
        [LocalizedDisplayName("Target")]
        public TargetParam Target { get; set; }

        public O_PLAY_ACTION_VERSION8()
        {
            ActionName = "";
            Loop = false;
            Interval = 0;
            Target = new TargetParam();
        }

        public void Read(BinaryReader br)
        {
            ActionName = br.ReadBytes(128).ToGBK();
            Loop = br.ReadBoolean();
            br.ReadBytes(3);
            Interval = br.ReadInt32();
            Target = TargetStream.Read(br);
        }

        public void Write(BinaryWriter bw)
        {
            bw.Write(ActionName.FromGBK(128));
            bw.Write(Loop);
            bw.Write(new byte[] { 0, 0, 0 });
            bw.Write(Interval);
            TargetStream.Save(bw, Target);
        }

        public bool Search(string str)
        {
            if (ActionName.Contains(str) || Loop.ToString().Contains(str) || Interval.ToString().Contains(str))
                return true;
            else
                return false;
        }

        public object Clone()
        {
            return new O_PLAY_ACTION_VERSION8() { ActionName = ActionName, Loop = Loop, Interval = Interval, Target = Target.Clone() as TargetParam  };
        }
    }
}
