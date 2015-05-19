<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Consulta.aspx.cs" Inherits="Auditoria_Consulta" EnableEventValidation="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Consulta - ALS CorpLab</title>
    <script src="../Scripts/jquery-1.11.1.js" type="text/javascript"></script>
    <link href="../Styles/Auditoria.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        $(document).ready(function () {

            $("#btDivAmostra").click(function () {
                $("#divAmostra").show();
                $("#divInicio").show();
                $("#divOpcoes").hide();                
                $("#divPrateleira").hide();
                $("#txtAmostra").focus();
            });

            $("#btDivPrateleira").click(function () {
                $("#divOpcoes").hide();
                $("#divAmostra").hide();
                $("#divInicio").show();
                $("#divPrateleira").show();
                $("#txtPrateleira").focus();
            });

            $("#btAmostra").click(function () {
                $("#divOpcoes").hide();
                $("#divAmostra").show();
                $("#divInicio").show();
                $("#divPrateleira").hide();
                $("#txtAmostra").focus();
                $("#divConsulta").show();
            });

            $("#btPrateleira").click(function () {
                $("#divOpcoes").hide();
                $("#divAmostra").hide();
                $("#divInicio").show();
                $("#divPrateleira").show();
                $("#txtPrateleira").focus();
                $("#divConsulta").show();
            });

        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <input type="hidden" runat="server" id="hddTestPost" />
        <input type="hidden" runat="server" id="hddIdUnidade" value="0" />
        <input type="hidden" runat="server" id="hddIdPrateleira" />
        <input type="hidden" runat="server" id="hddCodPrateleira" />
        <input type="hidden" id="hddErro" runat="server" />
        <div class="pagina" runat="server" id="divPagina">
            <h2>Consulta <asp:Label runat="server" ID="lblBusca" CssClass="lblCamara" />
            </h2>
            <div style="padding-bottom: 3%;">
                <div class="insercoes">
                    <div style="margin-top: 3%;" runat="server" id="divOpcoes">
                        <div class="contBt">
                            <input type="button" class="bt" runat="server" id="btDivAmostra" title="Consultar Amostra" value="Amostra" />
                            <input type="button" class="bt" runat="server" id="btDivPrateleira" title="Consultar Prateleira" value="Prateleira" />
                        </div>
                    </div>
                    <div style="margin-top: 3%;" runat="server" id="divPrateleira" class="none">
                        Entre com a Prateleira
                    <asp:Panel runat="server" DefaultButton="btPrateleira" style="margin-top: 10px">
                        <asp:TextBox runat="server" ID="txtPrateleira" Width="180px" Height="25px" autocomplete="off" />
                        <div style="display: none">
                            <asp:Button runat="server" ID="btPrateleira" OnClick="btPrateleira_Click" />
                        </div>
                    </asp:Panel>
                    </div>
                    <div runat="server" id="divAmostra" class="none" style="margin-top: 3%;">
                        <div>
                            Entre com a Amostra 
                        </div>
                        <br />
                        <asp:Panel runat="server" DefaultButton="btAmostra">
                            <asp:TextBox runat="server" ID="txtAmostra" Width="180px" Height="25px" autocomplete="off" />
                            <div style="display: none">
                                <asp:Button runat="server" ID="btAmostra" OnClick="btAmostra_Click" />
                            </div>
                        </asp:Panel>
                    </div>
                    <div style="margin-top: 3%; margin-bottom: 3%; text-align: center; font-size: 18px;" runat="server" id="divRetorno" visible="false">
                        <div style="margin-bottom: 3%;">
                            <asp:Image runat="server" ID="imgOk" ImageUrl="../Imagens/ok.png" Visible="false" Width="3%" />
                            <asp:Image runat="server" ID="imgErro" ImageUrl="../Imagens/error.png" Visible="false" Width="3%" />
                            <asp:Label runat="server" ID="lblRetorno" />
                        </div>
                    </div>
                    <div style="margin-top: 3%;" runat="server" id="divConsulta" class="none">
                        <div>
                            <asp:Repeater runat="server" ID="rptConsulta">
                                <HeaderTemplate>
                                    <table cellspacing="0" cellpadding="0" width="100%">
                                        <tr class="amostrasPrateleira" style="background-color: #DDD;">
                                            <td>CodAmostra</td>
                                            <td>Usuário Data Recepção</td>                                            
                                            <td>Estante</td>
                                            <td>Prateleira</td>
                                            <td>Caixa</td>
                                            <td>Ultima Alteração</td>
                                            <td>Auditado?</td>
                                        </tr>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <tr class="amostrasGrupo">
                                        <td><%# DataBinder.Eval(Container.DataItem, "CodAmostra") %></td>
                                        <td><%# DataBinder.Eval(Container.DataItem, "DataUsuarioRecepcao") %></td>                                        
                                        <td><%# DataBinder.Eval(Container.DataItem, "Estante") %></td>
                                        <td><%# DataBinder.Eval(Container.DataItem, "Prateleira") %></td>
                                        <td><%# DataBinder.Eval(Container.DataItem, "Caixa") %></td>
                                        <td><%# DataBinder.Eval(Container.DataItem, "UltimaAlteracao") %></td>
                                        <td><%# DataBinder.Eval(Container.DataItem, "Auditado") %></td>
                                    </tr>
                                </ItemTemplate>
                                <FooterTemplate>
                                    </table>
                                </FooterTemplate>
                            </asp:Repeater>
                        </div>
                    </div>
                    <div style="margin-top: 10%;" runat="server" id="divProcessando" visible="false">
                        Processando...
                    <div style="margin-top: 10px">
                        <asp:Image runat="server" ID="imgProcessando" ImageUrl="~/Imagens/loading.gif" Width="25%" />
                    </div>
                    </div>
                </div>              
                <div runat="server" id="divInicio" class="none" style="padding-top: 2%;">
                    <div class="rodape">
                    </div>
                    <div class="contBt">
                        <asp:Button runat="server" CssClass="bt" ID="btInicio" OnClick="btInicio_Click" Text="Nova Consulta" />                        
                        <asp:Button runat="server" ID="btImprimir" OnClick="btImprimir_Click" CssClass="bt" Text="Imprimir" Visible="false" />
                    </div>
                </div>
            </div>
            <div class="rodape">
            </div>
            <div class="contBt">
                <asp:Button runat="server" ID="btMenuPrincial" OnClick="btMenuPrincipal_Click" CssClass="bt" Text="Menu Principal" />
                <asp:Button runat="server" ID="btAcoes" CssClass="bt" Text="Menu Ações" OnClick="btMenuAcoes_Click" />
            </div>
        </div>
    </form>
</body>
</html>
