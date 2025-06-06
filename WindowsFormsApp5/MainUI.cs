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

namespace WindowsFormsApp5
{
    public partial class MainUI : Form
    {
        private bool isLoggedIn = false;

        public MainUI()
        {
            InitializeComponent();
            seatSelectButton.Enabled = false; // 초기에는 비활성화
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            var loginForm = new LoginUI();
            loginForm.LoginSucceeded += OnLoginSuccess; // 이벤트 연결
            loginForm.ShowDialog();
        }

        private void OnLoginSuccess(object sender, EventArgs e)
        {
            isLoggedIn = true;
            seatSelectButton.Enabled = true;
        }

        private void seatSelectButton_Click(object sender, EventArgs e)
        {
            if (!isLoggedIn)
            {
                MessageBox.Show("로그인 후 이용 가능합니다.");
                return;
            }

            this.Hide();
            var seatForm = new SeatInquiryUI();
            seatForm.FormClosed += (s, args) => this.Show(); // 다시 메인으로 돌아오기
            seatForm.Show();
        }
    }
}
