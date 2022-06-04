﻿using ban_2.Form_selection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ban_2
{
    public partial class Mainform : Form
    {
        private UserControl currentChildForm;
        string email;
        string user_name;
        int permission;
        string now;
        Loginform loginform = new Loginform();

        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-MJVETF2\SQLEXPRESS;Initial Catalog=Quanlynhansu;Integrated Security=True;");
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter();

        void find_NV()
        {
            if (permission == 0) lbNameProfile.Text = "ADMIN";
            else
            {
                con.Open();
                string sql = "select HOTEN from CHUCVU inner join NHANVIEN on CHUCVU.MACV = NHANVIEN.MACV inner join PHONGBAN on NHANVIEN.MAPB = PHONGBAN.MAPB WHERE EMAIL = '" + email + "'";
                cmd = new SqlCommand(sql, con);
                cmd.CommandType = CommandType.Text;
                da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                con.Close();

                lbNameProfile.Text = dt.Rows[0][0].ToString();
            }
        }

        Image ByteArrayToImage(byte[] b)
        {
            MemoryStream m = new MemoryStream(b);
            return Image.FromStream(m);
        }

        public void reset(Image a)
        {
            pictureBoxAvatarMain.Image = a;
        }

        void add_avartar()
        {
            con.Open();
            string sql = "select AVATAR FROM ACC_USER WHERE USERNAME = '" + user_name + "'";
            cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();

            byte[] b = (byte[])dt.Rows[0][0];
            pictureBoxAvatarMain.Image = ByteArrayToImage(b);
        }

        public Mainform()
        {
            InitializeComponent();       
        }

        public Mainform(string a, string b, int c, string d)
        {
            InitializeComponent();
            email = a;
            user_name = b;
            permission = c;
            now = d;
        }

        void OpenChildForm(UserControl form)
        {
            if(currentChildForm != null)
            {
                panelMain.Controls.Clear();
            }

            currentChildForm = form;
            lbTitle.Text = currentChildForm.Name;
            panelMain.Controls.Add(currentChildForm);
        }

        private void Mainform_Load(object sender, EventArgs e)
        {
            if (permission == 0) profilleToolStripMenuItem.Visible = false;
            else if(permission == 1)
            {
                btUser_Mana.Visible = false;
            }
            else if (permission == 2)
            {
                btChart.Visible = false;
                btUser_Mana.Visible = false;
                btDepartment.Visible = false;
                btEmployee.Visible = false;
                btSalary.Visible = false;
            }

            OpenChildForm(new Home());
            lbNameProfile.Text = "";
            find_NV();

            try
            {
                add_avartar();
            }
            catch
            {

            }
        }

        private void btHome_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Home());
        }

        private void btEmployee_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Employee());
        }

        private void btSalary_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Salary());
        }

        private void btDepartment_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Departments());
        }

        private void btAccount_Click(object sender, EventArgs e)
        {
           
        }

        private void btAbout_Click(object sender, EventArgs e)
        {
            OpenChildForm(new About());
        }

        private void btSetting_Click(object sender, EventArgs e)
        {
            menuSetting.Show(this, this.PointToClient(MousePosition));
        }

        private void profilleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Profile(email, user_name, permission, this));
        }

        void add_TT_user()
        {
            con.Open();
            string sql = "INSERT INTO QL_USER VALUES('" + user_name + "', '" + now + "', '" + DateTime.Now.ToString() + "')";
            cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        private void loginOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to sign out?", "Notification", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                add_TT_user();
                this.Close();                
                loginform.Show();
            }
        }

        private void btChart_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Chart());
        }

        private void btUser_Mana_Click(object sender, EventArgs e)
        {
            OpenChildForm(new User_M());
        }
    }
}
