using System;
using System.Collections.Generic;
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
        if (txtLogin.Text == "admin" && txtSenha.Text == "@dmin01")
        {
            Response.Redirect("../Home/Home.aspx");
            lblRetorno.Visible = false;
        }
        else
        {
            lblRetorno.Visible = true;
            lblRetorno.Text = "Login e/ou Senha inválidos";
        }
    }
}