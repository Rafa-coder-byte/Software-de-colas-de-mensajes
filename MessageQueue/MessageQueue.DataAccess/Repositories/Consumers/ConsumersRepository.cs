
using MessageQueue.Contracts;
using MessageQueue.DataAccess.Contexts;
using MessageQueue.Domain.Entities;
using Microsoft.EntityFrameworkCore;


namespace MessageQueue.DataAccess.Respositories.Consumers
{

    /// <summary>Repositorio para manejar entidades de tipo MaintenanceActivity.</summary>
    /// <remarks>Constructor que inicializa el repositorio con el contexto de la aplicación.</remarks>
    /// <param name="context">El contexto de la aplicación.</param>
    public class ConsumerRepository(ApplicationContext context) : RepositoryBase<Consumer>(context), IConsumerRepository
    {


    }
}
