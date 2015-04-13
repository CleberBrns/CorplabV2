$(document).ready(function () {

    $("#dialog-MsgRetorno").dialog({
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

    if ($('#txtGrupo').val() == "") {
        $('#btIncluir').prop('disabled', true);
    } else {
        $('#btIncluir').prop('disabled', false);
    }

    if ($('#txtAmostra').val() == "") {
        $('#btIncluir').prop('disabled', true);
    } else {
        $('#btIncluir').prop('disabled', false);
    }

    $('#txtAmostra').keydown(function (event) {

        if ($(this).val() == "") {
            $('#btIncluir').prop('disabled', true);
        } else {
            $('#btIncluir').prop('disabled', false);
            $('#divRetornoSaida').hide();
        }

    });

    $('#txtAmostra').keyup(function (event) {

        if ($(this).val() == "") {
            $('#btIncluir').prop('disabled', true);
        } else {
            $('#btIncluir').prop('disabled', false);
        }

    });

    $("#btInfoGrupo").click(function () {

        if ($("#divInfoGrupo").hide()) {
            $("#btInfoGrupo").hide();
            $("#divInfoGrupo").show();
            $("#btEscondeInfoGrupo").show();
        }

    });

    $("#btEscondeInfoGrupo").click(function () {

        $("#divInfoGrupo").hide();
        $("#btInfoGrupo").show();
        $("#btEscondeInfoGrupo").hide();

    });

    function ExibeMsgRetorno(msgRetorno) {

        $('#lblMsgRetorno').text(msgRetorno);
        $('#dialog-MsgRetorno').dialog('open');
    }
});
/////////////////////////////////////////////////////////////////////////////////////////////
function Redireciona(tipo) {

    var destino = "../Home/Home.aspx";

    if (tipo == 1) {
        destino = "../Login/Login.aspx";
    }

    window.location.href = destino;
}
