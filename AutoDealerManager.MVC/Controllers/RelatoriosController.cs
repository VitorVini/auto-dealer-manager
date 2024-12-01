using AutoDealerManager.Application.Services;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AutoDealerManager.MVC.Controllers
{
    public class RelatoriosController : Controller
    {
        private readonly IRelatorioAppService _relatorioAppService;

        public RelatoriosController(IRelatorioAppService relatorioAppService)
        {
            _relatorioAppService = relatorioAppService;
        }

        public ActionResult RelatorioMensal()
        {
            return View();
        }

        [HttpGet]
        public async Task<JsonResult> ObterRelatorioMensal(int mes, int ano)
        {
            var relatorio = await _relatorioAppService.GerarRelatorioMensal(mes, ano);

            if (relatorio == null)
            {
                return Json(new
                {
                    Sucesso = false,
                    Mensagem = "Não há dados disponíveis para o relatório."
                }, JsonRequestBehavior.AllowGet);
            }

            return Json(new
            {
                Relatorio = relatorio,
                Sucesso = true
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public async Task<ActionResult> ExportarParaPDF(int mes, int ano)
        {
            var relatorio = await _relatorioAppService.GerarRelatorioMensal(mes, ano);
            var pdfBytes = _relatorioAppService.GerarRelatorioPDF(relatorio, mes, ano);
            return File(pdfBytes, "application/pdf", $"Relatorio_Mensal_{mes}_{ano}.pdf");
        }

        [HttpGet]
        public async Task<ActionResult> ExportarParaExcel(int mes, int ano)
        {
            var relatorio = await _relatorioAppService.GerarRelatorioMensal(mes, ano);
            var excelBytes = _relatorioAppService.GerarRelatorioExcel(relatorio, mes, ano);
            return File(excelBytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", $"Relatorio_Mensal_{mes}_{ano}.xlsx");
        }
    }
}