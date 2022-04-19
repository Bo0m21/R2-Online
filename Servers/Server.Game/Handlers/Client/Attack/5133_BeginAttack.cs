using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Core.Models;

namespace Server.Game.Handlers.Client.Attack
{
    /// <summary>
    ///     Обработчик пакета начала атаки
    /// </summary>
    public class BeginAttack : AcHandler<BeginAttackModel>
    {
        public override int Code { get; set; } = 5133;

        public override IEnumerable<int> Treatment(ConnectionModel connection, BeginAttackModel model)
        {
            // Получение видимых персонажей
            var visibleConnections = GameConnections.GetGameConnections()
                .GetVisibleGameConnections(connection.GameConnection).ToList();

            // TODO проверять зону видимости


            var visibleconnection = visibleConnections.FirstOrDefault(c => c.Id == model.AttackSessionGameId);

            if (visibleconnection == null)
            {
                return new List<int>();
            }

            connection.GameConnection.AttackedConnection = visibleconnection;

            Task.Run(() =>
            {
                var attackedConnection = visibleconnection;

                while (true)
                {
                    // Получение видимых соединений
                    var visibleConnections1 = GameConnections.GetGameConnections()
                        .GetVisibleGameConnections(connection.GameConnection).ToList();

                    // Отправляем завершение атаки всем кого видим
                    if (attackedConnection.Id != connection.GameConnection.AttackedConnection?.Id)
                    {
                        foreach (var visibleConnection1 in visibleConnections1)
                        {
                            TreatmentPackets.Send(visibleConnection1.Connection, 5134, new EndAttackModel
                            {
                                SessionGameId = connection.GameConnection.Id
                            });
                        }

                        break;
                    }

                    // Атака TODO пернести в метод
                    attackedConnection.Character.HealthPoint -=
                        (short) (connection.GameConnection.Character.Attack - attackedConnection.Character.Defence / 2);

                    // Отправляем атакующему его новое хп
                    TreatmentPackets.Send(attackedConnection.Connection, 5146, new HealthPointCharacteristicsModel
                    {
                        HealthPoint = attackedConnection.Character.HealthPoint,
                        MagicPoint = attackedConnection.Character.MagicPoint
                    });


                    // Отправляем атаку всем кого видим
                    foreach (var visibleConnection1 in visibleConnections1)
                    {
                        TreatmentPackets.Send(visibleConnection1.Connection, 5132, new AttackModel
                        {
                            SessionGameId = connection.GameConnection.Id,
                            AttackSessionGameId = attackedConnection.Id,
                            Hit = true,
                            CoordinateX = connection.GameConnection.Character.CoordinateX,
                            CoordinateZ = connection.GameConnection.Character.CoordinateZ,
                            CoordinateY = connection.GameConnection.Character.CoordinateY
                        });
                    }

                    // Задержка атаки
                    Thread.Sleep(connection.GameConnection.Character.SpeedAttack);
                }
            });

            return new List<int>();
        }
    }
}