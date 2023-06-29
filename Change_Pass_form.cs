using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ban_2
{
    public partial class Change_Pass_form : Form
    {
        string email;

        SqlConnection con = new connect().Con;
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter();

        public Change_Pass_form()
        {
            InitializeComponent();
        }

        public Change_Pass_form(string a)
        {
            InitializeComponent();
            email = a;
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        bool kt()
        {
            con.Open();
            string sql = "select USERPASS FROM ACC_USER WHERE EMAIL = '" + email + "'";
            cmd = new SqlCommand(sql, con);
            da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();

            if (dt.Rows[0][0].ToString() == tbPassOld.Text) return true;
            return false;
        }

        private void btChange_Click(object sender, EventArgs e)
        {
            if (tbPassOld.Text == "" || tbNewPass.Text == "" || tbConfirmPass.Text == "")
            {
                MessageBox.Show("Please fill out all the information", "Failed to change password", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (tbNewPass.Text == tbConfirmPass.Text)
            {
                if (kt())
                {
                    con.Open();
                    string sql = "UPDATE ACC_USER SET USERPASS = '" + tbConfirmPass.Text + "' WHERE EMAIL = '" + email + "'";
                    cmd = new SqlCommand(sql, con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Change Password Successfully", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else MessageBox.Show("Incorrect password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("New password does not match, please re-enter", "Registration Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            tbPassOld.Text = tbNewPass.Text = tbConfirmPass.Text = "";
            tbPassOld.Focus();
        }
    }
}
