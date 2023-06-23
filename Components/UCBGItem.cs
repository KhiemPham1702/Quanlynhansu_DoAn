using ban_2.Models;
using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ban_2.Components
{
    public partial class UCBGItem : UserControl
    {
        public string ThemeText { get; set; }
        public string Url { get; set; }
        HubConnection hubConnection;
        public UCBGItem(string theme, string url)
        {
            ThemeText = theme;
            Url = url;
            hubConnection = new HubConnectionBuilder()
                               .WithUrl("https://localhost:7205/chat")
                               .Build();
            hubConnection.StartAsync();
            InitializeComponent();
            if(url == "default")
            {
                btnTheme.Image = Image.FromFile("D:\\Images\\chatdf.jpg");
                btnTheme.Text = "Theme Default";
            }
            else
            {
                btnTheme.Image = Image.FromFile(Url);
                btnTheme.Text = ThemeText;
            }
            
        }

        

        private async void btnTheme_Click(object sender, EventArgs e)
        {
            DialogResult ret = MessageBox.Show("Do you want to choose this theme?", "Change background", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if(ret == DialogResult.OK)
            {
                await hubConnection.InvokeAsync("SendBackground", Helper.CurrentUser.Email, Helper.ToEmailChatUser, Url);
                Helper.PnlInfo.Visible = false;
            }
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            Process.Start(Url);
        }
    }
}
