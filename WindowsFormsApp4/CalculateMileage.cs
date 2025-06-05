// CalculateMileage.cs
using System;
namespace WindowsFormsApp4
{
    public class CalculateMileage
    {
        // 적립될 마일리지 계산
        // purchasePrice: 구매 금액
        // rewardRate: 적립률 (예: 0.1m은 10%)
        public decimal CalculateRewardMileage(decimal purchasePrice, decimal rewardRate)
        {
            if (purchasePrice < 0 || rewardRate < 0)
            {
                return 0; // 음수 값에 대해서는 0 반환 또는 예외 처리
            }
            return Math.Floor(purchasePrice * rewardRate); // 소수점 이하 버림 (정책에 따라 다를 수 있음)
        }

        // (선택 사항) 마일리지 사용 등을 고려한 최종 결제 금액 계산
        // 이 기능은 클래스 다이어그램의 PaymentCheckUI에 finalPrice와 useMileage 속성이 있는 것으로 보아 필요할 수 있음
        public decimal CalculateFinalPrice(decimal originalPrice, decimal mileageToUse, decimal currentMileageBalance)
        {
            if (originalPrice < 0 || mileageToUse < 0)
            {
                // 적절한 오류 처리
                return originalPrice;
            }

            decimal actualMileageUsed = 0;
            if (mileageToUse > 0)
            {
                // 사용하려는 마일리지가 보유 마일리지보다 많으면, 보유 마일리지만큼만 사용
                actualMileageUsed = Math.Min(mileageToUse, currentMileageBalance);
                // 사용하려는 마일리지가 상품 가격보다 크면, 상품 가격만큼만 마일리지 사용 (마일리지로 전액 결제 가능 시)
                actualMileageUsed = Math.Min(actualMileageUsed, originalPrice);
            }

            return originalPrice - actualMileageUsed;
        }
    }
}