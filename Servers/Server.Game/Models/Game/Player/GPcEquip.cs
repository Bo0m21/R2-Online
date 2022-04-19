using Database.DataModel.Enums;
using Database.DataModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Game.Models.Game
{
    public class GPcEquip
    {
        public GItem Item;
        public ulong SerialNo;
        public int IsConfirm;
        public ItemStatusEnum Status;
        public bool IsEquip;
        public bool IsSeal;
    }
}
