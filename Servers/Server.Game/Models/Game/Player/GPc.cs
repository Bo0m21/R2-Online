using Database.DataModel.Enums;
using Database.Game.Models;
using Packets.Server.Game.Structures;
using Server.Game.Network;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Server.Game.Models.Game
{
    /// <summary>
    ///     Character game model
    /// </summary>
    public class GPc : GChar
    {
        public GPc()
            : base()
        {
            //Items = new List<ItemGameModel>();
            //Buffs = new List<BuffGameModel>();
            VisibleCharacterGames = new List<GameSession>();
            VisibleItemGames = new List<GPublicItem>();
            VisibleUnitGames = new List<GMonster>();
            Equip = new List<GPcEquip>();
            Inventory = new GPcInventory();
        }
        public List<GPcEquip> Equip { get; set; }
        public GPcInventory Inventory { get; set; }

        //public AttackTypeEnum AttackTarget { get; set; }
        public ushort AttackType { get; set; }
        public Vector3 AttackPosition { get; set; }
        public byte AttackFlag { get; set; }
        public bool checkAttack { get; set; }
        public DateTime AttackDateTime { get; set; }

        #region Etc
        public uint Action;
        public uint PartyNo;
        public uint LogoutTick;
        public uint TickEndBoa;
        public uint TickEndBoaEx;
        public uint SpdHackTick;
        public uint UserNo;
        public uint BlockChat;
        public uint BlockBoard;
        public byte PcBangLv;
        public uint ChatCnt;
        public uint ChatTick;
        public int NeedMoneyNo;
        public uint SpecialEffectTime;
        public short AddHidDDv;
        public short AddHidMDv;
        public short AddHidRDv;
        public short AddHidDPv;
        public short AddHidMPv;
        public short AddHidRPv;
        public short AddCriticalHit;
        public uint mSecurityTick;
        public uint BlockChatTime;
        public char PlusCode;
        public byte UseMacroTimes;
        public uint MacroTick;
        public int PreventAddictionPlayTm;
        public short IncExp;
        public short IncDropRate;
        public short AddPotionRestore;
        public short AddTransformMaxHP;
        public short AddTransformMaxMP;
        public uint TickLetterLimit;
        public int NewId;
        public short SkillHp;
        public byte TeamBattle;
        public bool IsCheckTeam;
        public bool PreventItemDrop;
        public ulong VisitTicketSerial;
        public short ReduceDmgPer;
        public short ReflectDmg;
        public short RestoreHpFromReduceDmg;
        public short HonorPtrProtect;
        public short HonorPtrAmp;
        public int TermOfVolitionOfHonor;
        public byte TotemDamage;
        public uint Freeze;
        public int IsQuestInit;
        public byte UserItemDrop;
        public byte UserAddPKDrop;
        public uint AddTransformTm;
        public short AddDDWhenCritical;
        public short InstAddMaxHP;
        public short InstAddDDD;
        public bool RecallToAgit;
        public short SubDescChaoticPercent;
        public short AddIncrChaoticPercent;
        public int PcBangGUID;
        public int AccountGUID;
        public uint LoginTick;
        public uint EmoticonTick;
        public short SubDDWhenCritical;
        public short EnemySubCriticalHit;
        public uint LootingTick;
        public int IsDialogEditMode;
        public int IsUseReturnNoItem;
        public int IsAutoStomach;
        public uint AutoLootingCnt;
        public int BeginHp;
        public int BeginMp;
        public short EventDungeonSerialNo;
        public int IsFreeFall;
        public int IsTeleportCenterTownRegistBullet;
        public uint __aServerTickAcummulate;
        public int Bomber;
        public uint CheckValidTime;
        public uint TeamRankNo;
        public uint mTeamRankGuildNo;
        public int IsCalendarReLoad;
        public bool IsLimitTimeInit;
        public bool IsARSAuth;
        public bool IsInValidHeightLog;
        public int IsUpdateLimitTime;
        public int ServantTotalAbility;
        public short PainKiller;
        public int IsPainKiller;
        public uint UmZilAttackTick;
        public int IsRegArena;
        public int IsBossBattleDead;
        public byte FierceBattleKillCnt;
        public int ArenaPanalty;
        //public long RestExp[3];
        //public long RestExpMax[2];

        //char UserId[21];
        //char CRMCode[17];
        //char JoinCode[2];
        //char BillNo[21];
        //int LimitPlayTime[2];
        //char mTeamRankGuildNm[17];
        #endregion

        #region Default fields
        //public List<GItem> Items { get; set; }
        //public List<GBuff> Buffs { get; set; }
        #endregion

        #region General fields
        /// <summary>
        ///     Unique identifier
        /// </summary>

        /// <summary>
        ///     Attacked unique identifier
        /// </summary>
        public UniqueId AttackedUniqueIdentifier { get; set; }
        #endregion

        #region Visible fields
        /// <summary>
        ///     Visible character game
        /// </summary>
        public List<GameSession> VisibleCharacterGames { get; set; }

        /// <summary>
        ///     Visible item game
        /// </summary>
        public List<GPublicItem> VisibleItemGames { get; set; }

        /// <summary>
        ///     Visible unit game
        /// </summary>
        public List<GMonster> VisibleUnitGames { get; set; }
        #endregion

        #region TODO
        //CPersonalShop MyPShop;
        //wchar_t MacroStr[11];
        //ENeedMoney NeedMoney;
        //FnlApp::CInvenObj Inven;
        //FnlApp::CPcEquip Equip;
        //FnlApi::CArrayEx<CAgroHistory,4> AgroList;
        //FnlApp::CPcTeleport Teleport;
        //CExchange Exchange;
        //std::multimap<unsigned long,CFriend> Friend;
        //std::multimap<unsigned long,CChatFilter> ChatFilter;
        //CScriptObj Script;
        //FnlApp::CVector SpdHackPos;
        //CAdminInfo AdminInfo;
        //FnlApi::CTime NeedMoneyEndOrStxTm;
        //CPc::<unnamed_type_NeedMoneyInfo> NeedMoneyInfo;
        //ESpecialEffectLevel SpecialEffectLevel;
        //ESpecialEffectType SpecialEffectType;
        //CCSAuth2 mSecurityInfo;
        //FnlApi::CLocker mLockerScript;
        //std::map<unsigned short,unsigned long> mTrProcTickList;
        //FnlApi::CTime LoginTime;
        //FnlFw::CUnique MacroAdmin;
        //EAddictionState PreventAddictionState;
        //SGoldItemEffectStatus ChargeItemInfo[16];
        //FnlApp::CPcSetItemEquip SetEquip;
        //FnlApi::CFlag<257,unsigned short> PcFlag;
        //FnlApp::CVector TeamBattleEnterPos;
        //FnlApp::CPcSummon Summons;
        //SChaosRankingPoint RankingPoint;
        //FnlApi::CHashMap<int,FnlApi::CHashMap<int,unsigned char> > CAbCntMap;
        //FnlFw::CUnique OreadTotem;
        //CSpdHackChecker SpdHackChk;
        //FnlApi::CArrayCircular<FnlFw::CBullet> SerializeQueue;
        //FnlApi::CAuthAcquire SerializeQueueAcquire;
        //FnlFw::CUnique TalkingNpc;
        //FnlApp::EUTGWMatchGroup UTGWGroupInfo;
        //FnlApp::CPrivateSerialGenerator SerialGenerator;
        //CSkillTreeInven SkillTreeInven;
        //CSkillPackInven SkillPackInven;
        //CPassiveAbInflame PassiveAbInflame;
        //CSkillParmModifier SkillParmModifier;
        //CPcAbilityModifier PcAbilityModifier;
        //EAccountingType AccountingType;
        //CCnsmInfo CnsmInfo;
        //FnlApp::CBeadInven BeadInven;
        //FnlApp::CBeadEquip BeadEquip;
        //CActiveBead ActiveBead;
        //std::deque<unsigned short> CheckAutoStomach;
        //std::map<unsigned __int64,int> StoreItemIDList;
        //std::map<unsigned __int64,int> GuildStoreItemIDList;
        //FnlApp::CVector FreeVector;
        //CAchievementMgr AchievementMgr;
        //NAchieve::SAbility AchieveBaseAbility;
        //NAchieve::SAbility AchieveTransformAbility;
        //std::set<int> QuestMakingProc;
        //FnlApi::CHashMap<int,CPc::SQuestMaking> QuestMakingInfo;
        //ELimitPlayState LimitPlayState;
        //FnlApi::CTime LimitCheckTime;
        //std::set<int> RegionQuestProc;
        //FnlApp::CServantInvenObj ServantInven;
        //FnlApi::CHashMap<unsigned __int64,CSkillTreeInven> ServantSkillTreeInvenList;
        //FnlApi::CHashMap<unsigned __int64,CSkillPackInven> ServantSkillPackInvenList;
        //FnlApp::CServantItem *ServantItem;
        //CSkillTreeInven *ServantSkillTreeInven;
        //CSkillPackInven *ServantSkillPackInven;
        //FnlApp::CServantSubInven ServantSubInven;
        //FnlApp::CServantGatheringInfo ServantGatheringInfo;
        //_SYSTEMTIME ArenaPanaltyTm;
        //CPc::CStorePassword StorePassword;
        #endregion

        public ErrorEnum EquipItem(ulong serialNo)
        {
            if (Simple.Hp < 1)
            {
                return ErrorEnum.CharAlreadyDie;
            }

            //if (this->_mModInf.__mArray[13].mCnt && this->_mModInf.__mArray[13].mTickStx + 10000 < v6)
            //{
            //    v5 = eErrNoCharParalyzed_104;
            //    goto LABEL_121;
            //}

            //if (this->_mModInf.__mArray[50].mCnt)
            //{
            //    v5 = eErrNoCharSwoon_104;
            //    goto LABEL_121;
            //}

            var item = Inventory.Items.FirstOrDefault(x => x.SerialNumber == serialNo);
            if (item == null)
            {
                //item = ServantInventory.FirstOrDefault(x => x.SerialNumber == serialNo);
                //if (item == null)
                //{
                //    return ErrorEnum.ItemNotExist;
                //}
            }








        }

        public new void CalcAbility()
        {
            Ability.Str = Simple.CalcStr();
            Ability.Dex = Simple.CalcDex();
            Ability.Int = Simple.CalcInt();
            Ability.DDv = 1;
            Ability.MDv = 1;
            Ability.RDv = 1;
            Ability.AddDDWhenCritical += AddDDWhenCritical;
            Ability.SubDDWhenCritical += SubDDWhenCritical;
            Ability.EnemySubCriticalHit += EnemySubCriticalHit;

            var addHpByItem = 0;
            var addMpByItem = 0;
            foreach (var equip in Equip)
            {
                var item = equip.Item;

                Ability.DDv += item.DDv;
                Ability.MDv += item.MDv;
                Ability.RDv += item.RDv;
                Ability.DPv += item.DPv;
                Ability.MPv += item.MPv;
                Ability.RPv += item.RPv;
                Ability.HidDDv += item.HDDv;
                Ability.HidMDv += item.HMDv;
                Ability.HidRDv += item.HRDv;
                Ability.HidDPv += item.HDPv;
                Ability.HidMPv += item.HMPv;
                Ability.HidRPv += item.HRPv;
                Ability.CriticalHit += item.Critical;
                Ability.AddDDWhenCritical += item.AddDDWhenCritical;
                Ability.SubDDWhenCritical += item.SubDDWhenCritical;
                Ability.EnemySubCriticalHit += item.EnemySubCriticalHit;
                Ability.DHit += item.DHit;
                Ability.RHit += item.RHit;
                Ability.MHit += item.MHit;
                Ability.Str += item.Str;
                Ability.Dex += item.Dex;
                Ability.Int += item.Int;
                Ability.HpRegen += item.HpRegen;
                Ability.MpRegen += item.MpRegen;
                addHpByItem += item.HpPlus;
                addMpByItem += item.Mpplus;
                #region TODO
                //if (item.IsMeleeWeapon(item))
                //{
                //    if (item.IsAttackable(item) && v4.__List[0].mStatus == eItemStatusBless)
                //        ++this._mAbility.mCriticalHit;
                //}
                //else
                //{
                //    this._mAbility.mDDD += item.__mDDd.__mZ;
                //}
                //if (!FnlApp::CParmItemSmall::IsRange(item))
                //    this._mAbility.mRDD += item.__mRDd.__mZ;
                //if (item.__mTevel.__mMem.mType != 12)
                //    this._mAbility.mMDD += item.__mMDd.__mZ;
                //CPc::__EquipPanaltyAbility(this, item.__mParmNo);
                //v7 = item.__mSlain;
                //v8 = (__int64) & item.__mSlain[item.__mSlainCnt];
                //if (v6 != (FnlApp::CParmItem*)-936i64 && v7 != (const FnlApp::CParmSlain**)v8 )
                //{
                //    do
                //    {
                //        if (*v7)
                //            FnlApp::CPcAbility::ChangeSlain(&this->_mAbility, *v7);
                //        ++v7;
                //    }
                //    while (v7 != (const FnlApp::CParmSlain**)v8 );
                //}
                //v9 = v6->__mProtect;
                //v10 = (__int64) & v6->__mProtect[v6->__mProtectCnt];
                //if (v6 != (FnlApp::CParmItem*)-1024i64 && v9 != (const FnlApp::CParmProtect**)v10 )
                //{
                //    do
                //    {
                //        if (*v9)
                //            FnlApp::CPcAbility::ChangeProtect(&this->_mAbility, *v9);
                //        ++v9;
                //    }
                //    while (v9 != (const FnlApp::CParmProtect**)v10 );
                //}
                //v11 = v6->__mAttributeAdd;
                //v12 = (__int64) & v6->__mAttributeAdd[v6->__mAttributeAddCnt];
                //if (v6 != (FnlApp::CParmItem*)-760i64 && v11 != (const FnlApp::CParmAttribute**)v12 )
                //{
                //    do
                //    {
                //        if (*v11)
                //            FnlApp::CPcAbility::ChangeAttrAdd(&this->_mAbility, *v11);
                //        ++v11;
                //    }
                //    while (v11 != (const FnlApp::CParmAttribute**)v12 );
                //}
                //v13 = v6->__mAttributeResist;
                //v14 = (__int64) & v6->__mAttributeResist[v6->__mAttributeResistCnt];
                //if (v6 != (FnlApp::CParmItem*)-848i64 && v13 != (const FnlApp::CParmAttribute**)v14 )
                //{
                //    do
                //    {
                //        if (*v13)
                //            FnlApp::CPcAbility::ChangeAttrResist(&this->_mAbility, *v13);
                //        ++v13;
                //    }
                //    while (v13 != (const FnlApp::CParmAttribute**)v14 );
                //}
                //v15 = v6->__mAbnormalAdd;
                //v16 = (__int64) & v6->__mAbnormalAdd[v6->__mAbnormalAddCnt];
                //if (v6 != (FnlApp::CParmItem*)-1112i64 && v15 != (const FnlApp::CParmAbnormalAdd**)v16 )
                //{
                //    do
                //    {
                //        if (*v15)
                //            FnlApp::CPcAbility::ChangeAbnAdd(&this->_mAbility, *v15);
                //        ++v15;
                //    }
                //    while (v15 != (const FnlApp::CParmAbnormalAdd**)v16 );
                //}
                //v17 = v6->__mAbnormalResist;
                //v18 = (__int64) & v6->__mAbnormalResist[v6->__mAbnormalResistCnt];
                //if (v17)
                //{
                //    if (v17 == (const FnlApp::CParmAbnormalResist**)v18 )
                //    {
                //        itemsHp = v41;
                //    }
                //    else
                //    {
                //        do
                //        {
                //            if (*v17)
                //                FnlApp::CPcAbility::ChangeAbnResist(&this->_mAbility, *v17);
                //            ++v17;
                //        }
                //        while (v17 != (const FnlApp::CParmAbnormalResist**)v18 );
                //        itemsHp = v41;
                //    }
                //}
                //else
                //{
                //    itemsHp = v41;
                //}
                #endregion
            }
            /*LOWORD(v19) = this->_mAbInf.__mArray[213].__mBusySlot;
            if ((unsigned __int16)v19 <= 0x15u )
            {
                v19 = (__int16)v19;
                v20 = (v19 & 0x8000u) != 0i64 ? &this->_mAbInf.__mArray[213].__mAbParm.__mArray[22] : &this->_mAbInf.__mArray[213].__mAbParm.__mArray[v19];
                if (*v20)
                    FnlApp::CPcAbility::ChangeAbnormal(&this->_mAbility);
            }*/
            Ability.DDv += AddDDV;
            Ability.MDv += AddMDV;
            Ability.RDv += AddRDV;
            Ability.DPv += AddDPV;
            Ability.MPv += AddMPV;
            Ability.RPv += AddRPV;
            Ability.DHit += AddHit;
            Ability.RHit += AddRHit;
            Ability.MHit += AddMHit;
            Ability.DDD += (short)(AddDD + InstAddDDD);
            Ability.RDD += AddRDD;
            Ability.MDD += AddMDD;

            _CalcAbility();

            Ability.HidDDv += (short)(AddHidDDv + 5);
            Ability.HidMDv += (short)(AddHidMDv + 5);
            Ability.HidRDv += (short)(AddHidRDv + 5);
            Ability.HidDPv += AddHidDPv;
            Ability.HidMPv += AddHidMPv;
            Ability.HidRPv += AddHidRPv;
            Ability.DDv += Ability.HidDDv;
            Ability.MDv += Ability.HidMDv;
            Ability.RDv += Ability.HidRDv;
            Ability.DPv += Ability.HidDPv;
            Ability.MPv += Ability.HidMPv;
            Ability.RPv += Ability.HidRPv;
            Ability.CriticalHit += (short)(AddCriticalHit + Ability.Dex / 10);
            //pAddHpByItem = itemsHp + LOWORD(this->__mAchieveBaseAbility.mHP); TODO
            if (ParmMon == ParmMonCur)
            {
                //if (this->_mAbInf.__mArray[18].__mAbParm.__mArray[20])
                //    pAddHpByItem += this->__mAddTransformMaxHP + LOWORD(this->__mAchieveTransformAbility.mHP);
            }
            else
            {
                addHpByItem += AddTransformMaxHP; // + AchieveTransformAbility.HP); TODO
            }

            CalcMaxHp(addHpByItem);
            if (Ability.MaxHp < Simple.Hp)
            {
                Simple.Hp = Ability.MaxHp;
            }

            if (Simple.Class == PcClassEnum.Wizard)
            {
                var addTransMaxMp = 0;
                if (ParmMon != ParmMonCur)
                {
                    addTransMaxMp += AddTransformMaxMP;
                }

                Ability.MaxMp = (short)(addMpByItem + addTransMaxMp + AddMp + 2 * (Ability.Int + Simple.Level + 15));
            }
            else
            {
                var addTransMaxMp = 0;
                if (ParmMon != ParmMonCur)
                {
                    addTransMaxMp += AddTransformMaxMP;
                }

                Ability.MaxMp = (short)(addMpByItem + addTransMaxMp + Simple.Level + AddMp + 2 * (Ability.Int + 15));
            }
            //TODO Ability.MaxMp += LOWORD(this->__mAchieveBaseAbility.mMP);
            //if (ParmMon == ParmMonCur)
            //{
            //    //if (this->_mAbInf.__mArray[18].__mAbParm.__mArray[20])
            //    //    pAddHpByItem += this->__mAddTransformMaxHP + LOWORD(this->__mAchieveTransformAbility.mHP);
            //}
            //else
            //{
            //    Ability.MaxMp += LOWORD(this->__mAchieveTransformAbility.mMP);
            //}

            if (Simple.Level > 100u)
                Ability.MaxMp += (short)(10 * (Simple.Level - 100));

            if (Ability.MaxMp < Simple.Mp)
                Simple.Mp = Ability.MaxMp;

            Ability.MpRegen += (short)(Ability.Int / 4);
            CalcWeight();
        }

        private void _CalcAbility()
        {
            short pStrRate;
            short pDexRate;
            // TODO вынести ability классов в отдельную настройку
            if (Simple.Class == PcClassEnum.Fighter)
            {
                Ability.DHit += (short)((Ability.Str - 15) / 2 + Simple.Level / 6 + 1);
                Ability.RHit += (short)(Ability.Dex - 9);
                Ability.MHit += (short)(Ability.Int - 9);
                Ability.DDD += (short)((Ability.Str - 15) / 3 + 1);
                Ability.RDD += (short)(Ability.Dex / 10);
                Ability.MDD += (short)(Ability.Int / 10 + 1);
                Ability.PvPMHIT = Ability.MHit;
                pStrRate = 3;
                pDexRate = 15;

            }
            else if (Simple.Class == PcClassEnum.Dragoon)
            {
                Ability.DHit += (short)((Ability.Str - 10) / 2 + Simple.Level / 6 + 1);
                Ability.RHit += (short)(Ability.Dex - 15 + 1);
                Ability.MHit += (short)(Ability.Int - 10 + 1);
                Ability.DDD += (short)((Ability.Str) / 10 + 1);
                Ability.RDD += (short)((Ability.Dex - 15) / 3);
                Ability.MDD += (short)(Ability.Int / 10 + 1);
                Ability.PvPMHIT = Ability.MHit;
                pStrRate = 3;
                pDexRate = 15;

                var def = (short)((Ability.Dex - 15) / 3);
                Ability.DDv = def;
                Ability.RDv = def;
                Ability.MDv = def;
            }
            else if (Simple.Class == PcClassEnum.Wizard)
            {
                Ability.DHit += (short)((Ability.Str - 13) / 2 + Simple.Level / 6 + 1);
                Ability.RHit += (short)(Ability.Dex - 10 + 1);
                Ability.MHit += (short)(Ability.Int - 12 + 1);
                Ability.DDD += (short)((Ability.Str - 13) / 3 + 1);
                Ability.RDD += (short)(Ability.Dex / 10);
                Ability.MDD += (short)(Ability.Int / 3);
                Ability.PvPMHIT = Ability.MHit;
                pStrRate = 5;
                pDexRate = 15;
            }
            else if (Simple.Class == PcClassEnum.Assassin)
            {
                var hit = (short)((Ability.Str - 12) / 2 + Simple.Level / 6 + 1);
                Ability.DHit += hit;
                Ability.RHit += (short)(Ability.Dex - 9);
                Ability.MHit += hit;
                Ability.DDD += (short)((Ability.Str - 13) / 3 + 1);
                Ability.RDD += (short)(Ability.Dex / 10);
                Ability.MDD += (short)(Ability.Int / 3);
                Ability.PvPMHIT = Ability.MHit;
                pStrRate = 5;
                pDexRate = 3;

                var def = (short)((Ability.Dex - 13) / 4);
                Ability.DDv = def;
                Ability.RDv = def;
                Ability.MDv = def;
            }
            else
            {
                Ability.DHit += (short)((Ability.Str - 12) / 2 + Simple.Level / 6 + 1);
                Ability.RHit += (short)(Ability.Dex - 11);
                Ability.MHit += (short)(Ability.Int + Ability.Str - 12 - 10);
                Ability.DDD += (short)((Ability.Str - 12) / 3 + 1);
                Ability.RDD += (short)((Ability.Dex - 12) / 3 + 1);
                Ability.MDD += (short)(Ability.Int / 3);
                Ability.PvPMHIT = (short)((Ability.Str - 12) + (Ability.Int - 11) / 5 + 1);
                pStrRate = 5;
                pDexRate = 3;

                var def = (short)((Ability.Dex - 13) / 4);
                Ability.DDv = def;
                Ability.RDv = def;
                Ability.MDv = def;
            }
            CalcPvPHitRate(pStrRate, pDexRate);
            if (Simple.StomachStatus == StomachStatusEnum.Full)
            {
                ++Ability.DDD;
                ++Ability.RDD;
                ++Ability.MDD;
            }
            else if (Simple.StomachStatus == 0)
            {
                --Ability.DDD;
                --Ability.RDD;
                --Ability.MDD;
            }
        }

        public void CalcWeight()
        {
            var maxWeight = 0;
            if (Simple.Class == PcClassEnum.Fighter)
                maxWeight = AddWeight + 30 * (Ability.Str + 100) + Simple.Level * 25;
            else if (Simple.Class == PcClassEnum.Dragoon)
                maxWeight = AddWeight + 30 * (Ability.Str + 100) + Simple.Level * 15;
            else if (Simple.Class == PcClassEnum.Wizard)
                maxWeight = AddWeight + 30 * (Ability.Str + 100) + Simple.Level * 20;
            else if (Simple.Class == PcClassEnum.Assassin)
                maxWeight = AddWeight + 30 * (Ability.Str + 100) + Simple.Level * 20;
            else
                maxWeight = AddWeight + 30 * (Ability.Str + 100) + Simple.Level * 15;

            if (Simple.Level > 100 )
                maxWeight += 400 * (Simple.Level - 100);

            // TODO
            //if ( this->_mParmMon != this->_mParmMonCur || this->_mAbInf.__mArray[18].__mAbParm.__mArray[20] )
            //  maxWeight += AchieveTransformAbility.WP;

            Inventory.SetMaxWeight(maxWeight);
        }

        public void CalcMaxHp(int addHpByItem)
        {
            if (Simple.Class == PcClassEnum.Fighter)
            {
                Ability.MaxHp = (short)(addHpByItem + AddHp + 3 * Ability.Str + 8 * (Simple.Level + 5));
            }
            else if (Simple.Class == PcClassEnum.Dragoon)
            {
                var v7 = Ability.Str + 2 * Simple.Level;
                var v8 = 2 * v7;
                Ability.MaxHp = (short)(addHpByItem + AddHp + v7 + v8 + 40);
            }
            else if (Simple.Class == PcClassEnum.Wizard)
            {
                var v7 = 3 * Ability.Str;
                var v8 = 7 * Simple.Level;
                Ability.MaxHp = (short)(addHpByItem + AddHp + v7 + v8 + 40);
            }
            else if (Simple.Class == PcClassEnum.Assassin)
            {
                var v7 = 3 * Ability.Str;
                var v8 = 7 * Simple.Level;
                Ability.MaxHp = (short)(addHpByItem + AddHp + v7 + v8 + 40);
            }
            else
            {
                var v7 = 3 * Ability.Str;
                var v8 = 7 * Simple.Level;
                Ability.MaxHp = (short)(addHpByItem + AddHp + v7 + v8 + 40);
            }
            // ХЗ нужно ли делать
            /*if (FnlFw::CParm::__mSingleton->__mSvrInfo == 1)
            {
                v9 = this->_mFlag.__mFlag;
                if (!_bittest((const int*)&v9, 0xEu)
                  && !_bittest((const int*)&v9, 0x13u)
                  && !_bittest((const int*)&v9, 0x19u)
                  && !_bittest((const int*)&v9, 0x1Au) )
                {
                    this->_mAbility.mMaxHp += 1500;
                }
            }
            this->_mAbility.mMaxHp += this->__mInstAddMaxHP;
            v10 = this->_mSimple.mLevel;
            if (v10 > 0x64u)
                this->_mAbility.mMaxHp += 25 * (v10 - 100);*/
        }

        public void CalcPvPHitRate(short strRate, short dexRate)
        {
            var strHitRate = Simple.Level / strRate;
            if (strHitRate <= 15)
            {
                Ability.PvPDHIT = Ability.DHit;
                Ability.PvPRHIT = Ability.RHit;
            }
            else
            {
                Ability.PvPDHIT = (short)(Ability.DHit - strHitRate + 15);
                var dexHitRate = Simple.Level / dexRate;
                if (dexHitRate <= 15)
                    Ability.PvPRHIT = Ability.RHit;
                else
                    Ability.PvPRHIT = (short)(Ability.RHit - dexHitRate + 15);
            }
        }
    }
}
