using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vasis.Erp.Facil.Shared.Entities.Cadastros;

public class MotoristaMapping : IEntityTypeConfiguration<Motorista>
{
    public void Configure(EntityTypeBuilder<Motorista> builder)
    {
        builder.ToTable("Motoristas");

        builder.Property(m => m.NumeroCnh).HasMaxLength(20);
        builder.Property(m => m.CategoriaCnh).HasMaxLength(5);
    }
}
