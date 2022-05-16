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

namespace ban_2.Form_selection
{
    public partial class Salary : UserControl
    {
        public Salary()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-MJVETF2\SQLEXPRESS;Initial Catalog=Quanlynhansu;Integrated Security=True;");
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter();

        private void ketnoicsdl()
        {
            con.Open();
            string sql = "select NHANVIEN.MANV, HOTEN, TENCV, MALUONG, LUONGCOBAN,LUONGPHEP,HESOLUONG  from CHUCVU inner join NHANVIEN on CHUCVU.MACV = NHANVIEN.MACV inner join BANGLUONG on NHANVIEN.MANV = BANGLUONG.MANV";
            cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            dataGridViewNV.DataSource = dt;
        }

        private void tbTimL_TextChanged(object sender, EventArgs e)
        {
            if (tbTimL.Text != "")
            {
                con.Open();
                string sql = "select NHANVIEN.MANV, HOTEN, TENCV, MALUONG, LUONGCOBAN,LUONGPHEP,HESOLUONG  from CHUCVU inner join NHANVIEN on CHUCVU.MACV = NHANVIEN.MACV inner join BANGLUONG on NHANVIEN.MANV = BANGLUONG.MANV WHERE HOTEN like '%" + tbTimL.Text + "%'";
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


        private void Salary_Load(object sender, EventArgs e)
        {
            ketnoicsdl();
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
