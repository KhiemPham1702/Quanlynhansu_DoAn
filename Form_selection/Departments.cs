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
using System.IO;

namespace ban_2.Form_selection
{
    public partial class Departments : UserControl
    {
        string maPB;
        public Departments()
        {
            InitializeComponent();
        }
        SqlConnection con = new connect().con;
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter();

        string sqltc = "select MANV, HOTEN, TENCV, NGAYSINH, SDT, EMAIL, DIACHI from NHANVIEN inner join CHUCVU on NHANVIEN.MACV = CHUCVU.MACV inner join PHONGBAN on NHANVIEN.MAPB = PHONGBAN.MAPB where TENPHONGBAN = N'Nhân sự'";
        string ten_pb = "Nhân sự";

        Image ByteArrayToImage(byte[] b)
        {
            MemoryStream m = new MemoryStream(b);
            return Image.FromStream(m);
        }


        private void find_Leader()
        {
            picturboxAvatar.Image = null;
            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }
            String sql = "select HOTEN,AVATAR from NHANVIEN inner join CHUCVU on NHANVIEN.MACV = CHUCVU.MACV inner join PHONGBAN on NHANVIEN.MAPB = PHONGBAN.MAPB WHERE TENCV = N'Trưởng phòng' and TENPHONGBAN = N'" + ten_pb + "'";
            cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            lbTen.Text = dt.Rows[0][0].ToString();

            try
            {
                byte[] b = (byte[])dt.Rows[0][1];
                picturboxAvatar.Image = ByteArrayToImage(b);
            }
            catch
            {

            }
        

            
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

        public void ketnoicsdl2()
        {
            con.Open();
            string sql = "select COUNT(MANV) as MEMBER , PHONGBAN.MAPB, TENPHONGBAN from NHANVIEN right join PHONGBAN on NHANVIEN.MAPB = PHONGBAN.MAPB group by PHONGBAN.MAPB, TENPHONGBAN";
            cmd = new SqlCommand(sql, con);
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
            Form add = new Add_PB_form(this);
            add.FormClosing += new FormClosingEventHandler(this.Form_Closing_De);
            add.Show();
        }

        private void Form_Closing_De(object sender, FormClosingEventArgs e)
        {
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
            try
            {
                if (dataGridViewNV.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    NV_info_form form = new NV_info_form(dataGridViewNV.Rows[e.RowIndex].Cells[0].Value.ToString());
                    form.FormClosing += new FormClosingEventHandler(this.Form_Closing);
                    form.Show();
                }
            }
            catch { }
        }

        private void Form_Closing(object sender, FormClosingEventArgs e)
        {
            ketnoicsdl2();
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
                        try
                        {
                            find_Leader();
                        }
                        catch { }
                        ketnoicsdl(sql);
                    }
                }
            }
            catch
            {
                MessageBox.Show("There are no employees in the department!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (con.State != ConnectionState.Open)
                {
                    con.Open();
                }
                string sql = "SELECT TENPHONGBAN FROM PHONGBAN";
                da = new SqlDataAdapter(sql, con);
                DataTable tbb = new DataTable();
                da.Fill(tbb);
                cbbDP.DataSource = tbb;
                cbbDP.DisplayMember = "TENPHONGBAN";
                cbbDP.ValueMember = "TENPHONGBAN";
                con.Close();
            }
        }



        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                maPB = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            }
            catch { }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            DialogResult dlr = MessageBox.Show("Do you want to delete this department?", "Notification", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dlr == DialogResult.Yes)
            {
                if (maPB != null)
                {
                    try
                    {
                        con.Open();
                        cmd = con.CreateCommand();
                        cmd.CommandText = "delete from PHONGBAN where MAPB = '" + maPB + "'";
                        cmd.ExecuteNonQuery();
                        con.Close();
                        MessageBox.Show("Delete successfully", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ketnoicsdl2();
                        if (con.State != ConnectionState.Open)
                        {
                            con.Open();
                        }
                        string sql = "SELECT TENPHONGBAN FROM PHONGBAN";
                        da = new SqlDataAdapter(sql, con);
                        DataTable tbb = new DataTable();
                        da.Fill(tbb);
                        cbbDP.DataSource = tbb;
                        cbbDP.DisplayMember = "TENPHONGBAN";
                        cbbDP.ValueMember = "TENPHONGBAN";
                        con.Close();
                    }
                    catch
                    {
                        MessageBox.Show("This department cannot be deleted!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            
        }
    }
}
