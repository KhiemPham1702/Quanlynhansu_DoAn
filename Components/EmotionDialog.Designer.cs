namespace ban_2.Components
{
    partial class EmotionDialog
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
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.btnLike = new Guna.UI2.WinForms.Guna2CircleButton();
            this.btnHaha = new Guna.UI2.WinForms.Guna2CircleButton();
            this.btnLove = new Guna.UI2.WinForms.Guna2CircleButton();
            this.guna2Panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Panel1.BorderRadius = 20;
            this.guna2Panel1.BorderThickness = 1;
            this.guna2Panel1.Controls.Add(this.btnLove);
            this.guna2Panel1.Controls.Add(this.btnHaha);
            this.guna2Panel1.Controls.Add(this.btnLike);
            this.guna2Panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guna2Panel1.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(231, 46);
            this.guna2Panel1.TabIndex = 0;
            // 
            // btnLike
            // 
            this.btnLike.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnLike.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnLike.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnLike.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnLike.FillColor = System.Drawing.Color.Transparent;
            this.btnLike.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnLike.ForeColor = System.Drawing.Color.White;
            this.btnLike.Image = global::ban_2.Properties.Resources.like;
            this.btnLike.ImageSize = new System.Drawing.Size(25, 25);
            this.btnLike.Location = new System.Drawing.Point(21, 3);
            this.btnLike.Name = "btnLike";
            this.btnLike.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.btnLike.Size = new System.Drawing.Size(58, 40);
            this.btnLike.TabIndex = 6;
            this.btnLike.Click += new System.EventHandler(this.btnLike_Click);
            // 
            // btnHaha
            // 
            this.btnHaha.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnHaha.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnHaha.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnHaha.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnHaha.FillColor = System.Drawing.Color.Transparent;
            this.btnHaha.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnHaha.ForeColor = System.Drawing.Color.White;
            this.btnHaha.Image = global::ban_2.Properties.Resources.haha;
            this.btnHaha.ImageSize = new System.Drawing.Size(25, 25);
            this.btnHaha.Location = new System.Drawing.Point(86, 3);
            this.btnHaha.Name = "btnHaha";
            this.btnHaha.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.btnHaha.Size = new System.Drawing.Size(58, 40);
            this.btnHaha.TabIndex = 7;
            this.btnHaha.Click += new System.EventHandler(this.btnHaha_Click);
            // 
            // btnLove
            // 
            this.btnLove.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnLove.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnLove.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnLove.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnLove.FillColor = System.Drawing.Color.Transparent;
            this.btnLove.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnLove.ForeColor = System.Drawing.Color.White;
            this.btnLove.Image = global::ban_2.Properties.Resources.love;
            this.btnLove.ImageSize = new System.Drawing.Size(25, 25);
            this.btnLove.Location = new System.Drawing.Point(160, 3);
            this.btnLove.Name = "btnLove";
            this.btnLove.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.btnLove.Size = new System.Drawing.Size(58, 40);
            this.btnLove.TabIndex = 8;
            this.btnLove.Click += new System.EventHandler(this.btnLove_Click);
            // 
            // EmotionDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.guna2Panel1);
            this.Name = "EmotionDialog";
            this.Size = new System.Drawing.Size(231, 46);
            this.guna2Panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2CircleButton btnLike;
        private Guna.UI2.WinForms.Guna2CircleButton btnLove;
        private Guna.UI2.WinForms.Guna2CircleButton btnHaha;
    }
}
