using Packets.Server.Game.Enums;
using Packets.Server.Game.Structures;
using Server.Game.Models.Game;
using Server.Game.Network;
using System.Collections.Generic;
using System.Linq;

namespace Server.Game.Services
{
    /// <summary>
    ///     Identification service for working loading objects
    /// </summary>
    public class IdentificationService
    {
        /// <summary>
        ///     Lock object
        /// </summary>
        private object _lockObject = new object();

        /// <summary>
        ///     Unique identifiers unit
        /// </summary>
        private Queue<uint> _uniqueIdentifiers;

        /// <summary>
        ///     Unique identifiers counter
        /// </summary>
        private uint _uniqueIdentifiersCounter;

        /// <summary>
        ///     Connections in the game
        /// </summary>
        private Dictionary<UniqueId, GameSession> _connections;

        /// <summary>
        ///     Items in the game
        /// </summary>
        private Dictionary<UniqueId, GPublicItem> _items;

        /// <summary>
        ///     Units in the game
        /// </summary>
        private Dictionary<UniqueId, GMonster> _units;

        /// <summary>
        ///     Method for loading
        /// </summary>
        public IdentificationService()
        {
            _uniqueIdentifiers = new Queue<uint>();
            _uniqueIdentifiersCounter = 1;

            _connections = new Dictionary<UniqueId, GameSession>();
            _items = new Dictionary<UniqueId, GPublicItem>();
            _units = new Dictionary<UniqueId, GMonster>();
        }

        #region Connections
        /// <summary>
        ///     Add connection
        /// </summary>
        /// <param name="gameSession"></param>
        public void AddConnection(GameSession gameSession)
        {
            lock (_lockObject)
            {
                var uniqueIdentifier = GetUniqueIdentifier();

                gameSession.Pc.UniqueId = new UniqueId(UniqueIdentifierType.Player);
                gameSession.Pc.UniqueId.Id = uniqueIdentifier;

                _connections.Add(gameSession.Pc.UniqueId, gameSession);
            }
        }

        /// <summary>
        ///     Remove connection
        /// </summary>
        /// <param name="gameSession"></param>
        public void RemoveConnection(GameSession gameSession)
        {
            lock (_lockObject)
            {
                var uniqueIdentifier = _connections.FirstOrDefault(c => c.Value == gameSession).Key;

                if (uniqueIdentifier != null)
                {
                    RemoveUniqueIdentifier(uniqueIdentifier.Id);
                    _connections.Remove(uniqueIdentifier);
                }
            }
        }

        /// <summary>
        ///     Get all connections
        /// </summary>
        /// <returns></returns>
        public List<GameSession> GetAllConnections()
        {
            lock (_lockObject)
            {
                return _connections.Values.ToList();
            }
        }

        /// <summary>
        ///     Get connection by unique identifier
        /// </summary>
        /// <param name="uniqueIdentifier"></param>
        /// <returns></returns>
        public GameSession GetConnectionByUniqueIdentifier(UniqueId uniqueIdentifier)
        {
            lock (_lockObject)
            {
                return _connections.FirstOrDefault(c => c.Key.Id == uniqueIdentifier.Id).Value;
            }
        }

        /// <summary>
        ///     Get connection by character name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public GameSession GetConnectionByCharacterName(string name)
        {
            lock (_lockObject)
            {
                return _connections.Values.FirstOrDefault(c => c.Pc?.Simple.NickName == name);
            }
        }
        #endregion

        #region Items
        /// <summary>
        ///     Add item
        /// </summary>
        /// <param name="item"></param>
        public void AddItem(GPublicItem item)
        {
            lock (_lockObject)
            {
                var uniqueIdentifier = GetUniqueIdentifier();

                item.UniqueId = new UniqueId(UniqueIdentifierType.Item);
                item.UniqueId.Id = uniqueIdentifier;

                _items.Add(item.UniqueId, item);
            }
        }

