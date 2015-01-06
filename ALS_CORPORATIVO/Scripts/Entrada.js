$(document).ready(function () {

    $('#btConcluir').hide();

    $('#txtAmostra').keydown(function (event) {
        var keyCode = (event.keyCode ? event.keyCode : event.which);
        if (keyCode == 13) {

            if ($('#ddlPrateleira').val() == "") {
                alert("Por favor, selecione a Prateleira");
                return false;
            }

            if ($('#txtGrupo').val() == "") {
                alert("Por favor, preencha o campo Grupo");
                return false;
            }

            if ($('#ddlTipoAmostra').val() == "") {
                alert("Por favor, selecione o Tipo");
                return false;
            }

            if ($('#txtAmostra').val() != "") {

                var valores = $('#ddlPrateleira').val() + '_' + $('#txtCaixa').val() + '_' + $('#txtGrupo').val() + '_' +
                          $('#ddlTipoAmostra').val() + '_' + $('#txtAmostra').val() + '|';

                if ($("#hddInclusoes").val() != "") {
                    valores += $("#hddInclusoes").val();
                }

                $("#hddInclusoes").val(valores);
                $('#txtAmostra').val('');

                var incluidos = $("#hddInclusoes").val().split('|');
                $('#lblContadorItens').text(incluidos.length - 1);

            }
            else {
                alert("Por favor, preencha o campo Amostra");
                return false;
            }

            if ($("#hddInclusoes").val() != "") {
                $('#btConcluir').show();
            }
            else {
                $('#btConcluir').hide();
            }
        }
    });

    $('#btConcluir').click(function () {
        $('#btFinalizar').trigger('click');
    });

    $("#dialog-sucesso").dialog({    
        resizable: false,
        autoOpen: false,
        height: 200,
        width: 320,
        modal: true,
        buttons: {
            "Ok": function () {
                $(this).dialog("close");

            }
        },
        close: function () {
            window.close();
        }
    });

});
/////////////////////////////////////////////////////////////////////////////////////////////
function Redireciona(tipo) {

    var destino = "../Home/Home.aspx";

    if (tipo == 1) {
        destino = "../Login/Login.aspx";
    }

    window.location.href = destino;
}
