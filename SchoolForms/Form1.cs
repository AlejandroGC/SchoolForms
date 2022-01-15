using System.Data;

namespace SchoolForms
{
    public partial class Form1 : Form
    {
        ExcelHandler ExcelHandler;
        public Form1()
        {
            InitializeComponent();
            ExcelHandler = new ExcelHandler();
        }

        private void tsmiAbrir_Click(object sender, EventArgs e)
        {
            string processStatus;

            if (ofdAbrir.ShowDialog() == DialogResult.OK)
            {
                processStatus = ExcelHandler.LoadExcelFile(ofdAbrir.FileName);
                if (processStatus != "Success")
                {
                    // TODO: throw an error/warning letting the user know the content is not in the expected format
                    return;
                }

                dgvExcelInfo.DataSource = ExcelHandler.getDataTable();

                // TODO: Create function that requires a DataSet as a parameter and that returns a string regarding the status of the operation
                DataTable dtGraph = ExcelHandler.getDataTable();
                int NombresIdx = -1;
                int CalificacionIdx = -1;
                double[] values = new double[dtGraph.Rows.Count];
                double[] positions = new double[dtGraph.Rows.Count];
                string[] labels = new string[dtGraph.Rows.Count];
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
                    if ((NombresIdx == -1) || (CalificacionIdx == -1))
                    {
                        //return error message since we didn't find two KEY columns for this test
                    }
                    positions[rowIdx] = rowIdx;
                    labels[rowIdx] = (string)dtGraph.Rows[rowIdx].ItemArray[NombresIdx]!;
                    values[rowIdx] = (double)dtGraph.Rows[rowIdx].ItemArray[CalificacionIdx]!;
                }

                frmGraph.Plot.AddBar(values, positions);
                frmGraph.Plot.XTicks(positions, labels);
                frmGraph.Plot.SetAxisLimits(yMin: 0);
                frmGraph.Refresh();

            }
        }
    }
}