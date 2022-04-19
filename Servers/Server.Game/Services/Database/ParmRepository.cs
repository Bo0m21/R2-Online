using Database.DataModel.Enums;
using Database.DataModel.Models;
using Database.Parm.Interfaces;
using Database.Parm.Models;
using Microsoft.EntityFrameworkCore;
using Server.Game.Models.Game;
using System.Collections.Generic;
using System.Linq;

namespace Server.Game.Services.Database
{
    /// <summary>
    ///     Database balance service
    /// </summary>
    public class ParmRepository
    {
        private readonly IParmContext _parmContext;
        private readonly DBParmMappingService _parmMappingService;

        public List<Abnormal> Abnormals { get; }
        public List<AbnormalAdd> AbnormalAdds { get; }
        public List<AbnormalResist> AbnormalResists { get; }
        public List<Attribute> Attributes { get; }
        public List<AttributeAdd> AttributeAdds { get; }
        public List<AttributeResist> AttributeResists { get; }
        public List<BeadEffect> BeadEffects { get; }
        public List<ItemPanalty> ItemPanalties { get; }
        public List<Item> Items { get; }
        public List<Module> Modules { get; }
        public List<Protect> Protects { get; }
        public List<Skill> Skills { get; }
        public List<Slain> Slains { get; }

        public List<DropItem> DropItems { get; }
        public List<DropGroup> DropGroups { get; }
        public List<MonsterDrop> MonsterDrops { get; }
        public List<MonsterSpotGroup> MonsterSpotGroups { get; }
        public List<MonsterSpot> MonsterSpots { get; }
        public List<Monster> Monsters { get; }

        public List<ExpModel> Exps { get; set; }

