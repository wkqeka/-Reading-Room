using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Studyroom_kiosk.ControlClass;

namespace Studyroom_kiosk
{
    public partial class SeatInquiryUI : Form
    {
        private List<Seat> seats;
        private readonly SeatInquiryControl seatControl = new SeatInquiryControl();
        private string userId;

        public SeatInquiryUI(string userId) // userId 전달 받도록 수정
        {
            InitializeComponent();
            this.userId = userId;
            LoadSeatsFromControl();
        }

        private void LoadSeatsFromControl()
        {
            try
            {
                seats = seatControl.FetchAllSeats();
                GenerateSeatButtons(seats);
            }
            catch (Exception ex)
            {
                MessageBox.Show("좌석 데이터를 불러오는 중 오류 발생:\n" + ex.Message);
            }
        }

        // ✅ 새로고침 메서드 추가
        public void RefreshSeatStatus()
        {
            // 기존 버튼 제거
            foreach (Control control in this.Controls)
            {
                if (control is Button btn && btn.Tag is Seat)
                {
                    this.Controls.Remove(control);
                }
            }

            // 다시 불러오기
            LoadSeatsFromControl();
        }

        private void GenerateSeatButtons(List<Seat> seats)
        {
            int buttonWidth = 150;
            int buttonHeight = 80;
            int marginX = 20;
            int marginY = 20;
            int startX = 30;
            int startY = 100;
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
                btn.Location = new Point(startX + (buttonWidth + marginX) * col, startY + (buttonHeight + marginY) * row);

                btn.Text = $"좌석 {seat.SeatId}\n[{seat.Status}]";
                btn.BackColor = GetSeatColor(seat.Status);

                btn.Click += SeatButton_Click;
                this.Controls.Add(btn);
            }
        }

        private Color GetSeatColor(string status)
        {
            switch (status)
            {
                case "사용 중":
                    return Color.Gray;
                case "예약됨":
                    return Color.Khaki;
                case "사용가능":
                    return Color.LightGreen;
                default:
                    return SystemColors.Control;
            }
        }

        private void SeatButton_Click(object sender, EventArgs e)
        {
            var button = sender as Button;
            if (button?.Tag is Seat seat)
            {
                Console.WriteLine($"좌석 상태: {seat.Status}"); // 로그 확인용
                var statusForm = new ShowStatus(userId, seat);

                // 상태 전달을 위해 프로퍼티 추가 (아래 ShowStatus 수정 필요)
                if (seat.Status.Trim() == "사용중") // 공백 제거 + 정확한 비교
                {
                    MessageBox.Show("해당 자리는 현재 사용 중입니다. 결제는 불가능합니다.");
                    statusForm.IsSeatOccupied = true;
                }
                else if (seat.Status == "예약됨")
                {
                    MessageBox.Show("해당 자리는 예약된 상태입니다.");
                }
                statusForm.Owner = this;
                statusForm.ShowDialog(); // 예약 창을 모달로 띄움
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SeatInquiryUI_FormClosed(object sender, FormClosedEventArgs e)
        {
            new LoginUI().Show();
        }
    }
}