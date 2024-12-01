using AutoDealerManager.Domain.Core.Services;
using AutoDealerManager.Domain.Entities.Validations;
using AutoDealerManager.Domain.Interfaces.Repositories;
using AutoDealerManager.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
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
            await TratarCliente(venda);

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
            var veiculo = await _veiculoRepository.ObterPorIdAsync(venda.VeiculoId);

            ExecutarValidacaoValidator(new VendaValidation(), venda);
            ExecutarValidacaoValidator(new ClienteValidation(), venda.Cliente);

            ExecutarValidacao(veiculo != null, "Este veículo não existe ou não está disponível.");
            ExecutarValidacao(await _concessionariaRepository.ObterPorIdAsync(venda.ConcessionariaId) != null, "Esta concessionária não existe ou não está disponível");
            ExecutarValidacao(venda.Preco >= veiculo.Preco, "Não é possível vender um veículo com um preço menor do que o cadastrado");

            VerificarErros();
        }
        // TO DO: ASSOCIAR VENDAS PARA NÃO QUEBRAR QUANDO O CLIENTE FOR O MESMO
        private async Task TratarCliente(Venda venda)
        {
            var cliente = await _clienteRepository.ObterPorCpfAsync(venda.Cliente.CPF);

            if (cliente != null)
            {
                venda.Cliente = cliente;
                venda.Cliente.Id = cliente.Id;

                if (cliente.Vendas == null)
                    cliente.Vendas = new List<Venda>();

                cliente.Vendas.Add(venda);
            }
            else
            {
                venda.Cliente.Id = Guid.NewGuid();
                venda.Cliente.Vendas = new List<Venda> { venda };
            }
            venda.ClienteId = venda.Cliente.Id;
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
