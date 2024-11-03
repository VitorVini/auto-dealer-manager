using AutoDealerManager.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;

namespace AutoDealerManager.Infra.Data.EntityConfig
{
    public class FabricanteConfig : EntityTypeConfiguration<Fabricante>
    {
        public FabricanteConfig()
        {
            HasKey(f => f.Id);

            Property(f => f.Nome)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute { IsUnique = true }));

            Property(f => f.PaisOrigem)
                .IsRequired()
                .HasMaxLength(50);

            Property(f => f.AnoFundacao)
                .IsRequired();

            Property(f => f.Website)
                .HasMaxLength(255);

            HasMany(f => f.Veiculos)
                .WithMany(v => v.Fabricantes)
                .Map(m =>
                {
                    m.ToTable("FabricanteVeiculo");
                    m.MapLeftKey("FabricanteID");
                    m.MapRightKey("VeiculoID");
                });

            ToTable("Fabricantes");
        }
    }
}
