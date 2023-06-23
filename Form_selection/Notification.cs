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
    public partial class Notification : UserControl
    {
        SqlConnection con = new connect().Con;
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter();
        DataTable data = new DataTable();
        public Notification()
        {
            InitializeComponent();
        }

        string sqltc = "select MANV, HOTEN from NHANVIEN";
        string sqltc2 = "select MANV,HOTEN,THOIGIAN,NOIDUNG from THONGBAO";

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
            da.Fill(data);
            cbbNV.DataSource = dt;
            cbbNV.DisplayMember = "HOTEN";
            cbbNV.ValueMember = "HOTEN";
            con.Close();
            dataGridViewTB.DataSource = dt;
        }

        private void ketnoicsdl2(String sql)
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
            dataGridViewTB.DataSource = dt;
        }

        private bool kt()
        {
            if (tbND.Text == "")
            {
                MessageBox.Show("Please fill out all the information!!!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void Notification_Load(object sender, EventArgs e)
        {
            ketnoicsdl(sqltc);
            ketnoicsdl2(sqltc2);
        }

        private void btSend_Click(object sender, EventArgs e)
        {
            if(kt())
            {
                try
                {
                    

                    string maNV = "";
                    DataRow[] rows = data.Select("HOTEN = '" + cbbNV.Text + "'");
                    if (rows.Length > 0)
                    {
                        maNV = rows[0]["MaNV"].ToString();
                    }

                    int loai;
                    string all = cbbNV.Text;
                    if (tgAll.Checked == true)
                    {
                        loai = 1;
                        all = "Thông báo chung";
                        maNV = "ALL";
                    }
                    else loai = 0;

                    con.Open();
                    cmd = con.CreateCommand();
                    cmd.CommandText = "INSERT INTO THONGBAO (MANV,LOAI,NOIDUNG,THOIGIAN,HOTEN, TRANGTHAI)  VALUES ('" + maNV + "','" + loai + "', N'" + tbND.Text + "','" + DateTime.Now.ToString() + "',N'" + all + "','" + 0 + "')";
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Successfully sended", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    tbND.Text = "";
                    ketnoicsdl2(sqltc2);
                }
                catch
                {
                    MessageBox.Show("Send notification failed", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void tgAll_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
