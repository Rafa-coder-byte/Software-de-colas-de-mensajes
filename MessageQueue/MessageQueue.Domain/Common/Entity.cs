using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageQueue.Domain.Common
{
    /// <summary>
    /// Clase base para todas las entidades del dominio
    /// </summary>
    /// <typeparam name="TId">Tipo del identificador único de la entidad</typeparam>
    public abstract class Entity
    {
        #region Properties
        /// <summary>
        /// Identificador único de la entidad (clave primaria)
        /// </summary>

        public Guid Id { get; set; } // Propiedad para identificar de manera única a la entidad.

            #endregion

            protected Entity() { } // Constructor por defecto.
        /// <summary>
        /// Constructor base para inicializar el identificador
        /// </summary>
        /// <param name="id">Identificador único de la entidad</param>

        protected Entity(Guid id) // Constructor que permite establecer el ID al crear una entidad.
            {
                Id = id; // Asigna el ID recibido a la propiedad Id.
            }
        }
}
