using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace ban_2.Form_selection
{
    public partial class Employee : UserControl
    {
        public Employee()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-MJVETF2\SQLEXPRESS;Initial Catalog=Quanlynhansu;Integrated Security=True;");
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter();

        public void ketnoicsdl()
        {
            con.Open();
            string sql = "select MANV, HOTEN, GIOITINH, CCCD, NGAYSINH, DIACHI, HOCVAN, SDT, TENPHONGBAN, TENCV from CHUCVU inner join NHANVIEN on CHUCVU.MACV = NHANVIEN.MACV inner join PHONGBAN on NHANVIEN.MAPB = PHONGBAN.MAPB  ";
        
            cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            dataGridViewNV.DataSource = dt;
        }

        private void btAddNew_Click(object sender, EventArgs e)
        {
            Form add = new Add_TV_form();
            add.Show();
        }

        private void Employee_Load(object sender, EventArgs e)
        {
            ketnoicsdl();
        }

        private void tbTimNHANVIEN_TextChanged(object sender, EventArgs e)
        {
            if (tbTimNHANVIEN.Text != "")
            {
                con.Open();
                String sql = "select MANV, HOTEN, GIOITINH, CCCD, NGAYSINH, DIACHI, HOCVAN, SDT, TENPHONGBAN, TENCV from CHUCVU inner join NHANVIEN on CHUCVU.MACV = NHANVIEN.MACV inner join PHONGBAN on NHANVIEN.MAPB = PHONGBAN.MAPB WHERE HOTEN  like '%" + tbTimNHANVIEN.Text + "%'";
                cmd = new SqlCommand(sql, con);
                cmd.CommandType = CommandType.Text;
                da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                con.Close();
                dataGridViewNV.DataSource = dt;
            }
            else ketnoicsdl();
        }

        private void dataGridViewNV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewNV.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                Form form = new NV_info_form(dataGridViewNV.Rows[e.RowIndex].Cells[0].Value.ToString());
                form.Show();
            }      
        }
    }
}
