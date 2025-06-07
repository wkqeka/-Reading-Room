using Studyroom_kiosk;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp5.EntityClass;

namespace Studyroom_kiosk
{
    // ▶ [Boundary] PaymentCheckUI: 결제 확인 화면 (일반 결제 및 예약 결제 UI)
    public partial class PaymentCheckUI : Form
    {
        private PricingPlan selectedPlan;   // ▶ [Entity] PricingPlan: 요금제 정보 객체
        private string userId;
        private int seatId;
        private decimal userMileage;
        private decimal usedMileage = 0;
        private decimal finalPrice = 0;

        private bool isReservationMode;
        private Reservation reservation;    // ▶ [Entity] Reservation: 예약 정보 객체

        // ▶ 일반 결제용 생성자
        public PaymentCheckUI(string userId, int seatId, PricingPlan plan)
        {
            InitializeComponent();
            this.userId = userId;
            this.seatId = seatId;
            this.selectedPlan = plan;
            this.isReservationMode = false;
        }

        // ▶ 예약 결제용 생성자
        public PaymentCheckUI(Reservation reservation)
        {
            InitializeComponent();
            this.reservation = reservation;
            this.userId = reservation.AccountId.ToString();
            this.seatId = reservation.SeatId;
            this.selectedPlan = DatabaseManager.GetPricingPlanById(reservation.PlanId); // ▶ [Control → Entity] 요금제 조회
            this.isReservationMode = true;
        }

        // ▶ 폼 로드시 사용자 마일리지 조회, 요금제 정보 표시
        private void PaymentCheckUI_Load(object sender, EventArgs e)
        {
            userMileage = DatabaseManager.GetUserMileage(userId);    // ▶ [Control → Entity] 사용자 마일리지 조회
            lblAvailableMileage.Text = $"{userMileage:N0} 원";

            cbMileageUse.Items.Clear();
            for (int i = 0; i <= 10000; i += 1000)
            {
                if (i <= userMileage && i <= selectedPlan.Price)
                    cbMileageUse.Items.Add(i.ToString());
            }

            cbMileageUse.SelectedIndex = 0;

            lblSeat.Text = $"좌석 번호: {seatId}";
            lblPlan.Text = $"요금제: {selectedPlan.Name}";
            lblPlanPrice.Text = $"{selectedPlan.Price:N0} 원";

            if (isReservationMode && reservation != null)
            {
                DateTime start = reservation.StartTime;
                DateTime end = start.AddMinutes(selectedPlan.DurationMin);
                lblReservationTimeInfo.Text = $"예약 시간: {start:yyyy-MM-dd HH:mm} ~ {end:HH:mm}";
            }
            else
            {
                lblReservationTimeInfo.Text = ""; // 일반 결제는 비움
            }

            UpdatePriceInfo(); // ▶ 가격 및 예상 마일리지 계산
        }

        // ▶ 마일리지 적용 버튼 클릭
        private void btnApplyMileage_Click(object sender, EventArgs e)
        {
            usedMileage = Convert.ToDecimal(cbMileageUse.SelectedItem);
            UpdatePriceInfo();
        }

        // ▶ 결제금액 및 적립 마일리지 계산
        private void UpdatePriceInfo()
        {
            finalPrice = selectedPlan.Price - usedMileage;
            decimal reward = Math.Floor(finalPrice * 0.05m);
            lblFinalPrice.Text = $"{finalPrice:N0} 원";
            lblRewardMileage.Text = $"{reward:N0} 원";
        }

        // ▶ 결제 버튼 클릭 처리
        private void btnPay_Click(object sender, EventArgs e)
        {
            bool result;

            // ▶ [Control] PaymentControl: 예약 결제 or 일반 결제 로직 실행
            if (isReservationMode)
            {
                result = new PaymentControl().ProcessReservationPayment(
                    reservation,
                    (int)usedMileage,
                    selectedPlan.Price
                );
            }
            else
            {
                result = new PaymentControl().ProcessCardPurchase(
                    userId, seatId, selectedPlan.PlanId,
                    DateTime.Now, DateTime.Now.AddMinutes(selectedPlan.DurationMin),
                    (int)usedMileage, selectedPlan.Price
                );
            }

            // ▶ 결제 성공 시 처리
            if (result)
            {
                MessageBox.Show("결제 완료!");

                // ▶ [Boundary] SeatInquiryUI의 좌석 정보 갱신
                foreach (Form form in Application.OpenForms)
                {
                    if (form is SeatInquiryUI seatForm)
                    {
                        seatForm.RefreshSeatStatus();    // ▶ 좌석 새로고침
                        seatForm.BringToFront();         // ▶ 포커스 재지정
                        break;
                    }
                }

                this.Close();         // ▶ 현재 결제확인창 닫기
                this.Owner?.Close(); // ▶ 이전 PaymentUI 창도 닫기
            }
            else
            {
                MessageBox.Show("결제 실패");
            }
        }

        // ▶ 취소 버튼 클릭 시
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Owner?.Show(); // ▶ 이전 창 재표시
        }
    }
}
