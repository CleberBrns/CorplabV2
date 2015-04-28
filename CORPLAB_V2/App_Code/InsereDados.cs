using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


/// <summary>
/// 
/// </summary>
public class InsereDados
{
    SelecionaDados selecionaDados = new SelecionaDados();
    string sConexao = ConfigurationManager.AppSettings.Get("sConexaoSQL");

    public int InsereUnidade(string unidade, int idCidade, int idEstado)
    {
        int idUnidade = 0;

        SqlConnection sqlConnection = new SqlConnection(sConexao);
        try
        {
            using (sqlConnection)
            {
                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.CommandText = "usp_unidade_insert";
                sqlCommand.Parameters.AddWithValue("@unidade", unidade);
                sqlCommand.Parameters.AddWithValue("@idCidade", idCidade);
                sqlCommand.Parameters.AddWithValue("@idEstado", idEstado);
                sqlCommand.Parameters.AddWithValue("@idUnidade", 0).Direction = ParameterDirection.Output;

                sqlConnection.Open();
                sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);

                idUnidade = int.Parse(sqlCommand.Parameters["@idUnidade"].Value.ToString());
                sqlCommand.Dispose();
                sqlCommand = null;
            }
        }
        finally
        {
            if (sqlConnection.State == ConnectionState.Open)
            {
                sqlConnection.Close();
            }
            sqlConnection = null;
        }

        return idUnidade;
    }

    public int InsereCamara(string codCamara, int idUnidade)
    {
        int idCamara = 0;

        SqlConnection sqlConnection = new SqlConnection(sConexao);
        try
        {
            using (sqlConnection)
            {
                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.CommandText = "usp_camara_insert";
                sqlCommand.Parameters.AddWithValue("@NomeCamara", codCamara);
                sqlCommand.Parameters.AddWithValue("@idUnidade", idUnidade);                              
                sqlCommand.Parameters.AddWithValue("@idCamara", 0).Direction = ParameterDirection.Output;

                sqlConnection.Open();
                sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);

                idCamara = int.Parse(sqlCommand.Parameters["@idCamara"].Value.ToString());
                sqlCommand.Dispose();
                sqlCommand = null;
            }
        }
        finally
        {
            if (sqlConnection.State == ConnectionState.Open)
            {
                sqlConnection.Close();
            }
            sqlConnection = null;
        }

        return idCamara;
    }

    public int InsereEstante(string codEstante, int idCamara)
    {
        int idEstante = 0;

        SqlConnection sqlConnection = new SqlConnection(sConexao);
        try
        {
            using (sqlConnection)
            {
                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.CommandText = "usp_estante_insert";
                sqlCommand.Parameters.AddWithValue("@Estante", codEstante);
                sqlCommand.Parameters.AddWithValue("@idCamara", idCamara);
                sqlCommand.Parameters.AddWithValue("@idEstante", 0).Direction = ParameterDirection.Output;

                sqlConnection.Open();
                sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);

                idEstante = int.Parse(sqlCommand.Parameters["@idEstante"].Value.ToString());
                sqlCommand.Dispose();
                sqlCommand = null;
            }
        }
        finally
        {
            if (sqlConnection.State == ConnectionState.Open)
            {
                sqlConnection.Close();
            }
            sqlConnection = null;
        }

        return idEstante;
    }

    public void InserePrateleira(int idEstante, string codPrateleira)
    {
        SqlConnection sqlConnection = new SqlConnection(sConexao);

        try
        {
            using (sqlConnection)
            {
                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.CommandText = "usp_prateleira_insert";
                sqlCommand.Parameters.AddWithValue("@idEstante", idEstante);
                sqlCommand.Parameters.AddWithValue("@Prateleira", codPrateleira);
                sqlConnection.Open();
                sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);

                sqlCommand.Dispose();
                sqlCommand = null;
            }
        }
        finally
        {
            if (sqlConnection.State == ConnectionState.Open)
            {
                sqlConnection.Close();
            }
            sqlConnection = null;
        }
    }

    public void InsereAmostra(string sIdGrupo, int idAmostra, string descricao, int idTipoAmostra, int idPrateleira, string nomeCaixa)
    {
        SqlConnection sqlConnection = new SqlConnection(sConexao);

        try
        {
            using (sqlConnection)
            {
                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.CommandText = "usp_grupo_x_amostras_insert";

                sqlCommand.Parameters.AddWithValue("@idGrupo", sIdGrupo);
                sqlCommand.Parameters.AddWithValue("@idAmostra", idAmostra);
                sqlCommand.Parameters.AddWithValue("@Descricao", descricao);
                sqlCommand.Parameters.AddWithValue("@idtipoAmostra", idTipoAmostra);
                sqlCommand.Parameters.AddWithValue("@idPrateleira", idPrateleira);
                sqlCommand.Parameters.AddWithValue("@NomeCaixa", nomeCaixa);

                sqlConnection.Open();
                sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);

                sqlCommand.Dispose();
                sqlCommand = null;
            }
        }
        finally
        {
            if (sqlConnection.State == ConnectionState.Open)
            {
                sqlConnection.Close();
            }
            sqlConnection = null;
        }
    }

    public void InsereUsuario(string nome, string login, string senha, int idUnidade, int idTipoAcesso, int idStatus)
    {
        SqlConnection sqlConnection = new SqlConnection(sConexao);

        try
        {
            using (sqlConnection)
            {
                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.CommandText = "usp_usuario_insert";
                sqlCommand.Parameters.AddWithValue("@Nome", nome);
                sqlCommand.Parameters.AddWithValue("@Login", login);
                sqlCommand.Parameters.AddWithValue("@senha", senha);
                sqlCommand.Parameters.AddWithValue("@idUnidade", idUnidade);
                sqlCommand.Parameters.AddWithValue("@idTipoAcesso", idTipoAcesso);
                sqlCommand.Parameters.AddWithValue("@idTipoStatus", idStatus);
                sqlConnection.Open();
                sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);

                sqlCommand.Dispose();
                sqlCommand = null;
            }
        }
        finally
        {
            if (sqlConnection.State == ConnectionState.Open)
            {
                sqlConnection.Close();
            }
            sqlConnection = null;
        }
    }


}
