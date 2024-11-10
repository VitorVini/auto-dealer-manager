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

        public async Task<Concessionaria> ObterConcessionariaEndereco(Guid id)
        {
            return await Db.Concessionarias.AsNoTracking()
                .Include(c => c.Endereco)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Concessionaria> ObterPorNomeAsync(string nome)
        {
            return await DbSet.AsNoTracking().FirstOrDefaultAsync(c => c.Nome == nome);
        }

        public async Task<bool> ConcessionariaExisteAsync(string nome)
        {
            return await DbSet.AsNoTracking().AnyAsync(c => c.Nome == nome);
        }

        public async Task<Concessionaria> ObterPorEnderecoAsync(Endereco endereco)
        {
            return await Db.Concessionarias
                .Include(c => c.Endereco)
                .AsNoTracking()
                .FirstOrDefaultAsync(c =>
                c.Endereco.CEP == endereco.CEP &&
                c.Endereco.Estado == endereco.Estado &&
                c.Endereco.Cidade == endereco.Cidade &&
                c.Endereco.Rua == endereco.Rua &&
                c.Endereco.Numero == endereco.Numero);
        }

    }
}
