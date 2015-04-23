<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Acoes.aspx.cs" Inherits="Acoes_Acoes" EnableEventValidation="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Entrada - ALS CorpLab</title>
    <link href="../Styles/Acoes.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        /////////////////////////////////////////////////////////////////////////////////////////////
        function Redireciona() {

            var destino = "../Home/Home.aspx";
            window.location.href = destino;
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <input type="hidden" runat="server" id="hddTestPost" />
        <input type="hidden" runat="server" id="hddIdUnidade" value="0" />
        <input type="hidden" runat="server" id="hddInclusoes" />
        <input type="hidden" id="hddErro" runat="server" />
        <div class="pagina" runat="server" id="divPagina">
            <h2>Ações</h2>           
            <div class="insercoes">
                <div style="margin-top: 10%;">
                    Aguardando a&ccedil;&atilde;o...   
                    <div style="margin-top:10px">
                        <asp:TextBox runat="server" ID="txtAcao" Width="180px" Height="25px" autocomplete="off" />
                        <div style="display: none">
                            <asp:Button runat="server" ID="btAcao" OnClick="btAcao_Click" />
                        </div>
                    </div>                   
                </div>                          
            </div>
            <div style="margin-top: 3%; margin-bottom: 3%; text-align: center; font-size: 18px; color:red;" runat="server" id="divRetorno" visible="false">                
                <div style="margin-bottom: 3%;">
                    <asp:Image runat="server" ID="imgErro" ImageUrl="../Imagens/error.png" Visible="false" Width="8%" />
                </div>
                <asp:Label runat="server" ID="lblRetorno" />
            </div>
            <div class="rodape">
            </div>
            <div class="contBt">
              <a href="javascript:Redireciona();">
                    <input type="button" class="bt" value="Menu Principal" /></a>
            </div>
        </div>
    </form>
</body>
</html>
