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
    // ▶ [Boundary] PaymentUI: 결제 요금제 선택 창
    public partial class PaymentUI : Form
    {
        private List<PricingPlan> plans;          // ▶ [Entity] 요금제 목록
        private Reservation reservation;          // ▶ [Entity] 예약 정보 객체
        private PricingPlan SelectedPlan;         // ▶ [Entity] 선택된 요금제
        private string userId;
        private Seat selectedSeat;                // ▶ [Entity] 선택된 좌석 정보
        private bool isReservationMode;

        // ▶ 예약 결제용 생성자
        public PaymentUI(Reservation reservation)
        {
            InitializeComponent();
            this.reservation = reservation;
            this.isReservationMode = true;
        }

        // ▶ 일반 결제용 생성자
        public PaymentUI(string userId, Seat selectedSeat)
        {
            InitializeComponent();
            this.userId = userId;
            this.selectedSeat = selectedSeat;
            this.isReservationMode = false;
        }

        // ▶ 폼 로드시 요금제 로드 or 결제 확인으로 진행
        private void PaymentUI_Load(object sender, EventArgs e)
        {
            if (!isReservationMode)
            {
                LoadPricingPlans();  // ▶ [Control → Entity] 일반 결제: 요금제 버튼 로드
            }
            else
            {
                if (reservation.PlanId == 0)
                    LoadPricingPlans();  // ▶ 예약: 요금제 미지정 → 요금제 선택
                else
                    ProceedWithReservationPayment(); // ▶ 요금제 지정됨 → 결제 확인창 바로 호출
            }
        }

        // ▶ 요금제 버튼 UI 생성
        private void LoadPricingPlans()
        {
            plans = DatabaseManager.GetPricingPlans();  // ▶ [Control → Entity] 요금제 조회

            if (plans == null || plans.Count == 0)
            {
                MessageBox.Show("요금제를 불러올 수 없습니다.");
                return;
            }

            foreach (PricingPlan plan in plans)
            {
                Button btn = new Button();
                btn.Text = $"{plan.Name}\n{plan.Price:N0}원";
                btn.Tag = plan;
                btn.Size = new Size(190, 100);
                btn.Margin = new Padding(10);
                btn.Click += PlanButton_Click;           // ▶ 요금제 버튼 클릭 → 결제 확인 창 호출
                flowLayoutPanelPlans.Controls.Add(btn);
            }
        }

        // ▶ 요금제 선택 후 결제 확인 창 호출
        private void PlanButton_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn?.Tag is PricingPlan selectedPlan)
            {
                this.SelectedPlan = selectedPlan;

                if (reservation != null)
                {
                    // ▶ 예약 결제 경로: 요금제 설정 후 확인 창 호출
                    reservation.PlanId = selectedPlan.PlanId;
                    reservation.EndTime = reservation.StartTime.AddMinutes(selectedPlan.DurationMin);

                    var paymentCheck = new PaymentCheckUI(reservation);
                    paymentCheck.ShowDialog(this);  // ▶ [Boundary] 결제 확인 창 (예약)
                    this.Close();
                }
                else if (userId != null && selectedSeat != null)
                {
                    // ▶ 일반 결제 경로
                    var paymentCheck = new PaymentCheckUI(userId, selectedSeat.SeatId, selectedPlan);
                    paymentCheck.ShowDialog(this);  // ▶ [Boundary] 결제 확인 창 (일반)
                    this.Close();
                }
            }
        }

        // ▶ 예약 결제 플로우 (요금제가 이미 있는 경우)
        private void ProceedWithReservationPayment()
        {
            var paymentCheck = new PaymentCheckUI(reservation);
            paymentCheck.ShowDialog();  // ▶ [Boundary] 결제 확인 창 호출
        }

        // ▶ 취소 버튼 클릭
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Owner?.Show(); // ▶ 이전 창 재표시
        }
    }
}
