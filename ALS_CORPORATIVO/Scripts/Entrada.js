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

    $('#btConcluir').hide();

    $('#ddlPrateleira').prop('disabled', true);

    CarregaUnidade();
    CarregaTipoAmostra();
    
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

                var valores = $('#ddlPrateleira').find('option:selected').val() + '_' + $('#txtCaixa').val() + '_' + $('#txtGrupo').val() + '_' +
                          $('#ddlTipoAmostra').find('option:selected').val() + '_' + $('#txtAmostra').val() + '|';

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
        InsereAmostras($("#hddInclusoes").val());
    });

    $("#ddlCamaras").change(function () {               
        
        CarregaPrateleiras($(this).find('option:selected').val());

    });

    function CarregaUnidade() {

        $.ajax({
            type: "POST",
            url: "Entrada.aspx/Unidades",
            data: JSON.stringify(),
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
                    CarregaCamaras($('#ddlUnidade option:selected').val());
                }
            }
        });
    }

    function CarregaCamaras(idUnidade) {

        $.ajax({
            type: "POST",
            url: "Entrada.aspx/Camaras",
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

                CarregaPrateleiras($('#ddlCamaras option:selected').val());
            },
            error: function (x, e) {
                $("#hddErro").val(e.responseText);
                $('#btErro').trigger('click');
            }
        });

    }

    function CarregaPrateleiras(idCamara) {

        $.ajax({
            type: "POST",
            url: "Entrada.aspx/Prateleiras",
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
            error: function (x, e) {
                $("#hddErro").val(e.responseText);
                $('#btErro').trigger('click');
            }
        });

    }

    function CarregaTipoAmostra() {

        $.ajax({
            type: "POST",
            url: "Entrada.aspx/TipoAmostra",
            data: JSON.stringify(),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
                var select = '<select>';
                var option = '';
                $.each(data.d, function (index, value) {
                    option += '<option value=' + value.Value + '>' + value.Text + '</option>';
                });
                select = select + option + '</select>';
                $('#ddlTipoAmostra').html(select);
            },
            error: function (x, e) {
                $("#hddErro").val(e.responseText);
                $('#btErro').trigger('click');
            }
        });

    }

    function InsereAmostras(amostrasInclusao) {

        $("#divPagina").hide();
        $("#divProcessando").show();

        $.ajax({
            type: "POST",
            url: "Entrada.aspx/InsereAmostras",
            data: JSON.stringify({ amostrasInclusao: amostrasInclusao }),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {     

                $("#divPagina").show();
                $("#divProcessando").hide();


                ExibeMsgRetorno("Amostra incluída com sucesso!");
               
            },
            error: function (x, e) {
                $("#hddErro").val(e.responseText);
                $('#btErro').trigger('click');
            }
        });

    }

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
