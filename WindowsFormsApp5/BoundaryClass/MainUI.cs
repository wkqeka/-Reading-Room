using Studyroom_kiosk;
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
    // ▶ [Boundary] MainUI: 메인 사용자 인터페이스, 로그인 및 자리 선택 진입점
    public partial class MainUI : Form
    {
        // ▶ 로그인 상태 및 현재 로그인한 사용자 ID를 관리하는 내부 변수
        private bool isLoggedIn = false;
        private string currentUserId = null;

        public MainUI()
        {
            InitializeComponent();

            // ▶ 로그인 전에는 좌석 선택 비활성화
            seatSelectButton.Enabled = false;
        }

        // ▶ 로그인/로그아웃 버튼 클릭 이벤트 처리
        private void loginButton_Click(object sender, EventArgs e)
        {
            if (currentUserId == null)
            {
                // ▶ [Boundary] LoginUI: 로그인 UI를 자식 창으로 실행
                var loginUI = new LoginUI();
                loginUI.Owner = this;           // ▶ MainUI가 부모 폼
                loginUI.ShowDialog();           // ▶ 로그인 완료 후 EnableAfterLogin 호출됨
            }
            else
            {
                // ▶ 로그아웃 절차
                var confirm = MessageBox.Show("로그아웃 하시겠습니까?", "로그아웃", MessageBoxButtons.YesNo);
                if (confirm == DialogResult.Yes)
                {
                    currentUserId = null;
                    isLoggedIn = false;
                    seatSelectButton.Enabled = false;
                    loginButton.Text = "로그인";
                    MessageBox.Show("로그아웃 되었습니다.");
                }
            }
        }

        // ▶ 로그인 UI에서 로그인 성공 시 호출됨 → 사용자 ID 저장
        public void SetLoginUser(string userId)
        {
            currentUserId = userId;
        }

        // ▶ 로그인 성공 이후 UI 변경 (버튼 활성화, 텍스트 변경)
        public void EnableAfterLogin()
        {
            isLoggedIn = true;
            seatSelectButton.Enabled = true;
            loginButton.Text = "로그아웃";
        }

        // ▶ 좌석 선택 버튼 클릭 시 실행되는 처리 로직
        private void seatSelectButton_Click(object sender, EventArgs e)
        {
            if (!isLoggedIn)
            {
                MessageBox.Show("로그인 후 이용 가능합니다.");
                return;
            }

            // ▶ [Boundary] SeatInquiryUI: 자리 현황 확인 및 예약/결제 진입
            this.Hide(); // ▶ 현재 메인 폼 숨김
            var seatForm = new SeatInquiryUI(currentUserId);

            // ▶ 자리 선택창 닫히면 메인 폼 다시 표시
            seatForm.FormClosed += (s, args) => this.Show();
            seatForm.Show();
        }
    }
}
