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
    public partial class SeatStatusForm : Form
    {
        private Seat seat;
        public SeatStatusForm(Seat selectedSeat)
        {
            InitializeComponent();
            seat = selectedSeat;
            LoadSeatInfo();
        }
        private void LoadSeatInfo()
        {
            lblSeatId.Text = $"ID: {seat.SeatId}";
            lblStatus.Text = $"상태: {seat.Status}";
            lblPurpose.Text = $"설명: {seat.Purpose}";
            lblReservedTime.Text = seat.Status == "예약 완료" ? $"예약 시간: {seat.ReservedTime}" : "";
        }
        private void btnReserve_Click(object sender, EventArgs e)
        {
            MessageBox.Show("예약창으로 이동합니다 (미구현)");
            this.Close();
        }

        private void btnPayment_Click(object sender, EventArgs e)
        {
            MessageBox.Show("결제창으로 이동합니다 (미구현)");
            this.Close();
        }
    }
}
