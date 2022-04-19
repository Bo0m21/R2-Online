using System;
using System.Collections.Generic;

namespace Database.Game.Models
{
    public partial class Pc
    {
        public Pc()
        {
            PcAbnormals = new HashSet<PcAbnormal>();
            PcChatFilters = new HashSet<PcChatFilter>();
            PcFriends = new HashSet<PcFriend>();
            PcTeleports = new HashSet<PcTeleport>();
        }

        public DateTime RegDate { get; set; }
        public int Owner { get; set; }
        public byte Slot { get; set; }
        public int No { get; set; }
        public string NickName { get; set; }
        public byte Class { get; set; }
        public byte Sex { get; set; }
        public byte Head { get; set; }
        public byte Face { get; set; }
        public byte Body { get; set; }
        public int HomeMapNo { get; set; }
        public float HomePosX { get; set; }
        public float HomePosY { get; set; }
        public float HomePosZ { get; set; }
        public DateTime? DelDate { get; set; }

        public virtual PcDeleted PcDeleted { get; set; }
        public virtual PcInvenQslotInfo PcInvenQslotInfo { get; set; }
        public virtual PcState State { get; set; }
        public virtual ICollection<PcAbnormal> PcAbnormals { get; set; }
        public virtual ICollection<PcChatFilter> PcChatFilters { get; set; }
        public virtual ICollection<PcFriend> PcFriends { get; set; }
        public virtual ICollection<PcTeleport> PcTeleports { get; set; }
        public virtual ICollection<PcEquip> PcEquips { get; set; }
        public virtual ICollection<PcInventory> PcInventoryItems { get; set; }
    }
}
