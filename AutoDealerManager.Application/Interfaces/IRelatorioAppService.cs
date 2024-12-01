using AutoDealerManager.Domain.DTO;
using System.Threading.Tasks;

namespace AutoDealerManager.Application.Services
{
    public interface IRelatorioAppService
    {
        Task<RelatorioMensalVendasDTO> GerarRelatorioMensal(int mes, int ano);
        byte[] GerarRelatorioPDF(RelatorioMensalVendasDTO relatorio, int mes, int ano);
        byte[] GerarRelatorioExcel(RelatorioMensalVendasDTO relatorio, int mes, int ano);
    }
}