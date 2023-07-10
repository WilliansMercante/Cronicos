$(".profile").off("click").on("click", function () {
    $("#conteudo").load("/Profile/DadosCadastrais", function () {
        $("#titulo").text("Dados Cadastrais");
        $("#modal").modal();
    });
});