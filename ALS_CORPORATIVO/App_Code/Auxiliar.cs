using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


/// <summary>
/// Summary description for Auxiliar
/// </summary>
public class Auxiliar
{
    public DataTable RetornaAlfabeto()
    {
        DataTable dtAlfabeto = new DataTable();
        dtAlfabeto.Columns.Add("IdLetra");
        dtAlfabeto.Columns.Add("Letra");

        string[] aAlfabeto = { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "l", "m", "n", "o", "p", 
                             "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" };

        for (int countLetra = 0; countLetra < aAlfabeto.Length; countLetra++)
        {
            DataRow dRow = dtAlfabeto.NewRow();

            dRow["IdLetra"] = countLetra;
            dRow["Letra"] = aAlfabeto[countLetra].ToUpper();

            dtAlfabeto.Rows.Add(dRow);
        }

        return dtAlfabeto;
    }

    public DataTable RetornaAmostraTeste()
    {
        DataTable dtAmostraTeste = new DataTable();
        dtAmostraTeste.Columns.Add("IdAmostra");
        dtAmostraTeste.Columns.Add("Descricao");
        dtAmostraTeste.Columns.Add("TipoAmostra");
        dtAmostraTeste.Columns.Add("DataEntrada");
        dtAmostraTeste.Columns.Add("StatusAmostra");
        dtAmostraTeste.Columns.Add("IdStatusAmostra");

        for (int entrada = 0; entrada < 5; entrada++)
        {
            DataRow dRow = dtAmostraTeste.NewRow();
            dRow["IdAmostra"] = entrada;
            dRow["Descricao"] = "Amostra Teste " + entrada;
            dRow["TipoAmostra"] = "Tipo " + entrada;
            dRow["DataEntrada"] = DateTime.Now.ToShortDateString();
            dRow["StatusAmostra"] = "Entrada";
            dRow["IdStatusAmostra"] = 0;

            dtAmostraTeste.Rows.Add(dRow);

        }

        for (int saida = 5; saida < 10; saida++)
        {
            DataRow dRow = dtAmostraTeste.NewRow();
            dRow["IdAmostra"] = saida;
            dRow["Descricao"] = "Amostra Teste " + saida;
            dRow["TipoAmostra"] = "Tipo " + saida;
            dRow["DataEntrada"] = DateTime.Now.ToShortDateString();
            dRow["StatusAmostra"] = "Saída";
            dRow["IdStatusAmostra"] = 1;

            dtAmostraTeste.Rows.Add(dRow);
        }

        for (int reentrada = 10; reentrada < 15; reentrada++)
        {
            DataRow dRow = dtAmostraTeste.NewRow();
            dRow["IdAmostra"] = reentrada;
            dRow["Descricao"] = "Amostra Teste " + reentrada;
            dRow["TipoAmostra"] = "Tipo " + reentrada;
            dRow["DataEntrada"] = DateTime.Now.ToShortDateString();
            dRow["StatusAmostra"] = "Reentrada";
            dRow["IdStatusAmostra"] = 2;

            dtAmostraTeste.Rows.Add(dRow);
        }

        for (int descarte = 15; descarte < 20; descarte++)
        {
            DataRow dRow = dtAmostraTeste.NewRow();
            dRow["IdAmostra"] = descarte;
            dRow["Descricao"] = "Amostra Teste " + descarte;
            dRow["TipoAmostra"] = "Tipo " + descarte;
            dRow["DataEntrada"] = DateTime.Now.ToShortDateString();
            dRow["StatusAmostra"] = "Descarte";
            dRow["IdStatusAmostra"] = 3;

            dtAmostraTeste.Rows.Add(dRow);
        }


        return dtAmostraTeste;
    }


    public class AmostraXGrupo
    {
        public int IdAmostra { get; set; }
        public string Descricao { get; set; }
        public string TipoAmostra { get; set; }
        public string DataEntrada { get; set; }
        public string StatusAmostra { get; set; }
        public int IdStatusAmostra { get; set; }  
    }
}
