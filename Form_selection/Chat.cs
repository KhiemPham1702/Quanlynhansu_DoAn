using ban_2.Components;
using ban_2.Models;
using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ban_2.Form_selection
{
    public partial class Chat : UserControl
    {
        public bool IsInit = true;
        public String Email { get; set; }
        public List<ChatMessage> ChatMessages { get; set; }
        SqlConnection con = new connect().con;
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter();

        public ChatContent ChatContent;
        public ChatWelcome ChatWelcome;

        HubConnection hubConnection;
        public Chat(String email)
        {
            Email = email;
            InitializeComponent();
            Helper.PnlInfo = pnlInformation;
            Helper.PnlInfo.Visible = false;
            Helper.ChatControl = this;
            LoadConversations();
            LoadChatPanel();
            hubConnection = new HubConnectionBuilder()
                                .WithUrl("https://localhost:7205/chat")
                                .Build();
        }

        private async Task HubConnection_Closed(Exception arg)
        {
            await Task.Delay(new Random().Next(0, 5) * 1000);
            await hubConnection.StartAsync();
        }

        public void LoadChatPanel()
        {
            
            if (!IsInit)
            {
                this.pnlChat.Invoke(new MethodInvoker(delegate ()
                {
                    pnlChat.Controls.Clear();
                    pnlAction.Visible = true;
                    ChatContent = new ChatContent();
                    pnlChat.Controls.Add(ChatContent);
                    if(ChatContent.ChatMessages.Count > 0)
                    {
                        ChatContent.ScrollToPosition(ChatContent.ChatMessages[ChatContent.ChatMessages.Count - 1]);
                    }
                    
                }));
               
                
            }
            else
            {
                pnlAction.Visible = false;
                pnlChat.Controls.Add(new Components.ChatWelcome());
            }
        }

        public void LoadConversations()
        {
            ChatMessages = new List<ChatMessage>();
            string query = "SELECT * FROM MESSAGE WHERE FromEmail = @Email OR ToEmail = @Email";
            try
            {
                con.Open();
            }
            catch (Exception ex)
            {
                con.Close();
                con.Open();
            }
            SqlCommand command = new SqlCommand(query, con);
            command.Parameters.AddWithValue("@Email", Email);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {

                ChatMessage message = new ChatMessage
                {
                    MessageID = (int)reader["MessageID"],
                    TypeMessage = (int)reader["TypeMessage"],
                    FromEmail = (string)reader["FromEmail"],
                    ToEmail = (string)reader["ToEmail"],
                    EmotionFrom = (string)reader["EmotionFrom"],
                    EmotionTo = (string)reader["EmotionTo"],
                    MessageText = (string)reader["MessageText"],
                    Timestamp = (DateTime)reader["Timestamp"]
                };

                ChatMessages.Add(message);
            }

            reader.Close();
            con.Close();

            //var distinctMessages = ChatMessages.GroupBy(m => new[] { m.FromEmail, m.ToEmail }.First())
            //                          .Select(group => group.OrderByDescending(m => m.Timestamp).First())
            //                          .ToList();
            ChatMessages.Reverse();
            var distinctMessages = ChatMessages
          .Where(m => m.FromEmail == Helper.CurrentUser.Email || m.ToEmail == Helper.CurrentUser.Email)
          .GroupBy(m => new { m.FromEmail, m.ToEmail })
          .Select(g => g.OrderByDescending(m => m.Timestamp).First())
          .ToList();
            var listString = new List<String>();
            pnlConservations.Controls.Clear();
            foreach ( var item in distinctMessages)
            {
                if(listString.Contains(item.FromEmail+item.ToEmail) || listString.Contains(item.ToEmail + item.FromEmail))
                {
                    continue;
                }
                listString.Add(item.FromEmail+ item.ToEmail);
                pnlConservations.Controls.Add(new Components.Conversation(CreateConservations(item) , this));
            }
        }

        private ChatConservation CreateConservations(ChatMessage item)
        {
            var Cons = new ChatConservation();
            var email = Email == item.FromEmail ? item.ToEmail : item.FromEmail;
            string query = "SELECT NHANVIEN.HOTEN, ACC_USER.AVATAR FROM NHANVIEN INNER JOIN ACC_USER ON NHANVIEN.EMAIL = ACC_USER.EMAIL WHERE NHANVIEN.EMAIL = @Email";
            try
            {
                con.Open();
            }catch (Exception ex)
            {
                con.Close();
                con.Open();
            }
            SqlCommand command = new SqlCommand(query, con);
            command.Parameters.AddWithValue("@Email", email);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Cons = new ChatConservation()
                {
                    ToName = (string)reader["HOTEN"],
                    Avatar = (byte[])reader["AVATAR"],
                    LastMessage = item
                };
            }

            reader.Close();
            return Cons;
        }


        private async void btnSend_Click(object sender, EventArgs e)
        {
          
            if(!string.IsNullOrEmpty(txtText.Text))
            {
                await hubConnection.InvokeAsync("SendMessage", Helper.CurrentUser.Email , Helper.ToEmailChatUser, txtText.Text);
            }
            txtText.Text = "";
           
        }

        private async void Chat_Load(object sender, EventArgs e)
        {
            hubConnection.On<string, string , string>("ReceiveMessage" , (fromEmail, toEmail, mes) => {
                try
                {
                    this.pnlChat.Invoke(new MethodInvoker(delegate ()
                    {
                        if (Helper.CurrentUser.Email == fromEmail && Helper.ToEmailChatUser == toEmail)
                        {
                            var item = new ChatMessage()
                            {
                                FromEmail = Helper.CurrentUser.Email,
                                ToEmail = Helper.ToEmailChatUser,
                                TypeMessage = 1,
                                EmotionFrom = "normal",
                                EmotionTo = "normal",
                                MessageText = mes,
                                MessageID = -1,
                                Timestamp = DateTime.Now,
                            };
                            string query = @"INSERT into MESSAGE (FromEmail, TypeMessage, EmotionFrom, EmotionTo, ToEmail, MessageText, Timestamp ) VALUES( @FromEmail , @TypeMessage ,  @EmotionFrom , @EmotionTo , @ToEmail , @MessageText , @Timestamp ) ";
                            var parameters = new object[] { item.FromEmail, item.TypeMessage, item.EmotionFrom, item.EmotionTo, item.ToEmail, item.MessageText, item.Timestamp };
                            var res = DataProvider.Instance.ExecuteNonQuery(query, parameters);
                            Task.Delay(1000);
                            LoadChatPanel();
                            LoadConversations();
                        }
                        else if (Helper.CurrentUser.Email == toEmail && Helper.ToEmailChatUser == fromEmail)
                        {
                            Task.Delay(1000);
                            LoadChatPanel();
                            LoadConversations();
                        }
                        else
                        {
                            LoadConversations();
                        }
                    }));
                }
                catch (Exception ex)
                {
                   
                }
            });
            hubConnection.On<string, string, string>("ReceiveUrlFile", (fromEmail, toEmail, mes) => {
                try
                {
                    this.pnlChat.Invoke(new MethodInvoker(delegate ()
                    {
                        if (Helper.CurrentUser.Email == fromEmail && Helper.ToEmailChatUser == toEmail)
                        {
                            var item = new ChatMessage()
                            {
                                FromEmail = Helper.CurrentUser.Email,
                                ToEmail = Helper.ToEmailChatUser,
                                TypeMessage = 2,
                                EmotionFrom = "normal",
                                EmotionTo = "normal",
                                MessageText = mes,
                                MessageID = -1,
                                Timestamp = DateTime.Now,
                            };
                            string query = @"INSERT into MESSAGE (FromEmail, TypeMessage, EmotionFrom, EmotionTo, ToEmail, MessageText, Timestamp ) VALUES( @FromEmail , @TypeMessage ,  @EmotionFrom , @EmotionTo , @ToEmail , @MessageText , @Timestamp ) ";
                            var parameters = new object[] { item.FromEmail, item.TypeMessage, item.EmotionFrom, item.EmotionTo, item.ToEmail, item.MessageText, item.Timestamp };
                            var res = DataProvider.Instance.ExecuteNonQuery(query, parameters);
                            LoadChatPanel();
                            LoadConversations();
                        }
                        else if (Helper.CurrentUser.Email == toEmail && Helper.ToEmailChatUser == fromEmail)
                        {
                            LoadChatPanel();
                            LoadConversations();
                        }
                        else
                        {
                            LoadConversations();
                        }
                    }));

                }
                catch (Exception ex)
                {
                    
                }
            });
            hubConnection.On<string, string, int>("ReceiveEmotion", (email, mes , id) => {
                try
                {
                    this.pnlChat.Invoke(new MethodInvoker(delegate ()
                    {
                        
                        ChatContent.UpdateEmotionMessage(id, mes , email);
                        
                    }));
                }
                catch (Exception ex)
                {
                   
                }
            });
            hubConnection.On<string, string, string>("ReceiveBackground", (fromEmail, toEmail, url) => {
                try
                {
                    this.pnlChat.Invoke(new MethodInvoker(delegate ()
                    {
                        if(Helper.CurrentUser.Email == fromEmail)
                        {
                            ChatContent.ChangeBackground(url);
                            ChatContent.UpdateBackgroundToSql(url, fromEmail, toEmail);
                            ChatContent.UpdateBackgroundToSql(url, toEmail, fromEmail);
                        }
                        else if(Helper.CurrentUser.Email == toEmail)
                        {
                            ChatContent.ChangeBackground(url);                          
                        }
                    }));
                }
                catch (Exception ex)
                {
                   
                }
            });
            try
            {
                await hubConnection.StartAsync();
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private async void btnSendFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "All files (*.*)|*.*";
            openFileDialog.Title = "Chọn tập tin để gửi";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                DialogResult result = MessageBox.Show("Do you want to send this file?", "Send", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if(result == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;

                    await hubConnection.InvokeAsync("SendUrlFile", Helper.CurrentUser.Email,Helper.ToEmailChatUser, filePath);
                }
                
            }
        }

        private void tbTimNHANVIEN_TextChanged(object sender, EventArgs e)
        {
            var ListStaffs = new List<Staff>();
           
            if (string.IsNullOrEmpty(tbTimNHANVIEN.Text))
            {
                con.Close();
                LoadConversations();
            }
            else
            {
                string sql = $"SELECT NHANVIEN.HOTEN, ACC_USER.AVATAR, NHANVIEN.EMAIL FROM NHANVIEN INNER JOIN ACC_USER ON NHANVIEN.EMAIL = ACC_USER.EMAIL WHERE NHANVIEN.HOTEN LIKE '%' + @SearchString + '%'";
                var parameters = new object[] { tbTimNHANVIEN.Text };
                var data = DataProvider.Instance.ExecuteQuery(sql, parameters);
                for(int i = 0; i<data.Rows.Count; i++)
                {
                    var st = new Staff()
                    {
                        AVATAR = (byte[])data.Rows[i]["AVATAR"],
                        EMAIL = (string)data.Rows[i]["EMAIL"],
                        HOTEN = (string)data.Rows[i]["HOTEN"],
                    };
                    if(st.EMAIL != Helper.CurrentUser.Email)
                    {
                        ListStaffs.Add(st);
                    }
                    
                }

                pnlConservations.Controls.Clear();
                foreach(var st in ListStaffs)
                {
                    pnlConservations.Controls.Add(new UCItemSearchColleague(st , this));
                }
            }
           
        }
    }
}
