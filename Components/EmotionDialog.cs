using ban_2.Models;
using Microsoft.AspNetCore.SignalR.Client;
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
    public partial class EmotionDialog : UserControl
    {
        public int MessageID { get; set; }
        HubConnection hubConnection;
        public EmotionDialog( int id)
        {
            InitializeComponent();
            MessageID = id;
            hubConnection = new HubConnectionBuilder()
                                .WithUrl("https://localhost:7205/chat")
                                .Build();
            hubConnection.StartAsync();
        }
       
        private async void btnLike_Click(object sender, EventArgs e)
        {
            await hubConnection.InvokeAsync("SendEmotion", Helper.CurrentUser.Email, "like" , MessageID);
        }

   
        private async void btnHaha_Click(object sender, EventArgs e)
        {
            await hubConnection.InvokeAsync("SendEmotion", Helper.CurrentUser.Email, "haha", MessageID);
        }

        private  async void btnLove_Click(object sender, EventArgs e)
        {

            await hubConnection.InvokeAsync("SendEmotion", Helper.CurrentUser.Email, "love", MessageID);
        }
        
    }
}
