<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Auditoria.aspx.cs" Inherits="Auditoria_Auditoria" EnableEventValidation="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Auditoria</title>
    <link href="../Styles/jquery-ui-1.9.2.custom.min.css" rel="stylesheet" type="text/css" />
    <script src="../Scripts/jquery-1.11.1.js" type="text/javascript"></script>
    <script src="../Scripts/jquery-ui-1.9.2.custom.min.js" type="text/javascript"></script>
    <script src="../Scripts/Auditoria.js" type="text/javascript"></script>
    <link href="../Styles/Auditoria.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <input type="hidden" id="hddIdUnidade" runat="server" value="0" />
        <input type="hidden" id="hddErro" runat="server" />
        <div runat="server" id="divConteudo">
            <div class="pagina">
                <h2>Auditoria</h2>
                <div class="clear"></div>
                <div style="margin-top: 10px; text-align: center;" class="insercoes">
                    <div style="margin-top: 5px;" class="divUnidade">
                        Unidade
                <asp:DropDownList runat="server" ID="ddlUnidade" Width="180px" Height="25px">
                </asp:DropDownList>
                    </div>
                    <div style="margin-top: 10px;" class="divCamara">
                        <span>Câmara</span>
                        <asp:DropDownList runat="server" ID="ddlCamaras" Width="120px" Height="25px">
                            <asp:ListItem Value="0">-- Selecione --</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div style="margin-top: 10px;">
                        Prateleira
                <asp:DropDownList runat="server" ID="ddlPrateleira" Width="120px" Height="25px">
                    <asp:ListItem Value="0">-- Selecione --</asp:ListItem>
                </asp:DropDownList>
                    </div>
                    <div style="margin-top: 10px;">
                        <span style="font-weight: bold;">Amostra a ser pesquisada</span>
                        <div>
                            <input type="text" runat="server" id="txtAmostra" autocomplete="off" style="width: 150px; height: 25px; text-align: center" />
                        </div>
                    </div>
                    <div id="divAmostraAusente" class="none" style="margin-top: 10px; color: red;">
                        <asp:Label runat="server" ID="lblRetornoPesquisa" Text="Essa amostra não consta na prateleira indicada." />
                    </div>
                    <div class="rodape" style="margin-top: 10px;">
                    </div>
                    <div id="divExibicaoInfos" class="none">
                        <div class="contBt">
                            <input type="button" class="bt" style="width: 150px;" value="Exibir Amostras" id="btInfoGrupo" />
                            <input type="button" class="bt none" style="width: 180px;" value="Esconder Amostras" id="btEscondeInfoGrupo" />
                        </div>
                        <div class="insercoes none" id="divInfoGrupo">
                            <div style="margin-top: 10px; text-align: center;" runat="server" id="divRetornos">
                            </div>
                        </div>
                    </div>
                    <div class="clear"></div>
                    <div class="rodape">
                    </div>
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
