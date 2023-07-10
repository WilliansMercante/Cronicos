//$("#frmLogin").on("submit", function (event) {
//    var idUnidade = $("#IdUnidade").val();
//    if (idUnidade == "" || idUnidade == undefined) {
//        event.preventDefault();

//        var form = $(this)[0];

//        obterUnidades($(this).serialize()).done(function (dados) {
//            if (dados.unidades.length <= 1) {
//                $(form)[0].submit();
//            }
//            else {
//                carregarComboUnidade(dados.unidades);
//                $('#login-box').removeClass('visible');
//                $('#forgot-box').addClass('visible');
//                $('#IdUnidade').attr("required", true);
//            }
//        })
//    }
//})

//function obterUnidades(dados) {
//    return requisicao("../Autenticar/ListarUnidades", "POST", dados)
//}

//function carregarComboUnidade(unidades) {
//    var itens = [];

//    itens.push(
//        $('<option></option>')
//            .val("")
//            .html("-- Unidade --")
//    );

//    $.each(unidades, function (index, obj) {
//        itens.push(
//            $('<option></option>')
//                .val(obj.id)
//                .html(obj.nmUnidade)
//        );
//    });

//    $("#IdUnidade").empty().append(itens);
//}