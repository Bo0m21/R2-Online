namespace Server.Game.Models.Game
{
    /// <summary>
    ///     Buff game model
    /// </summary>
    public class BuffGameModel
    {
        public BuffGameModel()
        {

        }

        /// <summary>
        ///     Buff id
        /// </summary>
        public int BuffId { get; set; }

        /// <summary>
        ///     Buff id
        /// </summary>
        public AbnormalType Type { get; set; }

        /// <summary>
        ///     Time in milliseconds
        /// </summary>
        public uint Time { get; set; }

        /// <summary>
        ///     Buff level
        /// </summary>
        public int Level { get; set; }

        /// <summary>
        ///     Time in milliseconds
        /// </summary>
        public uint EndTick { get; set; }

        /// <summary>
        ///     Buff name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     Is removable buff
        /// </summary>
        public bool IsRemovable { get; set; }

        #region Buff equip
        /// <summary>
        ///     Direct Damage value min
        /// </summary>
        public int DDvMin { get; set; }

        /// <summary>
        ///     Direct Damage value max
        /// </summary>
        public int DDvMax { get; set; }

        /// <summary>
        ///     Magic Damage value min
        /// </summary>
        public int MDvMin { get; set; }

        /// <summary>
        ///     Magic Damage value max
        /// </summary>
        public int MDvMax { get; set; }

        /// <summary>
        ///     Range Damage value min
        /// </summary>
        public int RDvMin { get; set; }

        /// <summary>
        ///     Range Damage value max
        /// </summary>
        public int RDvMax { get; set; }

        /// <summary>
        ///     Direct Protection value
        /// </summary>
        public int DPv { get; set; }

        /// <summary>
        ///     Magic Protection value
        /// </summary>
        public int MPv { get; set; }

        /// <summary>
        ///     Range Protection value
        /// </summary>
        public int RPv { get; set; }

        /// <summary>
        ///     Direct hit
        /// </summary>
        public int Dhit { get; set; }

        /// <summary>
        ///     Direct Damage dodge
        /// </summary>
        public int DDd { get; set; }

        /// <summary>
        ///     Range hit
        /// </summary>
        public int Rhit { get; set; }

        /// <summary>
        ///     Range Damage dodge
        /// </summary>
        public int RDd { get; set; }

        /// <summary>
        ///     Magic hit
        /// </summary>
        public int Mhit { get; set; }

        /// <summary>
        ///     Magic Damage dodge
        /// </summary>
        public int MDd { get; set; }

        /// <summary>
        ///     Critical
        /// </summary>
        public short Critical { get; set; }

        /// <summary>
        ///     Critical protect
        /// </summary>
        public short CriticalProtect { get; set; }

        /// <summary>
        ///     DDv critical add
        /// </summary>
        public short DDvCriticalAdd { get; set; }

        /// <summary>
        ///     DDv critical remove
        /// </summary>
        public short DDvCriticalRemove { get; set; }

        /// <summary>
        ///     Human killer
        /// </summary>
        public short HumanKiller { get; set; }

        /// <summary>
        ///     Human protect
        /// </summary>
        public short HumanProtect { get; set; }

        /// <summary>
        ///     Mob killer
        /// </summary>
        public short MobKiller { get; set; }

        /// <summary>
        ///     Mob protect
        /// </summary>
        public short MobProtect { get; set; }

        /// <summary>
        ///     Strength
        /// </summary>
        public short Str { get; set; }

        /// <summary>
        ///     Adroitness
        /// </summary>
        public short Dex { get; set; }

        /// <summary>
        ///     Intelligence
        /// </summary>
        public short Int { get; set; }

        /// <summary>
        ///     Health point
        /// </summary>
        public short Hp { get; set; }

        /// <summary>
        ///     Health point regen
        /// </summary>
        public short HpRegen { get; set; }

        /// <summary>
        ///     Hp potion restore
        /// </summary>
        public short HpPotionRestore { get; set; }

        /// <summary>
        ///     Add potion restore hp
        /// </summary>
        public short AddPotionRestoreHp { get; set; }

        /// <summary>
        ///     Add transform hp
        /// </summary>
        public short AddTransformMaxHp { get; set; }

        /// <summary>
        ///     Magic point
        /// </summary>
        public short Mp { get; set; }

        /// <summary>
        ///     Magic point regen
        /// </summary>
        public short MpRegen { get; set; }

        /// <summary>
        ///     Mp potion restore
        /// </summary>
        public short MpPotionRestore { get; set; }

        /// <summary>
        ///     Add potion restore mp
        /// </summary>
        public short AddPotionRestoreMp { get; set; }

        /// <summary>
        ///     Add transform max hp
        /// </summary>
        public short AddTransformMaxMp { get; set; }

        /// <summary>
        ///     Weight max
        /// </summary>
        public short WeightMax { get; set; }

        /// <summary>
        ///     Attack rate
        /// </summary>
        public short AttackRate { get; set; }

        /// <summary>
        ///     Attack speed when transform
        /// </summary>
        public short AttackRateWhenTransform { get; set; }

        /// <summary>
        ///     Move rate
        /// </summary>
        public short MoveRate { get; set; }

        /// <summary>
        ///     Move speed when transform
        /// </summary>
        public short MoveRateWhenTransform { get; set; }
        #endregion

        #region Premium
        /// <summary>
        ///     Increase exp
        /// </summary>
        public short IncExp { get; set; }
        /// <summary>
        ///     Increase drop
        /// </summary>
        public short IncDrop { get; set; }
        /// <summary>
        ///     Increase silver drop
        /// </summary>
        public short IncSilver { get; set; }
        #endregion
    }
}