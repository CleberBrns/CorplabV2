using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Descarte_Descarte : System.Web.UI.Page
{
    SelecionaDados selecionaDados = new SelecionaDados();
    InsereDados insereDados = new InsereDados();
    AtualizaDados atualizaDados = new AtualizaDados();

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["SessionIdUnidade"].ToString() == string.Empty)
            {
                Page.ClientScript.RegisterStartupScript(GetType(), "SemSessao", "alert('Perdeu a sessão!');", true);
                Response.Redirect("../Login/Login.aspx");
            }
            else
            {
                hddIdUnidade.Value = Session["SessionIdUnidade"].ToString();
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

    public void RetornaPaginaErro(string erro)
    {
        Session["ExcessaoDeErro"] = erro.Trim();
        Response.Redirect("../Erro/Erro.aspx");
    }
}