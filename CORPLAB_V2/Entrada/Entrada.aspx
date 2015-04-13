<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Entrada.aspx.cs" Inherits="Entrada_Entrada" EnableEventValidation="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Entrada - ALS CorpLab</title>
    <link href="../Styles/Entrada.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/jquery-ui-1.9.2.custom.min.css" rel="stylesheet" type="text/css" />
    <script src="../Scripts/jquery-1.11.1.js" type="text/javascript"></script>
    <script src="../Scripts/Entrada.js" type="text/javascript"></script>
    <script src="../Scripts/jquery-ui-1.9.2.custom.min.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
        <input type="hidden" runat="server" id="hddTestPost" />
        <input type="hidden" runat="server" id="hddIdUnidade" value="0" />
        <input type="hidden" runat="server" id="hddInclusoes" />
        <input type="hidden" id="hddErro" runat="server" />
        <div class="pagina" runat="server" id="divPagina">
            <h2>Entrada</h2>
            <div class="dataAtual">
                <h4>
                    <asp:Label runat="server" ID="lblDataAtual"></asp:Label>
                </h4>
            </div>
            <div class="insercoes">
                <div style="margin-top: 5px;" class="divUnidade" runat="server" id="divUnidade">
                    Unidade
                <asp:DropDownList runat="server" ID="ddlUnidade" AutoPostBack="true" OnSelectedIndexChanged="ddlUnidade_SelectedIndexChanged" Width="180px" Height="25px">
                </asp:DropDownList>
                </div>
                <div style="margin-top: 5px;" class="divCamara" runat="server" id="divCamara">
                    Câmara
                <asp:DropDownList runat="server" ID="ddlCamaras" Width="180px" Height="25px" Enabled="false" AutoPostBack="true" OnSelectedIndexChanged="ddlCamaras_SelectedIndexChanged">
                </asp:DropDownList>
                </div>
                <div style="margin-top: 5px;">
                    Prateleira
                <asp:DropDownList runat="server" ID="ddlPrateleira" Width="180px" Height="25px" Enabled="false">
                </asp:DropDownList>
                </div>
                <div style="margin-top: 5px;">
                    Caixa
                <asp:TextBox runat="server" placeholder="Campo opcional" autocomplete="off" Width="180px"
                    Height="25px" ID="txtCaixa"></asp:TextBox>
                </div>
                <div style="margin-top: 5px;">
                    Cod. Grupo
                <asp:TextBox runat="server" placeholder="Campo obrigatório" autocomplete="off" Width="180px"
                    Height="25px" ID="txtGrupo"></asp:TextBox>
                </div>
                <div style="margin-top: 10px;">
                    Tipo Amostra
                <asp:DropDownList runat="server" ID="ddlTipoAmostra" Width="180px" Height="25px">
                </asp:DropDownList>
                </div>
                <div style="margin-top: 10px;">
                    Amostra
                <input type="text" runat="server" id="txtAmostra" autocomplete="off" style="width: 180px; height: 25px" />
                </div>
                <div style="margin-top: 10px;" class="contBt">
                    <asp:Button runat="server" ID="btIncluir" OnClick="btIncluir_Click" CssClass="btIncluir" Text="Incluir Amostra" />
                </div>
            </div>
            <div id="divRetornoSaida" runat="server" class="none">
                <div class="clear"></div>
                <div class="rodape">
                </div>
                <div style="padding-top: 10px; text-align: center;">
                    <span style="color: green;">Amostra inserida com sucesso.</span>
                </div>
            </div>
            <div class="rodape">
            </div>
            <div class="contBt">
                <a href="javascript:Redireciona(0);">
                    <input type="button" class="bt" value="Menu Principal" /></a>
            </div>
        </div>
        <div class="pagina" runat="server" id="divProcessando" visible="false" style="height: 535px;">
            <h2>Entrada</h2>
            <div class="infoProcessando">
                A amostra está sendo incluída. Por favor, aguarde!
            </div>
            <div class="imgProcessando">
                <img src="../Imagens/loading.gif" width="300px" />
            </div>
        </div>
        <div style="display: none;">
            <asp:Button runat="server" ID="btGuardar" CssClass="bt" />
        </div>
        <%--BOTÃO PARA ACIONAR A PÁGINA DE ERRO--%>
        <div runat="server" id="divBotoesAux" class="none">
            <asp:Button runat="server" ID="btErro" Text="Erro" OnClick="btErro_Click" />
        </div>
        <%--MODAL MENSAGEM RETORNO!--%>
        <div id="dialog-MsgRetorno" title="Atenção!" class="confirmaInclusao">
            <p>
                <strong>
                    <asp:Label runat="server" ID="lblMsgRetorno" /></strong>
            </p>
        </div>
    </form>
</body>
</html>
