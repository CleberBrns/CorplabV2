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
        if (!IsPostBack)
        {
            CarregaDados();
        }       
    }

    private void CarregaDados()
    {
        Response.Redirect("../Unidades/Cadastrar.aspx");

        //DataTable dtUnidades = new DataTable();

        //if (dtUnidades.Rows.Count == 0)
        //{
        //    Response.Redirect("../Unidades/Cadastrar.aspx");
        //}
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
}