using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.Services;

public partial class Unidades_Gerenciar : System.Web.UI.Page
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
                    RedirecionaLogin();
                }

            }
        }
        catch (Exception ex)
        {
            RedirecionaLogin();
        }
    }

    private void RedirecionaLogin()
    {
        Page.ClientScript.RegisterStartupScript(GetType(), "msgbox", "alert('Perdeu a sessão!');", true);
        Response.Redirect("../Login/Login.aspx");
    }

    private void CarregaPagina()
    {
        DataTable dtEstados = selecionaDados.ConsultaEstados(1);

        ddlEstado.DataSource = dtEstados;
        ddlEstado.DataTextField = "Estado";
        ddlEstado.DataValueField = "IdEstado";
        ddlEstado.DataBind();

        ddlEstado.Items.Insert(0, new ListItem("-- Selecione -- ", "0"));
    }

    private void MostrarRetorno(string mensagem, int tipoRetorno)
    {
        if (tipoRetorno == 0)
        {
            imgOk.Visible = true;
            imgErro.Visible = false;
        }
        else
        {
            imgOk.Visible = false;
            imgErro.Visible = true;
        }

        divRetorno.Visible = true;
        lblRetorno.Text = mensagem;
    }

    protected void ddlEstado_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlEstado.SelectedValue != "0")
        {
            ddlCidade.Enabled = true;

            DataTable dtCidade = selecionaDados.ConsultaCidades(Convert.ToInt32(ddlEstado.SelectedValue));

            ddlCidade.DataSource = dtCidade;
            ddlCidade.DataTextField = "Cidade";
            ddlCidade.DataValueField = "IdCidade";
            ddlCidade.DataBind();

            ddlCidade.Items.Insert(0, new ListItem("-- Selecione -- ", "0"));
        }
        else
        {
            ddlCidade.Enabled = false;
            ddlCidade.SelectedValue = "0";
        }

    }

    protected void btMenuPrincipal_Click(object sender, EventArgs e)
    {
        Response.Redirect("../Home/Home.aspx");
    }

    protected void btCadastrar_Click(object sender, EventArgs e)
    {
        if (ddlEstado.SelectedValue != "0")
        {
            if (ddlCidade.SelectedValue != "0")
            {
                if (!string.IsNullOrEmpty(txtNomeUnidade.Text))
                {
                    ddlEstado.Enabled = false;
                    ddlCidade.Enabled = false;
                    txtNomeUnidade.ReadOnly = true;
                    btMenuPrincipal.Enabled = false;
                    btMenuPrincipal.ToolTip = "Por favor, configure a unidade antes de continuar";

                    btConfigurarUnidade.Visible = true;
                    btCadastrar.Visible = false;

                    MostrarRetorno("Unidade cadastrada com sucesso. <br/> Por favor, clique em Configurar Unidade", 0);

                }
                else
                {
                    MostrarRetorno("Por favor, preencha o nome da unidade", 1);
                }

            }
            else
            {
                MostrarRetorno("Por favor, selecione uma Cidade", 1);
            }
        }
        else
        {
            MostrarRetorno("Por favor, selecione um Estado", 1);
        }
    }

    protected void btConfigurarUnidade_Click(object sender, EventArgs e)
    {
        lblUnidade.Text = " - Configuração da Unidade " + txtNomeUnidade.Text.Trim();

        btConfigurarUnidade.Visible = false;
        divUnidade.Visible = false;
        divRetorno.Visible = false;

        divConfiguraUnidade.Visible = true;        

        divCamara.Visible = true;
        txtCamara.Focus();

    }

    protected void btCamara_Click(object sender, EventArgs e)
    {        
        if (!string.IsNullOrEmpty(txtCamara.Text))
        {
            txtEstante.Focus();
            if (true)
            {
                MostrarRetorno("Camara cadastrada com sucesso", 0);
                divCamara.Visible = false;
                divEstante.Visible = true;
            }
            else
            {
                //Mensagem de erro
            }
        }
        else
        {
            MostrarRetorno("Para continuar preencha o campo Camara", 1);
        }
    }

    protected void btEstante_Click(object sender, EventArgs e)
    {
        txtEstante.Focus();
        if (!string.IsNullOrEmpty(txtEstante.Text))
        {
            txtPrateleiras.Focus();
            if (true)
            {
                MostrarRetorno("Estante cadastrada com sucesso", 0);
                txtPrateleiras.Focus();

                divEstante.Visible = false;
                divPrateleiras.Visible = true;

               
            }
            else
            {
                //Mensagem erro
            }

        }
        else
        {
            MostrarRetorno("Para continuar preencha o campo Estante", 1);
        }
    }

    protected void btPrateleiras_Click(object sender, EventArgs e)
    {
        txtPrateleiras.Focus();
        if (!string.IsNullOrEmpty(txtPrateleiras.Text))
        {
            
            if (true)
            {
                MostrarRetorno("Prateleira cadastrada com sucesso", 0);

                btMenuPrincipal.Enabled = true;
                btInicio.Visible = true;

                txtPrateleiras.Text = string.Empty;
                txtPrateleiras.Focus();
            }
            else
            {
                //Mensagem erro
            }

        }
        else
        {
            MostrarRetorno("Para continuar preencha o campo Prateleira", 1);
        }
    }


    protected void btInicio_Click(object sender, EventArgs e)
    {
        Response.Redirect("../Unidades/Unidades.aspx");
    }
}