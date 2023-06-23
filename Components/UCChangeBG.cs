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
    public partial class UCChangeBG : UserControl
    {
        public UCChangeBG()
        {
            InitializeComponent();
            LoadItem();
        }

        private void LoadItem()
        {
            int i = 0;
            foreach(var item in Data.ListBackgrounds)
            {
                i++;
                var uc = new UCBGItem("Theme " + i, item);
                flwBG.Controls.Add(uc);
            }
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            Helper.PnlInfo.Controls.Clear();
            Helper.PnlInfo.Controls.Add(new UCInfoChat());
        }
    }
}