        public ParmRepository(IParmContext parmContext, DBParmMappingService parmMappingService)
        {
            _parmContext = parmContext;
            _parmMappingService = parmMappingService;

            // Зависимости
            Abnormals = _parmContext.Abnormals.Select(x => new Abnormal
            {
                Id = x.Id,
                Type = (AbnormalTypeEnum)x.Type,
                Level = x.Level,
                Percent = x.Percent,
                Time = x.Time,
                Grade = x.Grade,
                Desc = x.Desc
            }).ToList();
            AbnormalAdds = _parmContext.AbnormalAdds.Select(x => new AbnormalAdd
            {
                Id = x.Id,
                Type = (AbnormalTypeEnum)x.Type,
                Level = x.Level,
                Percent = x.Percent,
            }).ToList();
            AbnormalResists = _parmContext.AbnormalResists.Select(x => new AbnormalResist
            {
                Id = x.Id,
                Type = (AbnormalTypeEnum)x.Type,
                Level = x.Level,
                Percent = x.Percent,
            }).ToList();
            Attributes = _parmContext.Attributes.Select(x => new Attribute
            {
                Id = x.Id,
                Type = x.Type,
                Level = x.Level,
                DiceDamage = x.DiceDamage,
                Damage = x.Damage,
            }).ToList();
            AttributeAdds = _parmContext.AttributeAdds.Select(x => new AttributeAdd
            {
                Id = x.Id,
                Type = x.Type,
                Level = x.Level,
                DiceDamage = x.DiceDamage,
                Damage = x.Damage,
            }).ToList();
            AttributeResists = _parmContext.AttributeResists.Select(x => new AttributeResist
            {
                Id = x.Id,
                Type = x.Type,
                Level = x.Level,
                DiceDamage = x.DiceDamage,
                Damage = x.Damage,
            }).ToList();
            BeadEffects = _parmContext.BeadEffects.Select(x => new BeadEffect
            {
                BeadNo = x.BeadNo,
                Name = x.Name,
                BeadType = x.BeadType,
                ChkGroup = x.ChkGroup,
                Percent = x.Percent,
                ApplyTarget = x.ApplyTarget,
                ParamA = x.ParamA,
                ParamB = x.ParamB,
                ParamC = x.ParamC,
                ParamD = x.ParamD,
                ParamE = x.ParamE
            }).ToList();
            Modules = _parmContext.Modules.Select(x => new Module
            {
                Id = x.Id,
                Type = (ModuleTypeEnum)x.Type,
                Level = x.Level,
                AParam = x.AParam,
                BParam = x.BParam,
                CParam = x.CParam
            }).ToList();
            Protects = _parmContext.Protects.Select(x => new Protect
            {
                Id = x.Id,
                Type = (RaceTypeEnum)x.Type,
                Level = x.Level,
                DPv = x.DPv,
                MPv = x.MPv,
                RPv = x.RPv,
                DDv = x.DDv,
                MDv = x.MDv,
                RDv = x.RDv
            }).ToList();
            Slains = _parmContext.Slains.Select(x => new Slain
            {
                Id = x.SlainId,
                Type = (RaceTypeEnum)x.Type,
                Level = x.Level,
                HitPlus = x.HitPlus,
                Ddplus = x.Ddplus,
                Rddplus = x.Rddplus,
                RhitPlus = x.RhitPlus
            }).ToList();
            ItemPanalties = _parmContext.ItemPanalties.Select(x => new ItemPanalty
            {
                Id = x.ItemId,
                UseClass = x.UseClass,
                DHit = x.DHit,
                DDd = x.DDd,
                RHit = x.RHit,
                RDd = x.RDd,
                MHit = x.MHit,
                MDd = x.MDd,
                HPPlus = x.HPPlus,
                MPPlus = x.MPPlus,
                Str = x.Str,
                Dex = x.Dex,
                Int = x.Int,
                HPregen = x.HPregen,
                MPregen = x.MPregen,
                AttackRate = x.AttackRate,
                MoveRate = x.MoveRate,
                Critical = x.Critical,
                Range = x.Range,
                AddWeight = x.AddWeight,
                AddPotionRestore = x.AddPotionRestore,
                DPv = x.DPv,
                MPv = x.MPv,
                RPv = x.RPv,
                DDv = x.DDv,
                MDv = x.MDv,
                RDv = x.RDv,
                HDPv = x.HDPv,
                HMPv = x.HMPv,
                HRPv = x.HRPv,
                HDDv = x.HDDv,
                HMDv = x.HMDv,
                HRDv = x.HRDv
            }).ToList();
            MonsterSpotGroups = _parmContext.MonsterSpotGroups.Select(x => new MonsterSpotGroup
            {
                Id = x.GId,
                PosX = x.PosX,
                PosY = x.PosY,
                PosZ = x.PosZ,
                Radius = x.Radius,
            }).ToList();
            Exps = _parmContext.Exps.ToList();

            // Связи
            var skillAbnormals = _parmContext.SkillAbnormals.ToList();
            var skillAttributes = _parmContext.SkillAttributes.ToList();
            var skillSlains = _parmContext.SkillSlains.ToList();
            var itemAbnormalAdds = _parmContext.ItemAbnormalAdds.ToList();
            var itemAbnormalResists = _parmContext.ItemAbnormalResists.ToList();
            var itemAttributeAdds = _parmContext.ItemAttributeAdds.ToList();
            var itemBeadEffects = _parmContext.ItemBeadEffects.ToList();
            //var itemPanalties = _parmContext.ItemPanalties.ToList();
            var itemBeadModules = _parmContext.ItemBeadModules.ToList();
            var itemProtects = _parmContext.ItemProtects.ToList();
            var itemSkills = _parmContext.ItemSkills.ToList();
            var itemSlains = _parmContext.ItemSlains.ToList();

            var monsterAbnormalAdds = _parmContext.MonsterAbnormalAdds.ToList();
            var monsterAbnormalResists = _parmContext.MonsterAbnormalResists.ToList();
            var monsterAttributeAdds = _parmContext.MonsterAttributeAdds.ToList();
            var monsterAttributeResists = _parmContext.MonsterAttributeResists.ToList();
            var monsterDrops = _parmContext.MonsterDrops.ToList();
            var monsterSlains = _parmContext.MonsterSlains.ToList();
            var monsterRoles = _parmContext.MonsterRoles.ToList();

            // Главные сущности
            Skills = _parmContext.Skills.AsEnumerable().Select(x => new Skill
            {
                Id= x.Id,
                Name = x.Name,
                HitPlus= x.HitPlus,
                MpperUse = x.MpperUse,
                SpellNum = x.SpellNum,
                Desc = x.Desc,
                Type = x.Type,
                HpperUse = x.HpperUse,
                ChaoUse = x.ChaoUse,
                ApplyRadius = x.ApplyRadius,
                ApplyCnt = x.ApplyCnt,
                ApplyRace = x.ApplyRace,
                CastingDelay = x.CastingDelay,
                ConsumeItem = x.ConsumeItem,
                ConsumeItemCnt = x.ConsumeItemCnt,
                ActiveType = x.ActiveType,
                Animation = x.Animation,
                CastingSpeed = x.CastingSpeed,
                SkillEffect = x.SkillEffect,
                CamShakeWhenHit = x.CamShakeWhenHit,
                CriticalEffectWhenHit = x.CriticalEffectWhenHit,
                ActiveWeapon = x.ActiveWeapon,
                CoolTime = x.CoolTime,
                CastingGroup = x.CastingGroup,
                CoolTimeGroup = x.CoolTimeGroup,
                ConsumeItem2 = x.ConsumeItem2,
                ConsumeItemCnt2 = x.ConsumeItemCnt2,
                IsCancel = x.IsCancel,
                IsAttack = x.IsAttack,
            }).ToList();
            foreach (var skill in Skills)
            {
                var sAbnormals = skillAbnormals.Where(x => x.SkillId == skill.Id).ToList();
                var sAttributes = skillAttributes.Where(x => x.SkillId == skill.Id).ToList();
                var sSlains = skillSlains.Where(x => x.SkillId == skill.Id).ToList();

                skill.Abnormals = Abnormals
                   .Where(a => sAbnormals.Any(sa => sa.AbnormalId == a.Id))
                   .ToList();
                skill.Attributes = Attributes
                    .Where(a => sAttributes.Any(sa => sa.AttrbuteId == a.Id))
                    .ToList();
                skill.Slains = Slains.Where(a => sSlains.Any(sa => sa.SlainId == a.Id))
                    .ToList();
            }

            Items = _parmContext.Items.Select(x => new Item
            {
                Id = x.Id,
                Name = x.Name,
                Type = (ItemTypeEnum)x.Type,
                Level = x.Level,
                DHit = x.Dhit,
                DDd = x.DDd,
                RHit = x.Rhit,
                RDd = x.Rdd,
                MHit = x.Mhit,
                MDd = x.Mdd,
                HpPlus = x.HpPlus,
                Mpplus = x.Mpplus,
                Str = x.Str,
                Dex = x.Dex,
                Int = x.Int,
                DPv = x.DPv,
                MPv = x.MPv,
                RPv = x.RPv,
                DDv = x.DDv,
                MDv = x.MDv,
                RDv = x.RDv,
                HDPv = x.Hdpv,
                HMPv = x.Hmpv,
                HRPv = x.Hrpv,
                HDDv = x.Hddv,
                HMDv = x.Hmdv,
                HRDv = x.Hrdv,
                MaxStack = x.MaxStack,
                Weight = x.Weight,
                UseType = (UseTypeEnum)x.UseType,
                UseNum = x.UseNum,
                Recycle = x.Recycle,
                HpRegen = x.HpRegen,
                MpRegen = x.Mpregen,
                AttackRate = x.AttackRate,
                MoveRate = x.MoveRate,
                Critical = x.Critical,
                TermOfValidity = x.TermOfValidity,
                TermOfValidityMi = x.TermOfValidityMi,
                Desc = x.Desc,
                Status = (ItemStatusEnum)x.Status,
                FakeId = x.FakeId,
                FakeName = x.FakeName,
                UseMsg = x.UseMsg,
                Range = x.Range,
                UseClass = (UseClassEnum)x.UseClass,
                DropEffect = x.DropEffect,
                UseLevel = x.UseLevel,
                UseEternal = x.UseEternal,
                UseDelay = x.UseDelay,
                UseInAttack = x.UseInAttack == 1,
                IsEvent = x.IsEvent,
                IsIndict = x.IsIndict,
                AddWeight = x.AddWeight,
                SubType = (ItemSubTypeEnum)x.SubType,
                IsCharge = x.IsCharge,
                NationOp = x.NationOp,
                PshopItemType = x.PshopItemType,
                QuestNo = x.QuestNo,
                IsTest = x.IsTest,
                QuestNeedCnt = x.QuestNeedCnt,
                ContentsLv = x.ContentsLv,
                IsConfirm = x.IsConfirm,
                IsSealable = x.IsSealable,
                AddDDWhenCritical = x.AddDdwhenCritical,
                SealRemovalNeedCnt = x.SealRemovalNeedCnt,
                IsPracticalPeriod = x.IsPracticalPeriod,
                IsReceiveTown = x.IsReceiveTown,
                IsReinforceDestroy = x.IsReinforceDestroy,
                AddHpPotionRestore = x.AddPotionRestore,
                //TODO AddMpPotionRestore
                AddMaxHpWhenTransform = x.AddMaxHpWhenTransform,
                AddMaxMpWhenTransform = x.AddMaxMpWhenTransform,
                AddAttackRateWhenTransform = x.AddAttackRateWhenTransform,
                AddMoveRateWhenTransform = x.AddMoveRateWhenTransform,
                SupportType = x.SupportType,
                TermOfValidityLv = x.TermOfValidityLv,
                IsUseableUtgwsvr = x.IsUseableUtgwsvr,
                AddShortAttackRange = x.AddShortAttackRange,
                AddLongAttackRange = x.AddLongAttackRange,
                WeaponPoisonType = x.WeaponPoisonType,
                SubDDWhenCritical = x.SubDdwhenCritical,
                GetItemFeedback = x.GetItemFeedback,
                EnemySubCriticalHit = x.EnemySubCriticalHit,
                IsPartyDrop = x.IsPartyDrop,
                MaxBeadHoleCount = x.MaxBeadHoleCount,
                SubTypeOption = x.SubTypeOption,
                //AbnormalAdds = AbnormalAdds
                //    .Where(a => _parmContext.ItemAbnormalAdds.Any(sa => sa.ItemId == x.Id && sa.AbnormalId == a.Id))
                //    .ToList(),
                //AbnormalResists = AbnormalResists
                //    .Where(a => _parmContext.ItemAbnormalResists.Any(sa => sa.ItemId == x.Id && sa.AbnormalId == a.Id))
                //    .ToList(),
                //AttributeAdds = AttributeAdds
                //    .Where(a => _parmContext.ItemAttributeAdds.Any(sa => sa.ItemId == x.Id && sa.AttributeId == a.Id))
                //    .ToList(),
                //AttributeResists = new List<AttributeResist>(), // TODO
                //BeadEffects = BeadEffects
                //    .Where(a => _parmContext.ItemBeadEffects.Any(sa => sa.ItemId == x.Id && sa.BeadNo == a.BeadNo))
                //    .ToList(),
                //ItemPanalties = ItemPanalties
                //    .Where(a => _parmContext.ItemPanalties.Any(sa => sa.ItemId == x.Id && sa.ItemId == a.Id))
                //    .ToList(),
                //Modules = Modules
                //    .Where(a => _parmContext.ItemBeadModules.Any(sa => sa.ItemId == x.Id && sa.ModuleId == a.Id))
                //    .ToList(),
                //Protects = Protects
                //    .Where(a => _parmContext.ItemProtects.Any(sa => sa.ItemId == x.Id && sa.ProtectId == a.Id))
                //    .ToList(),
                //Skills = Skills
                //    .Where(a => _parmContext.ItemSkills.Any(sa => sa.ItemId == x.Id && sa.SkillId == a.Id))
                //    .ToList(),
                //Slains = Slains
                //    .Where(a => _parmContext.ItemSlains.Any(sa => sa.ItemId == x.Id && sa.SlainId == a.Id))
                //    .ToList(),

            }).ToList();
            foreach (var item in Items)
            {
                var iAbnormalAdds = itemAbnormalAdds.Where(x => x.ItemId == item.Id).ToList();
                var iAbnormalResists = itemAbnormalResists.Where(x => x.ItemId == item.Id).ToList();
                var iAttributeAdds = itemAttributeAdds.Where(x => x.ItemId == item.Id).ToList();
                var iBeadEffects = itemBeadEffects.Where(x => x.ItemId == item.Id).ToList();
                var iPanalties = ItemPanalties.Where(x => x.Id == item.Id).ToList();
                var iBeadModules = itemBeadModules.Where(x => x.ItemId == item.Id).ToList();
                var iProtects = itemProtects.Where(x => x.ItemId == item.Id).ToList();
                var iSkills = itemSkills.Where(x => x.ItemId == item.Id).ToList();
                var iSlains = itemSlains.Where(x => x.ItemId == item.Id).ToList();

                item.AbnormalAdds = AbnormalAdds
                    .Where(a => iAbnormalAdds.Any(sa => sa.AbnormalId == a.Id))
                    .ToList();
                item.AbnormalResists = AbnormalResists
                    .Where(a => iAbnormalResists.Any(sa => sa.AbnormalId == a.Id))
                    .ToList();
                item.AttributeAdds = AttributeAdds
                    .Where(a => iAttributeAdds.Any(sa => sa.AttributeId == a.Id))
                    .ToList();
                item.BeadEffects = BeadEffects
                    .Where(a => iBeadEffects.Any(sa => sa.BeadNo == a.BeadNo))
                    .ToList();
                item.ItemPanalties = ItemPanalties
                    .Where(a => iPanalties.Any(sa => sa.Id == a.Id))
                    .ToList();
                item.Modules = Modules
                    .Where(a => iBeadModules.Any(sa => sa.ModuleId == a.Id))
                    .ToList();
                item.Protects = Protects
                    .Where(a => iProtects.Any(sa => sa.ProtectId == a.Id))
                    .ToList();
                item.Skills = Skills
                    .Where(a => iSkills.Any(sa => sa.SkillId == a.Id))
                    .ToList();
                item.Slains = Slains
                    .Where(a => iSlains.Any(sa => sa.SlainId == a.Id))
                    .ToList();
                item.AttributeResists = new List<AttributeResist>(); // TODO
            }

            DropItems = _parmContext.DropItems.Select(x => new DropItem
            {
                Id = x.Id,
                ItemId = x.ItemId,
                Count = x.Count,
                Status = (ItemStatusEnum)x.Status,
                IsEvent = x.IsEvent
            }).ToList();
            foreach (var dropItem in DropItems)
            {
                dropItem.Item = Items.Where(i => i.Id == dropItem.ItemId).FirstOrDefault();
            }

            DropGroups = _parmContext.DropGroups.GroupBy(x => x.DropGroupId).Select(x => new DropGroup
            {
                DropGroupId = x.Key
            }).ToList();
            foreach (var dropGroup in DropGroups)
            {
                dropGroup.Items = new List<DropGroupItem>();
                var dropGroupItemss = _parmContext.DropGroups.Where(dg => dg.DropGroupId == dropGroup.DropGroupId).Select(x => new DropGroupItem
                {
                    DropItemId = x.DropItemId,
                    Percent = x.Percent,
                }).ToList();

                foreach (var dropGroupItem in dropGroupItemss)
                {
                    dropGroupItem.DropItem = DropItems.Where(i => i.Id == dropGroupItem.DropItemId).FirstOrDefault();
                    dropGroup.Items.Add(dropGroupItem);
                }
            }

            MonsterDrops = _parmContext.MonsterDrops.AsEnumerable().Select(x => new MonsterDrop
            {
                MonsterId = x.MonsterId,
                DropGroupId = x.DropGroupId,
                Percent = x.Percent,
                DropGroup = DropGroups.FirstOrDefault(dg => dg.DropGroupId == x.DropGroupId)
            }).ToList();
            MonsterSpots = _parmContext.MonsterSpots.AsEnumerable().Select(x => new MonsterSpot
            {
                GroupId = x.GroupId,
                MonsterId = x.MonsterId,
                Cnt = x.Cnt,
                Tick = x.Tick,
                Dir = x.Dir,
                VarRespawnTick = x.VarRespawnTick,
                SpotGroup = MonsterSpotGroups.Where(msg => msg.Id == x.GroupId).ToList()
            }).ToList();
            Monsters = _parmContext.Monsters.Select(x => new Monster
            {
                Id = x.Id,
                Name = x.Name,
                Level = x.Level,
                Class = (PcClassEnum)x.Class,
                Exp = (ulong)x.Exp,
                Hit = x.Hit,
                MinDamage = x.MinD,
                MaxDamage = x.MaxD,
                AttackRateOrg = x.AttackRateOrg,
                MoveRateOrg = x.MoveRateOrg,
                AttackRateNew = x.AttackRateNew,
                MoveRateNew = x.MoveRateNew,
                HpMax = x.Hp,
                MpMax = x.Mp,
                MoveRange = x.MoveRange,
                Type = (GbjClassEnum)x.GbjType,
                RaceType = (RaceTypeEnum)x.RaceType,
                AiType = (AiTypeEnum)x.AiType,
                CastingDelay = x.CastingDelay,
                Chaotic = x.Chaotic,
                SameRace1 = x.SameRace1,
                SameRace2 = x.SameRace2,
                SameRace3 = x.SameRace3,
                SameRace4 = x.SameRace4,
                SightRange = x.SightRange,
                AttackRange = x.AttackRange,
                SkillRange = x.SkillRange,
                BodySize = x.BodySize,
                DetectTransformF = x.DetectTransF,
                DetectTransformP = x.DetectTransP,
                DetectChaotic = x.DetectChao,
                AiEx = (AiTypeEnum)x.AiEx,
                Scale = x.Scale,
                IsResistTransF = x.IsResistTransF,
                IsEvent = x.IsEvent,
                IsTest = x.IsTest,
                HpNew = x.HpNew,
                MpNew = x.MpNew,
                BuyMerchanId = x.BuyMerchanId,
                SellMerchanId = x.SellMerchanId,
                ChargeMerchanId = x.ChargeMerchanId,
                TransformWeight = x.TransformWeight,
                NationOp = x.NationOp,
                HpRegen = x.HpRegen,
                MpRegen = x.MpRegen,
                ContentsLv = x.ContentsLv,
                IsEventTest = x.IsEventTest,
                IsShowHp = x.IsShowHp,
                SupportType = x.SupportType,
                VolitionOfHonor = x.VolitionOfHonor,
                WMapIconType = x.WmapIconType,
                IsAmpliableTermOfValidity = x.IsAmpliableTermOfValidity,
                AttackType = (AttackTypeEnum)x.AttackType,
                TransType = x.TransType,
                DPv = x.DPv,
                MPv = x.MPv,
                RPv = x.RPv,
                DDv = x.DDv,
                MDv = x.MDv,
                RDv = x.RDv,
                SubDDWhenCritical = x.SubDDwhenCritical,
                EnemySubCriticalHit = x.EnemySubCriticalHit,
                EventQuest = x.EventQuest,
                //AbnormalAdds = AbnormalAdds
                //    .Where(a => _parmContext.MonsterAbnormalAdds.Any(sa => sa.MonsterId == x.Id && sa.AbnormalId == a.Id))
                //    .ToList(),
                //AbnormalResists = AbnormalResists
                //    .Where(a => _parmContext.MonsterAbnormalResists.Any(sa => sa.MonsterId == x.Id && sa.AbnormalId == a.Id))
                //    .ToList(),
                //AttributeAdds = AttributeAdds
                //    .Where(a => _parmContext.MonsterAttributeAdds.Any(sa => sa.MonsterId == x.Id && sa.AttributeId == a.Id))
                //    .ToList(),
                //AttributeResists = AttributeResists
                //    .Where(a => _parmContext.MonsterAttributeResists.Any(sa => sa.MonsterId == x.Id))
                //    .ToList(),
                //Drops = MonsterDrops
                //    .Where(a => _parmContext.MonsterDrops.Any(sa => sa.MonsterId == x.Id))
                //    .ToList(),
                //Protects = new List<Protect>(),
                //Slains = Slains
                //    .Where(a => _parmContext.MonsterSlains.Any(sa => sa.MonsterId == x.Id))
                //    .ToList(),
                //Roles = _parmContext.MonsterRoles.Where(mr => mr.MonsterId == x.Id).Select(x => (NpcRoleEnum)x.MonsterRole).ToList(),
                //Spots = MonsterSpots.Where(ms => ms.MonsterId == x.Id).ToList()

            }).ToList();
            foreach (var monster in Monsters)
            {
                var mAbnormalAdds = monsterAbnormalAdds.Where(x => x.MonsterId == monster.Id).ToList();
                var mAbnormalResists = monsterAbnormalResists.Where(x => x.MonsterId == monster.Id).ToList();
                var mAttributeAdds = monsterAttributeAdds.Where(x => x.MonsterId == monster.Id).ToList();
                var mAttributeResists = monsterAttributeResists.Where(x => x.MonsterId == monster.Id).ToList();
                var mDrops = monsterDrops.Where(x => x.MonsterId == monster.Id).ToList();
                var mSlains = monsterSlains.Where(x => x.MonsterId == monster.Id).ToList();

                monster.AbnormalAdds = AbnormalAdds
                    .Where(a => mAbnormalAdds.Any(sa => sa.AbnormalId == a.Id))
                    .ToList();
                monster.AbnormalResists = AbnormalResists
                    .Where(a => mAbnormalResists.Any(sa => sa.AbnormalId == a.Id))
                    .ToList();
                monster.AttributeAdds = AttributeAdds
                    .Where(a => mAttributeAdds.Any(sa => sa.AttributeId == a.Id))
                    .ToList();
                monster.AttributeResists = AttributeResists
                    .Where(a => mAttributeResists.Any(sa => sa.AttributeId == a.Id))
                    .ToList();
                monster.Drops = MonsterDrops
                    .Where(x => x.MonsterId == monster.Id)
                    .ToList();
                monster.Slains = Slains
                    .Where(a => mSlains.Any(sa => sa.SlainId == a.Id))
                    .ToList();

                monster.Roles = monsterRoles.Where(mr => mr.MonsterId == monster.Id).Select(x => (NpcRoleEnum)x.MonsterRole).ToList();
                //monster.Spots = MonsterSpots.Where(ms => ms.MonsterId == monster.Id).ToList();
                //Protects = new List<Protect>();

            }

            var qwe = _parmContext.MonsterSpots.ToList();
        }

