namespace ban_2
{
    partial class Add_Furrlough
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
            this.label1 = new System.Windows.Forms.Label();
            this.tbReason = new Guna.UI2.WinForms.Guna2TextBox();
            this.PickerTBack = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.PickerTOff = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btCancel = new Guna.UI2.WinForms.Guna2Button();
            this.btAdd = new Guna.UI2.WinForms.Guna2Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Gainsboro;
            this.label1.Location = new System.Drawing.Point(118, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(260, 38);
            this.label1.TabIndex = 25;
            this.label1.Text = "Add new Furlough";
            // 
            // tbReason
            // 
            this.tbReason.BorderRadius = 20;
            this.tbReason.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbReason.DefaultText = "";
            this.tbReason.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.tbReason.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.tbReason.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbReason.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbReason.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbReason.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.tbReason.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbReason.Location = new System.Drawing.Point(55, 225);
            this.tbReason.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tbReason.Name = "tbReason";
            this.tbReason.PasswordChar = '\0';
            this.tbReason.PlaceholderForeColor = System.Drawing.Color.DarkGray;
            this.tbReason.PlaceholderText = "Reason";
            this.tbReason.SelectedText = "";
            this.tbReason.Size = new System.Drawing.Size(376, 105);
            this.tbReason.TabIndex = 38;
            // 
            // PickerTBack
            // 
            this.PickerTBack.BackColor = System.Drawing.Color.Transparent;
            this.PickerTBack.BorderRadius = 20;
            this.PickerTBack.Checked = true;
            this.PickerTBack.FillColor = System.Drawing.Color.White;
            this.PickerTBack.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.PickerTBack.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.PickerTBack.Location = new System.Drawing.Point(211, 160);
            this.PickerTBack.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.PickerTBack.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.PickerTBack.Name = "PickerTBack";
            this.PickerTBack.Size = new System.Drawing.Size(220, 45);
            this.PickerTBack.TabIndex = 40;
            this.PickerTBack.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.PickerTBack.Value = new System.DateTime(2022, 4, 22, 23, 27, 36, 0);
            // 
            // PickerTOff
            // 
            this.PickerTOff.BackColor = System.Drawing.Color.Transparent;
            this.PickerTOff.BorderRadius = 20;
            this.PickerTOff.Checked = true;
            this.PickerTOff.FillColor = System.Drawing.Color.White;
            this.PickerTOff.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.PickerTOff.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.PickerTOff.Location = new System.Drawing.Point(211, 90);
            this.PickerTOff.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.PickerTOff.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.PickerTOff.Name = "PickerTOff";
            this.PickerTOff.Size = new System.Drawing.Size(220, 45);
            this.PickerTOff.TabIndex = 41;
            this.PickerTOff.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.PickerTOff.Value = new System.DateTime(2022, 4, 22, 23, 27, 36, 0);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Gainsboro;
            this.label5.Location = new System.Drawing.Point(50, 98);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(98, 28);
            this.label5.TabIndex = 42;
            this.label5.Text = "Time Off:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Gainsboro;
            this.label2.Location = new System.Drawing.Point(50, 168);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 28);
            this.label2.TabIndex = 43;
            this.label2.Text = "Time Back:";
            // 
            // btCancel
            // 
            this.btCancel.BackColor = System.Drawing.Color.Transparent;
            this.btCancel.BorderRadius = 20;
            this.btCancel.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btCancel.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btCancel.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btCancel.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btCancel.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(84)))), ((int)(((byte)(122)))));
            this.btCancel.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.btCancel.ForeColor = System.Drawing.Color.White;
            this.btCancel.Location = new System.Drawing.Point(254, 369);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(157, 50);
            this.btCancel.TabIndex = 45;
            this.btCancel.Text = "Cancel";
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // btAdd
            // 
            this.btAdd.BackColor = System.Drawing.Color.Transparent;
            this.btAdd.BorderRadius = 20;
            this.btAdd.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btAdd.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btAdd.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btAdd.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btAdd.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(84)))), ((int)(((byte)(122)))));
            this.btAdd.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btAdd.ForeColor = System.Drawing.Color.White;
            this.btAdd.Location = new System.Drawing.Point(81, 369);
            this.btAdd.Name = "btAdd";
            this.btAdd.Size = new System.Drawing.Size(157, 50);
            this.btAdd.TabIndex = 44;
            this.btAdd.Text = "Add";
            this.btAdd.Click += new System.EventHandler(this.btAdd_Click);
            // 
            // Add_Furrlough
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(52)))), ((int)(((byte)(88)))));
            this.ClientSize = new System.Drawing.Size(505, 451);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.btAdd);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.PickerTOff);
            this.Controls.Add(this.PickerTBack);
            this.Controls.Add(this.tbReason);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Add_Furrlough";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add_Furrlough";
            this.Load += new System.EventHandler(this.Add_Furrlough_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2TextBox tbReason;
        private Guna.UI2.WinForms.Guna2DateTimePicker PickerTBack;
        private Guna.UI2.WinForms.Guna2DateTimePicker PickerTOff;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2Button btCancel;
        private Guna.UI2.WinForms.Guna2Button btAdd;
    }
}