using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.Services;

public partial class Entrada_Entrada : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["SessionUser"].ToString() != string.Empty)
            {
                if (!IsPostBack)
                    CarregaPagina();
            }
            else
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

    private void CarregaPagina()
    {
        if (Session["SessionUser"].ToString() != "Gestor")
            hddIdUnidade.Value = Session["SessionIdUnidade"].ToString();

        hddInclusoes.Value = string.Empty;
        lblDataAtual.Text = DateTime.Now.ToShortDateString();
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
        ListCamaras = selecionaDados.ConsultaCamaras(idUnidade);

        return ListCamaras;
    }

    [WebMethod]
    public static List<ListItem> Prateleiras(int idCamara)
    {
        List<ListItem> ListPrateleiras = new List<ListItem>();

        SelecionaDados selecionaDados = new SelecionaDados();
        ListPrateleiras = selecionaDados.ConsultaPrateleiras(idCamara);

        return ListPrateleiras;
    }

    [WebMethod]
    public static List<ListItem> TipoAmostra()
    {
        List<ListItem> ListTipoAmostra = new List<ListItem>();

        SelecionaDados selecionaDados = new SelecionaDados();
        ListTipoAmostra = selecionaDados.ConsultaTipoAmostra();

        return ListTipoAmostra;
    }

    [WebMethod]
    public static string InsereAmostras(string amostrasInclusao)
    {
        #region Descrição dos valores contigos em aItens

        //aItens[0] = IdPrateleira
        //aItens[1] = Caixa
        //aItens[2] = IdGrupo
        //aItens[3] = IdTipoAmostra
        //aItens[4] = CodAmostra/IdAmostra

        #endregion

        InsereDados insereDados = new InsereDados();
        bool sucesso = false;

        string[] aInsercoes = amostrasInclusao.Split('|');

        for (int item = 0; item < aInsercoes.Length; item++)
        {
            if (!string.IsNullOrEmpty(aInsercoes[item]))
            {
                string[] aItens = aInsercoes[item].Split('_');

                int idPrateleira = Convert.ToInt32(aItens[0].ToString().Trim());
                string caixa = aItens[1].ToString().Trim();
                int idGrupo = Convert.ToInt32(aItens[2].ToString().Trim());
                int idTipoAmostra = Convert.ToInt32(aItens[3].ToString().Trim());
                int idAmostra = Convert.ToInt32(aItens[4].ToString().Trim());

                //insereDados.InsereAmostra(idGrupo, idAmostra, )
            }
        }

        return sucesso.ToString();
    }

    protected void btErro_Click(object sender, EventArgs e)
    {
        Session["ExcessaoDeErro"] = hddErro.Value;
        Response.Redirect("../Erro/Erro.aspx");
    }

}