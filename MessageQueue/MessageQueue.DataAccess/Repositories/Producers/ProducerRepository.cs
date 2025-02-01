
using MessageQueue.Contracts;
using MessageQueue.DataAccess.Contexts; // Para ApplicationContext
using MessageQueue.Domain.Entities;

namespace MessageQueue.DataAccess.Respositories.Producers
{
    /// <summary>Repositorio para manejar entidades de tipo Equipment.</summary>
    /// <remarks>Constructor que inicializa el repositorio con el contexto de la aplicación.</remarks>
    /// <param name="context">El contexto de la aplicación.</param>
    public class ProducerRepository(ApplicationContext context) : RepositoryBase<Producer>(context), IProducerRepository
    {
    }
}
    

