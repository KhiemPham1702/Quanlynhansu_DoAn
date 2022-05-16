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
    public partial class About : UserControl
    {
        public About()
        {
            InitializeComponent();
        }

        private void faceT_Click(object sender, EventArgs e)
        {
            var uri = "https://www.facebook.com/nnt720";
            var psi = new System.Diagnostics.ProcessStartInfo();
            psi.UseShellExecute = true;
            psi.FileName = uri;
            System.Diagnostics.Process.Start(psi);
        }

        private void faceK_Click(object sender, EventArgs e)
        {
            var uri = "https://www.facebook.com/khiem.pham.56027281/";
            var psi = new System.Diagnostics.ProcessStartInfo();
            psi.UseShellExecute = true;
            psi.FileName = uri;
            System.Diagnostics.Process.Start(psi);
        }

        private void faceTH_Click(object sender, EventArgs e)
        {
            var uri = "https://www.facebook.com/lehoangthoai.2607";
            var psi = new System.Diagnostics.ProcessStartInfo();
            psi.UseShellExecute = true;
            psi.FileName = uri;
            System.Diagnostics.Process.Start(psi);
        }

        private void uitT_Click(object sender, EventArgs e)
        {
            var uri = "https://courses.uit.edu.vn/user/view.php?id=15210&course=8910";
            var psi = new System.Diagnostics.ProcessStartInfo();
            psi.UseShellExecute = true;
            psi.FileName = uri;
            System.Diagnostics.Process.Start(psi);
        }

        private void uitK_Click(object sender, EventArgs e)
        {
            var uri = "https://courses.uit.edu.vn/user/profile.php?id=14654";
            var psi = new System.Diagnostics.ProcessStartInfo();
            psi.UseShellExecute = true;
            psi.FileName = uri;
            System.Diagnostics.Process.Start(psi);
        }

        private void uitTH_Click(object sender, EventArgs e)
        {
            var uri = "https://courses.uit.edu.vn/user/view.php?id=15171&course=8910";
            var psi = new System.Diagnostics.ProcessStartInfo();
            psi.UseShellExecute = true;
            psi.FileName = uri;
            System.Diagnostics.Process.Start(psi);
        }
    }
}
