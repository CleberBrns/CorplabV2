using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

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

        ddlTipoAmostra.Items.Insert(0, new ListItem("-- Selecione --", "0"));
        ddlTipoAmostra.Items.Insert(1, new ListItem("Vaio", "1"));
        ddlTipoAmostra.Items.Insert(2, new ListItem("Solo", "2"));
        ddlTipoAmostra.Items.Insert(3, new ListItem("Outros", "3"));


        ddlPrateleira.DataSource = CarregaPrateleiras();
        ddlPrateleira.DataTextField = "Prateleira";
        ddlPrateleira.DataValueField = "IdPrateleira";
        ddlPrateleira.DataBind();

        ddlPrateleira.Items.Insert(0, new ListItem("-- Selecione --", "0"));

    }

    private DataTable CarregaPrateleiras()
    {
        DataTable dtPrateleiras = new DataTable();
        dtPrateleiras.Columns.Add("IdPrateleira");
        dtPrateleiras.Columns.Add("Prateleira");

        string[] aAlfabeto = { "*", "a", "b", "c", "d", "e", "f", "g", "h", "i", "j" };

        for (int alfabeto = 1; alfabeto < aAlfabeto.Length; alfabeto++)
        {
            string sAlfabeto = aAlfabeto[alfabeto].ToString().ToUpper();
            for (int insercao = 1; insercao < 10; insercao++)
            {
                DataRow dRow = dtPrateleiras.NewRow();

                dRow["IdPrateleira"] = insercao;
                dRow["Prateleira"] = sAlfabeto + insercao;

                dtPrateleiras.Rows.Add(dRow);
            }
        }

        return dtPrateleiras;
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

}