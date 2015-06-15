using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Xml;
using System.Web.Services;
using System.IO;

public partial class Laboratorios : System.Web.UI.Page
{
    InsereDados insereDados = new InsereDados();
    SelecionaDados selecionaDados = new SelecionaDados();
    AtualizaDados atualizaDados = new AtualizaDados();

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                if (Session["SessionIdTipoAcesso"].ToString() != "1")
                {
                    RetornaPaginaErro("Você não possui permissões para acessar essa ferramenta.");
                }
                else if (Session["SessionQtdUnidades"].ToString() == "0")
                {
                    RetornaPaginaErro("Não existem Unidades cadastradas para vincular Laboratórios. <br/>" +
                                      "Por favor, consulte o administrador do sistemas.");
                }
                else
                {
                    if (Session["SessionUsuario"].ToString() != string.Empty)
                    {
                        if (!IsPostBack)
                            CarregaDados();
                        else
                            DesmarcaSelecionados();
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

    /// <summary>
    /// Inicia a pagina
    /// </summary>
    public void CarregaDados()
    {
        CarregaLaboratorios();
        CarregaUnidades();
        DadosDefault();
    }

    private void CarregaLaboratorios()
    {
        DataTable dtLaboratorios = selecionaDados.ConsultaLaboratorio();

        if (dtLaboratorios.Rows.Count > 0)
        {
            rblLaboratorios.DataSource = dtLaboratorios;
            rblLaboratorios.DataTextField = "Nome";
            rblLaboratorios.DataValueField = "IdLaboratorio";
            rblLaboratorios.DataBind();

            rptCadastros.DataSource = dtLaboratorios;
            rptCadastros.DataBind();
        }

    }

    private void CarregaUnidades()
    {
        DataTable dtUnidades = selecionaDados.ConsultaTodasUnidades();

        if (dtUnidades.Rows.Count > 0)
        {
            ddlUnidade.DataSource = dtUnidades;
            ddlUnidade.DataTextField = "Unidade";
            ddlUnidade.DataValueField = "IdUnidade";
            ddlUnidade.DataBind();
        }
    }

    private void InsereLaboratorio(string sIdUnidade, string codLab, string nomeLab)
    {
        int idUnidade = Convert.ToInt32(sIdUnidade.Trim());

        InsereDados insereDados = new InsereDados();
        insereDados.InsereLaboratorio(codLab.Trim(), nomeLab.Trim(), 1, idUnidade);

    }

    private void DeletaLaboratorio(string sIdLaboratorio)
    {
        int idLaboratiro = Convert.ToInt32(sIdLaboratorio.Trim());

        DeletaDados deletaDados = new DeletaDados();

        deletaDados.DeletaLaboratorio(idLaboratiro);
    }

    private void DadosDefault()
    {
        txtNovoNome.Text = string.Empty;
        txtNovoCodigo.Text = string.Empty;
    }

    private void DesmarcaSelecionados()
    {
        foreach (ListItem item in rblLaboratorios.Items)
        {
            if (item.Selected)
                item.Selected = false;
        }
    }

    protected void rptCadastros_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        Label lblIdCadastro = (Label)e.Item.FindControl("lblIdCadastro");
        Panel dvLaboratorio = (Panel)e.Item.FindControl("dvLaboratorio");

        dvLaboratorio.CssClass = "none dvLaboratorio css" + lblIdCadastro.Text.Trim();
    }

    #region Ações dos Botões

    protected void btCadastrar_Click(object sender, EventArgs e)
    {
        try
        {
            bool dadosJaCadastrados = false;
            dadosJaCadastrados = VerificaCodLabCadastro(txtNovoNome.Text.Trim(), txtNovoCodigo.Text.Trim(), ddlUnidade.SelectedValue);

            if (!dadosJaCadastrados)
            {
                InsereLaboratorio(ddlUnidade.SelectedValue, txtNovoCodigo.Text, txtNovoNome.Text);

                DadosDefault();
                DesmarcaSelecionados();
                CarregaDados();

                Page.ClientScript.RegisterStartupScript(GetType(), "msgbox", "alert('Laboratório cadastrado com sucesso!');", true);
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(GetType(), "msgbox", "alert('Por favor, defina um novo Código e/ou" +
                    " novo Nome pois o(s) digitado(s) já está(ão) sendo usado(s).');", true);
            }

        }
        catch (Exception ex)
        {
            Session["ExcessaoDeErro"] = ex.ToString();
            Response.Redirect("../Erro/Erro.aspx");
        }
    }

    private bool VerificaCodLabCadastro(string novoNome, string novoCod, string idUnidade)
    {
        try
        {
            DataTable dtLaboratorios = selecionaDados.ConsultaLaboratorio();
            dtLaboratorios.DefaultView.RowFilter = "IdUnidade = " + idUnidade + " and Nome = '" + novoNome +
                                                   "' or CodLaboratorio = '" + novoCod.Trim() + "' ";

            //O mesmo código só é valido para Laboratórios que já foram cadastrados e bloqueados posteriormente
            if (dtLaboratorios.DefaultView.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        catch (Exception ex)
        {

            return false;
        }

    }

    private bool VerificaCodigoLab(string novoCod, string idUnidade)
    {
        try
        {
            DataTable dtLaboratorios = selecionaDados.ConsultaLaboratorio();
            dtLaboratorios.DefaultView.RowFilter = "IdUnidade = " + idUnidade + "and CodLaboratorio = '" + novoCod.Trim() + "' ";

            //O mesmo código só é valido para Laboratórios que já foram cadastrados e bloqueados posteriormente
            if (dtLaboratorios.DefaultView.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        catch (Exception ex)
        {
            return false;
        }

    }

    /// <summary>
    /// Grava e altera os números
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btAlterar_Click(object sender, EventArgs e)
    {
        string idCadastro = ((Button)sender).CommandArgument.ToString().Trim();

        try
        {
            foreach (RepeaterItem item in rptCadastros.Items)
            {
                Label lblIdUnidade = (Label)item.FindControl("lblIdUnidade");
                Label lblUnidade = (Label)item.FindControl("lblUnidade");
                Label lblIdCadastro = (Label)item.FindControl("lblIdCadastro");
                Label lblNome = (Label)item.FindControl("lblNome");

                //TextBox txtNome = (TextBox)item.FindControl("txtNome");
                TextBox txtCodigo = (TextBox)item.FindControl("txtCodigo");

                if (idCadastro == lblIdCadastro.Text)
                {
                    bool dadosJaCadastrados = false;
                    dadosJaCadastrados = VerificaCodigoLab(txtCodigo.Text.Trim(), lblIdUnidade.Text.Trim());

                    if (!dadosJaCadastrados)
                    {
                        atualizaDados.AtualizaLaboratorio(Convert.ToInt32(idCadastro), txtCodigo.Text.Trim(), lblNome.Text.Trim(), 1, Convert.ToInt32(lblIdUnidade.Text.Trim()));

                        DadosDefault();
                        DesmarcaSelecionados();
                        CarregaDados();

                        Page.ClientScript.RegisterStartupScript(GetType(), "msgbox", "alert('Laboratório alterado com sucesso!');", true);

                        break;
                    }
                    else
                    {
                        DesmarcaSelecionados();
                        Page.ClientScript.RegisterStartupScript(GetType(), "msgbox", "alert('Por favor, defina um novo Código e/ou" +
                                                            " novo Nome pois o(s) digitado(s) já está(ão) sendo usado(s).');", true);
                        break;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Session["ExcessaoDeErro"] = ex.ToString();
            Response.Redirect("../Erro/Erro.aspx");
        }
    }

    protected void btExcluir_Click(object sender, EventArgs e)
    {
        try
        {
            string idCadastro = ((Button)sender).CommandArgument.ToString().Trim();

            foreach (RepeaterItem item in rptCadastros.Items)
            {
                Label lblIdCadastro = (Label)item.FindControl("lblIdCadastro");

                if (idCadastro == lblIdCadastro.Text)
                {
                    DeletaLaboratorio(idCadastro);
                    DadosDefault();
                    DesmarcaSelecionados();
                    CarregaDados();
                    break;
                }
            }

            Page.ClientScript.RegisterStartupScript(GetType(), "msgbox", "alert('Laboratório excluído com sucesso!');", true);
        }
        catch (Exception ex)
        {
            Session["ExcessaoDeErro"] = ex.ToString();
            Response.Redirect("../Erro/Erro.aspx");
        }

    }

    #endregion

    protected void btMenuInicial_Click(object sender, EventArgs e)
    {
        Response.Redirect("../Home/Home.aspx");
    }

    protected void btErro_Click(object sender, EventArgs e)
    {
        Session["ExcessaoDeErro"] = hddErro.Value;
        Response.Redirect("../Erro/Erro.aspx");
    }

    public void RetornaPaginaErro(string erro)
    {
        Session["ExcessaoDeErro"] = erro.Trim();
        Response.Redirect("../Erro/Erro.aspx");
    }

    protected void RecarregarPagina_Click(object sender, EventArgs e)
    {
        DesmarcaSelecionados();
        Response.Redirect("../OpcoesAdicionais/Laboratorios.aspx");
    }
}