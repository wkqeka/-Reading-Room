using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Collections.Specialized.BitVector32;

namespace Studyroom_kiosk
{
    public partial class ShowStatus : Form
    {
        private string userId;
        private Seat seat;
        public bool IsSeatOccupied { get; set; } = false;

        public ShowStatus(string userId, Seat selectedSeat)
        {
            InitializeComponent();
            this.userId = userId;
            this.seat = selectedSeat;
        }

        private void LoadSeatInfo()
        {
            lblSeatId.Text = $"ID: {seat.SeatId}";
            lblStatus.Text = $"상태: {seat.Status}";
            lblPurpose.Text = $"유형: {seat.SeatType}";
            lblReservedTime.Text = seat.Status == "예약 완료" ? $"예약 시간: {seat.ReservedTime}" : "";
        }

        private void btnReserve_Click(object sender, EventArgs e)
        {
            MessageBox.Show("예약창으로 이동합니다 (미구현)");
            this.Close();
        }

        private void btnPayment_Click(object sender, EventArgs e)
        {
            var paymentForm = new PaymentUI(userId, seat);
            paymentForm.Show();
            this.Close();
        }

        private void ShowStatus_Load(object sender, EventArgs e)
        {
            LoadSeatInfo();

            if (IsSeatOccupied)
            {
                btnPayment.Enabled = false;  
                btnPayment.Text = "사용 중 (결제 불가)";
            }
        }
    }
}
