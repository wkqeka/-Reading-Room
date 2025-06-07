using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// ▶ Control 클래스 참조
using Studyroom_kiosk.ControlClass;

namespace Studyroom_kiosk
{
    // ▶ [Boundary] SeatInquiryUI: 좌석 현황을 사용자에게 표시하고 선택 처리하는 UI
    public partial class SeatInquiryUI : Form
    {
        private List<Seat> seats;

        // ▶ [Control] 좌석 데이터 제어 객체 (Entity를 불러오기 위한 Control 클래스)
        private readonly SeatInquiryControl seatControl = new SeatInquiryControl();
        private string userId;

        public SeatInquiryUI(string userId)
        {
            InitializeComponent();
            this.userId = userId;

            // ▶ 좌석 상태 초기 로딩
            LoadSeatsFromControl();
        }

        // ▶ [Control 사용] 좌석 정보를 제어 클래스로부터 받아서 버튼 생성
        private void LoadSeatsFromControl()
        {
            try
            {
                seats = seatControl.FetchAllSeats(); // ▶ [Entity] Seat 리스트 반환
                GenerateSeatButtons(seats);
            }
            catch (Exception ex)
            {
                MessageBox.Show("좌석 데이터를 불러오는 중 오류 발생:\n" + ex.Message);
            }
        }

        // ▶ [갱신 로직] 좌석 정보가 바뀐 후 호출되며, 버튼을 전부 제거하고 새로 그림
        public void RefreshSeatStatus()
        {
            var seatButtons = this.Controls
                .OfType<Button>()
                .Where(btn => btn.Tag is Seat)
                .ToList();

            foreach (var btn in seatButtons)
            {
                this.Controls.Remove(btn);
            }

            LoadSeatsFromControl(); // 재로딩
        }

        // ▶ [Boundary] 좌석 버튼 생성 및 배치
        private void GenerateSeatButtons(List<Seat> seats)
        {
            int buttonWidth = 150;
            int buttonHeight = 80;
            int marginX = 20;
            int marginY = 20;
            int startX = 30;
            int startY = 100;
            int buttonsPerRow = 5;

            foreach (Seat seat in seats)
            {
                Button btn = new Button
                {
                    Tag = seat, // ▶ [Entity] Seat 객체를 Tag에 저장
                    Width = buttonWidth,
                    Height = buttonHeight,
                    Text = $"좌석 {seat.SeatId}\n[{seat.Status}]",
                    BackColor = GetSeatColor(seat.Status)
                };

                int index = seats.IndexOf(seat);
                int row = index / buttonsPerRow;
                int col = index % buttonsPerRow;
                btn.Location = new Point(startX + (buttonWidth + marginX) * col, startY + (buttonHeight + marginY) * row);

                btn.Click += SeatButton_Click;
                this.Controls.Add(btn);
            }
        }

        // ▶ 상태별 색상 반환
        private Color GetSeatColor(string status)
        {
            switch (status)
            {
                case "사용 중": return Color.Gray;
                case "예약됨": return Color.Khaki;
                case "사용가능": return Color.LightGreen;
                default: return SystemColors.Control;
            }
        }

        // ▶ [Boundary] 좌석 버튼 클릭 시 이벤트 처리
        private void SeatButton_Click(object sender, EventArgs e)
        {
            var button = sender as Button;
            if (button == null || !(button.Tag is Seat)) return;

            var seat = (Seat)button.Tag;
            var now = DateTime.Now;

            // ▶ [Control 호출] 예약 정보 조회
            var reservations = seatControl.FetchAllActiveReservations()
                                          .Where(r => r.SeatId == seat.SeatId)
                                          .ToList();

            // ▶ [Boundary] 상태 창 UI 호출
            var statusForm = new ShowStatus(userId, seat);

            // ▶ [Entity] 현재 사용 중 상태인지 확인
            var currentUse = reservations.FirstOrDefault(r =>
                r.Status == "사용중" && r.StartTime <= now && r.EndTime > now);

            // ▶ [Entity] 예약된 상태인지 확인
            var upcomingReservation = reservations.FirstOrDefault(r =>
                r.Status == "예약됨" && r.StartTime > now);

            if (currentUse != null)
            {
                MessageBox.Show("해당 자리는 현재 사용중인 자리입니다.");
                statusForm.IsSeatOccupied = true;
                statusForm.SeatEndTime = currentUse.EndTime;
            }
            else if (upcomingReservation != null)
            {
                MessageBox.Show("해당 자리는 예약된 상태입니다.");
                statusForm.IsSeatReserved = true;
                statusForm.ReservationInfo = upcomingReservation;
            }

            statusForm.Owner = this;
            statusForm.ShowDialog(); // ▶ 상태창 모달 호출
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // ▶ 폼 종료 시 → 로그인 창으로 복귀
        private void SeatInquiryUI_FormClosed(object sender, FormClosedEventArgs e)
        {
            new LoginUI().Show();
        }
    }
}
