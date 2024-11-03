using AutoDealerManager.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace AutoDealerManager.Infra.Data.EntityConfig
{
    public class UsuarioConfig : EntityTypeConfiguration<Usuario>
    {
        public UsuarioConfig()
        {
            HasKey(u => u.Id);

            Property(u => u.Email)
                .IsRequired()
                 .HasColumnName("Email")
                .HasMaxLength(100);

            Property(u => u.UserName)
                .IsRequired()
                .HasColumnName("NomeUsuario")
                .HasMaxLength(50);

            Property(u => u.Senha)
                .IsRequired()
                .HasColumnName("Senha")
                .HasMaxLength(255);

            ToTable("Usuarios");
        }
    }
}
