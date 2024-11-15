﻿using AutoDealerManager.Domain.Entities;
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

        public async Task<bool> ClienteExisteAsync(Guid id)
        {
            return await Db.Clientes.AnyAsync(c => c.Id == id);
        }

        public async Task<bool> CpfExisteAsync(string cpf)
        {
            return await Db.Clientes.AnyAsync(c => c.CPF == cpf);
        }

        public async Task<bool> NomeExisteAsync(string nome)
        {
            return await Db.Clientes.AnyAsync(c => c.Nome == nome);
        }
    }
}

