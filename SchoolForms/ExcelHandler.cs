using Excel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolForms
{
    public class ExcelHandler
    {
        DataTable _excelDataTable;
        public ExcelHandler()
        {
            _excelDataTable = new DataTable();
        }

        /// <summary>
        /// Takes a 97-03 Excel Workbook File [*.xls] and reads it.
        /// Expects excel file to contain table of information that will be stored
        /// in an internal DataTable of the class
        /// </summary>
        /// <param name="FilePath">Path of the Excel File that is expected to be loaded</param>
        /// <returns> status message of the operation upon finalization </returns>
        public string LoadExcelFile(string FilePath)
        {
            DataSet dsExcel;
            FileStream fileStream;
            IExcelDataReader excelDataReader;

            fileStream      = File.Open(FilePath, FileMode.Open, FileAccess.Read);
            excelDataReader = ExcelReaderFactory.CreateBinaryReader(fileStream);
            excelDataReader.IsFirstRowAsColumnNames = true;
            dsExcel         = excelDataReader.AsDataSet();
            dsExcel.Tables[0].Columns.Add("Clave", typeof(string));
            _excelDataTable = dsExcel.Tables[0];

            if (_excelDataTable == null)
            {
                return "Error";
            }
            else
            {
                return "Success";
            }
        }

        /// <summary>
        /// setter of DataTable populated upon loading an Excel File with the function LoadExcelFile
        /// </summary>
        /// <returns>Returns the DataTable loaded with LoadExcelFile. Returns Null if that function has not been called beforehand</returns>
        public DataTable getDataTable()
        {
            return _excelDataTable;
        }
    }
}
