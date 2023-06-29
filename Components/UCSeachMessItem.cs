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
    public partial class UCSeachMessItem : UserControl
    {
        public ChatMessage Message { get; set; }
        public string Search { get; set; }
        public UCSeachMessItem(ChatMessage chat , string search)
        {
            Message = chat;
            Search = search;
            InitializeComponent();
            if(Message.FromEmail == Helper.CurrentUser.Email)
            {
                btnText.Text = "You: " +  Message.MessageText;
            }
            else {
                string sql = $"SELECT * FROM NHANVIEN WHERE EMAIL = @EMAIL";
                var parameters = new object[] { Helper.ToEmailChatUser };
                var data = DataProvider.Instance.ExecuteQuery(sql, parameters);
                var fullName = (string)data.Rows[0]["HOTEN"];
                string[] nameParts = fullName.Split(' ');
                string lastName = nameParts[nameParts.Length - 1];
                btnText.Text = lastName + ": " + Message.MessageText;
            }
            lblHour.Text = Message.Timestamp.ToString("HH:mm");
        }

        private void btnText_Click(object sender, EventArgs e)
        { 
            Helper.ChatControl.ChatContent.Invoke(new MethodInvoker(delegate ()
            {
                Helper.ChatControl.ChatContent.ScrollToPositionHightLight(Message , Search);
            }));
            Helper.PnlInfo.Visible = false;
        }
    }
}
