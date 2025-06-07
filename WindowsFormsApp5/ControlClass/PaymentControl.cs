using Studyroom_kiosk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Studyroom_kiosk
{
    public class PaymentControl
    {
        public bool ProcessCardPurchase(string userId, int seatId, int planId, DateTime startTime, DateTime endTime, int mileageUsed, decimal planPrice)
        {
            try
            {
                // 최종 결제 금액 계산
                decimal finalPrice = CalculateMileage.CalculateFinalPrice(planPrice, mileageUsed);

                // DB에 예약 및 결제 정보 저장
                bool success = DatabaseManager.ExecuteReserveAndPayProcedure(userId, seatId, planId, startTime, endTime, mileageUsed);

                return success;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ERROR] 카드 결제 실패: {ex.Message}");
                return false;
            }
        }
    }
}
