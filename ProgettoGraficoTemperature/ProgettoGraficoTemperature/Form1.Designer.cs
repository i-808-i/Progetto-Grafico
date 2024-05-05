namespace ProgettoGraficoTemperature
{
    partial class Form1
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.btn_import = new System.Windows.Forms.Button();
            this.chkList_Luoghi = new System.Windows.Forms.CheckedListBox();
            this.dtTime_Da = new System.Windows.Forms.DateTimePicker();
            this.dtTime_A = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.LineChart_Temp = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.LineChart_Temp)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_import
            // 
            this.btn_import.Location = new System.Drawing.Point(12, 12);
            this.btn_import.Name = "btn_import";
            this.btn_import.Size = new System.Drawing.Size(87, 34);
            this.btn_import.TabIndex = 0;
            this.btn_import.Text = "Importa";
            this.btn_import.UseVisualStyleBackColor = true;
            this.btn_import.Click += new System.EventHandler(this.btn_import_Click);
            // 
            // chkList_Luoghi
            // 
            this.chkList_Luoghi.FormattingEnabled = true;
            this.chkList_Luoghi.Location = new System.Drawing.Point(12, 217);
            this.chkList_Luoghi.Name = "chkList_Luoghi";
            this.chkList_Luoghi.Size = new System.Drawing.Size(200, 556);
            this.chkList_Luoghi.TabIndex = 1;
            this.chkList_Luoghi.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.chkList_Luoghi_ItemCheck);
            // 
            // dtTime_Da
            // 
            this.dtTime_Da.Location = new System.Drawing.Point(12, 88);
            this.dtTime_Da.Name = "dtTime_Da";
            this.dtTime_Da.Size = new System.Drawing.Size(200, 26);
            this.dtTime_Da.TabIndex = 2;
            this.dtTime_Da.ValueChanged += new System.EventHandler(this.dtTime_Da_ValueChanged);
            // 
            // dtTime_A
            // 
            this.dtTime_A.Location = new System.Drawing.Point(12, 151);
            this.dtTime_A.Name = "dtTime_A";
            this.dtTime_A.Size = new System.Drawing.Size(200, 26);
            this.dtTime_A.TabIndex = 3;
            this.dtTime_A.ValueChanged += new System.EventHandler(this.dtTime_A_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Da:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 128);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(24, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "A:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 194);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "Dove:";
            // 
            // LineChart_Temp
            // 
            chartArea3.Name = "ChartArea1";
            this.LineChart_Temp.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.LineChart_Temp.Legends.Add(legend3);
            this.LineChart_Temp.Location = new System.Drawing.Point(234, 12);
            this.LineChart_Temp.Name = "LineChart_Temp";
            this.LineChart_Temp.Size = new System.Drawing.Size(973, 742);
            this.LineChart_Temp.TabIndex = 7;
            this.LineChart_Temp.Text = "chart1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1219, 781);
            this.Controls.Add(this.LineChart_Temp);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtTime_A);
            this.Controls.Add(this.dtTime_Da);
            this.Controls.Add(this.chkList_Luoghi);
            this.Controls.Add(this.btn_import);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.LineChart_Temp)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_import;
        private System.Windows.Forms.CheckedListBox chkList_Luoghi;
        private System.Windows.Forms.DateTimePicker dtTime_Da;
        private System.Windows.Forms.DateTimePicker dtTime_A;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataVisualization.Charting.Chart LineChart_Temp;
    }
}

