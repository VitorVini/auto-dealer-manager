using AutoDealerManager.Domain.Core.Services;
using AutoDealerManager.Domain.Entities.Validations;
using AutoDealerManager.Domain.Interfaces.Repositories;
using AutoDealerManager.Domain.Interfaces.Services;
using System;
using System.Threading.Tasks;

namespace AutoDealerManager.Domain.Entities.Services
{
    public class VendaService : BaseService, IVendaService
    {
        private readonly IVendaRepository _vendaRepository;
        private readonly IConcessionariaRepository _concessionariaRepository;
        private readonly IVeiculoRepository _veiculoRepository;
        private readonly IClienteRepository _clienteRepository;

        public VendaService(
      IVendaRepository vendaRepository,
      IConcessionariaRepository concessionariaRepository,
      IVeiculoRepository veiculoRepository,
      IClienteRepository clienteRepository)
        {
            _vendaRepository = vendaRepository;
            _concessionariaRepository = concessionariaRepository;
            _veiculoRepository = veiculoRepository;
            _clienteRepository = clienteRepository;
        }

        public async Task Adicionar(Venda venda)
        {
            var cliente = await _clienteRepository.ObterPorCpfAsync(venda.Cliente.CPF);
            if (cliente != null)
                venda.Cliente.Id = cliente.Id;
            else
                venda.Cliente.Id = Guid.NewGuid();
            venda.ClienteId = venda.Cliente.Id;

            await ValidarDadosVendaAsync(venda);

            venda.Protocolo = long.Parse(DateTime.Now.ToString("yyyyMMddHHmmssfff"));

            await _vendaRepository.AdicionarAsync(venda);
        }

        public async Task Atualizar(Venda venda)
        {
            await ValidarDadosVendaAsync(venda);

            var cliente = await _clienteRepository.ObterPorIdAsync(venda.ClienteId);
            if (cliente == null) return;

            await _vendaRepository.AtualizarAsync(venda);
        }

        public async Task Remover(Venda venda)
        {
            await _vendaRepository.RemoverAsync(venda);
        }

        private async Task ValidarDadosVendaAsync(Venda venda)
        {
            if (!ExecutarValidacao(new VendaValidation(), venda))
                throw new Exception($"Erro de validação: {string.Join(",", errors)}");

            if (!ExecutarValidacao(new ClienteValidation(), venda.Cliente))
                throw new Exception($"Erro validação do cliente: {string.Join(",", errors)}");

            var veiculo = await _veiculoRepository.ObterPorIdAsync(venda.VeiculoId);

            if (veiculo == null)
                throw new Exception("Este veículo não existe ou não está disponível");

            if (await _concessionariaRepository.ObterPorIdAsync(venda.ConcessionariaId) == null)
                throw new Exception("Esta concessionária não existe ou não está disponível");

            if (venda.Preco < veiculo.Preco)
                throw new Exception("Não é possível vender um veículo com um preço menor do que o cadastrado");
        }

        public void Dispose()
        {
            _vendaRepository?.Dispose();
            _clienteRepository?.Dispose();
            _veiculoRepository?.Dispose();
            _concessionariaRepository?.Dispose();
        }
    }
}
