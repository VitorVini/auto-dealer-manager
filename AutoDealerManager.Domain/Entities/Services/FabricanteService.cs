using AutoDealerManager.CrossCutting.Helpers.Validations;
using AutoDealerManager.Domain.Core.Services;
using AutoDealerManager.Domain.Entities.Validations;
using AutoDealerManager.Domain.Interfaces.Repositories;
using AutoDealerManager.Domain.Interfaces.Services;
using System;
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
            if (!ExecutarValidacao(new FabricanteValidation(), fabricante))
                throw new Exception($"Erro de validação: {string.Join(",", errors)}");

            if (await _fabricanteRepository.NomeExisteAsync(fabricante.Id, fabricante.Nome))
                throw new Exception("Já existe um fabricante cadastrado com esse nome.");

            if (!WebsiteAcessivel(fabricante.Website))
                throw new Exception("Website não está acessível, favor verificar.");

            if (!AnoValidoUtils.ValidarAno(fabricante.AnoFundacao))
                throw new Exception("Ano inválido.");
        }

        public async Task Remover(Fabricante fabricante)
        {
            await _fabricanteRepository.RemoverAsync(fabricante);
        }

        //public async Task<bool> WebsiteAcessivelAsync(string website, CancellationToken cancellationToken)
        //{
        //    try
        //    {
        //        using (var client = new HttpClient())
        //        {
        //            client.Timeout = TimeSpan.FromSeconds(5);
        //            var response = await client.GetAsync(website, cancellationToken);
        //            return response.IsSuccessStatusCode;
        //        }
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //}

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
