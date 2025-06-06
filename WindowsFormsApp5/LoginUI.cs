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
    public partial class LoginUI : Form
    {
        public event EventHandler LoginSucceeded;

        private LoginController loginController = new LoginController();

        public LoginUI()
        {
            InitializeComponent();
        }

        private void onLoginClck(object sender, EventArgs e)
        {
            string id = idBox.Text;
            string pwd = passwordBox.Text;

            bool success = loginController.TryLogin(id, pwd);
            if (success)
            {
                MessageBox.Show("로그인 성공");
                LoginSucceeded?.Invoke(this, EventArgs.Empty); // 이벤트 알림
                this.Close(); // 메인으로 복귀
            }
            else
            {
                MessageBox.Show("로그인에 실패하였습니다.\n아이디나 비밀번호를 다시 확인해주세요.");
            }
        }

        private void onNewAccountClick(object sender, EventArgs e)
        {
            new LoginSignInUI().Show();
        }
    }
}
