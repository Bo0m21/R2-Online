using Packets.Server.Game.Models.Send.Action;
using Server.Game.Core.Factories.Interfaces;
using Server.Game.Network;

namespace Server.Game.Core.Factories
{
    public class SkillFactory : ISkillFactory
    {
        public void SendUseSkillPack(GameSession client, UseSkillPackAckModel model)
        {
            UseSkillPackAckModel useSkillPackAckModel = new UseSkillPackAckModel()
            {
                SkillId = model.SkillId
            };

            client.Send(useSkillPackAckModel);
        }
    }
}
