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
            if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty(Session["SessionIdBusca"].ToString()) && !string.IsNullOrEmpty(Session["SessionTipoBusca"].ToString()) &&
                    !string.IsNullOrEmpty(Session["SessionCamara"].ToString()) && !string.IsNullOrEmpty(Session["SessionPrateleira"].ToString()))
                {
                    CarregaInfoConsulta(Session["SessionCamara"].ToString().Trim(), Session["SessionIdBusca"].ToString().Trim(),
                        Session["SessionTipoBusca"].ToString().Trim(), Session["SessionPrateleira"].ToString().Trim());
                }               
            }
        }
        catch (Exception)
        {
            RetornaPaginaErro("Perdeu a sessão. Faça o login novamente, por favor.");
        }
    }

    public void RetornaPaginaErro(string erro)
    {
        Session["ExcessaoDeErro"] = erro.Trim();
        Response.Redirect("../Erro/Erro.aspx");
    }

    private void CarregaInfoConsulta(string camara, string idBusca, string tipoBusca, string prateleira)
    {
        DataTable dtBusca = new DataTable();

        if (tipoBusca == "0")//Prateleira
        {
            lblCamara.Text = " - C&acirc;mara " + camara;
            lblPrateleira.Text = ", Prateleira " + prateleira;
            dtBusca = CarregaTabelaTeste();
        }
        else//Amostra
        {

        }

        CarregaRepeater(dtBusca);
    }

    private DataTable CarregaTabelaTeste()
    {
        DataTable dtInfoBusca = new DataTable();

        dtInfoBusca.Columns.Add("CodAmostra");
        dtInfoBusca.Columns.Add("DataRecepcao");
        dtInfoBusca.Columns.Add("UsuarioRecepcao");
        dtInfoBusca.Columns.Add("Estante");
        dtInfoBusca.Columns.Add("Prateleira");
        dtInfoBusca.Columns.Add("Caixa");
        dtInfoBusca.Columns.Add("UltimaAlteracao");
        dtInfoBusca.Columns.Add("Auditado");

        for (int i = 0; i < 20; i++)
        {
            dtInfoBusca.Rows.Add(3501 + i, DateTime.Now.ToShortDateString(), "David", "E0" + i, "P0" + i, VerificaCaixa(i), FormaHistorico(i), VerificaAudicao(i));
        }

        return dtInfoBusca;
    }

    private string VerificaCaixa(int numero)
    {
        string caixa = string.Empty;

        if (numero % 2 == 0)
            caixa = numero.ToString();

        return caixa;
    }

    private string VerificaAudicao(int testaPar)
    {
        string auditado = "Não";

        if (testaPar % 2 == 0)
            auditado = "Sim";

        return auditado;
    }

    public string FormaHistorico(int numero)
    {
        return "João - " + numero + "/04/2015 - Saída";
    }

    private void CarregaRepeater(DataTable dtBusca)
    {
        rptAuditoria.DataSource = dtBusca;
        rptAuditoria.DataBind();
    }



}