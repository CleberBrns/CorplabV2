﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Home_Home : System.Web.UI.Page
{
    SelecionaDados selecionaDados = new SelecionaDados();

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["SessionUsuario"].ToString() != string.Empty)
            {
                CarregaPagina();
            }
        }
        catch (Exception)
        {
            Response.Write("<script>alert('Perdeu a sessão!')</script>");
            Response.Redirect("../Login/Login.aspx");
        }

    }

    private void CarregaPagina()
    {
        //Usuário Gestor
        if (Session["SessionIdTipoAcesso"].ToString() != "1")
        {
            btUnidades.Visible = false;
            btUsuarios.Visible = false;
        }
        else
        {
            try
            {
                DataTable dtUnidades = selecionaDados.ConsultaTodasUnidades();

                Session["SessionQtdUnidades"] = "0";
                if (!(dtUnidades.Rows.Count > 0))
                {
                    btUsuarios.Visible = false;
                }
                else
                {
                    Session["SessionQtdUnidades"] = dtUnidades.Rows.Count.ToString();
                }
            }
            catch (Exception ex)
            {                
                btUsuarios.Visible = false;
            }

        }
    }

    protected void btUsuarios_Click(object sender, EventArgs e)
    {
        Response.Redirect("../Usuarios/Usuarios.aspx");
    }

    protected void btSair_Click(object sender, EventArgs e)
    {
        Session["SessionUsuario"] = null;
        Session["SessionIdUsuario"] = null;
        Session["SessionIdTipoAcesso"] = null;
        Session["SessionIdUnidade"] = null;

        Response.Redirect("../Login/Login.aspx");
    }

    protected void btUnidades_Click(object sender, EventArgs e)
    {
        Response.Redirect("../Unidades/Unidades.aspx");
    }

    protected void btAcoes_Click(object sender, EventArgs e)
    {
        Response.Redirect("../Acoes/Acoes.aspx");
    }

}