﻿using ban_2.Models;
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
    public partial class UCInfoChat : UserControl
    {
        public UCInfoChat()
        {
            InitializeComponent();
            LoadName();
        }
        private void LoadName()
        {
            string sql = $"SELECT * FROM NHANVIEN WHERE EMAIL = @EMAIL";
            var parameters = new object[] { Helper.ToEmailChatUser };
            var data = DataProvider.Instance.ExecuteQuery(sql, parameters);
            lblName.Text = (string)data.Rows[0]["HOTEN"];
            try
            {
                var imageB = (byte[])data.Rows[0]["AVATAR"];
                picturboxAvatar.Image = ByteArrayToImage(imageB);
            }
            catch (Exception ex)
            {

            }
        }
        public Image ByteArrayToImage(byte[] avt)
        {
            try
            {
                MemoryStream m = new MemoryStream(avt);
                return Image.FromStream(m);
            }
            catch (Exception ex)
            {
                return Helper.AvatarDefault;
            }

        }
        private void btnInfo_Click(object sender, EventArgs e)
        {
            Helper.PnlInfo.Visible = false;
        }

        private void btnChangeBG_Click(object sender, EventArgs e)
        {
            Helper.PnlInfo.Controls.Clear();
            Helper.PnlInfo.Controls.Add(new UCChangeBG());
        }

        private void btnViewFile_Click(object sender, EventArgs e)
        {
            Helper.PnlInfo.Controls.Clear();
            Helper.PnlInfo.Controls.Add(new UCViewFile());
        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            Helper.PnlInfo.Controls.Clear();
            Helper.PnlInfo.Controls.Add(new UCFindMess());
        }
    }
}
