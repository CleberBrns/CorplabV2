﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.Services;

public partial class Acoes_Entrada : System.Web.UI.Page
{
    SelecionaDados selecionaDados = new SelecionaDados();
    InsereDados insereDados = new InsereDados();


    protected void Page_Load(object sender, EventArgs e)
    {
        txtAmostra.Focus();
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
            divPrateleira.Visible = true;
            txtPrateleira.Focus();
        }

        if (string.IsNullOrEmpty(txtPrateleira.Text))
        {
            btNovaPrateleira.Visible = false;
        }
        else
        {
            btNovaPrateleira.Visible = true;
        }

        ExibiLinkInicial();
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
            divInsercoes.Visible = true;
            btNovaPrateleira.Visible = true;

            ExibiLinkInicial();
        }
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
                    MostraRetorno("Entrada de caixa executada com sucesso.");
                }
                else
                {
                    MostraRetorno("Entrada de amostra executada com sucesso.");
                }

                divProcessando.Visible = true;
                divInsercoes.Visible = false;
               
                imgOk.Visible = true;
                imgErro.Visible = false;

                txtAmostra.Text = string.Empty;
                divProcessando.Visible = false;
                divInsercoes.Visible = true;
            }
            catch (Exception ex)
            {
                MostraRetorno("Ocorreu um erro ao tentar processar o objeto; " + txtAmostra.Text.Trim());
                imgErro.Visible = true;
                imgOk.Visible = false;
            }

        }
    }

    protected void btNovaPrateleira_Click(object sender, EventArgs e)
    {
        ckbRetiraCaixa.Checked = false;        

        txtPrateleira.Text = string.Empty;
        lblPrateleira.Text = string.Empty;
        txtPrateleira.Focus();

        divRetorno.Visible = false;
        divInsercoes.Visible = false;
        divInicio.Visible = false;
        divPrateleira.Visible = true;
    }

    protected void ckbRetiraCaixa_CheckedChanged(object sender, EventArgs e)
    {
        divRetorno.Visible = false;
        if (ckbRetiraCaixa.Checked)
        {
            lblTipoSaida.Text = "Caixa a entrar";
        }
        else
        {
            lblTipoSaida.Text = "Amostra a entrar";
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
        Response.Redirect("../Acoes/Entrada.aspx");
    }
}