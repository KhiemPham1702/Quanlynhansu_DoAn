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
    public partial class SeperatorDate : UserControl
    {
        public SeperatorDate(DateTime dateTime)
        {
            InitializeComponent();
            var now = DateTime.Now.Date;
            if(dateTime == now)
            {
                txtDate.Text = "Today";
            }
            else
            {
                txtDate.Text = dateTime.ToString("dd/MM/yyyy");
            }
           
        }
    }
}
