using ban_2.Form_selection;
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
    public partial class Conversation : UserControl
    { 
        public ChatConservation ChatConservation { get; set; }
        public Chat ChatControl { get; set; }
        public string Email { get; set; }
        public Conversation(ChatConservation chatConservation , Chat chat)
        {
            ChatConservation = chatConservation;
            ChatControl = chat;
            InitializeComponent();
            LoadItem();
        }

        private void LoadItem()
        {
            this.BackColor = Helper.ConsDefault;
            picturboxAvatar.Image = ChatConservation.ByteArrayToImage();
            lblLastMessage.Text = GetWhoChat() + ChatConservation.LastMessage.MessageText;
            lblName.Text = ChatConservation.ToName;
        }

        private string GetWhoChat()
        {
            if(ChatControl.Email == ChatConservation.LastMessage.FromEmail)
            {
                return "You: ";
            }
            return "";
        }

        private void Conversation_Click(object sender, EventArgs e)
        {
            this.BackColor = Helper.ConsClicked;
            ChatControl.IsInit = false;
            ChatControl.LoadChatPanel();
            if(Helper.CurrentUser.Email == ChatConservation.LastMessage.FromEmail)
            {
                Helper.ToEmailChatUser = ChatConservation.LastMessage.ToEmail;
            }
            else
            {
                Helper.ToEmailChatUser = ChatConservation.LastMessage.FromEmail;
            }
        }

        private void Conversation_Load(object sender, EventArgs e)
        {

        }

        private void Conversation_MouseHover(object sender, EventArgs e)
        {
            if(this.BackColor == Helper.ConsDefault)
            {
                this.BackColor = Helper.ConsHover;
            }
           
        }

        private void Conversation_Leave(object sender, EventArgs e)
        {

        }

        private void Conversation_MouseLeave(object sender, EventArgs e)
        {
            if (this.BackColor == Helper.ConsHover)
            {
                this.BackColor = Helper.ConsDefault;
            }

        }

        private void lblLastMessage_Click(object sender, EventArgs e)
        {

        }
    }
}
