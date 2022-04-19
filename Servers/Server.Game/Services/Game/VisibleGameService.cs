using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Packets.Server.Game.Enums;
using Server.Game.Core.Factories.Interfaces;
using Server.Game.Models.Settings;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Server.Game.Services.GameServices
{
    /// <summary>
    ///     Visible game service
    /// </summary>
    public class VisibleGameService : IHostedService
    {
        private readonly GameSetting _gameSetting;
        private readonly IVisibleFactory _visibleFactory;
        private readonly IdentificationService _identificationService;

        public VisibleGameService(IOptions<GameSetting> gameSetting, IVisibleFactory visibleFactory, IdentificationService identificationService)
        {
            _gameSetting = gameSetting.Value;
            _visibleFactory = visibleFactory;
            _identificationService = identificationService;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            VisibleConnections();
            VisibleItems();
            VisibleUnits();

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        /// <summary>
        ///     Visible connections
        /// </summary>
        private void VisibleConnections()
        {
            Task.Run(() =>
            {
                while (true)
                {
                    try
                    {
                        var connections = _identificationService.GetAllConnections().Where(c => c.Pc != null);

                        foreach (var connection in connections)
                        {
                            // Get all visible connections
                            var visibleConnections = connections.Where(c => c != connection && c.Pc.PositionCur.Distance(connection.Pc.PositionCur) <= _gameSetting.VisibleConnections).ToList();

                            // Get new or old connections
                            var newVisibleConnections = visibleConnections.Where(c => c.Pc.IsVsibleFirst == true);
                            var lastVisibleConnections = visibleConnections.Where(c => c.Pc.IsVsibleFirst == false);

                            // TODO add is teleport or new ifelse

                            // Send me displayed details
                            if (connection.Pc.IsVsibleFirst)
                            {
                                _visibleFactory.SendDisplayedDetailsCharacter(connection, connection);
                            }

                            foreach (var newVisibleConnection in newVisibleConnections)
                            {
                                _visibleFactory.SendDisplayedDetailsCharacter(newVisibleConnection, connection);
                            }

                            // Get appear connections
                            var appearConnections = lastVisibleConnections.Except(connection.Pc.VisibleCharacterGames);

                            var count = appearConnections.Count() % 45;
                            for (int i = 0; i < count; i++)
                            {
                                _visibleFactory.SendDisplayedCharacters(appearConnections.Skip(i * 45).Take(45).ToList(), connection);
                            }

                            // Get disappear connections
                            var disappearConnections = connection.Pc.VisibleCharacterGames.Except(visibleConnections);

                            foreach (var disappearConnection in disappearConnections)
                            {
                                _visibleFactory.SendExitMap(connection, disappearConnection.Pc.UniqueId, ExitMapWhy.None);
                            }

                            connection.Pc.VisibleCharacterGames = visibleConnections;
                        }

                        // Reset is vsible first
                        foreach (var connection in connections)
                        {
                            if (connection.Pc.IsVsibleFirst)
                            {
                                connection.Pc.IsVsibleFirst = false;
                            }
                        }
                    }
                    catch (Exception ex)
                    {

                    }

                    Thread.Sleep(100);
                }
            });
        }

        /// <summary>
        ///     Visible items
        /// </summary>
        private void VisibleItems()
        {
            Task.Run(() =>
            {
                while (true)
                {
                    try
                    {
                        var connections = _identificationService.GetAllConnections().Where(c => c.Pc != null);
                        var items = _identificationService.GetAllItems();

                        // Visible items for connection
                        foreach (var connection in connections)
                        {
                            // Get all visible items
                            var visibleItems = items.Where(i => i.Position.Distance(connection.Pc.PositionCur) <= _gameSetting.VisibleItems).ToList();

                            // Get new or old items
                            var newVisibleItems = visibleItems.Where(i => i.IsVsibleFirst == true);
                            var lastVisibleItems = visibleItems.Where(i => i.IsVsibleFirst == false);

                            foreach (var newVisibleItem in newVisibleItems)
                            {
                                _visibleFactory.SendDisplayedDetailsItem(connection, newVisibleItem);
                            }

                            // Get appear items
                            var appearItems = lastVisibleItems.Except(connection.Pc.VisibleItemGames);

                            var count = appearItems.Count() % 45;
                            for (int i = 0; i < count; i++)
                            {
                                _visibleFactory.SendDisplayedItems(connection, appearItems.Skip(i * 45).Take(45).ToList());
                            }

                            // Get disappear items
                            var disappearItems = connection.Pc.VisibleItemGames.Except(visibleItems);

                            foreach (var exitItem in disappearItems)
                            {
                                _visibleFactory.SendExitMap(connection, exitItem.UniqueId, ExitMapWhy.None);
                            }

                            connection.Pc.VisibleItemGames = visibleItems;
                        }

                        // Visible connections for item
                        foreach (var item in items)
                        {
                            // Get all visible connections
                            var visibleConnections = connections.Where(i => i.Pc.PositionCur.Distance(item.Position) <= _gameSetting.VisibleUnits).ToList();

                            item.VisibleCharacterGames = visibleConnections;
                        }

                        // Reset is vsible first
                        foreach (var item in items)
                        {
                            if (item.IsVsibleFirst)
                            {
                                item.IsVsibleFirst = false;
                            }
                        }
                    }
                    catch (Exception ex)
                    {

                    }

                    Thread.Sleep(100);
                }
            });
        }

        /// <summary>
        ///     Visible units
        /// </summary>
        private void VisibleUnits()
        {
            Task.Run(() =>
            {
                while (true)
                {
                    try
                    {
                        var connections = _identificationService.GetAllConnections().Where(c => c.Pc != null);
                        var units = _identificationService.GetAllUnits();

                        // Visible units for connection
                        foreach (var connection in connections)
                        {
                            // Get all visible unts
                            var visibleUnits = units.Where(i => i.PositionCur.Distance(connection.Pc.PositionCur) <= _gameSetting.VisibleUnits).ToList();

                            // Get new or old units
                            var newVisibleUnits = visibleUnits.Where(u => u.IsVsibleFirst == true);
                            var lastVisibleUnits = visibleUnits.Where(u => u.IsVsibleFirst == false);

                            foreach (var newVisibleUnit in newVisibleUnits)
                            {
                                _visibleFactory.SendDisplayedDetailsUnit(connection, newVisibleUnit);
                            }

                            // Get appear units
                            var appearUnits = lastVisibleUnits.Except(connection.Pc.VisibleUnitGames);

                            var count = appearUnits.Count() % 45;
                            for (int i = 0; i < count; i++)
                            {
                                _visibleFactory.SendDisplayedUnit(connection, appearUnits.Skip(i * 45).Take(45).ToList());
                            }

                            // Get disappear units
                            var disappearUnits = connection.Pc.VisibleUnitGames.Except(visibleUnits);

                            foreach (var exitUnit in disappearUnits)
                            {
                                _visibleFactory.SendExitMap(connection, exitUnit.UniqueId, ExitMapWhy.None);
                            }

                            connection.Pc.VisibleUnitGames = visibleUnits;
                        }

                        // Visible connections for unit
                        foreach (var unit in units)
                        {
                            // Get all visible connections
                            var visibleConnections = connections.Where(i => i.Pc.PositionCur.Distance(unit.PositionCur) <= _gameSetting.VisibleUnits).ToList();

                            unit.VisibleCharacterGames = visibleConnections;
                        }

                        // Reset is vsible first
                        foreach (var unit in units)
                        {
                            if (unit.IsVsibleFirst)
                            {
                                unit.IsVsibleFirst = false;
                            }
                        }
                    }
                    catch (Exception ex)
                    {

                    }

                    Thread.Sleep(100);
                }
            });
        }
    }
}
