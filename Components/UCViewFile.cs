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
    public partial class UCViewFile : UserControl
    {
        public List<string> ListFiles { get; set; }
        public UCViewFile()
        {
            InitializeComponent();
            LoadItem();
        }

        private void LoadItem()
        {
            ListFiles = new List<string>();
            string sql = $"SELECT * FROM MESSAGE WHERE ( FromEmail = @FromEmail AND ToEmail = @ToEmail ) OR ( FromEmail = @To AND ToEmail = @From ) ";
            var parameters = new object[] { Helper.CurrentUser.Email, Helper.ToEmailChatUser, Helper.ToEmailChatUser , Helper.CurrentUser.Email };
            var data = DataProvider.Instance.ExecuteQuery(sql, parameters);
            for(int i = 0; i < data.Rows.Count; i++)
            {
                if((int)data.Rows[i]["TypeMessage"] == 2)
                {
                    ListFiles.Add((string)data.Rows[i]["MessageText"]);
                } 
                
            }
            flwFiles.Controls.Clear();
            foreach (var file in ListFiles)
            {
                flwFiles.Controls.Add(new UCFileItem(file));
            }
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            Helper.PnlInfo.Controls.Clear();
            Helper.PnlInfo.Controls.Add(new UCInfoChat());
        }
    }
}
