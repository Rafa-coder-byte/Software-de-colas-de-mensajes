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
    /// Entidad que representa un mensaje en el sistema
    /// Relaciones:
    /// - 1 Productor -> N Mensajes (ProducerId como clave foránea)
    /// - 1 Mensaje -> N Consumidores (mediante ReadBy)
    /// </summary>
    public class Message : Entity
    {

        private readonly List<Guid> _readBy = new();

        /// <summary>
        /// Contenido del mensaje
        /// </summary>
        public MessageContent Content { get; set; }

        /// <summary>
        /// Identificador del productor (clave foránea a Producer)
        /// </summary>
        public Guid ProducerId { get; private set; }

        /// <summary>
        /// Lista de consumidores que han leído el mensaje (claves foráneas a Consumer)
        /// </summary>
        public IReadOnlyCollection<Guid> ReadBy => _readBy.AsReadOnly();

        /// <summary>
        /// Constructor para crear un mensaje
        /// </summary>
        /// <param name="id">Identificador único</param>
        /// <param name="content">Contenido del mensaje</param>
        /// <param name="producerId">Identificador del productor</param>
        public Message(Guid id, MessageContent content, Guid producerId) : base(id)
        {
            Content = content ?? throw new ArgumentNullException(nameof(content));
            ProducerId = producerId;
        }


        /// <summary>
        /// Constructor para crear un mensaje en la base de datos
        /// </summary>
        public Message() { }

        /// <summary>
        /// Marca el mensaje como leído por un consumidor
        /// </summary>
        /// <param name="consumerId">Identificador del consumidor</param>
        public void MarkAsRead(Guid consumerId)
        {
            _readBy.Add(consumerId);
        }

        /// <summary>
        /// Verifica si un consumidor ha leído el mensaje
        /// </summary>
        /// <param name="consumerId">Identificador del consumidor</param>
        /// <returns>True si el mensaje fue leído</returns>
        public bool WasReadBy(Guid consumerId) => _readBy.Contains(consumerId);
    }
}
