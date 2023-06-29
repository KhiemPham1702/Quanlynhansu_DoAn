namespace ban_2.Components
{
    partial class UCFileItem
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
            this.btnFile = new Guna.UI2.WinForms.Guna2Button();
            this.SuspendLayout();
            // 
            // btnFile
            // 
            this.btnFile.BorderColor = System.Drawing.Color.Gray;
            this.btnFile.BorderRadius = 15;
            this.btnFile.BorderThickness = 1;
            this.btnFile.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnFile.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnFile.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnFile.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnFile.FillColor = System.Drawing.Color.Transparent;
            this.btnFile.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFile.ForeColor = System.Drawing.Color.Black;
            this.btnFile.Location = new System.Drawing.Point(3, 3);
            this.btnFile.Name = "btnFile";
            this.btnFile.Size = new System.Drawing.Size(142, 119);
            this.btnFile.TabIndex = 0;
            this.btnFile.Text = "txx.png";
            this.btnFile.Click += new System.EventHandler(this.btnFile_Click);
            // 
            // UCFileItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnFile);
            this.Name = "UCFileItem";
            this.Size = new System.Drawing.Size(148, 136);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Button btnFile;
    }
}
