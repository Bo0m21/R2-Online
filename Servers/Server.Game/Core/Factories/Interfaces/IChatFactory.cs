using Packets.Server.Game.Models.Receive.Chat;
using Server.Game.Network;

namespace Server.Game.Core.Factories.Interfaces
{
    public interface IChatFactory
    {
        public void SendMessage(GameSession clientFrom, GameSession clientTo, ChatReqModel model);
        
        public void SendMessageToGlobalChat(GameSession clientFrom, GameSession clientTo, GlobalChatReqModel model);
        
        public void SendEmoticon(GameSession clientFrom, GameSession clientTo, EmoticonReqModel model);
    }
}
