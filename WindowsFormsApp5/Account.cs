using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp5
{
    public class Account
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public string UserPhoneNum { get; set; }
        public int UserMileage { get; set; } = 0;
        public DateTime PurchaseDate { get; set; } = DateTime.Now;
        public string MyTime { get; set; }
        public bool IsAdmin { get; set; } = false;

        public Account(string userId, string userName, string userPassword, string userPhoneNum)
        {
            UserId = userId;
            UserName = userName;
            UserPassword = userPassword;
            UserPhoneNum = userPhoneNum;
        }
    }
}
