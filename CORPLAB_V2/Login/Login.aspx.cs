using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Login_Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Acessar_Click(object sender, EventArgs e)
    {
        VerificaAcesso();
    }

    private void VerificaAcesso()
    {
        SelecionaDados selecionaDados = new SelecionaDados();

        if (txtLogin.Text == "admin" && txtSenha.Text == "@dmin01")
        {
            Session["SessionUser"] = "Gestor";
            Session["SessionIdUnidade"] = "0";
            Response.Redirect("../Home/Home.aspx");
            lblRetorno.Visible = false;
        }
        else
        {
            try
            {
                DataTable dtUsuario = selecionaDados.ConsultaAcessoUsuario(txtLogin.Text.Trim(), txtSenha.Text.Trim());

                if (dtUsuario.Rows.Count > 0)
                {
                    if (dtUsuario.Rows[0]["IdStatus"].ToString() == "0")
                    {
                        lblRetorno.Visible = true;
                        lblRetorno.Text = "Usuário bloqueado. Para mais informações, por favor, contate o Administrador do sistema.";
                    }
                    else
                    {
                        lblRetorno.Visible = false;
                        Session["SessionUser"] = dtUsuario.Rows[0]["TipoAcesso"].ToString();
                        Session["SessionIdUnidade"] = dtUsuario.Rows[0]["IdUnidade"].ToString();
                        Response.Redirect("../Home/Home.aspx");
                    }

                }
                else
                {
                    lblRetorno.Visible = true;
                    lblRetorno.Text = "Dados de acesso incorrentos e/ou usuário não cadastrado.";
                }

            }
            catch (Exception)
            {
                lblRetorno.Visible = true;
                lblRetorno.Text = "Erro com a requisição. Por favor, contate o Administrador do sistema.";
            }

        }

    }
}