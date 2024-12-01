using AutoDealerManager.Domain.Entities;
using AutoDealerManager.Domain.Interfaces.Repositories;
using AutoDealerManager.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace AutoDealerManager.Infra.Data.Repositories
{
    public class VendaRepository : Repository<Venda>, IVendaRepository
    {
        public VendaRepository(AutoDealerManagerContext context) : base(context)
        {

        }
        public async Task<IEnumerable<Venda>> ObterPorDataAsync(DateTime dataInicio, DateTime dataFim)
        {
            return await DbSet
                .AsNoTracking()
                .Where(v => v.Data >= dataInicio && v.Data <= dataFim && v.Ativo)
                .ToListAsync();
        }

        public async Task<Venda> ObterPorProtocoloAsync(long protocolo)
        {
            return await DbSet.AsNoTracking().FirstOrDefaultAsync(v => v.Protocolo == protocolo && v.Ativo);
        }

        public override async Task<IEnumerable<Venda>> ObterTodosAsync()
        {
            return await DbSet
                .Where(v => v.Ativo)
                .Include(v => v.Cliente)
                .Include(v => v.Veiculo)
                .Include(v => v.Concessionaria)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<IEnumerable<Venda>> ObterVendasPorMesAno(int mes, int ano)
        {
            return await DbSet
                .Where(v => v.Ativo)
                .Include(v => v.Veiculo)
                .Include(v => v.Veiculo.Fabricante)
                .Include(v => v.Concessionaria)
                .Where(v => v.Data.Month == mes && v.Data.Year == ano)
                .ToListAsync();
        }

        public async Task<Dictionary<string, decimal>> ObterVendasPorTipoDeVeiculoAsync(int mes, int ano)
        {
            return await Db.Vendas
                .Where(v => v.Ativo && v.Data.Month == mes && v.Data.Year == ano)
                .GroupBy(v => v.Veiculo.TipoVeiculo)
                .Select(g => new { Tipo = g.Key.ToString(), Total = g.Sum(v => v.Preco) })
                .ToDictionaryAsync(g => g.Tipo, g => g.Total);
        }

        public async Task<Dictionary<string, decimal>> ObterVendasPorFabricanteAsync(int mes, int ano)
        {
            return await Db.Vendas
                .Where(v => v.Ativo && v.Data.Month == mes && v.Data.Year == ano)
                .GroupBy(v => v.Veiculo.Fabricante.Nome)
                .Select(g => new { Fabricante = g.Key, Total = g.Sum(v => v.Preco) })
                .ToDictionaryAsync(g => g.Fabricante, g => g.Total);
        }

        public async Task<Dictionary<string, decimal>> ObterVendasPorConcessionariaAsync(int mes, int ano)
        {
            return await Db.Vendas
                .Where(v => v.Ativo && v.Data.Month == mes && v.Data.Year == ano)
                .GroupBy(v => v.Concessionaria.Nome)
                .Select(g => new { Concessionaria = g.Key, Total = g.Sum(v => v.Preco) })
                .ToDictionaryAsync(g => g.Concessionaria, g => g.Total);
        }
    }
}
