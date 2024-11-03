using AutoDealerManager.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace AutoDealerManager.Infra.Data.EntityConfig
{
    public class EnderecoConfig : EntityTypeConfiguration<Endereco>
    {
        public EnderecoConfig()
        {
            HasKey(e => e.Id);

            HasRequired(e => e.Concessionaria)
                .WithRequiredDependent(c => c.Endereco);

            Property(e => e.Rua)
                .IsRequired()
                .HasMaxLength(255);

            Property(e => e.Cidade)
                .IsRequired()
                .HasMaxLength(50);

            Property(e => e.Estado)
                .IsRequired()
                .HasMaxLength(50);

            Property(e => e.CEP)
                .IsRequired()
                .HasMaxLength(10);

            ToTable("Enderecos");
        }
    }
}
