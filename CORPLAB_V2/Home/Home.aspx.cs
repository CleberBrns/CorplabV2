using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Home_Home : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["SessionUser"].ToString() != string.Empty)
            {
                if (Session["SessionUser"].ToString() != "Gestor")
                {
                    btUsuarios.Visible = false;
                    btUnidades.Visible = false;
                }
            }
        }
        catch (Exception)
        {
            Page.ClientScript.RegisterStartupScript(GetType(), "SemSessao", "alert('Perdeu a sessão!');", true);
            Response.Redirect("../Login/Login.aspx");
        }

    }

    protected void btUsuarios_Click(object sender, EventArgs e)
    {
        Response.Redirect("../Usuarios/Usuarios.aspx");
    }

    protected void btSair_Click(object sender, EventArgs e)
    {
        Session["SessionUser"] = null;
        Session["SessionIdUnidade"] = null;
        Response.Redirect("../Login/Login.aspx");
    }

    protected void btUnidades_Click(object sender, EventArgs e)
    {
        Response.Redirect("../Unidades/Unidades.aspx");
    }

    protected void btAcoes_Click(object sender, EventArgs e)
    {
        Response.Redirect("../Acoes/Acoes.aspx");
    }
    
}