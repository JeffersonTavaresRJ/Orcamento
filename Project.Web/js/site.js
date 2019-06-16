//$(document).ready(function () {    
//}).ajaxComplete(function () {
//    alert("Página carregada");
//    $('#imgCarregando').hide();
//    });

$(document).ready(function () {  
    document.getElementById('imgCarregando').style.display = 'none';
    document.getElementById('divBody').style.display ='block';
})

function AjaxMensagem(result) {
    if (result && result.mensagem) {
        if (result.mensagem != null) {
            $('#modalMensagemId').html(result.mensagem);
            $('#modalMensagem').modal();
        }
    }

};

function PopulaPerfil() {
    $.ajax({
        type: "POST",
        url: "/Perfil/ListarPerfil",
        success: function (dados) {

            var option = '<option value=-1>Selecione o Perfil</option>';
            $.each(dados, function (i, obj) {
                option += '<option value="' + obj.Id + '">' + obj.Descricao + '</option>';
            });

            $('#cmbPerfil').html(option).show();

        },
        error: function (e) {
            exibirAlert("Erro: " + e.status);
        }
    });
}

function PopulaStatus() {
    $.ajax({
        type: "POST",
        url: "/Usuario/ListaStatus",
        success: function (dados) {

            var option = '<option value=-1 > Selecione o Status</option>';
            $.each(dados, function (i, obj) {
                option += '<option value="' + obj.Key + '">' + obj.Value + '</option>';
            });

            $('#cmbStatus').html(option).show();

        },
        error: function (e) {
            exibirAlert("Erro: " + e.status);
        }
    });
}