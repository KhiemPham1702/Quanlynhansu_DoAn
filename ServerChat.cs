using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ban_2
{
    public class ServerChat
    {
        private TcpListener tcpListener;
        private List<ClientHandler> clients;
        private bool isRunning;

        public ServerChat()
        {
            clients = new List<ClientHandler>();
        }

        public void Start()
        {
            // Bắt đầu lắng nghe kết nối từ client
            tcpListener = new TcpListener(IPAddress.Any, 8888);
            tcpListener.Start();

            isRunning = true;
            Console.WriteLine("Server started. Waiting for client connections...");

            while (isRunning)
            {
                TcpClient tcpClient = tcpListener.AcceptTcpClient();

                // Tạo một ClientHandler mới cho mỗi kết nối
                ClientHandler clientHandler = new ClientHandler(tcpClient, this);
                clients.Add(clientHandler);

                // Bắt đầu xử lý dữ liệu từ client trong một luồng riêng
                Thread clientThread = new Thread(clientHandler.HandleClient);
                clientThread.Start();
            }
        }

        public void BroadcastMessage(string message, ClientHandler sender)
        {
            // Gửi tin nhắn đến tất cả client, trừ sender
            foreach (var client in clients)
            {
                if (client != sender)
                {
                    client.SendMessage(message);
                }
            }
        }

        public void RemoveClient(ClientHandler client)
        {
            // Xóa client khỏi danh sách khi client ngắt kết nối
            clients.Remove(client);
        }

        public void Stop()
        {
            // Dừng máy chủ
            isRunning = false;
            tcpListener.Stop();
        }
    }

    public class ClientHandler
    {
        private TcpClient tcpClient;
        private NetworkStream stream;
        private ServerChat ServerChat;

        public ClientHandler(TcpClient client, ServerChat server)
        {
            tcpClient = client;
            ServerChat = server;
        }

        public void HandleClient()
        {
            try
            {
                stream = tcpClient.GetStream();

                byte[] data = new byte[1024];
                int bytesRead;

                while ((bytesRead = stream.Read(data, 0, data.Length)) > 0)
                {
                    string message = Encoding.UTF8.GetString(data, 0, bytesRead);
                    ServerChat.BroadcastMessage(message, this);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error handling client: " + ex.Message);
            }
            finally
            {
                stream.Close();
                tcpClient.Close();
                ServerChat.RemoveClient(this);
            }
        }

        public void SendMessage(string message)
        {
            byte[] data = Encoding.UTF8.GetBytes(message);
            stream.Write(data, 0, data.Length);
        }
    }
}