        #region Character
        /// <summary>
        ///     Get character position by class
        /// </summary>
        /// <param name="characterType"></param>
        /// <returns></returns>
        public GCharacterPosition GetCharacterPositionByClass(CharacterTypeEnum characterType)
        {
            GCharacterPosition characterPositionGame = new GCharacterPosition();

            CharacterPositionModel characterPosition = _parmContext.CharacterPositions.First(cp => cp.Class == (int)characterType);
            _parmMappingService.MapCharacterPositionGame(characterPositionGame, characterPosition);

            return characterPositionGame;
        }
        #endregion

        #region Exp
        /// <summary>
        ///     Get exp by lvl
        /// </summary>
        /// <param name="level"></param>
        public GExp GetExpByLvl(long level)
        {
            GExp expGame = new GExp();

            ExpModel exp = Exps.First(e => e.Level == level);
            _parmMappingService.MapExpGame(expGame, exp);

            return expGame;
        }
        #endregion

        #region Item
        /// <summary>
        ///     Get item by id
        /// </summary>
        /// <param name="itemId"></param>
        /// <returns></returns>
        public Item GetItemById(int itemId)
        {
            Item item = Items.FirstOrDefault(i => i.Id == itemId);

            if (item == null)
            {
                return null;
            }

            return item;
        }

