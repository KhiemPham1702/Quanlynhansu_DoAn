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
    public partial class Chart : UserControl
    {
        public Chart()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-MJVETF2\SQLEXPRESS;Initial Catalog=Quanlynhansu;Integrated Security=True;");
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter();

        private void Chart_Load(object sender, EventArgs e)
        {
            cbbStyle.SelectedIndex = 0;
        }

        private void cbbStyle_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbStyle.SelectedItem.ToString() == "Column")
            {
                chartView.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
            }
            else if (cbbStyle.SelectedItem.ToString() == "Pie")
            {
                chartView.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            }
            else if (cbbStyle.SelectedItem.ToString() == "Doughnut")
            {
                chartView.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Doughnut;
            }
            else if (cbbStyle.SelectedItem.ToString() == "Bar")
            {
                chartView.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Bar;
            }
            else if (cbbStyle.SelectedItem.ToString() == "Spline")
            {
                chartView.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            }
        }

        private void cbbStatic_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbbStatic.SelectedItem.ToString() == "Department")
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
                chartView.ChartAreas["ChartArea1"].AxisX.Title = "Departments";
                chartView.ChartAreas["ChartArea1"].AxisY.Title = "Number of employees";

                chartView.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.BrightPastel;
                chartView.Series[0].Name = "Employee";

                chartView.Series["Employee"].XValueMember = "TENPHONGBAN";
                chartView.Series["Employee"].YValueMembers = "MEMBER";
                con.Close();
            } 
        }
    }
}
