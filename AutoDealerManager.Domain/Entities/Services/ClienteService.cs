using AutoDealerManager.Domain.Core.Services;
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
            await ValidarDadosCliente(cliente);

            await _clienteRepository.AdicionarAsync(cliente);
        }

        public async Task Atualizar(Cliente cliente)
        {
            await ValidarDadosCliente(cliente);

            await _clienteRepository.AtualizarAsync(cliente);
        }

        public async Task Remover(Cliente cliente)
        {
            await _clienteRepository.RemoverAsync(cliente);
        }

        private async Task ValidarDadosCliente(Cliente cliente)
        {
            if (!ExecutarValidacao(new ClienteValidation(), cliente))
                throw new Exception($"Erro de validação: {string.Join(",", errors)}");

            if (await _clienteRepository.ClienteExisteAsync(cliente.Id))
                throw new Exception("Este cliente já foi cadastrado.");

            if (await _clienteRepository.CpfExisteAsync(cliente.CPF))
                throw new Exception("Um cliente com este cpf já foi cadastrado.");
        }

        public void Dispose()
        {
            _clienteRepository?.Dispose();
        }
    }
}
