using MessageQueue.DataAccess.Contexts;
using MessageQueue.Domain.Entities;
using MessageQueue.Domain.ValueObjects;
using MessageQueue.Contracts;
using MessageQueue.DataAccess.Respositories.Messages;
using MessageQueue.DataAccessTests.Utilities;
using MessageQueue.DataAccess.Respositories.Producers; // Ajusta el namespace según tu proyecto

namespace MessageQueue.DataAccessTests
{
    [TestClass]
    public class MessageRepositoryTests
    {
        private ApplicationContext _context;
        private IUnitOfWork _unitOfWork;
        private MessageRepository _messageRepository;
        private ProducerRepository _producerRepository;

        [TestInitialize]
        public void SetUp()
        {
            // Inicializa el contexto y el repositorio
            _context = new ApplicationContext(ConnectionStringProvider.GetConnectingString());
            _unitOfWork = new UnitOfWork(_context);
            _messageRepository = new MessageRepository(_context);

            // Limpia y recrea la base de datos
            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();
        }

        [TestMethod]
        public void Add_ShouldAddMessage()
        {

            // Arrange
            // 1. Crea un Producer y guárdalo en la base de datos
            var producerEndpoint = new NetworkEndpoint("192.168.1.1", 8080);
            var producer = new Producer(Guid.NewGuid(), producerEndpoint);

            _producerRepository.Add(producer); // Asegúrate de inyectar ProducerRepository en las pruebas
            _unitOfWork.SaveChanges();


            // Arrange
            
            var content = new MessageContent("Alerta", "Temperatura crítica");
            var message = new Message(Guid.NewGuid(), content, producer.Id);

            // Act
            _messageRepository.Add(message);
            _unitOfWork.SaveChanges();

            // Assert
            var result = _context.Set<Message>().FirstOrDefault(m => m.Id == message.Id);
            Assert.IsNotNull(result);
            Assert.AreEqual("Alerta", result.Content.Title);
            Assert.AreEqual("Temperatura crítica", result.Content.Content);
        }

        [TestMethod]
        public void GetById_ShouldReturnMessage()
        {
            // Arrange
            var producerId = Guid.NewGuid();
            var content = new MessageContent("Alerta", "Temperatura crítica");
            var message = new Message(Guid.NewGuid(), content, producerId);

            _context.Set<Message>().Add(message);
            _unitOfWork.SaveChanges();

            // Act
            var result = _messageRepository.GetById(message.Id);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(message.Id, result.Id);
        }

        [TestMethod]
        public void GetAll_ShouldReturnAllMessages()
        {
            // Arrange
            var producerId = Guid.NewGuid();
            var content1 = new MessageContent("Alerta", "Temperatura crítica");
            var content2 = new MessageContent("Advertencia", "Presión alta");
            var message1 = new Message(Guid.NewGuid(), content1, producerId);
            var message2 = new Message(Guid.NewGuid(), content2, producerId);

            _context.Set<Message>().AddRange(message1, message2);
            _unitOfWork.SaveChanges();

            // Act
            var result = _messageRepository.GetAll();

            // Assert
            Assert.AreEqual(2, result.Count());
        }

        [TestMethod]
        public void Update_ShouldModifyMessage()
        {
            // Arrange
            var producerId = Guid.NewGuid();
            var content = new MessageContent("Alerta", "Temperatura crítica");
            var message = new Message(Guid.NewGuid(), content, producerId);

            _context.Set<Message>().Add(message);
            _unitOfWork.SaveChanges();

            // Act
            var updatedContent = new MessageContent("Advertencia", "Presión alta");
            message.Content = updatedContent;

            _messageRepository.Update(message);
            _unitOfWork.SaveChanges();

            // Assert
            var result = _context.Set<Message>().Find(message.Id);
            Assert.AreEqual("Advertencia", result.Content.Title);
            Assert.AreEqual("Presión alta", result.Content.Content);
        }

        [TestMethod]
        public void Delete_ShouldRemoveMessage()
        {
            // Arrange
            var producerId = Guid.NewGuid();
            var content = new MessageContent("Alerta", "Temperatura crítica");
            var message = new Message(Guid.NewGuid(), content, producerId);

            _context.Set<Message>().Add(message);
            _unitOfWork.SaveChanges();

            // Act
            _messageRepository.Delete(message.Id);
            _unitOfWork.SaveChanges();

            // Assert
            var result = _context.Set<Message>().Find(message.Id);
            Assert.IsNull(result);
        }
    }
}
