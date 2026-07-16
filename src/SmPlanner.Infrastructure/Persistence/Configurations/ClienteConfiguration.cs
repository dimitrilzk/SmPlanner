using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmPlanner.Domain.Clienti;

namespace SmPlanner.Infrastructure.Persistence.Configurations;

public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
{
    public void Configure(EntityTypeBuilder<Cliente> builder)
    {
        builder.ToTable("Clienti");

        builder.HasKey(c => c.Id);

        builder.Property(c => c.Nome).IsRequired().HasMaxLength(100);
        builder.Property(c => c.Cognome).IsRequired().HasMaxLength(100);
        builder.Property(c => c.Societa).HasMaxLength(150);
        builder.Property(c => c.Citta).HasMaxLength(100);
        builder.Property(c => c.Telefono).HasMaxLength(30);
        builder.Property(c => c.Email).HasMaxLength(150);
        builder.Property(c => c.ImportoMensile).HasColumnType("decimal(10,2)");
        builder.Property(c => c.ColoreHex).IsRequired().HasMaxLength(7);

        builder.OwnsMany(c => c.Pianificazione, pianificazione =>
        {
            pianificazione.ToTable("ClientePianificazioneGiorni");
            pianificazione.WithOwner().HasForeignKey("ClienteId");
            pianificazione.Property<int>("Id");
            pianificazione.HasKey("Id");
        });
    }
}
