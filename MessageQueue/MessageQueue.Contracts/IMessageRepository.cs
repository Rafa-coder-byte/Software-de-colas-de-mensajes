
using MessageQueue.Domain.Entities;


namespace MessageQueue.Contracts
{
    public interface IMessageRepository
    {
        /// <summary>Añade una nueva entidad al repositorio.</summary>
        /// <param name="message">La entidad a añadir.</param>
        void Add(Message message);

        /// <summary>Busca una entidad por su identificador único.</summary>
        /// <param name="id">El identificador único de la entidad.</param>
        /// <returns>La entidad correspondiente al identificador, o null si no se encuentra.</returns>
        Message? GetById(Guid id);

        /// <summary>Devuelve todas las entidades del tipo especificado.</summary>
        /// <returns>Una colección de todas las entidades.</returns>
        IEnumerable<Message> GetAll();

        /// <summary>Actualiza una entidad existente en el repositorio.</summary>
        /// <param name="message">La entidad a actualizar.</param>
        void Update(Message message);

        /// <summary>Elimina una entidad del repositorio por su identificador único.</summary>
        /// <param name="id">El identificador único de la entidad a eliminar.</param>
        void Delete(Guid id);
    }
}
