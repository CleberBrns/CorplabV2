<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Entrada.aspx.cs" Inherits="Entrada_Entrada" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../Styles/Entrada.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/jquery-ui-1.9.2.custom.min.css" rel="stylesheet" type="text/css" />
    <script src="../Scripts/jquery-1.11.1.js" type="text/javascript"></script>
    <script src="../Scripts/Entrada.js" type="text/javascript"></script>
    <script src="../Scripts/jquery-ui-1.9.2.custom.min.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <input type="hidden" runat="server" id="hddInclusoes" />
    <div class="pagina" runat="server" id="divPagina">
        <h2>
            Entrada</h2>
        <div class="dataAtual">
            <h4>
                <asp:Label runat="server" ID="lblDataAtual"></asp:Label>
            </h4>
        </div>
        <div class="insercoes">
            <div style="margin-top: 5px;">
                Prateleira
                <asp:DropDownList runat="server" ID="ddlPrateleira" Width="180px" Height="25px">
                </asp:DropDownList>
            </div>
            <div style="margin-top: 5px;">
                Caixa
                <asp:TextBox runat="server" placeholder="Campo opcional" autocomplete="off" Width="180px"
                    Height="25px" ID="txtCaixa"></asp:TextBox>
            </div>
            <div style="margin-top: 5px;">
                Grupo
                <asp:TextBox runat="server" placeholder="Campo obrigatório" autocomplete="off" Width="180px"
                    Height="25px" ID="txtGrupo"></asp:TextBox>
            </div>
            <div style="margin-top: 10px;">
                Tipo
                <asp:DropDownList runat="server" ID="ddlTipoAmostra" Width="180px" Height="25px">
                </asp:DropDownList>
            </div>
            <div style="margin-top: 10px;">
                Amostra
                <input type="text" runat="server" id="txtAmostra" autocomplete="off" style="width: 180px;
                    height: 25px" />
            </div>
            <div style="margin-top: 10px;" class="contadorItens">
                Itens inclusos;&nbsp;<asp:Label runat="server" ID="lblContadorItens" Text="0" />
            </div>
            <div style="margin-top: 10px;" class="contBt">
                <input type="button" runat="server" id="btConcluir" class="btConcluir" value="Concluir" />
            </div>
        </div>
        <div class="rodape">
        </div>
        <div class="contBt">
            <a href="javascript:Redireciona(0);">
                <input type="button" class="bt" value="Menu Principal" /></a> <a href="javascript:Redireciona(1);">
                    <input type="button" class="bt" value="Sair" /></a>
        </div>
    </div>
    <div class="pagina" runat="server" id="divProcessando" visible="false" style="height: 535px;">
        <h2>
            Entrada</h2>
        <div class="infoProcessando">
            A amostra está sendo incluída. Por favor, aguarde!
        </div>
        <div class="imgProcessando">
            <img src="../Imagens/loading.gif" width="300px" />
        </div>
    </div>
    <div style="display: none;">
        <asp:Button runat="server" ID="btGuardar" CssClass="bt" />
        <asp:Button runat="server" ID="btFinalizar" CssClass="bt" OnClick="btFinalizar_Click" />
    </div>
    <%--MODAL SUCESSO!--%>
    <div id="dialog-sucesso" title="Sucesso!" class="confirmaInclusao">
        <p>
            <strong>Amostra incluída com sucesso!</strong></p>
    </div>
    </form>
</body>
</html>
