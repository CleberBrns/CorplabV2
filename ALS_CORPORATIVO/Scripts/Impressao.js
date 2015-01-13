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

    CarregaAmostrasGrupo();

    $('#txtAmostra').keydown(function (event) {        

        var keyCode = (event.keyCode ? event.keyCode : event.which);
        if (keyCode == 13) {

            if ($('#txtAmostra').val() == "") {
                alert("Por favor, preencha o campo Amostra");
                return false;
            }
        }
    });

    function CarregaAmostrasGrupo() {
        //obj.IdAmostra = Convert.ToInt32(item["IdAmostra"]);
        //obj.Descricao = item["Descricao"].ToString();
        //obj.TipoAmostra = item["TipoAmostra"].ToString();
        //obj.DataEntrada = item["DataEntrada"].ToString();
        //obj.Status = item["Status"].ToString();
        //obj.IdStatus = Convert.ToInt32(item["IdStatus"]);

        $.ajax({
            type: "POST",
            url: "Saida.aspx/ConsultaAmostrasGrupo",
            data: JSON.stringify(),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
                var select = '<div>' + '<ul class="amostrasGrupo" style="background-color: #DDD;"><li style="float: left">IdAmostra</li><li style="float: left">Tipo Amostra</li><li style="float: left">Data Entrada</li><li>Status</li></ul>';
                var option = '';
                $.each(data.d, function (index, value) {
                    option += '<ul class="amostrasGrupo"><li style="float: left">' + value.IdAmostra + '</li><li style="float: left">' + value.TipoAmostra + '</li><li style="float: left">' + value.DataEntrada + '</li><li style=' + corStatus(value.IdStatus) + '>' + value.Status + '</li></ul>';
                });
                select = select + option + '</div>';
                $('#divRetornos').html(select);
            }
        });
    }

    function corStatus(status) {
        if (status == 1) {
            return 'color:green';
        } else {
            return 'color:red';
        }

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