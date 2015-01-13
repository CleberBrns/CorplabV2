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

    public void InsereAmostra(int idGrupo, int idAmostra, string codAmostra, string descricao, int idTipoAmostra)
    {
        SqlConnection sqlConnection = new SqlConnection(sConexao);

        try
        {
            using (sqlConnection)
            {
                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.CommandText = "usp_grupo_x_amostras_insert";
                sqlCommand.Parameters.AddWithValue("@idGrupo", idGrupo);
                sqlCommand.Parameters.AddWithValue("@idAmostra", idAmostra);
                sqlCommand.Parameters.AddWithValue("@CodAmostra", codAmostra);
                sqlCommand.Parameters.AddWithValue("@Descricao", descricao);
                sqlCommand.Parameters.AddWithValue("@idtipoAmostra", idTipoAmostra);
                
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
                sqlCommand.Parameters.AddWithValue("@idStatus", idStatus);
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

    public int InsereUnidade(string unidade, int idCidade, int idEstado, int idPais, int qtdCamaras)
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
                sqlCommand.Parameters.AddWithValue("@idPais", idPais);
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

        for (int camara = 1; camara < qtdCamaras + 1; camara++)
            InsereCamara(idUnidade, camara);


        return idUnidade;

    }

    public void InsereCamara(int idUnidade, int qtdCamara)
    {
        SqlConnection sqlConnection = new SqlConnection(sConexao);

        try
        {
            using (sqlConnection)
            {
                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.CommandText = "usp_camara_insert";
                sqlCommand.Parameters.AddWithValue("@NomeCamara", "Câmara nº" + qtdCamara);
                sqlCommand.Parameters.AddWithValue("@idUnidade", idUnidade);
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

    public void InserePrateleira(int idCamara, string prateleira)
    {
        SqlConnection sqlConnection = new SqlConnection(sConexao);

        try
        {
            using (sqlConnection)
            {
                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.CommandText = "usp_prateleira_insert";
                sqlCommand.Parameters.AddWithValue("@idCamara", idCamara);
                sqlCommand.Parameters.AddWithValue("@Prateleira", prateleira);
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
