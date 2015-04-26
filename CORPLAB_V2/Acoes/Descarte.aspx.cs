using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.Services;

public partial class Acoes_Descarte : System.Web.UI.Page
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

        hddInclusoes.Value = string.Empty;

        ExibiLinkInicial();

    }

    protected void ddlCamaras_SelectedIndexChanged(object sender, EventArgs e)
    {        
        if (ddlCamaras.SelectedValue != "0")
        {
            lblCamara.Text = " - C&acirc;mara " + ddlCamaras.SelectedItem.Text;

            divCamara.Visible = false;
            divAmostra.Visible = true;
            txtAmostra.Focus();
        }

        ExibiLinkInicial();
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
                if (ckbRetiraCaixa.Checked)
                {
                    MostraRetorno("Caixa descartada com sucesso.");
                }
                else
                {
                    MostraRetorno("Amostra descartada com sucesso.");
                }

                divProcessando.Visible = true;                
               
                imgOk.Visible = true;
                imgErro.Visible = false;

                txtAmostra.Text = string.Empty;
                divProcessando.Visible = false;               
            }
            catch (Exception ex)
            {
                MostraRetorno("Ocorreu um erro ao tentar processar o objeto; " + txtAmostra.Text.Trim());
                imgErro.Visible = true;
                imgOk.Visible = false;
            }

        }
    }

    protected void ckbRetiraCaixa_CheckedChanged(object sender, EventArgs e)
    {
        divRetorno.Visible = false;
        if (ckbRetiraCaixa.Checked)
        {
            lblTipoSaida.Text = "Caixa a descartar";
        }
        else
        {
            lblTipoSaida.Text = "Amostra a descartar";
        }
       
    }

    public void ConfiguraPagina(string tipoInsercao)
    {
        hddInclusoes.Value = tipoInsercao;

        lblCamara.Text = " - C&acirc;mara " + hddInclusoes.Value;

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

    private void ExibiLinkInicial()
    {
        if (!string.IsNullOrEmpty(lblCamara.Text))
        {
            divInicio.Visible = true;
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

    protected void btInicio_Click(object sender, EventArgs e)
    {
        Response.Redirect("../Acoes/Descarte.aspx");
    }
}