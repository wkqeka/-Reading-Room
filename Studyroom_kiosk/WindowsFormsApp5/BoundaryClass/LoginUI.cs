using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Studyroom_kiosk
{
    // ▶ [Boundary] LoginUI 클래스: 사용자 인터페이스 계층의 로그인 화면 폼
    public partial class LoginUI : Form
    {
        // ▶ [Control] AccountControl 클래스 사용: 로그인 로직을 담당하는 컨트롤 클래스
        private AccountControl accountControl = new AccountControl();

        public LoginUI()
        {
            InitializeComponent(); // ▶ Windows Form Designer에서 생성한 UI 구성 초기화
        }

        // ▶ 로그인 버튼 클릭 이벤트 핸들러
        private void onLoginClck(object sender, EventArgs e)
        {
            string id = txtId.Text.Trim();              // ▶ 사용자 입력 ID
            string password = txtPassword.Text;         // ▶ 사용자 입력 비밀번호

            // ▶ [Control] AccountControl.TryLogin 호출: Entity(Account)를 통한 검증 수행
            if (accountControl.TryLogin(id, password))
            {
                // ▶ 로그인 후 MainUI에서 로그인 사용자 ID와 권한 처리
                if (this.Owner is MainUI mainForm)
                {
                    mainForm.SetLoginUser(id);       // ▶ MainUI에 로그인 ID 전달
                    mainForm.EnableAfterLogin();     // ▶ 로그인 이후 버튼 활성화
                }

                MessageBox.Show("로그인 성공!");
                this.Close(); // ▶ 로그인 폼 종료
            }
            else
            {
                MessageBox.Show("로그인 실패: 아이디 또는 비밀번호를 확인하세요.");
            }
        }

        // ▶ 회원가입 버튼 클릭 시 회원가입 폼(NewAccountUI) 띄움
        private void onNewAccountClick(object sender, EventArgs e)
        {
            new NewAccountUI().Show(); // ▶ [Boundary] NewAccountUI: 계정 생성 화면
        }

        // ▶ 로그인된 사용자 ID를 외부에서 가져오기 위한 메서드
        public string GetUserId()
        {
            return txtId.Text.Trim(); // ▶ 혹은 로그인 시 저장된 필드값을 사용할 수도 있음
        }
    }
}
