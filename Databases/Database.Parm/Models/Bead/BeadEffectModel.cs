namespace Database.Parm.Models
{
    public partial class BeadEffectModel
    {
        public int BeadNo { get; set; }
        public string Name { get; set; }
        public int BeadType { get; set; }
        public byte ChkGroup { get; set; }
        public double Percent { get; set; }
        public byte ApplyTarget { get; set; }
        public int ParamA { get; set; }
        public int ParamB { get; set; }
        public int ParamC { get; set; }
        public int ParamD { get; set; }
        public int ParamE { get; set; }
    }
}
