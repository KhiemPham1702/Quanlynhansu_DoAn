using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.Entity;

namespace ban_2.Form_selection
{
    public partial class Departments : UserControl
    {
        public Departments()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-MJVETF2\SQLEXPRESS;Initial Catalog=Quanlynhansu;Integrated Security=True;");
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter();

        string sqltc = "select MANV, HOTEN, TENCV, NGAYSINH, SDT, EMAIL, DIACHI from NHANVIEN inner join CHUCVU on NHANVIEN.MACV = CHUCVU.MACV inner join PHONGBAN on NHANVIEN.MAPB = PHONGBAN.MAPB where TENPHONGBAN = N'Nhân sự'";
        string ten_pb = "Nhân sự";

        private void find_Leader()
        {
            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }
            String sql = "select HOTEN from NHANVIEN inner join CHUCVU on NHANVIEN.MACV = CHUCVU.MACV inner join PHONGBAN on NHANVIEN.MAPB = PHONGBAN.MAPB WHERE TENCV = N'Trưởng phòng' and TENPHONGBAN = N'" + ten_pb + "'";
            cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            lbTen.Text = dt.Rows[0][0].ToString();
        }

        private void ketnoicsdl(String sql)
        {
            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }
            cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            dataGridViewNV.DataSource = dt;
        }

        private void ketnoicsdl2()
        {
            con.Open();
            string sql = "select COUNT(MANV) as MEMBER , PHONGBAN.MAPB, TENPHONGBAN from NHANVIEN right join PHONGBAN on NHANVIEN.MAPB = PHONGBAN.MAPB group by PHONGBAN.MAPB, TENPHONGBAN";
            cmd = new SqlCommand(sql , con);
            cmd.CommandType = CommandType.Text;
            da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            dataGridView1.DataSource = dt;
        }

        private void tbTimDP_TextChanged(object sender, EventArgs e)
        {
            if (tbTimDepartment.Text != "")
            {
                con.Open();
                String sql = "select MANV, HOTEN, TENCV, NGAYSINH, SDT, EMAIL, DIACHI from NHANVIEN inner join CHUCVU on NHANVIEN.MACV = CHUCVU.MACV inner join PHONGBAN on NHANVIEN.MAPB = PHONGBAN.MAPB WHERE HOTEN like '%" + tbTimDepartment.Text + "%' and TENPHONGBAN = N'" + cbbDP.SelectedValue.ToString() + "'";
                cmd = new SqlCommand(sql, con);
                cmd.CommandType = CommandType.Text;
                da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                con.Close();
                dataGridViewNV.DataSource = dt;
            }
            else ketnoicsdl(sqltc);
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            Form add = new Add_PB_form();
            add.Show();
        }

        private void Departments_Load(object sender, EventArgs e)
        {            
            ketnoicsdl(sqltc);
            ketnoicsdl2();
            find_Leader();

            string sql = "SELECT TENPHONGBAN FROM PHONGBAN";
            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }
            da = new SqlDataAdapter(sql, con);           
            DataTable tbb = new DataTable();
            da.Fill(tbb);
            cbbDP.DataSource = tbb;
            cbbDP.DisplayMember = "TENPHONGBAN";
            cbbDP.ValueMember = "TENPHONGBAN";
            con.Close();
        }

        private void dataGridViewNV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dataGridViewNV.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                Form form = new NV_info_form(dataGridViewNV.Rows[e.RowIndex].Cells[0].Value.ToString());
                form.Show();
            }
        }

        private void cbbDP_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cbbDP.SelectedValue.ToString() != null)
                {
                    ten_pb = cbbDP.SelectedValue.ToString();
                    String sql = "select MANV, HOTEN, TENCV, NGAYSINH, SDT, EMAIL, DIACHI from NHANVIEN inner join CHUCVU on NHANVIEN.MACV = CHUCVU.MACV inner join PHONGBAN on NHANVIEN.MAPB = PHONGBAN.MAPB where TENPHONGBAN = N'" + ten_pb + "'";
                    if (ten_pb == "System.Data.DataRowView")
                    {
                        ten_pb = "Nhân sự";
                        ketnoicsdl(sqltc);
                    }
                    else
                    {
                        find_Leader();
                        ketnoicsdl(sql);
                    }
                }
            } 
            catch
            {
                MessageBox.Show("Error", "Phòng ban chưa có nhân viên", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    } 
}
