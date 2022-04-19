namespace Database.Balance.Models
{
    /// <summary>
    ///     Exp model
    /// </summary>
    public class ExpModel
    {
        public ExpModel()
        {

        }

        public int Id { get; set; }

        /// <summary>
        ///     Level
        /// </summary>
        public short Level { get; set; }

        /// <summary>
        ///     Exp
        /// </summary>
        public long Exp { get; set; }
    }
}
