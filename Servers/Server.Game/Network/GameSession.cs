using Core.Network;
using Microsoft.Extensions.Logging;
using System.Net.Sockets;
using System.Reflection;
using Core.Network.Cryptography;
using Packets.Core.Attributes;
using Packets.Core.Enums;
using Packets.Core.Interfaces;
using Packets.Core.Utilities;
using Server.Game.Core.Factories.Interfaces;
using System;
using Server.Game.Services;
using Server.Game.Models.Game;
using System.Collections.Generic;

namespace Server.Game.Network
{
    /// <summary>
    ///     Network game session
    /// </summary>
    public class GameSession : NetworkSession
    {
        private ILogger<GameSession> _logger;
        private IAuthorizationFactory _authorizationFactory;
        private IRegisterHandlerService _registerHandlerService;
        private IdentificationService _identificationService;

        #region Properties for game session
        /// <summary>
        ///     Session game model
        /// </summary>
        public GSession Sessions { get; set; }

        /// <summary>
        ///     Characters model
        /// </summary>
        public List<GPc> Pcs { get; set; }

        /// <summary>
        ///     Character game model
        /// </summary>
        public GPc Pc { get; set; }
        #endregion

        /// <summary>
        ///     Creates a new instance
        /// </summary>
        /// <param name="server"></param>
        public GameSession(GameServer server) : base(server)
        {

        }

        /// <summary>
        ///     Inicialize services
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="authorizationFactory"></param>
        /// <param name="registerHandlerService"></param>
        /// <param name="identificationService"></param>
        public void InicializeServices(ILogger<GameSession> logger, IAuthorizationFactory authorizationFactory, IRegisterHandlerService registerHandlerService, IdentificationService identificationService)
        {
            _logger = logger;
            _authorizationFactory = authorizationFactory;
            _registerHandlerService = registerHandlerService;
            _identificationService = identificationService;
        }

        /// <summary>
        ///     Event connection new client
        /// </summary>
        protected override void OnConnected()
        {
            _logger.LogInformation($"New client connected {Id}");

            // Send welcome packet
            _authorizationFactory.SendWelcome(this);
        }

        /// <summary>
        ///     Event disconnected client
        /// </summary>
        protected override void OnDisconnected()
        {
            _logger.LogInformation($"Client disconnected {Id}");

            // Remove session in store
            _identificationService.RemoveConnection(this);

            // Save account in database
        }

        /// <summary>
        ///     Handle receive data
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="offset"></param>
        /// <param name="size"></param>
        protected override void OnReceived(byte[] buffer, long offset, long size)
        {
            try
            {
                FormationPackage formationPackage = new FormationPackage(buffer, offset, size);

                byte checkCrypt = formationPackage.ReadByte();

                if (checkCrypt == 1)
                {
                    formationPackage = new FormationPackage(BlowfishCrypt.Decrypt(formationPackage.GetBytes()));
                }

                byte packetNumber = formationPackage.ReadByte();
                short packetId = formationPackage.ReadShort();

                // Check packet is exist in enum
                if (!Enum.IsDefined(typeof(PacketType), packetId))
                {
                    _logger.LogError($"Packet {packetId} is not defined");
                    return;
                }

                PacketType packetType = (PacketType)packetId;

                // Parse byte array to model
                object parserModel = _registerHandlerService.Parse(packetType, formationPackage.GetBytes());

                // Check model is null after parser
                if (parserModel == null)
                {
                    _logger.LogError($"Model after parser is null for packet {packetId}");
                    return;
                }

                // Handle parse model
                _registerHandlerService.InvokeHandler(packetType, this, parserModel);
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
            }
        }

        /// <summary>
        ///     Send message to client
        /// </summary>
        /// <param name="model"></param>
        public void Send(object model)
        {
            PacketType packetType = model.GetType().GetCustomAttribute<ModelAttribute>().PacketType;

            // Parse model to byte array
            byte[] data = _registerHandlerService.Parse(packetType, model);

            FormationPackage formationPackage = new FormationPackage();
            formationPackage.AddByte(0x00); // TODO crypt
            formationPackage.AddByte(0x01); // TODO number package
            formationPackage.AddShort((short)packetType);
            formationPackage.AddBytes(data, 0, data.Length);
            formationPackage.AddShort((short)(formationPackage.Size + 2), begin: true);

            base.Send(formationPackage.GetBytes());
        }

        public void SendOnlyBytesForDelevop(byte[] data)
        {
            base.Send(data);
        }

        /// <summary>
        ///     Handle error exception
        /// </summary>
        /// <param name="error"></param>
        protected override void OnError(SocketError error)
        {
            _logger.LogInformation($"Have error at game session. ErrorType with code {error}");
        }
    }
}
