using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Studyroom_kiosk
{
    public class LoginController
    {
        public bool TryLogin(string id, string password)
        {
            // DB 연결해서 확인
            Account account = DatabaseManager.GetAccountById(id);

            if (account == null) return false;
            return account.UserPassword == password;
        }
    }
}
