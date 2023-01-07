using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ban_2.Models
{
    public class ChatConservation
    {
        public byte[] Avatar { get; set; }
        public string ToName { get; set; }
        public ChatMessage LastMessage { get; set; }

        public Image ByteArrayToImage()
        {
            try
            {
                MemoryStream m = new MemoryStream(Avatar);
                return Image.FromStream(m);
            }
            catch (Exception ex)
            {
                return Helper.AvatarDefault;
            }
            
        }
    }
}
