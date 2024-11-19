using AutoDealerManager.Domain.Entities;
using AutoDealerManager.Domain.Interfaces.Repositories;
using AutoDealerManager.Infra.Data.Context;
using System;
using System.Data.Entity;
using System.Threading.Tasks;

namespace AutoDealerManager.Infra.Data.Repositories
{
    public class ConcessionariaRepository : Repository<Concessionaria>, IConcessionariaRepository
    {
        public ConcessionariaRepository(AutoDealerManagerContext context) : base(context) { }

        public async Task<Concessionaria> ObterPorNomeAsync(string nome)
        {
            return await DbSet.FirstOrDefaultAsync(c => c.Nome == nome && c.Ativo);
        }

        public async Task<bool> ConcessionariaExisteAsync(Guid Id, string nome)
        {
            return await DbSet.AnyAsync(c => c.Nome == nome && c.Id == Id && c.Ativo);
        }
    }
}
