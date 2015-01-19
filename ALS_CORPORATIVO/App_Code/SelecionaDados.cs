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

    public DataTable ConsultaPrateleiraAuditoria(int idPrateleira)
    {
        DataTable dtAuditoria = new DataTable();
        SqlConnection sqlConnection = new SqlConnection(sConexao);
        try
        {
            using (sqlConnection)
            {
                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@idPrateleira", idPrateleira);
                sqlCommand.CommandText = "usp_auditoria_x_prateleira_select";
                sqlConnection.Open();
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);

                dtAuditoria.Load(sqlDataReader);

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

        return dtAuditoria;
    }

    public DataTable ConsultaGrupoXAmostra(string codGrupo)
    {
        DataTable dtAmostrasGrupo = new DataTable();
        SqlConnection sqlConnection = new SqlConnection(sConexao);
        try
        {
            using (sqlConnection)
            {
                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@idGrupo", codGrupo);
                sqlCommand.CommandText = "usp_grupo_x_amostras_select";
                sqlConnection.Open();
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);

                dtAmostrasGrupo.Load(sqlDataReader);

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

        return dtAmostrasGrupo;
    }

    public DataTable ConsultaAcessoUsuario(string login, string senha)
    {
        DataTable dtUsuario = new DataTable();
        SqlConnection sqlConnection = new SqlConnection(sConexao);
        try
        {
            using (sqlConnection)
            {
                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@Login", login);
                sqlCommand.Parameters.AddWithValue("@Senha", senha);
                sqlCommand.CommandText = "usp_usuarioAcesso_select";
                sqlConnection.Open();
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);

                dtUsuario.Load(sqlDataReader);

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

        return dtUsuario;
    }

    public DataTable ConsultaTipoAmostra()
    {
        DataTable dtTipoAmostra = new DataTable();
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

                dtTipoAmostra.Load(sqlDataReader);

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

        return dtTipoAmostra;
    }

    public DataTable ConsultaPrateleiras(int idCamara)
    {
        DataTable dtPrateleiras = new DataTable();
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

                dtPrateleiras.Load(sqlDataReader);

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

        return dtPrateleiras;
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

    public DataTable ConsultaCamaras(int idUnidade)
    {
        DataTable dtCamaras = new DataTable();
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

                dtCamaras.Load(sqlDataReader);           

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

        return dtCamaras;
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
