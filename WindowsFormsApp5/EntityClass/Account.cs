using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Studyroom_kiosk
{
    public class Account
    {
        public string UserId { get; set; } // int → string
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public string UserPhoneNum { get; set; }

        public Account(string id, string name, string password, string phone)
        {
            UserId = id;
            UserName = name;
            UserPassword = password;
            UserPhoneNum = phone;
        }
    }
}
