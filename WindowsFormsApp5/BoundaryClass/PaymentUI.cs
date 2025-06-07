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
    public partial class PaymentUI : Form
    {
        private List<PricingPlan> plans; // 요금제 목록
        public PricingPlan SelectedPlan { get; private set; }

        private string userId;
        private Seat selectedSeat;

        public PaymentUI(string userId, Seat selectedSeat)
        {
            InitializeComponent();
            this.userId = userId;
            this.selectedSeat = selectedSeat;
        }

        private void PaymentUI_Load(object sender, EventArgs e)
        {
            LoadPricingPlans();
        }

        private void LoadPricingPlans()
        {
            plans = DatabaseManager.GetPricingPlans(); 

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
                btn.Click += PlanButton_Click;
                flowLayoutPanelPlans.Controls.Add(btn); 
            }
        }

        private void PlanButton_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn?.Tag is PricingPlan selectedPlan)
            {
                // PaymentCheckUI로 좌석, 유저 정보 전달
                var paymentCheck = new PaymentCheckUI(userId, selectedSeat.SeatId, selectedPlan);
                paymentCheck.ShowDialog();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Owner?.Show(); // 부모 폼 복원
        }
    }
}
