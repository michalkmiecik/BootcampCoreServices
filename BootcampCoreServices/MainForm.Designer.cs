namespace BootcampCoreServices
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ofd = new System.Windows.Forms.OpenFileDialog();
            this.btnOpenFile = new System.Windows.Forms.Button();
            this.cbOptions = new System.Windows.Forms.ComboBox();
            this.btnGenerateReport = new System.Windows.Forms.Button();
            this.txtClientID = new System.Windows.Forms.TextBox();
            this.lblClientID = new System.Windows.Forms.Label();
            this.btnExport = new System.Windows.Forms.Button();
            this.panelClientID = new System.Windows.Forms.Panel();
            this.gbReportOptions = new System.Windows.Forms.GroupBox();
            this.gbRange = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtMax = new System.Windows.Forms.TextBox();
            this.txtMin = new System.Windows.Forms.TextBox();
            this.sfd = new System.Windows.Forms.SaveFileDialog();
            this.dgvReport = new System.Windows.Forms.DataGridView();
            this.panelClientID.SuspendLayout();
            this.gbReportOptions.SuspendLayout();
            this.gbRange.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReport)).BeginInit();
            this.SuspendLayout();
            // 
            // ofd
            // 
            this.ofd.Filter = "XML, JSON, CSV files|*.xml;*.json;*.csv|XML files|*.xml|JSON files|*.json|CSV fil" +
    "es|*.csv";
            this.ofd.Multiselect = true;
            this.ofd.Title = "Select file with data";
            // 
            // btnOpenFile
            // 
            this.btnOpenFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnOpenFile.Location = new System.Drawing.Point(12, 12);
            this.btnOpenFile.Name = "btnOpenFile";
            this.btnOpenFile.Size = new System.Drawing.Size(215, 33);
            this.btnOpenFile.TabIndex = 4;
            this.btnOpenFile.Text = "Wybierz pliki...";
            this.btnOpenFile.UseVisualStyleBackColor = true;
            this.btnOpenFile.Click += new System.EventHandler(this.btnOpenFile_Click);
            // 
            // cbOptions
            // 
            this.cbOptions.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbOptions.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbOptions.DropDownWidth = 500;
            this.cbOptions.FormattingEnabled = true;
            this.cbOptions.Items.AddRange(new object[] {
            "Ilość zamówień",
            "Ilość zamówień dla klienta o wskazanym identyfikatorze",
            "Łączna kwota zamówień",
            "Łączna kwota zamówień dla klienta o wskazanym identyfikatorze",
            "Lista wszystkich zamówień",
            "Lista zamówień dla klienta o wskazanym identyfikatorze",
            "Średnia wartość zamówienia",
            "Średnia wartość zamówienia dla klienta o wskazanym identyfikatorze",
            "Ilość zamówień pogrupowanych po nazwie",
            "Ilość zamówień pogrupowanych po nazwie dla klienta o wskazanym identyfikatorze",
            "Zamówienia w podanym przedziale cenowym"});
            this.cbOptions.Location = new System.Drawing.Point(6, 19);
            this.cbOptions.Name = "cbOptions";
            this.cbOptions.Size = new System.Drawing.Size(203, 24);
            this.cbOptions.TabIndex = 1;
            this.cbOptions.SelectedIndexChanged += new System.EventHandler(this.cbOptions_SelectedIndexChanged);
            // 
            // btnGenerateReport
            // 
            this.btnGenerateReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnGenerateReport.Location = new System.Drawing.Point(6, 141);
            this.btnGenerateReport.Name = "btnGenerateReport";
            this.btnGenerateReport.Size = new System.Drawing.Size(203, 33);
            this.btnGenerateReport.TabIndex = 2;
            this.btnGenerateReport.Text = "Generuj raport";
            this.btnGenerateReport.UseVisualStyleBackColor = true;
            this.btnGenerateReport.Click += new System.EventHandler(this.btnGenerateReport_Click);
            // 
            // txtClientID
            // 
            this.txtClientID.Location = new System.Drawing.Point(105, 3);
            this.txtClientID.Name = "txtClientID";
            this.txtClientID.Size = new System.Drawing.Size(95, 23);
            this.txtClientID.TabIndex = 1;
            // 
            // lblClientID
            // 
            this.lblClientID.AutoSize = true;
            this.lblClientID.Location = new System.Drawing.Point(33, 6);
            this.lblClientID.Name = "lblClientID";
            this.lblClientID.Size = new System.Drawing.Size(66, 17);
            this.lblClientID.TabIndex = 0;
            this.lblClientID.Text = "ID klienta";
            // 
            // btnExport
            // 
            this.btnExport.Enabled = false;
            this.btnExport.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnExport.Location = new System.Drawing.Point(6, 180);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(203, 33);
            this.btnExport.TabIndex = 1;
            this.btnExport.Text = "Zapisz raport";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // panelClientID
            // 
            this.panelClientID.Controls.Add(this.lblClientID);
            this.panelClientID.Controls.Add(this.txtClientID);
            this.panelClientID.Location = new System.Drawing.Point(6, 49);
            this.panelClientID.Name = "panelClientID";
            this.panelClientID.Size = new System.Drawing.Size(203, 29);
            this.panelClientID.TabIndex = 3;
            this.panelClientID.Visible = false;
            // 
            // gbReportOptions
            // 
            this.gbReportOptions.Controls.Add(this.gbRange);
            this.gbReportOptions.Controls.Add(this.cbOptions);
            this.gbReportOptions.Controls.Add(this.btnExport);
            this.gbReportOptions.Controls.Add(this.btnGenerateReport);
            this.gbReportOptions.Controls.Add(this.panelClientID);
            this.gbReportOptions.Enabled = false;
            this.gbReportOptions.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.gbReportOptions.Location = new System.Drawing.Point(12, 72);
            this.gbReportOptions.Name = "gbReportOptions";
            this.gbReportOptions.Size = new System.Drawing.Size(215, 223);
            this.gbReportOptions.TabIndex = 0;
            this.gbReportOptions.TabStop = false;
            this.gbReportOptions.Text = "Wybierz raport";
            // 
            // gbRange
            // 
            this.gbRange.Controls.Add(this.label2);
            this.gbRange.Controls.Add(this.label1);
            this.gbRange.Controls.Add(this.txtMax);
            this.gbRange.Controls.Add(this.txtMin);
            this.gbRange.Location = new System.Drawing.Point(6, 49);
            this.gbRange.Name = "gbRange";
            this.gbRange.Size = new System.Drawing.Size(203, 86);
            this.gbRange.TabIndex = 0;
            this.gbRange.TabStop = false;
            this.gbRange.Text = "Zakres";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(73, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "Do";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(73, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Od";
            // 
            // txtMax
            // 
            this.txtMax.Location = new System.Drawing.Point(105, 49);
            this.txtMax.Name = "txtMax";
            this.txtMax.Size = new System.Drawing.Size(92, 23);
            this.txtMax.TabIndex = 2;
            // 
            // txtMin
            // 
            this.txtMin.Location = new System.Drawing.Point(105, 20);
            this.txtMin.Name = "txtMin";
            this.txtMin.Size = new System.Drawing.Size(92, 23);
            this.txtMin.TabIndex = 3;
            // 
            // sfd
            // 
            this.sfd.DefaultExt = "txt";
            this.sfd.Filter = "CSV File (*.csv)|*.csv";
            // 
            // dgvReport
            // 
            this.dgvReport.AllowUserToAddRows = false;
            this.dgvReport.AllowUserToDeleteRows = false;
            this.dgvReport.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReport.Location = new System.Drawing.Point(233, 12);
            this.dgvReport.Name = "dgvReport";
            this.dgvReport.ReadOnly = true;
            this.dgvReport.RowTemplate.Height = 25;
            this.dgvReport.Size = new System.Drawing.Size(555, 426);
            this.dgvReport.TabIndex = 5;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgvReport);
            this.Controls.Add(this.gbReportOptions);
            this.Controls.Add(this.btnOpenFile);
            this.MinimumSize = new System.Drawing.Size(816, 488);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "XML JSON CSV reader";
            this.panelClientID.ResumeLayout(false);
            this.panelClientID.PerformLayout();
            this.gbReportOptions.ResumeLayout(false);
            this.gbRange.ResumeLayout(false);
            this.gbRange.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReport)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog ofd;
        private System.Windows.Forms.Button btnOpenFile;
        private System.Windows.Forms.ComboBox cbOptions;
        private System.Windows.Forms.Button btnGenerateReport;
        private System.Windows.Forms.TextBox txtClientID;
        private System.Windows.Forms.Label lblClientID;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Panel panelClientID;
        private System.Windows.Forms.GroupBox gbReportOptions;
        private System.Windows.Forms.GroupBox gbRange;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMax;
        private System.Windows.Forms.TextBox txtMin;
        private System.Windows.Forms.SaveFileDialog sfd;
        private System.Windows.Forms.DataGridView dgvReport;
    }
}

