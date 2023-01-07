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

        public ChatServer(BackgroundWorker backgroundWorker1, BackgroundWorker backgroundWorker2)
        {
            this.backgroundWorker1 = backgroundWorker1;
            this.backgroundWorker2 = backgroundWorker2;
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

           if(Helper.CurrentUser.Email == Message.FromEmail)
            {
                LoadSend();
            }
            else if(Helper.CurrentUser.Email == Message.ToEmail)
            {
                LoadReceive();
            }
        }

        private void LoadReceive()
        {
            throw new NotImplementedException();
        }

        private void LoadSend()
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
    }
}
