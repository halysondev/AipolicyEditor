using AipolicyEditor.AIPolicy.Operations.CustomEditors;
using System;
using System.ComponentModel;
using System.IO;
using WPFLocalizeExtension.Extensions;

namespace AipolicyEditor.AIPolicy.Operations
{
    public class O_PLAY_ACTION : IOperation, ICloneable
    {
        [Browsable(false)]
        public int FromVersion => 9;
        [Browsable(false)]
        public int OperID => 19;
        [Browsable(false)]
        public string Name => MainWindow.Provider.GetLocalizedString("o19");

        //Trigger param
        [LocalizedCategory("OperationParam")]
        [LocalizedDisplayName("ActionName")]
        public string ActionName { get; set; }
        [LocalizedCategory("OperationParam")]
        [LocalizedDisplayName("LoopCount")]
        public int LoopCount { get; set; }
        [LocalizedCategory("OperationParam")]
        [LocalizedDisplayName("Interval")]
        public int Interval { get; set; }
        [LocalizedCategory("OperationParam")]
        [LocalizedDisplayName("PlayTime")]
        public int PlayTime { get; set; }
        // Target param
        [LocalizedCategory("TargetParam")]
        [LocalizedDisplayName("Target")]
        public TargetParam Target { get; set; }

        public O_PLAY_ACTION()
        {
            ActionName = "";
            LoopCount = 0;
            Interval = 0;
            PlayTime = 0;
            Target = new TargetParam();
        }

        public void Read(BinaryReader br)
        {
            ActionName = br.ReadBytes(128).ToGBK();
            LoopCount = br.ReadInt32();
            Interval = br.ReadInt32();
            PlayTime = br.ReadInt32();
            Target = TargetStream.Read(br);
        }

        public void Write(BinaryWriter bw)
        {
            bw.Write(ActionName.FromGBK(128));
            bw.Write(LoopCount);
            bw.Write(Interval);
            bw.Write(PlayTime);
            TargetStream.Save(bw, Target);
        }

        public bool Search(string str)
        {
            if (ActionName.Contains(str) || LoopCount.ToString().Contains(str) || Interval.ToString().Contains(str) || PlayTime.ToString().Contains(str))
                return true;
            else
                return false;
        }

        public object Clone()
        {
            return new O_PLAY_ACTION() { ActionName = ActionName, LoopCount = LoopCount, Interval = Interval, PlayTime = PlayTime, Target = Target.Clone() as TargetParam  };
        }
    }
}
