struct __cppobj CChar : CGbject
{
	FnlApi::CFlag<134217729, unsigned long> _mFlag;
	unsigned __int8 _mFssActSeq;
	unsigned __int8 _mCntDie;
	const CParmMonster* _mParmMon;
	const CParmMonster* _mParmMonCur;
	const FnlApp::CParmAbnormal* _mTransParm;
	const CParmAi* _mParmAi;
	const CFss* _mFssAct;
	const FnlApp::CParmItem* _mWeapon;
	const CMonsterSpot* __mSpot;
	CMonsterSpotGroup* __mSpotGroup;
	unsigned __int8 _mFssActCalledCnt;
	unsigned __int8 _mTargetMoveCnt;
	unsigned __int8 _mIAD;
	__int16 _mIRD;
	__int16 _mTotDamageToTarget;
	__int16 _mTotDamageFromMain;
	__int16 _mTotDamageFromOther;
	__int16 _mAddHp;
	__int16 _mAddMp;
	__int16 _mAddRegenHp;
	__int16 _mAddRegenMp;
	__int16 _mAddStr;
	__int16 _mAddDex;
	__int16 _mAddInt;
	__int16 _mAddDDV;
	__int16 _mAddMDV;
	__int16 _mAddRDV;
	__int16 _mAddDPV;
	__int16 _mAddMPV;
	__int16 _mAddRPV;
	__int16 _mAddDD;
	__int16 _mAddHit;
	__int16 _mAddRDD;
	__int16 _mAddRHit;
	__int16 _mAddMDD;
	__int16 _mAddMHit;
	__int16 _mAddWeight;
	__int16 _mAddMoveSpeed;
	__int16 _mAddAttackSpeed;
	__int16 _mBaseMoveSpeed;
	__int16 _mAddHwRegenHp;
	__int16 _mAddHwRegenMp;
	__int16 __mNextDamage;
	__int16 _mReduceUseMp;
	__int16 _mAddReduceUseMp;
	__int16 _mAddSkillHitRate;
	int _AbNoCriticalHitUp;
	EPlace __mHomePlace;
	int _mAiParam;
	unsigned int __mGuildAssNo;
	unsigned int __mCastingDelay;
	__int16 __mAddCastingDelay;
	unsigned int __mSpdAttackPerFire;
	unsigned int _mTickLastFight;
	unsigned int __mTickStxUmZil;
	unsigned int _mTickLastSkill;
	unsigned int _mTickLastPotion;
	unsigned int __mTickLastSearchRace;
	unsigned int _mSpdAttackPerTick;
	float __mDistAttack;
	float __mSpdWalkPerSec;
	float __mSpdWalkPerFire;
	float __mSpdWalkPerFireSq;
	float __mSpdRunPerHalfFire;
	float _mSpdRunPerSec;
	float _mSpdHackMaxDist;
	float _mSpdHackMovedDist;
	FnlFw::CUnique _mTargetChar;
	FnlFw::CUnique _mMainAttacker;
	FnlFw::CUnique _mLastAttacker;
	FnlFw::CUnique __mFoundItem;
	FnlApp::CVector __mPosTo;
	FnlApp::CVector __mPosToLast;
	FnlApp::CVector __mPosToStep;
	FnlApi::CArrayEx<FnlApi::C2D<float>, 12> __mNaviPath;
	FnlApi::CArrayEx<CModInflame, 193> _mModInf;
	FnlApi::CArrayEx<CAbInflame, 373> _mAbInf;
	FnlApp::CPcSimple _mSimple;
	FnlApp::CPcDetail _mDetail;
	FnlApp::CPcAbility _mAbility;
	FnlApp::CParmItem _mWeaponDef;
	CAiRaidInfo _mAiRaidInfo;
	std::set<SAiRaidCndKey> _mAiRaidCndKey;
	unsigned int _mAiRaidCndLastTick;
	int _mWeaponApplyAbnItemNo;
	unsigned int _mWeaponApplyAbnItemEndTick;
	EMaxMemPerPartyCntLevel _mPartyMemCntLevel;
	unsigned int _mLastLoadingTick;
	__int16 _mAddTransformAttackRate;
	__int16 _mAddTransformMoveRate;
	FnlApi::CArrayCircular<SAttachDetachAbArgs> __mBeAttachedAbQ;
	unsigned int __mAbQFlagThreadId;
	int __mBeAttachedAbQFlag;
	std::map<short, SSkillDelayInfo> __mUsingCastingDelay;
	std::map<short, SSkillDelayInfo> __mUsingCoolTimeDelay;
	bool __mIsAbsoluteHit;
	const FnlApp::CParmAbnormal* __mReflectAb;
	__int16 _mPowerwordLust;
	__int16 _mArmorBreak;
	__int16 _mDestructionOfInner;
	FnlApp::CParmSlain _mSlainModifier;
	FnlApp::CParmProtect _mProtectModifier;
	int _mReduceCycleDamage;
	int _mInstDamageModAttack;
	int _mInstDamageModDefense;
	FnlApi::CArrayEx<FnlApp::CParmSlain const*, 14> __mAddSlain;
	FnlApi::CArrayEx<FnlApp::CParmProtect const*, 14> __mAddProtect;
};

