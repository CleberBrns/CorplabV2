using Excel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btUpload_Click(object sender, EventArgs e)
    {
        if (fUpload.HasFile)
        {
            RotinaLeituraArquivo();
        }
        else
        {

        }

    }

    private void RotinaLeituraArquivo()
    {
        string Extension = System.IO.Path.GetExtension(fUpload.FileName);

        if (Extension.ToLower() == ".xls" || Extension.ToLower() == ".xlsx")
        {
            string FileName = Server.HtmlEncode(fUpload.FileName);
            string caminhoArquivo = string.Empty;
            string camanhoDestino = Server.MapPath("/ArquivosTemp/");

            if (Directory.Exists(camanhoDestino))
            {
                string arquivoComCaminho = camanhoDestino + fUpload.FileName;
                fUpload.SaveAs(arquivoComCaminho);

                if (File.Exists(arquivoComCaminho))
                {
                    using (FileStream stream = File.Open(arquivoComCaminho, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                    {
                        IExcelDataReader excelReader;

                        if (Extension.ToLower() == ".xls")
                        {
                            //Reading from a binary Excel file ('97-2003 format; *.xls)
                            excelReader = ExcelReaderFactory.CreateBinaryReader(stream);
                        }
                        else
                        {
                            //Reading from a OpenXml Excel file (2007 format; *.xlsx)
                            excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);
                        }
                        
                        //DataSet - Create column names from first row
                        excelReader.IsFirstRowAsColumnNames = true;
                        DataSet dsResult = excelReader.AsDataSet();                       

                        //Free resources (IExcelDataReader is IDisposable)
                        excelReader.Close();
                    }

                    File.Delete(arquivoComCaminho);
                }
            }

        }
        else
        {
            //"Formato de arquivo inválido!"
        }
    }
}