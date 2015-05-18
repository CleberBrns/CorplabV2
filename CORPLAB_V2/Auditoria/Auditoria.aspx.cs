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
                if (Session["SessionIdTipoAcesso"].ToString() != "1")
                {
                    RetornaPaginaErro("Você não possui permissões para acessar essa ferramenta.");
                }
                else
                {
                    if (Session["SessionUsuario"].ToString() != string.Empty)
                    {
                        if (!IsPostBack)
                            CarregaPagina();
                    }
                    else
                    {
                        RedirecionaLogin();
                    }
                }
            }
        }
        catch (Exception ex)
        {
            if (Session["SessionIdTipoAcesso"] == null)
            {
                RetornaPaginaErro("Sessão perdida. Por favor, faça o login novamente.");
            }
            else
            {
                RetornaPaginaErro(ex.ToString());
            }
        }
    }

    private void RedirecionaLogin()
    {
        Page.ClientScript.RegisterStartupScript(GetType(), "msgbox", "alert('Perdeu a sessão!');", true);
        Response.Redirect("../Login/Login.aspx");
    }

    private void CarregaPagina()
    {        

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
            DataTable dtInfoPrateleira = selecionaDados.ConsultaPrateleira(txtPrateleira.Text.Trim());

            if (dtInfoPrateleira.Rows.Count > 0)
            {
                lblPrateleira.Text = " - Prateleira " + txtPrateleira.Text.Trim();
                divPrateleira.Visible = false;

                hddIdPrateleira.Value = dtInfoPrateleira.DefaultView[0]["IdPrateleira"].ToString();

                hddCodPrateleira.Value = txtPrateleira.Text.Trim();
                MostraAuditoria(txtPrateleira.Text);

            }
            else
            {
                MostraRetorno("Não existem amostras cadastradas nessa prateleira.");
                imgErroAuditar.Visible = true;
                imgOkAuditar.Visible = false;
            }
        }
    }

    protected void btInicio_Click(object sender, EventArgs e)
    {
        CamposDefault();
        txtPrateleira.Focus();

        divRetornoAuditar.Visible = false;
        divBotaoAuditoria.Visible = false;
        btImprimir.Visible = false;
        divAuditoria.Visible = false;
        divInicio.Visible = false;
        divPrateleira.Visible = true;

    }

    protected void btImprimir_Click(object sender, EventArgs e)
    {
        txtAmostra.Focus();

        Session["SessionIdBusca"] = hddIdPrateleira.Value;
        Session["SessionTipoBusca"] = "0";
        Session["SessionPrateleira"] = hddCodPrateleira.Value;

        Response.Write("<script>window.open('../Auditoria/Impressao.aspx','_blank')</script");

    }

    protected void btAuditarAmostra_Click(object sender, EventArgs e)
    {
        try
        {
            divRetornoAuditar.Visible = true;

            if (!string.IsNullOrEmpty(txtAmostra.Text))
            {
                try
                {
                    bool formatoCorreto = ValidaCampoAmostra(txtAmostra.Text.Trim());

                    if (formatoCorreto)
                    {
                        divProcessando.Visible = true;

                        long codAmostra = Convert.ToInt64(txtAmostra.Text.Trim());

                        insereDados.InsereAmostraAuditoria(Convert.ToInt32(hddIdPrateleira.Value.Trim()),
                                                           Convert.ToInt32(Session["SessionIdUsuario"].ToString()), codAmostra);                                                           

                        divProcessando.Visible = false;
                        imgErroAuditar.Visible = false;
                        imgOkAuditar.Visible = true;
                        lblRetornoAuditar.Text = "Amostra " + txtAmostra.Text + " auditada com sucesso";
                        txtAmostra.Text = string.Empty;
                    }
                    else
                    {
                        MostraRetorno("O campo Amostra só aceita caracteres numéricos. <br /> Por favor, consulte o administrador do sistema.");
                        imgErroAuditar.Visible = true;
                        imgOkAuditar.Visible = false;
                    }

                }
                catch (Exception ex)
                {
                    divProcessando.Visible = false;
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

    private bool ValidaCampoAmostra(string codAmostra)
    {
        bool valido = false;

        try
        {
            int dCodAmostra = Convert.ToInt32(codAmostra.Trim());
            valido = true;
        }
        catch (Exception) { }//Continua false

        return valido;
    }

    private void MostraAuditoria(string codPrateleira)
    {
        DataTable dtAuditoria = CarregaInfoPrateleira(hddCodPrateleira.Value);

        if (dtAuditoria.Rows.Count > 0)
        {
            //divBotaoAuditoria.Visible = true;
            txtAmostra.Focus();
            divAuditoria.Visible = true;
            btImprimir.Visible = true;
            divInicio.Visible = true;

            rptAuditoria.DataSource = dtAuditoria;
            rptAuditoria.DataBind();
        }
        else
        {
            MostraRetorno("Não existem amostras cadastradas.");
            divInicio.Visible = true;
            imgErroAuditar.Visible = true;
            imgOkAuditar.Visible = false;
        }

    }

    private DataTable CarregaInfoPrateleira(string prateleira)
    {
        DataTable dtInfoPrateleira = new DataTable();

        dtInfoPrateleira.Columns.Add("CodAmostra");
        dtInfoPrateleira.Columns.Add("DataUsuarioRecepcao");
        dtInfoPrateleira.Columns.Add("Estante");
        dtInfoPrateleira.Columns.Add("Prateleira");
        dtInfoPrateleira.Columns.Add("Caixa");
        dtInfoPrateleira.Columns.Add("UltimaAlteracao");
        dtInfoPrateleira.Columns.Add("Auditado");

        DataTable dtPrateleiraAuditoria = selecionaDados.ConsultaPrateleiraAuditoria(hddCodPrateleira.Value);

        if (dtPrateleiraAuditoria.Rows.Count > 0)
        {
            foreach (DataRow item in dtPrateleiraAuditoria.Rows)
            {                
                dtInfoPrateleira.Rows.Add(item["CodAmostra"].ToString(),
                    ConfiguraUsuarioRecepcao(item["DataRecepcao"].ToString(), item["UsuarioRecepcao"].ToString()), item["Estante"].ToString(),
                    item["Prateleira"].ToString(), item["Caixa"].ToString(),
                    ConfiguraUltimaAlteracao(item["NomeUsuario"].ToString(), item["DataAtualizacao"].ToString(), item["Acao"].ToString()),
                    item["Auditado"].ToString());
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