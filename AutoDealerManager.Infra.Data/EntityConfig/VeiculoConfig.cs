using AutoDealerManager.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;

namespace AutoDealerManager.Infra.Data.EntityConfig
{
    public class VeiculoConfig : EntityTypeConfiguration<Veiculo>
    {
        public VeiculoConfig()
        {
            HasKey(v => v.Id);

            Property(v => v.Modelo)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnAnnotation("IX_Modelo", new IndexAnnotation(new IndexAttribute { IsUnique = true }));

            Property(v => v.AnoFabricacao)
                .IsRequired();

            Property(v => v.Preco)
                .IsRequired()
                .HasPrecision(10, 2);

            Property(v => v.FabricanteId)
                .IsRequired();

            Property(v => v.TipoVeiculo)
                .IsRequired();

            Property(v => v.Descricao)
                .IsOptional();

            HasMany(v => v.Vendas)
            .WithRequired(venda => venda.Veiculo)
            .HasForeignKey(venda => venda.VeiculoId);

            ToTable("Veiculos");
        }
    }
}
