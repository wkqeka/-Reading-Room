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
    public partial class LoginSingInUI : Form
    {
        public bool checkOpen = false;
        public LoginSingInUI()
        {
            InitializeComponent();
            checkOpen = true;
        }

        public class Account
        {
            public string userId;
            public string userName;
            public string userPassword;
            public string userPhoneNum;
            public int userMileage;
            public DateTime purchaseDate;
            public string myTime;
            public bool isAdmin;

            public Account(string userid, string username, string userpassword, string userphonenumber)
            {
                userId = userid;
                userName = username;
                userPassword = userpassword;
                userPhoneNum = userphonenumber;
                userMileage = 0;
                purchaseDate = DateTime.Now;
                isAdmin = false;
            }
            public void printAccount(Account account)
            {
                Console.WriteLine($"회원 아이디:{account.userId}");
                Console.WriteLine($"회원 비밀번호:{account.userPassword}");
                Console.WriteLine($"회원 이름:{account.userName}");
                Console.WriteLine($"회원 핸드폰 번호:{account.userPhoneNum}");
                Console.WriteLine($"회원 마일리지:{account.userMileage}");
                Console.WriteLine($"회원 시간:{account.myTime}");
                Console.WriteLine($"어드민인 회원:{account.isAdmin}");
            }
        }
       
        
        private void SignUpButton_Click(object sender, EventArgs e)
        {
            // textbox 예외처리
            string textboxException = "";
            if (string.IsNullOrEmpty(idTextBox.Text))
            {
                textboxException = "아이디";
            }
            else if (string.IsNullOrEmpty(passwordTextBox.Text))
            {
                textboxException = "비밀번호";
            }
            else if (string.IsNullOrEmpty(nameTextBox.Text))
            {
                textboxException = "이름";
            }
            else if (string.IsNullOrEmpty(phonenumberTextBox.Text))
            {
                textboxException = "핸드폰 번호";
            }
            if (!string.IsNullOrEmpty(textboxException))
                MessageBox.Show(textboxException + " 를 다시 한번 확인해주세요.");

            Account newAccount = new Account(idTextBox.Text, nameTextBox.Text, passwordTextBox.Text, phonenumberTextBox.Text);
            newAccount.printAccount(newAccount);

            // 창 닫기
            this.Close();
        }
    }
}
/*
 
            // 
            // SignUpButton
            // 
            this.SignUpButton.Location = new System.Drawing.Point(231, 279);
            this.SignUpButton.Name = "SignUpButton";
            this.SignUpButton.Size = new System.Drawing.Size(85, 29);
            this.SignUpButton.TabIndex = 0;
            this.SignUpButton.Text = "가입하기";
            this.SignUpButton.UseVisualStyleBackColor = true;
            this.SignUpButton.Click += new System.EventHandler(this.SignUpButton_Click);
 
 */