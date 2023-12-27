using System;
using System.IO;

namespace AipolicyEditor.AIPolicy
{
    public class Condition : ICloneable
    {
        public int ID { get; set; }
        public object[] Value { get; set; }
        public int Type { get; set; }
        public Condition ConditionLeft;
        public int SubNodeL { get; set; }
        public Condition ConditionRight;
        public int SubNodeR { get; set; }

        public Condition()
        {
            ID = 2;
            Value = new object[0];
            Type = 3;
        }

        public void Read(BinaryReader br)
        {
            ID = br.ReadInt32();
            Value = Conditions.Conditions.Read(br.ReadBytes(br.ReadInt32()), ID);
            Type = br.ReadInt32();
            if (Type == 1)
            {
                ConditionLeft = new Condition();
                ConditionLeft.Read(br);
                SubNodeL = br.ReadInt32();
                ConditionRight = new Condition();
                ConditionRight.Read(br);
                SubNodeR = br.ReadInt32();
            }
            if (Type == 2)
            {
                ConditionRight = new Condition();
                ConditionRight.Read(br);
                SubNodeL = br.ReadInt32();
            }
        }

        public void Save(BinaryWriter bw)
        {
            bw.Write(ID);
            byte[] value = Conditions.Conditions.Write(Value, ID);
            bw.Write(value.Length);
            bw.Write(value);
            bw.Write(Type);
            if (Type == 1)
            {
                ConditionLeft.Save(bw);
                bw.Write(SubNodeL);
                ConditionRight.Save(bw);
                bw.Write(SubNodeR);
            }
            if (Type == 2)
            {
                ConditionRight.Save(bw);
                bw.Write(SubNodeL);
            }
        }

        public object Clone()
        {
            var data = new Condition() { ID = ID, SubNodeL = SubNodeL, SubNodeR = SubNodeR, Type = Type, Value = Value.Clone() as object[] };
            if (ConditionLeft != null)
                data.ConditionLeft = ConditionLeft.Clone() as Condition;
            if (ConditionRight != null)
                data.ConditionRight = ConditionRight.Clone() as Condition;
            return data;
        }
    }
}
