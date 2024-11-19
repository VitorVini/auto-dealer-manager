function buscaCep() {
    $(document).ready(function () {

        function limpa_formulario_cep() {
            $("#Rua").val("");
            $("#Cidade").val("");
            $("#Estado").val("");
        }

        $("#CEP").blur(function () {

            var cep = $(this).val().replace(/\D/g, '');

            if (cep != "") {

                var validacep = /^[0-9]{8}$/;

                if (validacep.test(cep)) {

                    $("#Rua").val("...");
                    $("#Cidade").val("...");
                    $("#Estado").val("...");

                    $.getJSON("https://viacep.com.br/ws/" + cep + "/json/?callback=?",
                        function (dados) {

                            if (!("erro" in dados)) {
                                $("#Rua").val(dados.logradouro);
                                $("#Cidade").val(dados.localidade);
                                $("#Estado").val(dados.uf);
                            }
                            else {
                                limpa_formulario_cep();
                                alert("CEP não encontrado.");
                            }
                        });
                }
                else {
                    limpa_formulario_cep();
                    alert("Formato de CEP inválido.");
                }
            }
            else {
                limpa_formulario_cep();
            }
        });
    });
}

function selecionarVeiculo(id, modelo) {
    $("#VeiculoId").val(id);
    $("#NomeVeiculo").val(modelo);
}

function selecionarConcessionaria(id, nome) {
    $("#ConcessionariaId").val(id);
    $("#NomeConcessionaria").val(nome);
}

function obterModalVeiculos() {
    var url = "/Veiculos/ObterModal";
    $("#loading").show();
    $.ajax({
        url: url,
        type: "GET",
        success: function (data) {
            $('#modalTitle').text('Veículos');
            $('#modalContent').html(data);
            $("#divModal").modal('show');
        },
        error: function () {
            alert("Ocorreu um erro ao carregar a o modal de veículos.");
        }, 
        complete: function () {
            $("#loading").hide();
        }
    });
}

function obterModalConcessionarias() {
    var url = "/Concessionarias/ObterModal";
    $("#loading").show();
    $.ajax({
        url: url,
        type: "GET",
        success: function (data) {
            $('#modalTitle').text('Concessionárias');
            $('#modalContent').html(data);
            $("#divModal").modal('show');
        },
        error: function () {
            alert("Ocorreu um erro ao carregar a o modal de concessionárias.");
        },
        complete: function () {
            $("#loading").hide();
        }
    });
}

function inicializarDataTable(tableId) {
    $(document).ready(function () {
        $(tableId).DataTable({
            "autoWidth": false,
            "language": {
                "sEmptyTable": "Nenhum dado disponível na tabela",
                "sInfo": "Mostrando _START_ até _END_ de _TOTAL_ registros",
                "sInfoEmpty": "Mostrando 0 até 0 de 0 registros",
                "sInfoFiltered": "(filtrado de _MAX_ registros no total)",
                "sLengthMenu": "Exibir _MENU_ registros por página",
                "sLoadingRecords": "Carregando...",
                "sProcessing": "Processando...",
                "sSearch": "Buscar:",
                "sZeroRecords": "Nenhum registro encontrado",
                "oPaginate": {
                    "sFirst": "Primeira",
                    "sPrevious": "Anterior",
                    "sNext": "Próxima",
                    "sLast": "Última"
                },
                "oAria": {
                    "sSortAscending": ": Ativar para ordenar a coluna de forma ascendente",
                    "sSortDescending": ": Ativar para ordenar a coluna de forma descendente"
                }
            },
            "columnDefs": [
            {
                "targets": -1,  // Última coluna
                "orderable": false,  // Impede a ordenação
                "searchable": false,  // Impede o filtro
                "width": "60px"
                }
            ]
        });
    });
}