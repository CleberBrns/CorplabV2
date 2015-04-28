﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Unidades.aspx.cs" Inherits="Unidades_Unidades" EnableEventValidation="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Unidades - ALS CorpLab</title>
    <link href="../Styles/Acoes.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <input type="hidden" runat="server" id="hddTestPost" />
        <input type="hidden" runat="server" id="hddIdUnidade" value="0" />
        <input type="hidden" runat="server" id="hddInclusoes" />
        <input type="hidden" id="hddErro" runat="server" />
        <div class="pagina" runat="server" id="divPagina">
            <h2>Unidades
            </h2>
            <div style="padding-bottom: 3%;">
                <div runat="server" id="divInicio">
                    <%--<div class="rodape">
                    </div>--%>
                    <div class="contBt">
                        <asp:Button runat="server" ID="btGerenciar" OnClick="btGerenciar_Click" CssClass="bt" Text="Gerenciar Unidades" Visible="false" />
                        <asp:Button runat="server" ID="btNovaUnidade" OnClick="btNovaUnidade_Click" CssClass="bt" Text="Nova Unidade" />
                    </div>
                </div>
            </div>
            <div class="rodape">
            </div>
            <div class="contBt">
              <asp:Button runat="server" ID="btMenuPrincipal" CssClass="bt" OnClick="btMenuPrincipal_Click" Text="Menu Principal" />
            </div>
        </div>
    </form>
</body>
</html>
