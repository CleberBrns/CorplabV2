using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.Services;

public partial class Unidades_Unidades : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["SessionIdTipoAcesso"].ToString() != "1")
            {
                RetornaPaginaErro("Você não possui permissões para acessar essa ferramenta.");
            }
            else
            {
                if (!IsPostBack)
                {
                    CarregaDados();
                }
            }
        }
        catch (Exception ex)
        {
            RetornaPaginaErro("Perdeu a sessão. Faça o login novamente, por favor.");
        }

    }

    private void CarregaDados()
    {
        try
        {
            if (Convert.ToInt32(Session["SessionQtdUnidades"].ToString()) > 0)
            {
                btGerenciar.Visible = true;
            }
            else
            {
                Response.Redirect("../Unidades/Cadastrar.aspx");
            }
        }
        catch (Exception)
        {
            Response.Redirect("../Unidades/Cadastrar.aspx");
        }
    }

    protected void btNovaUnidade_Click(object sender, EventArgs e)
    {
        Response.Redirect("../Unidades/Cadastrar.aspx");
    }

    protected void btGerenciar_Click(object sender, EventArgs e)
    {
        Response.Redirect("../Unidades/Gerenciar.aspx");
    }

    protected void btMenuPrincipal_Click(object sender, EventArgs e)
    {
        Response.Redirect("../Home/Home.aspx");
    }

    public void RetornaPaginaErro(string erro)
    {
        Session["ExcessaoDeErro"] = erro.Trim();
        Response.Redirect("../Erro/Erro.aspx");
    }
}