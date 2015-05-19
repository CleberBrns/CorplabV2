using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.Services;

public partial class Acoes_Saida : System.Web.UI.Page
{
    SelecionaDados selecionaDados = new SelecionaDados();
    InsereDados insereDados = new InsereDados();

    protected void Page_Load(object sender, EventArgs e)
    {
        txtAmostra.Focus();

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
                    RetornaPaginaErro("Sessão perdida. Por favor, faça o login novamente.");
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
        hddIdUnidade.Value = Session["SessionIdUnidade"].ToString();
        hddIdUsuario.Value = Session["SessionIdUsuario"].ToString();

        txtAmostra.Focus();
    }

    protected void btAmostra_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(txtAmostra.Text))
        {
            MostraRetorno(string.Empty);
        }
        else
        {
            try
            {
                bool formatoCorreto = ValidaCampoAmostra(txtAmostra.Text.Trim());

                if (formatoCorreto)
                {
                    InsereAmostra(txtAmostra.Text.Trim(), string.Empty);
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
                MostraRetorno("Ocorreu um erro ao tentar executar a Saída da amostra; " + txtAmostra.Text.Trim());
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

    private void InsereAmostra(string sCodAmostra, string caixa)
    {
        try
        {
            divProcessando.Visible = true;
            divInsercoes.Visible = false;

            long codAmostra = Convert.ToInt64(sCodAmostra);

            DataTable dtVerificaAmostra = selecionaDados.ConsultaAmostra(codAmostra);

            if (dtVerificaAmostra.Rows.Count > 0)
            {
                DataTable dtStatusAmos = selecionaDados.ConsultaStatusAmostra(codAmostra);
                string statusAmostra = string.Empty;

                if (dtStatusAmos.Rows.Count > 0)
                {
                    statusAmostra = dtStatusAmos.DefaultView[0]["UltimaAlteracao"].ToString();
                }

                if (statusAmostra != string.Empty && statusAmostra.ToLower() == "descarte")
                {
                    MostraRetornoErro("A amostra " + sCodAmostra + " foi descartada e já não pode passar por qualquer nova Ação.");
                    divProcessando.Visible = false;
                    txtAmostra.Text = string.Empty;
                    txtAmostra.Focus();
                }
                else
                {
                    insereDados.InsereAmostraSaida(Convert.ToInt32(hddIdPrateleria.Value.Trim()), Convert.ToInt32(hddIdUsuario.Value.Trim()), codAmostra, caixa);

                    MostraRetorno("Saída da amostra executada com sucesso.");

                    imgOk.Visible = true;
                    imgErro.Visible = false;

                    txtAmostra.Text = string.Empty;
                    divProcessando.Visible = false;
                    divInsercoes.Visible = true;
                }
            }
            else
            {
                MostraRetornoErro("A amostra " + sCodAmostra + " ainda não foi cadastrada, <br /> A mesma deve passar pela a ação de Recepção." +
                    "<br /> Qualquer dúvida, por favor, consulte o administrador do sistema");
                txtAmostra.Text = string.Empty;
                txtAmostra.Focus();
            }
        }
        catch (Exception ex)
        {
            MostraRetornoErro("Ocorreu um erro ao tentar executar a Saída da amostra. <br /> Por favor, consulte o administrador do sistema");
        }

    }

    private void MostraRetornoErro(string mensagem)
    {
        divProcessando.Visible = false;
        divInsercoes.Visible = true;

        MostraRetorno(mensagem);

        imgOk.Visible = false;
        imgErro.Visible = true;
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