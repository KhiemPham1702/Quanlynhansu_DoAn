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
    public partial class UCFindMess : UserControl
    {
        public UCFindMess()
        {
            InitializeComponent();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSearch.Text))
            {
                flwMess.Controls.Clear();
                return;
            };
            var ListMessages = new List<ChatMessage>();
            var ListDates = new List<DateTime>();
            string sql = $"SELECT * FROM MESSAGE WHERE (( FromEmail = @FromEmail AND ToEmail = @ToEmail ) OR ( FromEmail = @To AND ToEmail = @From )) AND MessageText LIKE '%' + @SearchString + '%'";
            var parameters = new object[] { Helper.CurrentUser.Email, Helper.ToEmailChatUser, Helper.ToEmailChatUser, Helper.CurrentUser.Email, txtSearch.Text };
            var data = DataProvider.Instance.ExecuteQuery(sql, parameters);
            for (int i = 0; i < data.Rows.Count; i++)
            {
                ChatMessage message = new ChatMessage
                {
                    MessageID = (int)data.Rows[i]["MessageID"],
                    TypeMessage = (int)data.Rows[i]["TypeMessage"],
                    FromEmail = (string)data.Rows[i]["FromEmail"],
                    ToEmail = (string)data.Rows[i]["ToEmail"],
                    EmotionFrom = (string)data.Rows[i]["EmotionFrom"],
                    EmotionTo = (string)data.Rows[i]["EmotionTo"],
                    MessageText = (string)data.Rows[i]["MessageText"],
                    Timestamp = (DateTime)data.Rows[i]["Timestamp"]
                };
                ListMessages.Add(message);
            }
            flwMess.Controls.Clear();
            if(ListMessages.Count ==0)
            {
                Label lb = new Label();
                lb.Text = "Don't find message with '" + txtSearch.Text + "'";
                flwMess.Controls.Add(lb);
            }
            else
            {
                foreach (ChatMessage message in ListMessages)
                {
                    var date = new DateTime(message.Timestamp.Year, message.Timestamp.Month, message.Timestamp.Day);
                    bool exists = ListDates.Contains(date);
                    if (!exists)
                    {
                        ListDates.Add(date);
                        var seperator = new SpDateForSearch(date);
                        flwMess.Controls.Add(seperator);

                    }
                    flwMess.Controls.Add(new UCSeachMessItem(message));
                }
            }
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            Helper.PnlInfo.Controls.Clear();
            Helper.PnlInfo.Controls.Add(new UCInfoChat());
        }
    }
}
