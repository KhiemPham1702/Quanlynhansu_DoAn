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
    public partial class Furlough : UserControl
    {
        string maNP = " ";

        SqlConnection con = new SqlConnection(@"Data Source=NguyenTin;Initial Catalog=Quanlynhansu;Integrated Security=True;");
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter();

        public void ketnoicsdl()
        {
            con.Open();
            string sql = "select MANP, NHANVIEN.MANV, HOTEN, NGAYNGHI, NGHIDEN, LYDO from NHANVIEN inner join NGHIPHEP ON NHANVIEN.MANV = NGHIPHEP.MANV";
            cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            dataGridViewNP.DataSource = dt;
        }
        public Furlough()
        {
            InitializeComponent();
        }
        private void dataGridViewTV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                maNP = dataGridViewNP.Rows[e.RowIndex].Cells[0].Value.ToString();
            }
            catch { }
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            DialogResult dlr = MessageBox.Show("Do you want to delete this furlough?", "Notification", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dlr == DialogResult.Yes)
            {
                if (maNP != null)
                {
                    try
                    {
                        con.Open();
                        cmd = con.CreateCommand();
                        cmd.CommandText = "delete from NGHIPHEP where MANP = '" + maNP + "'";
                        cmd.ExecuteNonQuery();
                        con.Close();
                        MessageBox.Show("Delete successfully", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ketnoicsdl();
                    }
                    catch
                    {
                        MessageBox.Show("This furlough cannot be deleted!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }

        }

        private void Furlough_Load(object sender, EventArgs e)
        {
            ketnoicsdl();
        }

    }
}
