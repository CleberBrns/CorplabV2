<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Reentrada.aspx.cs" Inherits="Analise_Reentrada" EnableEventValidation="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Reentrada - ALS CorpLab</title>
    <link href="../Styles/jquery-ui-1.9.2.custom.min.css" rel="stylesheet" type="text/css" />
    <script src="../Scripts/jquery-1.11.1.js" type="text/javascript"></script>
    <script src="../Scripts/jquery-ui-1.9.2.custom.min.js" type="text/javascript"></script>
    <script src="../Scripts/Reentrada.js" type="text/javascript"></script>
    <link href="../Styles/Reentrada.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <input type="hidden" id="hddIdGrupo" runat="server" />
        <input type="hidden" id="hddErro" runat="server" />
        <div runat="server" id="divConteudo">
            <div class="pagina">
                <h2>Reentrada</h2>
                <div style="margin-top: 10px; text-align: center;">
                    <span style="font-weight: bold;">Amostra a reentrar na prateleira</span>
                    <input type="text" runat="server" id="txtAmostra" autocomplete="off" style="width: 180px; height: 25px" />
                    <div class="contBt">
                        <asp:Button runat="server" ID="btReinserirAmostra" CssClass="bt" OnClick="btReinserirAmostra_Click" Text="Reinserir Amostra" />
                    </div>

                </div>
                <div class="none" id="divRetornoSaida" runat="server">
                    <div class="clear"></div>
                    <div class="rodape">
                    </div>
                    <div style="padding-top: 10px; text-align: center;">
                        <span style="color: green;" runat="server" id="spanLabelRetorno">
                            <asp:Label runat="server" ID="lblRetornoSaida" /></span>
                    </div>
                </div>
                <div runat="server" id="divInsercoes" class="none">
                    <div class="clear"></div>
                    <div class="rodape">
                    </div>
                    <div class="insercoes">
                        <div style="margin-top: 10px; text-align: center;" runat="server" id="divRetornos">
                        </div>
                    </div>
                </div>
                <div class="clear"></div>
                <div class="rodape">
                </div>
                <div class="contBt" style="padding-top: 20px;">
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
                    <asp:Label runat="server" ID="lblMsgRetorno" Visible="false" /></strong>
            </p>
        </div>
    </form>
</body>
</html>
