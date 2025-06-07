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

namespace Studyroom_kiosk
{
    public partial class PaymentCheckUI : Form
    {
        private PricingPlan selectedPlan;
        private string userId;
        private int seatId;
        private decimal userMileage;
        private decimal usedMileage = 0;
        private decimal finalPrice = 0;

        public PaymentCheckUI(string userId,int seatId, PricingPlan plan)
        {
            InitializeComponent();
            this.userId = userId;
            this.seatId = seatId;
            this.selectedPlan = plan;
        }

        private void btnApplyMileage_Click(object sender, EventArgs e)
        {
            usedMileage = Convert.ToDecimal(cbMileageUse.SelectedItem);
            UpdatePriceInfo();
        }

        private void UpdatePriceInfo()
        {
            finalPrice = selectedPlan.Price - usedMileage;
            decimal reward = Math.Floor(finalPrice * 0.05m);

            lblFinalPrice.Text = $"{finalPrice:N0} 원";
            lblRewardMileage.Text = $"{reward:N0} 원";
        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            bool result = new PaymentControl().ProcessCardPurchase(
                userId, seatId, selectedPlan.PlanId,
                DateTime.Now, DateTime.Now.AddMinutes(selectedPlan.DurationMin),
                (int)usedMileage, selectedPlan.Price
            );

            if (result)
            {
                MessageBox.Show($"결제 완료!\n좌석: {seatId}\n시간: {selectedPlan.DurationMin}분");
                this.Owner?.Close(); // PaymentUI
                this.Close();        // PaymentCheckUI

                foreach (Form form in Application.OpenForms)
                {
                    if (form is SeatInquiryUI seatForm)
                    {
                        seatForm.Show();
                        seatForm.RefreshSeatStatus();
                        break;
                    }
                }
            }
            else
            {
                MessageBox.Show("결제 실패");
            }
        }

        private void PaymentCheckUI_Load(object sender, EventArgs e)
        {
            // 유저 마일리지 조회
            userMileage = DatabaseManager.GetUserMileage(userId);
            lblAvailableMileage.Text = $"{userMileage:N0} 원";

            // 콤보박스 초기화 (1000 단위 최대 만원까지)
            cbMileageUse.Items.Clear();
            for (int i = 0; i <= 10000; i += 1000)
            {
                if (i <= userMileage && i <= selectedPlan.Price)
                {
                    cbMileageUse.Items.Add(i.ToString());
                }
            }

            cbMileageUse.SelectedIndex = 0;
            lblSeat.Text = $"좌석 번호: {seatId}";
            lblPlan.Text = $"요금제: {selectedPlan.Name}";
            lblPlanPrice.Text = $"{selectedPlan.Price:N0} 원";
            UpdatePriceInfo();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Owner?.Show(); // 부모 폼 복원
        }
    }
}
