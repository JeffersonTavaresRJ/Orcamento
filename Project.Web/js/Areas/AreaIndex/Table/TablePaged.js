$(document).ready(function () {

     //selecionar linhas..
    //$('.tabelaPaginada tbody').on('click', 'tr', function () {
    //    $(this).toggleClass('selected');

    //});

    //exibir a quantidade de linhas selecionadas..
    //$('#button').click(function () {
    //    alert(table.rows('.selected').data().length + ' row(s) selected');
    //});


    $('.tabelaPaginada').DataTable({
        "bProcessing": true,
        "bServerSide": false,
        "bLengthChange": false, /*tornar invisível combo para visualizar a quantidade de registros */
        "bFilter": false, /*tornar invisível o campo de busca do resultado da tabela */
        "pagingType": "full_numbers",
        "language": {
            "sEmptyTable": "Nenhum registro encontrado",
            "sInfo": "De _START_ até _END_ de um total de _TOTAL_ registros",
            "sInfoEmpty": "Mostrando 0 até 0 de 0 registros",
            "sInfoFiltered": "(Filtrados de _MAX_ registros)",
            "sInfoPostFix": "",
            "sInfoThousands": ".",
            "sLengthMenu": "_MENU_ resultados por página",
            "sLoadingRecords": "Carregando...",
            "sProcessing": "Processando...",
            "sZeroRecords": "Nenhum registro encontrado",
            "sSearch": "Busca:",
            "oPaginate": {
                "sNext": ">",
                "sPrevious": "<",
                "sFirst": "<<",
                "sLast": ">>"
            },
            "oAria": {
                "sSortAscending": ": Ordenar colunas de forma ascendente",
                "sSortDescending": ": Ordenar colunas de forma descendente"
            }
        }

    });


});