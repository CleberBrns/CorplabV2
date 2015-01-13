using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Analise_Analise : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btSaida_Click(object sender, EventArgs e)
    {
        Session["IdGrupo"] = hddIdGrupo.Value.Trim();
        Response.Redirect("../Analise/Saida.aspx");
    }

    protected void btReetrada_Click(object sender, EventArgs e)
    {
        Session["IdGrupo"] = hddIdGrupo.Value.Trim();
        Response.Redirect("../Analise/Reentrada.aspx");
    }

    protected void btErro_Click(object sender, EventArgs e)
    {
        Session["ExcessaoDeErro"] = hddErro.Value;
        Response.Redirect("../Erro/Erro.aspx");
    }

}