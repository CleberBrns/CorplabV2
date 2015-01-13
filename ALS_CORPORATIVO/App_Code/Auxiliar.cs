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
        dtAmostraTeste.Columns.Add("Status");
        dtAmostraTeste.Columns.Add("IdStatus");

        for (int entrou = 0; entrou < 5; entrou++)
        {
            DataRow dRow = dtAmostraTeste.NewRow();
            dRow["IdAmostra"] = entrou;
            dRow["Descricao"] = "Amostra Teste " + entrou;
            dRow["TipoAmostra"] = "Tipo " + entrou;
            dRow["DataEntrada"] = DateTime.Now.ToShortDateString();
            dRow["Status"] = "Entrou";
            dRow["IdStatus"] = 1;

            dtAmostraTeste.Rows.Add(dRow);

        }

        for (int saiu = 5; saiu < 10; saiu++)
        {
            DataRow dRow = dtAmostraTeste.NewRow();
            dRow["IdAmostra"] = saiu;
            dRow["Descricao"] = "Amostra Teste " + saiu;
            dRow["TipoAmostra"] = "Tipo " + saiu;
            dRow["DataEntrada"] = DateTime.Now.ToShortDateString();
            dRow["Status"] = "Saiu";
            dRow["IdStatus"] = 2;

            dtAmostraTeste.Rows.Add(dRow);
        }

        for (int reentrou = 10; reentrou < 15; reentrou++)
        {
            DataRow dRow = dtAmostraTeste.NewRow();
            dRow["IdAmostra"] = reentrou;
            dRow["Descricao"] = "Amostra Teste " + reentrou;
            dRow["TipoAmostra"] = "Tipo " + reentrou;
            dRow["DataEntrada"] = DateTime.Now.ToShortDateString();
            dRow["Status"] = "Reentrou";
            dRow["IdStatus"] = 3;

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
        public string Status { get; set; }
        public int IdStatus { get; set; }  
    }
}
