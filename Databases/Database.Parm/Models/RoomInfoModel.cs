using System;
using System.Collections.Generic;

#nullable disable

namespace Database.Parm.Models
{
    public partial class RoomInfoModel
    {
        public int? Id { get; set; }
        public string RoomName { get; set; }
        public byte Type { get; set; }
        public short MapNo { get; set; }
        public int KeyItemId { get; set; }
    }
}
