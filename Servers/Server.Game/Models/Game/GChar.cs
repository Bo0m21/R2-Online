using Database.DataModel.Enums;
using Database.DataModel.Models;
using Packets.Server.Game.Structures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Game.Models.Game
{
    public class GChar : GObject
    {
        public GChar()
        {
            Detail = new GPcDetail();
            Ability = new GPcAbility();
            Simple = new GPcSimple();
            //ParmMon = new ParmMonster();
            //ParmMonCur = new ParmMonster();
        }
        public float _DistAttack { get; set; }

        public GItem Weapon { get; set; }
        public GPcDetail Detail { get; set; }
        public GPcAbility Ability { get; set; }
        public GPcSimple Simple { get; set; }
        public ParmMonster ParmMon { get; set; }
        public ParmMonster ParmMonCur { get; set; }
        public UniqueId TargetUniqueId { get; set; }
        //public UniqueId MainAttacker { get; set; }
        //public UniqueId LastAttacker { get; set; }
        //public UniqueId _FoundItem { get; set; }
        public Vector3 _PosTo { get; set; }
        public Vector3 _PosToLast { get; set; }
        public Vector3 _PosToStep { get; set; }
        public float DirectionSight { get; set; }


        public MonsterSpot _Spot { get; set; }
        public MonsterSpotGroup _SpotGroup { get; set; }

        public bool IsVsibleFirst { get; set; }
        public DateTime LastUpdateHpMp { get; set; }
        public DateTime? DeadTime { get; set; }

        public short AttackRate { get; set; }
        public float MoveRate { get; set; }

        public short AddTransformAttackRate { get; set; }
        public short AddTransformMoveRate { get; set; }

        public uint _CastingDelay { get; set; }


        public bool CantDie { get; set; }
        public byte FssActCalledCnt { get; set; }
        public byte TargetMoveCnt { get; set; }
        public byte IAD { get; set; }
        public short IRD { get; set; }
        public short TotDamageToTarget { get; set; }
        public short TotDamageFromMain { get; set; }
        public short TotDamageFromOther { get; set; }
        public short AddHp { get; set; }
        public short AddMp { get; set; }
        public short AddRegenHp { get; set; }
        public short AddRegenMp { get; set; }
        public short AddStr { get; set; }
        public short AddDex { get; set; }
        public short AddInt { get; set; }
        public short AddDDV { get; set; }
        public short AddMDV { get; set; }
        public short AddRDV { get; set; }
        public short AddDPV { get; set; }
        public short AddMPV { get; set; }
        public short AddRPV { get; set; }
        public short AddDD { get; set; }
        public short AddHit { get; set; }
        public short AddRDD { get; set; }
        public short AddRHit { get; set; }
        public short AddMDD { get; set; }
        public short AddMHit { get; set; }
        public short AddWeight { get; set; }
        public short AddMoveSpeed { get; set; }
        public short AddAttackSpeed { get; set; }
        public short BaseMoveSpeed { get; set; }
        public short AddHwRegenHp { get; set; }
        public short AddHwRegenMp { get; set; }
        public short _NextDamage { get; set; }
        public short ReduceUseMp { get; set; }
        public short AddReduceUseMp { get; set; }
        public short AddSkillHitRate { get; set; }
        public int _AbNoCriticalHitUp { get; set; }
        public PlaceEnum _HomePlace { get; set; }
        public int AiParam { get; set; }
        public uint _GuildAssNo { get; set; }
        public short _AddCastingDelay { get; set; }
        public uint _SpdAttackPerFire { get; set; }
        public uint TickLastFight { get; set; }
        public uint _TickStxUmZil { get; set; }
        public uint TickLastSkill { get; set; }
        public uint TickLastPotion { get; set; }
        public uint _TickLastSearchRace { get; set; }
        public float _SpdWalkPerSec { get; set; }
        public float _SpdWalkPerFire { get; set; }
        public float _SpdWalkPerFireSq { get; set; }
        public float _SpdRunPerHalfFire { get; set; }
        public float SpdHackMaxDist { get; set; }
        public float SpdHackMovedDist { get; set; }

        public uint AiRaidCndLastTick { get; set; }
        public int WeaponApplyAbnItemNo { get; set; }
        public uint WeaponApplyAbnItemEndTick { get; set; }
        public uint LastLoadingTick { get; set; }

        public uint _AbQFlagThreadId { get; set; }
        public int _BeAttachedAbQFlag { get; set; }
        public bool _IsAbsoluteHit { get; set; }
        public short PowerwordLust { get; set; }
        public short ArmorBreak { get; set; }
        public short DestructionOfInner { get; set; }

        private void Attack(GChar target)
        {

        }

        public void CalcSpeed()
        {
            AttackRate = AddAttackSpeed;
            MoveRate = BaseMoveSpeed + AddMoveSpeed;

            if ((ParmMon.ParmNo == 151 || ParmMon.ParmNo == 952))// ParmItemSmall.IsRange(Weapon.ItemSmall))
                AttackRate += ParmMon.AttackRateOrg;
            else
                AttackRate += Detail.AttackRate;

            if (ParmMon != ParmMonCur)
            {
                AttackRate += AddTransformAttackRate;
                MoveRate += AddTransformMoveRate;
            }

            _SpdAttackPerFire = (uint)(AttackRate / 100);
            _SpdWalkPerSec = (uint)(MoveRate * 0.5);
            _SpdWalkPerFire = (uint)(MoveRate * 0.5);
            _SpdRunPerHalfFire = (uint)(MoveRate * 0.5);
            _SpdWalkPerFireSq = (uint)(MoveRate * 0.5 * (MoveRate * 0.5));
            SpdHackMaxDist = (uint)(MoveRate * 30) + (MoveRate * 7);
        }

        public void CalcAbility()
        {
            Ability.Reset();
            Ability.MaxHp = ParmMon.Hp;
            Ability.MaxMp = ParmMon.Mp;
            Ability.HpRegen = AddRegenHp;
            Ability.MpRegen = AddRegenMp;
            Ability.HwHpRegen = AddHwRegenHp;
            Ability.HwMpRegen = AddHwRegenMp;
  //          v5 = (__int64) & ParmMon._Slain[ParmMon._SlainCnt];
  //          if ((const FnlApp::CParmSlain**)v5 != ParmMon._Slain )
  //{
  //              do
  //                  FnlApp::CPcAbility::ChangeSlain(v1, *ParmMon.Slain++);
  //              while (ParmMon.Slain != (const FnlApp::CParmSlain**)v5 );
  //          }
  //          v6 = this.ParmMon;
  //          v7 = v6._Protect;
  //          v8 = (__int64) & v6._Protect[v6._ProtectCnt];
  //          if ((const FnlApp::CParmProtect**)v8 != v6._Protect )
  //{
  //              do
  //                  FnlApp::CPcAbility::ChangeProtect(v1, *v7++);
  //              while (v7 != (const FnlApp::CParmProtect**)v8 );
  //          }
  //          v9 = this.ParmMon;
  //          v10 = v9._AttributeAdd;
  //          v11 = (__int64) & v9._AttributeAdd[v9._AttributeAddCnt];
  //          if ((const FnlApp::CParmAttribute**)v11 != v9._AttributeAdd )
  //{
  //              do
  //                  FnlApp::CPcAbility::ChangeAttrAdd(v1, *v10++);
  //              while (v10 != (const FnlApp::CParmAttribute**)v11 );
  //          }
  //          v12 = this.ParmMon;
  //          v13 = v12._AttributeResist;
  //          v14 = (__int64) & v12._AttributeResist[v12._AttributeResistCnt];
  //          if ((const FnlApp::CParmAttribute**)v14 != v12._AttributeResist )
  //{
  //              do
  //                  FnlApp::CPcAbility::ChangeAttrResist(v1, *v13++);
  //              while (v13 != (const FnlApp::CParmAttribute**)v14 );
  //          }
  //          v15 = this.ParmMon;
  //          v16 = v15._AbnormalAdd;
  //          v17 = (__int64) & v15._AbnormalAdd[v15._AbnormalAddCnt];
  //          if ((const FnlApp::CParmAbnormalAdd**)v17 != v15._AbnormalAdd )
  //{
  //              do
  //                  FnlApp::CPcAbility::ChangeAbnAdd(v1, *v16++);
  //              while (v16 != (const FnlApp::CParmAbnormalAdd**)v17 );
  //          }
  //          v18 = this.ParmMon;
  //          v19 = v18._AbnormalResist;
  //          v20 = (__int64) & v18._AbnormalResist[v18._AbnormalResistCnt];
  //          if ((const FnlApp::CParmAbnormalResist**)v20 != v18._AbnormalResist )
  //{
  //              do
  //                  FnlApp::CPcAbility::ChangeAbnResist(v1, *v19++);
  //              while (v19 != (const FnlApp::CParmAbnormalResist**)v20 );
  //          }
        }
        public void _SetDefaultInfo(ParmMonster parmMon)
        {
            ParmMon = parmMon;
            ParmMonCur = parmMon;

            //this->_mWeapon = &this->_mWeaponDef;

            AddRegenHp = ParmMon.HpRegen;
            AddRegenMp = ParmMon.MpRegen;

            Transformed(parmMon);
        }

        public void Transformed(ParmMonster parmMonCur)
        {
            ParmMonCur = parmMonCur;

            if (ParmMon.GbjClass == GbjClassEnum.Pc)
                Simple.OldLevel = Simple.Level;

            if (ParmMon == ParmMonCur)
            {
                //FnlApp::CParmItem::SetDefWeapon(&this->_mWeaponDef, v55->__mDistMelee, v55->__mHit, v55->__mMinD, v55->__mMaxD);

                if (ParmMon.GbjClass == GbjClassEnum.Mon)
                {
                    _DistAttack = ParmMonCur.DistMelee;
                }
                else if (ParmMon.GbjClass == GbjClassEnum.Pc)
                {
                    _DistAttack = ParmMonCur.DistMelee;// Weapon.Range;
                }

                BaseMoveSpeed = ParmMonCur.MoveRateOrg;
                Detail.AttackRate = ParmMonCur.AttackRateOrg;
                Detail.MoveRate = ParmMonCur.MoveRateOrg;
            }
            else
            {
                _DistAttack = ParmMonCur.DistMelee;
                //v61 = CParmTransformAbilityMgr::Find(
                //&CParmTransformAbilityMgr::__mSingleton,
                //*(unsigned __int16 *)(v53 + 86744),
                //eTransformNecklace);
                if (ParmMonCur.AttackType == AttackTypeEnum.Long)
                {
                    _DistAttack += Weapon.AddLongAttackRange;
                    //Detail.AttackRate = TransformAbilty.LongAttackRate;
                }
                else
                {
                    _DistAttack += Weapon.AddShortAttackRange;
                    //Detail.AttackRate = TransformAbilty.ShortAttackRate;
                }
                //BaseMoveSpeed = TransformAbilty.MoveRate;
                //Detail.MoveRate = TransformAbilty.MoveRate;
            }

            _DistAttack += ParmMonCur.BodySz;
            _CastingDelay = (uint)ParmMonCur.CastingDelay / 100;

            CalcSpeed();
        }

        private void _CalcWaponDamage(GChar target)
        {

        }
        #region TODO
        //FnlApi::CFlag<134217729, unsigned long> Flag { get; set; }
        //public byte FssActSeq { get; set; }
        //public const FnlApp::CParmAbnormal* TransParm { get; set; }
        //public const CParmAi* ParmAi { get; set; }
        //public const CFss* FssAct { get; set; }
        //public FnlApi::CArrayEx<FnlApi::C2D<float>, 12> _NaviPath { get; set; }
        //public FnlApi::CArrayEx<CModInflame, 193> ModInf { get; set; }
        //public FnlApi::CArrayEx<CAbInflame, 373> AbInf { get; set; }
        //public FnlApp::CParmItem WeaponDef { get; set; }
        //public CAiRaidInfo AiRaidInfo { get; set; }
        //public std::set<SAiRaidCndKey> AiRaidCndKey { get; set; }
        //public EMaxMemPerPartyCntLevel PartyMemCntLevel { get; set; }
        //public FnlApi::CArrayCircular<SAttachDetachAbArgs> _BeAttachedAbQ { get; set; }
        //public std::map<short, SSkillDelayInfo> _UsingCastingDelay { get; set; }
        //public std::map<short, SSkillDelayInfo> _UsingCoolTimeDelay { get; set; }
        //public const FnlApp::CParmAbnormal* _ReflectAb { get; set; }
        //public FnlApp::CParmSlain SlainModifier { get; set; }
        //public FnlApp::CParmProtect ProtectModifier { get; set; }
        //public int ReduceCycleDamage { get; set; }
        //public int InstDamageModAttack { get; set; }
        //public int InstDamageModDefense { get; set; }
        //public FnlApi::CArrayEx<FnlApp::CParmSlain const*, 14> _AddSlain { get; set; }
        //public FnlApi::CArrayEx<FnlApp::CParmProtect const*, 14> _AddProtect { get; set; }
        #endregion
    }
}
