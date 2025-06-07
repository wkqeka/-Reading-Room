using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Studyroom_kiosk
{
    public class Seat
    {
        public int SeatId { get; set; }
        public string SeatNumber { get; set; }
        public string Status { get; set; }
        public string SeatType { get; set; }
        public string ReservedTime { get; set; } = "없음";

        public Seat(int seatId, string seatNumber, string status, string seatType)
        {
            SeatId = seatId;
            SeatNumber = seatNumber;
            Status = status;
            SeatType = seatType;
        }
    }
}
