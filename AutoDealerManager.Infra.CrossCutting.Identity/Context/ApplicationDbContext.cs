using AutoDealerManager.Infra.CrossCutting.Identity.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;

namespace AutoDealerManager.Infra.CrossCutting.Identity.Context
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>, IDisposable
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}
