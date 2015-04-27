using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.Services;

public partial class Auditoria_Auditoria : System.Web.UI.Page
{
    SelecionaDados selecionaDados = new SelecionaDados();
    InsereDados insereDados = new InsereDados();


    protected void Page_Load(object sender, EventArgs e)
    {
        txtPrateleira.Focus();

        try
        {
            if (!IsPostBack)
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

    }

    protected void ddlCamaras_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlCamaras.SelectedValue != "0")
        {
            lblCamara.Text = " - C&acirc;mara " + ddlCamaras.SelectedItem.Text;

            CamposDefault();

            divRetornoAuditar.Visible = false;
            divBotaoAuditoria.Visible = false;
            btNovaPrateleira.Visible = false;
            divCamara.Visible = false;
            divInicio.Visible = true;
            divPrateleira.Visible = true;
            txtPrateleira.Focus();
        }
    }

    private void CamposDefault()
    {
        txtAmostra.Text = string.Empty;
        txtPrateleira.Text = string.Empty;
    }

    protected void btPrateleira_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(txtPrateleira.Text))
        {
            MostraRetorno(string.Empty);
        }
        else
        {
            lblPrateleira.Text = ", Prateleira " + txtPrateleira.Text.Trim();
            divPrateleira.Visible = false;
            btNovaPrateleira.Visible = true;

            hddIdPrateleira.Value = txtPrateleira.Text.Trim();
            MostraAuditoria(txtPrateleira.Text);
        }
    }

    protected void btNovaPrateleira_Click(object sender, EventArgs e)
    {
        CamposDefault();
        txtPrateleira.Focus();

        divRetornoAuditar.Visible = false;
        divBotaoAuditoria.Visible = false;
        divAuditoria.Visible = false;
        divCamara.Visible = false;
        btImprimir.Visible = false;
        btNovaPrateleira.Visible = false;
        divPrateleira.Visible = true;
        divInicio.Visible = true;

    }

    protected void btInicio_Click(object sender, EventArgs e)
    {
        CamposDefault();
        txtPrateleira.Focus();

        ddlCamaras.SelectedValue = "0";

        divRetornoAuditar.Visible = false;
        divBotaoAuditoria.Visible = false;
        btImprimir.Visible = false;
        divAuditoria.Visible = false;
        divPrateleira.Visible = false;
        divInicio.Visible = false;
        divCamara.Visible = true;
    }

    protected void btImprimir_Click(object sender, EventArgs e)
    {
        txtAmostra.Focus();

        Session["SessionIdBusca"] = txtPrateleira.Text;
        Session["SessionTipoBusca"] = "0";
        Session["SessionCamara"] = ddlCamaras.SelectedItem;
        Session["SessionPrateleira"] = txtPrateleira.Text;

        Response.Write("<script>window.open('../Auditoria/Impressao.aspx','_blank')</script");
             
    }

    protected void btAuditarAmostra_Click(object sender, EventArgs e)
    {
        try
        {
            divRetornoAuditar.Visible = true;

            if (!string.IsNullOrEmpty(txtAmostra.Text))
            {
                if (true)
                {
                    imgErroAuditar.Visible = false;
                    imgOkAuditar.Visible = true;
                    lblRetornoAuditar.Text = "Amostra " + txtAmostra.Text + " auditada com sucesso";
                    txtAmostra.Text = string.Empty;
                }
                else
                {
                    imgErroAuditar.Visible = true;
                    imgOkAuditar.Visible = false;
                    lblRetornoAuditar.Text = "Ocorreu um erro ao aditar a amostra";
                }
            }
            else
            {
                imgErroAuditar.Visible = true;
                imgOkAuditar.Visible = false;
                lblRetornoAuditar.Text = "Por favor, preencha o campo corretamente para prosseguir";
            }

            MostraAuditoria(hddIdPrateleira.Value);
        }
        catch (Exception ex)
        {

            throw;
        }
    }

    private void MostraAuditoria(string idPrateleira)
    {
        DataTable dtAuditoria = CarregaInfoPrateleira();

        if (dtAuditoria.Rows.Count > 0)
        {
            divBotaoAuditoria.Visible = true;
            txtAmostra.Focus();
            divAuditoria.Visible = true;
            btImprimir.Visible = true;

            rptAuditoria.DataSource = dtAuditoria;
            rptAuditoria.DataBind();
        }

    }

    private DataTable CarregaInfoPrateleira()
    {
        DataTable dtInfoPrateleira = new DataTable();

        dtInfoPrateleira.Columns.Add("CodAmostra");
        dtInfoPrateleira.Columns.Add("DataRecepcao");
        dtInfoPrateleira.Columns.Add("UsuarioRecepcao");
        dtInfoPrateleira.Columns.Add("Estante");
        dtInfoPrateleira.Columns.Add("Prateleira");
        dtInfoPrateleira.Columns.Add("Caixa");
        dtInfoPrateleira.Columns.Add("UltimaAlteracao");
        dtInfoPrateleira.Columns.Add("Auditado");

        for (int i = 0; i < 20; i++)
        {
            dtInfoPrateleira.Rows.Add(3501 + i, DateTime.Now.ToShortDateString(), "David", "E0" + i, "P0" + i, VerificaCaixa(i), FormaHistorico(i), VerificaAudicao(i));
        }

        return dtInfoPrateleira;
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

    public void MostraRetorno(string mensagem)
    {
        divRetornoAuditar.Visible = true;

        if (string.IsNullOrEmpty(mensagem))
        {
            lblRetornoAuditar.Text = "Por favor, preencha o campo corretamente para prosseguir";
            imgErroAuditar.Visible = true;
            imgOkAuditar.Visible = false;
        }
        else
        {
            lblRetornoAuditar.Text = mensagem;
        }

    }

    public void RetornaPaginaErro(string erro)
    {
        Session["ExcessaoDeErro"] = erro.Trim();
        Response.Redirect("../Erro/Erro.aspx");
    }

    protected void btMenuPrincipal_Click(object sender, EventArgs e)
    {
        Response.Redirect("../Home/Home.aspx");
    }
}