namespace ban_2.Form_selection
{
    partial class Chat
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.guna2Separator1 = new Guna.UI2.WinForms.Guna2Separator();
            this.pnlConservations = new System.Windows.Forms.Panel();
            this.tbTimNHANVIEN = new Guna.UI2.WinForms.Guna2TextBox();
            this.pnlChat = new System.Windows.Forms.Panel();
            this.pnlAction = new System.Windows.Forms.Panel();
            this.txtText = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnSend = new Guna.UI2.WinForms.Guna2CircleButton();
            this.guna2CircleButton2 = new Guna.UI2.WinForms.Guna2CircleButton();
            this.btnEmotion = new Guna.UI2.WinForms.Guna2CircleButton();
            this.btnStart = new Guna.UI2.WinForms.Guna2Button();
            this.btnConnect = new Guna.UI2.WinForms.Guna2Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            this.panel1.SuspendLayout();
            this.pnlAction.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.guna2Separator1);
            this.panel1.Controls.Add(this.pnlConservations);
            this.panel1.Controls.Add(this.tbTimNHANVIEN);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(335, 720);
            this.panel1.TabIndex = 0;
            // 
            // guna2Separator1
            // 
            this.guna2Separator1.BackColor = System.Drawing.Color.LightGray;
            this.guna2Separator1.Dock = System.Windows.Forms.DockStyle.Right;
            this.guna2Separator1.Location = new System.Drawing.Point(334, 0);
            this.guna2Separator1.Name = "guna2Separator1";
            this.guna2Separator1.Size = new System.Drawing.Size(1, 720);
            this.guna2Separator1.TabIndex = 7;
            // 
            // pnlConservations
            // 
            this.pnlConservations.Location = new System.Drawing.Point(0, 103);
            this.pnlConservations.Name = "pnlConservations";
            this.pnlConservations.Size = new System.Drawing.Size(329, 617);
            this.pnlConservations.TabIndex = 6;
            // 
            // tbTimNHANVIEN
            // 
            this.tbTimNHANVIEN.BorderRadius = 5;
            this.tbTimNHANVIEN.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbTimNHANVIEN.DefaultText = "";
            this.tbTimNHANVIEN.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.tbTimNHANVIEN.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.tbTimNHANVIEN.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbTimNHANVIEN.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbTimNHANVIEN.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbTimNHANVIEN.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold);
            this.tbTimNHANVIEN.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbTimNHANVIEN.Location = new System.Drawing.Point(9, 20);
            this.tbTimNHANVIEN.Margin = new System.Windows.Forms.Padding(4);
            this.tbTimNHANVIEN.Name = "tbTimNHANVIEN";
            this.tbTimNHANVIEN.PasswordChar = '\0';
            this.tbTimNHANVIEN.PlaceholderText = "Search colleagues";
            this.tbTimNHANVIEN.SelectedText = "";
            this.tbTimNHANVIEN.Size = new System.Drawing.Size(319, 54);
            this.tbTimNHANVIEN.TabIndex = 5;
            // 
            // pnlChat
            // 
            this.pnlChat.AutoScroll = true;
            this.pnlChat.Location = new System.Drawing.Point(335, 69);
            this.pnlChat.Name = "pnlChat";
            this.pnlChat.Size = new System.Drawing.Size(697, 572);
            this.pnlChat.TabIndex = 1;
            // 
            // pnlAction
            // 
            this.pnlAction.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.pnlAction.Controls.Add(this.txtText);
            this.pnlAction.Controls.Add(this.btnSend);
            this.pnlAction.Controls.Add(this.guna2CircleButton2);
            this.pnlAction.Controls.Add(this.btnEmotion);
            this.pnlAction.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlAction.Location = new System.Drawing.Point(335, 644);
            this.pnlAction.Name = "pnlAction";
            this.pnlAction.Size = new System.Drawing.Size(697, 76);
            this.pnlAction.TabIndex = 2;
            // 
            // txtText
            // 
            this.txtText.BorderRadius = 5;
            this.txtText.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtText.DefaultText = "";
            this.txtText.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtText.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtText.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtText.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtText.FillColor = System.Drawing.SystemColors.ButtonFace;
            this.txtText.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtText.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold);
            this.txtText.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtText.Location = new System.Drawing.Point(21, 12);
            this.txtText.Margin = new System.Windows.Forms.Padding(4);
            this.txtText.Name = "txtText";
            this.txtText.PasswordChar = '\0';
            this.txtText.PlaceholderText = "Enter your text...";
            this.txtText.SelectedText = "";
            this.txtText.Size = new System.Drawing.Size(431, 50);
            this.txtText.TabIndex = 56;
            // 
            // btnSend
            // 
            this.btnSend.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSend.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSend.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSend.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSend.FillColor = System.Drawing.Color.White;
            this.btnSend.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnSend.ForeColor = System.Drawing.Color.White;
            this.btnSend.Image = global::ban_2.Properties.Resources.contact;
            this.btnSend.ImageSize = new System.Drawing.Size(25, 25);
            this.btnSend.Location = new System.Drawing.Point(638, 22);
            this.btnSend.Name = "btnSend";
            this.btnSend.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.btnSend.Size = new System.Drawing.Size(39, 36);
            this.btnSend.TabIndex = 55;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // guna2CircleButton2
            // 
            this.guna2CircleButton2.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2CircleButton2.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2CircleButton2.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2CircleButton2.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2CircleButton2.FillColor = System.Drawing.Color.Transparent;
            this.guna2CircleButton2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2CircleButton2.ForeColor = System.Drawing.Color.White;
            this.guna2CircleButton2.Image = global::ban_2.Properties.Resources.attach_paperclip_symbol_icon_icons_com_73094;
            this.guna2CircleButton2.ImageSize = new System.Drawing.Size(25, 25);
            this.guna2CircleButton2.Location = new System.Drawing.Point(580, 22);
            this.guna2CircleButton2.Name = "guna2CircleButton2";
            this.guna2CircleButton2.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.guna2CircleButton2.Size = new System.Drawing.Size(39, 36);
            this.guna2CircleButton2.TabIndex = 54;
            // 
            // btnEmotion
            // 
            this.btnEmotion.BackColor = System.Drawing.Color.Transparent;
            this.btnEmotion.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnEmotion.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnEmotion.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnEmotion.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnEmotion.FillColor = System.Drawing.Color.Transparent;
            this.btnEmotion.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnEmotion.ForeColor = System.Drawing.Color.White;
            this.btnEmotion.Image = global::ban_2.Properties.Resources.emoji_smile_102022;
            this.btnEmotion.ImageSize = new System.Drawing.Size(25, 25);
            this.btnEmotion.Location = new System.Drawing.Point(518, 22);
            this.btnEmotion.Name = "btnEmotion";
            this.btnEmotion.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.btnEmotion.Size = new System.Drawing.Size(46, 36);
            this.btnEmotion.TabIndex = 0;
            // 
            // btnStart
            // 
            this.btnStart.AutoRoundedCorners = true;
            this.btnStart.BorderRadius = 21;
            this.btnStart.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnStart.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnStart.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnStart.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnStart.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(84)))), ((int)(((byte)(122)))));
            this.btnStart.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnStart.ForeColor = System.Drawing.Color.White;
            this.btnStart.Location = new System.Drawing.Point(469, 13);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(180, 45);
            this.btnStart.TabIndex = 3;
            this.btnStart.Text = "Start";
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnConnect
            // 
            this.btnConnect.AutoRoundedCorners = true;
            this.btnConnect.BorderRadius = 21;
            this.btnConnect.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnConnect.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnConnect.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnConnect.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnConnect.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(84)))), ((int)(((byte)(122)))));
            this.btnConnect.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnConnect.ForeColor = System.Drawing.Color.White;
            this.btnConnect.Location = new System.Drawing.Point(694, 13);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(180, 45);
            this.btnConnect.TabIndex = 4;
            this.btnConnect.Text = "Connect";
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // backgroundWorker2
            // 
            this.backgroundWorker2.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker2_DoWork);
            // 
            // Chat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.pnlAction);
            this.Controls.Add(this.pnlChat);
            this.Controls.Add(this.panel1);
            this.Name = "Chat";
            this.Size = new System.Drawing.Size(1032, 720);
            this.panel1.ResumeLayout(false);
            this.pnlAction.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel pnlChat;
        private Guna.UI2.WinForms.Guna2TextBox tbTimNHANVIEN;
        private System.Windows.Forms.Panel pnlConservations;
        private System.Windows.Forms.Panel pnlAction;
        private Guna.UI2.WinForms.Guna2CircleButton btnSend;
        private Guna.UI2.WinForms.Guna2CircleButton guna2CircleButton2;
        private Guna.UI2.WinForms.Guna2CircleButton btnEmotion;
        private Guna.UI2.WinForms.Guna2Separator guna2Separator1;
        private Guna.UI2.WinForms.Guna2Button btnStart;
        private Guna.UI2.WinForms.Guna2Button btnConnect;
        private Guna.UI2.WinForms.Guna2TextBox txtText;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
    }
}
