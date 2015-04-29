using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.Services;

public partial class Acoes_Acoes : System.Web.UI.Page
{
    SelecionaDados selecionaDados = new SelecionaDados();
    InsereDados insereDados = new InsereDados();


    protected void Page_Load(object sender, EventArgs e)
    {
        txtAcao.Focus();

        try
        {
            if (!IsPostBack)
            {
                if (Session["SessionUsuario"].ToString() != string.Empty)
                {
                    if (!IsPostBack)
                        CarregaPagina();
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(GetType(), "msgbox", "alert('Perdeu a sessão!');", true);
                    Response.Redirect("../Login/Login.aspx");
                }

            }
        }
        catch (Exception ex)
        {
            RetornaPaginaErro(ex.ToString());
        }

    }

    private void CarregaPagina()
    {
        hddIdUnidade.Value = Session["SessionIdUnidade"].ToString();

    }

    protected void btAcao_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(txtAcao.Text))
        {
            MostraRetorno(string.Empty);
        }
        else
        {
            switch (txtAcao.Text)
            {
                case "01":
                    Response.Redirect("../Acoes/Recepcao.aspx");
                    break;
                case "02":
                    Response.Redirect("../Acoes/Saida.aspx");
                    break;
                case "03":
                    Response.Redirect("../Acoes/Entrada.aspx");
                    break;
                case "04":
                    Response.Redirect("../Acoes/Descarte.aspx");
                    break;
                case "05"://Auditoria
                    VerificaAcessoUsuario();
                    break;
                //case "06":
                //    Response.Redirect("../Auditoria/Busca.aspx");
                //    break;
                default:
                    MostraRetorno("Ação Desconhecida. Favor entrar em contato com o Administrador.");
                    break;
            }
        }
    }

    private void VerificaAcessoUsuario()
    {
        if (Session["SessionTipoAcesso"].ToString() == "1")
        {
            Response.Redirect("../Auditoria/Auditoria.aspx");
        }
        else
        {
            MostraRetorno("Você não possui permissões para acessar essa ferramenta.");
        }
    }

    private void MostraRetorno(string mensagem)
    {
        divRetorno.Visible = true;
        imgErro.Visible = true;

        if (string.IsNullOrEmpty(mensagem))
        {
            lblRetorno.Text = "Por favor, preencha o campo corretamente para prosseguir";
        }
        else
        {
            lblRetorno.Text = mensagem;
        }
    }

    public void RetornaPaginaErro(string erro)
    {
        Session["ExcessaoDeErro"] = erro.Trim();
        Response.Redirect("../Erro/Erro.aspx");
    }

    protected void btMenuPrincipal_Click(object sender, EventArgs e)
    {
        Response.Redirect("../Home/Home.aspx");
    }

}