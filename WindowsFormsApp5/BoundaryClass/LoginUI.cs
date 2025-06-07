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

        private AccountControl accountControl = new AccountControl();


        public LoginUI()
        {
            InitializeComponent();
        }

        private void onLoginClck(object sender, EventArgs e)
        {
            string id = txtId.Text.Trim();
            string password = txtPassword.Text;

            if (accountControl.TryLogin(id, password))
            {
                if (this.Owner is MainUI mainForm)
                {
                    mainForm.SetLoginUser(id);       // ID 저장
                    mainForm.EnableAfterLogin();     // 버튼 활성화
                }

                MessageBox.Show("로그인 성공!");
                this.Close();
            }
            else
            {
                MessageBox.Show("로그인 실패: 아이디 또는 비밀번호를 확인하세요.");
            }
        }

        private void onNewAccountClick(object sender, EventArgs e)
        {
            new NewAccountUI().Show();
        }
        public string GetUserId()
        {
            return txtId.Text.Trim(); // 또는 로그인 성공 시 저장한 private 필드
        }
    }
}
