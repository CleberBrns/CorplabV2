<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Auditoria.aspx.cs" Inherits="Auditoria_Auditoria" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../Styles/jquery-ui-1.9.2.custom.min.css" rel="stylesheet" type="text/css" />
    <script src="../Scripts/jquery-1.11.1.js" type="text/javascript"></script>
    <script src="../Scripts/jquery-ui-1.9.2.custom.min.js" type="text/javascript"></script>
    <script src="../Scripts/Auditoria.js" type="text/javascript"></script>
    <link href="../Styles/Auditoria.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <input type="hidden" id="hddErro" runat="server" />
        <div runat="server" id="divConteudo">            
            <div class="pagina">
                <h2>Saída</h2>
                <div class="insercoes">
                    <div style="margin-top: 10px; text-align: center;" runat="server" id="divRetornos">
                    </div>
                </div>
                <div class="clear"></div>                          
                <div style="margin-top: 10px; text-align: center;">
                    <span style="font-weight:bold;">Amostra a ser retirada da prateleira</span> 
                <input type="text" runat="server" id="txtAmostra" autocomplete="off" style="width: 180px; height: 25px" />
                </div>                
                <div class="rodape">
                </div>
                <div class="contBt">
                    <a href="javascript:Redireciona(0);">
                        <input type="button" class="bt" value="Menu Principal" runat="server" id="btMenuPrincipal" /></a>
                    <a href="javascript:Redireciona(1);">
                        <input type="button" class="bt" value="Voltar" runat="server" id="btVoltar" /></a>
                </div>
            </div>
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
