﻿$(document).ready(function () {
    document.getElementById('imgCarregando').style.display = 'none';
    document.getElementById('divBody').style.display = 'block';
});

function AjaxMensagem(result) {
    if (result && result.mensagem) {
        if (result.mensagem !== null) {
            $('#modalMensagemId').html(result.mensagem);
            $('#modalMensagem').modal();
        }
    }

};

function PopulaSelectList(controller, action, cmb, item) {

    $.ajax({
        type: "POST",
        url: "/" + controller + "/" + action,
        success: function (dados) {

            var option = '<option value="-1" >Selecione o item</option>';
            $.each(dados, function (i, obj) {
                option += '<option value="' + obj.Key + '">' + obj.Value + '</option>';
            });

            $(cmb).html(option).show();

            //setando o valor inicial.. 
            $(cmb).val(item);

        },
        error: function (e) {
            exibirAlert("Erro: " + e.status);
        }
    });
}

function PopulaSelectListId(controller, action, cmb, item, id) {

    $.ajax({
        type: "POST",
        url: "/" + controller + "/" + action,
        data: "id="+ id,
        success: function (dados) {

            var option = '<option value="-1" >Selecione o item</option>';
            $.each(dados, function (i, obj) {
                option += '<option value="' + obj.Key + '">' + obj.Value + '</option>';
            });

            $(cmb).html(option).show();

            //setando o valor inicial.. 
            $(cmb).val(item);

        },
        error: function (e) {
            exibirAlert("Erro: " + e.status);
        }
    });
}