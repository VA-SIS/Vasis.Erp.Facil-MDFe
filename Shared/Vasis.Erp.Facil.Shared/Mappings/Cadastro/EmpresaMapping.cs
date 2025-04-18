using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vasis.Erp.Facil.Shared.Entities.Cadastros;

namespace Vasis.Erp.Facil.Server.Mappings
{
    public class EmpresaMapping : IEntityTypeConfiguration<Empresa>
    {
        public void Configure(EntityTypeBuilder<Empresa> builder)
        {
            builder.ToTable("Empresas");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.RazaoSocial).IsRequired().HasMaxLength(200);
            builder.Property(e => e.NomeFantasia).HasMaxLength(200);
            builder.Property(e => e.Cnpj).HasMaxLength(20);
            builder.Property(e => e.Ie).HasMaxLength(20);
            builder.Property(e => e.Email).HasMaxLength(150);
            builder.Property(e => e.Telefone).HasMaxLength(20);

            builder.Property(e => e.Cep).HasMaxLength(10);
            builder.Property(e => e.Endereco).HasMaxLength(200);
            builder.Property(e => e.Numero).HasMaxLength(20);
            builder.Property(e => e.Bairro).HasMaxLength(100);
            builder.Property(e => e.Complemento).HasMaxLength(100);
            builder.Property(e => e.Cidade).HasMaxLength(100);
            builder.Property(e => e.Uf).HasMaxLength(2);

            builder.Property(e => e.CriadoEm).IsRequired();

            builder.HasMany(e => e.Pessoas)
                   .WithOne(p => p.Empresa)
                   .HasForeignKey(p => p.EmpresaId);
        }
    }
}
