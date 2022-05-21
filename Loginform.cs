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
    public partial class Loginform : Form
    {

        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-MJVETF2\SQLEXPRESS;Initial Catalog=Quanlynhansu;Integrated Security=True;");
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter();

        public Loginform()
        {
            InitializeComponent();
        }
       

        int kt()
        {
            if (cbP.SelectedItem.ToString() == "Quản lý")
                return 1;
            else return 2;
        }

        private void guna2PictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void lbSignUpChange_Click(object sender, EventArgs e)
        {
            panelLogin.Visible = false;
            panelSignUp.Visible = true;
            panelSignUp.Dock = DockStyle.Left;
            textLoginUserName.Text = textLoginUserPass.Text = "";
        }

        private void lbLoginChange_Click(object sender, EventArgs e)
        {
            panelLogin.Visible = true;
            panelSignUp.Visible = false;
            textSignUpUserName.Text = textSignUpUserPass.Text = tbEmail.Text = tbPhone.Text = textConfirmPass.Text = "";
        }

        private void tgShowPass_CheckedChanged(object sender, EventArgs e)
        {
            if (tgShowPass.Checked)
            {
                textLoginUserPass.PasswordChar = '\0';
            }
            else
            {
                textLoginUserPass.PasswordChar = '•';
            }
        }

        private void tgShowPassSU_CheckedChanged(object sender, EventArgs e)
        {
            if (tgShowPassSU.Checked)
            {
                textSignUpUserPass.PasswordChar = '\0';
                textConfirmPass.PasswordChar = '\0';
            }
            else
            {
                textConfirmPass.PasswordChar = '•';
                textSignUpUserPass.PasswordChar = '•';
            }
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            if (textLoginUserName.Text == "" || textLoginUserPass.Text == "")
            {
                MessageBox.Show("Tài khoản hoặc mật khẩu bị bỏ trống", "Đăng nhập thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string email = find_NV();
                con.Open();
                SqlDataReader dr;
                string login = "SELECT * FROM ACC_USER WHERE USERNAME= '" + textLoginUserName.Text.Trim() + "' and USERPASS= '" + textLoginUserPass.Text.Trim() + "'";
                cmd = new SqlCommand(login, con);
                dr = cmd.ExecuteReader();               
                if (dr.Read() == true)
                {
                    int per;
                    if (textLoginUserName.Text == "admin") per = 0;
                    else per = kt();
                    Mainform fmain = new Mainform(email, textLoginUserName.Text, per);
                    fmain.Show();
                    this.Hide();
                    textLoginUserName.Text = "";
                    textLoginUserPass.Text = "";
                }
                else
                {
                    MessageBox.Show("Tài khoản hoặc mật khẩu bị sai, mời nhập lại", "Đăng nhập thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textLoginUserName.Text = "";
                    textLoginUserPass.Text = "";
                    textLoginUserName.Focus();
                }
                con.Close();
            }
            
        }

        string find_NV()
        {
            string s = "SELECT EMAIL FROM ACC_USER WHERE USERNAME = '" + textLoginUserName.Text + "'";
            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }
            cmd = new SqlCommand(s, con);
            cmd.CommandType = CommandType.Text;
            da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();

            con.Open();
            SqlDataReader drr;
            cmd = new SqlCommand(s, con);
            cmd.CommandType = CommandType.Text;
            drr = cmd.ExecuteReader();
            if (drr.Read() == true)
            {
                con.Close();
                return dt.Rows[0][0].ToString();
            }
            con.Close();
            return "";
        }

        bool KT_NV()
        {
            con.Open();
            SqlDataReader dr;
            string sql = "SELECT * FROM ACC_USER WHERE EMAIL = '" + tbEmail.Text + "'";
            cmd = new SqlCommand(sql, con);
            dr = cmd.ExecuteReader();
            if (dr.Read() == true)
            {
                con.Close();
                return true;
            } else
            {
                con.Close();
                return false;
            }  
        }

        private void buttonSignUp_Click(object sender, EventArgs e)
        {
            if (textSignUpUserName.Text == "" || textSignUpUserPass.Text == "" || textConfirmPass.Text == "" || tbEmail.Text == "" || tbPhone.Text == "")
            {
                MessageBox.Show("Hãy nhập đầy đủ thông tin", "Đăng ký thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (textSignUpUserPass.Text == textConfirmPass.Text)
            {
                if (KT_NV() == true)
                {
                    con.Open();
                    string regester = "INSERT INTO ACC_USER VALUES ('" + textSignUpUserName.Text + "','" + textSignUpUserPass.Text + "','" + tbEmail.Text + "','" + tbPhone.Text + "','" + kt() + "','null')";
                    cmd = new SqlCommand(regester, con);
                    cmd.ExecuteNonQuery();
                    con.Close();

                    textSignUpUserName.Text = textSignUpUserPass.Text = textConfirmPass.Text = "";

                    MessageBox.Show("Tài khoản của bạn đã được tạo", "Đăng ký thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    panelLogin.Visible = true;
                    panelSignUp.Visible = false;
                }
                else MessageBox.Show("Nhân viên đăng kí không có trong danh sách nhân viên !", "Đăng kí thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);    
            }
            else
            {
                MessageBox.Show("Mật khẩu không trùng khớp, mời nhập lại", "Đăng ký thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textSignUpUserPass.Text = textConfirmPass.Text = "";
                textSignUpUserPass.Focus();
            }
        }

        private void Loginform_Load(object sender, EventArgs e)
        {
            cbP.SelectedIndex = 0;
        }
    }
}