        /// <summary>
        ///     Remove item
        /// </summary>
        /// <param name="item"></param>
        public void RemoveItem(GPublicItem item)
        {
            lock (_lockObject)
            {
                var uniqueIdentifier = _items.FirstOrDefault(c => c.Value == item).Key;

                if (uniqueIdentifier != null)
                {
                    RemoveUniqueIdentifier(uniqueIdentifier.Id);
                    _items.Remove(uniqueIdentifier);
                }
            }
        }

        /// <summary>
        ///     Get all items
        /// </summary>
        /// <returns></returns>
        public List<GPublicItem> GetAllItems()
        {
            lock (_lockObject)
            {
                return _items.Values.ToList();
            }
        }

        /// <summary>
        ///     Get item by unique identifier
        /// </summary>
        /// <param name="uniqueIdentifier"></param>
        /// <returns></returns>
        public GPublicItem GetItemByUniqueIdentifier(UniqueId uniqueIdentifier)
        {
            lock (_lockObject)
            {
                return _items.FirstOrDefault(c => c.Key.Id == uniqueIdentifier.Id).Value;
            }
        }
        #endregion

        #region Units
        /// <summary>
        ///     Add unit
        /// </summary>
        /// <param name="unit"></param>
        public void AddUnit(GMonster unit)
        {
            lock (_lockObject)
            {
                var uniqueIdentifier = GetUniqueIdentifier();

                unit.UniqueId = new UniqueId((UniqueIdentifierType)1);
                unit.UniqueId.Id = uniqueIdentifier;

                _units.Add(unit.UniqueId, unit);
            }
        }

        /// <summary>
        ///     Remove unit
        /// </summary>
        /// <param name="unit"></param>
        public void RemoveUnit(GMonster unit)
        {
            lock (_lockObject)
            {
                var uniqueIdentifier = _units.FirstOrDefault(c => c.Value == unit).Key;

                if (uniqueIdentifier != null)
                {
                    RemoveUniqueIdentifier(uniqueIdentifier.Id);
                    _units.Remove(uniqueIdentifier);
                }
            }
        }

        /// <summary>
        ///     Get all units
        /// </summary>
        /// <returns></returns>
        public List<GMonster> GetAllUnits()
        {
            lock (_lockObject)
            {
                return _units.Values.ToList();
            }
        }

        /// <summary>
        ///     Get unit by unique identifier
        /// </summary>
        /// <param name="uniqueIdentifier"></param>
        /// <returns></returns>
        public GMonster GetUnitByUniqueIdentifier(UniqueId uniqueIdentifier)
        {
            lock (_lockObject)
            {
                return _units.FirstOrDefault(c => c.Key.Id == uniqueIdentifier.Id).Value;
            }
        }
        #endregion

        #region Other methods
        /// <summary>
        ///     Check connection or unit by unique identifier
        /// </summary>
        /// <param name="uniqueIdentifier"></param>
        /// <returns></returns>
        public bool CheckConnectionOrUnitByUniqueIdentifier(UniqueId uniqueIdentifier)
        {
            lock (_lockObject)
            {
                var connection = GetConnectionByUniqueIdentifier(uniqueIdentifier);

                if (connection != null)
                {
                    return true;
                }

                var unit = GetUnitByUniqueIdentifier(uniqueIdentifier);

                if (unit != null)
                {
                    return true;
                }

                return false;
            }
        }
        #endregion

        /// <summary>
        ///     Get unique identifier
        /// </summary>
        /// <returns></returns>
        public uint GetUniqueIdentifier()
        {
            if (_uniqueIdentifiers.Count == 0)
            {
                _uniqueIdentifiers.Enqueue(_uniqueIdentifiersCounter);
                _uniqueIdentifiersCounter = _uniqueIdentifiersCounter + 1;
            }

            return _uniqueIdentifiers.Dequeue();
        }

        /// <summary>
        ///     Remove unique identifier
        /// </summary>
        /// <param name="uniqueIdentifier"></param>
        private void RemoveUniqueIdentifier(uint uniqueIdentifier)
        {
            _uniqueIdentifiers.Enqueue(uniqueIdentifier);
        }
    }
}
