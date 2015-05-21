﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Importacao.aspx.cs" Inherits="Importacao_Importacao" EnableEventValidation="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Importação - ALS CorpLab</title>
    <script src="../Scripts/jquery-1.11.1.js" type="text/javascript"></script>
    <link href="../Styles/Auditoria.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        $(document).ready(function () {

            $("#btMostrarConsulta").click(function () {
                $(this).hide();
                $("#btEsconderConsulta").show();
                $("#divConsulta").show();
               
            });

            $("#btEsconderConsulta").click(function () {
                $(this).hide();
                $("#btMostrarConsulta").show();
                $("#divConsulta").hide();
            });

        });
    </script>
</head>
<body>
    <form id="form1" runat="server">       
        <input type="hidden" runat="server" id="hddIdUnidade" value="0" />
        <input type="hidden" runat="server" id="hddIdPrateleira" />
        <input type="hidden" runat="server" id="hddCodPrateleira" />
        <input type="hidden" id="hddErro" runat="server" />
        <div class="pagina" runat="server" id="divPagina">
            <h2>Importação <asp:Label runat="server" ID="lblBusca" CssClass="lblCamara" />
            </h2>
            <div style="padding-bottom: 3%;">
                <div class="insercoes">                    
                    <div style="margin-top: 3%;" runat="server" id="divUpload">
                        Selecione o arquivo para importação
                    <asp:Panel runat="server" style="margin-top: 10px" CssClass="contBt">
                        <asp:FileUpload runat="server" ID="fUpload" CssClass="bt" />
                        <div>
                            <asp:Button runat="server" ID="btUpload" OnClick="btUpload_Click" Text="Upload" CssClass="bt" />
                        </div>
                    </asp:Panel>
                    </div>                  
                    <div style="margin-top: 3%; margin-bottom: 3%; text-align: center; font-size: 18px;" runat="server" id="divRetorno" visible="false">
                        <div style="margin-bottom: 3%;">
                            <asp:Image runat="server" ID="imgOk" ImageUrl="../Imagens/ok.png" Visible="false" Width="3%" />
                            <asp:Image runat="server" ID="imgErro" ImageUrl="../Imagens/error.png" Visible="false" Width="3%" />
                            <div style="margin-top: 2%;">
                                <asp:Label runat="server" ID="lblRetorno" />
                            </div>
                        </div>
                    </div>
                    <div runat="server" id="divOpcoes" style="padding-top: 2%;" visible="false">
                        <div class="rodape">
                        </div>
                        <div class="contBt">
                            <asp:Button runat="server" CssClass="bt" ID="btInicio" OnClick="btInicio_Click" Text="Nova Importação" />
                            <input type="button" runat="server" id="btMostrarConsulta" class="bt" value="Mostra Consulta" />
                            <input type="button" runat="server" id="btEsconderConsulta" class="bt none" value="Esconde Consulta" />
                            <asp:Button runat="server" ID="btImprimir" OnClick="btImprimir_Click" CssClass="bt" Text="Imprimir" Visible="false" />
                        </div>
                    </div>
                    <div style="margin-top: 10%;" runat="server" id="divProcessando" visible="false">
                        <span>Processando...</span>
                        <div style="margin-top: 10px">
                            <asp:Image runat="server" ID="imgProcessando" ImageUrl="~/Imagens/loading.gif" Width="25%" />
                        </div>
                    </div>
                    <div style="margin-top: 3%;" runat="server" id="divConsulta" class="none">
                        <div>
                            <asp:Repeater runat="server" ID="rptConsulta">
                                <HeaderTemplate>
                                    <table cellspacing="0" cellpadding="0" width="100%">
                                        <tr class="amostrasPrateleira" style="background-color: #DDD;">
                                            <td>CodAmostra</td>
                                            <td>Status</td>                                       
                                            <td>Prateleira</td>                                     
                                        </tr>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <tr class="amostrasGrupo">
                                        <td><%# DataBinder.Eval(Container.DataItem, "CodAmostra") %></td>
                                        <td><%# DataBinder.Eval(Container.DataItem, "Status") %></td>
                                        <td><%# DataBinder.Eval(Container.DataItem, "Prateleira") %></td>
                                    </tr>
                                </ItemTemplate>
                                <FooterTemplate>
                                    </table>
                                </FooterTemplate>
                            </asp:Repeater>
                        </div>
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
