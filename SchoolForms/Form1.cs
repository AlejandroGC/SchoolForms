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
            System.Data.DataSet dsExcel;
            FileStream fileStream;
            IExcelDataReader excelDataReader;

            if (ofdAbrir.ShowDialog() == DialogResult.OK)
            {
                fileStream = File.Open(ofdAbrir.FileName, FileMode.Open, FileAccess.Read);
                excelDataReader = ExcelReaderFactory.CreateBinaryReader(fileStream);
                excelDataReader.IsFirstRowAsColumnNames = true;
                dsExcel = excelDataReader.AsDataSet();
                dsExcel.Tables[0].Columns.Add("Clave", typeof(string));
                if (dsExcel == null)
                {
                    // TODO: throw an error/warning letting the user know the content is not in the expected format
                }
                else
                {
                    dgvExcelInfo.DataSource = dsExcel.Tables[0];

                    // TODO: Create function that requires a DataSet as a parameter and that returns a string regarding the status of the operation
                    DataTable dtGraph = dsExcel.Tables[0];
                    int NombresIdx = -1;
                    int CalificacionIdx = -1;
                    double[] values    = new double[dtGraph.Rows.Count];
                    double[] positions = new double[dtGraph.Rows.Count];
                    string[] labels    = new string[dtGraph.Rows.Count];
                    for (int colIdx = 0; colIdx < dtGraph.Columns.Count; colIdx++)
                    {
                        if (dtGraph.Columns[colIdx].ColumnName == "Nombres")
                        {
                            NombresIdx = colIdx;
                        }
                        if (dtGraph.Columns[colIdx].ColumnName == "Calificacion")
                        {
                            CalificacionIdx = colIdx;
                        }
                    }
                    for (int rowIdx = 0; rowIdx < dtGraph.Rows.Count; rowIdx++)
                    {
                        if ( (NombresIdx == -1) || (CalificacionIdx == -1) )
                        {
                            //return error message since we didn't find two KEY columns for this test
                        }
                        positions[rowIdx] = rowIdx;
                        labels[rowIdx] = (string) dtGraph.Rows[rowIdx].ItemArray[NombresIdx]!;
                        values[rowIdx] = (double) dtGraph.Rows[rowIdx].ItemArray[CalificacionIdx]!;
                    }

                    frmGraph.Plot.AddBar(values, positions);
                    frmGraph.Plot.XTicks(positions, labels);
                    frmGraph.Plot.SetAxisLimits(yMin: 0);
                    frmGraph.Refresh();
                }
            }
        }
    }
}