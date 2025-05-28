using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Seats : Form
    {
        private List<Seat> seats;

        public Seats()
        {
            InitializeComponent();
            InitializeSeats();
            BindSeatsToButtons(); // Seat 정보 → 버튼 연결
        }
        private void InitializeSeats()
        {
            // 임의의 자리 2개
            seats = new List<Seat>
        {
            new Seat("A1", "사용 가능", "창가 자리"),
            new Seat("A2", "예약 완료", "중앙 자리", "오후 2시 ~ 4시"),
            new Seat("A3", "사용 중", "복도 자리")
        };
        }

        private void BindSeatsToButtons()
        {
            SetupButton(btnSeat1, seats[0]);
            SetupButton(btnSeat2, seats[1]);
            SetupButton(btnSeat3, seats[2]);
        }
        private void SetupButton(Button btn, Seat seat)
        {
            btn.Tag = seat;

            // 버튼 텍스트와 색상 설정
            if (seat.Status == "사용 중")
            {
                btn.Text = "사용 중";
                btn.BackColor = Color.Gray;
            }
            else if (seat.Status == "예약 완료")
            {
                btn.Text = "사용 가능(예약됨)";
                btn.BackColor = Color.LightYellow;
            }
            else
            {
                btn.Text = "사용 가능";
                btn.BackColor = Color.LightGreen;
            }

            btn.Click += SeatButton_Click;
        }

        private void SeatButton_Click(object sender, EventArgs e)
        {
            var button = sender as Button;
            if (button?.Tag is Seat seat)
            {
                if (seat.Status == "사용 중")
                {
                    MessageBox.Show("해당 자리는 사용 중입니다. 다른 자리를 선택하세요.");
                    return; // SeatStatusForm 열지 않음
                }
                else if (seat.Status == "예약 완료")
                {
                    MessageBox.Show($"해당 자리는 {seat.ReservedTime}에 예약되어 있습니다.");
                    // 진행은 계속함
                }

                var statusForm = new SeatStatusForm(seat);
                statusForm.ShowDialog();
            }
        }
    }
}
