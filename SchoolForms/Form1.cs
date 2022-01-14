using Excel;
using System.Data;

namespace SchoolForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void tsmiAbrir_Click(object sender, EventArgs e)
        {
            DataSet dsExcel;
            FileStream fileStream;
            IExcelDataReader excelDataReader;

            if (ofdAbrir.ShowDialog() == DialogResult.OK)
            {
                fileStream = File.Open(ofdAbrir.FileName, FileMode.Open, FileAccess.Read);
                excelDataReader = ExcelReaderFactory.CreateBinaryReader(fileStream);
                excelDataReader.IsFirstRowAsColumnNames = true;
                dsExcel = excelDataReader.AsDataSet();

                if (dsExcel != null)
                {
                    dgvExcelInfo.DataSource = dsExcel.Tables[0];
                }
                else
                {
                    // TODO: throw an error/warning letting the user know the content is not in the expected format
                }
            }
        }
    }
}