$(document).ready(function () {
    //Tratamento para DropDowns..
    $(".btn-item").each(function () {
        var Name = $(this).attr("data-name");
        var Default = $(this).attr("data-default");

        $("#txtCod" + Name).val("-1");
        $("#spDescricao" + Name).html(Default);
    });

    $(".btn-item").click(function () {
        var Cod = $(this).attr("data-cod");
        var Descricao = $(this).attr("data-text");

        $("#txtCod" + $(this).attr("data-name")).val(Cod);
        $("#spDescricao" + $(this).attr("data-name")).html(Descricao);
    });
});