struct __cppobj CPc : CChar
{
	CPersonalShop __mMyPShop;
	FnlApp::CInvenObj __mInven;
	FnlApp::CPcEquip __mEquip;
	FnlApi::CArrayEx<CAgroHistory, 4> __mAgroList;
	FnlApp::CPcTeleport __mTeleport;
	CExchange __mExchange;
	std::multimap<unsigned long, CFriend> __mFriend;
	std::multimap<unsigned long, CChatFilter> __mChatFilter;
	CScriptObj __mScript;
	unsigned int __mAction;
	unsigned int __mPartyNo;
	unsigned int __mLogoutTick;
	unsigned int __mTickEndBoa;
	unsigned int __mTickEndBoaEx;
	FnlApp::CVector __mSpdHackPos;
	unsigned int __mSpdHackTick;
	unsigned int __mUserNo;
	char __mUserId[21];
	CAdminInfo __mAdminInfo;
	unsigned int __mBlockChat;
	unsigned int __mBlockBoard;
	unsigned __int8 __mPcBangLv;
	unsigned int __mChatCnt;
	unsigned int __mChatTick;
	ENeedMoney __mNeedMoney;
	int __mNeedMoneyNo;
	FnlApi::CTime __mNeedMoneyEndOrStxTm;
	CPc::<unnamed_type___mNeedMoneyInfo> __mNeedMoneyInfo;
	ESpecialEffectLevel __mSpecialEffectLevel;
	ESpecialEffectType __mSpecialEffectType;
	unsigned int __mSpecialEffectTime;
	__int16 __mAddHidDDv;
	__int16 __mAddHidMDv;
	__int16 __mAddHidRDv;
	__int16 __mAddHidDPv;
	__int16 __mAddHidMPv;
	__int16 __mAddHidRPv;
	__int16 __mAddCriticalHit;
	CCSAuth2 mSecurityInfo;
	unsigned int mSecurityTick;
	void* mHackShieldHandle;
	FnlApi::CLocker mLockerScript;
	std::map<unsigned short, unsigned long> mTrProcTickList;
	unsigned int __mBlockChatTime;
	FnlApi::CTime __mLoginTime;
	char __mCRMCode[17];
	char __mPlusCode;
	wchar_t __mMacroStr[11];
	unsigned __int8 __mUseMacroTimes;
	unsigned int __mMacroTick;
	FnlFw::CUnique __mMacroAdmin;
	EAddictionState __mPreventAddictionState;
	int __mPreventAddictionPlayTm;
	SGoldItemEffectStatus __mChargeItemInfo[16];
	FnlApp::CPcSetItemEquip __mSetEquip;
	__int16 __mIncExp;
	__int16 __mIncDropRate;
	__int16 __mAddPotionRestore;
	__int16 __mAddTransformMaxHP;
	__int16 __mAddTransformMaxMP;
	FnlApi::CFlag<257, unsigned short> __mPcFlag;
	unsigned int __mTickLetterLimit;
	char __mJoinCode[2];
	int __mNewId;
	__int16 __mSkillHp;
	unsigned __int8 __mTeamBattle;
	FnlApp::CPcSummon __mSummons;
	bool __mIsCheckTeam;
	bool __mPreventItemDrop;
	unsigned __int64 __mVisitTicketSerial;
	char __mBillNo[21];
	SChaosRankingPoint __mRankingPoint;
	__int16 __mReduceDmgPer;
	__int16 __mReflectDmg;
	__int16 __mRestoreHpFromReduceDmg;
	__int16 __mHonorPtrProtect;
	__int16 __mHonorPtrAmp;
	int __mTermOfVolitionOfHonor;
	FnlApi::CHashMap<int, FnlApi::CHashMap<int, unsigned char> > __mCAbCntMap;
	FnlFw::CUnique __mOreadTotem;
	unsigned __int8 __mTotemDamage;
	unsigned int __mFreeze;
	CSpdHackChecker __mSpdHackChk;
	FnlApi::CArrayCircular<FnlFw::CBullet> __mSerializeQueue;
	FnlApi::CAuthAcquire __mSerializeQueueAcquire;
	FnlFw::CUnique __mTalkingNpc;
	FnlApp::EUTGWMatchGroup __mUTGWGroupInfo;
	FnlApp::CPrivateSerialGenerator __mSerialGenerator;
	int __mIsQuestInit;
	unsigned __int8 __mUserItemDrop;
	unsigned __int8 __mUserAddPKDrop;
	unsigned int __mAddTransformTm;
	__int16 __mAddDDWhenCritical;
	__int16 __mInstAddMaxHP;
	__int16 __mInstAddDDD;
	bool __mRecallToAgit;
	CSkillTreeInven __mSkillTreeInven;
	CSkillPackInven __mSkillPackInven;
	CPassiveAbInflame __mPassiveAbInflame;
	CSkillParmModifier __mSkillParmModifier;
	CPcAbilityModifier __mPcAbilityModifier;
	__int64 __mRestExp[3];
	__int64 __mRestExpMax[2];
	__int16 __mSubDescChaoticPercent;
	__int16 __mAddIncrChaoticPercent;
	int __mPcBangGUID;
	int __mAccountGUID;
	EAccountingType __mAccountingType;
	unsigned int __mLoginTick;
	unsigned int __mEmoticonTick;
	FnlApp::CVector __mTeamBattleEnterPos;
	CCnsmInfo __mCnsmInfo;
	__int16 __mSubDDWhenCritical;
	__int16 __mEnemySubCriticalHit;
	unsigned int __mLootingTick;
	FnlApp::CBeadInven __mBeadInven;
	FnlApp::CBeadEquip __mBeadEquip;
	CActiveBead __mActiveBead;
	int __mIsDialogEditMode;
	int __mIsUseReturnNoItem;
	std::deque<unsigned short> __mCheckAutoStomach;
	int __mIsAutoStomach;
	unsigned int __mAutoLootingCnt;
	std::map<unsigned __int64, int> __mStoreItemIDList;
	std::map<unsigned __int64, int> __mGuildStoreItemIDList;
	int __mBeginHp;
	int __mBeginMp;
	__int16 __mEventDungeonSerialNo;
	int __mIsFreeFall;
	FnlApp::CVector __mFreeVector;
	int __mIsTeleportCenterTownRegistBullet;
	unsigned int __aServerTickAcummulate;
	int __mBomber;
	unsigned int __mCheckValidTime;
	CAchievementMgr __mAchievementMgr;
	NAchieve::SAbility __mAchieveBaseAbility;
	NAchieve::SAbility __mAchieveTransformAbility;
	unsigned int __mTeamRankNo;
	unsigned int mTeamRankGuildNo;
	char mTeamRankGuildNm[17];
	std::set<int> __mQuestMakingProc;
	FnlApi::CHashMap<int, CPc::SQuestMaking> __mQuestMakingInfo;
	int __mIsCalendarReLoad;
	int __mLimitPlayTime[2];
	ELimitPlayState __mLimitPlayState;
	FnlApi::CTime __mLimitCheckTime;
	bool __mIsLimitTimeInit;
	bool __mIsARSAuth;
	std::set<int> __mRegionQuestProc;
	bool __mIsInValidHeightLog;
	int __mIsUpdateLimitTime;
	FnlApp::CServantInvenObj __mServantInven;
	FnlApi::CHashMap<unsigned __int64, CSkillTreeInven> __mServantSkillTreeInvenList;
	FnlApi::CHashMap<unsigned __int64, CSkillPackInven> __mServantSkillPackInvenList;
	FnlApp::CServantItem* __mServantItem;
	CSkillTreeInven* __mServantSkillTreeInven;
	CSkillPackInven* __mServantSkillPackInven;
	FnlApp::CServantSubInven __mServantSubInven;
	FnlApp::CServantGatheringInfo __mServantGatheringInfo;
	int __mServantTotalAbility;
	__int16 __mPainKiller;
	int __mIsPainKiller;
	unsigned int __mUmZilAttackTick;
	int __mIsRegArena;
	int __mIsBossBattleDead;
	unsigned __int8 __mFierceBattleKillCnt;
	int __mArenaPanalty;
	_SYSTEMTIME __mArenaPanaltyTm;
	CPc::CStorePassword __mStorePassword;
};

