<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Unidades1.aspx.cs" Inherits="Unidades_Unidades"
    EnableEventValidation="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Unidades - ALS CorpLab</title>
    <link href="../Styles/Unidades.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <input type="hidden" id="hddIdUnidade" runat="server" />
    <input type="hidden" id="hddLetraIncluida" runat="server" />
    <input type="hidden" id="hddPrateleiraIncluida" runat="server" />
    <input type="hidden" id="hddExibicaoPrateleiras" runat="server" />
    <input type="hidden" id="hddErro" runat="server" />
    <div class="pagina">
        <div runat="server" id="divPaginaInicial">
            <div class="contBt none">
                <input type="button" runat="server" id="btGerenciar" value="Gerenciar Unidades" class="bt" />
            </div>
            <div class="contBt">
                <input type="button" runat="server" id="btNovaUnidade" value="Incluir Nova Unidade"
                    class="bt" />
            </div>
        </div>
        <div runat="server" id="divNovaUnidade" visible="false">
            <div class="insercoes">
                <div style="margin-top: 5px; display: none;">
                    País&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:DropDownList runat="server" ID="ddlPais" Width="180px" Height="25px">
                    </asp:DropDownList>
                </div>
                <div style="margin-top: 5px;">
                    Estado
                    <asp:DropDownList runat="server" ID="ddlEstado" Width="180px" Height="25px">
                    </asp:DropDownList>
                </div>
                <div style="margin-top: 5px;">
                    Cidade
                    <asp:DropDownList runat="server" ID="ddlCidade" Width="180px" Height="25px">
                    </asp:DropDownList>
                </div>
                <div style="margin-top: 10px;">
                    Nome da Unidade
                    <asp:TextBox runat="server" placeholder="Campo obrigatório" autocomplete="off" Width="180px"
                        Height="25px" ID="txtNomeUnidade"></asp:TextBox>
                </div>
                <div style="margin-top: 5px;">
                    Quantidade de Câmaras
                    <asp:DropDownList runat="server" ID="ddlQtdCamaras" Width="180px" Height="25px">
                        <asp:ListItem Value="1" Text="1"></asp:ListItem>
                        <asp:ListItem Value="2" Text="2"></asp:ListItem>
                        <asp:ListItem Value="3" Text="3"></asp:ListItem>
                        <asp:ListItem Value="4" Text="4"></asp:ListItem>
                        <asp:ListItem Value="5" Text="5"></asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div style="margin-top: 5px; text-align: center;">
                    <input type="button" runat="server" id="btInserirPrateleiras" class="btIncluir" value="Inserir Prateleiras" />
                </div>
            </div>
        </div>
        <div runat="server" id="divPrateleiras" visible="false">
            <div class="insercoesPratelerias">
                <div style="margin-top: 5px;">
                    <div class="divCamaraCadastrada none">
                        Câmara Cadastrada
                        <div>
                            <asp:DropDownList runat="server" ID="ddlCamaras" Width="180px" Height="25px">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div style="margin-top: 5px;">
                        Coluna&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:DropDownList runat="server" ID="ddlAlfabeto" Width="45px" Height="25px">
                        </asp:DropDownList>
                    </div>
                    <div style="margin-top: 1px;">
                        Quantidade&nbsp;
                        <asp:DropDownList runat="server" ID="ddlNumeracao" Width="45px" Height="25px">
                        </asp:DropDownList>
                    </div>
                </div>
                <div style="margin-top: 10px; text-align: center;">
                    <input type="button" runat="server" id="btAdicionarPrateleira" class="btIncluir"
                        value="Incluir Prateleira" />
                </div>
                <div style="margin-top: 10px;" class="contadorItens">
                    Prateleiras p/incluir;
                </div>
                <div style="margin-top: 10px;" class="contadorItens">
                    <asp:Label runat="server" ID="lblPrateleirasIncluidas" />
                </div>
                <div runat="server" id="divConcluirUnidade" style="margin-top: 10px; text-align: center;
                    display: none;">
                    <div style="margin-top: 10px;">
                        <input type="button" runat="server" id="btConcluirUnidade" title="Finaliza e salva as configurações da unidade"
                            class="btIncluir" value="Concluir Unidade" />
                    </div>
                </div>
            </div>
        </div>
        <div class="rodape">
        </div>
        <div class="contBt">
            <a href="javascript:Redireciona(0);">
                <input type="button" class="bt" value="Menu Principal" runat="server" id="btMenuPrincipal" /></a>
        </div>
    </div>
    </form>
</body>
</html>
