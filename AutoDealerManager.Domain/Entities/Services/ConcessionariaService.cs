using AutoDealerManager.Domain.Core.Services;
using AutoDealerManager.Domain.Entities.Validations;
using AutoDealerManager.Domain.Interfaces.Repositories;
using AutoDealerManager.Domain.Interfaces.Services;
using System.Threading.Tasks;

namespace AutoDealerManager.Domain.Entities.Services
{
    public class ConcessionariaService : BaseService, IConcessionariaService
    {
        private readonly IConcessionariaRepository _concessionariaRepository;

        public ConcessionariaService(IConcessionariaRepository concessionariaRepository)
        {
            _concessionariaRepository = concessionariaRepository;
        }
        public async Task Adicionar(Concessionaria concessionaria)
        {
            await ValidarDadosConcessionariaAsync(concessionaria);
            await _concessionariaRepository.AdicionarAsync(concessionaria);
        }

        public async Task Atualizar(Concessionaria concessionaria)
        {
            await ValidarDadosConcessionariaAsync(concessionaria);
            await _concessionariaRepository.AtualizarAsync(concessionaria);
        }

        public async Task Remover(Concessionaria concessionaria)
        {
            await _concessionariaRepository.RemoverAsync(concessionaria);
        }

        private async Task ValidarDadosConcessionariaAsync(Concessionaria concessionaria)
        {
            ExecutarValidacaoValidator(new ConcessionariaValidation(), concessionaria);

            ExecutarValidacao(!await _concessionariaRepository.ConcessionariaExisteAsync(concessionaria.Id, concessionaria.Nome), "Esta concessionária já foi cadastrada.");

            VerificarErros();
        }

        public void Dispose()
        {
            _concessionariaRepository?.Dispose();
        }

    }
}
