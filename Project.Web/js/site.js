function AjaxMensagem(result) {
    if (result && result.mensagem) {
        if (result.mensagem != null) {
            $('#modalMensagemId').html(result.mensagem);
            $('#modalMensagem').modal();
        }
    }
};