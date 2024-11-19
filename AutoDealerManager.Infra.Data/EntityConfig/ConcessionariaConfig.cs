using AutoDealerManager.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;

namespace AutoDealerManager.Infra.Data.EntityConfig
{
    public class ConcessionariaConfig : EntityTypeConfiguration<Concessionaria>
    {
        public ConcessionariaConfig()
        {
            HasKey(c => c.Id);

            Property(c => c.Nome)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnAnnotation("IX_Nome", new IndexAnnotation(new IndexAttribute { IsUnique = true }));

            Property(c => c.Telefone)
                .IsOptional()
                .HasMaxLength(15);

            Property(c => c.Email)
                .IsRequired()
                .HasMaxLength(100);

            Property(c => c.CapacidadeMaximaVeiculos)
                .IsRequired();

            Property(c => c.Rua)
                .IsRequired()
                .HasMaxLength(255);

            Property(c => c.Cidade)
                .IsRequired()
                .HasMaxLength(50);

            Property(c => c.Estado)
                .IsRequired()
                .HasMaxLength(50);

            Property(c => c.CEP)
                .IsRequired()
                .HasMaxLength(10);

            Property(c => c.Numero)
                .IsRequired();

            HasMany(c => c.Vendas)
            .WithRequired(v => v.Concessionaria)
            .HasForeignKey(v => v.ConcessionariaId);

            ToTable("Concessionarias");
        }
    }
}
