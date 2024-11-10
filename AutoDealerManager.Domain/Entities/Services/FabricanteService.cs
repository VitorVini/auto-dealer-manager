using AutoDealerManager.CrossCutting.Helpers.Validations;
using AutoDealerManager.Domain.Core.Services;
using AutoDealerManager.Domain.Entities.Validations;
using AutoDealerManager.Domain.Interfaces.Repositories;
using AutoDealerManager.Domain.Interfaces.Services;
using System;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace AutoDealerManager.Domain.Entities.Services
{
    public class FabricanteService : BaseService, IFabricanteService
    {
        private readonly IFabricanteRepository _fabricanteRepository;
        public FabricanteService(IFabricanteRepository fabricanteRepository)
        {
            _fabricanteRepository = fabricanteRepository;
        }
        public async Task Adicionar(Fabricante fabricante)
        {
            if (!ExecutarValidacao(new FabricanteValidation(), fabricante)) return;

            if (await _fabricanteRepository.NomeExisteAsync(fabricante.Nome)) return;

            if (!await WebsiteAcessivelAsync(fabricante.Website, new CancellationToken())) return;

            if (!AnoValidoUtils.ValidarAno(fabricante.AnoFundacao)) return;

            await _fabricanteRepository.Adicionar(fabricante);
        }

        public async Task Atualizar(Fabricante fabricante)
        {
            if (!ExecutarValidacao(new FabricanteValidation(), fabricante)) return;

            if (await _fabricanteRepository.NomeExisteAsync(fabricante.Nome)) return;

            if (!await WebsiteAcessivelAsync(fabricante.Website, new CancellationToken())) return;

            if (!AnoValidoUtils.ValidarAno(fabricante.AnoFundacao)) return;

            await _fabricanteRepository.Atualizar(fabricante);
        }

        public async Task Remover(Guid id)
        {
            var fabricante = await _fabricanteRepository.ObterFabricanteVeiculosAsync(id);

            if (fabricante.Veiculos.Any())
            {
                return; // TO DO 
            }

            await _fabricanteRepository.Remover(id);
        }

        public async Task<bool> WebsiteAcessivelAsync(string website, CancellationToken cancellationToken)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.Timeout = TimeSpan.FromSeconds(5);
                    var response = await client.GetAsync(website, cancellationToken);
                    return response.IsSuccessStatusCode;
                }
            }
            catch
            {
                return false;
            }
        }

        public void Dispose()
        {
            _fabricanteRepository?.Dispose();
        }
    }
}
