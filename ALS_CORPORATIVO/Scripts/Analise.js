﻿$(document).ready(function () {

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

    $("#btPesquisar").click(function () {

        if ($("#txtGrupo").val() != "") {



            $("#hddIdGrupo").val($("#txtGrupo").val());
            $("#divPesquisa").hide();
            $("#divAcoes").show();
            $("#btVoltar").show();
        }
        else {
            alert("Favor preencher o campo Grupo");
            return false;
        }
    });

    $('#txtGrupo').keydown(function (event) {
        var keyCode = (event.keyCode ? event.keyCode : event.which);
        if (keyCode == 13) {
            return false;
        }
    });

    $("#btVoltar").click(function () {

        $("#txtGrupo").val('');
        $("#hddIdGrupo").val('');
        $("#divPesquisa").show();
        $("#divAcoes").hide();
        $("#btVoltar").hide();

    });


});
/////////////////////////////////////////////////////////////////////////////////////////////
function Redireciona() {

    var destino = "../Home/Home.aspx";
    window.location.href = destino;
}