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
    public partial class NV_info_form : Form
    {
        String maNV;
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-MJVETF2\SQLEXPRESS;Initial Catalog=Quanlynhansu;Integrated Security=True;");
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter();


        public NV_info_form(String a)
        {
            InitializeComponent();
            maNV = a;
        }

        void lay_NV()
        {
            con.Open();
            String sql = "select HOTEN, GIOITINH, NGAYSINH, CCCD, EMAIL, DIACHI, TENCV, SDT, TENPHONGBAN, HOCVAN, isnull(LUONGCOBAN,0) , isnull(LUONGPHEP,0) from CHUCVU full join NHANVIEN on CHUCVU.MACV = NHANVIEN.MACV  full join	PHONGBAN on NHANVIEN.MAPB = PHONGBAN.MAPB  full join BANGLUONG on NHANVIEN.MANV = BANGLUONG.MANV WHERE NHANVIEN.MANV ='" + maNV + "'";
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
            lbSalary.Text = dt.Rows[0][10].ToString() + " VND";
            lbBonus.Text = dt.Rows[0][11].ToString() + " VND";
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void NV_info_form_Load(object sender, EventArgs e)
        {
            lay_NV();
        }

        private bool kt()
        {
            if (tbName.Text == "" || tbIDC.Text == "" || tbEmail.Text == "" || tbDiaChi.Text == "" || tbChucvu.Text == "" || tbPhone.Text == "" || tbPhongBan.Text == "" || (radioButton1.Checked == false && radioButton2.Checked == false))
            {
                MessageBox.Show("Hãy điền đầy đủ thông tin!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void btUpdate_Click(object sender, EventArgs e)
        {
            DialogResult dlr = MessageBox.Show("Bạn có chắc chắc update không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dlr == DialogResult.Yes)
            {
                if (kt())
                {
                    string gt = gioitinh();
                    string MAPB = Get_MAPB();
                    string MACV = Get_MACV();
                    con.Open();
                    cmd = con.CreateCommand();
                    cmd.CommandText = "UPDATE NHANVIEN SET MAPB = '" + MAPB + "', MACV = '" + MACV + "', HOTEN =  N'" + tbName.Text + "', CCCD='" + tbIDC.Text + "', GIOITINH= N'" + gt + "',NGAYSINH = '" + pickerBirthday.Value.ToString("yyyy-MM-dd") + "', SDT = '" + tbPhone.Text + "', EMAIL = '" + tbEmail.Text + "', DIACHI = N'" + tbDiaChi.Text + "', HOCVAN = N'" + tbChuyenNganh.Text + "'WHERE MANV = '" + maNV + "'";
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Update thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    tbName.Text = tbEmail.Text = tbIDC.Text = tbPhone.Text = tbDiaChi.Text = tbChuyenNganh.Text = "";
                    radioButton1.Checked = radioButton2.Checked = false;                    
                    this.Close();
                }
            }
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
                DialogResult dlr = MessageBox.Show("Bạn muốn xóa thành viên này?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlr == DialogResult.Yes)
                {
                try
                {
                    con.Open();
                    cmd = con.CreateCommand();
                    cmd.CommandText = "delete from NHANVIEN where CCCD ='" + tbIDC.Text + "'";
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    this.Close();
                }
                catch
                {
                    MessageBox.Show("Thành viên này đang nằm trong danh sách mượn trả. Không thể xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {

        }
    }
}
