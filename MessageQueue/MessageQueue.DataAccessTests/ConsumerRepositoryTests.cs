using MessageQueue.Contracts;
using MessageQueue.DataAccess.Contexts;
using MessageQueue.DataAccess.Respositories.Consumers;
using MessageQueue.DataAccessTests.Utilities;
using MessageQueue.Domain.Entities;
using MessageQueue.Domain.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;


namespace MessageQueue.DataAccessTests
{

    [TestClass]
    public class ConsumerRepositoryTests
    {
        private ApplicationContext _context;
        private IUnitOfWork _unitOfWork;
        private ConsumerRepository _consumerRepository;

        [TestInitialize]
        public void SetUp()
        {
            // Inicializa el contexto y el repositorio
            _context = new ApplicationContext(ConnectionStringProvider.GetConnectingString());
            _unitOfWork = new UnitOfWork(_context);
            _consumerRepository = new ConsumerRepository(_context);

            // Limpia y recrea la base de datos
            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();
        }

        [TestMethod]
        public void Add_ShouldAddConsumer()
        {
            // Arrange
            var endpoint = new NetworkEndpoint("192.168.1.2", 8081);
            var consumer = new Consumer(Guid.NewGuid(), endpoint);

            // Act
            _consumerRepository.Add(consumer);
            _unitOfWork.SaveChanges();

            // Assert
            var result = _context.Set<Consumer>().FirstOrDefault(c => c.Id == consumer.Id);
            Assert.IsNotNull(result);
            Assert.AreEqual("192.168.1.2", result.Endpoint.IP);
            Assert.AreEqual(8081, result.Endpoint.Port);
        }

        [TestMethod]
        public void GetById_ShouldReturnConsumer()
        {
            // Arrange
            var endpoint = new NetworkEndpoint("192.168.1.2", 8081);
            var consumer = new Consumer(Guid.NewGuid(), endpoint);

            _context.Set<Consumer>().Add(consumer);
            _unitOfWork.SaveChanges();

            // Act
            var result = _consumerRepository.GetById(consumer.Id);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(consumer.Id, result.Id);
        }

        [TestMethod]
        public void GetAll_ShouldReturnAllConsumers()
        {
            // Arrange
            var endpoint1 = new NetworkEndpoint("192.168.1.2", 8081);
            var endpoint2 = new NetworkEndpoint("192.168.1.3", 8082);
            var consumer1 = new Consumer(Guid.NewGuid(), endpoint1);
            var consumer2 = new Consumer(Guid.NewGuid(), endpoint2);

            _context.Set<Consumer>().AddRange(consumer1, consumer2);
            _unitOfWork.SaveChanges();

            // Act
            var result = _consumerRepository.GetAll();

            // Assert
            Assert.AreEqual(2, result.Count());
        }

        [TestMethod]
        public void Update_ShouldModifyConsumer()
        {
            // Arrange
            var endpoint = new NetworkEndpoint("192.168.1.2", 8081);
            var consumer = new Consumer(Guid.NewGuid(), endpoint);

            _context.Set<Consumer>().Add(consumer);
            _unitOfWork.SaveChanges();

            // Act
            var updatedEndpoint = new NetworkEndpoint("192.168.1.200", 9091);
            consumer.Endpoint = updatedEndpoint;

            _consumerRepository.Update(consumer);
            _unitOfWork.SaveChanges();

            // Assert
            var result = _context.Set<Consumer>().Find(consumer.Id);
            Assert.AreEqual("192.168.1.200", result.Endpoint.IP);
            Assert.AreEqual(9091, result.Endpoint.Port);
        }

        [TestMethod]
        public void Delete_ShouldRemoveConsumer()
        {
            // Arrange
            var endpoint = new NetworkEndpoint("192.168.1.2", 8081);
            var consumer = new Consumer(Guid.NewGuid(), endpoint);

            _context.Set<Consumer>().Add(consumer);
            _unitOfWork.SaveChanges();

            // Act
            _consumerRepository.Delete(consumer.Id);
            _unitOfWork.SaveChanges();

            // Assert
            var result = _context.Set<Consumer>().Find(consumer.Id);
            Assert.IsNull(result);
        }
    }
}
