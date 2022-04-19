using Packets.Core.Enums;
using Packets.Server.Game.Models.Send;
using Server.Game.Core.Factories.Interfaces;
using Server.Game.Network;

namespace Server.Game.Core.Factories
{
    public class ErrorFactory : IErrorFactory
    {
        public void SendServerError(GameSession client, PacketType packet, GameServerErrorType gameServerError, bool isMsgBox)
        {
            GameServerErrorModel gameServerErrorModel = new GameServerErrorModel
            {
                PacketType = packet,
                ErrorType = gameServerError,
                IsMsgBox = isMsgBox
            };

            client.Send(gameServerErrorModel);
        }
    }
}
