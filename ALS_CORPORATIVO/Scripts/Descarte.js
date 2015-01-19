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
            $("#btMenuPrincipal").trigger("click");
        }
    });

    //ExibeMsgRetorno("Não existem Grupos/Amostras a serem descartados.");
    CarregaAmostrasGrupo("432423/18");

    function CarregaAmostrasGrupo(idGrupo) {

        $.ajax({
            type: "POST",
            url: "Descarte.aspx/ConsultaAmostrasGrupo",
            data: JSON.stringify({ sIdGrupo: idGrupo }),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
                var select = '<div>' + '<ul class="amostrasGrupo" style="background-color: #DDD;"><li style="float: left">CodAmostra</li><li style="float: left">Tipo Amostra</li><li style="float: left">Data Entrada</li><li>Descartar</li></ul>';
                var option = '';
                $.each(data.d, function (index, value) {
                    option += '<ul class="amostrasGrupo"><li style="float: left">' + value.IdAmostra + '</li><li style="float: left">' +
                        value.TipoAmostra + '</li><li style="float: left">' + value.DataEntrada +
                        '</li><li><a href="javascript:Descarte(' + value.IdAmostra + ');">' +
                        '<input type="button" class="btOk" value="Ok" /></a></li></ul>';
                });
                select = select + option + '</div>';
                $('#divRetornos').html(select);
            }
        });
    }

    function corStatus(status) {
        if (status == 0) {
            return 'color:green';
        } else if (status == 1) {
            return 'color:orange';
        } else if (status == 2) {
            return 'color:blue';
        } else {
            return 'color:red';
        }
    }

    function ExibeMsgRetorno(msgRetorno) {

        $('#lblMsgRetorno').text(msgRetorno);
        $('#dialog-MsgRetorno').dialog('open');

    }

});
/////////////////////////////////////////////////////////////////////////////////////////////
function Redireciona(destino) {

    var urlDestino;

    if (destino == 0) {
        urlDestino = "../Home/Home.aspx";
    }
    else {
        urlDestino = "../Analise/Analise.aspx";
    }

    window.location.href = urlDestino;
}
//////////////////////////////////////////////////////////////////////////////////////////////
function Descarte(idGrupo) {
    alert(idGrupo);
}
//////////////////////////////////////////////////////////////////////////////////////////////
function Impressao() {
    var urlDestino = "../Analise/ImpressaoSaida.aspx";
    window.open(urlDestino);
}
//////////////////////////////////////////////////////////////////////////////////////////////