using AipolicyEditor.AIPolicy.Operations.CustomEditors;
using System.Collections.Generic;
using System.IO;

namespace AipolicyEditor.AIPolicy
{
    public static class TargetStream
    {
        public static TargetParam Read(BinaryReader br)
        {
            EnumTarget enumTarget = (EnumTarget)br.ReadUInt32();
            uint occupations = 0u;
            uint players = 0u;
            uint unk2 = 0u;
            uint unk3 = 0u;
            uint unk4 = 0u;
            if (enumTarget == EnumTarget.occupation_list)
            {
                occupations = br.ReadUInt32();
            }
            if (enumTarget == EnumTarget.t_random_in_range)
            {
                players = br.ReadUInt32();
            }
            if (enumTarget == EnumTarget.t_nearest_in_range)
            {
                players = br.ReadUInt32();
            }
            if (enumTarget == EnumTarget.t_farthest_in_range)
            {
                players = br.ReadUInt32();
            }
            if (enumTarget == EnumTarget.unk_18)
            {
                players = br.ReadUInt32();
                unk2 = br.ReadUInt32();
                unk3 = br.ReadUInt32();
            }
            if (enumTarget == EnumTarget.unk_20)
            {
                players = br.ReadUInt32();
                unk2 = br.ReadUInt32();
                unk3 = br.ReadUInt32();
                unk4 = br.ReadUInt32();
            }
            return new TargetParam
            {
                Target = enumTarget,
                Occupations = occupations,
                Players = players,
                Unk2 = unk2,
                Unk3 = unk3,
                Unk4 = unk4
            };
        }

        public static void Save(BinaryWriter bw, TargetParam param)
        {
            bw.Write((uint)param.Target);
            if (param.Target == EnumTarget.occupation_list)
            {
                bw.Write(param.Occupations);
            }
            if (param.Target == EnumTarget.t_random_in_range)
            {
                bw.Write(param.Players);
            }
            if (param.Target == EnumTarget.t_nearest_in_range)
            {
                bw.Write(param.Players);
            }
            if (param.Target == EnumTarget.t_farthest_in_range)
            {
                bw.Write(param.Players);
            }
            if (param.Target == EnumTarget.unk_18)
            {
                bw.Write(param.Players);
                bw.Write(param.Unk2);
                bw.Write(param.Unk3);
            }
            if (param.Target == EnumTarget.unk_20)
            {
                bw.Write(param.Players);
                bw.Write(param.Unk2);
                bw.Write(param.Unk3);
                bw.Write(param.Unk4);
            }
        }

        public static List<string> GetTargetList()
        {
            var list = new List<string>();
            EnumTarget count = EnumTarget.t_num;
            for (int i = 0; i < (int)count; ++i)
                list.Add(count.ToString());
            return list;
        }
    }

    public enum EnumTarget : uint
    {
        hate_first, //0
        hate_second, //1
        hate_others, //2
        most_hp, //3
        most_mp, //4
        least_hp, //5
        occupation_list, //6
        self, //7
        monster_killer, //8
        monster_birthplace_faction, //9
        hate_random_one, //10
        hate_nearest, //11
        hate_farthest, //12
        hate_first_redirected, //13
        t_random_in_range, //14
        t_nearest_in_range, //15
        t_farthest_in_range, //16
        unk_17,
        unk_18,
        unk_19,
        unk_20,
        t_num
    };
}
