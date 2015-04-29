using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.Services;

public partial class Auditoria_Busca : System.Web.UI.Page
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
            RetornaPaginaErro("Perdeu a sessão. Faça o login novamente, por favor.");
        }

    }

    private void CarregaPagina()
    {
        if (Session["SessionUser"].ToString() != "Gestor")
            hddIdUnidade.Value = Session["SessionIdUnidade"].ToString();

        hddInclusoes.Value = string.Empty;

    }

    protected void ddlCamaras_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlCamaras.SelectedValue != "0")
        {
            lblCamara.Text = " - C&acirc;mara " + ddlCamaras.SelectedItem.Text;

            divCamara.Visible = false;
            divPrateleira.Visible = true;
            txtPrateleira.Focus();
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
            lblPrateleira.Text = ", Prateleira " + txtPrateleira.Text.Trim();

            divPrateleira.Visible = false;          
        }
    }

    protected void btNovaPrateleira_Click(object sender, EventArgs e)
    {
        txtPrateleira.Text = string.Empty;
        lblPrateleira.Text = string.Empty;
        txtPrateleira.Focus();

        divRetorno.Visible = false;
        divPrateleira.Visible = true;
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

    public void RetornaPaginaErro(string erro)
    {
        Session["ExcessaoDeErro"] = erro.Trim();
        Response.Redirect("../Erro/Erro.aspx");
    }

}