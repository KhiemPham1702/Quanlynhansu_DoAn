namespace ban_2.Components
{
    partial class ChatContent
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
            this.pnlChat = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblName = new System.Windows.Forms.Label();
            this.guna2Separator1 = new Guna.UI2.WinForms.Guna2Separator();
            this.btnInfo = new Guna.UI2.WinForms.Guna2CircleButton();
            this.guna2Separator2 = new Guna.UI2.WinForms.Guna2Separator();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlChat
            // 
            this.pnlChat.AutoScroll = true;
            this.pnlChat.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlChat.Location = new System.Drawing.Point(0, 58);
            this.pnlChat.Name = "pnlChat";
            this.pnlChat.Size = new System.Drawing.Size(697, 580);
            this.pnlChat.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.guna2Separator2);
            this.panel1.Controls.Add(this.btnInfo);
            this.panel1.Controls.Add(this.guna2Separator1);
            this.panel1.Controls.Add(this.lblName);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(697, 58);
            this.panel1.TabIndex = 1;
            // 
            // lblName
            // 
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(185, 15);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(331, 29);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Nguyễn Văn A";
            this.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // guna2Separator1
            // 
            this.guna2Separator1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.guna2Separator1.FillColor = System.Drawing.Color.Gray;
            this.guna2Separator1.Location = new System.Drawing.Point(0, 53);
            this.guna2Separator1.Name = "guna2Separator1";
            this.guna2Separator1.Size = new System.Drawing.Size(697, 5);
            this.guna2Separator1.TabIndex = 1;
            // 
            // btnInfo
            // 
            this.btnInfo.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnInfo.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnInfo.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnInfo.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnInfo.FillColor = System.Drawing.Color.Transparent;
            this.btnInfo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnInfo.ForeColor = System.Drawing.Color.White;
            this.btnInfo.Image = global::ban_2.Properties.Resources.info_5_64__1_;
            this.btnInfo.Location = new System.Drawing.Point(619, 11);
            this.btnInfo.Name = "btnInfo";
            this.btnInfo.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.btnInfo.Size = new System.Drawing.Size(58, 36);
            this.btnInfo.TabIndex = 9;
            this.btnInfo.Click += new System.EventHandler(this.btnInfo_Click);
            // 
            // guna2Separator2
            // 
            this.guna2Separator2.Dock = System.Windows.Forms.DockStyle.Top;
            this.guna2Separator2.FillColor = System.Drawing.Color.Gray;
            this.guna2Separator2.Location = new System.Drawing.Point(0, 0);
            this.guna2Separator2.Name = "guna2Separator2";
            this.guna2Separator2.Size = new System.Drawing.Size(697, 2);
            this.guna2Separator2.TabIndex = 10;
            // 
            // ChatContent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnlChat);
            this.DoubleBuffered = true;
            this.Name = "ChatContent";
            this.Size = new System.Drawing.Size(697, 638);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlChat;
        private System.Windows.Forms.Panel panel1;
        private Guna.UI2.WinForms.Guna2Separator guna2Separator1;
        private System.Windows.Forms.Label lblName;
        private Guna.UI2.WinForms.Guna2CircleButton btnInfo;
        private Guna.UI2.WinForms.Guna2Separator guna2Separator2;
    }
}
