using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Studyroom_kiosk
{
    public class AccountController
    {
        public bool RegisterAccount(Account newAccount)
        {
            // 유효성 검사
            if (string.IsNullOrEmpty(newAccount.UserId) ||
                string.IsNullOrEmpty(newAccount.UserPassword) ||
                string.IsNullOrEmpty(newAccount.UserName) ||
                string.IsNullOrEmpty(newAccount.UserPhoneNum))
                return false;

            // 중복 검사
            if (DatabaseManager.GetAccountById(newAccount.UserId) != null)
            {
                MessageBox.Show("이미 존재하는 아이디입니다.");
                return false;
            }

            return DatabaseManager.InsertAccount(newAccount);
        }
    }
}
