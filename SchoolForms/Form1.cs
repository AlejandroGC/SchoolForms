using System.Data;

namespace SchoolForms
{
    public partial class Form1 : Form
    {
        ExcelHandler ExcelHandler;
        GraphicsHandler GraphicsHandler;
        public Form1()
        {
            InitializeComponent();
            ExcelHandler = new ExcelHandler();
            GraphicsHandler = new GraphicsHandler();

        }

        private void tsmiAbrir_Click(object sender, EventArgs e)
        {
            string processStatus;
            double[] gphValues;
            double[] gphPositions;
            string[] gphLabels;
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

            processStatus = GraphicsHandler.LoadGraphicsData(
                ExcelHandler.getDataTable(), "Nombres", "Calificacion"
            );
            if (processStatus != "Success")
            {
                // TODO: throw an error/warning letting the user know the content is not
                // in the expected format
                return;
            }
            gphValues    = GraphicsHandler.getGraphValues();
            gphPositions = GraphicsHandler.getGraphPositions();
            gphLabels    = GraphicsHandler.getGraphLabels();

            frmGraph.Plot.AddBar(gphValues, gphPositions);
            frmGraph.Plot.XTicks(gphPositions, gphLabels);
            frmGraph.Plot.SetAxisLimits(yMin: 0);
            frmGraph.Refresh();
        }
    }
}