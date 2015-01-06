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

    protected void Page_Load(object sender, EventArgs e)
    {
        //try
        //{
        //    if (Session["UsuarioLogado"].ToString() != string.Empty)
        //    {
        //        if (!IsPostBack)
        //            CarregaDados();
        //        else
        //            DesmarcaSelecionados();
        //    }
        //    else
        //    {
        //        Response.Redirect("../Home/Home.aspx");
        //    }
        //}
        //catch (Exception)//Sem sessão
        //{
        //    Response.Redirect("../Home/Home.aspx");
        //}

        if (!IsPostBack)
            CarregaDados();
        else
            DesmarcaSelecionados();

    }

    /// <summary>
    /// Inicia a pagina
    /// </summary>
    public void CarregaDados()
    {
        CarregaCadastros();
        CarregaDropDowns();
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
            rblUsuarios.DataTextField = "NOME";
            rblUsuarios.DataValueField = "ID";
            rblUsuarios.DataBind();

            rptCadastros.DataSource = dtUsuarios;
            rptCadastros.DataBind();

        }
    }

    private void CarregaDropDowns()
    {
        string sCaminhoXML = string.Empty;

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
        lblTipoAcesso.Text = RetornaDescricaoTipoAcesso(Convert.ToInt32(lblTipoAcesso.Text.Trim()));

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
        catch (Exception) { }//Continua Vazio

        return nomeUnidade;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="idTipoAcesso"></param>
    /// <returns></returns>
    private string RetornaDescricaoTipoAcesso(int idTipoAcesso)
    {
        string tipoAcesso = "Não definido";

        try
        {
            DataSet dsTiposAcesso = new DataSet();
            string sCaminhoXML = Server.MapPath("../Tabelas/TiposDeAcesso.xml");
            dsTiposAcesso.ReadXml(sCaminhoXML);
            DataView dvTipoAcesso = dsTiposAcesso.Tables[0].DefaultView;

            dvTipoAcesso.RowFilter = "ID = " + idTipoAcesso + "";

            tipoAcesso = dvTipoAcesso[0]["TIPO"].ToString().Trim();
        }
        catch (Exception) { }//Continua Vazio

        return tipoAcesso;
    }

    #region Ações dos Botões

    /// <summary>
    /// Grava e altera os números
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btCadastrar_Click(object sender, EventArgs e)
    {

        int idCadastro = 0;

        DataSet dsUsuarios = new DataSet();
        DataView dvUsuarios = new DataView();
        string sCaminhoXML = Server.MapPath("../Tabelas/Usuarios.xml");
        dsUsuarios.ReadXml(sCaminhoXML);

        if (dsUsuarios.Tables.Count > 0)
            dvUsuarios = dsUsuarios.Tables[0].DefaultView;

        dvUsuarios.Sort = "ID desc";

        int idUltimoCadastro = 0;
        try
        {
            idUltimoCadastro = Convert.ToInt32(dvUsuarios[0]["ID"].ToString());
        }
        catch (Exception) { }//Continua 0

        idCadastro = (idUltimoCadastro + 1);

        try
        {
            ValidaCampos(idCadastro, Convert.ToInt32(ddlUnidade.SelectedValue.Trim()), Convert.ToInt32(ddlNivelAcesso.SelectedValue.Trim()),
                         txtNovoNome.Text.Trim(), txtNovoLogin.Text.Trim(), txtNovaSenha.Text.Trim(), 1);
        }
        catch (Exception erro) { Response.Write(erro); }

    }

    /// <summary>
    /// Grava e altera os números
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btAlterar_Click(object sender, EventArgs e)
    {
        string idCadastro = ((Button)sender).CommandArgument.ToString().Trim();

        foreach (RepeaterItem item in rptCadastros.Items)
        {
            Label lblIdCadastro = (Label)item.FindControl("lblIdCadastro");
            Label lblNome = (Label)item.FindControl("lblNome");

            TextBox txtLogin = (TextBox)item.FindControl("txtLogin");
            TextBox txtSenha = (TextBox)item.FindControl("txtSenha");

            if (idCadastro == lblIdCadastro.Text)
            {
                ValidaCampos(Convert.ToInt32(idCadastro.Trim()), 0, 0, lblNome.Text, txtLogin.Text.Trim(), txtSenha.Text.Trim(), 2);
                break;
            }
        }
    }

    /// <summary>
    /// Grava e altera os números
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btExcluir_Click(object sender, EventArgs e)
    {
        string idCadastro = ((Button)sender).CommandArgument.ToString().Trim();
        if (hddConfirmacao.Value == "Sim")
        {
            foreach (RepeaterItem item in rptCadastros.Items)
            {
                Label lblIdCadastro = (Label)item.FindControl("lblIdCadastro");
                string esclusao = "excluir";//Apenas para usar o método
                if (idCadastro == lblIdCadastro.Text)
                {
                    ValidaCampos(Convert.ToInt32(lblIdCadastro.Text.Trim()), 0, 0, esclusao, esclusao, esclusao, 3);
                    break;
                }
            }
        }
        else
        {
            string msgConfirmacao = "Ação cancelada, o cadastro não foi alterado.";
            Page.ClientScript.RegisterStartupScript(GetType(), "AlertaCancelado", "alert('" + msgConfirmacao + "');", true);
        }
    }

    #endregion


    /// <summary>
    /// Valida os campos e inclui/altera/exclui o cadastro
    /// </summary>
    /// <param name="idCadastro"></param>
    private void ValidaCampos(int idCadastro, int idUnidade, int idTipoAcesso, string nome, string login, string senha, int tipoAcao)
    {
        //Tipo ação 1/Inclusão - 2/Alteração - 3/Exclusão

        bool confimacao = false;
        string msgConfirmacao = string.Empty;
        if (!string.IsNullOrEmpty(nome) && !string.IsNullOrEmpty(login) && !string.IsNullOrEmpty(senha))
        {
            if (login.Length >= 4 && senha.Length >= 4)
            {
                if (tipoAcao == 1)
                    InsereUsuario1(idCadastro, idUnidade, idTipoAcesso, nome, login, senha);
                else if (tipoAcao == 2)
                    AlterarCadastroXML(idCadastro, login, senha);
                else if (tipoAcao == 3)
                    ExcluirCadastroXML(idCadastro);

                msgConfirmacao = "Cadastro " + DescricaoAcao(tipoAcao) + " com sucesso!";
                confimacao = true;
            }
            else
                msgConfirmacao = "Favor preencher corretamente os campos.";
        }
        else
            msgConfirmacao = "Favor preencher todos os campos.";

        Page.ClientScript.RegisterStartupScript(GetType(), "AlertaOk", "alert('" + msgConfirmacao + "');", true);

        if (confimacao)
            Page.ClientScript.RegisterStartupScript(GetType(), "Reload", "window.location.reload();", true);

    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="tipoAcao"></param>
    /// <returns></returns>
    private string DescricaoAcao(int tipoAcao)
    {
        //Tipo ação 1/Inclusão - 2/Alteração - 3/Exclusão
        string acao = "conclúido";

        switch (tipoAcao)
        {
            case 1:
                acao = "incluído";
                break;
            case 2:
                acao = "alterado";
                break;
            case 3:
                acao = "excluído";
                break;
        }

        return acao;
    }

    #region Métodos: Inclusão, Alteração e Exclusão

    /// <summary>
    /// Insere novo contato
    /// </summary>
    /// <param name="idCadastro"></param>
    /// <param name="nomeGestor"></param>
    /// <param name="login"></param>
    /// <param name="senha"></param>
    private void InsereUsuario1(int idCadastro, int idUnidade, int idTipoAcesso, string nomeUsuario, string login, string senha)
    {
        try
        {
            insereDados.InsereUsuario(nomeUsuario, login, senha, idUnidade, idTipoAcesso, 1);
        }
        catch (Exception ex)
        {

        }
    }

    /// <summary>
    /// Altera os telefones
    /// </summary>
    /// <param name="idCadastro"></param>
    /// <param name="sTelefone"></param>
    /// <param name="iCadastro"></param>
    private void AlterarCadastroXML(int idCadastro, string sLogin, string sSenha)
    {
        XmlDocument doc = new XmlDocument();

        string sCaminhoXML = Server.MapPath("../Tabelas/Usuarios.xml");
        DataSet ds = new DataSet();
        ds.ReadXml(sCaminhoXML);
        string nomeTabela = ds.Namespace;

        //Fazer uma busca no DataSet para encontrar o cliente com o ID da QueryString
        DataRow dRow = ds.Tables[0].Select("ID = '" + idCadastro + "'")[0];

        //Definindo os valores do DataRow com os valores do formulário.
        dRow["LOGIN"] = sLogin;
        dRow["SENHA"] = sSenha;

        //Atualizar o XML com os novos valores.
        ds.WriteXml(sCaminhoXML);

    }


    /// <summary>
    /// Exclui um cadastro
    /// </summary>
    /// <param name="iIdVereador"></param>
    /// <param name="idCadastro"></param>
    private void ExcluirCadastroXML(int idCadastro)
    {
        string sCaminhoXML = Server.MapPath("../Tabelas/Usuarios.xml");
        DataSet ds = new DataSet();
        ds.ReadXml(sCaminhoXML);

        //Selecionar e deletar a linha com o ID da QueryString
        ds.Tables[0].Select("ID = '" + idCadastro + "'")[0].Delete();
        //Aplicar as alterações no DataSet
        ds.AcceptChanges();

        //Salva no XML
        ds.WriteXml(sCaminhoXML);
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
}