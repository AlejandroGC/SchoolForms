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
            this.tsmiFile = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.tabPanel = new System.Windows.Forms.TabControl();
            this.tp1RawData = new System.Windows.Forms.TabPage();
            this.dgvExcelInfo = new System.Windows.Forms.DataGridView();
            this.tp2Graphs = new System.Windows.Forms.TabPage();
            this.frmGraph = new ScottPlot.FormsPlot();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBestStudent = new System.Windows.Forms.TextBox();
            this.txtWorstStudent = new System.Windows.Forms.TextBox();
            this.txtAverage = new System.Windows.Forms.TextBox();
            this.nudKeyIndexGenerator = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.tabPanel.SuspendLayout();
            this.tp1RawData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExcelInfo)).BeginInit();
            this.tp2Graphs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudKeyIndexGenerator)).BeginInit();
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
            this.tsmiFile});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1007, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tsmiFile
            // 
            this.tsmiFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiOpen});
            this.tsmiFile.Name = "tsmiFile";
            this.tsmiFile.Size = new System.Drawing.Size(37, 20);
            this.tsmiFile.Text = "File";
            // 
            // tsmiOpen
            // 
            this.tsmiOpen.Name = "tsmiOpen";
            this.tsmiOpen.Size = new System.Drawing.Size(103, 22);
            this.tsmiOpen.Text = "Open";
            this.tsmiOpen.Click += new System.EventHandler(this.tsmiOpen_Click);
            // 
            // tabPanel
            // 
            this.tabPanel.Controls.Add(this.tp1RawData);
            this.tabPanel.Controls.Add(this.tp2Graphs);
            this.tabPanel.Location = new System.Drawing.Point(0, 27);
            this.tabPanel.Name = "tabPanel";
            this.tabPanel.SelectedIndex = 0;
            this.tabPanel.Size = new System.Drawing.Size(859, 412);
            this.tabPanel.TabIndex = 3;
            // 
            // tp1RawData
            // 
            this.tp1RawData.Controls.Add(this.dgvExcelInfo);
            this.tp1RawData.Location = new System.Drawing.Point(4, 24);
            this.tp1RawData.Name = "tp1RawData";
            this.tp1RawData.Padding = new System.Windows.Forms.Padding(3);
            this.tp1RawData.Size = new System.Drawing.Size(851, 384);
            this.tp1RawData.TabIndex = 0;
            this.tp1RawData.Text = "Raw Data";
            this.tp1RawData.UseVisualStyleBackColor = true;
            // 
            // dgvExcelInfo
            // 
            this.dgvExcelInfo.AllowUserToAddRows = false;
            this.dgvExcelInfo.AllowUserToDeleteRows = false;
            this.dgvExcelInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvExcelInfo.Location = new System.Drawing.Point(0, 3);
            this.dgvExcelInfo.Name = "dgvExcelInfo";
            this.dgvExcelInfo.ReadOnly = true;
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
            this.tp2Graphs.Size = new System.Drawing.Size(851, 384);
            this.tp2Graphs.TabIndex = 1;
            this.tp2Graphs.Text = "Graphs";
            this.tp2Graphs.UseVisualStyleBackColor = true;
            // 
            // frmGraph
            // 
            this.frmGraph.Enabled = false;
            this.frmGraph.Location = new System.Drawing.Point(4, 3);
            this.frmGraph.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.frmGraph.Name = "frmGraph";
            this.frmGraph.Size = new System.Drawing.Size(843, 378);
            this.frmGraph.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(865, 231);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 15);
            this.label3.TabIndex = 14;
            this.label3.Text = "Average Calification";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(865, 174);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 15);
            this.label2.TabIndex = 13;
            this.label2.Text = "Worst Student Found";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(865, 116);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 15);
            this.label1.TabIndex = 12;
            this.label1.Text = "Best Student Found";
            // 
            // txtBestStudent
            // 
            this.txtBestStudent.Location = new System.Drawing.Point(865, 134);
            this.txtBestStudent.Name = "txtBestStudent";
            this.txtBestStudent.ReadOnly = true;
            this.txtBestStudent.Size = new System.Drawing.Size(130, 23);
            this.txtBestStudent.TabIndex = 15;
            // 
            // txtWorstStudent
            // 
            this.txtWorstStudent.Location = new System.Drawing.Point(865, 192);
            this.txtWorstStudent.Name = "txtWorstStudent";
            this.txtWorstStudent.ReadOnly = true;
            this.txtWorstStudent.Size = new System.Drawing.Size(130, 23);
            this.txtWorstStudent.TabIndex = 16;
            // 
            // txtAverage
            // 
            this.txtAverage.Location = new System.Drawing.Point(865, 249);
            this.txtAverage.Name = "txtAverage";
            this.txtAverage.ReadOnly = true;
            this.txtAverage.Size = new System.Drawing.Size(130, 23);
            this.txtAverage.TabIndex = 17;
            // 
            // nudKeyIndexGenerator
            // 
            this.nudKeyIndexGenerator.Location = new System.Drawing.Point(865, 74);
            this.nudKeyIndexGenerator.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.nudKeyIndexGenerator.Minimum = new decimal(new int[] {
            30,
            0,
            0,
            -2147483648});
            this.nudKeyIndexGenerator.Name = "nudKeyIndexGenerator";
            this.nudKeyIndexGenerator.Size = new System.Drawing.Size(130, 23);
            this.nudKeyIndexGenerator.TabIndex = 18;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(865, 54);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(113, 15);
            this.label4.TabIndex = 19;
            this.label4.Text = "Key Index Generator";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1007, 441);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.nudKeyIndexGenerator);
            this.Controls.Add(this.txtAverage);
            this.Controls.Add(this.txtWorstStudent);
            this.Controls.Add(this.txtBestStudent);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
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
            ((System.ComponentModel.ISupportInitialize)(this.nudKeyIndexGenerator)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private OpenFileDialog ofdAbrir;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem tsmiFile;
        private ToolStripMenuItem tsmiOpen;
        private TabControl tabPanel;
        private TabPage tp1RawData;
        private DataGridView dgvExcelInfo;
        private TabPage tp2Graphs;
        private Label label3;
        private Label label2;
        private Label label1;
        private ScottPlot.FormsPlot frmGraph;
        private TextBox txtBestStudent;
        private TextBox txtWorstStudent;
        private TextBox txtAverage;
        private NumericUpDown nudKeyIndexGenerator;
        private Label label4;
    }
}