using MessageQueue.Application;
using MessageQueue.Contracts;
using MessageQueue.DataAccess.Contexts;
using MessageQueue.DataAccess.Respositories.Consumers;
using MessageQueue.DataAccess.Respositories.Messages;
using MessageQueue.DataAccess.Respositories.Producers;
using MessageQueue.GrpcService.Services;

namespace MessageQueue.GrpcService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddSingleton("Data Source=MessageQueueDB.sqlite");
            builder.Services.AddScoped<ApplicationContext>();
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped<IConsumerRepository, ConsumerRepository>();
            builder.Services.AddScoped<IProducerRepository, ProducerRepository>();
            builder.Services.AddScoped<IMessageRepository, MessageRepository>();
            builder.Services.AddGrpc();
            builder.Services.AddAutoMapper(typeof(Program).Assembly);
            builder.Services.AddMediatR(new MediatRServiceConfiguration()
            {
                AutoRegisterRequestProcessors = true,
            }
            .RegisterServicesFromAssemblies(typeof(AssemblyReference).Assembly));
            // Agregar servicios al contenedor
            builder.Services.AddLogging();
            builder.Logging.AddConsole(); // Esto permite que los logs se muestren en la consola
            builder.Logging.AddDebug(); // Esto permite que los logs se muestren en la ventana de salida de Visual Studio

            builder.Services.AddGrpc(options =>
            {
                options.EnableDetailedErrors = true; // Esto habilita los errores detallados
            });

            // Asegurar que ILogger<T> está registrado
            builder.Services.AddTransient(typeof(ILogger<>), typeof(Logger<>));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            app.MapGrpcService<ConsumerService>();
          

            app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

            app.Run();
        }
    }
}