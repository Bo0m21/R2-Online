using Packets.Core.Enums;
using Packets.Server.Game.Models.Send;
using Server.Game.Network;

namespace Server.Game.Core.Factories.Interfaces
{
    public interface IErrorFactory
    {
        void SendServerError(GameSession client, PacketType packet, GameServerErrorType gameServerError, bool isMsgBox);
    }
}