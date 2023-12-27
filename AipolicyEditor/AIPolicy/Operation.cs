using System;
using System.IO;
using System.Text;
using AipolicyEditor.AIPolicy.Operations;
using System.Windows;

namespace AipolicyEditor.AIPolicy
{
    public static class Operation
    {
        public static IOperation Read(BinaryReader br, int version, int id)
        {
            IOperation op = null;
            switch (id)
            {
                case 0:
                    op = new O_ATTACK_TYPE();
                    break;
                case 1:
                    op = new O_USE_SKILL();
                    break;
                case 2:
                    if (version > 16)
                    {
                        op = new O_TALK_TEXT();
                    }
                    else
                    {
                        op = new O_TALK_TEXT_OLD();
                    }
                    break;
                case 3:
                    op = new O_RESET_HATE_LIST();
                    break;
                case 4:
                    op = new O_RUN_TRIGGER();
                    break;
                case 5:
                    op = new O_STOP_TRIGGER();
                    break;
                case 6:
                    op = new O_ACTIVE_TRIGGER();
                    break;
                case 7:
                    op = new O_CREATE_TIMER();
                    break;
                case 8:
                    op = new O_KILL_TIMER();
                    break;
                case 9:
                    op = new O_FLEE();
                    break;
                case 10:
                    op = new O_SET_HATE_TO_FIRST();
                    break;
                case 11:
                    op = new O_SET_HATE_TO_LAST();
                    break;
                case 12:
                    op = new O_SET_HATE_FIFTY_PERCENT();
                    break;
                case 13:
                    op = new O_SKIP_OPERATION();
                    break;
                case 14:
                    op = new O_ACTIVE_CONTROLLER();
                    break;
                case 15:
                    if (version > 3)
                    {
                        op = new O_SET_GLOBAL();
                    }
                    else
                    {
                        op = new O_SET_GLOBAL_VERSION3();
                    }
                    break;
                case 16:
                    op = new O_REVISE_GLOBAL();
                    break;
                case 17:
                    if (version > 6)
                    {
                        op = new O_SUMMON_MONSTER();
                    }
                    else
                    {
                        op = new O_SUMMON_MONSTER_VERSION6();
                    }
                    break;
                case 18:
                    op = new O_WALK_ALONG();
                    break;
                case 19:
                    if (version <= 8)
                    {
                        op = new O_PLAY_ACTION_VERSION8();
                    }
                    else if(version <= 38)
                    {
                        op = new O_PLAY_ACTION();
                    }
                    else
                    {
                        op = new O_PLAY_ACTION_VERSION40();
                    }
                    //op = ((version <= 8) ? new O_PLAY_ACTION_VERSION8() : ((version <= 39) ? ((IOperation)new O_PLAY_ACTION()) : ((IOperation)new O_PLAY_ACTION_VERSION40())));
                    break;
                case 20:
                    op = new O_REVISE_HISTORY();
                    break;
                case 21:
                    op = new O_SET_HISTORY();
                    break;
                case 22:
                    op = new O_DELIVER_FACTION_PVP_POINTS();
                    break;
                case 23:
                    op = new O_CALC_VAR();
                    break;
                case 24:
                    op = new O_SUMMON_MONSTER_2();
                    break;
                case 25:
                    op = new O_WALK_ALONG_2();
                    break;
                case 26:
                    op = new O_USE_SKILL_2();
                    break;
                case 27:
                    op = new O_ACTIVE_CONTROLLER_2();
                    break;
                case 28:
                    op = new O_DELIVER_TASK();
                    break;
                case 29:
                    if(version > 23)
                    {
                        op = new O_SUMMON_MINE();
                    }
                    else
                    {
                        op = new O_SUMMON_MINE_VERSION23();
                    }
                    //op = ((version <= 23) ? ((IOperation)new O_SUMMON_MINE_VERSION23()) : ((IOperation)new O_SUMMON_MINE()));
                    break;
                case 30:
                    op = new O_SUMMON_NPC();
                    break;
                case 31:
                    op = new O_DELIVER_RANDOM_TASK_IN_REGION();
                    break;
                case 32:
                    op = new O_DELIVER_TASK_IN_HATE_LIST();
                    break;
                case 33:
                    op = new O_CLEAR_TOWER_TASK_IN_REGION();
                    break;
                case 34:
                    op = new O_SAVE_PLAYER_COUNT_IN_RADIUS_TO_PARAM();
                    break;
                case 35:
                    op = new O_SAVE_PLAYER_COUNT_IN_REGION_TO_PARAM();
                    break;
                //156
                case 36: 
                    op = new O_SKILL_WITH_TALK();
                    break;          
                case 37:
                    op = new O_USE_SKILL_3();
                    break;
                case 38:
                    op = new O_SORT_NUM();
                    break;
                case 39:
                    op = new O_GET_POS_NUM();
                    break;
                case 40:
                    op = new O_AUTO_BIND_CARRIER();
                    break;
                case 41:
                    op = new O_ADD_RANGE_TO_HATE_LIST();
                    break;
                case 42:
                    op = new O_SAVE_ALIVE_PLAYER_COUNT_IN_RADIUS_TO_PARAM();
                    break;
                case 43:
                    op = new O_SAVE_ALIVE_PLAYER_COUNT_IN_REGION_TO_PARAM();
                    break;
                case 44:
                    op = new O_WALK_ALONG_3();
                    break;
                case 45:
                    op = new O_WALK_ALONG_4();
                    break;
                case 46:
                    op = new O_SAVE_TIME();
                    break;
                case 47:
                    op = new O_RANDOM_ASSIGNMENT();
                    break;
                case 48:
                    op = new O_CARRIER_VOTING();
                    break;
                case 49:
                    op = new O_VOTING_RESULT();
                    break;
                case 50:
                    op = new O_VOTING_SHOW();
                    break;
                case 51:
                    op = new O_CARRIER_DELIVERY_TASK();
                    break;
                case 52:
                    op = new O_CARRIER_NOENTRY();
                    break;
                case 53:
                    op = new O_TALK_TEXT_2();
                    break;
                case 54:
                    op = new O_CREATE_TIMER_2();
                    break;
                case 55:
                    op = new O_KILL_TIMER_2();
                    break;
                case 56:
                    op = new O_CHANGE_MONSTER_FIGHTING_STATE();
                    break;
                case 57:
                    op = new O_CHANGE_MONSTER_ACTIVE_PASSIVE();
                    break;
                //157
                case 58:
                    op = new O_CHILD_CARRIER_PARENT_MONSTER();
                    break;
                case 59:
                    op = new O_CLOSE_CHILD_MONSTER();
                    break;
                case 60:
                    op = new O_DELIVER_HATE_TARGETS();
                    break;
                //157+
                case 61:
                    op = new O_CHANGE_MONSTER_ATTACK_POLICY();
                    break;
                case 62:
                    op = new O_SPECIFY_FAILED_TASK_ID();
                    break;
                case 63:
                    op = new O_SPECIFY_FAILED_TASK_ID_REGIONAL();
                    break;
                //159
               case 64:
                    op = new O_64();
                    break;
                case 65:
                   op = new O_65();
                   break;
                case 66:
                    op = new O_66();
                    break;
                case 67:
                    op = new O_67();
                    break;
                case 68:
                    op = new O_68();
                    break;
                case 69:
                    op = new O_69();
                    break;
                case 70:
                    op = new O_70();
                    break;
                case 71:
                    op = new O_71();
                    break;
                case 72:
                    op = new O_72();
                    break;
                //162
                case 73:
                    op = new O_73();
                    break;
                case 74:
                    op = new O_74();
                    break;
                case 75:
                    op = new O_75();
                    break;
                case 76:
                    op = new O_76();
                    break;
                case 77:
                    op = new O_77();
                    break;
                case 78:
                    op = new O_78();
                    break;
                case 79:
                    op = new O_79();
                    break;
                //166
                case 80:
                    op = new O_80();
                    break;
                case 81:
                    op = new O_81();
                    break;
                case 82:
                    op = new O_82();
                    break;
                case 83:
                    op = new O_83();
                    break;
                case 84:
                    op = new O_84();
                    break;
                case 85:
                    op = new O_85();
                    break;
                case 86:
                    op = new O_86();
                    break;
                case 87:
                    op = new O_87();
                    break;
                case 88:
                    op = new O_88();
                    break;
                case 89:
                    op = new O_89();
                    break;
                //170
                case 90:
                    op = new O_90();
                    break;
                case 91:
                    op = new O_91();
                    break;
                case 92:
                    op = new O_92();
                    break;
                case 93:
                    op = new O_93();
                    break;
                case 94:
                    op = new O_94();
                    break;
                case 95:
                    op = new O_95();
                    break;
                case 96:
                    op = new O_96();
                    break;
                case 97:
                    op = new O_97();
                    break;
                case 98:
                    op = new O_98();
                    break;
                case 99:
                    op = new O_99();
                    break;
                //172
                case 100:
                    op = new O_100();
                    break;
                case 101:
                    op = new O_101();
                    break;
                case 102:
                    op = new O_102();
                    break;
                case 103:
                    op = new O_103();
                    break;
                case 104:
                    op = new O_104();
                    break;
                //174
                case 105:
                    op = new O_105();
                    break;
                //176
                case 106:
                    op = new O_106();
                    break;
                
                default:
                    MessageBox.Show($"Unknown operation id {id} at pos {br.BaseStream.Position}");
                    break;
            }
            if (br != null)
                op?.Read(br);
            return op;
        }
    }
}
