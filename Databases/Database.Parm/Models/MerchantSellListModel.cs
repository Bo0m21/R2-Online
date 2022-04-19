using System;
using System.Collections.Generic;

#nullable disable

namespace Database.Parm.Models
{
    public partial class MerchantSellListModel
    {
        public int MIndex { get; set; }
        public int ListId { get; set; }
        public int ItemId { get; set; }
        public int Price { get; set; }
        public int Flag { get; set; }
        public int SortKey { get; set; }
        public int LimitCnt { get; set; }
    }
}
