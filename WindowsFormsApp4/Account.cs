// Account.cs
using System;
namespace WindowsFormsApp4
{
    public class Account
    {
        public string UserId { get; set; } // DB의 user_id 타입에 따라 int 또는 string
        public string UserName { get; set; }
        public string PhoneNumber { get; set; } // DB의 phone_number
                                                // public string UserPassword { get; set; } // 비밀번호는 보통 직접 다루지 않음
        public string Status { get; set; } // DB의 status
        public decimal UserMileage { get; set; } // 마일리지 (MILEAGE_SUMMARY 뷰 등에서 가져옴)
                                                 // public DateTime PurchaseDate { get; set; } // 이것은 특정 구매 건에 대한 날짜일 수 있으므로, Account에 직접 있기보다 Revenue 등에 있을 수 있음

        // 클래스 다이어그램에 있던 메서드들 (필요에 따라 구현)
        public decimal GetUserMileage()
        {
            return UserMileage;
        }

        public void SetUserMileage(decimal newMileage)
        {
            UserMileage = newMileage;
        }

        public void UpdatePurchaseHistory() // 이 메서드의 구체적인 역할 정의 필요
        {
            Console.WriteLine("TODO: Implement Account.UpdatePurchaseHistory()");
        }
    }
}