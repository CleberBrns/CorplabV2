$(document).ready(function () {

    $('#btNovoCadastro').hide();
    $('#lkbVoltar').hide();

    CarregaUnidades();
    CarregaTipoAcesso();

    //Faz aparecer os painel de telefones///////////////////////////////
    $(".rblUsuarios input").click(function () {
        if ($('.rblUsuarios input').is(':checked')) {
            var id = $(this).attr("value");
            $(".dvUsuario").hide();
            $(".css" + id + "").show();
            $("#pnlNovoCadastro").hide();
            $('#btNovoCadastro').show();
            $('#lkbVoltar').show();
        }
    })

    $('#btCadastrar').click(function () {

        if ($('#ddlNivelAcesso').val() == "") {
            alert("Por favor, selecione o Nível de Acesso");
            return false;
        }

        if ($('#txtNovoNome').val() == "") {
            alert("Por favor, preencha o campo nome");
            return false;
        }

        if ($('#txtNovoLogin').val() == "") {
            alert("Por favor, preencha o campo login");
            return false;
        }

        if ($('#txtNovaSenha').val() == "") {
            alert("Por favor, preencha o campo senha");
            return false;
        }

        $.ajax({
            type: "POST",
            url: "Usuarios.aspx/InsereUsuario",
            data: JSON.stringify({ sIdUnidade: $('#ddlUnidade :selected').val(), sIdTipoAcesso: $('#ddlNivelAcesso :selected').val(),
                nomeUsuario: $('#txtNovoNome').val(), login: $('#txtNovoLogin').val(), senha: $('#txtNovaSenha').val()
            }),

            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
                alert('Usuário cadastrado com sucesso!');
                location.reload();
            },
            error: function (x, e) {
                $("#hddErro").val(e.responseText);
                $('#btErro').trigger('click');
            }
        });

    })



    $(document).on('click', '#btExcluir', function () {

       

    });

    $('#btLimpar').click(function () {

        $('#txtNovoNome').val('');
        $('#txtNovoLogin').val('');
        $('#txtNovaSenha').val('');
    })

    function CarregaUnidades() {

        $.ajax({
            type: "POST",
            url: "Usuarios.aspx/Unidades",
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
            }
        });
    }

    function CarregaTipoAcesso() {

        $.ajax({
            type: "POST",
            url: "Usuarios.aspx/TipoAcesso",
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
                $('#ddlNivelAcesso').html(select);
            }
        });
    }

});
///////////////////////////////////////////////////////////////////////
///JavaScript//////////////////////////////////////////////////////////
function ConfirmaExclusao() {
    var confirmacao;

    if (confirm("Você está deletando definitivamente esse cadastro. Deseja continuar?")) {
        confirmacao = "Sim";
    } else {
        confirmacao = "Não";
    }
    document.getElementById("hddConfirmacao").value = confirmacao;
}
//////////////////////////////////////////////////////////////////////
function RecarregaPagina() {
    location.reload();
}
/////////////////////////////////////////////////////////////////////////////////////////////
function Redireciona() {

    var destino = "../Home/Home.aspx";

    window.location.href = destino;
}
/////////////////////////////////////////////////////////////////////////////////////////////