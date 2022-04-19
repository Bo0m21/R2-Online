using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Game.Models.Game
{
    public class GPcAbility
    {
		public short DDv { get; set; }
		public short MDv { get; set; }
		public short RDv { get; set; }
		public short DPv { get; set; }
		public short MPv { get; set; }
		public short RPv { get; set; }
		public short HidDDv { get; set; }
		public short HidMDv { get; set; }
		public short HidRDv { get; set; }
		public short HidDPv { get; set; }
		public short HidMPv { get; set; }
		public short HidRPv { get; set; }
		public short DDD { get; set; }
		public short DHit { get; set; }
		public short RDD { get; set; }
		public short RHit { get; set; }
		public short MDD { get; set; }
		public short MHit { get; set; }
		public short Str { get; set; }
		public short Dex { get; set; }
		public short Int { get; set; }
		public short AddDDWhenCritical { get; set; }
		public short SubDDWhenCritical { get; set; }
		public short CriticalHit { get; set; }
		public short EnemySubCriticalHit { get; set; }
		public short HpRegen { get; set; }
		public short MpRegen { get; set; }
		public short HwHpRegen { get; set; }
		public short HwMpRegen { get; set; }
		public short MaxHp { get; set; }
		public short MaxMp { get; set; }
		public short PvPDHIT { get; set; }
		public short PvPRHIT { get; set; }
		public short PvPMHIT { get; set; }
		//FnlApi::CArrayEx<FnlApp::CParmSlain const*, 14> mSlain;
		//FnlApi::CArrayEx<FnlApp::CParmProtect const*, 14> mProtect;
		//FnlApi::CArrayEx<FnlApp::CParmAttribute const*, 8> mAttrAdd;
		//FnlApi::CArrayEx<FnlApp::CParmAttribute const*, 8> mAttrResist;
		//FnlApi::CArrayEx<FnlApp::CParmAbnormalAdd const*, 373> mAbnAdd;
		//FnlApi::CArrayEx<FnlApp::CParmAbnormalResist const*, 373> mAbnResist;
		//FnlApi::CHashMap<int, enum FnlApp::EEquipAbnormalType> mAbnormal;


		public void Reset()
		{
			DDv = -1;
			MDv = -1;
			RDv = -1;
			DPv = 0;
			MPv = 0;
			MaxHp = 1;
			MaxMp = 1;
			RPv = 0;
			HidDDv = 0;
			HidMDv = 0;
			HidRDv = 0;
			HidDPv = 0;
			HidMPv = 0;
			HidRPv = 0;
			DDD = 0;
			DHit = 0;
			RDD = 0;
			RHit = 0;
			MDD = 0;
			MHit = 0;
			Str = 0;
			Dex = 0;
			Int = 0;
			CriticalHit = 0;
			EnemySubCriticalHit = 0;
			AddDDWhenCritical = 0;
			SubDDWhenCritical = 0;
			HpRegen = 0;
			MpRegen = 0;
			HwHpRegen = 0;
			HwMpRegen = 0;
			PvPDHIT = 0;
			PvPRHIT = 0;
			PvPMHIT = 0;
			//v1 = &this->mSlain.__mArray[this->mSlain.__mSz];
			//for (i = this->mSlain.__mArray; i != v1; ++i)
			//	*i = 0i64;
			//v3 = &this->mProtect.__mArray[this->mProtect.__mSz];
			//for (j = this->mProtect.__mArray; j != v3; ++j)
			//	*j = 0i64;
			//v5 = &this->mAttrAdd.__mArray[this->mAttrAdd.__mSz];
			//for (k = this->mAttrAdd.__mArray; k != v5; ++k)
			//	*k = 0i64;
			//v7 = &this->mAttrResist.__mArray[this->mAttrResist.__mSz];
			//for (l = this->mAttrResist.__mArray; l != v7; ++l)
			//	*l = 0i64;
			//v9 = &this->mAbnAdd.__mArray[this->mAbnAdd.__mSz];
			//for (m = this->mAbnAdd.__mArray; m != v9; ++m)
			//	*m = 0i64;
			//v11 = &this->mAbnResist.__mArray[this->mAbnResist.__mSz];
			//for (n = this->mAbnResist.__mArray; n != v11; ++n)
			//	*n = 0i64;
		}
	}
}
