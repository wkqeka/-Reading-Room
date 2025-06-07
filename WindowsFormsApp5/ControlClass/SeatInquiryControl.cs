using Studyroom_kiosk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp5.EntityClass;

namespace Studyroom_kiosk.ControlClass
{
    // ▶ [Control 클래스] SeatInquiryControl
    // 좌석 상태 조회 및 예약 정보 조회를 담당하는 제어 클래스
    public class SeatInquiryControl
    {
        // ▶ 좌석 상태 및 예약 상태를 포함하여 전체 좌석 목록을 반환
        // [Boundary] SeatInquiryUI에서 호출됨
        public List<Seat> FetchAllSeats()
        {
            try
            {
                return DatabaseManager.GetAllSeatsWithReservationStatus();
            }
            catch (Exception ex)
            {
                throw new Exception("좌석 상태를 불러오는 중 오류 발생: " + ex.Message);
            }
        }

        // ▶ 사용 중이거나 예약된 좌석에 대한 모든 예약 정보를 반환
        // [Boundary] SeatInquiryUI에서 호출됨
        public List<Reservation> FetchAllActiveReservations()
        {
            return DatabaseManager.GetAllActiveReservations();
        }
    }
}
