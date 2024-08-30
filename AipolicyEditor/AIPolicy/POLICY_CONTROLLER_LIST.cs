using AipolicyEditor.AIPolicy.Operations;
using AipolicyEditor.AIPolicy.Operations.CustomEditors;
using System;
using System.ComponentModel;
using System.IO;

namespace AipolicyEditor.AIPolicy
{
    public class POLICY_CONTROLLER_LIST
    {
        [LocalizedDisplayName("uID")]
        [LocalizedCategory("ControllersParam")]
        public int uID { get; set; }
        [LocalizedDisplayName("uIDType")]
        [LocalizedCategory("ControllersParam")]
        public VarType uIDType { get; set; }

        public override string ToString()
        {
            return $"ID: {uID}, Tipo de ID: {uIDType}";
        }

        /*public POLICY_CONTROLLER_LIST() 
        {
        }*/
        public static POLICY_CONTROLLER_LIST Read(BinaryReader br)
        {
            return new POLICY_CONTROLLER_LIST
            {
                uID = br.ReadInt32(),
                uIDType = (VarType)br.ReadInt32()
            };
        }

        public POLICY_CONTROLLER_LIST Copy()
        {
            return new POLICY_CONTROLLER_LIST
            {
                uID = uID,
                uIDType = uIDType
            };
        }

        public static void Write(BinaryWriter bw, POLICY_CONTROLLER_LIST param)
        {
            bw.Write(param.uID);
            bw.Write(Convert.ToUInt32(param.uIDType));
        }
    }
}
