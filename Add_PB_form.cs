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
using ban_2.Form_selection;

namespace ban_2
{
    public partial class Add_PB_form : Form
    {
        Departments departments = new Departments();
        public Add_PB_form(Departments a)
        {
            InitializeComponent();
            departments = a;
        }

        SqlConnection con = new connect().Con;
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter();

        private bool kt()
        {
            if (tbAddID.Text == "" || tbAddName.Text == "")
            {
                MessageBox.Show("Please fill out all the information!!!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                try
                {
                    con.Open();
                    cmd = con.CreateCommand();
                    cmd.CommandText = "INSERT INTO PHONGBAN (MAPB, TENPHONGBAN)  VALUES ('" + tbAddID.Text + "', N'" + tbAddName.Text + "')";
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Successfully added", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    tbAddID.Text = tbAddName.Text = "";                    
                    this.Close();
                    departments.ketnoicsdl2();
                }
                catch
                {
                    MessageBox.Show("ID department already exists", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btCancel_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
