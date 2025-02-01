using MessageQueue.Domain.Entities;


namespace MessageQueue.Contracts
{
    public interface IProducerRepository
    {
        /// <summary>Añade una nueva entidad al repositorio.</summary>
        /// <param name="producer">La entidad a añadir.</param>
        void Add(Producer producer);

        /// <summary>Busca una entidad por su identificador único.</summary>
        /// <param name="id">El identificador único de la entidad.</param>
        /// <returns>La entidad correspondiente al identificador, o null si no se encuentra.</returns>
        Producer? GetById(Guid id);

        /// <summary>Devuelve todas las entidades del tipo especificado.</summary>
        /// <returns>Una colección de todas las entidades.</returns>
        IEnumerable<Producer> GetAll();

        /// <summary>Actualiza una entidad existente en el repositorio.</summary>
        /// <param name="producer">La entidad a actualizar.</param>
        void Update(Producer producer);

        /// <summary>Elimina una entidad del repositorio por su identificador único.</summary>
        /// <param name="id">El identificador único de la entidad a eliminar.</param>
        void Delete(Guid id);
    }
}
