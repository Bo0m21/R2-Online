using System.Collections.Generic;
using Core.Models;

namespace Server.Game.Handlers.Client.Chat
{
    /// <summary>
    ///     Обработчик пакета сообщения в чат
    /// </summary>
    public class SendMessage : AcHandler<SendMessageModel>
    {
        public override int Code { get; set; } = 2033;

        public override IEnumerable<int> Treatment(ConnectionModel connection, SendMessageModel model)
        {
            // Обработка сообщений общего чата
            ChatService.TreatmentCommonChat(connection, model);

            return new List<int>();
        }
    }
}