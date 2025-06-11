using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Studyroom_kiosk
{
    // ▶ [Control 클래스] CalculateMileage
    // ▶ 결제 금액에서 마일리지 차감 및 적립 마일리지를 계산하는 기능을 제공
    public static class CalculateMileage
    {
        // ▶ 최종 결제 금액 계산 메서드
        // ▶ 사용처: PaymentControl에서 결제 요청 시 호출
        public static decimal CalculateFinalPrice(decimal price, decimal mileage)
        {
            return price - mileage;
        }

        // ▶ 적립 마일리지 계산 메서드 (5% 적립)
        // ▶ 사용처: PaymentCheckUI 등에서 예상 적립 마일리지 표시용
        public static decimal CalculateReward(decimal price)
        {
            return Math.Floor(price * 0.05m);
        }
    }
}
