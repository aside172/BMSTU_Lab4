
namespace IrisOpener
{
    partial class IrisVectorsOpener
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea5 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend5 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea6 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend6 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea7 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend7 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.chart_slength = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.button1 = new System.Windows.Forms.Button();
            this.chart_swidth = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chart_plength = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chart_pwidth = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartpie = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label1 = new System.Windows.Forms.Label();
            this.FilePathLabel = new System.Windows.Forms.TextBox();
            this.chartSqrt = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartDisp = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.chart_slength)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart_swidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart_plength)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart_pwidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartpie)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartSqrt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartDisp)).BeginInit();
            this.SuspendLayout();
            // 
            // chart_slength
            // 
            chartArea1.Name = "ChartArea1";
            this.chart_slength.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart_slength.Legends.Add(legend1);
            this.chart_slength.Location = new System.Drawing.Point(16, 15);
            this.chart_slength.Margin = new System.Windows.Forms.Padding(4);
            this.chart_slength.Name = "chart_slength";
            this.chart_slength.Size = new System.Drawing.Size(560, 731);
            this.chart_slength.TabIndex = 0;
            this.chart_slength.Text = "chart1";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(2172, 1112);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(377, 104);
            this.button1.TabIndex = 1;
            this.button1.Text = "Open file";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // chart_swidth
            // 
            chartArea2.Name = "ChartArea1";
            this.chart_swidth.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chart_swidth.Legends.Add(legend2);
            this.chart_swidth.Location = new System.Drawing.Point(584, 15);
            this.chart_swidth.Margin = new System.Windows.Forms.Padding(4);
            this.chart_swidth.Name = "chart_swidth";
            this.chart_swidth.Size = new System.Drawing.Size(620, 731);
            this.chart_swidth.TabIndex = 2;
            this.chart_swidth.Text = "chart1";
            // 
            // chart_plength
            // 
            chartArea3.Name = "ChartArea1";
            this.chart_plength.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.chart_plength.Legends.Add(legend3);
            this.chart_plength.Location = new System.Drawing.Point(1212, 15);
            this.chart_plength.Margin = new System.Windows.Forms.Padding(4);
            this.chart_plength.Name = "chart_plength";
            this.chart_plength.Size = new System.Drawing.Size(701, 731);
            this.chart_plength.TabIndex = 3;
            this.chart_plength.Text = "chart2";
            // 
            // chart_pwidth
            // 
            chartArea4.Name = "ChartArea1";
            this.chart_pwidth.ChartAreas.Add(chartArea4);
            legend4.Name = "Legend1";
            this.chart_pwidth.Legends.Add(legend4);
            this.chart_pwidth.Location = new System.Drawing.Point(1921, 15);
            this.chart_pwidth.Margin = new System.Windows.Forms.Padding(4);
            this.chart_pwidth.Name = "chart_pwidth";
            this.chart_pwidth.Size = new System.Drawing.Size(628, 731);
            this.chart_pwidth.TabIndex = 4;
            this.chart_pwidth.Text = "chart3";
            // 
            // chartpie
            // 
            chartArea5.Name = "ChartArea1";
            this.chartpie.ChartAreas.Add(chartArea5);
            legend5.Name = "Legend1";
            this.chartpie.Legends.Add(legend5);
            this.chartpie.Location = new System.Drawing.Point(16, 754);
            this.chartpie.Margin = new System.Windows.Forms.Padding(4);
            this.chartpie.Name = "chartpie";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartpie.Series.Add(series1);
            this.chartpie.Size = new System.Drawing.Size(611, 502);
            this.chartpie.TabIndex = 5;
            this.chartpie.Text = "chart";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1883, 1078);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 25);
            this.label1.TabIndex = 6;
            this.label1.Text = "File Path:";
            // 
            // FilePathLabel
            // 
            this.FilePathLabel.Location = new System.Drawing.Point(1994, 1072);
            this.FilePathLabel.Margin = new System.Windows.Forms.Padding(4);
            this.FilePathLabel.Name = "FilePathLabel";
            this.FilePathLabel.ReadOnly = true;
            this.FilePathLabel.Size = new System.Drawing.Size(554, 31);
            this.FilePathLabel.TabIndex = 7;
            // 
            // chartSqrt
            // 
            chartArea6.Name = "ChartArea1";
            this.chartSqrt.ChartAreas.Add(chartArea6);
            legend6.Name = "Legend1";
            this.chartSqrt.Legends.Add(legend6);
            this.chartSqrt.Location = new System.Drawing.Point(644, 754);
            this.chartSqrt.Margin = new System.Windows.Forms.Padding(4);
            this.chartSqrt.Name = "chartSqrt";
            this.chartSqrt.Size = new System.Drawing.Size(521, 486);
            this.chartSqrt.TabIndex = 2;
            this.chartSqrt.Text = "chart1";
            // 
            // chartDisp
            // 
            chartArea7.Name = "ChartArea1";
            this.chartDisp.ChartAreas.Add(chartArea7);
            legend7.Name = "Legend1";
            this.chartDisp.Legends.Add(legend7);
            this.chartDisp.Location = new System.Drawing.Point(1185, 754);
            this.chartDisp.Margin = new System.Windows.Forms.Padding(4);
            this.chartDisp.Name = "chartDisp";
            this.chartDisp.Size = new System.Drawing.Size(521, 486);
            this.chartDisp.TabIndex = 2;
            this.chartDisp.Text = "chart1";
            // 
            // IrisVectorsOpener
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2564, 1264);
            this.Controls.Add(this.FilePathLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chartpie);
            this.Controls.Add(this.chart_pwidth);
            this.Controls.Add(this.chart_plength);
            this.Controls.Add(this.chartDisp);
            this.Controls.Add(this.chartSqrt);
            this.Controls.Add(this.chart_swidth);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.chart_slength);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "IrisVectorsOpener";
            this.Text = "Iris Vectors Opener";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.chart_slength)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart_swidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart_plength)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart_pwidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartpie)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartSqrt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartDisp)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart_slength;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart_swidth;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart_plength;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart_pwidth;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartpie;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox FilePathLabel;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartSqrt;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartDisp;
    }
}

