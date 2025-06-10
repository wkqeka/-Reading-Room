using Studyroom_kiosk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp5.EntityClass;

namespace Studyroom_kiosk
{
    // ▶ [Control 클래스] PaymentControl
    // 결제 및 예약 결제 로직을 처리하는 제어 클래스
    public class PaymentControl
    {
        // ▶ 일반 결제 처리 메서드
        // [Boundary] PaymentCheckUI → btnPay_Click에서 호출
        public bool ProcessCardPurchase(string userId, int seatId, int planId, DateTime startTime, DateTime endTime, int mileageUsed, decimal planPrice)
        {
            try
            {
                // ▶ 최종 결제 금액 계산 (마일리지 적용)
                decimal finalPrice = CalculateMileage.CalculateFinalPrice(planPrice, mileageUsed);

                // ▶ 결제 및 예약 프로시저 호출
                bool success = DatabaseManager.ExecuteReserveAndPayProcedure(userId, seatId, planId, startTime, endTime, mileageUsed);

                return success;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ERROR] 카드 결제 실패: {ex.Message}");
                return false;
            }
        }

        // ▶ 예약 기반 결제 처리 메서드
        // [Boundary] PaymentCheckUI → btnPay_Click에서 호출
        public bool ProcessReservationPayment(Reservation reservation, int mileageUsed, decimal planPrice)
        {
            return DatabaseManager.ExecuteReserveAndPayProcedure(
                reservation.AccountId.ToString(),
                reservation.SeatId,
                reservation.PlanId,
                reservation.StartTime,
                reservation.EndTime,
                mileageUsed
            );
        }
    }
}
