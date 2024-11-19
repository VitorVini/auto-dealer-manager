using AutoDealerManager.CrossCutting.Helpers.Validations;
using AutoDealerManager.Domain.Core.Services;
using AutoDealerManager.Domain.Entities.Validations;
using AutoDealerManager.Domain.Interfaces.Repositories;
using AutoDealerManager.Domain.Interfaces.Services;
using System;
using System.Threading.Tasks;

namespace AutoDealerManager.Domain.Entities.Services
{
    public class VeiculoService : BaseService, IVeiculoService
    {
        private readonly IVeiculoRepository _veiculoRepository;
        private readonly IFabricanteRepository _fabricanteRepository;
        public VeiculoService(IVeiculoRepository veiculoRepository, IFabricanteRepository fabricanteRepository)
        {
            _veiculoRepository = veiculoRepository;
            _fabricanteRepository = fabricanteRepository;
        }
        public async Task Adicionar(Veiculo veiculo)
        {
            await ValidarDadosVeiculoAsync(veiculo);
            await _veiculoRepository.AdicionarAsync(veiculo);
        }

        public async Task Atualizar(Veiculo veiculo)
        {
            await ValidarDadosVeiculoAsync(veiculo);
            await _veiculoRepository.AtualizarAsync(veiculo);
        }

        private async Task ValidarDadosVeiculoAsync(Veiculo veiculo)
        {
            if (!ExecutarValidacao(new VeiculoValidation(), veiculo))
                throw new Exception($"Erro de validação: {string.Join(",", errors)}");

            if (!AnoValidoUtils.ValidarAno(veiculo.AnoFabricacao))
                throw new Exception("Ano inválido.");

            if (!await _fabricanteRepository.FabricanteExisteAsync(veiculo.FabricanteId))
                throw new Exception("Fabricante não vinculado.");

            if (await _veiculoRepository.VeiculoExisteAsync(veiculo.Id, veiculo.Modelo))
                throw new Exception("Este veículo já foi cadastrado.");
        }

        public async Task Remover(Veiculo veiculo)
        {
            await _veiculoRepository.RemoverAsync(veiculo);
        }

        public void Dispose()
        {
            _veiculoRepository?.Dispose();
            _fabricanteRepository?.Dispose();
        }
    }
}
