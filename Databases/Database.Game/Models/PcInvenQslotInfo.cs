using System;
using System.Collections.Generic;

namespace Database.Game.Models
{
    public partial class PcInvenQslotInfo
    {
        public DateTime UpdateDate { get; set; }
        public int PcNo { get; set; }
        public byte[] Info { get; set; }

        public virtual Pc PcNoNavigation { get; set; }
    }
}
