using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Analise_Analise : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }


    protected void btUnidades_Click(object sender, EventArgs e)
    {
        Response.Redirect("../Unidades/Unidades.aspx");
    }

    protected void btErro_Click(object sender, EventArgs e)
    {
        Session["ExcessaoDeErro"] = hddErro.Value;
        Response.Redirect("../Erro/Erro.aspx");
    }
}