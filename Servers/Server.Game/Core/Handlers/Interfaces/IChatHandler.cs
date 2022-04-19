using Packets.Server.Game.Models.Receive.Chat;
using Server.Game.Network;

namespace Server.Game.Core.Handlers.Interfaces
{
    public interface IChatHandler
    {
        public void ReceiveMessageHandle(GameSession client, ChatReqModel model);

        public void ReceiveMessageGChatHandle(GameSession client, GlobalChatReqModel model);

        public void ReceiveEmoticon(GameSession client, EmoticonReqModel model);
    }
}
