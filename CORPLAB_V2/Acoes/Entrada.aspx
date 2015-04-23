<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Entrada.aspx.cs" Inherits="Acoes_Recepcao" EnableEventValidation="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Recep&ccedil;&atilde;o - ALS CorpLab</title>
    <link href="../Styles/Acoes.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        /////////////////////////////////////////////////////////////////////////////////////////////
        function Redireciona(acao) {

            var destino;

            if (acao == 0) {
                destino = "../Home/Home.aspx";                
            }
            else {
                destino = "../Acoes/Recepcao.aspx";
            }

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
            <h2>Recepção <asp:Label runat="server" ID="lblCamara" CssClass="lblCamara" /><asp:Label runat="server" ID="lblPrateleira" CssClass="lblCamara" /><asp:Label runat="server" ID="lblComCaixa" CssClass="lblCamara" />
            </h2>           
            <div class="insercoes">
                <div style="margin-top: 10%;" runat="server" id="divInsercaoAtual">
                    <asp:Label runat="server" ID="lblInsercaoAtual" />
                </div>
                <div style="margin-top: 10%;" runat="server" id="divCamara">
                    Selecione a C&acirc;mara
                    <div style="margin-top: 10px">
                        <asp:DropDownList runat="server" ID="ddlCamaras" AutoPostBack="true" OnSelectedIndexChanged="ddlCamaras_SelectedIndexChanged"
                            Width="180px" Height="30px">
                            <asp:ListItem Text="-- Selecione --" Value="0"></asp:ListItem>
                            <asp:ListItem Text="ALS 01" Value="01"></asp:ListItem>
                            <asp:ListItem Text="ALS 02" Value="02"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
                <div style="margin-top: 10%;" runat="server" id="divPrateleira" visible="false">
                    Entre com a Prateleira
                    <div style="margin-top:10px">
                        <asp:TextBox runat="server" ID="txtPrateleira" Width="180px" Height="25px" autocomplete="off" />
                        <div style="display: none">
                            <asp:Button runat="server" ID="btPrateleira" OnClick="btPrateleira_Click" />
                        </div>
                    </div>                   
                </div>
                <div style="margin-top: 10%;" runat="server" id="divInsercoes" visible="false">
                    Insira a amostra
                    <div style="margin-top: 10px">
                        <asp:TextBox runat="server" ID="txtAmostra" Width="180px" Height="25px" autocomplete="off" />
                         <div style="display: none">
                            <asp:Button runat="server" ID="btAmostra" OnClick="btAmostra_Click" />
                        </div>
                        <div style="margin-top: 3%;">
                            <asp:CheckBox runat="server" ID="ckbComCaixa" Text="Com Caixa" AutoPostBack="true" OnCheckedChanged="ckbComCaixa_CheckedChanged" />
                        </div>
                        <div runat="server" id="divComCaixa" visible="false" style="margin-top: 3%;">
                            Insira a caixa
                            <div style="margin-top: 3%;">
                                <asp:TextBox runat="server" ID="txtCaixa" Width="180px" Height="25px" autocomplete="off" onkeydown="return (event.keyCode!=13);" />
                                <div style="display: none">                            
                        </div>
                            </div>
                        </div>                     
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
                    <asp:Image runat="server" ID="imgOk" ImageUrl="../Imagens/ok.png" Visible="false" Width="8%" />
                    <asp:Image runat="server" ID="imgErro" ImageUrl="../Imagens/error.png" Visible="false" Width="8%" />
                </div>
                <asp:Label runat="server" ID="lblRetorno" />
            </div>
            <div runat="server" id="divInicio" visible="false">
                <div class="rodape">
                </div>
                <div class="contBt">
                    <a href="javascript:Redireciona(1);" runat="server" id="linkInicio">
                        <input type="button" class="bt" value="In&iacute;cio" /></a>
                    <asp:Button runat="server" ID="btNovaPrateleira" OnClick="btNovaPrateleira_Click" CssClass="bt" Text="Nova Prateleira" />                   
                </div>
            </div>
            <div class="rodape">
            </div>
            <div class="contBt">
              <a href="javascript:Redireciona(0);">
                    <input type="button" class="bt" value="Menu Principal" /></a>
            </div>
        </div>
    </form>
</body>
</html>
