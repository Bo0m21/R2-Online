using Packets.Server.Game.Models.Receive.Chat;
using Packets.Server.Game.Models.Send.Chat;
using Server.Game.Core.Factories.Interfaces;
using Server.Game.Network;

namespace Server.Game.Core.Factories
{
    public class ChatFactory : IChatFactory
    {
        public void SendMessage(GameSession clientFrom, GameSession clientTo, ChatReqModel model)
        {
            ChatAckModel receiveMessageModel = new ChatAckModel()
            {
                Message = model.Message,
                Name = clientFrom.Pc.Simple.NickName,
                SessionGameId = clientFrom.Pc.UniqueId,
                Type = model.Type
            };

            clientTo.Send(receiveMessageModel);
        }

        public void SendMessageToGlobalChat(GameSession clientFrom, GameSession clientTo, GlobalChatReqModel model)
        {
            GlobalChatAckModel receiveMessageModel = new GlobalChatAckModel()
            {
                Message = model.Message,
                Name = clientFrom.Pc.Simple.NickName,
                SessionGameId = clientFrom.Pc.UniqueId,
            };

            clientTo.Send(receiveMessageModel);
        }

        public void SendEmoticon(GameSession clientFrom, GameSession clientTo, EmoticonReqModel model)
        {
            EmoticonAckModel emoticonAckModel = new EmoticonAckModel()
            {
                Type = model.Type,
                SessionGameId = clientFrom.Pc.UniqueId,
                Name = clientFrom.Pc.Simple.NickName
            };

            clientTo.Send(emoticonAckModel);
        }
    }
}
