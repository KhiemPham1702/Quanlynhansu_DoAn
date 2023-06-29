namespace ban_2.Components
{
    partial class UCSeachMessItem
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
            this.btnText = new Guna.UI2.WinForms.Guna2Button();
            this.lblHour = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnText
            // 
            this.btnText.AutoRoundedCorners = true;
            this.btnText.BorderColor = System.Drawing.Color.DarkGray;
            this.btnText.BorderRadius = 20;
            this.btnText.BorderThickness = 1;
            this.btnText.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnText.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnText.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnText.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnText.FillColor = System.Drawing.Color.Transparent;
            this.btnText.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.btnText.ForeColor = System.Drawing.Color.Black;
            this.btnText.Location = new System.Drawing.Point(16, 6);
            this.btnText.Name = "btnText";
            this.btnText.Size = new System.Drawing.Size(268, 42);
            this.btnText.TabIndex = 0;
            this.btnText.Text = "btnText";
            this.btnText.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnText.Click += new System.EventHandler(this.btnText_Click);
            // 
            // lblHour
            // 
            this.lblHour.AutoSize = true;
            this.lblHour.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHour.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblHour.Location = new System.Drawing.Point(298, 18);
            this.lblHour.Name = "lblHour";
            this.lblHour.Size = new System.Drawing.Size(44, 18);
            this.lblHour.TabIndex = 1;
            this.lblHour.Text = "10:30";
            // 
            // UCSeachMessItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblHour);
            this.Controls.Add(this.btnText);
            this.Name = "UCSeachMessItem";
            this.Size = new System.Drawing.Size(361, 59);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Button btnText;
        private System.Windows.Forms.Label lblHour;
    }
}
