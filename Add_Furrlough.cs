using ban_2.Form_selection;
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
    public partial class Add_Furrlough : Form
    {
        Furlough_Employee FE;

        SqlConnection con = new connect().Con;
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter();

        public Add_Furrlough(Furlough_Employee a)
        {
            InitializeComponent();
            FE = a;
        }

        private bool kt()
        {
            int result = DateTime.Compare(DateTime.Parse(PickerTBack.Text), DateTime.Parse(PickerTOff.Text));
            if (result <= 0)
            {
                MessageBox.Show("'Time Back' must be greater than 'Ngày nghỉ'", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        private void btAdd_Click(object sender, EventArgs e)
        {
            if (kt())
            {
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "INSERT INTO NGHIPHEP (MANV, NGAYNGHI, NGHIDEN, LYDO)  VALUES ('" + FE.maNV + "', '" + PickerTOff.Value.ToString("yyyy-MM-dd") + "', '" + PickerTBack.Value.ToString("yyyy-MM-dd") + "', N'" + tbReason.Text + "')";
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Successfully added", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tbReason.Text = "";
                
                this.Close();
                FE.ketnoicsdl();
                this.Close();
            }
        }
        private void Add_Furrlough_Load(object sender, EventArgs e)
        {

        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
