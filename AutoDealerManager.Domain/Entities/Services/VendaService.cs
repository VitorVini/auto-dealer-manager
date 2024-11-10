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
            if (!ExecutarValidacao(new VendaValidation(), venda)) return;

            var veiculo = await _veiculoRepository.ObterPorId(venda.VeiculoId);
            if (veiculo == null) return;

            if (venda.PrecoVenda > veiculo.Preco) return;

            var cliente = await _clienteRepository.ObterPorId(venda.ClienteId);
            if (cliente == null) return;

            var concessionaria = await _concessionariaRepository.ObterPorId(venda.ConcessionariaId);
            if (concessionaria == null) return;

            venda.Protocolo = Guid.NewGuid().ToString();

            await _vendaRepository.Adicionar(venda);
        }

        public async Task Atualizar(Venda venda)
        {
            var veiculo = await _veiculoRepository.ObterPorId(venda.VeiculoId);
            if (veiculo == null) return;

            if (venda.PrecoVenda > veiculo.Preco) return;

            var cliente = await _clienteRepository.ObterPorId(venda.ClienteId);
            if (cliente == null) return;

            var concessionaria = await _concessionariaRepository.ObterPorId(venda.ConcessionariaId);
            if (concessionaria == null) return;

            await _vendaRepository.Atualizar(venda);
        }

        public async Task Remover(Guid id)
        {
            await _vendaRepository.Remover(id);
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
