using Database.DataModel.Enums;

namespace Server.Game.Models.Game
{
    public class GPcSimple
    {
		public byte Flag { get; set; }
		public uint PcNo { get; set; }
		public PcClassEnum Class { get; set; }
		public byte Sex { get; set; }
		public byte Head { get; set; }
		public byte Face { get; set; }
		public byte Body { get; set; }
		public uint GuildNo { get; set; }
		public uint GuildMarkSec { get; set; }
		public GuildGradeEnum GuildGrade { get; set; }
		public string GuildNickName { get; set; }
		public bool IsAtkTower { get; set; }
		public ushort DfnsBenefitLv { get; set; }
		public int DiscipleNo { get; set; }
		public DiscipleMemberTypeEnum DiscipleType { get; set; }
		public int Hp { get; set; }
		public int Mp { get; set; }
		public short Stomach { get; set; }
		public StomachStatusEnum StomachStatus { get; set; }
		public ulong Exp { get; set; }
		public ushort Level { get; set; }
		public string NickName { get; set; }
		public ChaosBattleSideEnum ChaosBattleSide { get; set; }
		public ushort FieldSvrNo { get; set; }
		public uint FieldSvrPcNo { get; set; }
		public ushort FieldSvrSeq { get; set; }
		public byte EmblemOfHonorSeq { get; set; }
		public ushort OldLevel { get; set; }
		public byte NationalFlagNo { get; set; }
		public byte EmblemOfHonorEffectSeq { get; set; }
		public byte TeamRankEffectSeq { get; set; }
		public UTGWMatchGroupEnum MatchGroup { get; set; }
		public long LevelupCoinExp { get; set; }
		public int LastReceiptSection { get; set; }

		public byte Slot { get; set; }

		public short CalcStr()
        {
            if (Class == PcClassEnum.Fighter)
				return (short)(Level / 3 + 15);
            else if (Class == PcClassEnum.Dragoon)
				return (short)(Level / 3 + 10);
			else if (Class == PcClassEnum.Wizard)
				return (short)(Level / 3 + 13);
			else if (Class == PcClassEnum.Assassin)
				return (short)(Level / 3 + 12);
			else
				return (short)(Level / 3 + 12);
		}

		public short CalcDex()
		{
			if (Class == PcClassEnum.Fighter)
				return (short)(Level / 3 + 10);
			else if (Class == PcClassEnum.Dragoon)
				return (short)(Level / 3 + 15);
			else if (Class == PcClassEnum.Wizard)
				return (short)(Level / 3 + 10);
			else if (Class == PcClassEnum.Assassin)
				return (short)(Level / 3 + 13);
			else
				return (short)(Level / 3 + 12);
		}

		public short CalcInt()
		{
			if (Class == PcClassEnum.Fighter)
				return (short)(Level / 3 + 10);
			else if (Class == PcClassEnum.Dragoon)
				return (short)(Level / 3 + 10);
			else if (Class == PcClassEnum.Wizard)
				return (short)(Level / 3 + 12);
			else if (Class == PcClassEnum.Assassin)
				return (short)(Level / 3 + 10);
			else
				return (short)(Level / 3 + 11);
		}

		public void SetStomach(short stomach)
        {
			Stomach = stomach;
			if (stomach >= 70)
			{
				StomachStatus = StomachStatusEnum.Full;
			}
			else if (stomach >= 1)
            {
				StomachStatus = StomachStatusEnum.Normal;
            }
            else
            {
				StomachStatus = StomachStatusEnum.Hungry;
			}
		}

		public void SetGuild()
        {

        }
	}
}
