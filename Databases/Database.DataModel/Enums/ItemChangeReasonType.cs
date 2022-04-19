﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.DataModel.Enums
{
    public enum ItemChangeReasonType
    {
        eIcrPickup = 0x0,
        eIcrDrop = 0x1,
        eIcrDie = 0x2,
        eIcrStatus = 0x3,
        eIcrRollback = 0x4,
        eIcrExchangeIn = 0x5,
        eIcrExchangeOut = 0x6,
        eIcrGive = 0x7,
        eIcrReinforce = 0x8,
        eIcrCraft = 0x9,
        eIcrBuy = 0xA,
        eIcrSell = 0xB,
        eIcrRecharge = 0xC,
        eIcrCreatedByAdmin = 0xD,
        eIcrReceiveLetter = 0xE,
        eIcrStore = 0xF,
        eIcrPopCastle = 0x10,
        eIcrCreateGm = 0x11,
        eIcrTake = 0x12,
        eIcrFoodCreationModule = 0x13,
        eIcrQuest = 0x14,
        eIcrEvent = 0x15,
        eIcrRewardExp = 0x16,
        eIcrDrawingoutCastle = 0x17,
        eIcrHuntTax = 0x18,
        eIcrBetSiegeGamble = 0x19,
        eIcrSettleSiegeGamble = 0x1A,
        eIcrJewelReinforce = 0x1B,
        eIcrNotExistSlot = 0x1C,
        eIcrMarathon = 0x1D,
        eIcrTeamBattle = 0x1E,
        eIcrTeamBattleRefun = 0x1F,
        eIcrRacingTicketBuy = 0x20,
        eIcrConsignmentIn = 0x21,
        eIcrConsignmentOut = 0x22,
        eIcrPShopIn = 0x23,
        eIcrPShopOut = 0x24,
        eIcrTakeCoupon = 0x25,
        eIcrGuildStore = 0x26,
        eIcrPopGuildAccount = 0x27,
        eIcrGSExchangeReceive = 0x28,
        eIcrMaterialEvolution = 0x29,
        eIcrMaterialDraw = 0x2A,
        eIcrGiftBox = 0x2B,
        eIcrItemMall = 0x2C,
        eIcrItemWarpping = 0x2D,
        eIcrPushItemGm = 0x2E,
        eIcrReinforceFail = 0x2F,
        eIcrUTGWPrize = 0x30,
        eIcrStorage = 0x31,
        eIcrCnsmUnreg = 0x32,
        eIcrCnsmBuy = 0x33,
        eIcrCnsmWithdraw = 0x34,
        eIcrBeforeReinforce = 0x35,
        eIcrReturnBead = 0x36,
        eIcrRacingTicketSell = 0x37,
        eIcrAddStackConfirm = 0x38,
        eIcrItemIncSys = 0x39,
        eIcrPcBangEffect = 0x3A,
        eIcrRoyalEffect = 0x3B,
        eIcrItemCreate = 0x3C,
        eIcrEventQuest = 0x3D,
        eIcrTeamRankPrize = 0x3E,
        elcrUseCoinPocket = 0x3F,
        elcrUseUnDefCoin = 0x40,
        elcrCoinToTrophy = 0x41,
        elcrJackpotConfirm = 0x42,
        elcrJackpotReward = 0x43,
        elcrRegionQuestReward = 0x44,
        eIcrRmUse = 0x64,
        eIcrRmDeprived = 0x65,
        eIcrRmBoard = 0x66,
        eIcrRmAttack = 0x67,
        eIcrRmGuild = 0x68,
        eIcrRmGuildSkill = 0x69,
        eIcrRmReinforce = 0x6A,
        eIcrRmCraft = 0x6B,
        eIcrRmBuy = 0x6C,
        eIcrRmSell = 0x6D,
        eIcrRmRecharge = 0x6E,
        eIcrRmSendLetter = 0x6F,
        eIcrRmStore = 0x70,
        eIcrRmPushCastle = 0x71,
        eIcrRmDigest = 0x72,
        eIcrRmFoodItemBreakMod = 0x73,
        eIcrRmQuest = 0x74,
        eIcrRmEvent = 0x75,
        eIcrRmGateRepair = 0x76,
        eIcrRmCreateGuild = 0x77,
        eIcrRmRepairCastleGate = 0x78,
        eIcrRmStoreFee = 0x79,
        eIcrRmGuildSkillApply = 0x7A,
        eIcrRmBetSiegeGamble = 0x7B,
        eIcrRmSettleSiegeGamble = 0x7C,
        eIcrRmJewelReinforce = 0x7D,
        eIcrRmDracoRacing = 0x7E,
        eIcrRmRacingTicketSell = 0x7F,
        eIcrRmExpiredItem = 0x80,
        eIcrRmConsignmentFee = 0x81,
        eIcrRmProtectReinforcementSuccess = 0x82,
        eIcrRmProtectReinforcementFailed = 0x83,
        eIcrRmProtectItemDrop = 0x84,
        eIcrRmGuildStore = 0x85,
        eIcrRmTrashCan = 0x86,
        eIcrRmPushGuildAccount = 0x87,
        eIcrRmGSExchangeExchange = 0x89,
        eIcrRmMaterialEvolution = 0x8A,
        eIcrRmMaterialDraw = 0x8B,
        eIcrRmWrapping = 0x8C,
        eIcrRmUTGWDie = 0x8D,
        eIcrRmSkillTreeDev = 0x8E,
        eIcrRmSkillPackDev = 0x8F,
        eIcrRmResetPcSkillTree = 0x90,
        eIcrRmResetGkillTree = 0x91,
        eIcrRmGuildRecruit = 0x92,
        eIcrRmGuildRecruitMark = 0x93,
        eIcrRmItemCnsmReg = 0x94,
        eIcrRmItemCnsmRegFee = 0x95,
        eIcrRmItemCnsmBuyFee = 0x96,
        eIcrRmBeforeProtectReinforce = 0x98,
        eIcrRmProtectReinforcementDown = 0x99,
        eIcrRmPunchBeadHolePaper = 0x9A,
        eIcrRmBeadInserted = 0x9B,
        eIcrRmReturnBeadPaper = 0x9C,
        eIcrRmResetBeadHolePaper = 0x9D,
        eIcrRmBeadInsertFailed = 0x9E,
        eIcrRmRacingTicketBuy = 0x9F,
        eIcrRmStackConfirm = 0xA0,
        eIcrRmItemIncSys = 0xA1,
        eIcrRmItemCreate = 0xA2,
        elcrRmCoinCreate = 0xA3,
        elcrRmCoinToTrophy = 0xA4,
        eIcrRmGQMakingItem = 0xA5,
        elcrRmJackpotConfirm = 0xA6,
        elcrRmSummonSiegeGuard = 0xA7,
        eIcrRmResetServantSkillTree = 0xA8,
        eIcrRmResetServantEvolution = 0xA9,
        eIcrRmRenameServant = 0xAA,
        eIcrGoldenTreasureBox = 0xAE,
        eIcrBaseMaterial = 0xAF,
        eIcrBoxOfHero = 0xB0,
        eIcrCnt = 0xB1,
    }
}