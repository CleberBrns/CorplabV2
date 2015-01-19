using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Analise_Reentrada : System.Web.UI.Page
{
    SelecionaDados selecionaDados = new SelecionaDados();
    InsereDados insereDados = new InsereDados();
    AtualizaDados atualizaDados = new AtualizaDados();

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["SessionUser"].ToString() == string.Empty || Session["CodGrupo"].ToString() == string.Empty)
            {
                Page.ClientScript.RegisterStartupScript(GetType(), "SemSessao", "alert('Perdeu a sessão!');", true);
                Response.Redirect("../Login/Login.aspx");
            }
            else
            {
                hddIdGrupo.Value = Session["CodGrupo"].ToString();
            }
        }
        catch (Exception)
        {
            Page.ClientScript.RegisterStartupScript(GetType(), "SemSessao", "alert('Perdeu a sessão!');", true);
            Response.Redirect("../Login/Login.aspx");
        }
    }

    protected void btReinserirAmostra_Click(object sender, EventArgs e)
    {
        try
        {
            DataTable dtDadosGrupo = selecionaDados.ConsultaGrupoXAmostra(Session["CodGrupo"].ToString());

            dtDadosGrupo.DefaultView.RowFilter = "IdAmostra = " + txtAmostra.Value.Trim() + "";

            if (dtDadosGrupo.DefaultView.Count > 0)
            {
                atualizaDados.AtualizarAnaliseAmostra(2, Convert.ToInt32(txtAmostra.Value.Trim()));
           
                divRetornoSaida.Attributes.Remove("class");
                lblRetornoSaida.Text = "A amostra reentrou com sucesso.";
                txtAmostra.Value = string.Empty;
            }
            else
            {
                lblRetornoSaida.Text = "Essa amostra não pertence ao grupo pesquisado. <br/> Por favor, verifique abaixo as amostras cadastras para o mesmo.";
                spanLabelRetorno.Style.Add("color", "red");
                divRetornoSaida.Attributes.Remove("class");
                divInsercoes.Attributes.Remove("class");
            }



        }
        catch (Exception ex) { RetornaPaginaErro(ex.ToString()); }

    }

    [WebMethod]
    public static List<Auxiliar.AmostraXGrupo> ConsultaAmostrasGrupo(string sIdGrupo)
    {
        Auxiliar auxiliar = new Auxiliar();
        SelecionaDados selecionaDados = new SelecionaDados();

        DataTable dtAmostrasGrupo = selecionaDados.ConsultaGrupoXAmostra(sIdGrupo);

        List<Auxiliar.AmostraXGrupo> list = new List<Auxiliar.AmostraXGrupo>();
        Auxiliar.AmostraXGrupo obj = new Auxiliar.AmostraXGrupo();
        foreach (DataRow item in dtAmostrasGrupo.Rows)
        {
            obj = new Auxiliar.AmostraXGrupo();
            obj.IdAmostra = Convert.ToInt32(item["IdAmostra"]);          
            obj.TipoAmostra = item["TipoAmostra"].ToString();
            obj.DataEntrada = item["DataCadastro"].ToString();
            obj.StatusAmostra = item["StatusAmostra"].ToString();
            obj.IdStatusAmostra = Convert.ToInt32(item["IdStatusAmostra"]);
            list.Add(obj);
        }

        return list;
    }

    public void RetornaPaginaErro(string erro)
    {
        Session["ExcessaoDeErro"] = erro.Trim();
        Response.Redirect("../Erro/Erro.aspx");
    }
}