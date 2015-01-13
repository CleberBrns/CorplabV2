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

    $("#btPesquisar").click(function () {

        if ($("#txtGrupo").val() == "") {

            alert("Favor preencher o campo Grupo");
            return false;
        }
        else {           
            $("#hddIdGrupo").val($("#txtGrupo").val());
            $("#divPesquisa").hide();
            $("#divAcoes").show();
            $("#btVoltar").show();
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