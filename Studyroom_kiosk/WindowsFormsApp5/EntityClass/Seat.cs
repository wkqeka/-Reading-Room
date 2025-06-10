using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Studyroom_kiosk
{
    // ▶ [Entity 클래스] Seat
    // 좌석의 고유 정보와 상태를 저장하는 클래스
    public class Seat
    {
        // ▶ 좌석 고유 ID
        public int SeatId { get; set; }

        // ▶ 좌석 번호 (UI 표시용 문자열)
        public string SeatNumber { get; set; }

        // ▶ 현재 좌석 상태 (사용가능 / 예약됨 / 사용중)
        public string Status { get; set; }

        // ▶ 좌석 유형 (예: 1인실, 2인실 등)
        public string SeatType { get; set; }

        // ▶ 예약 시간 정보 (UI에서 표시용)
        public string ReservedTime { get; set; } = "없음";

        // ▶ 생성자: 좌석 정보 초기화
        public Seat(int seatId, string seatNumber, string status, string seatType)
        {
            SeatId = seatId;
            SeatNumber = seatNumber;
            Status = status;
            SeatType = seatType;
        }
    }
}
