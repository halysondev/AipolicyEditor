﻿using AipolicyEditor.AIPolicy.Operations.CustomEditors;
using System;
using System.ComponentModel;
using System.IO;
using WPFLocalizeExtension.Extensions;

namespace AipolicyEditor.AIPolicy.Operations
{
    public class O_CHANGE_MONSTER_ACTIVE_PASSIVE : IOperation, ICloneable
    {
        [Browsable(false)]
        public int FromVersion => 30;
        [Browsable(false)]
        public int OperID => 57;
        [Browsable(false)]
        public string Name => MainWindow.Provider.GetLocalizedString("o57");

        //Trigger param
        [LocalizedCategory("OperationParam")]
        [LocalizedDisplayName("iChoose")]
        public int iChoose { get; set; }

        // Target param
        [LocalizedCategory("TargetParam")]
        [LocalizedDisplayName("Target")]
        public TargetParam Target { get; set; }

        public O_CHANGE_MONSTER_ACTIVE_PASSIVE()
        {
            iChoose = 0;
            Target = new TargetParam();
        }

        public void Read(BinaryReader br)
        {
            iChoose = br.ReadInt32();
            Target = TargetStream.Read(br);
        }

        public void Write(BinaryWriter bw)
        {
            bw.Write(iChoose);
            TargetStream.Save(bw, Target);
        }

        public bool Search(string str)
        {
            if (iChoose.ToString().Contains(str))
                return true;
            else
                return false;
        }

        public object Clone()
        {
            return new O_CHANGE_MONSTER_ACTIVE_PASSIVE() { iChoose = iChoose, Target = Target.Clone() as TargetParam  };
        }
    }
}
