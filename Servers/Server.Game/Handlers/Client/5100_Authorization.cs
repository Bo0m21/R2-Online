using System.Collections.Generic;
using Core.Models;

namespace Server.Game.Handlers.Client
{
    /// <summary>
    ///     Обработчик авторизации клиента по данным из пакета
    /// </summary>
    public class Authorization : AcHandler<AuthorizationModel>
    {
        public override int Code { get; set; } = 5100;

        public override IEnumerable<int> Treatment(ConnectionModel connection, AuthorizationModel model)
        {
            
        }
    }
}