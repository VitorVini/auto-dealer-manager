document.addEventListener("DOMContentLoaded", function () {
    let graficosAtuais = []; 

    function gerarGrafico(dados) {
        graficosAtuais.forEach((grafico) => grafico.destroy());
        graficosAtuais = []; 

        const tiposVeiculos = Object.keys(dados.VendasPorTipo);
        const vendasPorTipo = Object.values(dados.VendasPorTipo);

        const graficoTipo = new Chart(document.getElementById("graficoVendasTipoVeiculo"), {
            type: "bar",
            data: {
                labels: tiposVeiculos,
                datasets: [{
                    label: "Vendas por Tipo de Veículo",
                    data: vendasPorTipo,
                    backgroundColor: "rgba(75, 192, 192, 0.2)",
                    borderColor: "rgba(75, 192, 192, 1)",
                    borderWidth: 1
                }]
            },
            options: {
                responsive: true
            }
        });
        graficosAtuais.push(graficoTipo);

        const fabricantes = Object.keys(dados.VendasPorFabricante);
        const vendasPorFabricante = Object.values(dados.VendasPorFabricante);

        const graficoFabricante = new Chart(document.getElementById("graficoVendasFabricante"), {
            type: "pie",
            data: {
                labels: fabricantes,
                datasets: [{
                    label: "Vendas por Fabricante",
                    data: vendasPorFabricante,
                    backgroundColor: ["#FF6384", "#36A2EB", "#FFCE56", "#4BC0C0", "#9966FF", "#FF9F40"]
                }]
            },
            options: {
                responsive: true,
                maintainAspectRatio: false, 
                plugins: {
                    legend: {
                        position: 'bottom', 
                    }
                },
                layout: {
                    padding: 10, 
                }
            }
        });

        graficosAtuais.push(graficoFabricante);

        const concessionarias = Object.keys(dados.VendasPorConcessionaria);
        const vendasPorConcessionaria = Object.values(dados.VendasPorConcessionaria);

        const graficoConcessionaria = new Chart(document.getElementById("graficoVendasConcessionaria"), {
            type: "bar",
            data: {
                labels: concessionarias,
                datasets: [{
                    label: "Vendas por Concessionária",
                    data: vendasPorConcessionaria,
                    backgroundColor: "rgba(153, 102, 255, 0.2)",
                    borderColor: "rgba(153, 102, 255, 1)",
                    borderWidth: 1
                }]
            },
            options: {
                responsive: true
            }
        });
        graficosAtuais.push(graficoConcessionaria);

        const receitaTotal = dados.TotalVendas;
        document.getElementById("receitaTotal").textContent = `Receita Total: R$ ${receitaTotal.toLocaleString("pt-BR", { minimumFractionDigits: 2 })}`;
    }

    function carregarDadosRelatorio() {
        const mes = document.getElementById("mes").value;
        const ano = document.getElementById("ano").value;

        fetch(`/Relatorios/ObterRelatorioMensal?mes=${mes}&ano=${ano}`)
            .then(response => response.json())
            .then(dados => {
                if (!dados.Sucesso || !dados.Relatorio) {
                    Swal.fire({
                        icon: 'error',
                        title: 'Erro',
                        text: dados.Mensagem,
                    });
                    return;
                }
                gerarGrafico(dados.Relatorio);
            })
            .catch(error => {
                console.error("Erro ao carregar os dados do relatório:", error);
            });
    }

    document.getElementById("btnGerarRelatorio").addEventListener("click", carregarDadosRelatorio);
});
