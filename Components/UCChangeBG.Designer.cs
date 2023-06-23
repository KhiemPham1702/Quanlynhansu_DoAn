namespace ban_2.Components
{
    partial class UCChangeBG
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
            this.flwBG = new System.Windows.Forms.FlowLayoutPanel();
            this.lblName = new System.Windows.Forms.Label();
            this.btnReturn = new Guna.UI2.WinForms.Guna2CircleButton();
            this.guna2Panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.Controls.Add(this.flwBG);
            this.guna2Panel1.Controls.Add(this.lblName);
            this.guna2Panel1.Controls.Add(this.btnReturn);
            this.guna2Panel1.CustomBorderColor = System.Drawing.Color.Gray;
            this.guna2Panel1.CustomBorderThickness = new System.Windows.Forms.Padding(2, 2, 0, 0);
            this.guna2Panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guna2Panel1.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(421, 720);
            this.guna2Panel1.TabIndex = 0;
            // 
            // flwBG
            // 
            this.flwBG.Location = new System.Drawing.Point(3, 92);
            this.flwBG.Name = "flwBG";
            this.flwBG.Size = new System.Drawing.Size(415, 574);
            this.flwBG.TabIndex = 17;
            // 
            // lblName
            // 
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(67, 15);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(331, 29);
            this.lblName.TabIndex = 16;
            this.lblName.Text = "Choose your background";
            this.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.btnReturn.Image = global::ban_2.Properties.Resources.arrow_67_64;
            this.btnReturn.Location = new System.Drawing.Point(17, 7);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.btnReturn.Size = new System.Drawing.Size(50, 50);
            this.btnReturn.TabIndex = 15;
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
            // 
            // UCChangeBG
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.guna2Panel1);
            this.Name = "UCChangeBG";
            this.Size = new System.Drawing.Size(421, 720);
            this.guna2Panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private System.Windows.Forms.FlowLayoutPanel flwBG;
        private System.Windows.Forms.Label lblName;
        private Guna.UI2.WinForms.Guna2CircleButton btnReturn;
    }
}
