using AutoDealerManager.Domain.Entities;
using AutoDealerManager.Infra.Data.EntityConfig;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace AutoDealerManager.Infra.Data.Context
{
    public class AutoDealerManagerContext : DbContext
    {
        public AutoDealerManagerContext()
            : base("DefaultConnection")
        {

        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Veiculo> Veiculos { get; set; }
        public DbSet<Fabricante> Fabricantes { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Concessionaria> Concessionarias { get; set; }
        public DbSet<Venda> Vendas { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Properties<string>()
            .Configure(p => p.HasColumnType("varchar"));

            modelBuilder.Configurations.Add(new UsuarioConfig());
            modelBuilder.Configurations.Add(new VeiculoConfig());
            modelBuilder.Configurations.Add(new FabricanteConfig());
            modelBuilder.Configurations.Add(new ClienteConfig());
            modelBuilder.Configurations.Add(new ConcessionariaConfig());
            modelBuilder.Configurations.Add(new VendaConfig());

            base.OnModelCreating(modelBuilder);
        }
    }
}
