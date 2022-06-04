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
    public partial class Home : UserControl
    {

        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-MJVETF2\SQLEXPRESS;Initial Catalog=Quanlynhansu;Integrated Security=True;");
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter();

        public Home()
        {
            InitializeComponent();
        }

        private void Home_Load(object sender, EventArgs e)
        {
            load_chart();
            load_NV();
            Sum_salary();
            lbDay.Text = DateTime.Now.ToLongDateString();
            timer1.Start();
            
        }

        private void load_NV()
        {
            con.Open();
            string sql = "SELECT TOP(2) NHANVIEN.MANV, AVATAR FROM NHANVIEN INNER JOIN BANGLUONG ON NHANVIEN.MANV = BANGLUONG.MANV ORDER BY LUONGPHEP DESC";
            cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();

            lbName1.Text = dt.Rows[0][0].ToString();
            lbName2.Text = dt.Rows[1][0].ToString();

            try
            {
                byte[] b = (byte[])dt.Rows[0][1];
                pb1.Image = ByteArrayToImage(b);
                byte[] c = (byte[])dt.Rows[1][1];
                pb2.Image = ByteArrayToImage(c);
            }
            catch
            {

            }
        }

        void Sum_salary()
        {
            con.Open();
            string sql = "SELECT SUM(LUONGNV) FROM(SELECT NHANVIEN.MANV, dbo.TONGLUONG(MANV) as LUONGNV FROM NHANVIEN GROUP BY MANV) AS TL";
            cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();

            string s = dt.Rows[0][0].ToString();

            string[] arrListStr = s.Split('.');
            lbSumSalary.Text = arrListStr[0];
        }

        Image ByteArrayToImage(byte[] b)
        {
            MemoryStream m = new MemoryStream(b);
            return Image.FromStream(m);
        }

        void load_chart()
        {
            con.Open();
            string sql = "select COUNT(MANV) as MEMBER , PHONGBAN.MAPB, TENPHONGBAN from NHANVIEN right join PHONGBAN on NHANVIEN.MAPB = PHONGBAN.MAPB group by PHONGBAN.MAPB, TENPHONGBAN";
            cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();

            chartView.DataSource = dt;
            chartView.ChartAreas["ChartArea1"].AxisX.IsMarginVisible = false;
            chartView.ChartAreas["ChartArea1"].AxisY.IsMarginVisible = false;

            chartView.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.BrightPastel;
            chartView.Series[0].Name = "Employee";

            chartView.Series["Employee"].XValueMember = "TENPHONGBAN";
            chartView.Series["Employee"].YValueMembers = "MEMBER";
            con.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lbTime.Text = DateTime.Now.ToLongTimeString();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
    }
}
