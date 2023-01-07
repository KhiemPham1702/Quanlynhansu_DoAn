using ban_2.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ban_2
{
    public partial class Loginform : Form
    {

        SqlConnection con = new connect().Con;
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter();

        string now = DateTime.Now.ToString();
        int permisstion = 0;
        public int VerifiCode { get; set; }
        public int CheckCode { get; set; }
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
            txtEmail.Text = textLoginUserPass.Text = "";
        }

        private void lbLoginChange_Click(object sender, EventArgs e)
        {
            panelLogin.Visible = true;
            panelSignUp.Visible = false;
            textSignUpUserPass.Text = tbEmail.Text = tbPhone.Text = textConfirmPass.Text = "";
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

        private void txbValue_TextChanged(object sender, EventArgs e)
        {
            Int64 num = 0;

            if (Int64.TryParse(tbPhone.Text, out num))
            { }    
            else
            {
                if(tbPhone.Text != "") MessageBox.Show("Only input number", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tbPhone.Text = "";
            }
        }

        public void buttonLogin_Click(object sender, EventArgs e)
        {
            if (txtEmail.Text == "" || textLoginUserPass.Text == "")
            {
                MessageBox.Show("Account or password is empty", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string email = find_NV();
                SqlDataReader dr;

                string sql = $"SELECT * FROM ACC_USER WHERE EMAIL = @EMAIL AND USERPASS = @USERPASS";
                var parameters = new object[] { txtEmail.Text.Trim(), textLoginUserPass.Text.Trim() };
                var data = DataProvider.Instance.ExecuteQuery(sql, parameters);
               
                if (data.Rows.Count !=0)
                {
                    Helper.CurrentUser = new User()
                    {
                        Avatar = (byte[])data.Rows[0]["Avatar"],
                        Email = (string)data.Rows[0]["Email"],
                        Permission = (int)data.Rows[0]["Permission"],
                        SDT = (string)data.Rows[0]["SDT"],
                        UserPass = (string)data.Rows[0]["UserPass"],
                    };
                    Mainform fmain = new Mainform(email, txtEmail.Text, permisstion, now);
                    MessageBox.Show("Welcome! Have a good day", "Login Successfuly", MessageBoxButtons.OK, MessageBoxIcon.None);
                    fmain.Show();
                    this.Hide();
                    txtEmail.Text = "";
                    textLoginUserPass.Text = "";
                }
                else
                {
                    Mainform fmain = new Mainform();
                    fmain.Hide();
                    con.Close();
                    MessageBox.Show("Invalid account or password, please re-enter", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtEmail.Text = "";
                    textLoginUserPass.Text = "";
                    txtEmail.Focus();
                }

            }

        }



        string find_NV()
        {
            string s = "SELECT EMAIL, PERMISSION FROM ACC_USER WHERE EMAIL = '" + txtEmail.Text + "'";
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

        bool KT_Email()
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
            }
            else
            {
                con.Close();
                return false;
            }
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
            }
            else
            {
                con.Close();
                return false;
            }
        }

        bool KT_ACC()
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
            }
            else
            {
                con.Close();
                return false;
            }
        }

        private void buttonSignUp_Click(object sender, EventArgs e)
        {
            if ( textSignUpUserPass.Text == "" || textConfirmPass.Text == "" || tbEmail.Text == "" || tbPhone.Text == "")
            {
                MessageBox.Show("Please enter the full information", "Registration Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (KT_Email())
            {
                MessageBox.Show("Email already existed", "Registration Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tbEmail.Text = "";
                tbEmail.Focus();
            }
            else if (textSignUpUserPass.Text == textConfirmPass.Text)
            {
                if (KT_NV() == true)
                {
                    if(KT_ACC() == false)
                    {
                        con.Open();
                        string regester = "INSERT INTO ACC_USER VALUES ('" + tbEmail.Text + "','" + textSignUpUserPass.Text + "','" + tbPhone.Text + "','" + kt() + "','null')";
                        cmd = new SqlCommand(regester, con);
                        cmd.ExecuteNonQuery();
                        con.Close();

                        tbEmail.Text = textSignUpUserPass.Text = textConfirmPass.Text = "";

                        MessageBox.Show("Your account has been created", "Successfully registered", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        panelLogin.Visible = true;
                        panelSignUp.Visible = false;
                    }
                    else MessageBox.Show("Employee has registered an account!", "Registration Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblForgotPass_Click(object sender, EventArgs e)
        {

            panelLogin.Visible = false;
            pnlForgotPass1.Visible = true;
            pnlForgotPass1.Dock = DockStyle.Left;
            txtEmail.Text = textLoginUserPass.Text = "";
            txtForgotPassEmail.Text = "";
        }

        private void lblFPLogin_Click(object sender, EventArgs e)
        {
            panelLogin.Visible = true;
            pnlForgotPass1.Visible = false;
            panelLogin.Dock = DockStyle.Left;
            txtForgotPassEmail.Text = "";
        }

       
        private void btnSend_Click(object sender, EventArgs e)
        {
            if (txtForgotPassEmail.Text == "")
            {
                MessageBox.Show("Email is empty", "Email Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                con.Open();
                SqlDataReader dr;
                string forgot = "SELECT * FROM ACC_USER WHERE EMAIL= '" + txtForgotPassEmail.Text.Trim() + "'";
                cmd = new SqlCommand(forgot, con);
                dr = cmd.ExecuteReader();
                if (dr.Read() == true)
                {
                    con.Close();
                    RefreshVerifyPanel();
                    SendCodeVerify();
                }
                else
                {
                    con.Close();
                    MessageBox.Show("Email does not exist, please re-enter", "Email Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtForgotPassEmail.Text = "";
                    txtForgotPassEmail.Focus();
                }

            }
        }

        private void CreateCodeRandom()
        {
            pnlVerify.Visible = true;
            pnlForgotPass1.Visible = false;
            pnlVerify.Dock = DockStyle.Left;

            // Tạo đối tượng Random
            Random random = new Random();

            // Chọn một giá trị ngẫu nhiên từ 0 đến 3
            int randomIndex = random.Next(0, 4);

            // Thiết lập giá trị text của nút được chọn là 20
            string selectedButtonText = VerifiCode.ToString();
            Guna.UI2.WinForms.Guna2CircleButton selectedButton = null;

            switch (randomIndex)
            {
                case 0:
                    btnCode1.Text = selectedButtonText;
                    selectedButton = btnCode1;
                    break;
                case 1:
                    btnCode2.Text = selectedButtonText;
                    selectedButton = btnCode2;
                    break;
                case 2:
                    btnCode3.Text = selectedButtonText;
                    selectedButton = btnCode3;
                    break;
                case 3:
                    btnCode4.Text = selectedButtonText;
                    selectedButton = btnCode4;
                    break;
            }


            // Thiết lập giá trị text của các nút còn lại
            foreach (Guna.UI2.WinForms.Guna2CircleButton button in new[] { btnCode1, btnCode2, btnCode3, btnCode4 }.Except(new[] { selectedButton }))
            {
                int randomButtonIndex = random.Next(1, 100);
                button.Text = randomButtonIndex.ToString("D2");
            }

        }

        private void SendCodeVerify()
        {
            Random random = new Random();
            int randomNumber = random.Next(1, 100);
            VerifiCode = randomNumber;
            // Thiết lập thông tin email
            string fromEmail = "manrunning101@gmail.com";
            string toEmail = txtForgotPassEmail.Text;
            string subject = "Forgot Password";
            string body = $"Your code verify is: {randomNumber:D2}";

            // Tạo đối tượng MailMessage
            MailMessage message = new MailMessage(fromEmail, toEmail, subject, body);

            // Thiết lập thông tin SMTP server
            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = new NetworkCredential(fromEmail, "dggsnlyeyaozlyjk");
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtpClient.EnableSsl = true;

            // Gửi email
            try
            {
                smtpClient.Send(message);
                CreateCodeRandom();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Email", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

       

        private void pnlVerify_Paint(object sender, PaintEventArgs e)
        {

        }

        Guna.UI2.WinForms.Guna2CircleButton lastSelectedButton = null;

        // Sự kiện Click của button
        private void btnCode_Click(object sender, EventArgs e)
        {
            Guna.UI2.WinForms.Guna2CircleButton selectedButton = (Guna.UI2.WinForms.Guna2CircleButton)sender;

            // Nếu đã có button được chọn gần đây thì thiết lập màu nền cho nó là Transparent
            if (lastSelectedButton != null)
            {
                lastSelectedButton.FillColor = Color.Transparent;
            }

            // Thiết lập màu nền cho button được chọn là DarkGray
            selectedButton.FillColor = Color.DarkGray;
            CheckCode = int.Parse(selectedButton.Text);
            btnConfirm.Enabled = true;
            // Lưu trữ button được chọn gần đây
            lastSelectedButton = selectedButton;
        }

        private void lblResendCode_Click(object sender, EventArgs e)
        {
            RefreshVerifyPanel();
            SendCodeVerify();
        }

        private void RefreshVerifyPanel()
        {
            btnConfirm.Enabled = false;
            btnCode1.FillColor = btnCode2.FillColor = btnCode3.FillColor = btnCode4.FillColor = Color.Transparent;
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if(CheckCode == VerifiCode)
            {
                pnlNewPass.Visible = true;
                pnlVerify.Visible = false;
                pnlNewPass.Dock = DockStyle.Left;
                RefreshNewPassPanel();
            }
            else
            {
                MessageBox.Show("Your code is wrong", "Verify Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                pnlVerify.Visible = false;
                panelLogin.Visible = true;
                panelLogin.Dock = DockStyle.Left;
            }
        }

        private void lvlVerifyLogin_Click(object sender, EventArgs e)
        {
            panelLogin.Visible = true;
            pnlVerify.Visible = false;
            panelLogin.Dock = DockStyle.Left;
        }

        private void lblNewPassLogin_Click(object sender, EventArgs e)
        {
            panelLogin.Visible = true;
            pnlNewPass.Visible = false;
            panelLogin.Dock = DockStyle.Left;
        }

        private void RefreshNewPassPanel()
        {
            txtConfirmNewPass.Text = txtNewPass.Text = "";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtConfirmNewPass.Text) || string.IsNullOrEmpty(txtNewPass.Text))
            {
                MessageBox.Show("Please enter the full information", "Save Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                con.Open();
                string update = "UPDATE ACC_USER SET USERPASS = '" + txtNewPass.Text + "'WHERE EMAIL = '" + txtForgotPassEmail.Text + "'";
                cmd = new SqlCommand(update, con);
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Please login again", "Successfully save password", MessageBoxButtons.OK, MessageBoxIcon.Information);
                panelLogin.Visible = true;
                panelLogin.Dock = DockStyle.Left;
                pnlNewPass.Visible = false;
            }
        }

        private void Loginform_Move(object sender, EventArgs e)
        {

        }

        private void Loginform_MouseDown(object sender, MouseEventArgs e)
        {
        }
    }

}
