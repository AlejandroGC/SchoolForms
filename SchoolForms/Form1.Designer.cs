namespace SchoolForms
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ofdAbrir = new System.Windows.Forms.OpenFileDialog();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tsmiArchivo = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAbrir = new System.Windows.Forms.ToolStripMenuItem();
            this.tabPanel = new System.Windows.Forms.TabControl();
            this.tp1RawData = new System.Windows.Forms.TabPage();
            this.dgvExcelInfo = new System.Windows.Forms.DataGridView();
            this.tp2Graphs = new System.Windows.Forms.TabPage();
            this.frmGraph = new ScottPlot.FormsPlot();
            this.tp3Analisis = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.tabPanel.SuspendLayout();
            this.tp1RawData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExcelInfo)).BeginInit();
            this.tp2Graphs.SuspendLayout();
            this.tp3Analisis.SuspendLayout();
            this.SuspendLayout();
            // 
            // ofdAbrir
            // 
            this.ofdAbrir.FileName = "ofdAbrir";
            this.ofdAbrir.Filter = "Archivos xlsx (*.xls) |*.xls";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiArchivo});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(860, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tsmiArchivo
            // 
            this.tsmiArchivo.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiAbrir});
            this.tsmiArchivo.Name = "tsmiArchivo";
            this.tsmiArchivo.Size = new System.Drawing.Size(60, 20);
            this.tsmiArchivo.Text = "Archivo";
            // 
            // tsmiAbrir
            // 
            this.tsmiAbrir.Name = "tsmiAbrir";
            this.tsmiAbrir.Size = new System.Drawing.Size(100, 22);
            this.tsmiAbrir.Text = "Abrir";
            this.tsmiAbrir.Click += new System.EventHandler(this.tsmiAbrir_Click);
            // 
            // tabPanel
            // 
            this.tabPanel.Controls.Add(this.tp1RawData);
            this.tabPanel.Controls.Add(this.tp2Graphs);
            this.tabPanel.Controls.Add(this.tp3Analisis);
            this.tabPanel.Location = new System.Drawing.Point(0, 27);
            this.tabPanel.Name = "tabPanel";
            this.tabPanel.SelectedIndex = 0;
            this.tabPanel.Size = new System.Drawing.Size(859, 416);
            this.tabPanel.TabIndex = 3;
            // 
            // tp1RawData
            // 
            this.tp1RawData.Controls.Add(this.dgvExcelInfo);
            this.tp1RawData.Location = new System.Drawing.Point(4, 24);
            this.tp1RawData.Name = "tp1RawData";
            this.tp1RawData.Padding = new System.Windows.Forms.Padding(3);
            this.tp1RawData.Size = new System.Drawing.Size(851, 388);
            this.tp1RawData.TabIndex = 0;
            this.tp1RawData.Text = "Raw Data";
            this.tp1RawData.UseVisualStyleBackColor = true;
            // 
            // dgvExcelInfo
            // 
            this.dgvExcelInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvExcelInfo.Location = new System.Drawing.Point(0, 3);
            this.dgvExcelInfo.Name = "dgvExcelInfo";
            this.dgvExcelInfo.RowTemplate.Height = 25;
            this.dgvExcelInfo.Size = new System.Drawing.Size(848, 380);
            this.dgvExcelInfo.TabIndex = 2;
            // 
            // tp2Graphs
            // 
            this.tp2Graphs.Controls.Add(this.frmGraph);
            this.tp2Graphs.Location = new System.Drawing.Point(4, 24);
            this.tp2Graphs.Name = "tp2Graphs";
            this.tp2Graphs.Padding = new System.Windows.Forms.Padding(3);
            this.tp2Graphs.Size = new System.Drawing.Size(851, 388);
            this.tp2Graphs.TabIndex = 1;
            this.tp2Graphs.Text = "Graphs";
            this.tp2Graphs.UseVisualStyleBackColor = true;
            // 
            // frmGraph
            // 
            this.frmGraph.Enabled = false;
            this.frmGraph.Location = new System.Drawing.Point(9, 3);
            this.frmGraph.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.frmGraph.Name = "frmGraph";
            this.frmGraph.Size = new System.Drawing.Size(835, 379);
            this.frmGraph.TabIndex = 4;
            // 
            // tp3Analisis
            // 
            this.tp3Analisis.Controls.Add(this.label6);
            this.tp3Analisis.Controls.Add(this.label5);
            this.tp3Analisis.Controls.Add(this.label4);
            this.tp3Analisis.Controls.Add(this.label3);
            this.tp3Analisis.Controls.Add(this.label2);
            this.tp3Analisis.Controls.Add(this.label1);
            this.tp3Analisis.Location = new System.Drawing.Point(4, 24);
            this.tp3Analisis.Name = "tp3Analisis";
            this.tp3Analisis.Padding = new System.Windows.Forms.Padding(3);
            this.tp3Analisis.Size = new System.Drawing.Size(851, 388);
            this.tp3Analisis.TabIndex = 2;
            this.tp3Analisis.Text = "Analisis";
            this.tp3Analisis.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(99, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "label2";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "label3";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(99, 45);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 15);
            this.label4.TabIndex = 3;
            this.label4.Text = "label4";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 83);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 15);
            this.label5.TabIndex = 4;
            this.label5.Text = "label5";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(99, 83);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 15);
            this.label6.TabIndex = 5;
            this.label6.Text = "label6";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(860, 449);
            this.Controls.Add(this.tabPanel);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "School Data Manager";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabPanel.ResumeLayout(false);
            this.tp1RawData.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvExcelInfo)).EndInit();
            this.tp2Graphs.ResumeLayout(false);
            this.tp3Analisis.ResumeLayout(false);
            this.tp3Analisis.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private OpenFileDialog ofdAbrir;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem tsmiArchivo;
        private ToolStripMenuItem tsmiAbrir;
        private TabControl tabPanel;
        private TabPage tp1RawData;
        private DataGridView dgvExcelInfo;
        private TabPage tp2Graphs;
        private ScottPlot.FormsPlot frmGraph;
        private TabPage tp3Analisis;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
    }
}