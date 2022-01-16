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

        private void tsmiAbrir_Click(object sender, EventArgs e)
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
            gphValues    = DataHandler.getGraphValues();
            gphPositions = DataHandler.getGraphPositions();
            gphLabels    = DataHandler.getGraphLabels();

            frmGraph.Plot.AddBar(gphValues, gphPositions);
            frmGraph.Plot.XTicks(gphPositions, gphLabels);
            frmGraph.Plot.SetAxisLimits(yMin: 0);
            frmGraph.Refresh();
        }
    }
}