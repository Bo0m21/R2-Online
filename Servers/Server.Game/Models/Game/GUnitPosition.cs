using Packets.Server.Game.Structures;

namespace Server.Game.Models.Game
{
    /// <summary>
    ///     Unit position game model
    /// </summary>
    public class GUnitPosition
    {
        /// <summary>
        ///     Unit id
        /// </summary>
        public int UnitId { get; set; }

        /// <summary>
        ///     Position
        /// </summary>
        public Vector3 Position { get; set; }

        /// <summary>
        ///     Direction sight
        /// </summary>
        public float DirectionSight { get; set; }

        /// <summary>
        ///     Millisecond to respawn
        /// </summary>
        public int Respawn { get; set; }
    }
}
