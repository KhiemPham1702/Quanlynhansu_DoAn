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
    public partial class ChatContent : UserControl
    {
        public List<ChatMessage> ChatMessages { get; set; }
        public string Email { get; set; }
        public int YLocation { get; set; }
        public ChatContent(List<ChatMessage> chatMessages , string email)
        {
            ChatMessages = chatMessages;
            Email = email;
            YLocation = 10;
            InitializeComponent();
            LoadChat();
            
        }
        public void AddMessage(ChatMessage item , int id)
        {
            if (id == 1) //You
            {
                pnlChat.Controls.Add(createFromMessage(item));
               
            }
            else
            {
                pnlChat.Controls.Add(createToMessage(item));
               
            }
           
                
        }
        private void LoadChat()
        {
            pnlChat.Controls.Clear();
            foreach (var item in ChatMessages)
            {
                if(item.FromEmail == Email)
                {
                    pnlChat.Controls.Add(createFromMessage(item));
                }
                else
                {
                    pnlChat.Controls.Add(createToMessage(item));
                }
            }
        }

        private Control createToMessage(ChatMessage item)
        {
            var txtTo = new Guna.UI2.WinForms.Guna2TextBox();
            txtTo.AppendText(item.MessageText + Environment.NewLine);
            txtTo.AppendText(item.Timestamp.ToString("HH:mm"));
            txtTo.BorderRadius = 10;
            txtTo.BackColor = Color.Transparent;
            txtTo.FillColor = Helper.MessBackground1;
            txtTo.Location = new Point(20, YLocation + 20);
            txtTo.Multiline = true;
            txtTo.AcceptsReturn = true;
            int lineCount = 4;
            int lineHeight = TextRenderer.MeasureText("Sample Text", txtTo.Font).Height;
            txtTo.Height = lineCount * lineHeight + txtTo.Padding.Vertical;
            txtTo.Width = TextRenderer.MeasureText(item.MessageText, txtTo.Font).Width + 20;
            txtTo.Padding = new Padding(10, 0, 0, 0);
           
            YLocation = YLocation + 20 + txtTo.Height;
            return txtTo;
        }

        private Control createFromMessage(ChatMessage item)
        {
           

            var txtFrom = new Guna.UI2.WinForms.Guna2TextBox();
            txtFrom.AppendText(item.MessageText + Environment.NewLine);
            txtFrom.AppendText(item.Timestamp.ToString("HH:mm"));
            txtFrom.BorderRadius = 10;
            txtFrom.FillColor = Color.AliceBlue;
            txtFrom.BackColor = Color.Transparent;
            txtFrom.Multiline = true;
            txtFrom.AcceptsReturn = true;
            int lineCount = 4;
            int lineHeight = TextRenderer.MeasureText("Sample Text", txtFrom.Font).Height;
            txtFrom.Height = lineCount * lineHeight + txtFrom.Padding.Vertical;
            txtFrom.Width = TextRenderer.MeasureText(item.MessageText, txtFrom.Font).Width + 50;
            txtFrom.Location = new Point(pnlChat.Size.Width - 20 - txtFrom.Width, YLocation + 20);
            txtFrom.Padding = new Padding(10, 0, 0, 0);
          
            YLocation = YLocation + 20 + txtFrom.Height;
            return txtFrom;
        }

      
    }
}
