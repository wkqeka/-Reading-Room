using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class Seat
    {
        public string SeatId { get; set; }
        public string Status { get; set; }        // "예약 가능", "예약 완료"
        public string Purpose { get; set; }
        public string ReservedTime { get; set; }  // ex) "오후 2시~4시"

        public Seat(string id, string status, string purpose, string reservedTime = "없음")
        {
            SeatId = id;
            Status = status;
            Purpose = purpose;
            ReservedTime = reservedTime;
        }
    }
}
