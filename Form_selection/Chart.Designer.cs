
namespace ban_2.Form_selection
{
    partial class Chart
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cbbStyle = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbbStatic = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chartView = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartView)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cbbStyle);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.cbbStatic);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1032, 93);
            this.panel1.TabIndex = 0;
            // 
            // cbbStyle
            // 
            this.cbbStyle.BackColor = System.Drawing.Color.Transparent;
            this.cbbStyle.BorderRadius = 20;
            this.cbbStyle.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbbStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbStyle.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbbStyle.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbbStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cbbStyle.ItemHeight = 30;
            this.cbbStyle.Items.AddRange(new object[] {
            "Column",
            "Spline",
            "Bar",
            "Pie",
            "Doughnut"});
            this.cbbStyle.Location = new System.Drawing.Point(804, 30);
            this.cbbStyle.Name = "cbbStyle";
            this.cbbStyle.Size = new System.Drawing.Size(225, 36);
            this.cbbStyle.TabIndex = 17;
            this.cbbStyle.SelectedIndexChanged += new System.EventHandler(this.cbbStyle_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 13F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(84)))), ((int)(((byte)(122)))));
            this.label2.Location = new System.Drawing.Point(575, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(201, 30);
            this.label2.TabIndex = 17;
            this.label2.Text = "Choose chart style:";
            // 
            // cbbStatic
            // 
            this.cbbStatic.BackColor = System.Drawing.Color.Transparent;
            this.cbbStatic.BorderRadius = 20;
            this.cbbStatic.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbbStatic.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbStatic.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbbStatic.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbbStatic.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbStatic.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cbbStatic.ItemHeight = 30;
            this.cbbStatic.Items.AddRange(new object[] {
            "Department"});
            this.cbbStatic.Location = new System.Drawing.Point(243, 30);
            this.cbbStatic.Name = "cbbStatic";
            this.cbbStatic.Size = new System.Drawing.Size(296, 36);
            this.cbbStatic.TabIndex = 16;
            this.cbbStatic.SelectedIndexChanged += new System.EventHandler(this.cbbStatic_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 13F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(84)))), ((int)(((byte)(122)))));
            this.label1.Location = new System.Drawing.Point(23, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(182, 30);
            this.label1.TabIndex = 15;
            this.label1.Text = "Choose statistics:";
            // 
            // chartView
            // 
            chartArea1.Name = "ChartArea1";
            this.chartView.ChartAreas.Add(chartArea1);
            this.chartView.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Name = "Legend1";
            this.chartView.Legends.Add(legend1);
            this.chartView.Location = new System.Drawing.Point(0, 93);
            this.chartView.Name = "chartView";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartView.Series.Add(series1);
            this.chartView.Size = new System.Drawing.Size(1032, 627);
            this.chartView.TabIndex = 1;
            this.chartView.Text = "chart1";
            // 
            // Chart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.chartView);
            this.Controls.Add(this.panel1);
            this.Name = "Chart";
            this.Size = new System.Drawing.Size(1032, 720);
            this.Load += new System.EventHandler(this.Chart_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2ComboBox cbbStatic;
        private Guna.UI2.WinForms.Guna2ComboBox cbbStyle;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartView;
    }
}
