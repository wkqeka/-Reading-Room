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
    public partial class MainUI : Form
    {
        private bool isLoggedIn = false;
        private string currentUserId = null;

        public MainUI()
        {
            InitializeComponent();
            seatSelectButton.Enabled = false; // 초기에는 비활성화
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            if (currentUserId == null)
            {
                var loginUI = new LoginUI(); // 로그인 창 열기
                loginUI.Owner = this;
                loginUI.ShowDialog();
            }
            else
            {
                var confirm = MessageBox.Show("로그아웃 하시겠습니까?", "로그아웃", MessageBoxButtons.YesNo);
                if (confirm == DialogResult.Yes)
                {
                    currentUserId = null;
                    isLoggedIn = false;
                    seatSelectButton.Enabled = false; // 로그아웃 시 자리 선택 비활성화
                    loginButton.Text = "로그인";
                    MessageBox.Show("로그아웃 되었습니다.");
                }
            }
        }

        public void SetLoginUser(string userId)
        {
            currentUserId = userId;
        }

        public void EnableAfterLogin()
        {
            isLoggedIn = true;
            seatSelectButton.Enabled = true;
            loginButton.Text = "로그아웃";
        }

        private void seatSelectButton_Click(object sender, EventArgs e)
        {
            if (!isLoggedIn)
            {
                MessageBox.Show("로그인 후 이용 가능합니다.");
                return;
            }

            this.Hide();
            var seatForm = new SeatInquiryUI(currentUserId);
            seatForm.FormClosed += (s, args) => this.Show(); // 자리 선택 닫으면 메인창 복귀
            seatForm.Show();
        }
    }
}
