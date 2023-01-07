using ban_2.Components;
using ban_2.Models;
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
        private TcpClient Client;
        public StreamReader STR;
        public StreamWriter STW;
        public string receive;
        public string TextToSend;
        public string LocalAddress;
        public ChatContent ChatContent;
        public ChatWelcome ChatWelcome;
        public Chat(String email)
        {
            Email = email;
            InitializeComponent();
            LoadConversations();
            LoadChatPanel();
            LoadIP();
        }

        private void LoadIP()
        {
            IPAddress[] localIP = Dns.GetHostAddresses(Dns.GetHostName());
            foreach (var ip in localIP)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    LocalAddress = ip.ToString();
                }
            }
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
                    FromEmail = (string)reader["FromEmail"],
                    ToEmail = (string)reader["ToEmail"],
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

       

        private void btnStart_Click(object sender, EventArgs e)
        {
            TcpListener tcpListener = new TcpListener(IPAddress.Any, 80);
            tcpListener.Start();
            Client = tcpListener.AcceptTcpClient();
            STR = new StreamReader(Client.GetStream());
            STW = new StreamWriter(Client.GetStream());
            STW.AutoFlush = true;
            backgroundWorker1.RunWorkerAsync();
            backgroundWorker2.WorkerSupportsCancellation = true;
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
          
            Client = new TcpClient();
            Client.Connect(LocalAddress, 80);
            IPEndPoint iPEnd = new IPEndPoint(IPAddress.Parse(LocalAddress), 80);
            try
            {
                STW = new StreamWriter(Client.GetStream());
                STR = new StreamReader(Client.GetStream());
                
                STW.AutoFlush = true;
                backgroundWorker1.RunWorkerAsync();
                backgroundWorker2.WorkerSupportsCancellation = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            if (Client == null) return;
            while (Client.Connected)
            {
                try
                {
                    receive = STR.ReadLine();
                  
                    this.pnlChat.Invoke(new MethodInvoker(delegate ()
                    {
                        var item = new ChatMessage()
                        {
                            FromEmail = Helper.CurrentUser.Email,
                            ToEmail = Helper.ToEmailChatUser,
                            MessageText = receive,
                            MessageID = -1,
                            Timestamp = DateTime.Now,
                        };
                        ChatContent.AddMessage(item, 2);
                    }));
                    receive = "";
                }
                catch
                {

                }
            }
        }

        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            if (Client == null) return;
            if (Client.Connected)
            {
                STW.WriteLine(TextToSend);
               
                this.pnlChat.Invoke(new MethodInvoker(delegate ()
                {
                    var item = new ChatMessage()
                    {
                        FromEmail = Helper.CurrentUser.Email,
                        ToEmail = Helper.ToEmailChatUser,
                        MessageText = TextToSend,
                        MessageID = -1,
                        Timestamp = DateTime.Now,
                    };
                    string query = @"INSERT into MESSAGE (FromEmail, ToEmail, MessageText, Timestamp ) VALUES( @FromEmail , @ToEmail , @MessageText , @Timestamp ) ";
                    var parameters = new object[] { item.FromEmail, item.ToEmail, item.MessageText, item.Timestamp };
                    var res = DataProvider.Instance.ExecuteNonQuery(query, parameters);
                    ChatContent.AddMessage(item, 1);
                }));
            }
            else
            {
                MessageBox.Show("Failed");
            }
            backgroundWorker2.CancelAsync();
            
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
          
            if(!string.IsNullOrEmpty(txtText.Text))
            {
                TextToSend = txtText.Text;
                backgroundWorker2.RunWorkerAsync();
            }
            txtText.Text = "";
        }
    }
}
