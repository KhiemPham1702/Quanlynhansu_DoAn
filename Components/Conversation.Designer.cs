namespace ban_2.Components
{
    partial class Conversation
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
            this.lblName = new System.Windows.Forms.Label();
            this.lblLastMessage = new System.Windows.Forms.Label();
            this.picturboxAvatar = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.dotNewMess = new Guna.UI2.WinForms.Guna2CircleButton();
            ((System.ComponentModel.ISupportInitialize)(this.picturboxAvatar)).BeginInit();
            this.SuspendLayout();
            // 
            // lblName
            // 
            this.lblName.AutoEllipsis = true;
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.ForeColor = System.Drawing.Color.Black;
            this.lblName.Location = new System.Drawing.Point(69, 8);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(126, 21);
            this.lblName.TabIndex = 20;
            this.lblName.Text = "Trưởng phòng";
            // 
            // lblLastMessage
            // 
            this.lblLastMessage.AutoEllipsis = true;
            this.lblLastMessage.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLastMessage.ForeColor = System.Drawing.Color.Black;
            this.lblLastMessage.Location = new System.Drawing.Point(68, 35);
            this.lblLastMessage.Name = "lblLastMessage";
            this.lblLastMessage.Size = new System.Drawing.Size(204, 19);
            this.lblLastMessage.TabIndex = 21;
            this.lblLastMessage.Text = "Mày có rảnh không";
            this.lblLastMessage.Click += new System.EventHandler(this.lblLastMessage_Click);
            // 
            // picturboxAvatar
            // 
            this.picturboxAvatar.BackColor = System.Drawing.Color.Transparent;
            this.picturboxAvatar.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(84)))), ((int)(((byte)(122)))));
            this.picturboxAvatar.Image = global::ban_2.Properties.Resources.jing_fm_account_clipart_1952632;
            this.picturboxAvatar.ImageRotate = 0F;
            this.picturboxAvatar.Location = new System.Drawing.Point(13, 13);
            this.picturboxAvatar.Name = "picturboxAvatar";
            this.picturboxAvatar.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.picturboxAvatar.Size = new System.Drawing.Size(43, 35);
            this.picturboxAvatar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picturboxAvatar.TabIndex = 1;
            this.picturboxAvatar.TabStop = false;
            // 
            // dotNewMess
            // 
            this.dotNewMess.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.dotNewMess.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.dotNewMess.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.dotNewMess.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.dotNewMess.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dotNewMess.ForeColor = System.Drawing.Color.White;
            this.dotNewMess.Location = new System.Drawing.Point(302, 25);
            this.dotNewMess.Name = "dotNewMess";
            this.dotNewMess.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.dotNewMess.Size = new System.Drawing.Size(15, 15);
            this.dotNewMess.TabIndex = 22;
            this.dotNewMess.Visible = false;
            // 
            // Conversation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.dotNewMess);
            this.Controls.Add(this.lblLastMessage);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.picturboxAvatar);
            this.Name = "Conversation";
            this.Size = new System.Drawing.Size(329, 60);
            this.Load += new System.EventHandler(this.Conversation_Load);
            this.Click += new System.EventHandler(this.Conversation_Click);
            this.Leave += new System.EventHandler(this.Conversation_Leave);
            this.MouseLeave += new System.EventHandler(this.Conversation_MouseLeave);
            this.MouseHover += new System.EventHandler(this.Conversation_MouseHover);
            ((System.ComponentModel.ISupportInitialize)(this.picturboxAvatar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2CirclePictureBox picturboxAvatar;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblLastMessage;
        private Guna.UI2.WinForms.Guna2CircleButton dotNewMess;
    }
}
