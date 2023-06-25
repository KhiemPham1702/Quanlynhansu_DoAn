using ban_2.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ban_2.Components
{
    public partial class UCInfoChat : UserControl
    {
        public UCInfoChat()
        {
            InitializeComponent();
        }

        private void btnInfo_Click(object sender, EventArgs e)
        {
            Helper.PnlInfo.Visible = false;
        }

        private void btnChangeBG_Click(object sender, EventArgs e)
        {
            Helper.PnlInfo.Controls.Clear();
            Helper.PnlInfo.Controls.Add(new UCChangeBG());
        }
    }
}
