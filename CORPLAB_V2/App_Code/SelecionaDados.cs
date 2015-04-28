using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.UI.WebControls;


/// <summary>
///
/// </summary>
public class SelecionaDados
{
    string sConexao = ConfigurationManager.AppSettings.Get("sConexaoSQL");

    public DataTable ConsultaUsuario(string login, string senha)
    {
        DataTable dtConsulta = new DataTable();
        SqlConnection sqlConnection = new SqlConnection(sConexao);
        try
        {
            using (sqlConnection)
            {
                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@login", login);
                sqlCommand.Parameters.AddWithValue("@senha", senha);
                sqlCommand.CommandText = "usp_usuario_select";
                sqlConnection.Open();
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);

                dtConsulta.Load(sqlDataReader);

                sqlDataReader.Close();
                sqlDataReader.Dispose();
                sqlDataReader = null;
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

        return dtConsulta;
    }

    public DataTable ConsultaTodosUsuarios()
    {
        DataTable dtConsulta = new DataTable();
        SqlConnection sqlConnection = new SqlConnection(sConexao);
        try
        {
            using (sqlConnection)
            {
                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.CommandText = "usp_todosUsuarios_select";
                sqlConnection.Open();
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);

                dtConsulta.Load(sqlDataReader);

                sqlDataReader.Close();
                sqlDataReader.Dispose();
                sqlDataReader = null;
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

        return dtConsulta;
    }

    public DataTable ConsultaTipoAcesso()
    {
        DataTable dtConsulta = new DataTable();
        SqlConnection sqlConnection = new SqlConnection(sConexao);
        try
        {
            using (sqlConnection)
            {
                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.CommandText = "usp_tipoAcesso_select";
                sqlConnection.Open();
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);

                dtConsulta.Load(sqlDataReader);

                sqlDataReader.Close();
                sqlDataReader.Dispose();
                sqlDataReader = null;
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

        return dtConsulta;
    }

    public DataTable ConsultaTodasUnidades()
    {
        DataTable dtConsulta = new DataTable();
        SqlConnection sqlConnection = new SqlConnection(sConexao);
        try
        {
            using (sqlConnection)
            {
                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.CommandText = "usp_todasUnidades_select";
                sqlConnection.Open();
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);

                dtConsulta.Load(sqlDataReader);

                sqlDataReader.Close();
                sqlDataReader.Dispose();
                sqlDataReader = null;
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

        return dtConsulta;
    }

    public DataTable ConsultaPaises()
    {
        DataTable dtConsulta = new DataTable();
        SqlConnection sqlConnection = new SqlConnection(sConexao);
        try
        {
            using (sqlConnection)
            {
                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.CommandText = "usp_todasUnidades_select";
                sqlConnection.Open();
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);

                dtConsulta.Load(sqlDataReader);

                sqlDataReader.Close();
                sqlDataReader.Dispose();
                sqlDataReader = null;
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

        return dtConsulta;
    }
    
    public DataTable ConsultaEstados(int idPais)
    {
        DataTable dtConsulta = new DataTable();
        SqlConnection sqlConnection = new SqlConnection(sConexao);
        try
        {
            using (sqlConnection)
            {
                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@idPais", idPais);
                sqlCommand.CommandText = "usp_Estado_select";
                sqlConnection.Open();
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);

                dtConsulta.Load(sqlDataReader);

                sqlDataReader.Close();
                sqlDataReader.Dispose();
                sqlDataReader = null;
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

        return dtConsulta;
    }

    public DataTable ConsultaCidades(int idEstado)
    {
        DataTable dtConsulta = new DataTable();
        SqlConnection sqlConnection = new SqlConnection(sConexao);
        try
        {
            using (sqlConnection)
            {
                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@idEstado", idEstado);
                sqlCommand.CommandText = "usp_Cidade_select";
                sqlConnection.Open();
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);

                dtConsulta.Load(sqlDataReader);

                sqlDataReader.Close();
                sqlDataReader.Dispose();
                sqlDataReader = null;
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

        return dtConsulta;
    }

}
