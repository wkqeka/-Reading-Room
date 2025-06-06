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
    public partial class LoginSignInUI : Form
    {
        private AccountController accountController = new AccountController();

        public LoginSignInUI()
        {
            InitializeComponent();
        }

        private void SignUpButton_Click(object sender, EventArgs e)
        {
            var newAccount = new Account(
                idTextBox.Text,
                nameTextBox.Text,
                passwordTextBox.Text,
                phonenumberTextBox.Text
            );

            bool success = accountController.RegisterAccount(newAccount);
            if (success)
            {
                MessageBox.Show("회원가입이 완료되었습니다.");
                this.Close();
            }
            else
            {
                MessageBox.Show("입력값을 확인해주세요.");
            }
        }
    }
}