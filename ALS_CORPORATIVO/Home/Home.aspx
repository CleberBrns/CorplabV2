<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Home.aspx.cs" Inherits="Home_Home" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Home - ALS CorpLab</title>
    <script src="../Scripts/jquery-1.11.1.js" type="text/javascript"></script>
    <script src="../Scripts/Home.js" type="text/javascript"></script>
    <link href="../Styles/Home.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div runat="server" id="divConteudo">
            <div class="pagina">
                <div class="contBt">
                    <asp:Button runat="server" ID="btEntrada" CssClass="bt" Text="Entrada"
                        OnClick="btEntrada_Click" />
                    <asp:Button runat="server" ID="btAnalise" CssClass="bt" Text="Análise" OnClick="btAnalise_Click" />
                    <asp:Button runat="server" ID="btDescarte" CssClass="bt" Text="Descarte" OnClick="btDescarte_Click" />
                </div>
                <div class="contBt">
                    <asp:Button runat="server" ID="btUnidades" CssClass="bt" Text="Cadastrar Unidades"
                        OnClick="btUnidades_Click" />
                    <asp:Button runat="server" ID="btUsuarios" CssClass="bt"
                        Text="Gerenciar Usuários" OnClick="btUsuarios_Click" />
                    <asp:Button runat="server" ID="btAuditoria" CssClass="bt"
                        Text="Auditoria" OnClick="btAuditoria_Click" />
                </div>
                <div class="contBt">
                     <asp:Button runat="server" ID="btSair" CssClass="bt"
                        Text="Sair" OnClick="btSair_Click" />
                </div>
            </div>
        </div>
    </form>
</body>
</html>
