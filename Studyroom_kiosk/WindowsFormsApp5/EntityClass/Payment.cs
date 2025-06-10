using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Studyroom_kiosk
{
    // ▶ [Entity 클래스] Payment
    // 결제 내역 정보를 담는 객체 (예약과 사용자, 마일리지 및 결제 시간 포함)
    public class Payment
    {
        // ▶ 결제 ID (PK 역할)
        public int PaymentId { get; set; }

        // ▶ 사용자 ID (참조: USERS.user_id)
        public int UserId { get; set; }

        // ▶ 예약 ID (참조: RESERVATIONS.reservation_id)
        public int ReservationId { get; set; }

        // ▶ 총 결제 금액 (마일리지 적용 후)
        public decimal TotalAmount { get; set; }

        // ▶ 사용한 마일리지
        public int MileageUsed { get; set; }

        // ▶ 결제 상태 (ex. 완료, 취소 등)
        public string Status { get; set; }

        // ▶ 결제 시간
        public DateTime PaymentTime { get; set; }
    }
}
