namespace ban_2.Form_selection
{
    partial class Salary
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridViewNV = new System.Windows.Forms.DataGridView();
            this.MANV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HOTEN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LUONGCOBAN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LUONGPHEP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HESOLUONG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.guna2ProgressBar1 = new Guna.UI2.WinForms.Guna2ProgressBar();
            this.tbTimL = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2ContextMenuStrip1 = new Guna.UI2.WinForms.Guna2ContextMenuStrip();
            this.label2 = new System.Windows.Forms.Label();
            this.guna2CirclePictureBox1 = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.picker = new Guna.UI2.WinForms.Guna2DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewNV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2CirclePictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewNV
            // 
            this.dataGridViewNV.AllowUserToAddRows = false;
            this.dataGridViewNV.AllowUserToDeleteRows = false;
            this.dataGridViewNV.AllowUserToResizeColumns = false;
            this.dataGridViewNV.AllowUserToResizeRows = false;
            this.dataGridViewNV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewNV.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridViewNV.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewNV.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dataGridViewNV.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(84)))), ((int)(((byte)(122)))));
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(84)))), ((int)(((byte)(122)))));
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewNV.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridViewNV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewNV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MANV,
            this.HOTEN,
            this.Column7,
            this.LUONGCOBAN,
            this.LUONGPHEP,
            this.HESOLUONG,
            this.Column6});
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Segoe UI Semibold", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewNV.DefaultCellStyle = dataGridViewCellStyle8;
            this.dataGridViewNV.EnableHeadersVisualStyles = false;
            this.dataGridViewNV.Location = new System.Drawing.Point(30, 164);
            this.dataGridViewNV.Name = "dataGridViewNV";
            this.dataGridViewNV.ReadOnly = true;
            this.dataGridViewNV.RowHeadersVisible = false;
            this.dataGridViewNV.RowHeadersWidth = 51;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(84)))), ((int)(((byte)(122)))));
            this.dataGridViewNV.RowsDefaultCellStyle = dataGridViewCellStyle9;
            this.dataGridViewNV.RowTemplate.Height = 24;
            this.dataGridViewNV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewNV.Size = new System.Drawing.Size(974, 529);
            this.dataGridViewNV.TabIndex = 1;
            this.dataGridViewNV.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewNV_CellClick);
            // 
            // MANV
            // 
            this.MANV.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.MANV.DataPropertyName = "MANV";
            this.MANV.HeaderText = "ID";
            this.MANV.MinimumWidth = 6;
            this.MANV.Name = "MANV";
            this.MANV.ReadOnly = true;
            this.MANV.Width = 57;
            // 
            // HOTEN
            // 
            this.HOTEN.DataPropertyName = "HOTEN";
            this.HOTEN.FillWeight = 150F;
            this.HOTEN.HeaderText = "Name";
            this.HOTEN.MinimumWidth = 6;
            this.HOTEN.Name = "HOTEN";
            this.HOTEN.ReadOnly = true;
            // 
            // Column7
            // 
            this.Column7.DataPropertyName = "TENCV";
            this.Column7.FillWeight = 80F;
            this.Column7.HeaderText = "Position";
            this.Column7.MinimumWidth = 6;
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            // 
            // LUONGCOBAN
            // 
            this.LUONGCOBAN.DataPropertyName = "LUONGCOBAN";
            this.LUONGCOBAN.HeaderText = "BasicPay";
            this.LUONGCOBAN.MinimumWidth = 6;
            this.LUONGCOBAN.Name = "LUONGCOBAN";
            this.LUONGCOBAN.ReadOnly = true;
            // 
            // LUONGPHEP
            // 
            this.LUONGPHEP.DataPropertyName = "LUONGPHEP";
            this.LUONGPHEP.FillWeight = 90F;
            this.LUONGPHEP.HeaderText = "Bonus";
            this.LUONGPHEP.MinimumWidth = 6;
            this.LUONGPHEP.Name = "LUONGPHEP";
            this.LUONGPHEP.ReadOnly = true;
            // 
            // HESOLUONG
            // 
            this.HESOLUONG.DataPropertyName = "HESOLUONG";
            this.HESOLUONG.FillWeight = 80F;
            this.HESOLUONG.HeaderText = "CoefSalary";
            this.HESOLUONG.MinimumWidth = 6;
            this.HESOLUONG.Name = "HESOLUONG";
            this.HESOLUONG.ReadOnly = true;
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "MALUONG";
            this.Column6.FillWeight = 110F;
            this.Column6.HeaderText = "Salary";
            this.Column6.MinimumWidth = 6;
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            // 
            // guna2ProgressBar1
            // 
            this.guna2ProgressBar1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(84)))), ((int)(((byte)(122)))));
            this.guna2ProgressBar1.Location = new System.Drawing.Point(30, 140);
            this.guna2ProgressBar1.Name = "guna2ProgressBar1";
            this.guna2ProgressBar1.Size = new System.Drawing.Size(974, 3);
            this.guna2ProgressBar1.TabIndex = 7;
            this.guna2ProgressBar1.Text = "guna2ProgressBar1";
            this.guna2ProgressBar1.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            // 
            // tbTimL
            // 
            this.tbTimL.BorderRadius = 20;
            this.tbTimL.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbTimL.DefaultText = "";
            this.tbTimL.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.tbTimL.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.tbTimL.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbTimL.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbTimL.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbTimL.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbTimL.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbTimL.Location = new System.Drawing.Point(30, 69);
            this.tbTimL.Margin = new System.Windows.Forms.Padding(4);
            this.tbTimL.Name = "tbTimL";
            this.tbTimL.PasswordChar = '\0';
            this.tbTimL.PlaceholderText = "Search";
            this.tbTimL.SelectedText = "";
            this.tbTimL.Size = new System.Drawing.Size(374, 45);
            this.tbTimL.TabIndex = 8;
            this.tbTimL.TextChanged += new System.EventHandler(this.tbTimL_TextChanged);
            // 
            // guna2ContextMenuStrip1
            // 
            this.guna2ContextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.guna2ContextMenuStrip1.Name = "guna2ContextMenuStrip1";
            this.guna2ContextMenuStrip1.RenderStyle.ArrowColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(143)))), ((int)(((byte)(255)))));
            this.guna2ContextMenuStrip1.RenderStyle.BorderColor = System.Drawing.Color.Gainsboro;
            this.guna2ContextMenuStrip1.RenderStyle.ColorTable = null;
            this.guna2ContextMenuStrip1.RenderStyle.RoundedEdges = true;
            this.guna2ContextMenuStrip1.RenderStyle.SelectionArrowColor = System.Drawing.Color.White;
            this.guna2ContextMenuStrip1.RenderStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.guna2ContextMenuStrip1.RenderStyle.SelectionForeColor = System.Drawing.Color.White;
            this.guna2ContextMenuStrip1.RenderStyle.SeparatorColor = System.Drawing.Color.Gainsboro;
            this.guna2ContextMenuStrip1.RenderStyle.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.guna2ContextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(52)))), ((int)(((byte)(88)))));
            this.label2.Location = new System.Drawing.Point(337, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(377, 54);
            this.label2.TabIndex = 12;
            this.label2.Text = "Salary Information";
            // 
            // guna2CirclePictureBox1
            // 
            this.guna2CirclePictureBox1.BackColor = System.Drawing.Color.White;
            this.guna2CirclePictureBox1.Image = global::ban_2.Properties.Resources._CITYPNG_COM_Gray_Search_Icon_Button_Transparent_PNG___512x512__1_;
            this.guna2CirclePictureBox1.ImageRotate = 0F;
            this.guna2CirclePictureBox1.Location = new System.Drawing.Point(357, 77);
            this.guna2CirclePictureBox1.Name = "guna2CirclePictureBox1";
            this.guna2CirclePictureBox1.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.guna2CirclePictureBox1.Size = new System.Drawing.Size(30, 30);
            this.guna2CirclePictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.guna2CirclePictureBox1.TabIndex = 9;
            this.guna2CirclePictureBox1.TabStop = false;
            // 
            // picker
            // 
            this.picker.BackColor = System.Drawing.Color.Transparent;
            this.picker.BorderRadius = 15;
            this.picker.Checked = true;
            this.picker.FillColor = System.Drawing.Color.White;
            this.picker.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold);
            this.picker.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.picker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.picker.Location = new System.Drawing.Point(685, 69);
            this.picker.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.picker.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.picker.Name = "picker";
            this.picker.Size = new System.Drawing.Size(319, 45);
            this.picker.TabIndex = 15;
            this.picker.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.picker.Value = new System.DateTime(2022, 5, 22, 23, 27, 0, 0);
            this.picker.ValueChanged += new System.EventHandler(this.picker_ValueChanged);
            // 
            // Salary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.picker);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.guna2CirclePictureBox1);
            this.Controls.Add(this.tbTimL);
            this.Controls.Add(this.guna2ProgressBar1);
            this.Controls.Add(this.dataGridViewNV);
            this.Name = "Salary";
            this.Size = new System.Drawing.Size(1032, 720);
            this.Load += new System.EventHandler(this.Salary_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewNV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2CirclePictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewNV;
        private Guna.UI2.WinForms.Guna2ProgressBar guna2ProgressBar1;
        private Guna.UI2.WinForms.Guna2TextBox tbTimL;
        private Guna.UI2.WinForms.Guna2CirclePictureBox guna2CirclePictureBox1;
        private Guna.UI2.WinForms.Guna2ContextMenuStrip guna2ContextMenuStrip1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn MANV;
        private System.Windows.Forms.DataGridViewTextBoxColumn HOTEN;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn LUONGCOBAN;
        private System.Windows.Forms.DataGridViewTextBoxColumn LUONGPHEP;
        private System.Windows.Forms.DataGridViewTextBoxColumn HESOLUONG;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private Guna.UI2.WinForms.Guna2DateTimePicker picker;
    }
}
