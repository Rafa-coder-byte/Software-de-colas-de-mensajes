using MessageQueue.DataAccess.FluentConfigurations.Common;
using MessageQueue.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace MessageQueue.DataAccess.FluentConfigurations.MaintenanceActivities
{
    /// <summary>Configuración base para la entidad MaintenanceActivity.</summary>
    public class MaintenanceActivityEntityTypeConfigurationBase : EntityTypeConfigurationBase<Message>
    {
        /// <summary>Configura la entidad MaintenanceActivity.</summary>
        /// <param name="builder">Constructor de la entidad.</param>
        public override void Configure(EntityTypeBuilder<Message> builder)
        {
            builder.ToTable("Messages");

            builder.HasKey(m => m.Id);
            builder.Property(m => m.Id)
                .ValueGeneratedOnAdd();

            // Configuración del Value Object MessageContent
            builder.OwnsOne(m => m.Content, content =>
            {
                content.Property(c => c.Title)
                    .HasColumnName("Title")
                    .HasMaxLength(100)
                    .IsRequired();

                content.Property(c => c.Content)
                    .HasColumnName("Body")
                    .HasMaxLength(1000)
                    .IsRequired();
            });

            // Relación con Producer
            builder.HasOne<Producer>()
                .WithMany()
                .HasForeignKey(m => m.ProducerId)
                .OnDelete(DeleteBehavior.Cascade);

            // Configuración del HashSet<Guid> (ReadBy)
            builder.Property(m => m.ReadBy)
                .HasConversion(
                    v => string.Join(',', v), // Convertir HashSet<Guid> a string
                    v => v.Split(',', StringSplitOptions.RemoveEmptyEntries)
                          .Select(Guid.Parse)
                          .ToList() // Convertir string a HashSet<Guid>
                )
                .HasColumnType("Text"); // Tipo de columna en la base de datos
        }
    }
}

