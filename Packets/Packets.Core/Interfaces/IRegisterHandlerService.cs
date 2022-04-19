using System.Reflection;
using Packets.Core.Enums;

namespace Packets.Core.Interfaces
{
    /// <summary>
    ///     Service for register parsers and handlers
    /// </summary>
    public interface IRegisterHandlerService
    {
        /// <summary>
        ///     Register models by assembly
        /// </summary>
        /// <param name="assembly"></param>
        void RegistrationModels(Assembly assembly);

        /// <summary>
        ///     Register parsers by assembly
        /// </summary>
        /// <param name="assembly"></param>
        void RegistrationParsers(Assembly assembly);

        /// <summary>
        ///     Register handlers by assembly
        /// </summary>
        /// <param name="assembly"></param>
        void RegistrationHandlers(Assembly assembly);

        /// <summary>
        ///     Get model by type
        /// </summary>
        /// <param name="packetType"></param>
        /// <returns></returns>
        object GetModel(PacketType packetType);

        /// <summary>
        ///     Invoke parser
        /// </summary>
        /// <param name="packetType"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        object Parse(PacketType packetType, byte[] data);

        /// <summary>
        ///     Invoke parser
        /// </summary>
        /// <param name="packetType"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        byte[] Parse(PacketType packetType, object model);

        /// <summary>
        ///     Invoke handler
        /// </summary>
        /// <param name="packetType"></param>
        /// <param name="pars"></param>
        void InvokeHandler(PacketType packetType, params object[] pars);
    }
}
