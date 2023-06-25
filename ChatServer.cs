using ban_2.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ban_2
{
    public class ChatServer
    {
        private TcpClient Client;
        public StreamReader STR;
        public StreamWriter STW;
        public string receive;
        public string TextToSend;
        public string LocalAddress;
        public BackgroundWorker backgroundWorker1;
        public BackgroundWorker backgroundWorker2;
        public ChatMessage Message;

        public ChatServer()
        {
            LoadIP();
        }

        private void LoadIP()
        {
            backgroundWorker1 = new BackgroundWorker();
            backgroundWorker2 = new BackgroundWorker();
            backgroundWorker1.DoWork += BackgroundWorker1_DoWork;
            backgroundWorker2.DoWork += BackgroundWorker2_DoWork;
            IPAddress[] localIP = Dns.GetHostAddresses(Dns.GetHostName());
            foreach (var ip in localIP)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    LocalAddress = ip.ToString();
                }
            }
            try
            {
                Start();
            }
            catch { 
                Connect();
            }
           
        }

        private void BackgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            if (Client == null) return;
            while (Client.Connected)
            {
                try
                {
                    receive = STR.ReadLine();

                    //this.pnlChat.Invoke(new MethodInvoker(delegate ()
                    //{
                    //    var item = new ChatMessage()
                    //    {
                    //        FromEmail = Helper.CurrentUser.Email,
                    //        ToEmail = Helper.ToEmailChatUser,
                    //        MessageText = receive,
                    //        MessageID = -1,
                    //        Timestamp = DateTime.Now,
                    //    };
                    //    ChatContent.AddMessage(item, 2);
                    //}));
                    MessageBox.Show(receive);
                    receive = "";
                }
                catch
                {

                }
            }
        }

        private void BackgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            if (Client == null) return;
            if (Client.Connected)
            {
                STW.WriteLine(TextToSend);
                MessageBox.Show(TextToSend);
                //this.pnlChat.Invoke(new MethodInvoker(delegate ()
                //{
                //    var item = new ChatMessage()
                //    {
                //        FromEmail = Helper.CurrentUser.Email,
                //        ToEmail = Helper.ToEmailChatUser,
                //        MessageText = TextToSend,
                //        MessageID = -1,
                //        Timestamp = DateTime.Now,
                //    };
                //    string query = @"INSERT into MESSAGE (FromEmail, ToEmail, MessageText, Timestamp ) VALUES( @FromEmail , @ToEmail , @MessageText , @Timestamp ) ";
                //    var parameters = new object[] { item.FromEmail, item.ToEmail, item.MessageText, item.Timestamp };
                //    var res = DataProvider.Instance.ExecuteNonQuery(query, parameters);
                //    ChatContent.AddMessage(item, 1);
                //}));
            }
            else
            {
                MessageBox.Show("Failed");
            }
            backgroundWorker2.CancelAsync();
        }

        void Start()
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
        void Connect()
        {
            Client = new TcpClient();
            Client.Connect(LocalAddress, 80);
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

        public void SendMessage(string mess)
        {
            TextToSend = mess;
            backgroundWorker2.RunWorkerAsync();
        }
    }
}
