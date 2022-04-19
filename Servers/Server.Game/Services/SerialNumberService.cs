using System.Collections.Generic;

namespace Server.Game.Services
{
    /// <summary>
    ///     Serial number service
    /// </summary>
    public class SerialNumberService
    {
        /// <summary>
        ///     Lock object
        /// </summary>
        private object _lockObject = new object();

        /// <summary>
        ///     Serial number identifiers
        /// </summary>
        private Queue<ulong> _serialNumberIdentifiers;

        /// <summary>
        ///     Serial number identifiers counter
        /// </summary>
        private uint _serialNumberIdentifiersCounter;

        public SerialNumberService()
        {
            _serialNumberIdentifiers = new Queue<ulong>();
            _serialNumberIdentifiersCounter = 1;
        }

        /// <summary>
        ///     Get serial number identifier
        /// </summary>
        /// <returns></returns>
        public ulong GetSerialNumberIdentifier()
        {
            lock (_lockObject)
            {
                if (_serialNumberIdentifiers.Count == 0)
                {
                    _serialNumberIdentifiers.Enqueue(_serialNumberIdentifiersCounter);
                    _serialNumberIdentifiersCounter = _serialNumberIdentifiersCounter + 1;
                }

                return _serialNumberIdentifiers.Dequeue();
            }
        }

        /// <summary>
        ///     Remove serial number identifier
        /// </summary>
        /// <param name="serialNumberIdentifier"></param>
        public void RemoveSerialNumberIdentifier(ulong serialNumberIdentifier)
        {
            lock (_lockObject)
            {
                _serialNumberIdentifiers.Enqueue(serialNumberIdentifier);
            }
        }
    }
}
