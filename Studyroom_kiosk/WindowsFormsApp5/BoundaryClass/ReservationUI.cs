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
using WindowsFormsApp5.ControlClass;
using WindowsFormsApp5.EntityClass;

namespace WindowsFormsApp5.BoundaryClass
{
    // ▶ [Boundary] ReservationUI: 예약 시작 시간 선택 UI
    public partial class ReservationUI : Form
    {
        private DateTime selectedStartTime;
        private int seatId;
        private string userId;

        // ▶ 생성자: 선택된 좌석과 사용자 ID를 전달받음
        public ReservationUI(int seatId, string userId)
        {
            InitializeComponent();
            this.seatId = seatId;
            this.userId = userId;
        }

        // ▶ 날짜 및 시간 선택 버튼 클릭 시
        private void btnSelectDateTime_Click(object sender, EventArgs e)
        {
            using (Form dateTimeForm = new Form())
            {
                var picker = new DateTimePicker
                {
                    Format = DateTimePickerFormat.Custom,
                    CustomFormat = "yyyy-MM-dd HH:mm",
                    Width = 200
                };

                var btnOk = new Button { Text = "확인", DialogResult = DialogResult.OK, Left = 220 };
                dateTimeForm.Text = "날짜 및 시간 선택";
                dateTimeForm.Controls.Add(picker);
                dateTimeForm.Controls.Add(btnOk);
                dateTimeForm.AcceptButton = btnOk;

                if (dateTimeForm.ShowDialog() == DialogResult.OK)
                {
                    selectedStartTime = picker.Value;
                    lblDateTimeSelected.Text = $"선택한 시간: {selectedStartTime:yyyy-MM-dd HH:mm}";
                }
            }
        }

        // ▶ 계속 버튼 클릭 → 결제 창으로 이동
        private void btnContinue_Click(object sender, EventArgs e)
        {
            if (selectedStartTime == default)
            {
                MessageBox.Show("예약할 날짜와 시간을 선택해주세요.");
                return;
            }

            // ▶ [Entity] Reservation 객체 생성
            var reservation = new Reservation
            {
                AccountId = userId,
                SeatId = seatId,
                PlanId = 0, // ▶ 요금제는 결제 창에서 선택 예정
                StartTime = selectedStartTime,
                ReservationTime = DateTime.Now,
                Status = "reserved"
            };

            // ▶ [Boundary] 결제 창 호출 (예약 기반)
            PaymentUI paymentForm = new PaymentUI(reservation);
            paymentForm.ShowDialog();
            this.Hide(); // 예약 UI는 숨김 처리
        }

        // ▶ 뒤로가기 버튼 클릭
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
