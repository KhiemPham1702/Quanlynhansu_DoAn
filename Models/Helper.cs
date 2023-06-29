using ban_2.Form_selection;
using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ban_2.Models
{
    public class Helper
    {
        public static Image AvatarDefault = Properties.Resources.jing_fm_account_clipart_1952632;
        public static Color ConsClicked = ColorTranslator.FromHtml("#ffd9d7");
        public static Color ConsHover = ColorTranslator.FromHtml("#eaeaea");
        public static Color ConsDefault = ColorTranslator.FromHtml("#ffffff");

        public static Color MessBackground1 = ColorTranslator.FromHtml("#ffd9d7");
        public static Color MessBackground2 = ColorTranslator.FromHtml("#555555");
        public static Color MessForeColor = ColorTranslator.FromHtml("#c0aba8");

        public static User CurrentUser;
        public static string ToEmailChatUser;

        public static Guna.UI2.WinForms.Guna2Panel PnlInfo;
        public static Chat ChatControl;
        public static List<string> ReceiveNewMess = new List<string>();
    }
}
