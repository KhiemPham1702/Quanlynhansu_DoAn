namespace ban_2.Components
{
    partial class UCInfoChat
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnViewFile = new Guna.UI2.WinForms.Guna2Button();
            this.btnChangeBG = new Guna.UI2.WinForms.Guna2Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnInfo = new Guna.UI2.WinForms.Guna2CircleButton();
            this.lblName = new System.Windows.Forms.Label();
            this.guna2CircleButton1 = new Guna.UI2.WinForms.Guna2CircleButton();
            this.picturboxAvatar = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.guna2Panel1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picturboxAvatar)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.Controls.Add(this.panel1);
            this.guna2Panel1.Controls.Add(this.label1);
            this.guna2Panel1.Controls.Add(this.btnInfo);
            this.guna2Panel1.Controls.Add(this.lblName);
            this.guna2Panel1.Controls.Add(this.guna2CircleButton1);
            this.guna2Panel1.Controls.Add(this.picturboxAvatar);
            this.guna2Panel1.CustomBorderColor = System.Drawing.Color.Gray;
            this.guna2Panel1.CustomBorderThickness = new System.Windows.Forms.Padding(2, 2, 0, 0);
            this.guna2Panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guna2Panel1.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(421, 720);
            this.guna2Panel1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnViewFile);
            this.panel1.Controls.Add(this.btnChangeBG);
            this.panel1.Location = new System.Drawing.Point(3, 364);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(415, 131);
            this.panel1.TabIndex = 19;
            // 
            // btnViewFile
            // 
            this.btnViewFile.BackColor = System.Drawing.Color.Transparent;
            this.btnViewFile.BorderRadius = 10;
            this.btnViewFile.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnViewFile.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnViewFile.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnViewFile.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnViewFile.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnViewFile.FillColor = System.Drawing.Color.Transparent;
            this.btnViewFile.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.btnViewFile.ForeColor = System.Drawing.Color.Black;
            this.btnViewFile.Image = global::ban_2.Properties.Resources.document_64;
            this.btnViewFile.ImageAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.btnViewFile.ImageSize = new System.Drawing.Size(30, 30);
            this.btnViewFile.Location = new System.Drawing.Point(0, 62);
            this.btnViewFile.Name = "btnViewFile";
            this.btnViewFile.Size = new System.Drawing.Size(415, 62);
            this.btnViewFile.TabIndex = 15;
            this.btnViewFile.Text = "View files, images";
            this.btnViewFile.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // btnChangeBG
            // 
            this.btnChangeBG.BackColor = System.Drawing.Color.Transparent;
            this.btnChangeBG.BorderRadius = 10;
            this.btnChangeBG.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnChangeBG.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnChangeBG.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnChangeBG.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnChangeBG.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnChangeBG.FillColor = System.Drawing.Color.Transparent;
            this.btnChangeBG.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.btnChangeBG.ForeColor = System.Drawing.Color.Black;
            this.btnChangeBG.Image = global::ban_2.Properties.Resources.photo_64;
            this.btnChangeBG.ImageAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.btnChangeBG.ImageSize = new System.Drawing.Size(30, 30);
            this.btnChangeBG.Location = new System.Drawing.Point(0, 0);
            this.btnChangeBG.Name = "btnChangeBG";
            this.btnChangeBG.Size = new System.Drawing.Size(415, 62);
            this.btnChangeBG.TabIndex = 14;
            this.btnChangeBG.Text = "Change Background";
            this.btnChangeBG.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnChangeBG.Click += new System.EventHandler(this.btnChangeBG_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(169, 305);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 33);
            this.label1.TabIndex = 18;
            this.label1.Text = "Search";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnInfo
            // 
            this.btnInfo.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnInfo.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnInfo.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnInfo.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnInfo.FillColor = System.Drawing.Color.Silver;
            this.btnInfo.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInfo.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnInfo.Location = new System.Drawing.Point(378, 3);
            this.btnInfo.Name = "btnInfo";
            this.btnInfo.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.btnInfo.Size = new System.Drawing.Size(40, 40);
            this.btnInfo.TabIndex = 16;
            this.btnInfo.Text = "X";
            this.btnInfo.Click += new System.EventHandler(this.btnInfo_Click);
            // 
            // lblName
            // 
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(42, 201);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(331, 29);
            this.lblName.TabIndex = 15;
            this.lblName.Text = "Nguyễn Văn A";
            this.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // guna2CircleButton1
            // 
            this.guna2CircleButton1.BackColor = System.Drawing.Color.Transparent;
            this.guna2CircleButton1.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2CircleButton1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2CircleButton1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2CircleButton1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2CircleButton1.FillColor = System.Drawing.Color.Gainsboro;
            this.guna2CircleButton1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2CircleButton1.ForeColor = System.Drawing.Color.White;
            this.guna2CircleButton1.Image = global::ban_2.Properties.Resources.search_48;
            this.guna2CircleButton1.Location = new System.Drawing.Point(182, 248);
            this.guna2CircleButton1.Name = "guna2CircleButton1";
            this.guna2CircleButton1.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.guna2CircleButton1.Size = new System.Drawing.Size(50, 50);
            this.guna2CircleButton1.TabIndex = 17;
            // 
            // picturboxAvatar
            // 
            this.picturboxAvatar.BackColor = System.Drawing.Color.Transparent;
            this.picturboxAvatar.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(84)))), ((int)(((byte)(122)))));
            this.picturboxAvatar.Image = global::ban_2.Properties.Resources.jing_fm_account_clipart_1952632;
            this.picturboxAvatar.ImageRotate = 0F;
            this.picturboxAvatar.Location = new System.Drawing.Point(140, 59);
            this.picturboxAvatar.Name = "picturboxAvatar";
            this.picturboxAvatar.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.picturboxAvatar.Size = new System.Drawing.Size(132, 120);
            this.picturboxAvatar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picturboxAvatar.TabIndex = 14;
            this.picturboxAvatar.TabStop = false;
            // 
            // UCInfoChat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.guna2Panel1);
            this.Name = "UCInfoChat";
            this.Size = new System.Drawing.Size(421, 720);
            this.guna2Panel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picturboxAvatar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private System.Windows.Forms.Panel panel1;
        private Guna.UI2.WinForms.Guna2Button btnViewFile;
        private Guna.UI2.WinForms.Guna2Button btnChangeBG;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2CircleButton btnInfo;
        private System.Windows.Forms.Label lblName;
        private Guna.UI2.WinForms.Guna2CircleButton guna2CircleButton1;
        private Guna.UI2.WinForms.Guna2CirclePictureBox picturboxAvatar;
    }
}
