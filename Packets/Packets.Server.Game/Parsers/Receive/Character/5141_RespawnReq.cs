using Packets.Core.Attributes;
using Packets.Core.Enums;
using Packets.Core.Utilities;
using Packets.Server.Game.Models.Receive.Character;

namespace Packets.Server.Game.Parsers.Receive.Character
{
    /// <summary>
    ///     Parser for respawn req
    /// </summary>
    [ParserReceive]
    public class RespawnReq
    {
        [ParserAction(PacketType.RespawnReq)]
        public RespawnReqModel Parsing(byte[] data)
        {
            RespawnReqModel respawnReqModel = new RespawnReqModel();

            FormationPackage formationPackage = new FormationPackage(data);
            respawnReqModel.IsRespawn = formationPackage.ReadByte();

            return respawnReqModel;
        }
    }
}