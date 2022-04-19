using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Packets.Core.Attributes;
using Packets.Core.Enums;
using Packets.Core.Interfaces;

namespace Packets.Core.Services
{
    /// <inheritdoc />
    public class RegisterHandlerService : IRegisterHandlerService
    {
        private readonly IServiceProvider _serviceProvider;

        // For models
        private static Dictionary<PacketType, Type> _models { get; set; } = new Dictionary<PacketType, Type>();

        // For parsers
        private static Dictionary<PacketType, MethodInfo> _parserRecieveActions { get; set; } = new Dictionary<PacketType, MethodInfo>();
        private static Dictionary<PacketType, MethodInfo> _parserSendActions { get; set; } = new Dictionary<PacketType, MethodInfo>();
        private static Dictionary<PacketType, object> _parsers { get; set; } = new Dictionary<PacketType, object>();

        // For handlers
        private static Dictionary<PacketType, Type> _handlers { get; set; } = new Dictionary<PacketType, Type>();
        private static Dictionary<PacketType, MethodInfo> _handlerActions { get; set; } = new Dictionary<PacketType, MethodInfo>();

        /// <summary>
        ///     Create a new instances
        /// </summary>
        /// <param name="serviceProvider"></param>
        public RegisterHandlerService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        /// <inheritdoc />
        public void RegistrationModels(Assembly assembly)
        {
            foreach (Type type in assembly.GetTypes())
            {
                if (type.GetCustomAttributes(typeof(ModelAttribute), true).Length > 0)
                {
                    _models.Add(type.GetCustomAttribute<ModelAttribute>().PacketType, type);
                }
            }
        }

        /// <inheritdoc />
        public void RegistrationParsers(Assembly assembly)
        {
            foreach (Type type in assembly.GetTypes())
            {
                if (type.GetCustomAttributes(typeof(ParserSendAttribute), true).Length > 0)
                {
                    object parser = Activator.CreateInstance(type);
                    MethodInfo[] methods = type.GetMethods().Where(method => Attribute.IsDefined(method, typeof(ParserActionAttribute))).ToArray();

                    foreach (MethodInfo method in methods)
                    {
                        PacketType packetType = method.GetCustomAttribute<ParserActionAttribute>().PacketType;

                        _parsers.Add(packetType, parser);
                        _parserSendActions.Add(packetType, method);
                    }
                }

                if (type.GetCustomAttributes(typeof(ParserReceiveAttribute), true).Length > 0)
                {
                    object parser = Activator.CreateInstance(type);
                    MethodInfo[] methods = type.GetMethods().Where(method => Attribute.IsDefined(method, typeof(ParserActionAttribute))).ToArray();

                    foreach (MethodInfo method in methods)
                    {
                        PacketType packetType = method.GetCustomAttribute<ParserActionAttribute>().PacketType;

                        _parsers.Add(packetType, parser);
                        _parserRecieveActions.Add(packetType, method);
                    }
                }
            }
        }

        /// <inheritdoc />
        public void RegistrationHandlers(Assembly assembly)
        {
            foreach (Type type in assembly.GetTypes())
            {
                if (type.GetCustomAttributes(typeof(HandlerAttribute), true).Length > 0)
                {
                    MethodInfo[] methods = type.GetMethods().Where(method => Attribute.IsDefined(method, typeof(HandlerActionAttribute))).ToArray();

                    foreach (MethodInfo method in methods)
                    {
                        PacketType packetType = method.GetCustomAttribute<HandlerActionAttribute>().PacketType;
                        _handlers.Add(packetType, type.GetInterfaces().FirstOrDefault() ?? type);
                        _handlerActions.Add(packetType, method);
                    }
                }
            }
        }

        /// <inheritdoc />
        public object GetModel(PacketType packetType)
        {
            return Activator.CreateInstance(_models[packetType]);
        }

        /// <inheritdoc />
        public object Parse(PacketType packetType, byte[] data)
        {
            return _parserRecieveActions.GetValueOrDefault(packetType)?.Invoke(_parsers[packetType], new object[] { data });
        }

        /// <inheritdoc />
        public byte[] Parse(PacketType packetType, object model)
        {
            return (byte[])_parserSendActions.GetValueOrDefault(packetType)?.Invoke(_parsers[packetType], new object[] { model });
        }

        /// <inheritdoc />
        public void InvokeHandler(PacketType packetType, params object[] pars)
        {
            object handler = _serviceProvider.GetService(_handlers[packetType]);
            _handlerActions.GetValueOrDefault(packetType)?.Invoke(handler, pars);
        }
    }
}
