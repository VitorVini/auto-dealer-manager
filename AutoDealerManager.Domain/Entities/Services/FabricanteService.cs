using AutoDealerManager.CrossCutting.Helpers.Validations;
using AutoDealerManager.Domain.Core.Services;
using AutoDealerManager.Domain.Entities.Validations;
using AutoDealerManager.Domain.Interfaces.Repositories;
using AutoDealerManager.Domain.Interfaces.Services;
using System.Threading.Tasks;

namespace AutoDealerManager.Domain.Entities.Services
{
    public class FabricanteService : BaseService, IFabricanteService
    {
        private readonly IFabricanteRepository _fabricanteRepository;
        private readonly IVeiculoRepository _veiculoRepository;
        public FabricanteService(IFabricanteRepository fabricanteRepository, IVeiculoRepository veiculoRepository)
        {
            _fabricanteRepository = fabricanteRepository;
            _veiculoRepository = veiculoRepository;
        }

        public async Task Adicionar(Fabricante fabricante)
        {
            await ValidarDadosFabricanteAsync(fabricante);
            await _fabricanteRepository.AdicionarAsync(fabricante);
        }

        public async Task Atualizar(Fabricante fabricante)
        {
            await ValidarDadosFabricanteAsync(fabricante);
            await _fabricanteRepository.AtualizarAsync(fabricante);
        }

        private async Task ValidarDadosFabricanteAsync(Fabricante fabricante)
        {
            ExecutarValidacaoValidator(new FabricanteValidation(), fabricante);

            ExecutarValidacao(!await _fabricanteRepository.NomeExisteAsync(fabricante.Id, fabricante.Nome), "Fabricante já cadastrado.");
            ExecutarValidacao(WebsiteAcessivel(fabricante.Website), "Website inválido.");
            ExecutarValidacao(AnoValidoUtils.ValidarAno(fabricante.AnoFundacao), "Ano inválido, deve representar uma data no presente ou passado.");

            VerificarErros();
        }

        public async Task Remover(Fabricante fabricante)
        {
            await _fabricanteRepository.RemoverAsync(fabricante);
            var veiculos = await _veiculoRepository.ObterPorFabricanteAsync(fabricante.Id);

            foreach (var veiculo in veiculos)
            {
                await _veiculoRepository.RemoverAsync(veiculo);
            }
        }
        public bool WebsiteAcessivel(string website)
        {
            return WebsiteValidoUtils.IsUrlValid(website);
        }

        public void Dispose()
        {
            _fabricanteRepository?.Dispose();
        }
    }
}
