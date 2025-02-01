
using MessageQueue.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;



namespace MessageQueue.DataAccess.FluentConfigurations.Plannings
{
    /// <summary>Configuración específica para la entidad Planning.</summary>
    public class ConsumerEntityTypeConfiguration : IEntityTypeConfiguration<Consumer>
    {
        /// <summary>Configura la entidad Planning.</summary>
        /// <param name="builder">Constructor de la entidad.</param>
        public void Configure(EntityTypeBuilder<Consumer> builder)
        {
            builder.ToTable("Consumers");

            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id)
                .ValueGeneratedOnAdd();

            builder.OwnsOne(c => c.Endpoint, endpoint =>
            {
                endpoint.Property(e => e.IP)
                    .HasColumnName("IPAddress")
                    .HasMaxLength(15)
                    .IsRequired();

                endpoint.Property(e => e.Port)
                    .HasColumnName("PortNumber")
                    .IsRequired();
            });
        }
    }
}


