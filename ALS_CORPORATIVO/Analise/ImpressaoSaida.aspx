<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ImpressaoSaida.aspx.cs" Inherits="Analise_ImpressaoSaida" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../Styles/jquery-ui-1.9.2.custom.min.css" rel="stylesheet" type="text/css" />
    <script src="../Scripts/jquery-1.11.1.js" type="text/javascript"></script>
    <script src="../Scripts/jquery-ui-1.9.2.custom.min.js" type="text/javascript"></script>
    <script src="../Scripts/ImpressaoSaida.js" type="text/javascript"></script>
    <link href="../Styles/Impressao.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" language="javascript">
        $(document).ready(function () {
            //window.print();
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <input type="hidden" id="hddErro" runat="server" />
        <div runat="server" id="divConteudo">
            <div class="pagina">
                <div style="text-align: center">
                    <h2>Controle de Saída -
                    <asp:Label runat="server" ID="lblDataControle" />
                        - Grupo:
                    <asp:Label runat="server" ID="lblIdGrupo" /></h2>
                </div>
                <div class="insercoes">
                    <div style="margin-top: 10px; text-align: center;" runat="server" id="divRetornos">
                    </div>
                </div>
                <div class="clear"></div>
                <div class="rodape">
                </div>
                <div class="clear" style="padding-top: 40px;"></div>
                <div class="divAssinaturas">
                    <div>
                        <span style="border-top-style: solid; border-top-color: black; border-top-width: 3px;">Assinatura Responsável Estoque</span>
                        <span style="padding-left: 160px;"></span>
                        <span style="border-top-style: solid; border-top-color: black; border-top-width: 3px;">Assinatura Responsável Retirada</span>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
