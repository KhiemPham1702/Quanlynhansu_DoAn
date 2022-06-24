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

namespace ban_2.Form_selection
{
    public partial class Furlough_Employee : UserControl
    {
        public string maNP = " ";
        string email;
        public string maNV;

        SqlConnection con = new SqlConnection(@"Data Source=NguyenTin;Initial Catalog=Quanlynhansu;Integrated Security=True;");
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter();

        public void SelectfromEmail()
        {
            con.Open();
            string sql = "select MANV from NHANVIEN WHERE EMAIL = '" + email + "'";
            cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            maNV = dt.Rows[0][0].ToString();
        }

        public void ketnoicsdl()
        {
            con.Open();
            string sql = "select MANP, NGAYNGHI, NGHIDEN, LYDO from NHANVIEN inner join NGHIPHEP ON NHANVIEN.MANV = NGHIPHEP.MANV WHERE NHANVIEN.MANV = '" + maNV + "'";
            cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            dataGridViewNP.DataSource = dt; 
        }

        public void ketnoicsdlbang2()
        {
            con.Open();
            string sql = "select MATP, THUONGPHAT, THOIGIAN, MOTA from THUONGPHAT inner join NHANVIEN ON NHANVIEN.MANV = THUONGPHAT.MANV WHERE NHANVIEN.MANV = '" + maNV + "'";
            cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            dataGridViewTP.DataSource = dt;
        }

        public Furlough_Employee()
        {
            InitializeComponent();
        }

        public Furlough_Employee(string a)
        {
            InitializeComponent();
            email = a;
        }

        private void Furlough_Employee_Load(object sender, EventArgs e)
        {
            SelectfromEmail();
            ketnoicsdl();
            ketnoicsdlbang2();
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            Form add = new Add_Furrlough(this);
            add.Show();
        }

    }
}
