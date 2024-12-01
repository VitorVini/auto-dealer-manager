using AutoDealerManager.Domain.DTO;
using AutoDealerManager.Domain.Interfaces.Repositories;
using ClosedXML.Excel;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AutoDealerManager.Application.Services
{
    public class RelatorioAppService : IRelatorioAppService
    {
        private readonly IVendaRepository _vendaRepository;
        public RelatorioAppService(IVendaRepository vendaRepository)
        {
            _vendaRepository = vendaRepository;
        }

        public async Task<RelatorioMensalVendasDTO> GerarRelatorioMensal(int mes, int ano)
        {
            var vendas = await _vendaRepository.ObterVendasPorMesAno(mes, ano);

            if (mes < 1 || mes > 12 || ano < 1900 || ano > DateTime.Now.Year)
                return null;


            if (vendas == null || !vendas.Any())
                return null;

            var totalVendas = vendas.Sum(v => v.Preco);

            var vendasPorTipo = await _vendaRepository.ObterVendasPorTipoDeVeiculoAsync(mes, ano);
            var vendasPorFabricante = await _vendaRepository.ObterVendasPorFabricanteAsync(mes, ano);
            var vendasPorConcessionaria = await _vendaRepository.ObterVendasPorConcessionariaAsync(mes, ano);

            return new RelatorioMensalVendasDTO
            {
                TotalVendas = totalVendas,
                VendasPorTipo = vendasPorTipo,
                VendasPorFabricante = vendasPorFabricante,
                VendasPorConcessionaria = vendasPorConcessionaria
            };
        }
        public byte[] GerarRelatorioPDF(RelatorioMensalVendasDTO relatorio, int mes, int ano)
        {
            using (var stream = new MemoryStream())
            {
                var documento = new Document();
                PdfWriter.GetInstance(documento, stream);
                documento.Open();

                var titulo = new Paragraph($"Relatório Mensal de Vendas - {mes}/{ano}", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 16))
                {
                    Alignment = Element.ALIGN_CENTER
                };
                documento.Add(titulo);
                documento.Add(new Paragraph("\n"));

                documento.Add(new Paragraph($"Receita Total: R$ {relatorio.TotalVendas.ToString("N2")}", FontFactory.GetFont(FontFactory.HELVETICA, 12)));
                documento.Add(new Paragraph("\n\nVendas por Tipo de Veículo:"));
                foreach (var tipo in relatorio.VendasPorTipo)
                {
                    documento.Add(new Paragraph($"{tipo.Key}: {tipo.Value}"));
                }

                documento.Add(new Paragraph("\n\nVendas por Fabricante:"));
                foreach (var fabricante in relatorio.VendasPorFabricante)
                {
                    documento.Add(new Paragraph($"{fabricante.Key}: {fabricante.Value}"));
                }

                documento.Add(new Paragraph("\n\nVendas por Concessionária:"));
                foreach (var concessionaria in relatorio.VendasPorConcessionaria)
                {
                    documento.Add(new Paragraph($"{concessionaria.Key}: {concessionaria.Value}"));
                }

                documento.Close();
                return stream.ToArray();
            }
        }

        public byte[] GerarRelatorioExcel(RelatorioMensalVendasDTO relatorio, int mes, int ano)
        {
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Relatório");

                worksheet.Cell(1, 1).Value = "Relatório Mensal de Vendas";
                worksheet.Cell(2, 1).Value = $"Período: {mes}/{ano}";
                worksheet.Cell(3, 1).Value = $"Receita Total: R$ {relatorio.TotalVendas.ToString("N2")}";

                worksheet.Cell(5, 1).Value = "Vendas por Tipo de Veículo:";
                int row = 6;
                foreach (var tipo in relatorio.VendasPorTipo)
                {
                    worksheet.Cell(row, 1).Value = tipo.Key;
                    worksheet.Cell(row, 2).Value = tipo.Value;
                    row++;
                }

                row += 2;
                worksheet.Cell(row, 1).Value = "Vendas por Fabricante:";
                row++;
                foreach (var fabricante in relatorio.VendasPorFabricante)
                {
                    worksheet.Cell(row, 1).Value = fabricante.Key;
                    worksheet.Cell(row, 2).Value = fabricante.Value;
                    row++;
                }

                row += 2;
                worksheet.Cell(row, 1).Value = "Vendas por Concessionária:";
                row++;
                foreach (var concessionaria in relatorio.VendasPorConcessionaria)
                {
                    worksheet.Cell(row, 1).Value = concessionaria.Key;
                    worksheet.Cell(row, 2).Value = concessionaria.Value;
                    row++;
                }

                worksheet.Columns().AdjustToContents();
                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    return stream.ToArray();
                }
            }
        }
    }
}