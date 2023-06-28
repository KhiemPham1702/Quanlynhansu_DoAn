using ban_2.Form_selection;
using ban_2.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ban_2.Components
{
    public partial class UCItemSearchColleague : UserControl
    {
        public Staff Staff { get; set; }
        public Chat ChatControl { get; set; }
        public UCItemSearchColleague(Staff st , Chat ct)
        {
            Staff = st;
            ChatControl = ct;
            InitializeComponent();
            btnUser.Text = Staff.HOTEN;
            btnUser.Image = ByteArrayToImage();
        }

        private void btnUser_Click(object sender, EventArgs e)
        {
            Helper.ToEmailChatUser = Staff.EMAIL;
            //kiem tra co Conservation chưa 

            string sql = $"SELECT * FROM Conversations WHERE ( FromEmail = @FromEmail AND ToEmail = @ToEmail ) OR ( FromEmail = @To AND ToEmail = @From ) ";
            var parameters = new object[] { Helper.CurrentUser.Email, Helper.ToEmailChatUser, Helper.ToEmailChatUser, Helper.CurrentUser.Email };
            var data = DataProvider.Instance.ExecuteQuery(sql, parameters);
            if(data.Rows.Count != 2)
            {
                string query = @"INSERT into Conversations (FromEmail, ToEmail, Background) VALUES( @FromEmail , @ToEmail ,  @Background ) ";
                parameters = new object[] { Helper.CurrentUser.Email, Helper.ToEmailChatUser, "default" };
                DataProvider.Instance.ExecuteNonQuery(query, parameters);
                query = @"INSERT into Conversations (FromEmail, ToEmail, Background) VALUES( @FromEmail , @ToEmail ,  @Background ) ";
                parameters = new object[] { Helper.ToEmailChatUser, Helper.CurrentUser.Email, "default" };
                DataProvider.Instance.ExecuteNonQuery(query, parameters);
            }
            
            ChatControl.IsInit = false;
            ChatControl.LoadChatPanel();

        }
        public Image ByteArrayToImage()
        {
            try
            {
                MemoryStream m = new MemoryStream(Staff.AVATAR);
                return Image.FromStream(m);
            }
            catch (Exception ex)
            {
                return Helper.AvatarDefault;
            }

        }
    }
}
