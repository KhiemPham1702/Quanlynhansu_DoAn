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
    public partial class Conversation : UserControl
    { 
        public ChatConservation ChatConservation { get; set; }
        public Chat ChatControl { get; set; }
        public string Email { get; set; }
        public Conversation(ChatConservation chatConservation , Chat chat )
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
            if(ChatConservation.LastMessage.TypeMessage == 2)
            {
                lblLastMessage.Text = GetWhoChat() + Path.GetFileName(ChatConservation.LastMessage.MessageText);
            }
            else
            {
                lblLastMessage.Text = GetWhoChat() + ChatConservation.LastMessage.MessageText;
            }
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
            var compare = ChatConservation.LastMessage.FromEmail == Helper.CurrentUser.Email ? ChatConservation.LastMessage.ToEmail : ChatConservation.LastMessage.FromEmail;
            if (Helper.ReceiveNewMess.Contains(compare)){
                Helper.ReceiveNewMess.Remove(compare);
            }
            if (Helper.CurrentUser.Email == ChatConservation.LastMessage.FromEmail)
            {
                Helper.ToEmailChatUser = ChatConservation.LastMessage.ToEmail;
            }
            else
            {
                Helper.ToEmailChatUser = ChatConservation.LastMessage.FromEmail;
            }
            ChatControl.LoadConversations();
            ChatControl.IsInit = false;
            ChatControl.LoadChatPanel();
           
            //Helper.ChatServerController = new ChatServer();
        }

        private void Conversation_Load(object sender, EventArgs e)
        {
            if(Helper.ToEmailChatUser == ChatConservation.LastMessage.FromEmail || Helper.ToEmailChatUser == ChatConservation.LastMessage.ToEmail)
            {
                this.BackColor = Helper.ConsClicked;
            }
            if(Helper.ReceiveNewMess.Count > 0)
            {
                var compare = ChatConservation.LastMessage.FromEmail == Helper.CurrentUser.Email ? ChatConservation.LastMessage.ToEmail : ChatConservation.LastMessage.FromEmail;
                if(Helper.ReceiveNewMess.Contains(compare))
                {
                    CreateEffectNewMess();
                }
            }
        }
        void CreateEffectNewMess()
        {
            lblLastMessage.Font = new Font(lblLastMessage.Font, FontStyle.Bold);
            lblName.Font = new Font(lblName.Font, FontStyle.Bold);
            dotNewMess.Visible = true;
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
