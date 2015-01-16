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

        if ($("#txtGrupo").val() != "") {

            $.ajax({
                type: "POST",
                url: "Analise.aspx/ConstultaGrupo",
                data: JSON.stringify({ codGrupo: $("#txtGrupo").val() }),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    var retorno = data.d;

                    if (retorno == "True") {

                        $("#divRetornoPesquisa").hide();
                        $("#hddIdGrupo").val($("#txtGrupo").val());
                        $("#divPesquisa").hide();
                        $("#divAcoes").show();
                        $("#btVoltar").show();
                    }
                    else {                       
                        $("#divRetornoPesquisa").show();
                    }
                },             
            });
          
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