using AutoDealerManager.Domain.Core.Services;
using AutoDealerManager.Domain.Entities.Validations;
using AutoDealerManager.Domain.Interfaces.Repositories;
using AutoDealerManager.Domain.Interfaces.Services;
using System;
using System.Threading.Tasks;

namespace AutoDealerManager.Domain.Entities.Services
{
    public class ConcessionariaService : BaseService, IConcessionariaService
    {
        private readonly IConcessionariaRepository _concessionariaRepository;
        private readonly IEnderecoRepository _enderecoRepository;

        public ConcessionariaService(IConcessionariaRepository concessionariaRepository, IEnderecoRepository enderecoRepository)
        {
            _concessionariaRepository = concessionariaRepository;
            _enderecoRepository = enderecoRepository;
        }
        public async Task Adicionar(Concessionaria concessionaria)
        {
            // TO DO TESTAR 
            //concessionaria.Endereco.Id = concessionaria.Id;
            //concessionaria.Endereco.Concessionaria = concessionaria;

            if (!ExecutarValidacao(new ConcessionariaValidation(), concessionaria) ||
                !ExecutarValidacao(new EnderecoValidation(), concessionaria.Endereco)) return;

            if (await _concessionariaRepository.ConcessionariaExisteAsync(concessionaria.Nome)) return;

            await _concessionariaRepository.AdicionarAsync(concessionaria);
        }

        public async Task Atualizar(Concessionaria concessionaria) // Não terei que atualizar nada no sistema
        {
            if (!ExecutarValidacao(new ConcessionariaValidation(), concessionaria)) return;

            if (await _concessionariaRepository.ConcessionariaExisteAsync(concessionaria.Nome)) return;

            await _concessionariaRepository.AtualizarAsync(concessionaria);
        }

        public async Task Remover(Concessionaria concessionaria)
        {
            await _concessionariaRepository.RemoverAsync(concessionaria);
        }

        public void Dispose()
        {
            _concessionariaRepository?.Dispose();
            _enderecoRepository?.Dispose();
        }

    }
}
