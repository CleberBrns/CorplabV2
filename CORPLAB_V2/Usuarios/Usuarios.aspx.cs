using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Xml;
using System.Web.Services;

public partial class Usuarios_Usuarios : System.Web.UI.Page
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
            RetornaPaginaErro(ex.ToString());
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
        CarregaCadastros();    
        DadosDefault();
    }

    [WebMethod]
    public static List<ListItem> Unidades()
    {
        List<ListItem> ListUnidades = new List<ListItem>();

        SelecionaDados selecionaDados = new SelecionaDados();
        DataTable dtUnidades = selecionaDados.ConsultaTodasUnidades();

        if (dtUnidades.Rows.Count > 0)
        {
            foreach (DataRow item in dtUnidades.Rows)
                ListUnidades.Add(new ListItem(item["Unidade"].ToString(), item["IdUnidade"].ToString()));
        }

        return ListUnidades;
    }

    [WebMethod]
    public static List<ListItem> TipoAcesso()
    {
        List<ListItem> ListTipoAcesso = new List<ListItem>();

        SelecionaDados selecionaDados = new SelecionaDados();
        DataTable dtTipoAcesso = selecionaDados.ConsultaTipoAcesso();

        if (dtTipoAcesso.Rows.Count > 0)
        {
            foreach (DataRow item in dtTipoAcesso.Rows)
                ListTipoAcesso.Add(new ListItem(item["TipoAcesso"].ToString(), item["IdTipoAcesso"].ToString()));
        }

        return ListTipoAcesso;
    }

    [WebMethod]
    public static string InsereUsuario(string sIdUnidade, string sIdTipoAcesso, string nomeUsuario, string login, string senha)
    {
        string msgRetorno = string.Empty;

        int idUnidade = Convert.ToInt32(sIdUnidade.Trim());
        int idTipoAcesso = Convert.ToInt32(sIdTipoAcesso.Trim());

        InsereDados insereDados = new InsereDados();

        insereDados.InsereUsuario(nomeUsuario, login, senha, idUnidade, idTipoAcesso, 1);

        return msgRetorno;
    }

    [WebMethod]
    public static string DeletaUsuario(string sIdUsuario)
    {
        string msgRetorno = string.Empty;

        int idUsuario = Convert.ToInt32(sIdUsuario.Trim());

        DeletaDados deletaDados = new DeletaDados();

        deletaDados.DeletaUsuario(idUsuario);

        return msgRetorno;
    }


    /// <summary>
    /// Carrega as tabelas para exibição.
    /// </summary>
    private void CarregaCadastros()
    {
        DataTable dtUsuarios = selecionaDados.ConsultaTodosUsuarios();

        if (dtUsuarios.Rows.Count > 0)
        {
            rblUsuarios.DataSource = dtUsuarios;
            rblUsuarios.DataTextField = "Nome";
            rblUsuarios.DataValueField = "IdUsuario";
            rblUsuarios.DataBind();

            rptCadastros.DataSource = dtUsuarios;
            rptCadastros.DataBind();

        }
    }


    private void DadosDefault()
    {       
        txtNovoNome.Text = string.Empty;
        txtNovoLogin.Text = string.Empty;
        txtNovaSenha.Text = string.Empty;
    }

    /// <summary>
    /// 
    /// </summary>
    private void DesmarcaSelecionados()
    {
        foreach (ListItem item in rblUsuarios.Items)
        {
            if (item.Selected)
                item.Selected = false;
        }
    }


    /// <summary>
    /// Identação 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void rptCadastros_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        Label lblTipoAcesso = (Label)e.Item.FindControl("lblTipoAcesso");
        Label lblUnidade = (Label)e.Item.FindControl("lblUnidade");
        Label lblIdCadastro = (Label)e.Item.FindControl("lblIdCadastro");
        Panel dvUsuario = (Panel)e.Item.FindControl("dvUsuario");

        lblUnidade.Text = RetornaDescricaoUnidade(Convert.ToInt32(lblUnidade.Text.Trim()));        

        dvUsuario.CssClass = "none dvUsuario css" + lblIdCadastro.Text.Trim();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="p"></param>
    /// <returns></returns>
    private string RetornaDescricaoUnidade(int idUnidade)
    {
        string nomeUnidade = "Não definida";
        
        try
        {
            DataTable dtUnidades = selecionaDados.ConsultaTodasUnidades();
            dtUnidades.DefaultView.RowFilter = "IdUnidade = " + idUnidade + "";

            nomeUnidade = dtUnidades.DefaultView[0]["Unidade"].ToString().Trim();
        }
        catch (Exception) { }//Continua defaut

        return nomeUnidade;
    }

    #region Ações dos Botões

    
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
                Label lblIdCadastro = (Label)item.FindControl("lblIdCadastro");
                Label lblNome = (Label)item.FindControl("lblNome");

                TextBox txtLogin = (TextBox)item.FindControl("txtLogin");
                TextBox txtSenha = (TextBox)item.FindControl("txtSenha");

                if (idCadastro == lblIdCadastro.Text)
                {
                    atualizaDados.AtualizaUsuario(Convert.ToInt32(idCadastro), txtLogin.Text.Trim(), txtSenha.Text.Trim());
                    DesmarcaSelecionados();
                    break;
                }
            }

            Page.ClientScript.RegisterStartupScript(GetType(), "msgbox", "alert('Usuário alterado com sucesso!');", true);
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
        Response.Redirect("../Usuarios/Usuarios.aspx");
    }
}