using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.Services;

public partial class Acoes_Recepcao : System.Web.UI.Page
{
    SelecionaDados selecionaDados = new SelecionaDados();
    InsereDados insereDados = new InsereDados();


    protected void Page_Load(object sender, EventArgs e)
    {
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
      
    }

    protected void ddlCamaras_SelectedIndexChanged(object sender, EventArgs e)
    {
        lblCamara.Text = " - C&acirc;mara " + ddlCamaras.SelectedItem.Text;

        divCamara.Visible = false;
        divPrateleira.Visible = true;
    }

    protected void btPrateleira_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(txtPrateleira.Text))
        {
            MostraRetorno();
        }
        else
        {
            divPrateleira.Visible = false;
            divInsercoes.Visible = true;
        }
    }

    protected void btAmostra_Click(object sender, EventArgs e)
    {
        //if (string.IsNullOrEmpty(txtAcao.Text))
        //{
        //    divRetorno.Visible = true;
        //    lblRetorno.Text = "Por favor, preencha o campo corretamenta para prosseguir";
        //}
        //else
        //{
        //    ConfiguraPagina(txtAcao.Text.Trim());
        //    txtAcao.Text = string.Empty;
        //}
    }

    public void ConfiguraPagina(string tipoInsercao)
    {
        hddInclusoes.Value = tipoInsercao;

        lblCamara.Text = " - C&acirc;mara " + hddInclusoes.Value;        

    }

    public void MostraRetorno()
    {
        divRetorno.Visible = true;
        lblRetorno.Text = "Por favor, preencha o campo corretamenta para prosseguir";
    }

    public void RetornaPaginaErro(string erro)
    {
        Session["ExcessaoDeErro"] = erro.Trim();
        Response.Redirect("../Erro/Erro.aspx");
    }
}