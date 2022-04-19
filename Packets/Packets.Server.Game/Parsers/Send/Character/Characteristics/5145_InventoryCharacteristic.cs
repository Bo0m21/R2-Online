using Packets.Core.Attributes;
using Packets.Core.Utilities;
using Packets.Server.Game.Models.Send.Character.Characteristics;

namespace Packets.Server.Game.Parsers.Send.Character.Characteristics
{
    /// <summary>
    ///     Parser charactiristic in inventory
    /// </summary>
    [ParserSend]
    public class InventoryCharacteristic
    {
        [ParserAction(Core.Enums.PacketType.InventoryCharacteristic)]
        public byte[] Parsing(InventoryCharacteristicModel model)
        {
            FormationPackage formationPackage = new FormationPackage();

            formationPackage.AddShort(model.DDv);
            formationPackage.AddShort(model.MDv);
            formationPackage.AddShort(model.RDv);

            formationPackage.AddShort(model.DPv);
            formationPackage.AddShort(model.MPv);
            formationPackage.AddShort(model.RPv);

            formationPackage.AddShort(model.DDD);
            formationPackage.AddShort(model.DHit);

            formationPackage.AddShort(model.RDD);
            formationPackage.AddShort(model.RHit);

            formationPackage.AddShort(model.MDD);
            formationPackage.AddShort(model.MHit);

            formationPackage.AddShort(model.Str);
            formationPackage.AddShort(model.Dex);
            formationPackage.AddShort(model.Int);

            formationPackage.AddShort(model.CriticalHit);

            formationPackage.AddInteger(model.HpMax);
            formationPackage.AddInteger(model.MpMax);

            formationPackage.AddZeroBytes(10);

            return formationPackage.GetBytes();
        }
    }
}