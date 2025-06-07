using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Studyroom_kiosk
{
    // ▶ [Boundary] NewAccountUI: 신규 계정 등록 UI
    public partial class NewAccountUI : Form
    {
        // ▶ [Control] AccountControl: 계정 생성/검증 등 비즈니스 로직 담당
        private AccountControl accountController = new AccountControl();

        public NewAccountUI()
        {
            InitializeComponent(); // ▶ UI 초기화 (디자이너에서 설정한 컨트롤 구성)
        }

        // ▶ 회원가입 버튼 클릭 시 실행
        private void SignUpButton_Click(object sender, EventArgs e)
        {
            // ▶ [Entity] Account: 사용자 정보를 담는 객체
            var newAccount = new Account(
                idTextBox.Text,
                nameTextBox.Text,
                passwordTextBox.Text,
                phonenumberTextBox.Text
            );

            // ▶ [Control] RegisterAccount(): AccountControl이 계정 생성 처리
            bool success = accountController.RegisterAccount(newAccount);
            if (success)
            {
                MessageBox.Show("회원가입이 완료되었습니다.");
                this.Close(); // ▶ 창 닫기
            }
            else
            {
                MessageBox.Show("입력값을 확인해주세요.");
            }
        }
    }
}
