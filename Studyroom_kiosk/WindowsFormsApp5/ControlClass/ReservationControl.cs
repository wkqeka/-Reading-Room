using Studyroom_kiosk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp5.EntityClass;

namespace WindowsFormsApp5.ControlClass
{
    // ▶ [Control 클래스] ReservationControl
    // 좌석 예약 가능 여부 확인 및 예약 생성 기능을 담당하는 제어 클래스
    public class ReservationControl
    {
        // ▶ 예약 가능 여부 확인 메서드
        // [Boundary] ReservationUI 등에서 사용됨
        public bool IsSeatAvailable(int seatId, DateTime startTime, DateTime endTime)
        {
            List<Reservation> existingReservations = DatabaseManager.GetReservationsBySeat(seatId);

            foreach (var reservation in existingReservations)
            {
                if (reservation.Status == "reserved")
                {
                    // ▶ 기존 예약과 시간 겹치는지 확인
                    bool overlap = !(endTime <= reservation.StartTime || startTime >= reservation.EndTime);
                    if (overlap)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        // ▶ 예약 생성 메서드
        // [Boundary] ReservationUI에서 예약 요청 시 호출됨
        public bool MakeReservation(Reservation reservation)
        {
            if (!IsSeatAvailable(reservation.SeatId, reservation.StartTime, reservation.EndTime))
            {
                return false;
            }

            reservation.ReservationTime = DateTime.Now;
            reservation.Status = "reserved";

            return DatabaseManager.InsertReservation(reservation);
        }
    }
}
