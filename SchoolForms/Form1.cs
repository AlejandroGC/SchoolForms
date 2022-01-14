using Excel;
using ScottPlot;
using ScottPlot.Plottable;
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

                if (dsExcel == null)
                {
                    // TODO: throw an error/warning letting the user know the content is not in the expected format
                }
                else
                {
                    dgvExcelInfo.DataSource = dsExcel.Tables[0];

                    // TODO: Create function that requires a DataSet as a parameter and that returns a string regarding the status of the operation
                    System.Data.DataSet dsGraph = dsExcel;
                    int NombresIdx = -1;
                    int CalificacionIdx = -1;
                    double[] values    = new double[dsGraph.Tables[0].Rows.Count];
                    double[] positions = new double[dsGraph.Tables[0].Rows.Count];
                    string[] labels    = new string[dsGraph.Tables[0].Rows.Count];
                    for (int colIdx = 0; colIdx < dsGraph.Tables[0].Columns.Count; colIdx++)
                    {
                        if (dsGraph.Tables[0].Columns[colIdx].ColumnName == "Nombres")
                        {
                            NombresIdx = colIdx;
                        }
                        if (dsGraph.Tables[0].Columns[colIdx].ColumnName == "Calificacion")
                        {
                            CalificacionIdx = colIdx;
                        }
                    }
                    for (int rowIdx = 0; rowIdx < dsGraph.Tables[0].Rows.Count; rowIdx++)
                    {
                        if ( (NombresIdx != -1) || (CalificacionIdx != -1) )
                        {
                            //return error message since we didn't find two KEY columns for this test
                        }
                        positions[rowIdx] = rowIdx;
                        labels[rowIdx] = (string) dsGraph.Tables[0].Rows[rowIdx].ItemArray[NombresIdx]!;
                        values[rowIdx] = (double) dsGraph.Tables[0].Rows[rowIdx].ItemArray[CalificacionIdx]!;
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