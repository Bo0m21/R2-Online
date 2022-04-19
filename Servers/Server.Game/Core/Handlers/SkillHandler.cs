using Packets.Server.Game.Models.Receive.Action;
using Server.Game.Core.Factories.Interfaces;
using Server.Game.Core.Handlers.Interfaces;
using System.Collections.Generic;
using Packets.Core.Attributes;
using Server.Game.Network;
using Packets.Core.Enums;
using System.Text;
using System;

namespace Server.Game.Core.Handlers
{
    [Handler]
    public class SkillHandler : ISkillHandler
    {
        private readonly ISkillFactory _skillFactory;

        public SkillHandler(ISkillFactory skillFactory)
        {
            _skillFactory = skillFactory;
        }

        [HandlerAction(PacketType.UseSkillPackReq)]
        public void SkillPackReq(GameSession client, UseSkillPackReqModel model)
        {

        }
    }
}
