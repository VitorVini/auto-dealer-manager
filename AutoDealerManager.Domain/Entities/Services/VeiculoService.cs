using AutoDealerManager.CrossCutting.Helpers.Validations;
using AutoDealerManager.Domain.Core.Services;
using AutoDealerManager.Domain.Entities.Validations;
using AutoDealerManager.Domain.Interfaces.Repositories;
using AutoDealerManager.Domain.Interfaces.Services;
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
            ExecutarValidacaoValidator(new VeiculoValidation(), veiculo);

            ExecutarValidacao(AnoValidoUtils.ValidarAno(veiculo.AnoFabricacao), "Ano inválido");
            ExecutarValidacao(await _fabricanteRepository.FabricanteExisteAsync(veiculo.FabricanteId), "Fabricante não vinculado");
            ExecutarValidacao(!await _veiculoRepository.VeiculoExisteAsync(veiculo.Id, veiculo.Modelo), "Este veículo já foi cadastrado");

            VerificarErros();
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