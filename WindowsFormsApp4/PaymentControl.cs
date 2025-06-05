// PaymentControl.cs
using System;

namespace WindowsFormsApp4
{
    public class PaymentControl
    {
        private DatabaseManager dbManager;
        private UserInfo userInfo; // 마일리지 적립/사용 등에 필요

        public PaymentControl(DatabaseManager dbMgr, UserInfo uInfo)
        {
            this.dbManager = dbMgr ?? throw new ArgumentNullException(nameof(dbMgr));
            this.userInfo = uInfo ?? throw new ArgumentNullException(nameof(uInfo));
        }

        // 공통 결제 처리 로직 (내부에서만 사용)
        private bool ProcessPaymentInternal(int userId, int seatId, int planId, DateTime startTime, DateTime endTime, int mileageUsed, decimal planPrice, string paymentMethodName)
        {
            try
            {
                // 1. (중요) 실제 외부 결제 게이트웨이 연동 로직 (PG사 API 호출 등)
                //    이 부분은 각 결제 수단(카드, 카카오페이, 네이버페이)에 따라 다를 것이며, 여기서는 성공했다고 가정합니다.
                //    bool externalPaymentSuccess = CallExternalPaymentGateway(planPrice - mileageUsed, paymentMethodName, /*결제정보*/);
                //    if (!externalPaymentSuccess)
                //    {
                //        Console.WriteLine($"{paymentMethodName} 외부 결제 실패");
                //        return false;
                //    }

                Console.WriteLine($"{paymentMethodName} 외부 결제 성공 (시뮬레이션).");

                // 2. 우리 시스템에 예약 및 결제 정보 기록 (DB 프로시저 호출)
                bool dbSuccess = dbManager.ExecuteReserveAndPayProcedure(userId, seatId, planId, startTime, endTime, mileageUsed);

                if (dbSuccess)
                {
                    // 3. (선택 사항) 마일리지 적립 (결제 프로시저에서 자동 적립 안 할 경우)
                    // CalculateMileage mileageCalculator = new CalculateMileage(); // 필요시 인스턴스 생성 또는 주입
                    // decimal rewardMileage = mileageCalculator.CalculateRewardMileage(planPrice, 0.1m); // 10% 적립 가정
                    // if (rewardMileage > 0)
                    // {
                    //    userInfo.UpdateUserMileage(userId, (int)rewardMileage, $"{planName} 구매 적립");
                    // }

                    // 4. (선택 사항) 매출 기록 (결제 프로시저에서 처리 안 할 경우)
                    // Revenue revenue = new Revenue { ... }; dbManager.SaveRevenue(revenue);
                    Console.WriteLine("DB에 예약 및 결제 정보 기록 성공.");
                    return true;
                }
                else
                {
                    // DB 저장 실패 시, 이미 성공한 외부 결제를 취소해야 하는 복잡한 상황 발생 가능
                    Console.WriteLine("DB에 예약 및 결제 정보 기록 실패.");
                    // RollbackExternalPayment(paymentMethodName, /*결제 트랜잭션 ID*/);
                    return false;
                }
            }
            catch (Oracle.ManagedDataAccess.Client.OracleException oraEx)
            {
                Console.WriteLine($"{paymentMethodName} 결제 중 Oracle 오류: {oraEx.Message}");
                throw; // Form1에서 잡아서 처리하도록 다시 던짐
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{paymentMethodName} 결제 중 일반 오류: {ex.Message}");
                // 외부 결제가 이미 되었다면 롤백 로직 필요
                return false;
            }
        }


        public bool ProcessCardPurchase(int userId, int seatId, int planId, DateTime startTime, DateTime endTime, int mileageUsed, decimal planPrice)
        {
            Console.WriteLine("카드 결제 시도...");
            // 여기에 카드 결제 고유의 전처리 로직이 있다면 추가
            return ProcessPaymentInternal(userId, seatId, planId, startTime, endTime, mileageUsed, planPrice, "카드");
        }

        public bool ProcessKakaoPayPurchase(int userId, int seatId, int planId, DateTime startTime, DateTime endTime, int mileageUsed, decimal planPrice)
        {
            Console.WriteLine("카카오페이 결제 시도...");
            // 여기에 카카오페이 고유의 전처리 로직이 있다면 추가
            return ProcessPaymentInternal(userId, seatId, planId, startTime, endTime, mileageUsed, planPrice, "카카오페이");
        }

        public bool ProcessNaverPayPurchase(int userId, int seatId, int planId, DateTime startTime, DateTime endTime, int mileageUsed, decimal planPrice)
        {
            Console.WriteLine("네이버페이 결제 시도...");
            // 여기에 네이버페이 고유의 전처리 로직이 있다면 추가
            return ProcessPaymentInternal(userId, seatId, planId, startTime, endTime, mileageUsed, planPrice, "네이버페이");
        }
    }
}