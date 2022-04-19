using Packets.Core.Attributes;
using Packets.Core.Enums;

namespace Packets.Server.Game.Models.Send
{
    /// <summary>
    ///     Model serevr error
    /// </summary>
    [Model(PacketType.GameServerError)]
    public class GameServerErrorModel
    {
        public PacketType PacketType { get; set; }
        public GameServerErrorType ErrorType { get; set; }
        public bool IsMsgBox { get; set; }
    }

    /// <summary>
    ///     Enum for server type
    /// </summary>
    public enum GameServerErrorType : uint
    {
        NoUserNotLogin = 3461165659,
        NoUserChkAlreadyLogined = 4032203570,
        NoCharInvalidSlot = 2056329710,
        NoUserCharSlotBusy = 3519830633,
        NoCharAlreadyExistNm = 3275693591,
        NoCharCannotDel = 1325539862,
        NoCharInvalidNo = 2492253689,
        NoSvrInvalidNo = 708090742,
        HackerDetected = 3850774223,
        ItemInvalid = 67173391,
        NoItemTooHeavy = 3377358065,
        NoBeadHoleFull = 2456118758,
        NoReinforce = 4243148749,
        UnknownError = 3811631602,
    }
}