using AutoDealerManager.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace AutoDealerManager.Infra.Data.EntityConfig
{
    public class VendaConfig : EntityTypeConfiguration<Venda>
    {
        public VendaConfig()
        {
            HasKey(v => v.Id);

            Property(v => v.DataVenda)
                .IsRequired();

            Property(v => v.PrecoVenda)
                .HasPrecision(10, 2)
                .IsRequired();

            Property(v => v.Protocolo)
                .IsRequired()
                .HasColumnName("ProtocoloVenda")
                .HasMaxLength(20);

            HasRequired(v => v.Veiculo)
                .WithMany(veiculo => veiculo.Vendas)
                .HasForeignKey(v => v.VeiculoId)
                .WillCascadeOnDelete(false);

            HasRequired(v => v.Concessionaria)
                .WithMany(concessionaria => concessionaria.Vendas)
                .HasForeignKey(v => v.ConcessionariaId)
                .WillCascadeOnDelete(false);

            HasRequired(v => v.Cliente)
                .WithMany(cliente => cliente.Vendas)
                .HasForeignKey(v => v.ClienteId)
                .WillCascadeOnDelete(false);

            ToTable("Vendas");
        }
    }
}
