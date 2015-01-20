<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login_Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Login - ALS CorpLab</title>
    <link href="../Styles/Login.css" rel="stylesheet" type="text/css" />    
    <script src="../Scripts/jquery-1.11.1.js" type="text/javascript"></script>
    <script src="../Scripts/Login.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div runat="server" id="divLogin">
        <div class="pagina paginaLogin">
            <div>
                <h4>Login:</h4>
                <asp:TextBox ID="txtLogin" style="margin-top: 5px; margin-bottom: 5px;" runat="server" Width="100%"></asp:TextBox>
                 <h4>Senha:</h4>
                <asp:TextBox ID="txtSenha" style="margin-top: 5px;" TextMode="Password" runat="server" Width="100%"></asp:TextBox>
                <asp:Label runat="server" ID="lblRetorno" Visible="false" Style="color: Red; font-weight: bold;" />
            </div>
            <div class="contBt">
                <asp:Button runat="server" ID="btLogar" CssClass="bt" Text="OK" OnClick="Acessar_Click" />
                <asp:Button runat="server" ID="btLimparLogin" CssClass="bt" Text="Limpar" />
            </div>
        </div>
    </div>
    </form>
</body>
</html>
