namespace ban_2.Components
{
    partial class UCItemSearchColleague
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
            this.btnUser = new Guna.UI2.WinForms.Guna2Button();
            this.SuspendLayout();
            // 
            // btnUser
            // 
            this.btnUser.BackColor = System.Drawing.Color.Transparent;
            this.btnUser.BorderRadius = 10;
            this.btnUser.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnUser.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnUser.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnUser.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnUser.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnUser.FillColor = System.Drawing.Color.Transparent;
            this.btnUser.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.btnUser.ForeColor = System.Drawing.Color.Black;
            this.btnUser.Image = global::ban_2.Properties.Resources.photo_64;
            this.btnUser.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnUser.ImageSize = new System.Drawing.Size(30, 30);
            this.btnUser.Location = new System.Drawing.Point(0, 0);
            this.btnUser.Name = "btnUser";
            this.btnUser.Size = new System.Drawing.Size(329, 62);
            this.btnUser.TabIndex = 15;
            this.btnUser.Text = "Change Background";
            this.btnUser.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.btnUser.Click += new System.EventHandler(this.btnUser_Click);
            // 
            // UCItemSearchColleague
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnUser);
            this.Name = "UCItemSearchColleague";
            this.Size = new System.Drawing.Size(329, 60);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Button btnUser;
    }
}
