using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Studyroom_kiosk
{
    public class Payment
    {
        public int PaymentId { get; set; }
        public int UserId { get; set; }
        public int ReservationId { get; set; }
        public decimal TotalAmount { get; set; }
        public int MileageUsed { get; set; }
        public string Status { get; set; }
        public DateTime PaymentTime { get; set; }
    }
}
