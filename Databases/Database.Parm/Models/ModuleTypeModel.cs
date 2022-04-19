using System;
using System.Collections.Generic;

#nullable disable

namespace Database.Parm.Models
{
    public partial class ModuleTypeModel
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string AparamName { get; set; }
        public string BparamName { get; set; }
        public string CparamName { get; set; }
    }
}
