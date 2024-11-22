using AutoDealerManager.Domain.Entities;
using AutoDealerManager.Infra.CrossCutting.Identity.Models;
using AutoDealerManager.Infra.Data.EntityConfig;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Data.Entity;

namespace AutoDealerManager.Infra.CrossCutting.Identity.Context
{
    public class AutoDealerIdentityDbContext : IdentityDbContext<ApplicationUser>, IDisposable
    {
        public AutoDealerIdentityDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static AutoDealerIdentityDbContext Create()
        {
            return new AutoDealerIdentityDbContext();
        }

        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UsuarioConfig());

            base.OnModelCreating(modelBuilder);
        }
    }
}
