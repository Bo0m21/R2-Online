using Database.Balance.Enums;

namespace Database.Balance.Models
{
    /// <summary>
    ///     Character model
    /// </summary>
    public class CharacterModel
    {
        public CharacterModel()
        {
            
        }

        public int Id { get; set; }

        /// <summary>
        ///     Character class
        /// </summary>
        public CharacterType Class { get; set; }

        /// <summary>
        ///     Level
        /// </summary>
        public short Level { get; set; }

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
        ///     Health point max
        /// </summary>
        public short HpMax { get; set; }

        /// <summary>
        ///     Health point regen
        /// </summary>
        public short HpRegen { get; set; }

        /// <summary>
        ///     Magic point max
        /// </summary>
        public short MpMax { get; set; }

        /// <summary>
        ///     Magic point regen
        /// </summary>
        public short MpRegen { get; set; }

        /// <summary>
        ///     Weight max
        /// </summary>
        public short WeightMax { get; set; }

        /// <summary>
        ///     Attack rate
        /// </summary>
        public short AttackRate { get; set; }

        /// <summary>
        ///     Move rate
        /// </summary>
        public short MoveRate { get; set; }
    }
}
