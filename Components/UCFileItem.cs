using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ban_2.Components
{
    public partial class UCFileItem : UserControl
    {
        public string UrlFile { get; set; }
        public UCFileItem(string url)
        {
            UrlFile = url;
            InitializeComponent();
            var text = Path.GetFileName(UrlFile);
            btnFile.Text = text;
        }

        private void btnFile_Click(object sender, EventArgs e)
        {
            Process.Start(UrlFile);
        }
    }
}
