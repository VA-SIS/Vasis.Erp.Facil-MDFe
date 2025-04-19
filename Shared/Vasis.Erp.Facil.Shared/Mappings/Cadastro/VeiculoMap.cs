using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vasis.Erp.Facil.Shared.Domain.Entities;

namespace Vasis.Erp.Facil.Shared.Dtos.Mapping;

public class VeiculoMap : IEntityTypeConfiguration<Veiculo>
{
    public void Configure(EntityTypeBuilder<Veiculo> builder)
    {
        builder.ToTable("Veiculos");

        builder.HasKey(v => v.Id);

        builder.Property(v => v.Placa).IsRequired().HasMaxLength(10);
        builder.Property(v => v.Renavam).HasMaxLength(20);
        builder.Property(v => v.Tipo).HasMaxLength(50);
        builder.Property(v => v.Cor).HasMaxLength(50);
        builder.Property(v => v.Marca).HasMaxLength(100);
        builder.Property(v => v.Modelo).HasMaxLength(100);

        builder.HasOne(v => v.Transportadora)
               .WithMany()
               .HasForeignKey(v => v.TransportadoraId);
    }
}
