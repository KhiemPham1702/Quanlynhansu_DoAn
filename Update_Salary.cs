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
    public partial class Update_Salary : Form
    {
        NV_info_form NIF;

        SqlConnection con = new SqlConnection(@"Data Source=NguyenTin;Initial Catalog=Quanlynhansu;Integrated Security=True;");
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter();
        public Update_Salary(NV_info_form a)
        {
            InitializeComponent();
            NIF = a;
        }

        public void ketnoicsdl()
        {
            con.Open();
            string sql = "select MATP, THUONGPHAT, THOIGIAN, MOTA from THUONGPHAT inner join NHANVIEN ON NHANVIEN.MANV = THUONGPHAT.MANV WHERE NHANVIEN.MANV = '" + NIF.maNV + "'";
            cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            dataGridViewPO.DataSource = dt;
        }

        private void dataGridViewNV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewPO.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                NV_info_form form = new NV_info_form(dataGridViewPO.Rows[e.RowIndex].Cells[0].Value.ToString());
                form.FormClosing += new FormClosingEventHandler(this.Form_Closing);
                form.Show();
            }
        }

        private void Form_Closing(object sender, FormClosingEventArgs e)
        {
            ketnoicsdl();
        }

        private void Update_Salary_Load(object sender, EventArgs e)
        {
            ketnoicsdl();
        }

        private bool kt()
        {
            if (tbDetail.Text == "" || (radioButton1.Checked == false && radioButton2.Checked == false))
            {
                MessageBox.Show("Please fill out all the information!!!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        private string Thuongphat()
        {
            if (radioButton1.Checked == true)
                return "Thuong";
            if (radioButton2.Checked == true)
                return "Phat";
            return "";
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            if (kt())
            {
                string tp = Thuongphat();
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "INSERT INTO THUONGPHAT (MANV, MOTA , THUONGPHAT, THOIGIAN) VALUES ('" + NIF.maNV + "', N'" + tbDetail.Text + "', N'" + tp + "','" + pickerTime.Value.ToString("yyyy-MM-dd") + "')";
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Add successfully", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tbDetail.Text = "";
                radioButton1.Checked = radioButton2.Checked = false;
                this.ketnoicsdl();

            }
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
