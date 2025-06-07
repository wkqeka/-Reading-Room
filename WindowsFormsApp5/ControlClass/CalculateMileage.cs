using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Studyroom_kiosk
{
    public static class CalculateMileage
    {
        public static decimal CalculateFinalPrice(decimal price, decimal mileage)
        {
            return price - mileage;
        }

        public static decimal CalculateReward(decimal price)
        {
            return Math.Floor(price * 0.05m); // 예: 5% 적립
        }
    }
}
