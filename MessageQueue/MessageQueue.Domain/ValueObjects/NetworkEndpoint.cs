using MessageQueue.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageQueue.Domain.ValueObjects
{
    /// <summary>
    /// Objeto de valor que representa un endpoint de red
    /// </summary>
    public sealed class NetworkEndpoint : ValueObject
    {
        /// <summary>
        /// Dirección IP del endpoint
        /// </summary>
        public string IP { get; init; }

        /// <summary>
        /// Puerto del endpoint
        /// </summary>
        public int Port { get; init; }

        /// <summary>
        /// Constructor para crear un endpoint de red 
        /// </summary>
        public NetworkEndpoint() { }

        /// <summary>
        /// Constructor para crear un endpoint de red válido
        /// </summary>
        /// <param name="ip">Dirección IP válida</param>
        /// <param name="port">Puerto válido (1-65535)</param>
        /// <exception cref="ArgumentException">Si los datos son inválidos</exception>
        public NetworkEndpoint(string ip, int port)
        {
            if (!System.Net.IPAddress.TryParse(ip, out _))
                throw new ArgumentException("IP inválida");

            if (port < 1 || port > 65535)
                throw new ArgumentException("Puerto inválido");

            IP = ip;
            Port = port;
        }

        /// <summary>
        /// Componentes para igualdad: IP + Puerto
        /// </summary>
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return IP;
            yield return Port;
        }
    }
}
