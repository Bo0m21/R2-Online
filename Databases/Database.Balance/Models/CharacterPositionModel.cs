using Database.Balance.Enums;

namespace Database.Balance.Models
{
    /// <summary>
    ///     Character position model
    /// </summary>
    public class CharacterPositionModel
    {
        public CharacterPositionModel()
        {

        }

        public int Id { get; set; }

        /// <summary>
        ///     Character class
        /// </summary>
        public CharacterType Class { get; set; }

        /// <summary>
        ///     X
        /// </summary>
        public float X { get; set; }

        /// <summary>
        ///     Z
        /// </summary>
        public float Z { get; set; }

        /// <summary>
        ///     Y
        /// </summary>
        public float Y { get; set; }
    }
}
