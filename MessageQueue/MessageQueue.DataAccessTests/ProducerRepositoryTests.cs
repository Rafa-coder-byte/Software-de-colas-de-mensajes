using MessageQueue.Contracts;
using MessageQueue.DataAccess.Contexts;
using MessageQueue.DataAccess.Respositories.Producers;
using MessageQueue.DataAccessTests.Utilities;
using MessageQueue.Domain.Entities;
using MessageQueue.Domain.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace MessageQueue.DataAccessTests
{



    [TestClass]
    public class ProducerRepositoryTests
    {
        private ApplicationContext _context;
        private IUnitOfWork _unitOfWork;
        private ProducerRepository _producerRepository;

        [TestInitialize]
        public void SetUp()
        {
            // Inicializa el contexto y el repositorio
            _context = new ApplicationContext(ConnectionStringProvider.GetConnectingString());
            _unitOfWork = new UnitOfWork(_context);
            _producerRepository = new ProducerRepository(_context);

            // Limpia y recrea la base de datos
            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();
        }

        [TestMethod]
        public void Add_ShouldAddProducer()
        {
            // Arrange
            var endpoint = new NetworkEndpoint("192.168.1.1", 8080);
            var producer = new Producer(Guid.NewGuid(), endpoint);

            // Act
            _producerRepository.Add(producer);
            _unitOfWork.SaveChanges();

            // Assert
            var result = _context.Set<Producer>().FirstOrDefault(p => p.Id == producer.Id);
            Assert.IsNotNull(result);
            Assert.AreEqual("192.168.1.1", result.Endpoint.IP);
            Assert.AreEqual(8080, result.Endpoint.Port);
        }

        [TestMethod]
        public void GetById_ShouldReturnProducer()
        {
            // Arrange
            var endpoint = new NetworkEndpoint("192.168.1.1", 8080);
            var producer = new Producer(Guid.NewGuid(), endpoint);

            _context.Set<Producer>().Add(producer);
            _unitOfWork.SaveChanges();

            // Act
            var result = _producerRepository.GetById(producer.Id);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(producer.Id, result.Id);
        }

        [TestMethod]
        public void GetAll_ShouldReturnAllProducers()
        {
            // Arrange
            var endpoint1 = new NetworkEndpoint("192.168.1.1", 8080);
            var endpoint2 = new NetworkEndpoint("192.168.1.2", 8081);
            var producer1 = new Producer(Guid.NewGuid(), endpoint1);
            var producer2 = new Producer(Guid.NewGuid(), endpoint2);

            _context.Set<Producer>().AddRange(producer1, producer2);
            _unitOfWork.SaveChanges();

            // Act
            var result = _producerRepository.GetAll();

            // Assert
            Assert.AreEqual(2, result.Count());
        }

        [TestMethod]
        public void Update_ShouldModifyProducer()
        {
            // Arrange
            var endpoint = new NetworkEndpoint("192.168.1.1", 8080);
            var producer = new Producer(Guid.NewGuid(), endpoint);

            _context.Set<Producer>().Add(producer);
            _unitOfWork.SaveChanges();

            // Act
            var updatedEndpoint = new NetworkEndpoint("192.168.1.100", 9090);
            producer.Endpoint = updatedEndpoint;

            _producerRepository.Update(producer);
            _unitOfWork.SaveChanges();

            // Assert
            var result = _context.Set<Producer>().Find(producer.Id);
            Assert.AreEqual("192.168.1.100", result.Endpoint.IP);
            Assert.AreEqual(9090, result.Endpoint.Port);
        }

        [TestMethod]
        public void Delete_ShouldRemoveProducer()
        {
            // Arrange
            var endpoint = new NetworkEndpoint("192.168.1.1", 8080);
            var producer = new Producer(Guid.NewGuid(), endpoint);

            _context.Set<Producer>().Add(producer);
            _unitOfWork.SaveChanges();

            // Act
            _producerRepository.Delete(producer.Id);
            _unitOfWork.SaveChanges();

            // Assert
            var result = _context.Set<Producer>().Find(producer.Id);
            Assert.IsNull(result);
        }
    }
}
