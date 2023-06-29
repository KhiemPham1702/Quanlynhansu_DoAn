using ban_2.Models;
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

namespace ban_2.Form_selection
{
    public partial class Profile : UserControl
    {
        string email;
        int per;
        string path;
        Mainform mainform;


        public Profile()
        {
            InitializeComponent();
        }

        public Profile(string a, int c, Mainform main)
        {
            InitializeComponent();
            email = a;
            per = c;
            this.mainform = main;
        }

        SqlConnection con = new connect().Con;
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter();

        void ketnoicsdl()
        {
            con.Open();
            string sql = "select MANV, HOTEN, GIOITINH, NGAYSINH, DIACHI, HOCVAN, SDT, TENCV, TENPHONGBAN, CCCD from CHUCVU inner join NHANVIEN on CHUCVU.MACV = NHANVIEN.MACV inner join PHONGBAN on NHANVIEN.MAPB = PHONGBAN.MAPB WHERE EMAIL = '" + email + "'";
            cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();

            tbName.Text = dt.Rows[0][1].ToString();
            if (dt.Rows[0][2].ToString() == "Nam") radioButton1.Checked = true;
            else radioButton2.Checked = true;
            pickerBirthday.Text = dt.Rows[0][3].ToString();
            tbDiaChi.Text = dt.Rows[0][4].ToString();
            tbChuyenNganh.Text = dt.Rows[0][5].ToString();
            tbPhone.Text = dt.Rows[0][6].ToString();
            tbChucvu.Text = dt.Rows[0][7].ToString();
            tbDepartment.Text = dt.Rows[0][8].ToString();
            tbIDC.Text = dt.Rows[0][9].ToString();
            tbEmail.Text = email;
        }

        void ketnoicsdl2()
        {
            con.Open();
            string sql = "select EMAIL, USERPASS, AVATAR FROM ACC_USER WHERE EMAIL = '" + Helper.CurrentUser.Email + "'";
            cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();

            tbUserName.Text = dt.Rows[0][0].ToString();
            tbPass.Text = dt.Rows[0][1].ToString();

            try
            {
                byte[] b = (byte[])dt.Rows[0][2];
                picturboxAvatar.Image = ByteArrayToImage(b);
            }
            catch
            {

            }
        }


        private void btChange_Click(object sender, EventArgs e)
        {
            if (tbPass.PasswordChar == '\0')
            {
                tbPass.PasswordChar = '●';
            }
            else
            {
                tbPass.PasswordChar = '\0';
            }
        }

        private void btChangePass_Click(object sender, EventArgs e)
        {
            Form change = new Change_Pass_form(email);
            change.FormClosing += new FormClosingEventHandler(this.Form_Closing);
            change.Show();
        }

        private void Form_Closing(object sender, FormClosingEventArgs e)
        {
            ketnoicsdl2();
            ketnoicsdl();
        }

        private void Profile_Load(object sender, EventArgs e)
        {
            ketnoicsdl();
            ketnoicsdl2();
        }

        private void btChangePicture_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            if (open.ShowDialog() == DialogResult.OK)
            {
                picturboxAvatar.Image = Image.FromFile(open.FileName);
                path = open.FileName;

                byte[] b = ImageToByteArray(picturboxAvatar.Image);
                con.Open();
                cmd = new SqlCommand("UPDATE ACC_USER SET AVATAR = @HINH WHERE EMAIL = @TEN", con);
                cmd.Parameters.Add(new SqlParameter("@TEN", email));
                cmd.Parameters.Add(new SqlParameter("@HINH", b));
                cmd.ExecuteNonQuery();
                con.Close();

                mainform.reset(picturboxAvatar.Image);

                string updateQuery = "UPDATE NHANVIEN SET AVATAR = @AVATAR WHERE EMAIL = @EMAIL";
                var parameters = new object[] { b, email };
                DataProvider.Instance.ExecuteNonQuery(updateQuery, parameters);
            }
            
        }

        byte[] ImageToByteArray(Image image)
        {
            MemoryStream m = new MemoryStream();
            image.Save(m, System.Drawing.Imaging.ImageFormat.Png);
            return m.ToArray();
        }

        Image ByteArrayToImage(byte[] b)
        {
            MemoryStream m = new MemoryStream(b);
            return Image.FromStream(m);
        }
    }
}
