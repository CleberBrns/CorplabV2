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
    SelecionaDados selecionaDados = new SelecionaDados();
    InsereDados insereDados = new InsereDados();


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
        catch (Exception ex)
        {
            RetornaPaginaErro(ex.ToString());
        }

    }

    private void CarregaPagina()
    {
        if (Session["SessionUser"].ToString() != "Gestor")
            hddIdUnidade.Value = Session["SessionIdUnidade"].ToString();

        hddInclusoes.Value = string.Empty;
        lblDataAtual.Text = DateTime.Now.ToShortDateString();

        CarregaDrodDowns();
    }

    private void CarregaDrodDowns()
    {
        DataTable tipoAmostra = selecionaDados.ConsultaTipoAmostra();

        ddlTipoAmostra.DataSource = tipoAmostra;
        ddlTipoAmostra.DataTextField = "TipoAmostra";
        ddlTipoAmostra.DataValueField = "IdTipoAmostra";
        ddlTipoAmostra.DataBind();

        DataTable dtUnidades = selecionaDados.ConsultaTodasUnidades();

        if (dtUnidades.Rows.Count > 0)
        {
            if (hddIdUnidade.Value.Trim() != "0")
                dtUnidades.DefaultView.RowFilter = "IdUnidade = " + hddIdUnidade.Value.Trim() + "";

            dtUnidades = dtUnidades.DefaultView.ToTable();

            ddlUnidade.DataSource = dtUnidades;
            ddlUnidade.DataTextField = "Unidade";
            ddlUnidade.DataValueField = "IdUnidade";
            ddlUnidade.DataBind();

            if (dtUnidades.Rows.Count == 1)
                divUnidade.Visible = false;

            CarregaDropCamaras(Convert.ToInt32(dtUnidades.DefaultView[0]["IdUnidade"].ToString()));
        }
        else
        {
            RetornaPaginaErro("Não existem unidades cadastradas.");
        }

    }

    protected void ddlUnidade_SelectedIndexChanged(object sender, EventArgs e)
    {
        int idUnidadeSel = Convert.ToInt32(ddlUnidade.SelectedItem.Value);
        CarregaDropCamaras(idUnidadeSel);
    }

    private void CarregaDropCamaras(int idUnidade)
    {
        DataTable tdCamaras = selecionaDados.ConsultaCamaras(idUnidade);
        ddlCamaras.Enabled = true;

        ddlCamaras.DataSource = tdCamaras;
        ddlCamaras.DataTextField = "NomeCamara";
        ddlCamaras.DataValueField = "IdCamara";
        ddlCamaras.DataBind();

        if (tdCamaras.Rows.Count == 1)
            divCamara.Visible = false;

        int idCamaraSel = Convert.ToInt32(ddlCamaras.SelectedItem.Value);
        CarregaDropPrateleiras(idCamaraSel);
    }

    protected void ddlCamaras_SelectedIndexChanged(object sender, EventArgs e)
    {
        int idCamaraSel = Convert.ToInt32(ddlCamaras.SelectedItem.Value);
        CarregaDropPrateleiras(idCamaraSel);
    }

    private void CarregaDropPrateleiras(int idCamara)
    {
        DataTable dtPrateleiras = selecionaDados.ConsultaPrateleiras(idCamara);

        ddlPrateleira.Enabled = true;
        ddlPrateleira.DataSource = dtPrateleiras;
        ddlPrateleira.DataTextField = "Prateleira";
        ddlPrateleira.DataValueField = "IdPrateleira";
        ddlPrateleira.DataBind();
    }

    protected void btIncluir_Click(object sender, EventArgs e)
    {
        try
        {
            divProcessando.Visible = true;
            divPagina.Visible = false;

            insereDados.InsereAmostra(txtGrupo.Text.Trim(), Convert.ToInt32(txtAmostra.Value), string.Empty, Convert.ToInt32(ddlTipoAmostra.SelectedValue),
                Convert.ToInt32(ddlPrateleira.SelectedValue), txtCaixa.Text.Trim());

            txtAmostra.Value = string.Empty;
            divRetornoSaida.Attributes.Remove("class");

            divProcessando.Visible = false;
            divPagina.Visible = true;
        }
        catch (Exception ex) { RetornaPaginaErro(ex.ToString()); }

    }


    protected void btErro_Click(object sender, EventArgs e)
    {
        RetornaPaginaErro(hddErro.Value);
    }

    public void RetornaPaginaErro(string erro)
    {
        Session["ExcessaoDeErro"] = erro.Trim();
        Response.Redirect("../Erro/Erro.aspx");
    }

}