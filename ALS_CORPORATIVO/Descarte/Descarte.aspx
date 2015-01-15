﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Descarte.aspx.cs" Inherits="Descarte_Descarte" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
        <link href="../Styles/jquery-ui-1.9.2.custom.min.css" rel="stylesheet" type="text/css" />
    <script src="../Scripts/jquery-1.11.1.js" type="text/javascript"></script>
    <script src="../Scripts/jquery-ui-1.9.2.custom.min.js" type="text/javascript"></script>
    <script src="../Scripts/Descarte.js" type="text/javascript"></script>
    <link href="../Styles/Descarte.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <input type="hidden" id="hddErro" runat="server" />
        <div runat="server" id="divConteudo">
            <div class="pagina">
                <div class="insercoes">
                    <div style="margin-top: 10px;">
                        Digite o Grupo
                        <div>
                            <asp:TextBox runat="server" autocomplete="off" Width="180px"
                                Height="25px" ID="txtGrupo"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="contBt">
                    <input type="button" style="width:20%; height:45px;" class="bt" value="Pesquisar" runat="server" id="btPesquisar" />
                </div>
                <div class="rodape">
                </div>
                <div class="contBt">
                    <a href="javascript:Redireciona();">
                        <input type="button" class="bt" value="Menu Principal" runat="server" id="btMenuPrincipal" /></a>
                </div>
            </div>
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