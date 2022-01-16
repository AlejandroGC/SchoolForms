using System.Data;

namespace SchoolForms
{
    public partial class Form1 : Form
    {
        ExcelHandler ExcelHandler;
        DataHandler DataHandler;
        string[] fullNameColumns = { "Nombres", "Apellido Materno", "Apellido Paterno" };
        string[] keyGenColumns   = { "Nombres", "Apellido Materno", "Fecha de Nacimiento" };
        bool tableLoaded = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void tsmiOpen_Click(object sender, EventArgs e)
        {
            string processStatus;
            double[] gphValues;
            double[] gphPositions;
            string[] gphLabels;
            ExcelHandler  = new ExcelHandler();
            if (ofdAbrir.ShowDialog() == DialogResult.OK)
            {
                processStatus = ExcelHandler.LoadExcelFile(ofdAbrir.FileName);
                if (processStatus != "Success")
                {
                    // TODO: throw an error/warning letting the user know the content
                    // is not in the expected format
                    return;
                }
                dgvExcelInfo.DataSource = ExcelHandler.getDataTable();
            }
            DataHandler   = new DataHandler(ExcelHandler.getDataTable(), "Nombres", "Calificacion");
            processStatus = DataHandler.LoadGraphicsData();
            if (processStatus != "Success")
            {
                // TODO: throw an error/warning letting the user know the content is not
                // in the expected format
                return;
            }
            gphValues    = DataHandler.GetGraphValues();
            gphPositions = DataHandler.GetGraphPositions();
            gphLabels    = DataHandler.GetGraphLabels();

            frmGraph.Plot.AddBar(gphValues, gphPositions);
            frmGraph.Plot.XTicks(gphPositions, gphLabels);
            frmGraph.Plot.SetAxisLimits(yMin: 0);
            frmGraph.Refresh();

            txtBestStudent.Text  = DataHandler.GetBestStudentName(fullNameColumns);
            txtWorstStudent.Text = DataHandler.GetWorstStudentName(fullNameColumns);
            txtAverage.Text      = DataHandler.GetValuesAverage().ToString();

            tableLoaded = true;
            nudKeyIndexGenerator_ValueChanged(sender,e);
        }

        private void nudKeyIndexGenerator_ValueChanged(object sender, EventArgs e)
        {
            if (true == tableLoaded)
            {
                int keyIdx = (int)nudKeyIndexGenerator.Value;
                DataTable dt = ExcelHandler.getDataTable();
                int keyCol = dt.Columns.Count - 1;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dt.Rows[i][keyCol] = DataHandler.GetKeyGenValues(dt.Rows[i], keyGenColumns, keyIdx);
                }
                dgvExcelInfo.DataSource = dt;
            }
        }
    }
}