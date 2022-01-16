using System.Data;

namespace SchoolForms
{
    public partial class Form1 : Form
    {
        ExcelHandler ExcelHandler;
        DataHandler DataHandler;
        public Form1()
        {
            InitializeComponent();
        }

        private void tsmiOpen_Click(object sender, EventArgs e)
        {
            string processStatus;
            string[] fullNameColumns = { "Nombres", "Apellido Materno", "Apellido Paterno" };
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

            nudKeyIndexGenerator_ValueChanged(sender,e);
        }

        private void nudKeyIndexGenerator_ValueChanged(object sender, EventArgs e)
        {
            int algo = (int)nudKeyIndexGenerator.Value;
        }
    }
}