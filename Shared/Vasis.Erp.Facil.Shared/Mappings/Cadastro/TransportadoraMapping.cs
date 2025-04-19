using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vasis.Erp.Facil.Shared.Domain.Entities;

public class TransportadoraMapping : IEntityTypeConfiguration<Transportadora>
{
    public void Configure(EntityTypeBuilder<Transportadora> builder)
    {
        builder.ToTable("Transportadoras");

        builder.Property(t => t.Rntrc).HasMaxLength(30);
    }
}
