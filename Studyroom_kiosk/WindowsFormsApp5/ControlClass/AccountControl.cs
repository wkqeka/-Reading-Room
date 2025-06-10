using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Studyroom_kiosk
{
    // ▶ [Control 클래스] AccountControl
    // 로그인 시도 및 회원가입 로직을 처리하는 제어 로직 클래스
    public class AccountControl
    {
        // ▶ 로그인 시도 로직
        // [Boundary → Control] LoginUI가 호출
        public bool TryLogin(string id, string password)
        {
            // ▶ [Entity] Account 객체를 DB에서 조회
            Account account = DatabaseManager.GetAccountById(id);

            // ▶ ID 존재 + 비밀번호 일치 여부 확인
            return account != null && account.UserPassword == password;
        }

        // ▶ 회원가입 로직
        // [Boundary → Control] NewAccountUI가 호출
        public bool RegisterAccount(Account newAccount)
        {
            // ▶ 필수 항목 누락 여부 확인
            if (string.IsNullOrEmpty(newAccount.UserId) ||
                string.IsNullOrEmpty(newAccount.UserPassword) ||
                string.IsNullOrEmpty(newAccount.UserName) ||
                string.IsNullOrEmpty(newAccount.UserPhoneNum))
                return false;

            // ▶ 중복 ID 검사
            if (DatabaseManager.GetAccountById(newAccount.UserId) != null)
            {
                MessageBox.Show("이미 존재하는 아이디입니다.");
                return false;
            }

            // ▶ DB에 회원 정보 저장 시도
            return DatabaseManager.InsertAccount(newAccount);
        }
    }
}