struct __cppobj __declspec(align(8)) FnlApp::CPcSimple
{
	unsigned __int8 mFlag;
	unsigned int mPcNo;
	FnlApp::EPcClass mClass;
	unsigned __int8 mSex;
	unsigned __int8 mHead;
	unsigned __int8 mFace;
	unsigned __int8 mBody;
	unsigned int mGuildNo;
	unsigned int mGuildMarkSec;
	FnlApp::EGuildGrade mGuildGrade;
	char mGuildNickNm[17];
	bool mIsAtkTower;
	unsigned __int16 mDfnsBenefitLv;
	int mDiscipleNo;
	FnlApp::EDiscipleMemberType mDiscipleType;
	int mHp;
	int mMp;
	__int16 mStomach;
	unsigned __int8 mStomachStatus;
	__int64 mExp;
	unsigned __int16 mLevel;
	char mPcNm[15];
	FnlApp::EChaosBattleSide mChaosBattleSide;
	unsigned __int16 mFieldSvrNo;
	unsigned int mFieldSvrPcNo;
	unsigned __int16 mFieldSvrSeq;
	unsigned __int8 mEmblemOfHonorSeq;
	unsigned __int16 mOldLevel;
	unsigned __int8 mNationalFlagNo;
	unsigned __int8 mEmblemOfHonorEffectSeq;
	unsigned __int8 mTeamRankEffectSeq;
	FnlApp::EUTGWMatchGroup mMatchGroup;
	__int64 mLevelupCoinExp;
	int mLastReceiptSection;
};

