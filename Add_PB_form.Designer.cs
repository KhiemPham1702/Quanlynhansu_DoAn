
namespace ban_2
{
    partial class Add_PB_form
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
            this.btCancel = new Guna.UI2.WinForms.Guna2Button();
            this.btAdd = new Guna.UI2.WinForms.Guna2Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tbAddName = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.tbAddID = new Guna.UI2.WinForms.Guna2TextBox();
            this.SuspendLayout();
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
            this.btCancel.Location = new System.Drawing.Point(140, 262);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(229, 50);
            this.btCancel.TabIndex = 38;
            this.btCancel.Text = "Cancel";
            // 
            // btAdd
            // 
            this.btAdd.BackColor = System.Drawing.Color.Transparent;
            this.btAdd.BorderRadius = 20;
            this.btAdd.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btAdd.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btAdd.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btAdd.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btAdd.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(84)))), ((int)(((byte)(122)))));
            this.btAdd.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btAdd.ForeColor = System.Drawing.Color.White;
            this.btAdd.Location = new System.Drawing.Point(140, 200);
            this.btAdd.Name = "btAdd";
            this.btAdd.Size = new System.Drawing.Size(229, 50);
            this.btAdd.TabIndex = 37;
            this.btAdd.Text = "Add";
            this.btAdd.Click += new System.EventHandler(this.tbAddID_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Gainsboro;
            this.label1.Location = new System.Drawing.Point(93, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(301, 38);
            this.label1.TabIndex = 36;
            this.label1.Text = "Add new Department";
            // 
            // tbAddName
            // 
            this.tbAddName.BorderRadius = 20;
            this.tbAddName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbAddName.DefaultText = "";
            this.tbAddName.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.tbAddName.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.tbAddName.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbAddName.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbAddName.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbAddName.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.tbAddName.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbAddName.Location = new System.Drawing.Point(45, 129);
            this.tbAddName.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tbAddName.Name = "tbAddName";
            this.tbAddName.PasswordChar = '\0';
            this.tbAddName.PlaceholderForeColor = System.Drawing.Color.DarkGray;
            this.tbAddName.PlaceholderText = "Name";
            this.tbAddName.SelectedText = "";
            this.tbAddName.Size = new System.Drawing.Size(410, 45);
            this.tbAddName.TabIndex = 35;
            // 
            // guna2Elipse1
            // 
            this.guna2Elipse1.BorderRadius = 20;
            this.guna2Elipse1.TargetControl = this;
            // 
            // tbAddID
            // 
            this.tbAddID.BorderRadius = 20;
            this.tbAddID.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbAddID.DefaultText = "";
            this.tbAddID.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.tbAddID.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.tbAddID.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbAddID.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbAddID.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbAddID.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.tbAddID.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbAddID.Location = new System.Drawing.Point(45, 68);
            this.tbAddID.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tbAddID.Name = "tbAddID";
            this.tbAddID.PasswordChar = '\0';
            this.tbAddID.PlaceholderForeColor = System.Drawing.Color.DarkGray;
            this.tbAddID.PlaceholderText = "ID";
            this.tbAddID.SelectedText = "";
            this.tbAddID.Size = new System.Drawing.Size(410, 45);
            this.tbAddID.TabIndex = 39;
            // 
            // Add_PB_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(52)))), ((int)(((byte)(88)))));
            this.ClientSize = new System.Drawing.Size(500, 338);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.btAdd);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbAddName);
            this.Controls.Add(this.tbAddID);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Add_PB_form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add_PB_form";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Button btCancel;
        private Guna.UI2.WinForms.Guna2Button btAdd;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2TextBox tbAddName;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private Guna.UI2.WinForms.Guna2TextBox tbAddID;
    }
}