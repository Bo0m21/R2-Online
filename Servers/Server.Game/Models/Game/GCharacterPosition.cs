using Database.DataModel.Enums;
using Packets.Server.Game.Structures;

namespace Server.Game.Models.Game
{
    /// <summary>
    ///     Character position game model
    /// </summary>
    public class GCharacterPosition
    {
        /// <summary>
        ///     Character class
        /// </summary>
        public CharacterTypeEnum Class { get; set; }

        /// <summary>
        ///     Position
        /// </summary>
        public Vector3 Position { get; set; }
    }
}
