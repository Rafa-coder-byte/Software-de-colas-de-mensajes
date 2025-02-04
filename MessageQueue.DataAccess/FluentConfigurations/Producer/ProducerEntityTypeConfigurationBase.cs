using MessageQueue.DataAccess.FluentConfigurations.Common;
using MessageQueue.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace MessageQueue.DataAccess.FluentConfigurations.Equipments
{
    /// <summary>Configuración base para la entidad Equipment.</summary>
    public class ProducerEntityTypeConfigurationBase : EntityTypeConfigurationBase<Producer>
    {
        /// <summary>Configura la entidad Equipment.</summary>
        /// <param name="builder">Constructor de la entidad.</param>
        public override void Configure(EntityTypeBuilder<Producer> builder)
        {
            builder.ToTable("Producers");

            // Configuración de la clave primaria
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id)
                .ValueGeneratedOnAdd();

            // Configuración del Value Object NetworkEndpoint
            builder.OwnsOne(p => p.Endpoint, endpoint =>
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



