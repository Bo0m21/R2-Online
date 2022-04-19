using Database.DataModel.Enums;
using Database.DataModel.Models;
using Packets.Server.Game.Structures;
using Server.Game.Network;
using System;
using System.Collections.Generic;

namespace Server.Game.Models.Game
{
    public class GMonster : GChar
    {
        public GMonster()
        {
            VisibleCharacterGames = new List<GameSession>();
            VisibleItemGames = new List<GPublicItem>();
            VisibleUnitGames = new List<GMonster>();
        }

        public List<GDropGroup> DropGroup { get; set; }
        //FnlApi::CArrayEx<FnlApp::CGoods,10> __mStomach;
        //FnlApi::CArrayEx<CAgroHistory,4> __mAgroList;
        //FnlApi::CFlag<9, unsigned char> __mMonFlag;
        //unsigned int __mTickLastDie;

        public short Hp { get; set; }
        public short Mp { get; set; }
        public int Respawn { get; set; }
        public Vector3 PositionDefault { get; set; }
        public float DirectionSightDefault { get; set; }

        public List<GameSession> VisibleCharacterGames { get; set; }
        public List<GPublicItem> VisibleItemGames { get; set; }
        public List<GMonster> VisibleUnitGames { get; set; }

        public new void CalcAbility()
        {
            base.CalcAbility();

            Ability.DDv = Detail.DDv;
            Ability.MDv = Detail.MDv;
            Ability.DDD = 0;
            Ability.RDv = Detail.RDv;
            Ability.MPv = Detail.MPv;
            Ability.RPv = Detail.RPv;
            Ability.DHit = Detail.Hit;
            Ability.DPv = (short)(AddDPV + Detail.DPv);
        }

        public new void _SetDefaultInfo(ParmMonster parmMon)
        {
            base._SetDefaultInfo(parmMon);

            DeadTime = null;

            Simple = new GPcSimple()
            {
                Class = ParmMon.Class,
                Hp = ParmMon.Hp,
                Mp = ParmMon.Mp,
                Exp = ParmMon.Exp,
                NickName = ParmMon.Nm
            };

            Simple.SetStomach(70);

            Detail.DDv = ParmMon.DDv;
            Detail.RDv = ParmMon.RDv;
            Detail.MDv = ParmMon.MDv;

            Detail.DPv = ParmMon.DPv;
            Detail.RPv = ParmMon.RPv;
            Detail.MPv = ParmMon.MPv;

            Detail.Hit = 0;
            Detail.MinD = ParmMon.MinD;
            Detail.MaxD = ParmMon.MaxD;

            Transformed(parmMon);
        }
    }
}
