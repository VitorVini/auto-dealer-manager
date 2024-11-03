using AutoDealerManager.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;

namespace AutoDealerManager.Infra.Data.EntityConfig
{
    public class ClienteConfig : EntityTypeConfiguration<Cliente>
    {
        public ClienteConfig()
        {
            HasKey(c => c.Id);

            Property(c => c.Nome)
                .IsRequired()
                .HasMaxLength(100);

            Property(c => c.CPF)
                .IsRequired()
                .HasMaxLength(11)
                .IsFixedLength()
                .HasColumnAnnotation("IX_CPF", new IndexAnnotation(new IndexAttribute { IsUnique = true }));

            Property(c => c.Telefone)
                .IsRequired()
                .HasMaxLength(15);

            HasMany(c => c.Vendas)
            .WithRequired(v => v.Cliente)
            .HasForeignKey(v => v.ClienteId);

            ToTable("Clientes");
        }
    }
}
