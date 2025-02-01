
using MessageQueue.Domain.Entities;


namespace MessageQueue.Contracts
{
    /// <summary>Interfaz para el repositorio de planificaciones.</summary>
    public interface IConsumerRepository
    {
        /// <summary>Añade una planificación.</summary>
        void Add(Consumer consumer);

        /// <summary>Obtiene una planificación por su identificador.</summary>
        Consumer? GetById(Guid id);

        /// <summary>Obtiene todas las planificaciones.</summary>
        IEnumerable<Consumer> GetAll();

        /// <summary>Actualiza una planificación existente.</summary>
        void Update(Consumer consumer);

        /// <summary>Elimina una planificación por su identificador.</summary>
        void Delete(Guid id);
    }
}
