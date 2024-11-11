using AutoDealerManager.Application.Interfaces;
using AutoDealerManager.Domain.Entities;
using AutoDealerManager.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AutoDealerManager.Application.Services
{
    public class VendaApp : IVendaApp
    {
        private readonly IConcessionariaRepository _concessionariaRepository;
        private readonly IFabricanteRepository _fabricanteRepository;
        private readonly IVeiculoRepository _veiculoRepository;

        public VendaApp(
        IConcessionariaRepository concessionariaRepository,
        IFabricanteRepository fabricanteRepository,
        IVeiculoRepository veiculoRepository)
        {
            _concessionariaRepository = concessionariaRepository;
            _fabricanteRepository = fabricanteRepository;
            _veiculoRepository = veiculoRepository;
        }

        public async Task<IEnumerable<Concessionaria>> ObterConcessionariasAsync()
        {
            return await _concessionariaRepository.ObterTodosAsync();
        }

        public async Task<IEnumerable<Fabricante>> ObterFabricantesAsync()
        {
            return await _fabricanteRepository.ObterTodosAsync();
        }

        public async Task<IEnumerable<Veiculo>> ObterVeiculosPorFabricanteAsync(Guid fabricanteId)
        {
            return await _veiculoRepository.ObterPorFabricanteAsync(fabricanteId);
        }
    }
}
