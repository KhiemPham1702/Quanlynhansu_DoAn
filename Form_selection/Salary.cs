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

        SqlConnection con = new SqlConnection(@"Data Source=NguyenTin;Initial Catalog=Quanlynhansu;Integrated Security=True;");
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter();

        public void ketnoicsdl()
        {
            con.Open();
            string sql = "select NHANVIEN.MANV, HOTEN, TENCV, MALUONG, LUONGCOBAN,LUONGPHEP,HESOLUONG  from CHUCVU inner join NHANVIEN on CHUCVU.MACV = NHANVIEN.MACV inner join BANGLUONG on NHANVIEN.MANV = BANGLUONG.MANV WHERE THANG = '"+ picker.Value.Month +"'AND NAM = '" + picker.Value.Year +"'";
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
            picker.Format = DateTimePickerFormat.Custom;
            picker.CustomFormat = "MMM yyyy";
            ketnoicsdl();
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
            ketnoicsdl();
        }

        private void picker_ValueChanged(object sender, EventArgs e)
        {
            ketnoicsdl();
        }
    }
}
