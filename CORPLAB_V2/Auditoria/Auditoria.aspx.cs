﻿using System;
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
        lblPrateleira.Text = string.Empty;
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
                DataTable dtStatusPrateleira = selecionaDados.ConsultaAmostraAuditoriaPrateleira(txtPrateleira.Text.Trim());
                if (dtStatusPrateleira.Rows.Count > 0)
                {
                    lblPrateleira.Text = " - Prateleira " + txtPrateleira.Text.Trim();
                    divPrateleira.Visible = false;

                    hddIdPrateleira.Value = dtInfoPrateleira.DefaultView[0]["IdPrateleira"].ToString();
                    hddCodPrateleira.Value = txtPrateleira.Text.Trim();

                    divInicio.Visible = true;
                    divAmostraAuditoria.Visible = true;
                    txtAmostra.Focus();
                    //MostraAuditoria(txtPrateleira.Text);                 
                }
                else
                {
                    MostraRetorno("Não existem amostras cadastradas nessa prateleira.");
                    txtPrateleira.Text = string.Empty;
                    txtPrateleira.Focus();
                    imgErroAuditar.Visible = true;
                    imgOkAuditar.Visible = false;
                }
            }
            else
            {
                MostraRetorno("Prateleira não cadastrada. <br/> Favor consultar o Administrador do Sistema.");
                txtPrateleira.Text = string.Empty;
                txtPrateleira.Focus();
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
        divAmostraAuditoria.Visible = false;
        btImprimir.Visible = false;
        divAuditoria.Visible = false;
        divInicio.Visible = false;
        divPrateleira.Visible = true;

    }

    protected void btAuditarAmostra_Click(object sender, EventArgs e)
    {
        try
        {
            divRetornoAuditar.Visible = false;
            lblRetornoAuditar.Text = string.Empty;

            if (!string.IsNullOrEmpty(txtAmostra.Text))
            {
                try
                {
                    bool formatoCorreto = ValidaCampoAmostra(txtAmostra.Text.Trim());

                    if (formatoCorreto)
                    {
                        divProcessando.Visible = true;

                        long codAmostra = Convert.ToInt64(txtAmostra.Text.Trim());

                        DataTable dtStatusAmos = selecionaDados.ConsultaStatusAmostra(codAmostra);

                        if (dtStatusAmos.Rows.Count > 0)
                        {
                            string statusAmostra = string.Empty;
                            string prateleiraAmostra = string.Empty;

                            statusAmostra = dtStatusAmos.DefaultView[0]["UltimaAlteracao"].ToString();
                            prateleiraAmostra = dtStatusAmos.DefaultView[0]["Prateleira"].ToString();

                            if (statusAmostra != string.Empty && statusAmostra.ToLower() == "descarte")
                            {
                                MostraRetorno("A amostra " + codAmostra + " foi descartada e já não pode passar por qualquer nova Ação.");
                                divProcessando.Visible = false;
                                imgErroAuditar.Visible = true;
                                imgOkAuditar.Visible = false;
                                txtAmostra.Text = string.Empty;
                                txtAmostra.Focus();
                            }
                            else if (statusAmostra != string.Empty && statusAmostra.ToLower() == "saída")
                            {
                                MostraRetorno("A amostra " + codAmostra + " possui status de Saída <br/> e não consta na prateleira.");
                                divProcessando.Visible = false;
                                imgErroAuditar.Visible = true;
                                imgOkAuditar.Visible = false;
                                txtAmostra.Text = string.Empty;
                                txtAmostra.Focus();
                            }
                            else
                            {
                                //insereDados.InsereAmostraAuditoria(Convert.ToInt32(hddIdPrateleira.Value.Trim()),
                                //                                                          Convert.ToInt32(Session["SessionIdUsuario"].ToString()), codAmostra);

                                if (hddCodPrateleira.Value.ToLower() == prateleiraAmostra.ToLower())
                                {
                                    MostraRetorno("A amostra " + codAmostra + " consta na praleleira.");
                                    divProcessando.Visible = false;
                                    imgErroAuditar.Visible = false;
                                    divRetornoAuditar.Visible = true;
                                    imgOkAuditar.Visible = true;
                                    //lblRetornoAuditar.Text = "Amostra " + txtAmostra.Text + " auditada com sucesso";
                                    txtAmostra.Text = string.Empty;
                                }
                                else if (!string.IsNullOrEmpty(prateleiraAmostra))
                                {
                                    MostraRetorno("A amostra " + codAmostra + " não consta na praleleira.");
                                    divProcessando.Visible = false;
                                    imgErroAuditar.Visible = true;
                                    imgOkAuditar.Visible = false;
                                    txtAmostra.Text = string.Empty;
                                    txtAmostra.Focus();
                                }
                            }
                        }
                        else
                        {
                            MostraRetorno("A amostra " + codAmostra + " ainda não foi cadastrada, <br /> A mesma deve passar pela a ação de Recepção." +
                                          "<br /> Qualquer dúvida, por favor, consulte o administrador do sistema");
                            divProcessando.Visible = false;
                            imgErroAuditar.Visible = true;
                            imgOkAuditar.Visible = false;
                            txtAmostra.Text = string.Empty;
                            txtAmostra.Focus();
                        }
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
                    lblRetornoAuditar.Text = "Ocorreu um erro ao auditar a amostra";
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
            long dCodAmostra = Convert.ToInt64(codAmostra.Trim());
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
            divAmostraAuditoria.Visible = true;
            txtAmostra.Focus();
            //divAuditoria.Visible = true;
            //btImprimir.Visible = true;
            divInicio.Visible = true;

            Session["SessionTipoImpressao"] = "Auditoria";
            Session["SessionPrateleira"] = hddCodPrateleira.Value;

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
                    ConfiguraUltimaAlteracao(item["NomeUsuario"].ToString(), item["DataAtualizacao"].ToString(), item["UltimaAlteracao"].ToString()),
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

    protected void btMenuAcoes_Click(object sender, EventArgs e)
    {
        Response.Redirect("../Acoes/Acoes.aspx");
    }
}