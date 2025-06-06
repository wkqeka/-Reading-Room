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
    public partial class SeatInquiryUI : Form
    {
        private List<Seat> seats;

        public SeatInquiryUI()
        {
            InitializeComponent();
            LoadSeatsFromDatabase();
        }

        private void LoadSeatsFromDatabase()
        {
            try
            {
                seats = DatabaseManager.GetAllSeats();

                int buttonWidth = 150;
                int buttonHeight = 80;
                int marginX = 20;
                int marginY = 20;

                int startX = 30;
                int startY = 100; // ← 레이블 아래쪽으로 여백 줌

                int buttonsPerRow = 5;

                for (int i = 0; i < seats.Count; i++)
                {
                    Seat seat = seats[i];

                    Button btn = new Button();
                    btn.Tag = seat;
                    btn.Width = buttonWidth;
                    btn.Height = buttonHeight;

                    int row = i / buttonsPerRow;
                    int col = i % buttonsPerRow;

                    int x = startX + (buttonWidth + marginX) * col;
                    int y = startY + (buttonHeight + marginY) * row;

                    btn.Location = new Point(x, y);

                    // 상태 표시 및 색상
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
                    this.Controls.Add(btn);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("좌석 데이터를 불러오는 중 오류 발생:\n" + ex.Message);
            }
        }

        private void SeatButton_Click(object sender, EventArgs e)
        {
            var button = sender as Button;
            if (button?.Tag is Seat seat)
            {
                if (seat.Status == "사용 중")
                {
                    MessageBox.Show("해당 자리는 사용 중입니다. 다른 자리를 선택하세요.");
                    return;
                }
                else if (seat.Status == "예약 완료")
                {
                    MessageBox.Show($"해당 자리는 {seat.ReservedTime}에 예약되어 있습니다.");
                }

                var statusForm = new ShowStatus(seat);
                statusForm.ShowDialog();
            }
        }
        private void SeatInquiryUI_FormClosed(object sender, FormClosedEventArgs e)
        {
            new LoginUI().Show();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
