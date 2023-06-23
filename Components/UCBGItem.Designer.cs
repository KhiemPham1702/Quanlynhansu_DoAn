namespace ban_2.Components
{
    partial class UCBGItem
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
            this.btnReturn = new Guna.UI2.WinForms.Guna2CircleButton();
            this.btnTheme = new Guna.UI2.WinForms.Guna2Button();
            this.SuspendLayout();
            // 
            // btnReturn
            // 
            this.btnReturn.BackColor = System.Drawing.Color.Transparent;
            this.btnReturn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnReturn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnReturn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnReturn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnReturn.FillColor = System.Drawing.Color.Transparent;
            this.btnReturn.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnReturn.ForeColor = System.Drawing.Color.White;
            this.btnReturn.Image = global::ban_2.Properties.Resources.eye_2_48;
            this.btnReturn.Location = new System.Drawing.Point(366, 17);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.btnReturn.Size = new System.Drawing.Size(46, 35);
            this.btnReturn.TabIndex = 13;
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
            // 
            // btnTheme
            // 
            this.btnTheme.BorderRadius = 10;
            this.btnTheme.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnTheme.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnTheme.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnTheme.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnTheme.FillColor = System.Drawing.Color.Transparent;
            this.btnTheme.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.btnTheme.ForeColor = System.Drawing.Color.Black;
            this.btnTheme.Image = global::ban_2.Properties.Resources.chat1;
            this.btnTheme.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnTheme.ImageOffset = new System.Drawing.Point(20, 0);
            this.btnTheme.ImageSize = new System.Drawing.Size(70, 50);
            this.btnTheme.Location = new System.Drawing.Point(9, 0);
            this.btnTheme.Name = "btnTheme";
            this.btnTheme.Size = new System.Drawing.Size(334, 67);
            this.btnTheme.TabIndex = 0;
            this.btnTheme.Text = "guna2Button1";
            this.btnTheme.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.btnTheme.Click += new System.EventHandler(this.btnTheme_Click);
            // 
            // UCBGItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnReturn);
            this.Controls.Add(this.btnTheme);
            this.Name = "UCBGItem";
            this.Size = new System.Drawing.Size(418, 67);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Button btnTheme;
        private Guna.UI2.WinForms.Guna2CircleButton btnReturn;
    }
}
