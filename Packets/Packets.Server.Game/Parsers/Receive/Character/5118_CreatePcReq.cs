using Packets.Core.Attributes;
using Packets.Core.Enums;
using Packets.Core.Utilities;
using Packets.Server.Game.Models.Receive.Character;

namespace Packets.Server.Game.Parsers.Receive.Character
{
    /// <summary>
    ///     Parser for create pc
    /// </summary>
    [ParserReceive]
    public class CreateCharacter
    {
        [ParserAction(PacketType.CreatePcReq)]
        public CreatePcReqModel Parsing(byte[] data)
        {
            CreatePcReqModel createPcReqModel = new CreatePcReqModel();

            FormationPackage formationPackage = new FormationPackage(data);
            createPcReqModel.Slot = formationPackage.ReadByte();
            createPcReqModel.Class = formationPackage.ReadByte();
            createPcReqModel.Sex = formationPackage.ReadByte();
            createPcReqModel.Head = formationPackage.ReadByte();
            createPcReqModel.Face = formationPackage.ReadByte();
            createPcReqModel.TypeBody = formationPackage.ReadByte();
            createPcReqModel.Name = FormationPackageUtility.GetText(formationPackage.ReadBytes(13), 0);

            return createPcReqModel;
        }
    }
}