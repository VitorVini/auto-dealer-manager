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
            if (!ExecutarValidacao(new VeiculoValidation(), veiculo)) return;

            if (!AnoValidoUtils.ValidarAno(veiculo.AnoFabricacao)) return;

            if (!await _fabricanteRepository.FabricanteExisteAsync(veiculo.FabricanteId)) return; // TO DO Notificações de erros em todos os services

            if (await _veiculoRepository.VeiculoExisteAsync(veiculo.Modelo)) return;

            await _veiculoRepository.Adicionar(veiculo);
        }

        public async Task Atualizar(Veiculo veiculo)
        {
            if (!ExecutarValidacao(new VeiculoValidation(), veiculo)) return;

            if (!AnoValidoUtils.ValidarAno(veiculo.AnoFabricacao)) return;

            if (!await _fabricanteRepository.FabricanteExisteAsync(veiculo.FabricanteId)) return; // TO DO Notificações de erros em todos os services

            if (await _veiculoRepository.VeiculoExisteAsync(veiculo.Modelo)) return;

            await _veiculoRepository.Atualizar(veiculo);
        }

        public async Task Remover(Guid id)
        {
            await _veiculoRepository.Remover(id);
        }

        public void Dispose()
        {
            _veiculoRepository?.Dispose();
            _fabricanteRepository?.Dispose();
        }
    }
}
