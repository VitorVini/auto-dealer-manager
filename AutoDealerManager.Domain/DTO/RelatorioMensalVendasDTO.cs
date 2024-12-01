using System.Collections.Generic;

namespace AutoDealerManager.Domain.DTO
{
    public class RelatorioMensalVendasDTO
    {
        public decimal TotalVendas { get; set; }

        public Dictionary<string, decimal> VendasPorTipo { get; set; }

        public Dictionary<string, decimal> VendasPorFabricante { get; set; }

        public Dictionary<string, decimal> VendasPorConcessionaria { get; set; }
    }
}