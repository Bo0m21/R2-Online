using System;

namespace Database.Game.Models
{
    public partial class PcFriend
    {
        public DateTime RegDate { get; set; }
        public int OwnerPcNo { get; set; }
        public int FriendPcNo { get; set; }
        public string FriendPcNm { get; set; }

        public virtual Pc OwnerPcNoNavigation { get; set; }
    }
}
