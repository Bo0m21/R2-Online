using System;
using Core.Models;

namespace Server.Game.Handlers.Server.Settings
{
    /// <summary>
    ///     Обработчик пакета времени сервера
    /// </summary>
    public class ServerTime : AsHandler<ServerTimeModel>
    {
        public override int Code { get; set; } = 5652;

        public override ServerTimeModel Treatment(ConnectionModel connection)
        {
            // Время сервера
            DateTime dateTime = DateTime.Now;

            var serverTimeModel = new ServerTimeModel
            {
                Year = (short) dateTime.Year,
                Month = (short) dateTime.Month,
                DayOfWeek = (short) dateTime.DayOfWeek,
                Day = (short) dateTime.Day,
                Hour = (short) dateTime.Hour,
                Minute = (short) dateTime.Minute,
                Second = (short) dateTime.Second,
                Millisecond = (short) dateTime.Millisecond
            };

            return serverTimeModel;
        }
    }
}