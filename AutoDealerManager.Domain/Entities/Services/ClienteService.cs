using AutoDealerManager.Domain.Core.Services;
using AutoDealerManager.Domain.Entities.Validations;
using AutoDealerManager.Domain.Interfaces.Repositories;
using AutoDealerManager.Domain.Interfaces.Services;
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
            await ValidarDadosClienteAsync(cliente);

            await _clienteRepository.AdicionarAsync(cliente);
        }

        public async Task Atualizar(Cliente cliente)
        {
            await ValidarDadosClienteAsync(cliente);

            await _clienteRepository.AtualizarAsync(cliente);
        }

        public async Task Remover(Cliente cliente)
        {
            await _clienteRepository.RemoverAsync(cliente);
        }

        private async Task ValidarDadosClienteAsync(Cliente cliente)
        {
            ExecutarValidacaoValidator(new ClienteValidation(), cliente);

            ExecutarValidacao(!await _clienteRepository.ClienteExisteAsync(cliente.Id, cliente.CPF), "Este cliente já foi cadastrado.");

            VerificarErros();
        }

        public void Dispose()
        {
            _clienteRepository?.Dispose();
        }
    }
}
