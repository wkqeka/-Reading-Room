using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp5.EntityClass
{
    // ▶ [Entity 클래스] Reservation
    // 좌석 예약 정보를 저장하는 클래스
    public class Reservation
    {
        // ▶ 예약 ID (PK 역할)
        public int ReservationId { get; set; }

        // ▶ 예약자 ID (사용자 계정)
        public string AccountId { get; set; }

        // ▶ 예약한 좌석 ID
        public int SeatId { get; set; }

        // ▶ 선택한 요금제 ID
        public int PlanId { get; set; }

        // ▶ 예약 등록 시각
        public DateTime ReservationTime { get; set; }

        // ▶ 이용 시작 시각
        public DateTime StartTime { get; set; }

        // ▶ 이용 종료 시각
        public DateTime EndTime { get; set; }

        // ▶ 예약 상태 (reserved / cancelled / completed)
        public string Status { get; set; }
    }
}
