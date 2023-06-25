using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ban_2.Models
{
    public class User
    {
        public string Email { get; set; }
        public string UserPass { get; set; }
        public string SDT { get; set; }
        public int Permission { get; set; }
        public byte[] Avatar { get; set; }
     
    }
}

