$(document).ready(function () {
    $("#btn-procurar-veiculos").on("click", function (event) {
        event.preventDefault();
        obterModalVeiculos();
    });

    $("#btn-procurar-concessionarias").on("click", function (event) {
        event.preventDefault();
        obterModalConcessionarias();
    });
});