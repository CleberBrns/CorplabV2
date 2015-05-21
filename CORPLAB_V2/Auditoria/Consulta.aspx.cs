using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.Services;

public partial class Auditoria_Consulta : System.Web.UI.Page
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
        if (Session["SessionIdTipoAcesso"].ToString() == "1")//Adm
        {
            btMenuPrincial.Visible = true;
        }       
    }

    private void CamposDefault()
    {
        txtAmostra.Text = string.Empty;
        txtPrateleira.Text = string.Empty;
        lblRetorno.Text = string.Empty;
        lblBusca.Text = string.Empty;
    }

    protected void btInicio_Click(object sender, EventArgs e)
    {
        CamposDefault();
        divOpcoes.Visible = true;
        divInicio.Visible = false;       
        divAmostra.Visible = false;
        divPrateleira.Visible = false;
        divConsulta.Visible = false;
        divRetorno.Visible = false;
        btImprimir.Visible = false;
    }

    protected void btImprimir_Click(object sender, EventArgs e)
    {
        Session["SessionTipoImpressao"] = "Consulta";
        Session["SessionPrateleira"] = hddCodPrateleira.Value;
        Response.Write("<script>window.open('../Auditoria/Impressao.aspx','_blank')</script");

    }

    protected void btAmostra_Click(object sender, EventArgs e)
    {
        try
        {
            divRetorno.Visible = true;

            if (!string.IsNullOrEmpty(txtAmostra.Text))
            {
                try
                {
                    bool formatoCorreto = ValidaCampoAmostra(txtAmostra.Text.Trim());

                    if (formatoCorreto)
                    {
                        divProcessando.Visible = true;

                        long codAmostra = Convert.ToInt64(txtAmostra.Text.Trim());

                        MostraConsulta(txtAmostra.Text.Trim(), 1);

                        divOpcoes.Visible = false;
                        divInicio.Visible = true;
                        divProcessando.Visible = false;
                        txtAmostra.Text = string.Empty;
                    }
                    else
                    {
                        MostraRetorno("O campo Amostra só aceita caracteres numéricos. <br /> Por favor, consulte o administrador do sistema.");
                        imgErro.Visible = true;
                        imgOk.Visible = false;
                    }

                }
                catch (Exception ex)
                {
                    divProcessando.Visible = false;
                    imgErro.Visible = true;
                    imgOk.Visible = false;
                    lblRetorno.Text = ex.ToString();
                }

            }
            else
            {
                imgErro.Visible = true;
                imgOk.Visible = false;
                lblRetorno.Text = "Por favor, preencha o campo corretamente para prosseguir";
            }

        }
        catch (Exception ex)
        {
            RetornaPaginaErro(ex.ToString());
        }
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
                lblBusca.Text = " - Prateleira " + txtPrateleira.Text.Trim();
                divPrateleira.Visible = false;

                hddIdPrateleira.Value = dtInfoPrateleira.DefaultView[0]["IdPrateleira"].ToString();

                hddCodPrateleira.Value = txtPrateleira.Text.Trim();
                MostraConsulta(txtPrateleira.Text, 2);

                divOpcoes.Visible = false;
                divInicio.Visible = true;

            }
            else
            {
                MostraRetorno("A prateleira " + txtPrateleira.Text + " não foi está cadastrada!");
                txtPrateleira.Text = string.Empty;
                txtPrateleira.Focus();
                imgErro.Visible = true;
                imgOk.Visible = false;
            }
        }
    }

    private bool ValidaCampoAmostra(string codAmostra)
    {
        bool valido = false;

        try
        {
            long dCodAmostra = Convert.ToInt64(codAmostra.Trim());
            valido = true;
        }
        catch (Exception) { }//Continua false

        return valido;
    }

    private void MostraConsulta(string codConsulta, int idTipoConsulta)
    {
        DataTable dtConsulta = CarregaInfoConsulta(codConsulta, idTipoConsulta);

        if (dtConsulta.Rows.Count > 0)
        {
            divConsulta.Visible = true;            
            divInicio.Visible = true;           
            divOpcoes.Visible = false;
            divRetorno.Visible = false;
            lblRetorno.Text = string.Empty;

            if (idTipoConsulta == 2)
                btImprimir.Visible = true;

            rptConsulta.DataSource = dtConsulta;
            rptConsulta.DataBind();
        }
        else
        {
            if (idTipoConsulta == 1)
            {
                MostraRetorno("A amostra " + codConsulta + " não foi cadastrada!");
                txtAmostra.Text = string.Empty;
                txtAmostra.Focus();
                divAmostra.Visible = true;
            }
            else
            {
                MostraRetorno("Não existem amostras cadastradas na prateleira " + codConsulta + " !");
                txtPrateleira.Text = string.Empty;
                txtPrateleira.Focus();
                divPrateleira.Visible = true;
            }

            imgErro.Visible = true;
            imgOk.Visible = false;
        }

    }

    private DataTable CarregaInfoConsulta(string codConsulta, int idTipoConsulta)
    {
        DataTable dtInfoEstrutura = new DataTable();

        dtInfoEstrutura.Columns.Add("CodAmostra");
        dtInfoEstrutura.Columns.Add("DataUsuarioRecepcao");
        dtInfoEstrutura.Columns.Add("Estante");
        dtInfoEstrutura.Columns.Add("Prateleira");
        dtInfoEstrutura.Columns.Add("Caixa");
        dtInfoEstrutura.Columns.Add("UltimaAlteracao");
        dtInfoEstrutura.Columns.Add("Auditado");

        DataTable dtInfoConsulta = new DataTable();

        if (idTipoConsulta == 1)//Amostra
        {
            dtInfoConsulta = selecionaDados.ConsultaStatusAmostra(Convert.ToInt64(codConsulta));
        }
        else//Prateleira
        {
            dtInfoConsulta = selecionaDados.ConsultaPrateleiraAuditoria(codConsulta);
        }


        if (dtInfoConsulta.Rows.Count > 0)
        {
            foreach (DataRow item in dtInfoConsulta.Rows)
            {
                dtInfoEstrutura.Rows.Add(item["CodAmostra"].ToString(),
                    ConfiguraUsuarioRecepcao(item["DataRecepcao"].ToString(), item["UsuarioRecepcao"].ToString()), item["Estante"].ToString(),
                    item["Prateleira"].ToString(), item["Caixa"].ToString(),
                    ConfiguraUltimaAlteracao(item["NomeUsuario"].ToString(), item["DataAtualizacao"].ToString(), item["UltimaAlteracao"].ToString()),
                    item["Auditoria"].ToString());
            }
        }


        return dtInfoEstrutura;
    }

    private object ConfiguraUsuarioRecepcao(string dataRecepcao, string usuarioRecepcao)
    {
        return (usuarioRecepcao + " - " + Convert.ToDateTime(dataRecepcao).ToShortDateString() + " " + Convert.ToDateTime(dataRecepcao).ToShortTimeString());
    }

    private object ConfiguraUltimaAlteracao(string nomeUsuario, string dataAtualizacao, string acao)
    {
        if (!string.IsNullOrEmpty(dataAtualizacao))
        {
            string data = Convert.ToDateTime(dataAtualizacao).ToShortDateString() + " " +
            Convert.ToDateTime(dataAtualizacao).ToShortTimeString();

            return (nomeUsuario + " - " + data + " - " + acao);
        }
        else
        {
            return string.Empty;
        }
    }

    public void MostraRetorno(string mensagem)
    {
        divRetorno.Visible = true;

        if (string.IsNullOrEmpty(mensagem))
        {
            lblRetorno.Text = "Por favor, preencha o campo corretamente para prosseguir";
            imgErro.Visible = true;
            imgOk.Visible = false;
        }
        else
        {
            lblRetorno.Text = mensagem;
        }

    }

    protected void btDivAmostra_Click(object sender, EventArgs e)
    {
        txtAmostra.Focus();
        divAmostra.Visible = true;
        divInicio.Visible = true;
        divOpcoes.Visible = false;
    }
    protected void btDivPrateleira_Click(object sender, EventArgs e)
    {
        txtPrateleira.Focus();
        divPrateleira.Visible = true;
        divInicio.Visible = true;
        divOpcoes.Visible = false;
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

    protected void btMenuAcoes_Click(object sender, EventArgs e)
    {
        Response.Redirect("../Acoes/Acoes.aspx");
    }

}