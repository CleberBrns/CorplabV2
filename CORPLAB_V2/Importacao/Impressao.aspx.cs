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
    SelecionaDados selecionaDados = new SelecionaDados();

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty(Session["SessionIdBusca"].ToString()) && !string.IsNullOrEmpty(Session["SessionTipoBusca"].ToString()) &&
                    !string.IsNullOrEmpty(Session["SessionPrateleira"].ToString()))
                {
                    CarregaInfoConsulta(Session["SessionIdBusca"].ToString().Trim(),
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

    private void CarregaInfoConsulta(string idBusca, string tipoBusca, string prateleira)
    {
        DataTable dtBusca = new DataTable();

        if (tipoBusca == "0")//Prateleira
        {            
            lblPrateleira.Text = " - Prateleira " + prateleira;
            dtBusca = CarregaInfoPrateleira(idBusca);
        }
        else//Amostra
        {

        }

        CarregaRepeater(dtBusca);
    }

    private DataTable CarregaInfoPrateleira(string codPrateleira)
    {
        DataTable dtInfoPrateleira = new DataTable();

        //int idPrateleira = Convert.ToInt32(codPrateleira);

        dtInfoPrateleira.Columns.Add("CodAmostra");
        dtInfoPrateleira.Columns.Add("DataUsuarioRecepcao");
        dtInfoPrateleira.Columns.Add("Estante");
        dtInfoPrateleira.Columns.Add("Prateleira");
        dtInfoPrateleira.Columns.Add("Caixa");
        dtInfoPrateleira.Columns.Add("UltimaAlteracao");
        dtInfoPrateleira.Columns.Add("Auditado");

        DataTable dtPrateleiraAuditoria = selecionaDados.ConsultaPrateleiraAuditoria(codPrateleira);

        if (dtPrateleiraAuditoria.Rows.Count > 0)
        {
            foreach (DataRow item in dtPrateleiraAuditoria.Rows)
            {
                dtInfoPrateleira.Rows.Add(item["CodAmostra"].ToString(),
                    ConfiguraUsuarioRecepcao(item["DataRecepcao"].ToString(), item["UsuarioRecepcao"].ToString()), item["Estante"].ToString(),
                    item["Prateleira"].ToString(), item["Caixa"].ToString(),
                    ConfiguraUltimaAlteracao(item["NomeUsuario"].ToString(), item["DataAtualizacao"].ToString(), item["Acao"].ToString()),
                    item["Auditoria"].ToString());
            }
        }

        return dtInfoPrateleira;
    }

    private object ConfiguraUsuarioRecepcao(string dataRecepcao, string usuarioRecepcao)
    {
        return (usuarioRecepcao + " - " + Convert.ToDateTime(dataRecepcao).ToShortDateString() + " " + Convert.ToDateTime(dataRecepcao).ToShortTimeString());
    }

    private object ConfiguraUltimaAlteracao(string nomeUsuario, string dataAtualizacao, string acao)
    {
        return (nomeUsuario + " - " + Convert.ToDateTime(dataAtualizacao).ToShortDateString() + " " +
            Convert.ToDateTime(dataAtualizacao).ToShortTimeString() + " - " + acao);
    }

    private void CarregaRepeater(DataTable dtBusca)
    {
        rptAuditoria.DataSource = dtBusca;
        rptAuditoria.DataBind();
    }



}