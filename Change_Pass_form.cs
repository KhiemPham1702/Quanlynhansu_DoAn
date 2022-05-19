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
        string user_name;

        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-MJVETF2\SQLEXPRESS;Initial Catalog=Quanlynhansu;Integrated Security=True;");
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter();

        public Change_Pass_form()
        {
            InitializeComponent();
        }

        public Change_Pass_form(string a)
        {
            InitializeComponent();
            user_name = a;
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        bool kt()
        {
            con.Open();
            string sql = "select USERPASS FROM ACC_USER WHERE USERNAME = '" + user_name + "'";
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
            if(tbPassOld.Text == "" || tbNewPass.Text == "" || tbConfirmPass.Text == "")
            {
                MessageBox.Show("Mời nhập đầy đủ thông tin", "Đổi mật khẩu thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else if(tbNewPass.Text == tbConfirmPass.Text)
            {
                if (kt())
                {
                    con.Open();
                    string sql = "UPDATE ACC_USER SET USERPASS = '" + tbConfirmPass.Text + "' WHERE USERNAME = '" + user_name + "'";
                    cmd = new SqlCommand(sql, con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Đổi mật khẩu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else MessageBox.Show("Mật khẩu sai", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);                
            }
            else
            {
                MessageBox.Show("Mật khẩu mới không trùng khớp, mời nhập lại", "Đăng ký thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);                
            }
            tbPassOld.Text = tbNewPass.Text = tbConfirmPass.Text = "";
            tbPassOld.Focus();
        }
    }
}
