using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Studyroom_kiosk
{
    // ▶ [Entity 클래스] Account
    // 사용자 정보 (아이디, 이름, 비밀번호, 전화번호)를 담는 객체
    public class Account
    {
        // ▶ 사용자 ID (PK 역할)
        public string UserId { get; set; }

        // ▶ 사용자 이름
        public string UserName { get; set; }

        // ▶ 사용자 비밀번호
        public string UserPassword { get; set; }

        // ▶ 사용자 전화번호
        public string UserPhoneNum { get; set; }

        // ▶ 생성자: 모든 필드를 초기화
        public Account(string id, string name, string password, string phone)
        {
            UserId = id;
            UserName = name;
            UserPassword = password;
            UserPhoneNum = phone;
        }
    }
}
