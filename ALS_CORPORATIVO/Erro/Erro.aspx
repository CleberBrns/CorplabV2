<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Erro.aspx.cs" Inherits="Erro_Erro" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../Styles/Erro.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/jquery-ui-1.9.2.custom.min.css" rel="stylesheet" type="text/css" />
    <script src="../Scripts/jquery-1.11.1.js" type="text/javascript"></script>
    <script src="../Scripts/Erro.js" type="text/javascript"></script>
    <script src="../Scripts/jquery-ui-1.9.2.custom.min.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <input type="hidden" runat="server" id="hddInclusoes" />
    <div class="pagina" runat="server" id="divErro">
        <div style="text-align: center;">
            <h4>
                Ocorreu um erro inesperado.</h4>
        </div>
        <div style="text-align: center;">
            <h5>
                Por favor, entre em contato com o gestor da página 
                <asp:Label runat="server" ID="lblComExcessao" Visible="false"> e informe a segunte mensagem;</asp:Label> </h5>
        </div>
        <div class="mensagemErro">
            <asp:Label runat="server" ID="lblExcessao" />
        </div>
        <div class="rodape" style="margin-top:38%;">
        </div>
        <div class="contBt">
            <a href="javascript:Redireciona(0);">
                <input type="button" class="bt" value="Menu Principal" /></a> <a href="javascript:Redireciona(1);">
                    <input type="button" class="bt" value="Sair" /></a>
        </div>
    </div>
    </form>
</body>
</html>
