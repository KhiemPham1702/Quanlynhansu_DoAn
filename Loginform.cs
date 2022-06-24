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

        SqlConnection con = new SqlConnection(@"Data Source=NguyenTin;Initial Catalog=Quanlynhansu;Integrated Security=True;");
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter();

        string now = DateTime.Now.ToString();
        int permisstion = 0;

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
                MessageBox.Show("Account or password is empty", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    con.Close();
                    
                    Mainform fmain = new Mainform(email, textLoginUserName.Text, permisstion, now);
                    fmain.Show();
                    this.Hide();
                    textLoginUserName.Text = "";
                    textLoginUserPass.Text = "";
                }
                else
                {
                    con.Close();
                    MessageBox.Show("Invalid account or password, please re-enter", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textLoginUserName.Text = "";
                    textLoginUserPass.Text = "";
                    textLoginUserName.Focus();
                }
                
            }
            
        }

        string find_NV()
        {
            string s = "SELECT EMAIL, PERMISSION FROM ACC_USER WHERE USERNAME = '" + textLoginUserName.Text + "'";
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
                permisstion = int.Parse(dt.Rows[0][1].ToString());
                return dt.Rows[0][0].ToString();
            }
            con.Close();
            return "";
        }

        bool KT_NV()
        {
            con.Open();
            SqlDataReader dr;
            string sql = "SELECT * FROM NHANVIEN WHERE EMAIL = '" + tbEmail.Text + "'";
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
                MessageBox.Show("Please enter the full information", "Registration Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                    MessageBox.Show("Your account has been created", "Successfully registered", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    panelLogin.Visible = true;
                    panelSignUp.Visible = false;
                }
                else MessageBox.Show("Registered employees are not on the employee list!", "Registration Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);    
            }
            else
            {
                MessageBox.Show("Password does not match, please re-enter", "Registration Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
