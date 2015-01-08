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
        if (!IsPostBack)
            CarregaPagina();
    }

    private void CarregaPagina()
    {
        hddInclusoes.Value = string.Empty;
        lblDataAtual.Text = DateTime.Now.ToShortDateString();
    }

    [WebMethod]
    public static List<ListItem> Unidades()
    {
        List<ListItem> ListUnidades = new List<ListItem>();

        SelecionaDados selecionaDados = new SelecionaDados();
        DataTable dtUnidades = selecionaDados.ConsultaTodasUnidades();

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
    public static bool InsereAmostras(string amostrasInclusao)
    {
        bool sucesso = false;

        string[] aInsercoes = amostrasInclusao.Split('|');

        for (int item = 0; item < aInsercoes.Length; item++)
        {
            if (!string.IsNullOrEmpty(aInsercoes[item]))
            {
                string[] aItens = aInsercoes[item].Split('_');
            }
        }

        return sucesso;
    }

    protected void btFinalizar_Click(object sender, EventArgs e)
    {
        if (hddInclusoes.Value != string.Empty)
        {
            InsereDadosSalvos(hddInclusoes.Value);
            LimparCampos();
        }

    }

    private void LimparCampos()
    {
        hddInclusoes.Value = string.Empty;
        ddlPrateleira.SelectedValue = "0";
        txtCaixa.Text = string.Empty;
        txtGrupo.Text = string.Empty;
        ddlTipoAmostra.SelectedValue = "0";
        txtAmostra.Value = string.Empty;
    }

    private void InsereDadosSalvos(string insercoes)
    {
        try
        {
            divPagina.Visible = false;
            divProcessando.Visible = true;

            string[] aInsercoes = insercoes.Split('|');

            for (int item = 0; item < aInsercoes.Length; item++)
            {
                if (!string.IsNullOrEmpty(aInsercoes[item]))
                {
                    string[] aItens = aInsercoes[item].Split('_');
                }
            }

            divPagina.Visible = true;
            divProcessando.Visible = false;

            string jscript = "$(function() {$('#dialog-sucesso').dialog('open')});";
            ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "Concluí", jscript, true);          
                        
        }
        catch (Exception ex)
        {
            Session["ExcessaoDeErro"] = ex.ToString();
            Response.Redirect("../Erro/Erro.aspx");
        }
        
    }

    protected void btErro_Click(object sender, EventArgs e)
    {
        Session["ExcessaoDeErro"] = hddErro.Value;
        Response.Redirect("../Erro/Erro.aspx");
    }

}