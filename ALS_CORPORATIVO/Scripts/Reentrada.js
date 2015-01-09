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

        if ($("#txtGrupo").text() == "") {

            alert("Favor preencher o campo Grupo");

        }
    });

});
/////////////////////////////////////////////////////////////////////////////////////////////
function Redireciona() {

    var destino = "../Home/Home.aspx";
    window.location.href = destino;
}