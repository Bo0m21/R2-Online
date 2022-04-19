using Packets.Server.Game.Models.Receive.Inventory;
using Server.Game.Network;

namespace Server.Game.Core.Handlers.Interfaces
{
    public interface IEquipHandler
    {
        void Equip(GameSession client, EquipReqModel wearEquipReqModel);

        void UnEquip(GameSession client, UnEquipReqModel unEquipReqModel);
    }
}
