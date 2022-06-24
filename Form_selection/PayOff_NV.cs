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
    public partial class PayOff_NV : UserControl
    {
        SqlConnection con = new SqlConnection(@"Data Source=NguyenTin;Initial Catalog=Quanlynhansu;Integrated Security=True;");
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter();

        string email;

        public void ketnoicsdl()
        {
            con.Open();
            string sql = "select MATP, THUONGPHAT, THOIGIAN, MOTA from THUONGPHAT inner join NHANVIEN ON NHANVIEN.MANV = THUONGPHAT.MANV WHERE NHANVIEN.EMAIL = '" + email + "'";
            cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            dataGridViewPONV.DataSource = dt;
        }
        public PayOff_NV()
        {
            InitializeComponent();
        }

        public PayOff_NV(string a)
        {
            InitializeComponent();
            email = a;
        }

        private void PayOff_NV_Load(object sender, EventArgs e)
        {
            ketnoicsdl();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridViewNV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void guna2ProgressBar1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
