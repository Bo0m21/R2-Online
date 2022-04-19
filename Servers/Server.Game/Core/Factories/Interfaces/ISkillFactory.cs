using Packets.Server.Game.Models.Send.Action;
using Server.Game.Network;

namespace Server.Game.Core.Factories.Interfaces
{
    public interface ISkillFactory
    {
        void SendUseSkillPack(GameSession client, UseSkillPackAckModel model);
    }
}
