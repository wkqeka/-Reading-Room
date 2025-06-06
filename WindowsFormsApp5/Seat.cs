using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Studyroom_kiosk
{
    public class Seat
    {
        public string SeatId { get; set; }
        public string Status { get; set; }
        public string Purpose { get; set; }
        public string ReservedTime { get; set; }
        public string SeatType { get; set; }

        public Seat(string id, string status, string purpose, string reservedTime = "없음", string seatType = "")
        {
            SeatId = id;
            Status = status;
            Purpose = purpose;
            ReservedTime = reservedTime;
            SeatType = seatType;
        }
    }
}
