using System;

namespace AipolicyEditor.AIPolicy.Operations.CustomEditors
{
    public class SkillID
    {
        public uint Value { get; set; }

        public SkillID()
        {
            Value = 0;
        }
    }

    public class NpcID
    {
        public uint Value { get; set; }

        public NpcID()
        {
            Value = 0;
        }
    }

    public class MobID
    {
        public uint Value { get; set; }

        public MobID()
        {
            Value = 0;
        }
    }

    public class MineID
    {
        public uint Value { get; set; }

        public MineID()
        {
            Value = 0;
        }
    }

    public class TargetParam : ICloneable
    {
        public EnumTarget Target { get; set; }
        public uint Occupations { get; set; }

        public uint Players { get; set; }

        public uint Unk2 { get; set; }

        public uint Unk3 { get; set; }

        public uint Unk4 { get; set; }

        public TargetParam()
        {
            Target = EnumTarget.hate_first;
            Occupations = 0;
            Players = 0u;
            Unk2 = 0u;
            Unk3 = 0u;
            Unk4 = 0u;
        }

        public object Clone()
        {
            return new TargetParam() { Target = Target, Occupations = Occupations, Players = Players };
        }
    }
}