/* 1805 */
struct __cppobj FnlApp::CPcDetail
{
	__int16 mDDv;
	__int16 mMDv;
	__int16 mRDv;
	__int16 mDPv;
	__int16 mMPv;
	__int16 mRPv;
	__int16 mHit;
	__int16 mMinD;
	__int16 mMaxD;
	__int16 mAttackRate;
	__int16 mMoveRate;
	FnlApi::C3D<float> mHomePos;
	unsigned int mPkCnt;
	__int16 mChaotic;
	FnlApp::EChaoticStatus mChaoticStatus;
	int mLetterLimit;
	__int16 mVolitionOfHonor;
	int mHonorPoint;
	__int64 mChaosPoint;
};

struct __cppobj __declspec(align(8)) FnlApp::CPcAbility
{
	__int16 mDDv;
	__int16 mMDv;
	__int16 mRDv;
	__int16 mDPv;
	__int16 mMPv;
	__int16 mRPv;
	__int16 mHidDDv;
	__int16 mHidMDv;
	__int16 mHidRDv;
	__int16 mHidDPv;
	__int16 mHidMPv;
	__int16 mHidRPv;
	__int16 mDDD;
	__int16 mDHIT;
	__int16 mRDD;
	__int16 mRHIT;
	__int16 mMDD;
	__int16 mMHIT;
	__int16 mStr;
	__int16 mDex;
	__int16 mInt;
	__int16 mCriticalHit;
	__int16 mAddDDWhenCritical;
	__int16 mHpRegen;
	__int16 mMpRegen;
	__int16 mHwHpRegen;
	__int16 mHwMpRegen;
	__int16 mMaxHp;
	__int16 mMaxMp;
	__int16 mPvPDHIT;
	__int16 mPvPRHIT;
	__int16 mPvPMHIT;
	FnlApi::CArrayEx<FnlApp::CParmSlain const*, 14> mSlain;
	FnlApi::CArrayEx<FnlApp::CParmProtect const*, 14> mProtect;
	FnlApi::CArrayEx<FnlApp::CParmAttribute const*, 8> mAttrAdd;
	FnlApi::CArrayEx<FnlApp::CParmAttribute const*, 8> mAttrResist;
	FnlApi::CArrayEx<FnlApp::CParmAbnormalAdd const*, 373> mAbnAdd;
	FnlApi::CArrayEx<FnlApp::CParmAbnormalResist const*, 373> mAbnResist;
	FnlApi::CHashMap<int, enum FnlApp::EEquipAbnormalType> mAbnormal;
	__int16 mSubDDWhenCritical;
	__int16 mEnemySubCriticalHit;
};





