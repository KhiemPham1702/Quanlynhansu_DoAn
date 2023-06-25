
namespace ban_2
{
    partial class Change_Pass_form
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tbPassOld = new Guna.UI2.WinForms.Guna2TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbNewPass = new Guna.UI2.WinForms.Guna2TextBox();
            this.tbConfirmPass = new Guna.UI2.WinForms.Guna2TextBox();
            this.btCancel = new Guna.UI2.WinForms.Guna2Button();
            this.btChange = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.guna2AnimateWindow1 = new Guna.UI2.WinForms.Guna2AnimateWindow(this.components);
            this.SuspendLayout();
            // 
            // tbPassOld
            // 
            this.tbPassOld.BorderRadius = 15;
            this.tbPassOld.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbPassOld.DefaultText = "";
            this.tbPassOld.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.tbPassOld.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.tbPassOld.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbPassOld.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbPassOld.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbPassOld.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPassOld.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbPassOld.IconLeft = global::ban_2.Properties.Resources._111039_key_icon;
            this.tbPassOld.Location = new System.Drawing.Point(52, 95);
            this.tbPassOld.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tbPassOld.Name = "tbPassOld";
            this.tbPassOld.PasswordChar = '•';
            this.tbPassOld.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.tbPassOld.PlaceholderText = "Your Password";
            this.tbPassOld.SelectedText = "";
            this.tbPassOld.Size = new System.Drawing.Size(400, 52);
            this.tbPassOld.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Gainsboro;
            this.label1.Location = new System.Drawing.Point(145, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(245, 38);
            this.label1.TabIndex = 6;
            this.label1.Text = "Change Password";
            // 
            // tbNewPass
            // 
            this.tbNewPass.BorderRadius = 15;
            this.tbNewPass.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbNewPass.DefaultText = "";
            this.tbNewPass.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.tbNewPass.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.tbNewPass.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbNewPass.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbNewPass.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbNewPass.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbNewPass.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbNewPass.IconLeft = global::ban_2.Properties.Resources._111039_key_icon;
            this.tbNewPass.Location = new System.Drawing.Point(52, 178);
            this.tbNewPass.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tbNewPass.Name = "tbNewPass";
            this.tbNewPass.PasswordChar = '•';
            this.tbNewPass.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.tbNewPass.PlaceholderText = "New Password";
            this.tbNewPass.SelectedText = "";
            this.tbNewPass.Size = new System.Drawing.Size(400, 52);
            this.tbNewPass.TabIndex = 7;
            // 
            // tbConfirmPass
            // 
            this.tbConfirmPass.BorderRadius = 15;
            this.tbConfirmPass.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbConfirmPass.DefaultText = "";
            this.tbConfirmPass.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.tbConfirmPass.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.tbConfirmPass.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbConfirmPass.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbConfirmPass.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbConfirmPass.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbConfirmPass.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbConfirmPass.IconLeft = global::ban_2.Properties.Resources._111039_key_icon;
            this.tbConfirmPass.Location = new System.Drawing.Point(52, 263);
            this.tbConfirmPass.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tbConfirmPass.Name = "tbConfirmPass";
            this.tbConfirmPass.PasswordChar = '•';
            this.tbConfirmPass.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.tbConfirmPass.PlaceholderText = "Confirm New Password";
            this.tbConfirmPass.SelectedText = "";
            this.tbConfirmPass.Size = new System.Drawing.Size(400, 52);
            this.tbConfirmPass.TabIndex = 8;
            // 
            // btCancel
            // 
            this.btCancel.BackColor = System.Drawing.Color.Transparent;
            this.btCancel.BorderRadius = 20;
            this.btCancel.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btCancel.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btCancel.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btCancel.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btCancel.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(84)))), ((int)(((byte)(122)))));
            this.btCancel.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btCancel.ForeColor = System.Drawing.Color.White;
            this.btCancel.Location = new System.Drawing.Point(137, 411);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(229, 50);
            this.btCancel.TabIndex = 18;
            this.btCancel.Text = "Cancel";
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // btChange
            // 
            this.btChange.BackColor = System.Drawing.Color.Transparent;
            this.btChange.BorderRadius = 20;
            this.btChange.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btChange.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btChange.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btChange.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btChange.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(84)))), ((int)(((byte)(122)))));
            this.btChange.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btChange.ForeColor = System.Drawing.Color.White;
            this.btChange.Location = new System.Drawing.Point(137, 349);
            this.btChange.Name = "btChange";
            this.btChange.Size = new System.Drawing.Size(229, 50);
            this.btChange.TabIndex = 17;
            this.btChange.Text = "Change";
            this.btChange.Click += new System.EventHandler(this.btChange_Click);
            // 
            // guna2Elipse1
            // 
            this.guna2Elipse1.BorderRadius = 10;
            this.guna2Elipse1.TargetControl = this;
            // 
            // Change_Pass_form
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(52)))), ((int)(((byte)(88)))));
            this.ClientSize = new System.Drawing.Size(500, 492);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.btChange);
            this.Controls.Add(this.tbConfirmPass);
            this.Controls.Add(this.tbNewPass);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbPassOld);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Change_Pass_form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Change_Pass_form";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2TextBox tbPassOld;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2TextBox tbNewPass;
        private Guna.UI2.WinForms.Guna2TextBox tbConfirmPass;
        private Guna.UI2.WinForms.Guna2Button btCancel;
        private Guna.UI2.WinForms.Guna2Button btChange;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private Guna.UI2.WinForms.Guna2AnimateWindow guna2AnimateWindow1;
    }
}