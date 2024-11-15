﻿using AutoDealerManager.Domain.Core.Services;
using AutoDealerManager.Domain.Entities.Validations;
using AutoDealerManager.Domain.Interfaces.Repositories;
using AutoDealerManager.Domain.Interfaces.Services;
using System;
using System.Threading.Tasks;

namespace AutoDealerManager.Domain.Entities.Services
{
    public class ClienteService : BaseService, IClienteService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }
        public async Task Adicionar(Cliente cliente)
        {
            if (!ExecutarValidacao(new ClienteValidation(), cliente)) return;

            if (await _clienteRepository.ClienteExisteAsync(cliente.Id)) return;

            if (await _clienteRepository.CpfExisteAsync(cliente.CPF)) return;

            if (await _clienteRepository.NomeExisteAsync(cliente.Nome)) return;

            await _clienteRepository.AdicionarAsync(cliente);
        }

        public async Task Atualizar(Cliente cliente)
        {
            if (!ExecutarValidacao(new ClienteValidation(), cliente)) return;

            if (await _clienteRepository.ClienteExisteAsync(cliente.Id)) return;

            if (await _clienteRepository.CpfExisteAsync(cliente.CPF)) return;

            if (await _clienteRepository.NomeExisteAsync(cliente.Nome)) return;

            await _clienteRepository.AtualizarAsync(cliente);
        }

        public async Task Remover(Cliente cliente)
        {
            await _clienteRepository.RemoverAsync(cliente);
        }

        public void Dispose()
        {
            _clienteRepository?.Dispose();
        }
    }
}
