using SchoolForms.JsonObjects;
using System.Data;
using System.Diagnostics;

namespace SchoolForms
{
    public partial class Form1 : Form
    {
        ExcelHandler excelHandler;
        DataHandler dataHandler;
        WeatherApiHandler weatherApi;
        string[] fullNameColumns = { "Nombres", "Apellido Materno", "Apellido Paterno" };
        string[] keyGenColumns   = { "Nombres", "Apellido Materno", "Fecha de Nacimiento" };
        bool tableLoaded = false;
        public Form1()
        {
            InitializeComponent();
            excelHandler = new ExcelHandler();
            weatherApi   = new WeatherApiHandler();
        }

        private void tsmiOpen_Click(object sender, EventArgs e)
        {
            string processStatus;
            double[] gphValues;
            double[] gphPositions;
            string[] gphLabels;

            // Load Excel File into the solution
            if (ofdAbrir.ShowDialog() == DialogResult.OK)
            {
                processStatus = excelHandler.LoadExcelFile(ofdAbrir.FileName);
                if (processStatus != "Success")
                {
                    MessageBox.Show(processStatus, "Something went wrong", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                dgvExcelInfo.DataSource = excelHandler.getDataTable();
            }
            // Generate calculations for the Graphs generation
            dataHandler   = new DataHandler(excelHandler.getDataTable(), "Nombres", "Calificacion");
            processStatus = dataHandler.LoadGraphicsData();
            if (processStatus != "Success")
            {
                MessageBox.Show(processStatus, "Something went wrong", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            gphValues    = dataHandler.GetGraphValues();
            gphPositions = dataHandler.GetGraphPositions();
            gphLabels    = dataHandler.GetGraphLabels();

            frmGraph.Plot.AddBar(gphValues, gphPositions);
            frmGraph.Plot.XTicks(gphPositions, gphLabels);
            frmGraph.Plot.SetAxisLimits(yMin: 0);
            frmGraph.Refresh();

            // Show the result
            txtBestStudent.Text  = dataHandler.GetBestStudentName(fullNameColumns);
            txtWorstStudent.Text = dataHandler.GetWorstStudentName(fullNameColumns);
            txtAverage.Text      = dataHandler.GetValuesAverage().ToString();

            tableLoaded = true;
            nudKeyIndexGenerator_ValueChanged(sender,e);
        }

        private void nudKeyIndexGenerator_ValueChanged(object sender, EventArgs e)
        {
            if (true == tableLoaded)
            {
                int keyIdx = (int)nudKeyIndexGenerator.Value;
                DataTable dt = excelHandler.getDataTable();
                int keyCol = dt.Columns.Count - 1;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dt.Rows[i][keyCol] = dataHandler.GetKeyGenValues(dt.Rows[i], keyGenColumns, keyIdx);
                }
                dgvExcelInfo.DataSource = dt;
            }
        }

        private async void btnWeather_Click(object sender, EventArgs e)
        {
            try
            {
                var weather = await weatherApi.GetWeather("Hermosillo");
                txtWeather.Text = $"{weather}°C";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Something went wrong", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}