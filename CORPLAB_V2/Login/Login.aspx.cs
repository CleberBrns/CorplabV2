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

        //if (txtLogin.Text == "admin" && txtSenha.Text == "@dmin01")
        //{
        //    Session["SessionUser"] = "Gestor";
        //    Session["SessionIdUser"] = "0";
        //    Session["SessionIdUnidade"] = "0";
        //    Response.Redirect("../Home/Home.aspx");
        //    divRetorno.Visible = false;
        //}
        //else
        //{
        try
        {
            DataTable dtUsuario = selecionaDados.ConsultaUsuario(txtLogin.Text.Trim(), txtSenha.Text.Trim());

            if (dtUsuario.Rows.Count > 0)
            {
                if (dtUsuario.Rows[0]["IdTipoStatus"].ToString() == "0")
                {
                    divRetorno.Visible = true;
                    lblRetorno.Text = "Usuário bloqueado. <br /> Para mais informações, por favor, contate o Administrador do Sistema.";
                }
                else
                {
                    divRetorno.Visible = false;

                    Session["SessionUsuario"] = dtUsuario.Rows[0]["Nome"].ToString();
                    Session["SessionIdUsuario"] = dtUsuario.Rows[0]["IdUsuario"].ToString();
                    Session["SessionIdTipoAcesso"] = dtUsuario.Rows[0]["IdTipoAcesso"].ToString();
                    Session["SessionIdUnidade"] = dtUsuario.Rows[0]["IdUnidade"].ToString();
                    Response.Redirect("../Home/Home.aspx");
                }

            }
            else
            {
                divRetorno.Visible = true;
                lblRetorno.Text = "Dados de acesso incorrentos <br /> e/ou usuário não cadastrado.";
            }

        }
        catch (Exception)
        {
            divRetorno.Visible = true;
            lblRetorno.Text = "Erro com a requisição.<br /> Por favor, contate o Administrador do sistema.";
        }

        //}

    }
}