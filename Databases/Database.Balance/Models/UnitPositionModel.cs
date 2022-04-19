namespace Database.Balance.Models
{
    /// <summary>
    ///     Unit position model
    /// </summary>
    public class UnitPositionModel
    {
        public UnitPositionModel()
        {

        }

        public int Id { get; set; }

        /// <summary>
        ///     Unit id
        /// </summary>
        public int UnitId { get; set; }

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

        /// <summary>
        ///     Direction sight
        /// </summary>
        public float DirectionSight { get; set; }

        /// <summary>
        ///     Millisecond to respawn
        /// </summary>
        public int Respawn { get; set; }

        /// <summary>
        ///     Unit
        /// </summary>
        public UnitModel Unit { get; set; }
    }
}