__int64 __fastcall CPc::CalcAbility(CPc* this)
{
	__int16 v2; // si
	__int16 v3; // r14
	FnlApp::CPcEquip* v4; // r13
	__int64 v5; // r15
	FnlApp::CParmItem* v6; // rbx
	const FnlApp::CParmSlain** v7; // rsi
	__int64 v8; // r12
	const FnlApp::CParmProtect** v9; // rsi
	__int64 v10; // r12
	const FnlApp::CParmAttribute** v11; // rsi
	__int64 v12; // r12
	const FnlApp::CParmAttribute** v13; // rsi
	__int64 v14; // r12
	const FnlApp::CParmAbnormalAdd** v15; // rsi
	__int64 v16; // r12
	const FnlApp::CParmAbnormalResist** v17; // rsi
	__int64 v18; // rbx
	__int64 v19; // rax
	const FnlApp::CParmAbnormal** v20; // rcx
	__int16 v21; // r10
	__int16 v22; // r9
	__int16 v23; // r8
	__int16 v24; // dx
	__int16 v25; // cx
	__int16 v26; // ax
	__int16 v27; // dx
	int v28; // er10
	const CParmMonster* v29; // rcx
	const CParmMonster* v30; // r8
	__int16 v31; // r10
	__int16 v32; // r9
	unsigned __int16 v33; // dx
	__int16 v34; // r10
	__int16 v35; // r10
	unsigned int v36; // eax
	int v37; // eax
	unsigned int v38; // ebx
	FnlApp::CPcAbility pAbilitySrc; // [rsp+30h] [rbp-19D8h] BYREF
	__int16 v41; // [rsp+1A10h] [rbp+8h]

	CChar::CalcAbility(this);
	this->_mAbility.mMpRegen = this->_mAddRegenMp;
	this->_mAbility.mStr = FnlApp::CPcSimple::CalcStr(&this->_mSimple);
	this->_mAbility.mDex = FnlApp::CPcSimple::CalcDex(&this->_mSimple);
	this->_mAbility.mInt = FnlApp::CPcSimple::CalcInt(&this->_mSimple);
	this->_mAbility.mDDv = 1;
	this->_mAbility.mMDv = 1;
	this->_mAbility.mRDv = 1;
	v2 = 0;
	v3 = 0;
	this->_mAbility.mAddDDWhenCritical += this->__mAddDDWhenCritical;
	this->_mAbility.mSubDDWhenCritical += this->__mSubDDWhenCritical;
	this->_mAbility.mEnemySubCriticalHit += this->__mEnemySubCriticalHit;
	v4 = &this->__mEquip;
	v5 = 20i64;
	do
	{
		v6 = (FnlApp::CParmItem*)v4->__List[0].mItem;
		if (v4->__List[0].mItem)
		{
			this->_mAbility.mDDv += v6->__mDDv;
			this->_mAbility.mMDv += v6->__mMDv;
			this->_mAbility.mRDv += v6->__mRDv;
			this->_mAbility.mDPv += v6->__mDPv;
			this->_mAbility.mMPv += v6->__mMPv;
			this->_mAbility.mRPv += v6->__mRPv;
			this->_mAbility.mHidDDv += v6->__mHidDDv;
			this->_mAbility.mHidMDv += v6->__mHidMDv;
			this->_mAbility.mHidRDv += v6->__mHidRDv;
			this->_mAbility.mHidDPv += v6->__mHidDPv;
			this->_mAbility.mHidMPv += v6->__mHidMPv;
			this->_mAbility.mHidRPv += v6->__mHidRPv;
			this->_mAbility.mCriticalHit += v6->__mCritical;
			this->_mAbility.mAddDDWhenCritical += v6->__mAddDDWhenCritical;
			this->_mAbility.mSubDDWhenCritical += v6->__mSubDDWhenCritical;
			this->_mAbility.mEnemySubCriticalHit += v6->__mEnemySubCriticalHit;
			this->_mAbility.mDHIT += v6->__mDHit;
			if (v6->IsMeleeWeapon(v6))
			{
				if (v6->IsAttackable(v6) && v4->__List[0].mStatus == eItemStatusBless)
					++this->_mAbility.mCriticalHit;
			}
			else
			{
				this->_mAbility.mDDD += v6->__mDDd.__mZ;
			}
			this->_mAbility.mRHIT += v6->__mRHit;
			if (!FnlApp::CParmItemSmall::IsRange(v6))
				this->_mAbility.mRDD += v6->__mRDd.__mZ;
			this->_mAbility.mMHIT += v6->__mMHit;
			if (v6->__mTevel.__mMem.mType != 12)
				this->_mAbility.mMDD += v6->__mMDd.__mZ;
			this->_mAbility.mStr += v6->__mStr;
			this->_mAbility.mDex += v6->__mDex;
			this->_mAbility.mInt += v6->__mInt;
			v41 = v6->__mHp + v2;
			v3 += v6->__mMp;
			this->_mAbility.mHpRegen += v6->__mHpRegen;
			this->_mAbility.mMpRegen += v6->__mMpRegen;
			CPc::__EquipPanaltyAbility(this, v6->__mParmNo);
			v7 = v6->__mSlain;
			v8 = (__int64)&v6->__mSlain[v6->__mSlainCnt];
			if (v6 != (FnlApp::CParmItem*)-936i64 && v7 != (const FnlApp::CParmSlain**)v8)
			{
				do
				{
					if (*v7)
						FnlApp::CPcAbility::ChangeSlain(&this->_mAbility, *v7);
					++v7;
				} while (v7 != (const FnlApp::CParmSlain**)v8);
			}
			v9 = v6->__mProtect;
			v10 = (__int64)&v6->__mProtect[v6->__mProtectCnt];
			if (v6 != (FnlApp::CParmItem*)-1024i64 && v9 != (const FnlApp::CParmProtect**)v10)
			{
				do
				{
					if (*v9)
						FnlApp::CPcAbility::ChangeProtect(&this->_mAbility, *v9);
					++v9;
				} while (v9 != (const FnlApp::CParmProtect**)v10);
			}
			v11 = v6->__mAttributeAdd;
			v12 = (__int64)&v6->__mAttributeAdd[v6->__mAttributeAddCnt];
			if (v6 != (FnlApp::CParmItem*)-760i64 && v11 != (const FnlApp::CParmAttribute**)v12)
			{
				do
				{
					if (*v11)
						FnlApp::CPcAbility::ChangeAttrAdd(&this->_mAbility, *v11);
					++v11;
				} while (v11 != (const FnlApp::CParmAttribute**)v12);
			}
			v13 = v6->__mAttributeResist;
			v14 = (__int64)&v6->__mAttributeResist[v6->__mAttributeResistCnt];
			if (v6 != (FnlApp::CParmItem*)-848i64 && v13 != (const FnlApp::CParmAttribute**)v14)
			{
				do
				{
					if (*v13)
						FnlApp::CPcAbility::ChangeAttrResist(&this->_mAbility, *v13);
					++v13;
				} while (v13 != (const FnlApp::CParmAttribute**)v14);
			}
			v15 = v6->__mAbnormalAdd;
			v16 = (__int64)&v6->__mAbnormalAdd[v6->__mAbnormalAddCnt];
			if (v6 != (FnlApp::CParmItem*)-1112i64 && v15 != (const FnlApp::CParmAbnormalAdd**)v16)
			{
				do
				{
					if (*v15)
						FnlApp::CPcAbility::ChangeAbnAdd(&this->_mAbility, *v15);
					++v15;
				} while (v15 != (const FnlApp::CParmAbnormalAdd**)v16);
			}
			v17 = v6->__mAbnormalResist;
			v18 = (__int64)&v6->__mAbnormalResist[v6->__mAbnormalResistCnt];
			if (v17)
			{
				if (v17 == (const FnlApp::CParmAbnormalResist**)v18)
				{
					v2 = v41;
				}
				else
				{
					do
					{
						if (*v17)
							FnlApp::CPcAbility::ChangeAbnResist(&this->_mAbility, *v17);
						++v17;
					} while (v17 != (const FnlApp::CParmAbnormalResist**)v18);
					v2 = v41;
				}
			}
			else
			{
				v2 = v41;
			}
		}
		v4 = (FnlApp::CPcEquip*)((char*)v4 + 32);
		--v5;
	} while (v5);
	LOWORD(v19) = this->_mAbInf.__mArray[213].__mBusySlot;
	if ((unsigned __int16)v19 <= 0x15u)
	{
		v19 = (__int16)v19;
		v20 = (v19 & 0x8000u) != 0i64 ? &this->_mAbInf.__mArray[213].__mAbParm.__mArray[22] : &this->_mAbInf.__mArray[213].__mAbParm.__mArray[v19];
		if (*v20)
			FnlApp::CPcAbility::ChangeAbnormal(&this->_mAbility);
	}
	FnlApp::CPcAbility::CPcAbility(&pAbilitySrc, &this->_mAbility);
	CPcAbilityModifier::Apply(&this->__mPcAbilityModifier, &this->_mAbility, &pAbilitySrc);
	this->_mAbility.mDDv += this->_mAddDDV;
	this->_mAbility.mMDv += this->_mAddMDV;
	this->_mAbility.mRDv += this->_mAddRDV;
	this->_mAbility.mDPv += this->_mAddDPV;
	this->_mAbility.mMPv += this->_mAddMPV;
	this->_mAbility.mRPv += this->_mAddRPV;
	this->_mAbility.mDHIT += this->_mAddHit;
	this->_mAbility.mDDD += this->_mAddDD + this->__mInstAddDDD;
	this->_mAbility.mRHIT += this->_mAddRHit;
	this->_mAbility.mRDD += this->_mAddRDD;
	this->_mAbility.mMHIT += this->_mAddMHit;
	this->_mAbility.mMDD += this->_mAddMDD;
	CPc::__CalcAbility(this);
	this->_mAbility.mHidDDv += this->__mAddHidDDv + 5;
	v21 = this->_mAbility.mHidDDv;
	this->_mAbility.mHidMDv += this->__mAddHidMDv + 5;
	v22 = this->_mAbility.mHidMDv;
	this->_mAbility.mHidRDv += this->__mAddHidRDv + 5;
	v23 = this->_mAbility.mHidRDv;
	this->_mAbility.mHidDPv += this->__mAddHidDPv;
	v24 = this->_mAbility.mHidDPv;
	this->_mAbility.mHidMPv += this->__mAddHidMPv;
	v25 = this->_mAbility.mHidMPv;
	this->_mAbility.mHidRPv += this->__mAddHidRPv;
	v26 = this->_mAbility.mHidRPv;
	this->_mAbility.mDDv += v21;
	this->_mAbility.mMDv += v22;
	this->_mAbility.mRDv += v23;
	this->_mAbility.mDPv += v24;
	this->_mAbility.mMPv += v25;
	this->_mAbility.mRPv += v26;
	this->_mAbility.mCriticalHit += this->__mAddCriticalHit + this->_mAbility.mDex / 10;
	v27 = v2 + LOWORD(this->__mAchieveBaseAbility.mHP);
	if (this->_mParmMon == this->_mParmMonCur)
	{
		if (this->_mAbInf.__mArray[18].__mAbParm.__mArray[20])
			v27 += this->__mAddTransformMaxHP + LOWORD(this->__mAchieveTransformAbility.mHP);
	}
	else
	{
		v27 += this->__mAddTransformMaxHP + LOWORD(this->__mAchieveTransformAbility.mHP);
	}
	CPc::__CalcMaxHp(this, v27);
	v28 = this->_mAbility.mMaxHp;
	if (v28 < this->_mSimple.mHp)
		this->_mSimple.mHp = v28;
	if (this->_mSimple.mClass == ePcClassWizard)
	{
		v29 = this->_mParmMon;
		v30 = this->_mParmMonCur;
		if (v29 == v30)
			v34 = 0;
		else
			v34 = this->__mAddTransformMaxMP;
		v32 = this->_mAbility.mInt;
		v33 = this->_mSimple.mLevel;
		this->_mAbility.mMaxMp = v3 + v34 + this->_mAddMp + 2 * (v32 + v33 + 15);
	}
	else
	{
		v29 = this->_mParmMon;
		v30 = this->_mParmMonCur;
		if (v29 == v30)
			v31 = 0;
		else
			v31 = this->__mAddTransformMaxMP;
		v32 = this->_mAbility.mInt;
		v33 = this->_mSimple.mLevel;
		this->_mAbility.mMaxMp = v3 + v33 + v31 + this->_mAddMp + 2 * (v32 + 15);
	}
	this->_mAbility.mMaxMp += LOWORD(this->__mAchieveBaseAbility.mMP);
	v35 = this->_mAbility.mMaxMp;
	if (v29 == v30)
	{
		if (this->_mAbInf.__mArray[18].__mAbParm.__mArray[20])
			this->_mAbility.mMaxMp = v35 + LOWORD(this->__mAchieveTransformAbility.mMP);
	}
	else
	{
		this->_mAbility.mMaxMp = v35 + LOWORD(this->__mAchieveTransformAbility.mMP);
	}
	if (FnlFw::CParm::__mSingleton->__mSvrInfo == 1)
	{
		v36 = this->_mFlag.__mFlag;
		if (!_bittest((const int*)&v36, 0xEu)
			&& !_bittest((const int*)&v36, 0x13u)
			&& !_bittest((const int*)&v36, 0x19u)
			&& !_bittest((const int*)&v36, 0x1Au))
		{
			this->_mAbility.mMaxMp += 750;
		}
	}
	if (v33 > 0x64u)
		this->_mAbility.mMaxMp += 10 * (v33 - 100);
	v37 = this->_mAbility.mMaxMp;
	if (v37 < this->_mSimple.mMp)
		this->_mSimple.mMp = v37;
	this->_mAbility.mMpRegen += v32 / 4;
	v38 = CPc::__CalcWeight(this);
	stdext::_Hash<stdext::_Hmap_traits<FnlFw::CUnique, CTrap*, stdext::hash_compare<FnlFw::CUnique, std::less<FnlFw::CUnique>>, std::allocator<std::pair<FnlFw::CUnique const, CTrap*>>, 0>>::~_Hash<stdext::_Hmap_traits<FnlFw::CUnique, CTrap*, stdext::hash_compare<FnlFw::CUnique, std::less<FnlFw::CUnique>>, std::allocator<std::pair<FnlFw::CUnique const, CTrap*>>, 0>>((stdext::_Hash<stdext::_Hmap_traits<int, CAi, stdext::hash_compare<int, std::less<int> >, std::allocator<std::pair<int const, CAi> >, 0> > *) & pAbilitySrc.mAbnormal);
	return v38;
}