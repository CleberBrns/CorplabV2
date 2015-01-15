using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Auditoria_Auditoria : System.Web.UI.Page
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
    public static List<Auxiliar.AmostraXGrupo> ConsultaAmostrasGrupo()
    {
        Auxiliar auxiliar = new Auxiliar();

        DataTable dtAmostras = auxiliar.RetornaAmostraTeste();

        List<Auxiliar.AmostraXGrupo> list = new List<Auxiliar.AmostraXGrupo>();
        Auxiliar.AmostraXGrupo obj = new Auxiliar.AmostraXGrupo();
        foreach (DataRow item in dtAmostras.Rows)
        {
            obj = new Auxiliar.AmostraXGrupo();
            obj.IdAmostra = Convert.ToInt32(item["IdAmostra"]);
            obj.Descricao = item["Descricao"].ToString();
            obj.TipoAmostra = item["TipoAmostra"].ToString();
            obj.DataEntrada = item["DataEntrada"].ToString();
            obj.StatusAmostra = item["StatusAmostra"].ToString();
            obj.IdStatusAmostra = Convert.ToInt32(item["IdStatusAmostra"]);
            list.Add(obj);
        }

        return list;
    }

}