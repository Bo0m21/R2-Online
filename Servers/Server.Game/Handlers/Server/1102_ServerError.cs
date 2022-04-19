using Core.Models;

namespace Server.Game.Handlers.Server
{
    /// <summary>
    ///     Обработчик ошибки сервера
    /// </summary>
    public class ServerError : AsHandler<ServerErrorModel>
    {
        public override int Code { get; set; } = 1102;

        public override ServerErrorModel Treatment(ConnectionModel connection)
        {
            var model = new ServerErrorModel
            {
                Error = (Models.Server.ServerError) connection.ErrorCode
            };

            if (connection.ErrorCode == (uint) Models.Server.ServerError.NoUserNotLogin ||
                connection.ErrorCode == (uint) Models.Server.ServerError.NoUserChkAlreadyLogined)
            {
                connection.IsDisconnect = true;
            }

            return model;
        }
    }
}