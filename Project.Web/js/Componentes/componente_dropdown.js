var Cod = null;
var Descricao = null;
var Id = null;
var Default = null;

$(document).ready(function () {

    //Tratamento para DropDowns..
    $(".btn-item").each(function () {
        Id = $(this).attr("id");
        Default = $(this).attr("data-default");

        $("#spDescricao" + Id).html(Default);
    });

    $(".btn-item").click(function () {
        Cod = $(this).attr("data-cod");
        Descricao = $(this).attr("data-text");

        $("#txtCod" + $(this).attr("id")).val(Cod);
        $("#spDescricao" + $(this).attr("id")).html(Descricao);

        var X = $("#txtCod" + $(this).attr("id")).val();

        alert(X);
    });

});