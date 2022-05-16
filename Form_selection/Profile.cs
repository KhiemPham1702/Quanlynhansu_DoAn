using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ban_2.Form_selection
{
    public partial class Profile : UserControl
    {
        public Profile()
        {
            InitializeComponent();
        }

        private void btChange_Click(object sender, EventArgs e)
        {
            if(tbPass.PasswordChar == '\0')
            {
                tbPass.PasswordChar = '●';
            } else
            {
                tbPass.PasswordChar = '\0';
            }   
        }

        private void btChangePass_Click(object sender, EventArgs e)
        {
            Form change = new Change_Pass_form();
            change.Show();
        }
    }
}
