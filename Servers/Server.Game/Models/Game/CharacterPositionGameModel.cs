using Database.Balance.Enums;
using Packets.Server.Game.Structures;

namespace Server.Game.Models.Game
{
    /// <summary>
    ///     Character position game model
    /// </summary>
    public class CharacterPositionGameModel
    {
        /// <summary>
        ///     Character class
        /// </summary>
        public CharacterType Class { get; set; }

        /// <summary>
        ///     Position
        /// </summary>
        public Vector3 Position { get; set; }
    }
}
