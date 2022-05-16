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

namespace ban_2
{
    public partial class Add_PB_form : Form
    {
        public Add_PB_form()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-MJVETF2\SQLEXPRESS;Initial Catalog=Quanlynhansu;Integrated Security=True;");
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter();

        private bool kt()
        {
            if (tbAddID.Text == "" || tbAddName.Text == "")
            {
                MessageBox.Show("Hãy điền đầy đủ thông tin!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tbAddID_Click(object sender, EventArgs e)
        {
            if (kt())
            {
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "INSERT INTO PHONGBAN (MAPB, TENPHONGBAN)  VALUES ('" + tbAddID.Text + "', N'" + tbAddName.Text + "')";
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tbAddID.Text = tbAddName.Text = "";
                this.Close();
            }
        }
    }
}
