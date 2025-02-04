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
    /// Entidad que representa un productor de mensajes
    /// Relación: 1 Productor -> N Mensajes (clave foránea en Message.ProducerId)
    /// </summary>
    public class Producer : Entity
    {
        /// <summary>
        /// Endpoint de red del productor
        /// </summary>
        public NetworkEndpoint Endpoint { get; set; }

        /// <summary>
        /// Constructor para crear un producidor en la base de datos
        /// </summary>
        public Producer() { }

        /// <summary>
        /// Constructor para crear un productor
        /// </summary>
        /// <param name="id">Identificador único</param>
        /// <param name="endpoint">Endpoint de red válido</param>
        public Producer(Guid id, NetworkEndpoint endpoint) : base(id)
        {
            Endpoint = endpoint ?? throw new ArgumentNullException(nameof(endpoint));
        }
    }
}