        /// <summary>
        ///     Get GItem by id
        /// </summary>
        /// <param name="itemId"></param>
        /// <returns></returns>
        public GItem GetGItemById(int itemId)
        {
            Item item = Items.FirstOrDefault(i => i.Id == itemId);

            if (item == null)
            {
                return null;
            }

            GItem itemGame = new GItem(item);

            _parmMappingService.MapItemGame(itemGame, item);

            return itemGame;
        }

        #endregion

        #region Monster
        public List<GMonster> GetAllMonsters()
        {
            List<GMonster> monsters = new List<GMonster>();

            foreach (var monster in Monsters)
            {
                var monsterGame = new GMonster();
                _parmMappingService.MapMonstertGame(monsterGame, monster);
                monsters.Add(monsterGame);
            }

            return monsters;
        }

        /// <summary>
        ///     Get unit by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public GMonster GetGMonsterById(int id)
        {
            GMonster monsterGame = new GMonster();

            Monster monster = Monsters.First(u => u.Id == id);
            _parmMappingService.MapMonstertGame(monsterGame, monster);

            return monsterGame;
        }

        /// <summary>
        ///     Get unit by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ParmMonster GetMonsterById(int id)
        {
            Monster monster = Monsters.First(u => u.Id == id);

            var monsterGame = new ParmMonster(monster);

            return monsterGame;
        }

        /// <summary>
        ///     Get unit by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<MonsterSpot> GetAllMonsterSpots()
        {
            var monsterSpots = MonsterSpots.ToList();

            return monsterSpots;
        }
        #endregion
    }
}
