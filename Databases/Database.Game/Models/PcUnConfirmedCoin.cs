using System;

namespace Database.Game.Models
{
    public partial class PcUnConfirmedCoin
    {
        public DateTime RegDate { get; set; }
        public int PcNo { get; set; }
        public int Coin { get; set; }
    }
}
