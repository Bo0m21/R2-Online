using Database.DataModel.Enums;
using Packets.Server.Game.Structures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Game.Models.Game
{
    public class GPcDetail
    {
		public short DDv { get; set; }
		public short MDv { get; set; }
		public short RDv { get; set; }
		public short DPv { get; set; }
		public short MPv { get; set; }
		public short RPv { get; set; }
		public short Hit { get; set; }
		public short MinD { get; set; }
		public short MaxD { get; set; }
		public short AttackRate { get; set; }
		public short MoveRate { get; set; }
		public Vector3 HomePos { get; set; }
		public uint PkCnt { get; set; }
		public short Chaotic { get; set; }
		public ChaoticStatusEnum ChaoticStatus { get; set; }
		public int LetterLimit { get; set; }
		public short VolitionOfHonor { get; set; }
		public int HonorPoint { get; set; }
		public long ChaosPoint { get; set; }

		public void SetChaotic(int chaoticScore)
        {
			Chaotic = (short)chaoticScore;
			if (chaoticScore == 30000)
				ChaoticStatus = ChaoticStatusEnum.Chaotic3;
			else if (chaoticScore >= 20000)
				ChaoticStatus = ChaoticStatusEnum.Chaotic2;
			else if (chaoticScore >= 10000)
				ChaoticStatus = ChaoticStatusEnum.Chaotic1;
			else if (chaoticScore >= 0)
				ChaoticStatus = ChaoticStatusEnum.Normal;
			else if (chaoticScore >= 10000)
				ChaoticStatus = ChaoticStatusEnum.Low1;
			else if (chaoticScore >= -20000)
				ChaoticStatus = ChaoticStatusEnum.Low2;
			else if (chaoticScore == -30000)
				ChaoticStatus = ChaoticStatusEnum.Low3;
		}
	}
}
