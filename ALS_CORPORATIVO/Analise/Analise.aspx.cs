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
        try
        {
            if (Session["SessionUser"].ToString() == string.Empty)
            {
                Page.ClientScript.RegisterStartupScript(GetType(), "SemSessao", "alert('Perdeu a sessão!');", true);
                Response.Redirect("../Login/Login.aspx");
            }
        }
        catch (Exception)
        {
            Page.ClientScript.RegisterStartupScript(GetType(), "SemSessao", "alert('Perdeu a sessão!');", true);
            Response.Redirect("../Login/Login.aspx");
        }
    }

    [WebMethod]
    public static bool ConstultaGrupo(string codGrupo)
    {
        bool sucesso = false;

        SelecionaDados selecionaDados = new SelecionaDados();
        DataTable dtGrupo = selecionaDados.ConsultaGrupoXAmostra(codGrupo);

        if (dtGrupo.Rows.Count > 0)        
            sucesso = true;        

        return sucesso;
    }

    protected void btSaida_Click(object sender, EventArgs e)
    {
        Session["CodGrupo"] = hddIdGrupo.Value.Trim();
        Response.Redirect("../Analise/Saida.aspx");
    }

    protected void btReetrada_Click(object sender, EventArgs e)
    {
        Session["CodGrupo"] = hddIdGrupo.Value.Trim();
        Response.Redirect("../Analise/Reentrada.aspx");
    }

    protected void btErro_Click(object sender, EventArgs e)
    {
        Session["ExcessaoDeErro"] = hddErro.Value;
        Response.Redirect("../Erro/Erro.aspx");
    }

}