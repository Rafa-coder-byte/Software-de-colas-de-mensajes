using MessageQueue.Domain.Common;
using MessageQueue.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageQueue.Domain.Entities
{
    /// <summary>
    /// Entidad que representa un consumidor de mensajes
    /// Relación: N Mensajes <-> N Consumidores (mediante Message.ReadBy)
    /// </summary>
    public class Consumer : Entity
    {
        /// <summary>
        /// Endpoint de red del consumidor
        /// </summary>
        public NetworkEndpoint Endpoint { get; set; }

        /// <summary>
        /// Constructor para crear un consumidor en la base de datos
        /// </summary>
        public Consumer() { }

        /// <summary>
        /// Constructor para crear un consumidor
        /// </summary>
        /// <param name="id">Identificador único</param>
        /// <param name="endpoint">Endpoint de red válido</param>
        public Consumer(Guid id, NetworkEndpoint endpoint) : base(id)
        {
            Endpoint = endpoint ?? throw new ArgumentNullException(nameof(endpoint));
        }
    }
}

