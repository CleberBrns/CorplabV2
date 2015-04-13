using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Analise_Impressao : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["SessionUser"].ToString() == string.Empty || Session["CodGrupo"].ToString() == string.Empty)
            {
                Page.ClientScript.RegisterStartupScript(GetType(), "SemSessao", "alert('Perdeu a sessão!');", true);
                Response.Redirect("../Login/Login.aspx");
            }
            else
            {
                if (!IsPostBack)
                {
                    lblDataControle.Text = DateTime.Now.ToShortDateString();
                    lblIdGrupo.Text = Session["CodGrupo"].ToString();
                    hddIdGrupo.Value = Session["CodGrupo"].ToString();
                }
            }
        }
        catch (Exception)
        {
            Page.ClientScript.RegisterStartupScript(GetType(), "SemSessao", "alert('Perdeu a sessão!');", true);
            Response.Redirect("../Login/Login.aspx");
        }       
    }

    [WebMethod]
    public static List<Auxiliar.AmostraXGrupo> ConsultaAmostrasGrupo(string sIdGrupo)
    {
        Auxiliar auxiliar = new Auxiliar();
        SelecionaDados selecionaDados = new SelecionaDados();

        DataTable dtAmostrasGrupo = selecionaDados.ConsultaGrupoXAmostra(sIdGrupo);
        dtAmostrasGrupo.DefaultView.RowFilter = "IdStatusAmostra = 1";

        dtAmostrasGrupo = dtAmostrasGrupo.DefaultView.ToTable();

        List<Auxiliar.AmostraXGrupo> list = new List<Auxiliar.AmostraXGrupo>();
        Auxiliar.AmostraXGrupo obj = new Auxiliar.AmostraXGrupo();
        foreach (DataRow item in dtAmostrasGrupo.Rows)
        {
            obj = new Auxiliar.AmostraXGrupo();
            obj.IdAmostra = Convert.ToInt32(item["IdAmostra"]);
            obj.TipoAmostra = item["TipoAmostra"].ToString();
            obj.DataEntrada = item["DataCadastro"].ToString();
            obj.StatusAmostra = item["StatusAmostra"].ToString();
            obj.IdStatusAmostra = Convert.ToInt32(item["IdStatusAmostra"]);
            list.Add(obj);
        }

        return list;
    }

}