﻿using Aspose.Words;
using Aspose.Words.Tables;
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
using Aspose.Words;
using Aspose.Words.Tables;
using ThuVienWinform.Report.AsposeWordExtension;

namespace ban_2
{
    public partial class NV_info_form : Form
    {
        public String maNV;
        string hsLuong;
        SqlConnection con = new connect().Con;
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter();

        string path;
        double sum;

        public NV_info_form(String a)
        {
            InitializeComponent();
            maNV = a;
        }

        void add_avatar()
        {

        }

        public void lay_salary()
        {
            con.Open();
            String sql = "SELECT TOP(1) LUONGCOBAN, LUONGPHEP FROM NHANVIEN INNER JOIN BANGLUONG ON NHANVIEN.MANV = BANGLUONG.MANV WHERE NHANVIEN.MANV = '" + maNV + "' ORDER BY MALUONG DESC";
            cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();

            string s = dt.Rows[0][0].ToString();
            string[] arrListStr = s.Split('.');
            lbSalary.Text = arrListStr[0];

            string s1 = dt.Rows[0][1].ToString();
            string[] arrListStr1 = s1.Split('.');
            lbBonus.Text = arrListStr1[0];
        }

        public void lay_NV()
        {
            con.Open();
            String sql = "select HOTEN, GIOITINH, NGAYSINH, CCCD, EMAIL, DIACHI, TENCV, SDT, TENPHONGBAN, HOCVAN, isnull(LUONGCOBAN,0) , isnull(LUONGPHEP,0), AVATAR from CHUCVU full join NHANVIEN on CHUCVU.MACV = NHANVIEN.MACV  full join	PHONGBAN on NHANVIEN.MAPB = PHONGBAN.MAPB  full join BANGLUONG on NHANVIEN.MANV = BANGLUONG.MANV WHERE NHANVIEN.MANV ='" + maNV + "'";
            cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();

            tbName.Text = dt.Rows[0][0].ToString();
            string gt = dt.Rows[0][1].ToString();
            if (gt == "Nam") radioButton1.Checked = true;
            else if (gt == "Nữ") radioButton2.Checked = true;
            pickerBirthday.Text = dt.Rows[0][2].ToString();
            tbIDC.Text = dt.Rows[0][3].ToString();
            tbEmail.Text = dt.Rows[0][4].ToString();
            tbDiaChi.Text = dt.Rows[0][5].ToString();
            tbChucvu.Text = dt.Rows[0][6].ToString();
            tbPhone.Text = dt.Rows[0][7].ToString();
            tbPhongBan.Text = dt.Rows[0][8].ToString();
            tbChuyenNganh.Text = dt.Rows[0][9].ToString();

            lbTen.Text = dt.Rows[0][0].ToString();
            lbChucVu.Text = dt.Rows[0][6].ToString();

            sum = float.Parse(dt.Rows[0][10].ToString()) * pick_hsl2() + float.Parse(dt.Rows[0][11].ToString());



            try
            {
                byte[] b = (byte[])dt.Rows[0][12];
                picturboxAvatar.Image = ByteArrayToImage(b);
            }
            catch
            {

            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void NV_info_form_Load(object sender, EventArgs e)
        {
            lay_NV();
            lay_salary();
            add_avatar();
        }

        private bool kt()
        {
            if (tbName.Text == "" || tbIDC.Text == "" || tbEmail.Text == "" || tbDiaChi.Text == "" || tbChucvu.Text == "" || tbPhone.Text == "" || tbPhongBan.Text == "" || (radioButton1.Checked == false && radioButton2.Checked == false))
            {
                MessageBox.Show("Please fill out the form!!!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        private string gioitinh()
        {
            if (radioButton1.Checked == true)
                return "Nam";
            if (radioButton2.Checked == true)
                return "Nữ";
            return "";
        }

        string Get_MACV()
        {
            string sql = "SELECT MACV FROM CHUCVU WHERE TENCV = N'" + tbChucvu.Text + "'";
            con.Open();
            cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt.Rows[0][0].ToString();
        }

        string Get_MAPB()
        {
            string sql = "SELECT MAPB FROM PHONGBAN WHERE TENPHONGBAN = N'" + tbPhongBan.Text + "'";
            con.Open();
            cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt.Rows[0][0].ToString();
        }

        bool Check_TP()
        {
            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }
            SqlDataReader dr;
            string sql = "select NHANVIEN.MANV,NHANVIEN.HOTEN,NHANVIEN.MAPB,PHONGBAN.TENPHONGBAN,CHUCVU.TENCV from PHONGBAN, NHANVIEN, CHUCVU where PHONGBAN.MAPB = NHANVIEN.MAPB and NHANVIEN.MACV = CHUCVU.MACV and CHUCVU.TENCV = N'Trưởng phòng' and TENPHONGBAN = N'" + tbPhongBan.Text.ToString() + "'";
            cmd = new SqlCommand(sql, con);
            dr = cmd.ExecuteReader();
            if (dr.Read() == true)
            {
                con.Close();
                return false;
            }
            else
            {
                con.Close();
                return true;
            }
        }

        bool Check_PP()
        {
            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }
            SqlDataReader dr;
            String sql = "select NHANVIEN.MANV,NHANVIEN.HOTEN,NHANVIEN.MAPB,PHONGBAN.TENPHONGBAN,CHUCVU.TENCV from PHONGBAN, NHANVIEN, CHUCVU where PHONGBAN.MAPB = NHANVIEN.MAPB and NHANVIEN.MACV = CHUCVU.MACV and CHUCVU.TENCV = N'Phó phòng' and TENPHONGBAN = N'" + tbPhongBan.Text.ToString() + "'";
            cmd = new SqlCommand(sql, con);
            dr = cmd.ExecuteReader();
            if (dr.Read() == true)
            {
                con.Close();
                return false;
            }
            else
            {
                con.Close();
                return true;
            }
        }

        void Update_TV(string MAPB, string MACV, string gt)
        {
            con.Open();
            cmd = con.CreateCommand();
            cmd.CommandText = "UPDATE NHANVIEN SET MAPB = '" + MAPB + "', MACV = '" + MACV + "', HOTEN =  N'" + tbName.Text + "', CCCD='" + tbIDC.Text + "', GIOITINH= N'" + gt + "',NGAYSINH = '" + pickerBirthday.Value.ToString("yyyy-MM-dd") + "', SDT = '" + tbPhone.Text + "', EMAIL = '" + tbEmail.Text + "', DIACHI = N'" + tbDiaChi.Text + "', HOCVAN = N'" + tbChuyenNganh.Text + "'WHERE MANV = '" + maNV + "'";
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Update successfully", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
            tbName.Text = tbEmail.Text = tbIDC.Text = tbPhone.Text = tbDiaChi.Text = tbChuyenNganh.Text = "";
            radioButton1.Checked = radioButton2.Checked = false;
            this.Close();
        }

        private void btUpdate_Click(object sender, EventArgs e)
        {
            DialogResult dlr = MessageBox.Show("Are you sure to update?", "Notification", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dlr == DialogResult.Yes)
            {
                if (kt())
                {
                    try
                    {
                        string gt = gioitinh();
                        string MAPB = Get_MAPB();
                        string MACV = Get_MACV();

                        if (MACV == "CV001")
                        {
                            if (Check_TP() == true)
                            {
                                Update_TV(MAPB, MACV, gt);
                            }
                            else
                                MessageBox.Show("This department already has a head", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        }
                        else if (MACV == "CV002")
                        {
                            if (Check_PP() == true)
                            {
                                Update_TV(MAPB, MACV, gt);
                            }
                            else
                                MessageBox.Show("This department already has a deputy", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else Update_TV(MAPB, MACV, gt);
                    }
                    catch
                    {
                        MessageBox.Show("Update error", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    lay_NV();

                }
            }
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            DialogResult dlr = MessageBox.Show("Do you want to delete this employee?", "Notification", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dlr == DialogResult.Yes)
            {
                try
                {
                    con.Open();
                    cmd = con.CreateCommand();
                    cmd.CommandText = "delete from NHANVIEN where CCCD ='" + tbIDC.Text + "'";
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Delete successfully", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                catch
                {
                    MessageBox.Show("This employee cannot be deleted!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }


        private void btChangePicture_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            if (open.ShowDialog() == DialogResult.OK)
            {
                picturboxAvatar.Image = Image.FromFile(open.FileName);
                path = open.FileName;
            }
            
            byte[] b = ImageToByteArray(picturboxAvatar.Image);
            con.Open();
            cmd = new SqlCommand("UPDATE NHANVIEN SET AVATAR = @HINH WHERE MANV = @TEN", con);
            cmd.Parameters.Add(new SqlParameter("@TEN", maNV));
            cmd.Parameters.Add(new SqlParameter("@HINH", b));
            cmd.ExecuteNonQuery();
            con.Close();

            string updateQuery = "UPDATE ACC_USER SET AVATAR = @AVATAR WHERE EMAIL = @EMAIL";
            var parameters = new object[] { b, tbEmail.Text };
            DataProvider.Instance.ExecuteNonQuery(updateQuery, parameters);
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

        float pick_hsl2()
        {
            string sql = "SELECT TOP(1) HESOLUONG FROM NHANVIEN INNER JOIN BANGLUONG ON NHANVIEN.MANV = BANGLUONG.MANV WHERE NHANVIEN.MANV = '" + maNV + "' ORDER BY  NAM DESC, THANG DESC";
            con.Open();
            cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            try
            {
                return float.Parse(dt.Rows[0][0].ToString());
            }
            catch
            {
                return 1;
            }
        }

        string pick_hsl()
        {
            string sql = "SELECT TOP(1) HESOLUONG FROM NHANVIEN INNER JOIN BANGLUONG ON NHANVIEN.MANV = BANGLUONG.MANV WHERE NHANVIEN.MANV = '" + maNV + "' ORDER BY  NAM DESC, THANG DESC";
            con.Open();
            cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt.Rows[0][0].ToString();
        }

        private void btPrintSalary_Click_1(object sender, EventArgs e)
        {
            var homNay = DateTime.Now;
            hsLuong = pick_hsl();
            //Bước 1: Nạp file mẫu
            Document baoCao = new Document(@"D:\Long\CSharp\ban 2\Tamplate\Maubaocao.doc");

            //Bước 2: Điền các thông tin cố định
            baoCao.MailMerge.Execute(new[] { "ID" }, new[] { tbIDC.Text });
            baoCao.MailMerge.Execute(new[] { "Name" }, new[] { tbName.Text });
            baoCao.MailMerge.Execute(new[] { "DP" }, new[] { tbPhongBan.Text });
            baoCao.MailMerge.Execute(new[] { "CV" }, new[] { tbChucvu.Text });
            baoCao.MailMerge.Execute(new[] { "LUONGCOBAN" }, new[] { lbSalary.Text });
            baoCao.MailMerge.Execute(new[] { "LUONGPHEP" }, new[] { lbBonus.Text });
            baoCao.MailMerge.Execute(new[] { "HESOLUONG" }, new[] { hsLuong });

            baoCao.MailMerge.Execute(new[] { "Ngay_Thang_Nam_BC" }, new[] { string.Format("UIT, ngày {0} tháng {1} năm {2}", homNay.Day, homNay.Month, homNay.Year) });
            baoCao.MailMerge.Execute(new[] { "TONGLUONG" }, new[] { sum.ToString() });
            //Bước 4: Lưu và mở file
            baoCao.SaveAndOpenFile("BaoCao.doc");
        }

        private void btUpSalary_Click(object sender, EventArgs e)
        {
            DialogResult dlr = MessageBox.Show("Are you sure to update?", "Notification", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dlr == DialogResult.Yes)
            {
                if (kt())
                {
                    con.Open();
                    cmd = con.CreateCommand();
                    cmd.CommandText = "UPDATE BANGLUONG SET LUONGCOBAN = '" + decimal.Parse(lbSalary.Text) + "' WHERE MANV = '" + maNV + "' AND MALUONG = (SELECT TOP(1) MALUONG FROM BANGLUONG WHERE MANV = '" + maNV + "' ORDER BY MALUONG DESC)";
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Update successfully", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                    lay_salary();
                }
            }

        }

        private void btDetail_Click(object sender, EventArgs e)
        {
            Form add = new Update_Salary(this);
            add.FormClosing += new FormClosingEventHandler(this.Form_Closing);
            add.Show();
        }

        private void Form_Closing(object sender, FormClosingEventArgs e)
        {
            lay_NV();
            lay_salary();
        }

        private void lbSalary_TextChanged(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }
    }
}
