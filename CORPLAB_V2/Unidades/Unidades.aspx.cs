using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.Services;

public partial class Unidades_Unidades : System.Web.UI.Page
{
    SelecionaDados selecionaDados = new SelecionaDados();
    InsereDados insereDados = new InsereDados();
    Auxiliar auxiliar = new Auxiliar();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            CarregaDados();
    }

    private void CarregaDados()
    {
        DropDownNumeracao();
        ddlCidade.Items.Insert(0, new ListItem("-- Selecione --", "0"));
    }

    [WebMethod]
    public static List<ListItem> Pais()
    {
        List<ListItem> ListPais = new List<ListItem>();

        SelecionaDados selecionaDados = new SelecionaDados();
        ListPais = selecionaDados.ConsultaPais();

        return ListPais;
    }

    [WebMethod]
    public static List<ListItem> Estados()
    {
        List<ListItem> ListEstados = new List<ListItem>();

        SelecionaDados selecionaDados = new SelecionaDados();

        DataView dvEstados = selecionaDados.ConsultaEstados().DefaultView;
        dvEstados.RowFilter = "IdEstado in (19,25)";

        if (dvEstados.Count > 0)
        {
            foreach (DataRowView item in dvEstados)
                ListEstados.Add(new ListItem(item["Estado"].ToString(), item["IdEstado"].ToString()));
        }

        return ListEstados;
    }

    [WebMethod]
    public static List<ListItem> Cidades(string idEstado)
    {
        List<ListItem> ListCidade = new List<ListItem>();

        SelecionaDados selecionaDados = new SelecionaDados();
        DataTable dtCidade = selecionaDados.ConsultaCidades(Convert.ToInt32(idEstado.Trim()));

        if (dtCidade.Rows.Count > 0)
        {
            foreach (DataRow item in dtCidade.Rows)
                ListCidade.Add(new ListItem(item["Cidade"].ToString(), item["IdCidade"].ToString()));
        }

        return ListCidade;
    }

    [WebMethod]
    public static List<ListItem> Camaras(int idUnidade)
    {
        List<ListItem> ListCamaras = new List<ListItem>();

        SelecionaDados selecionaDados = new SelecionaDados();
        DataTable dtCamaras = selecionaDados.ConsultaCamaras(idUnidade);

        if (dtCamaras.Rows.Count > 0)
        {
            foreach (DataRow item in dtCamaras.Rows)
                ListCamaras.Add(new ListItem(item["NomeCamara"].ToString(), item["IdCamara"].ToString()));
        }

        return ListCamaras;
    }

    [WebMethod(EnableSession = true)]
    public static List<ListItem> InsereUnidade(string nomeUnidade, string sIdCidade, string sIdEstado, string sIdPais, string sQtdCamaras)
    {
        List<ListItem> ListCamaras = new List<ListItem>();
        InsereDados insereDados = new InsereDados();

        int idCidade = Convert.ToInt32(sIdCidade.Trim());
        int idEstado = Convert.ToInt32(sIdEstado.Trim());
        int idPais = Convert.ToInt32(sIdPais.Trim());
        int qtdCamaras = Convert.ToInt32(sQtdCamaras.Trim());

        int idUnidade = insereDados.InsereUnidade(nomeUnidade, idCidade, idEstado, idPais, qtdCamaras);

        ListCamaras.Add(new ListItem("Unidade Inserida", idUnidade.ToString()));

        return ListCamaras;
    }

    [WebMethod]
    public static string InserePrateleiras(string prateleiras)
    {
        string msgRetorno = string.Empty;

        InsereDados insereDados = new InsereDados();

        string[] aCamarasPrateleiras = prateleiras.Split('|');

        for (int camaraP = 0; camaraP < aCamarasPrateleiras.Length; camaraP++)
        {
            if (!string.IsNullOrEmpty(aCamarasPrateleiras[camaraP].ToString()))
            {
                string idCamaraAntes = string.Empty;
                string[] aPrateleiras = aCamarasPrateleiras[camaraP].ToString().Split('_');

                //Inclui mais prateleira para poder começar a contagem a partir do numero 1 
                int qtdPrateleiras = Convert.ToInt32(aPrateleiras[2].ToString().Trim()) + 1;
                for (int prateleira = 1; prateleira < qtdPrateleiras; prateleira++)
                {
                    int idCamara = Convert.ToInt32(aPrateleiras[0].ToString().Trim());
                    string nomeXnumeroPrateleira = aPrateleiras[1].ToString().Trim();

                    if (prateleira > 9)
                        nomeXnumeroPrateleira += prateleira;
                    else
                        nomeXnumeroPrateleira += "0" + prateleira;

                    insereDados.InserePrateleira(idCamara, nomeXnumeroPrateleira);
                }
            }
        }

        return msgRetorno;
    }

    private void DropDownNumeracao()
    {
        DataTable dtNumeracao = new DataTable();
        dtNumeracao.Columns.Add("IdNumero");
        dtNumeracao.Columns.Add("Numero");

        for (int numeracao = 1; numeracao < 100; numeracao++)
        {
            DataRow dRow = dtNumeracao.NewRow();

            dRow["IdNumero"] = numeracao;

            if (numeracao < 10)
                dRow["Numero"] = "0" + numeracao.ToString();
            else
                dRow["Numero"] = numeracao.ToString();


            dtNumeracao.Rows.Add(dRow);
        }

        ddlNumeracao.DataSource = dtNumeracao;
        ddlNumeracao.DataTextField = "Numero";
        ddlNumeracao.DataValueField = "IdNumero";
        ddlNumeracao.DataBind();

    }

    [WebMethod]
    public static List<ListItem> Alfabeto()
    {
        Auxiliar auxiliar = new Auxiliar();
        List<ListItem> ListAlfabeto = new List<ListItem>();

        DataTable dtAlfabeto = auxiliar.RetornaAlfabeto();

        if (dtAlfabeto.Rows.Count > 0)
        {
            foreach (DataRow item in dtAlfabeto.Rows)
                ListAlfabeto.Add(new ListItem(item["Letra"].ToString(), item["IdLetra"].ToString()));
        }

        return ListAlfabeto;
    }

    protected void btErro_Click(object sender, EventArgs e)
    {
        Session["ExcessaoDeErro"] = hddErro.Value;
        Response.Redirect("../Erro/Erro.aspx");
    }

}