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

            HasRequired(c => c.Endereco)
                .WithRequiredPrincipal(e => e.Concessionaria);

            HasMany(c => c.Vendas)
            .WithRequired(v => v.Concessionaria)
            .HasForeignKey(v => v.ConcessionariaId);

            ToTable("Concessionarias");
        }
    }
}
