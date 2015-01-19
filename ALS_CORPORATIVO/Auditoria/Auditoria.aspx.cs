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
        Auxiliar auxiliar = new Auxiliar();
        DataTable dtAmostras = auxiliar.RetornaAmostraTeste();

        try
        {
            if (Session["SessionUser"].ToString() == string.Empty)
            {
                Page.ClientScript.RegisterStartupScript(GetType(), "SemSessao", "alert('Perdeu a sessão!');", true);
                Response.Redirect("../Login/Login.aspx");
            }
            else
            {
                if (Session["SessionUser"].ToString() != "Gestor")
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
    public static List<Auxiliar.AmostraXGrupo> ConsultaAmostrasGrupo(string idPrateleira)
    {
        Auxiliar auxiliar = new Auxiliar();

        DataTable dtAmostras = auxiliar.RetornaAmostraTeste();

        dtAmostras.DefaultView.RowFilter = "Prateleira = " + idPrateleira + "";
        dtAmostras = dtAmostras.DefaultView.ToTable();

        List<Auxiliar.AmostraXGrupo> list = new List<Auxiliar.AmostraXGrupo>();
        Auxiliar.AmostraXGrupo obj = new Auxiliar.AmostraXGrupo();
        foreach (DataRow item in dtAmostras.Rows)
        {
            obj = new Auxiliar.AmostraXGrupo();
            obj.IdPrateleira = item["IdPrateleira"].ToString();
            obj.Prateleira = item["Prateleira"].ToString();
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

    [WebMethod]
    public static List<ListItem> Unidades(string sIdUnidade)
    {
        List<ListItem> ListUnidades = new List<ListItem>();

        SelecionaDados selecionaDados = new SelecionaDados();
        DataTable dtUnidades = selecionaDados.ConsultaTodasUnidades();

        if (sIdUnidade.Trim() != "0")
            dtUnidades.DefaultView.RowFilter = "IdUnidade = " + sIdUnidade.Trim() + "";

        dtUnidades = dtUnidades.DefaultView.ToTable();

        if (dtUnidades.Rows.Count > 0)
        {
            foreach (DataRow item in dtUnidades.Rows)
                ListUnidades.Add(new ListItem(item["Unidade"].ToString(), item["IdUnidade"].ToString()));
        }

        return ListUnidades;
    }

    [WebMethod]
    public static List<ListItem> Camaras(int idUnidade)
    {
        List<ListItem> ListCamaras = new List<ListItem>();

        SelecionaDados selecionaDados = new SelecionaDados();
        DataTable dtCamaras = selecionaDados.ConsultaCamaras(idUnidade);

        if (dtCamaras.Rows.Count > 0)
        {
            foreach (DataRow item in dtCamaras.Rows)
                ListCamaras.Add(new ListItem(item["NomeCamara"].ToString(), item["IdCamara"].ToString()));
        }

        return ListCamaras;
    }

    [WebMethod]
    public static List<ListItem> Prateleiras(int idCamara)
    {
        List<ListItem> ListPrateleiras = new List<ListItem>();

        SelecionaDados selecionaDados = new SelecionaDados();
        DataTable dtPrateleiras = selecionaDados.ConsultaPrateleiras(idCamara);

        if (dtPrateleiras.Rows.Count > 0)
        {
            foreach (DataRow item in dtPrateleiras.Rows)
                ListPrateleiras.Add(new ListItem(item["Prateleira"].ToString(), item["IdPrateleira"].ToString()));
        }

        return ListPrateleiras;
    }

}