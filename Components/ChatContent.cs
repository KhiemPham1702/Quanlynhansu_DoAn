using ban_2.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ban_2.Components
{
    public partial class ChatContent : UserControl
    {
        public List<ChatMessage> ChatMessages { get; set; }
        public int YLocation { get; set; }
        public List<DateTime> DateTimes { get; set; }
        public EmotionDialog EmotionDialog { get; set; }
        public ChatContent( )
        {
            YLocation = 10;
            LoadMessages();
            InitializeComponent();
            LoadName();
            LoadBackground();
            LoadChat();

        }

        public void LoadMessages()
        {
            ChatMessages = new List<ChatMessage>();
            string sql = $"SELECT * FROM MESSAGE WHERE (( FromEmail = @FromEmail AND ToEmail = @ToEmail ) OR ( FromEmail = @To AND ToEmail = @From )) ";
            var parameters = new object[] { Helper.CurrentUser.Email, Helper.ToEmailChatUser, Helper.ToEmailChatUser, Helper.CurrentUser.Email };
            var data = DataProvider.Instance.ExecuteQuery(sql, parameters);
            for (int i = 0; i < data.Rows.Count; i++)
            {
                ChatMessage message = new ChatMessage
                {
                    MessageID = (int)data.Rows[i]["MessageID"],
                    TypeMessage = (int)data.Rows[i]["TypeMessage"],
                    FromEmail = (string)data.Rows[i]["FromEmail"],
                    ToEmail = (string)data.Rows[i]["ToEmail"],
                    EmotionFrom = (string)data.Rows[i]["EmotionFrom"],
                    EmotionTo = (string)data.Rows[i]["EmotionTo"],
                    MessageText = (string)data.Rows[i]["MessageText"],
                    Timestamp = (DateTime)data.Rows[i]["Timestamp"]
                };
                ChatMessages.Add(message);
            }
            var item = ChatMessages.FirstOrDefault();
        }

        public void ScrollToPosition(ChatMessage mess)
        {
            for (int i = pnlChat.Controls.Count - 1; i >= 0; i--)
            {
                Control control = pnlChat.Controls[i];
                if (control.Tag != null && control.Tag.ToString() == "Container" + mess.MessageID)
                {
                    pnlChat.ScrollControlIntoView(control);
                    break;
                }
            }
            
        }
        private void LoadName()
        {
            string sql = $"SELECT * FROM NHANVIEN WHERE EMAIL = @EMAIL";
            var parameters = new object[] { Helper.ToEmailChatUser };
            var data = DataProvider.Instance.ExecuteQuery(sql, parameters);
            lblName.Text = (string)data.Rows[0]["HOTEN"];
        }

        private void LoadBackground()
        {
            var url = "default";
            string sql = $"SELECT * FROM Conversations WHERE FromEmail = @FromEmail AND ToEmail = @ToEmail";
            var parameters = new object[] { Helper.CurrentUser.Email, Helper.ToEmailChatUser };
            var data = DataProvider.Instance.ExecuteQuery(sql, parameters);
            if(data.Rows.Count> 0)
            {
                url = (string)data.Rows[0]["Background"];
            }
            ChangeBackground(url);
        }
        public void UpdateBackgroundToSql(string url, string fromEmail, string toEmail)
        {
            string updateQuery = "UPDATE Conversations SET Background = @Background WHERE FromEmail = @FromEmail AND ToEmail = @ToEmail";
            var parameters = new object[] { url, fromEmail, toEmail };
            DataProvider.Instance.ExecuteNonQuery(updateQuery, parameters);
        }
        public void AddMessage()
        {
            LoadMessages();
            LoadChat();
            ScrollToPosition(ChatMessages[ChatMessages.Count - 1]);
        }
        public void ChangeBackground(string url)
        {
            if(url == "default")
            {
                pnlChat.BackgroundImage = null;
            }
            else
            {
                pnlChat.BackgroundImage = Image.FromFile(url);
                pnlChat.BackgroundImageLayout = ImageLayout.Stretch;
            }
           
        }
        void UpdateEmotionTo(int id , string emotion)
        {
            string updateQuery = "UPDATE MESSAGE SET EmotionTo = @EmotionTo WHERE MessageID = @MessageID";
            var parameters = new object[] { emotion, id };
            DataProvider.Instance.ExecuteNonQuery(updateQuery, parameters);
        }
        void UpdateEmotionFrom(int id, string emotion)
        {
            string updateQuery = "UPDATE MESSAGE SET EmotionFrom = @EmotionFrom WHERE MessageID = @MessageID";
            var parameters = new object[] { emotion, id };
            DataProvider.Instance.ExecuteNonQuery(updateQuery, parameters);
        }
        public void UpdateEmotionMessage(int id , string emotion , string email)
        {
            var item = ChatMessages.Find(e => e.MessageID == id);
            if (item == null) return;
            var index = ChatMessages.IndexOf(item); 
            if (Helper.CurrentUser.Email == email)
            {
                if (item.FromEmail == Helper.CurrentUser.Email)
                {
                    item.EmotionFrom = emotion == item.EmotionFrom ? "normal" : emotion;
                    if(item.EmotionFrom == "normal")
                    {
                        removeIconFromFollowItem(item);
                    }
                    else
                    {
                        addIconFromFollowItem(item);
                    }
                    UpdateEmotionFrom(id, item.EmotionFrom);
                }
                else if (item.ToEmail == Helper.CurrentUser.Email)
                {
                    item.EmotionTo = (emotion == item.EmotionTo) ? "normal" : emotion;
                    if (item.EmotionTo == "normal")
                    {
                        removeIconToFollowItem(item);
                    }
                    else
                    {
                        addIconToFollowItem(item);
                    }
                    UpdateEmotionTo(id, item.EmotionTo);
                }
                
            }
            else if (email == Helper.ToEmailChatUser)
            {
                if (item.FromEmail == Helper.CurrentUser.Email)
                {
                    item.EmotionTo = emotion == item.EmotionTo ? "normal" : emotion;
                    if (item.EmotionTo == "normal")
                    {
                        removeIconToFollowItem(item);
                    }
                    else
                    {
                        addIconToFollowItem(item);
                    }
                }
                else if (item.ToEmail == Helper.CurrentUser.Email)
                {
                    item.EmotionFrom = emotion == item.EmotionFrom ? "normal" : emotion;
                    if (item.EmotionFrom == "normal")
                    {
                        removeIconFromFollowItem(item);
                    }
                    else
                    {
                        addIconFromFollowItem(item);
                    }
                }

            }
            
            ChatMessages[index] = item;         
            //LoadChat();
        }
        private void removeIconFromFollowItem(ChatMessage item)
        {
            for (int i = pnlChat.Controls.Count - 1; i >= 0; i--)
            {
                Control control = pnlChat.Controls[i];
                if (control.Tag != null && control.Tag.ToString() == "IconFrom" + item.MessageID)
                {
                    pnlChat.Controls.Remove(control);
                }
            }
        }
        private void addIconFromFollowItem(ChatMessage item)
        {
            removeIconFromFollowItem(item);
            for (int i = pnlChat.Controls.Count - 1; i >= 0; i--)
            {
                Control control = pnlChat.Controls[i];
                if (control.Tag != null && control.Tag.ToString() == "Container" + item.MessageID)
                {
                    if (control is Guna.UI2.WinForms.Guna2TextBox)
                    {
                        addIconTextBoxFromHandlerEvent(control as Guna.UI2.WinForms.Guna2TextBox, item);
                    }
                    else
                    {
                        addIconButtonFromHandlerEvent(control as Guna.UI2.WinForms.Guna2Button, item);
                    }
                    return;
                }
            }
        }
        private void removeIconToFollowItem(ChatMessage item)
        {
            for (int i = pnlChat.Controls.Count - 1; i >= 0; i--)
            {
                Control control = pnlChat.Controls[i];
                if (control.Tag != null && control.Tag.ToString() == "IconTo" + item.MessageID)
                {
                    pnlChat.Controls.Remove(control);
                }
            }
        }
        private void addIconToFollowItem(ChatMessage item)
        {
            removeIconToFollowItem(item);
            for (int i = pnlChat.Controls.Count - 1; i >= 0; i--)
            {
                Control control = pnlChat.Controls[i];
                if (control.Tag != null && control.Tag.ToString() == "Container" + item.MessageID)
                {
                    if (control is Guna.UI2.WinForms.Guna2TextBox)
                    {
                        addIconTextBoxToHandlerEvent(control as Guna.UI2.WinForms.Guna2TextBox, item);
                    }
                    else
                    {
                        addIconButtonToHandlerEvent(control as Guna.UI2.WinForms.Guna2Button, item);
                    }
                    return;
                }
            }
        }
        private void LoadChat()
        {
            pnlChat.Controls.Clear();
            YLocation = 0;
            DateTimes = new List<DateTime>();
            foreach (var item in ChatMessages)
            {
                if ((item.FromEmail == Helper.CurrentUser.Email && item.ToEmail == Helper.ToEmailChatUser) || (item.FromEmail == Helper.ToEmailChatUser && item.ToEmail == Helper.CurrentUser.Email))
                {
                    var date = new DateTime(item.Timestamp.Year, item.Timestamp.Month, item.Timestamp.Day);
                    bool exists = DateTimes.Contains(date);
                    if (!exists)
                    {
                        DateTimes.Add(date);
                        var seperator = new SeperatorDate(date);
                        seperator.Location = new Point(0, YLocation + 30);
                        YLocation = YLocation + 30 + seperator.Height;
                        pnlChat.Controls.Add(seperator);

                    }
                }
                if (item.FromEmail == Helper.CurrentUser.Email && item.ToEmail == Helper.ToEmailChatUser)
                {
                    if (item.TypeMessage == 1)
                    {
                        var textContainer = createFromMessageTypeText(item);
                        textContainer.Tag = "Container" + item.MessageID;
                        pnlChat.Controls.Add(textContainer);
                        if (item.EmotionFrom != "normal")
                        {
                            addIconTextBoxFromHandlerEvent(textContainer as Guna.UI2.WinForms.Guna2TextBox, item);
                        }
                        if (item.EmotionTo != "normal")
                        {
                            addIconTextBoxToHandlerEvent(textContainer as Guna.UI2.WinForms.Guna2TextBox, item);
                        }
                        pnlChat.Controls.Add(createFromButtonEmotion(textContainer, item));
                    }
                    else if (item.TypeMessage == 2)
                    {
                        var textContainer = createFromMessageTypeButton(item);
                        textContainer.Tag = "Container" + item.MessageID;
                        pnlChat.Controls.Add(textContainer);
                        if (item.EmotionFrom != "normal")
                        {
                            addIconButtonFromHandlerEvent(textContainer as Guna.UI2.WinForms.Guna2Button, item);
                        }
                        if (item.EmotionTo != "normal")
                        {
                            addIconButtonToHandlerEvent(textContainer as Guna.UI2.WinForms.Guna2Button, item);
                        }
                        pnlChat.Controls.Add(createFromButtonEmotion(textContainer, item));
                    }
                }
                else if (item.FromEmail == Helper.ToEmailChatUser && item.ToEmail == Helper.CurrentUser.Email)
                {
                    if (item.TypeMessage == 1)
                    {
                        var textContainer = createToMessageTypeText(item);
                        textContainer.Tag = "Container" + item.MessageID;
                        pnlChat.Controls.Add(textContainer);
                        if (item.EmotionFrom != "normal")
                        {
                            addIconTextBoxFromHandlerEvent(textContainer as Guna.UI2.WinForms.Guna2TextBox, item);
                        }
                        if (item.EmotionTo != "normal")
                        {
                            addIconTextBoxToHandlerEvent(textContainer as Guna.UI2.WinForms.Guna2TextBox, item);
                        }
                        pnlChat.Controls.Add(createToButtonEmotion(textContainer, item));
                    }
                    else if (item.TypeMessage == 2)
                    {
                        var textContainer = createToMessageTypeButton(item);
                        textContainer.Tag = "Container" + item.MessageID;
                        pnlChat.Controls.Add(textContainer);
                        if (item.EmotionFrom != "normal")
                        {
                            addIconButtonFromHandlerEvent(textContainer as Guna.UI2.WinForms.Guna2Button, item);
                        }
                        if (item.EmotionTo != "normal")
                        {
                            addIconButtonToHandlerEvent(textContainer as Guna.UI2.WinForms.Guna2Button, item);
                        }
                        pnlChat.Controls.Add(createToButtonEmotion(textContainer, item));
                    }

                }

            }

        }
        private Control createFromButtonEmotion(Control textContainer, ChatMessage item)
        {
            var buttonEmotion = new Guna.UI2.WinForms.Guna2CircleButton();
            buttonEmotion.FillColor = Color.Transparent;
            buttonEmotion.BackColor = Color.Transparent;
            buttonEmotion.Image = Properties.Resources.happy_64;
            buttonEmotion.Size = new Size(30, 30);
            int x = textContainer.Left - 40;
            int y = textContainer.Top + textContainer.Height / 2 - 15;
            buttonEmotion.Location = new Point(x, y);
            buttonEmotion.Click += (sender, e) =>
            {
                var parameter = buttonEmotion;
                ShowFromEmotionDialog(sender, e, parameter, textContainer , item);
            };
            return buttonEmotion;
        }

        private void ShowFromEmotionDialog(object sender, EventArgs e, Guna.UI2.WinForms.Guna2CircleButton parameter, Control textContainer, ChatMessage item)
        {
            if (pnlChat.Contains(EmotionDialog))
            {
                if (EmotionDialog.Tag as string == textContainer.Text)
                {
                    pnlChat.Controls.Remove(EmotionDialog);
                    return;
                }
                else
                {
                    pnlChat.Controls.Remove(EmotionDialog);
                }
            }
            EmotionDialog = new EmotionDialog(item.MessageID);
            int y = parameter.Bottom + 2;
            int x = parameter.Left - EmotionDialog.Width;           
            EmotionDialog.Tag = textContainer.Text;
            EmotionDialog.Location = new Point(x, y);
            pnlChat.Controls.Add(EmotionDialog);
            pnlChat.Controls.SetChildIndex(EmotionDialog, 0);
        }

        private Control createToButtonEmotion(Control textContainer, ChatMessage item)
        {
            var buttonEmotion = new Guna.UI2.WinForms.Guna2CircleButton();
            buttonEmotion.FillColor = Color.Transparent;
            buttonEmotion.BackColor = Color.Transparent;
            buttonEmotion.Image = Properties.Resources.happy_64;
            buttonEmotion.Size = new Size(30, 30);
            int x = textContainer.Right + 20;
            int y = textContainer.Top + textContainer.Height / 2 - 15;
            buttonEmotion.Location = new Point(x, y);
            buttonEmotion.Click += (sender, e) =>
            {
                var parameter = buttonEmotion;
                ShowToEmotionDialog(sender, e, parameter , textContainer, item);
            };
            return buttonEmotion;
        }

        private void ShowToEmotionDialog(object sender, EventArgs e, Guna.UI2.WinForms.Guna2CircleButton parameter, Control textContainer, ChatMessage item)
        {
            if(pnlChat.Contains(EmotionDialog))
            {
                if(EmotionDialog.Tag as string == textContainer.Text)
                {
                    pnlChat.Controls.Remove(EmotionDialog);
                    return;
                }
                else
                {
                    pnlChat.Controls.Remove(EmotionDialog);
                }
            }
            int y = parameter.Bottom + 5;
            int x = parameter.Left;
            EmotionDialog = new EmotionDialog(item.MessageID);
            EmotionDialog.Location = new Point(x, y);
            EmotionDialog.Tag = textContainer.Text;
            pnlChat.Controls.Add(EmotionDialog);
            pnlChat.Controls.SetChildIndex(EmotionDialog, 0);

        }

        private Control createToMessageTypeButton(ChatMessage item)
        {
            var fileToButton = new Guna.UI2.WinForms.Guna2Button();
            string fullPath = item.MessageText;
            string fileName = Path.GetFileName(fullPath);
            fileToButton.Text = fileName + "\n" + item.Timestamp.ToString("HH:mm");
            fileToButton.BorderRadius = 10;
            fileToButton.AutoSize = true;
            fileToButton.FillColor = Color.LightGray;
            fileToButton.BackColor = Color.Transparent;
            fileToButton.Image = Properties.Resources.file;
            fileToButton.ForeColor = Color.Black;
            fileToButton.Location = new Point(20, YLocation + 20);
            YLocation = YLocation + 20 + fileToButton.Height;
            fileToButton.Click += (sender, e) =>
            {
                string parameter = item.MessageText;
                FileFromButtonHandlerMethod(sender, e, parameter);
            };
            return fileToButton;
        }
        private Control createFromMessageTypeButton(ChatMessage item)
        {
            var fileFromButton = new Guna.UI2.WinForms.Guna2Button();
            fileFromButton.BorderRadius = 10;
            fileFromButton.AutoSize = true;
            string fullPath = item.MessageText;
            string fileName = Path.GetFileName(fullPath);
            fileFromButton.Text = fileName + "\n" + item.Timestamp.ToString("HH:mm");
            fileFromButton.Image = Properties.Resources.file;
            fileFromButton.ForeColor = Color.Black;
            fileFromButton.FillColor = Color.LightGray;
            fileFromButton.BackColor = Color.Transparent;
            fileFromButton.Location = new Point(pnlChat.Size.Width - 20 - fileFromButton.Width, YLocation + 20);
            YLocation = YLocation + 20 + fileFromButton.Height;
            fileFromButton.Click += (sender, e) =>
            {
                string parameter = item.MessageText;
                FileFromButtonHandlerMethod(sender, e, parameter);
            };
            return fileFromButton;
        }

        private void FileFromButtonHandlerMethod(object sender, EventArgs e , string fullPath)
        {
            try
            {
                Process.Start(fullPath);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private Control createToMessageTypeText(ChatMessage item)
        {
            var txtTo = new Guna.UI2.WinForms.Guna2TextBox();
            txtTo.TabIndex = 2;
            txtTo.AppendText(item.MessageText + Environment.NewLine);
            txtTo.AppendText(item.Timestamp.ToString("HH:mm"));
            txtTo.BorderRadius = 10;
            txtTo.BackColor = Color.Transparent;
            txtTo.FillColor = Helper.MessBackground1;
            txtTo.ForeColor = Color.Black;
            txtTo.Location = new Point(20, YLocation + 20);
            txtTo.Multiline = true;
            txtTo.AcceptsReturn = true;
            int lineCount = 4;
            int lineHeight = TextRenderer.MeasureText("Sample Text", txtTo.Font).Height;
            txtTo.Height = lineCount * lineHeight + txtTo.Padding.Vertical;
            txtTo.Width = TextRenderer.MeasureText(item.MessageText, txtTo.Font).Width + 50;
            txtTo.Padding = new Padding(10, 0, 0, 0);
            txtTo.ReadOnly = true;
            YLocation = YLocation + 20 + txtTo.Height;
            
            return txtTo;
        }

       

        private Control createFromMessageTypeText(ChatMessage item)
        {
           

            var txtFrom = new Guna.UI2.WinForms.Guna2TextBox();
            txtFrom.AppendText(item.MessageText + Environment.NewLine);
            txtFrom.AppendText(item.Timestamp.ToString("HH:mm"));
            txtFrom.BorderRadius = 10;
            txtFrom.ForeColor = Color.Black;
            txtFrom.FillColor = Color.AliceBlue;
            txtFrom.BackColor = Color.Transparent;
            txtFrom.Multiline = true;
            txtFrom.ReadOnly = true;
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
        private void addIconButtonFromHandlerEvent(Guna.UI2.WinForms.Guna2Button parameter, ChatMessage item)
        {

            Image image = null;
            switch (item.EmotionFrom)
            {
                case "haha":
                    image = Properties.Resources.haha;
                    break;
                case "like":
                    image = Properties.Resources.like;
                    break;
                case "love":
                    image = Properties.Resources.love;
                    break;
                default:
                    image = Properties.Resources.like;
                    break;
            }
            var icon = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            icon.Size = new Size(20, 20);
            icon.BackColor = parameter.FillColor;
            icon.FillColor = parameter.FillColor;
            icon.Image = image;
            icon.SizeMode = PictureBoxSizeMode.StretchImage;
            icon.Tag = "IconFrom" + item.MessageID;
            int x = parameter.Right - 50;
            int y = parameter.Bottom - 25;

            // Đặt vị trí của PictureBox
            icon.Location = new Point(x, y);

            // Thêm PictureBox vào Panel
            pnlChat.Controls.Add(icon);
            pnlChat.Controls.SetChildIndex(icon, 0);
        }
        private void addIconButtonToHandlerEvent(Guna.UI2.WinForms.Guna2Button parameter, ChatMessage item)
        {

            Image image = null;
            switch (item.EmotionTo)
            {
                case "haha":
                    image = Properties.Resources.haha;
                    break;
                case "like":
                    image = Properties.Resources.like;
                    break;
                case "love":
                    image = Properties.Resources.love;
                    break;
                default:
                    image = Properties.Resources.like;
                    break;
            }
            var icon = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            icon.Size = new Size(20, 20);
            icon.BackColor = parameter.FillColor;
            icon.FillColor = parameter.FillColor;
            icon.Image = image;
            icon.SizeMode = PictureBoxSizeMode.StretchImage;
            icon.Tag = "IconTo" + item.MessageID;
            int x = parameter.Right - 50;
            int y = parameter.Bottom - 25;

            // Đặt vị trí của PictureBox
            icon.Location = new Point(x, y);

            // Thêm PictureBox vào Panel
            pnlChat.Controls.Add(icon);
            pnlChat.Controls.SetChildIndex(icon, 0);
        }
        private void addIconTextBoxFromHandlerEvent(Guna.UI2.WinForms.Guna2TextBox parameter, ChatMessage item)
        {

            Image image = null;
            switch (item.EmotionFrom)
            {
                case "haha":
                    image = Properties.Resources.haha;
                    break;
                case "like":
                    image = Properties.Resources.like;
                    break;
                case "love":
                    image = Properties.Resources.love;
                    break;
                default:
                    image = Properties.Resources.like;
                    break;
            }
            var icon = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            icon.Size = new Size(20, 20);
            icon.BackColor = parameter.FillColor;
            icon.FillColor = parameter.FillColor;
            icon.Image = image;
            icon.SizeMode = PictureBoxSizeMode.StretchImage;
            icon.Tag = "IconFrom" + item.MessageID;
            int x = parameter.Right - 50;
            int y = parameter.Bottom - 25;

            // Đặt vị trí của PictureBox
            icon.Location = new Point(x, y);

            // Thêm PictureBox vào Panel
            pnlChat.Controls.Add(icon);
            pnlChat.Controls.SetChildIndex(icon, 0);
        }
        private void addIconTextBoxToHandlerEvent(Guna.UI2.WinForms.Guna2TextBox parameter, ChatMessage item)
        {

            Image image = null;
            switch (item.EmotionTo)
            {
                case "haha": 
                    image = Properties.Resources.haha;
                    break;
                case "like":
                    image = Properties.Resources.like;
                    break;
                case "love":
                    image = Properties.Resources.love;
                    break;
                default:
                    image = Properties.Resources.like;
                    break;
            }
            var icon = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            icon.Size = new Size(20, 20);
            icon.BackColor = parameter.FillColor;
            icon.FillColor = parameter.FillColor;
            icon.Image = image;
            icon.SizeMode = PictureBoxSizeMode.StretchImage;
            icon.Tag = "IconTo" + item.MessageID;
            int x = parameter.Right - 25;
            int y = parameter.Bottom - 25;

            // Đặt vị trí của PictureBox
            icon.Location = new Point(x, y);

            // Thêm PictureBox vào Panel
            pnlChat.Controls.Add(icon);
            pnlChat.Controls.SetChildIndex(icon, 0);
        }

        private void btnInfo_Click(object sender, EventArgs e)
        {
            Helper.PnlInfo.Visible = true;
            Helper.PnlInfo.BringToFront();
            Helper.PnlInfo.Controls.Clear();
            Helper.PnlInfo.Controls.Add(new UCInfoChat());
        }
    }
}
