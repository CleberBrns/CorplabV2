<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Home.aspx.cs" Inherits="Home_Home" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>        
    <script src="../Scripts/jquery-1.11.1.js" type="text/javascript"></script>    
    <script src="../Scripts/Home.js" type="text/javascript"></script>
    <link href="../Styles/Home.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
      <div runat="server" id="divConteudo">
        <div class="pagina">            
            <div class="contBt">
                <asp:Button runat="server" ID="btUsuarios" CssClass="bt" 
                    Text="Gerenciar Usuários" onclick="btUsuarios_Click" />
                     <asp:Button runat="server" ID="btEntrada" CssClass="bt" Text="Entrada" 
                    onclick="btEntrada_Click" />
                      <asp:Button runat="server" ID="btAnalise" CssClass="bt" Text="Análise" />
            </div>
            <div class="contBt">
                <asp:Button runat="server" ID="Button1" CssClass="bt" Text="Saída" />
                <asp:Button runat="server" ID="Button2" CssClass="bt" Text="Reentrada" />
                <asp:Button runat="server" ID="Button3" CssClass="bt" Text="Auditoria" />
            </div>
            <div class="contBt">
             <asp:Button runat="server" ID="btUnidades" CssClass="bt" Text="Cadastrar Unidades" 
                    onclick="btUnidades_Click" />
               <asp:Button runat="server" ID="btSair" CssClass="bt" 
                    Text="Sair" onclick="btSair_Click" />
            </div>
        </div>
    </div>
    </form>
</body>
</html>
