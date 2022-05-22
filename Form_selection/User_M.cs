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
    public partial class User_M : UserControl
    {
        public User_M()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-MJVETF2\SQLEXPRESS;Initial Catalog=Quanlynhansu;Integrated Security=True;");
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter();

        public void ketnoicsdl()
        {
            con.Open();
            string sql = "select * from QL_USER";
            cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            dataGridViewUser.DataSource = dt;
        }

        private void User_M_Load(object sender, EventArgs e)
        {
            ketnoicsdl();
        }

        private void tbTimUser_TextChanged(object sender, EventArgs e)
        {
            if (tbTimUser.Text != "")
            {
                con.Open();
                String sql = "select * from QL_USER WHERE QLNAME like '%" + tbTimUser.Text + "%'";
                cmd = new SqlCommand(sql, con);
                cmd.CommandType = CommandType.Text;
                da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                con.Close();
                dataGridViewUser.DataSource = dt;
            }
            else ketnoicsdl();
        }
    }
}
