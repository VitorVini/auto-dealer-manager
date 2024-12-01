using AutoDealerManager.Domain.Entities;
using AutoDealerManager.Domain.Interfaces.Repositories;
using AutoDealerManager.Infra.Data.Context;
using System;
using System.Data.Entity;
using System.Threading.Tasks;

namespace AutoDealerManager.Infra.Data.Repositories
{
    public class ClienteRepository : Repository<Cliente>, IClienteRepository
    {
        public ClienteRepository(AutoDealerManagerContext context) : base(context) { }

        public async Task<bool> ClienteExisteAsync(Guid id, string cpf)
        {
            return await Db.Clientes.AnyAsync(c => c.Id == id && c.CPF == cpf && c.Ativo);
        }

        public async Task<Cliente> ObterPorCpfAsync(string cpf)
        {
            return await Db.Clientes.FirstOrDefaultAsync(c => c.CPF == cpf && c.Ativo);
        }
    }
}

