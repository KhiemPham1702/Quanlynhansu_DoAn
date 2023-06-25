using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ban_2.Models
{
    public class ChatMessage
    {
        public int MessageID { get; set; }
        public int TypeMessage { get; set; }
        public string FromEmail { get; set; }
        public string EmotionFrom { get; set; }
        public string EmotionTo { get; set; }
        public string ToEmail { get; set; }
        public string MessageText { get; set; }
        public DateTime Timestamp { get; set; }
    }
}

