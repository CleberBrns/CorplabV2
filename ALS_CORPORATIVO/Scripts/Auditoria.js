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

    $('#ddlPrateleira').prop('disabled', true);
    $('#ddlCamaras').prop('disabled', true);
    CarregaUnidade($('#hddIdUnidade').val());
    

    $('#txtAmostra').keydown(function (event) {

        var keyCode = (event.keyCode ? event.keyCode : event.which);
        if (keyCode == 13) {

            if ($('#txtAmostra').val() == "") {               
                return false;
            }
            else {
                return false;
                CarregaAmostrasGrupo($('#ddlPrateleira').find('option:selected').Text());
                $("#divExibicaoInfos").show();
                //$("#divAmostraAusente").show();
               
            }
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

    $("#ddlCamaras").change(function () {
        CarregaPrateleiras($(this).find('option:selected').val());
    });

    $("#ddlUnidade").change(function () {
        CarregaCamaras($(this).find('option:selected').val());
    });

    function CarregaUnidade(idUnidade) {

        $.ajax({
            type: "POST",
            url: "Auditoria.aspx/Unidades",
            data: JSON.stringify({ sIdUnidade: idUnidade }),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
                var select = '<select>';
                var option = '';
                $.each(data.d, function (index, value) {
                    option += '<option value=' + value.Value + '>' + value.Text + '</option>';
                });
                select = select + option + '</select>';
                $('#ddlUnidade').html(select);

                var qtdUnidades = $("#ddlUnidade option").length;

                if (qtdUnidades == 1) {
                    $(".divUnidade").hide();                    
                }

                CarregaCamaras($('#ddlUnidade option:selected').val());
            }
        });
    }

    function CarregaCamaras(idUnidade) {

        $.ajax({
            type: "POST",
            url: "Auditoria.aspx/Camaras",
            data: JSON.stringify({ idUnidade: idUnidade }),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
                var select = '<select>';
                var option = '';
                $.each(data.d, function (index, value) {
                    option += '<option value=' + value.Value + '>' + value.Text + '</option>';
                });
                select = select + option + '</select>';
                $('#ddlCamaras').html(select);

                var qtdCamaras = $("#ddlCamaras option").length;

                if (qtdCamaras == 1) {
                    $(".divCamara").hide();
                }

                $('#ddlPrateleira').prop('disabled', false);
                CarregaPrateleiras($('#ddlCamaras option:selected').val());
            },
        });
    }

    function CarregaPrateleiras(idCamara) {

        $.ajax({
            type: "POST",
            url: "Auditoria.aspx/Prateleiras",
            data: JSON.stringify({ idCamara: idCamara }),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
                var select = '<select>';
                var option = '';
                $.each(data.d, function (index, value) {
                    option += '<option value=' + value.Value + '>' + value.Text + '</option>';
                });
                select = select + option + '</select>';
                $('#ddlPrateleira').html(select);

                $('#ddlPrateleira').prop('disabled', false);
            },
        });
    }

    function CarregaAmostrasGrupo() {
        //obj.IdAmostra = Convert.ToInt32(item["IdAmostra"]);
        //obj.Descricao = item["Descricao"].ToString();
        //obj.TipoAmostra = item["TipoAmostra"].ToString();
        //obj.DataEntrada = item["DataEntrada"].ToString();
        //obj.Status = item["Status"].ToString();
        //obj.IdStatus = Convert.ToInt32(item["IdStatus"]);

        $.ajax({
            type: "POST",
            url: "Auditoria.aspx/ConsultaAmostrasGrupo",
            data: JSON.stringify(),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
                var select = '<div>' + '<ul class="amostrasGrupo" style="background-color: #DDD;"><li style="float: left">CodAmostra</li><li style="float: left">Tipo Amostra</li><li style="float: left">Data Entrada</li><li>Status</li></ul>';
                var option = '';
                $.each(data.d, function (index, value) {
                    option += '<ul class="amostrasGrupo"><li style="float: left">' + value.IdAmostra + '</li><li style="float: left">' + value.TipoAmostra + '</li><li style="float: left">' + value.DataEntrada + '</li><li style=' + corStatus(value.IdStatusAmostra) + '>' + value.StatusAmostra + '</li></ul>';
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