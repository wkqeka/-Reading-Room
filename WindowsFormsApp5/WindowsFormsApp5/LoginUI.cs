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
    public partial class LoginUI : Form
    {
        public LoginUI()
        {
            InitializeComponent();
        }
        
        // 아래는 테스트 코드입니다.
        // 함수안의 내용은 아무 의미 없으니 삭제후 사용하시면 됩니다.
        #region 로그인 코드
        private void onLoginClck(object sender, EventArgs e)
        {
            // 로그인 확인
            bool test = false;
            if (test == true) 
            {
                // 로그인 성공시 메인화면 진입
                MessageBox.Show("로그인에 성공하셨습니다.");
            }
            else if(test == false)
            {
                // 로그인 실패시 실패 메시지 띄움
                MessageBox.Show("로그인에 실패하였습니다.\n아이디나 비밀번호를 다시 확인해주세요.");
            }
        }
        #endregion

        #region 회원가입 코드
        private void onNewAccountClick(object sender, EventArgs e)
        {
            // 회원가입 창 띄움
            Form LoginSingInUI = new LoginSingInUI();
            LoginSingInUI.Show();
            // 회원 가입 창 여러개 뛰우지 않게끔 예외처리 필요
        }
        #endregion

    }
}
