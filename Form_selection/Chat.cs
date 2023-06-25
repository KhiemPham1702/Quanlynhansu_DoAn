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
            pnlChat.Controls.Clear();
            if (!IsInit)
            {
                pnlAction.Visible = true;
                ChatContent = new ChatContent(ChatMessages, Email);
                pnlChat.Controls.Add(ChatContent);
            }
            else
            {
                pnlAction.Visible = false;
                pnlChat.Controls.Add(new Components.ChatWelcome());
            }
        }

        private void LoadConversations()
        {
           ChatMessages = new List<ChatMessage>();
            string query = "SELECT * FROM MESSAGE WHERE FromEmail = @Email OR ToEmail = @Email";
            con.Open();
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

            var distinctMessages = ChatMessages.GroupBy(m => new[] { m.FromEmail, m.ToEmail }.OrderBy(e => e).First())
                                      .Select(group => group.OrderByDescending(m => m.Timestamp).First())
                                      .ToList();
            pnlConservations.Controls.Clear();
            foreach ( var item in distinctMessages)
            {

                pnlConservations.Controls.Add(new Components.Conversation(CreateConservations(item) , this));
            }
        }

        private ChatConservation CreateConservations(ChatMessage item)
        {
            var Cons = new ChatConservation();
            var email = Email == item.FromEmail ? item.ToEmail : item.FromEmail;
            string query = "SELECT NHANVIEN.HOTEN, ACC_USER.AVATAR FROM NHANVIEN INNER JOIN ACC_USER ON NHANVIEN.EMAIL = ACC_USER.EMAIL WHERE NHANVIEN.EMAIL = @Email";
            con.Open();
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
                await hubConnection.InvokeAsync("SendMessage", Helper.CurrentUser.Email , txtText.Text);
            }
            txtText.Text = "";
        }

        private async void Chat_Load(object sender, EventArgs e)
        {
            hubConnection.On<string, string>("ReceiveMessage" , (email, mes) => {
                if(email == Helper.CurrentUser.Email)
                {
                    this.pnlChat.Invoke(new MethodInvoker(delegate ()
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
                        ChatContent.AddMessage(item);
                    }));
                }
                else if (email == Helper.ToEmailChatUser)
                {
                    this.pnlChat.Invoke(new MethodInvoker(delegate ()
                    {
                        var item = new ChatMessage()
                        {
                            FromEmail = email,
                            ToEmail = "",
                            TypeMessage = 1,
                            EmotionFrom = "normal",
                            EmotionTo = "normal",
                            MessageText = mes,
                            MessageID = -1,
                            Timestamp = DateTime.Now,
                        };

                        ChatContent.AddMessage(item);
                    }));
                }
            });
            hubConnection.On<string, string>("ReceiveUrlFile", (email, mes) => {
                if (email == Helper.CurrentUser.Email)
                {
                    this.pnlChat.Invoke(new MethodInvoker(delegate ()
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
                        ChatContent.AddMessage(item);
                    }));
                }
                else if (email == Helper.ToEmailChatUser)
                {
                    this.pnlChat.Invoke(new MethodInvoker(delegate ()
                    {
                        var item = new ChatMessage()
                        {
                            FromEmail = email,
                            ToEmail = "",
                            TypeMessage = 2,
                            MessageText = mes,
                            EmotionFrom = "normal",
                            EmotionTo = "normal",
                            MessageID = -1,
                            Timestamp = DateTime.Now,
                        };

                        ChatContent.AddMessage(item);
                    }));
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
                        }
                        else if(Helper.CurrentUser.Email == toEmail)
                        {
                            ChatContent.ChangeBackground(url);
                            ChatContent.UpdateBackgroundToSql(url, toEmail, fromEmail);
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

                    await hubConnection.InvokeAsync("SendUrlFile", Helper.CurrentUser.Email, filePath);
                }
                
            }
        }
    }
}
