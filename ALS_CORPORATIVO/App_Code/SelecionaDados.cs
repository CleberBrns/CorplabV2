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


    public List<ListItem> ConsultaTipoAmostra()
    {
        List<ListItem> ListTipoAmostra = new List<ListItem>();
        SqlConnection sqlConnection = new SqlConnection(sConexao);
        try
        {
            using (sqlConnection)
            {
                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.CommandText = "usp_tipoAmostra_select";                
                sqlConnection.Open();
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);

                if (sqlDataReader.HasRows)
                {
                    while (sqlDataReader.Read())
                    {
                        ListTipoAmostra.Add(new ListItem(sqlDataReader["TipoAmostra"].ToString(), sqlDataReader["IdTipoAmostra"].ToString()));
                    }
                }

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

        return ListTipoAmostra;
    }

    public List<ListItem> ConsultaPrateleiras(int idCamara)
    {
        List<ListItem> ListPrateleiras = new List<ListItem>();
        SqlConnection sqlConnection = new SqlConnection(sConexao);
        try
        {
            using (sqlConnection)
            {
                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.CommandText = "usp_prateleira_select";
                sqlCommand.Parameters.AddWithValue("@IdCamara", idCamara);
                sqlConnection.Open();
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);

                if (sqlDataReader.HasRows)
                {
                    while (sqlDataReader.Read())
                    {
                        ListPrateleiras.Add(new ListItem(sqlDataReader["Prateleira"].ToString(), sqlDataReader["IdPrateleira"].ToString()));
                    }
                }

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

        return ListPrateleiras;
    }

    public DataTable ConsultaTodosUsuarios()
    {
        DataTable dtUsuarios = new DataTable();
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

                dtUsuarios.Load(sqlDataReader);

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

        return dtUsuarios;
    }

    public DataTable ConsultaTipoAcesso()
    {
        DataTable dtTipoAcesso = new DataTable();
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

                dtTipoAcesso.Load(sqlDataReader);

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

        return dtTipoAcesso;
    }

    public DataTable ConsultaTodasUnidades()
    {
        DataTable dtUnidades = new DataTable();
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
                
                dtUnidades.Load(sqlDataReader);

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

        return dtUnidades;
    }

    public List<ListItem> ConsultaCamaras(int idUnidade)
    {
        List<ListItem> ListCamaras = new List<ListItem>();
        SqlConnection sqlConnection = new SqlConnection(sConexao);
        try
        {
            using (sqlConnection)
            {
                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.CommandText = "usp_camara_select";
                sqlCommand.Parameters.AddWithValue("@IdUnidade", idUnidade);
                sqlConnection.Open();
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);

                if (sqlDataReader.HasRows)
                {
                    while (sqlDataReader.Read())
                    {
                        ListCamaras.Add(new ListItem(sqlDataReader["NomeCamara"].ToString(), sqlDataReader["IdCamara"].ToString()));
                    }
                }            

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

        return ListCamaras;
    }

    public List<ListItem> ConsultaPais()
    {
        List<ListItem> ListPais = new List<ListItem>();
        SqlConnection sqlConnection = new SqlConnection(sConexao);

        string query = "select pais.pkIdPais as IdPais, pais.Pais from ALS_PAIS pais";
        try
        {
            using (sqlConnection)
            {
                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.CommandText = query;
                sqlConnection.Open();
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);

                if (sqlDataReader.HasRows)
                {
                    while (sqlDataReader.Read())
                    {
                        ListPais.Add(new ListItem(sqlDataReader["Pais"].ToString(), sqlDataReader["IdPais"].ToString()));
                    }
                }    

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

        return ListPais;
    }

    public DataTable ConsultaEstados()
    {
        DataTable dtPais = new DataTable();
        SqlConnection sqlConnection = new SqlConnection(sConexao);

        string query = "select estado.pkIdEstado as IdEstado, estado.Estado, estado.UF from ALS_ESTADO estado";
        try
        {
            using (sqlConnection)
            {
                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.CommandText = query;
                sqlConnection.Open();
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);

                dtPais.Load(sqlDataReader);

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

        return dtPais;
    }

    public DataTable ConsultaCidades(int idEstado)
    {
        DataTable dtCidades = new DataTable();
        SqlConnection sqlConnection = new SqlConnection(sConexao);

        string query = "select cidade.pkIdcidade as IdCidade,cidade.Cidade from ALS_CIDADE cidade where cidade.fkIdEstado = " + idEstado + "";
        try
        {
            using (sqlConnection)
            {
                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.CommandText = query;
                sqlConnection.Open();
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);

                dtCidades.Load(sqlDataReader);

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

        return dtCidades;
    }

}
