<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Cadastrar.aspx.cs" Inherits="Unidades_Cadastrar" EnableEventValidation="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Recep&ccedil;&atilde;o - ALS CorpLab</title>
    <link href="../Styles/Acoes.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <input type="hidden" runat="server" id="hddTestPost" />
        <input type="hidden" runat="server" id="hddIdUnidade" value="0" />
        <input type="hidden" runat="server" id="hddInclusoes" />
        <input type="hidden" id="hddErro" runat="server" />
        <div class="pagina" runat="server" id="divPagina">
            <h2>Nova Unidade<asp:Label runat="server" ID="lblUnidade" CssClass="lblCamara" />
            </h2>
            <div style="padding-bottom: 3%;">
                <div class="insercoes">
                    <div style="margin-top: 10%;" runat="server" id="divUnidade">
                        <div style="margin-top: 5px; display: none;">
                            País&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:DropDownList runat="server" ID="ddlPais" Width="180px" Height="25px">
                        <asp:ListItem Text="-- Selecione --" Value="0" />
                    </asp:DropDownList>
                        </div>
                        <div style="margin-top: 5px;">
                            Estado
                    <asp:DropDownList runat="server" ID="ddlEstado" Width="180px" Height="25px" AutoPostBack="true" OnSelectedIndexChanged="ddlEstado_SelectedIndexChanged">
                        <asp:ListItem Text="-- Selecione --" Value="0" />
                    </asp:DropDownList>
                        </div>
                        <div style="margin-top: 5px;">
                            Cidade
                    <asp:DropDownList runat="server" ID="ddlCidade" Width="180px" Height="25px" Enabled="false">
                        <asp:ListItem Text="-- Selecione --" Value="0" />
                    </asp:DropDownList>
                        </div>
                        <div style="margin-top: 10px;">
                            Nome da Unidade
                    <asp:TextBox runat="server" placeholder="Campo obrigatório" autocomplete="off" Width="180px"
                        Height="25px" ID="txtNomeUnidade"></asp:TextBox>
                        </div>
                    </div>
                    <div style="margin-top: 10%;" runat="server" id="divConfiguraUnidade" visible="false">                        
                        <div style="margin-top: 10%;" runat="server" id="divCamara" visible="false">
                            Insira a Câmara
                        <asp:Panel runat="server" DefaultButton="btCamara" style="margin-top: 10px">
                            <asp:TextBox runat="server" ID="txtCamara" Width="180px" Height="25px" autocomplete="off" />
                            <div style="display: none">
                                <asp:Button runat="server" ID="btCamara" OnClick="btCamara_Click" />
                            </div>
                        </asp:Panel>
                        </div>
                        <div style="margin-top: 10%;" runat="server" id="divEstante" visible="false">
                            Insira a Estante
                        <asp:Panel runat="server" DefaultButton="btEstante" Style="margin-top: 10px">
                            <asp:TextBox runat="server" ID="txtEstante" Width="180px" Height="25px" autocomplete="off" />
                            <div style="display: none">
                                <asp:Button runat="server" ID="btEstante" OnClick="btEstante_Click" />
                            </div>
                        </asp:Panel>
                        </div>
                        <div style="margin-top: 10%;" runat="server" id="divPrateleiras" visible="false">
                            Insira as Prateleiras
                        <asp:Panel runat="server" DefaultButton="btPrateleiras" Style="margin-top: 10px">
                            <asp:TextBox runat="server" ID="txtPrateleiras" Width="180px" Height="25px" autocomplete="off" />
                            <div style="display: none">
                                <asp:Button runat="server" ID="btPrateleiras" OnClick="btPrateleiras_Click" />
                            </div>
                        </asp:Panel>
                        </div>
                    </div>
                    <div style="margin-top: 10%;" runat="server" id="divProcessando" visible="false">
                        Processando...
                    <div style="margin-top: 10px">
                        <asp:Image runat="server" ID="imgProcessando" ImageUrl="~/Imagens/loading.gif" Width="100%" />
                    </div>
                    </div>
                </div>
                <div style="margin-top: 3%; margin-bottom: 3%; text-align: center; font-size: 18px;" runat="server" id="divRetorno" visible="false">
                    <div style="margin-bottom: 3%;">
                        <asp:Image runat="server" ID="imgOk" ImageUrl="../Imagens/ok.png" Visible="false" Width="5%" />
                        <asp:Image runat="server" ID="imgErro" ImageUrl="../Imagens/error.png" Visible="false" Width="5%" />
                    </div>
                    <asp:Label runat="server" ID="lblRetorno" />
                </div>
                <div runat="server" id="divAcoes">
                    <div class="rodape">
                    </div>
                    <div class="contBt">
                        <asp:Button runat="server" ID="btCadastrar" OnClick="btCadastrar_Click" CssClass="bt" Text="Cadastrar" />
                        <asp:Button runat="server" ID="btConfigurarUnidade" OnClick="btConfigurarUnidade_Click" CssClass="bt" Text="Configurar Unidade" Visible="false" />
                        <asp:Button runat="server" ID="btInicio" OnClick="btInicio_Click" CssClass="bt" Text="Inicio" Visible="false" />                     
                    </div>
                </div>
            </div>
            <div class="rodape">
            </div>
            <div class="contBt">
                <asp:Button runat="server" ID="btMenuPrincipal" CssClass="bt" OnClick="btMenuPrincipal_Click" Text="Menu Principal" />                
            </div>
        </div>
    </form>
</body>
</html>
