﻿using AipolicyEditor.AIPolicy.Operations.CustomEditors;
using System;
using System.ComponentModel;
using System.IO;
using WPFLocalizeExtension.Extensions;

namespace AipolicyEditor.AIPolicy.Operations
{
    public class O_GET_POS_NUM : IOperation, ICloneable
    {
        [Browsable(false)]
        public int FromVersion => 24;
        [Browsable(false)]
        public int OperID => 39;
        [Browsable(false)]
        public string Name => MainWindow.Provider.GetLocalizedString("o39");

        //Trigger param
        [LocalizedCategory("OperationParam")]
        [LocalizedDisplayName("uNum")]
        public int uNum { get; set; }
        [LocalizedCategory("OperationParam")]
        [LocalizedDisplayName("uuNumType")]
        public uint uuNumType { get; set; }
        [LocalizedCategory("OperationParam")]
        [LocalizedDisplayName("pos")]
        public uint pos { get; set; }
        [LocalizedCategory("OperationParam")]
        [LocalizedDisplayName("posType")]
        public uint posType { get; set; }

        [LocalizedCategory("OperationParam")]
        [LocalizedDisplayName("varID")]
        public uint varID { get; set; }

        [LocalizedCategory("OperationParam")]
        [LocalizedDisplayName("varType")]
        public uint varType { get; set; }

        // Target param
        [LocalizedCategory("TargetParam")]
        [LocalizedDisplayName("Target")]
        public TargetParam Target { get; set; }

        public O_GET_POS_NUM()
        {
            uNum = 0;
            uuNumType = 0;
            pos = 0;
            posType = 0;
            varID = 0;
            varType = 0;
            Target = new TargetParam();
        }

        public void Read(BinaryReader br)
        {
            uNum = br.ReadInt32();
            uuNumType = br.ReadUInt32();
            pos = br.ReadUInt32();
            posType = br.ReadUInt32();
            varID = br.ReadUInt32();
            varType = br.ReadUInt32();
            Target = TargetStream.Read(br);
        }

        public void Write(BinaryWriter bw)
        {
            bw.Write(uNum);
            bw.Write(uuNumType);
            bw.Write(pos);
            bw.Write(posType);
            bw.Write(varID);
            bw.Write(varType);
            TargetStream.Save(bw, Target);
        }

        public bool Search(string str)
        {
            if (uNum.ToString().Contains(str) || uuNumType.ToString().Contains(str) ||
                pos.ToString().Contains(str) || posType.ToString().Contains(str) ||
                varID.ToString().Contains(str) || varType.ToString().Contains(str))
                return true;
            else
                return false;
        }

        public object Clone()
        {
            return new O_GET_POS_NUM() { uNum = uNum, uuNumType = uuNumType, pos = pos, posType = posType, varID = varID, varType = varType, Target = Target.Clone() as TargetParam };
        }
    }
}