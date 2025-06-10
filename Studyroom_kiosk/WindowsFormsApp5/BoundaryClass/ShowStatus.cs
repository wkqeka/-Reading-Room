using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// ▶ 다른 Boundary 클래스 및 Entity 클래스 참조
using WindowsFormsApp5.BoundaryClass;
using WindowsFormsApp5.EntityClass;

namespace Studyroom_kiosk
{
    // ▶ [Boundary] ShowStatus: 좌석의 현재 상태(예약/사용중/결제 가능 여부)를 사용자에게 표시하는 UI
    public partial class ShowStatus : Form
    {
        // ▶ 외부로부터 전달되는 좌석 상태 플래그 및 정보 (Control로부터 받은 데이터 기반)
        public bool IsSeatReserved { get; set; } = false;
        public bool IsSeatOccupied { get; set; } = false;

        // ▶ [Entity] 예약 정보 객체 (해당 좌석의 예약 세부사항)
        public Reservation ReservationInfo { get; set; }

        // ▶ [Entity] 현재 사용중이라면 종료 시간
        public DateTime? SeatEndTime { get; set; }

        private string userId;

        // ▶ [Entity] 좌석 정보 객체
        private Seat seat;

        // ▶ 생성자: 좌석 상태 정보를 받아 초기화
        public ShowStatus(string userId, Seat selectedSeat)
        {
            InitializeComponent();
            this.userId = userId;
            this.seat = selectedSeat;
        }

        // ▶ 폼 로드 시 좌석 상태에 따라 UI 동작 결정
        private void ShowStatus_Load(object sender, EventArgs e)
        {
            lblSeatId.Text = $"ID: {seat.SeatId}";
            lblStatus.Text = $"상태: {seat.Status}";
            lblPurpose.Text = $"유형: {seat.SeatType}";

            if (IsSeatOccupied)
            {
                // ▶ 사용 중일 경우 결제 버튼 비활성화
                btnPayment.Enabled = false;
                btnPayment.Text = "사용 중 (결제 불가)";
                lblReservedTime.Text = SeatEndTime != null
                    ? $"사용 종료 시간: {SeatEndTime:yyyy-MM-dd HH:mm}"
                    : "종료 시간 없음";
            }
            else if (IsSeatReserved && ReservationInfo != null)
            {
                // ▶ 예약 상태일 경우 결제 가능
                btnPayment.Enabled = true;
                btnPayment.Text = "결제";
                lblReservedTime.Text = $"예약 시간: {ReservationInfo.StartTime:yyyy-MM-dd HH:mm} ~ {ReservationInfo.EndTime:HH:mm}";
            }
            else
            {
                // ▶ 사용 가능 상태
                btnPayment.Enabled = true;
                btnPayment.Text = "결제";
                lblReservedTime.Text = "결제 가능한 자리입니다.";
            }
        }

        // ▶ 예약 버튼 클릭 시 ReservationUI 호출
        private void btnReserve_Click(object sender, EventArgs e)
        {
            var reserveForm = new ReservationUI(seat.SeatId, userId);
            reserveForm.ShowDialog();   // ▶ [Boundary] Reservation UI 실행
            this.Close();               // ▶ 현재 상태창 종료
        }

        // ▶ 결제 버튼 클릭 시 PaymentUI 호출
        private void btnPayment_Click(object sender, EventArgs e)
        {
            var paymentForm = new PaymentUI(userId, seat);
            paymentForm.ShowDialog();  // ▶ [Boundary] 결제창 실행
            this.Close();              // ▶ 현재 상태창 종료
        }
    }
}
