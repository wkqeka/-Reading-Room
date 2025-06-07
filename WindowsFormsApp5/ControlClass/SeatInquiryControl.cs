using Studyroom_kiosk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Studyroom_kiosk.ControlClass
{
    public class SeatInquiryControl
    {
        public List<Seat> FetchAllSeats()
        {
            try
            {
                return DatabaseManager.GetAllSeats();
            }
            catch (Exception ex)
            {
                throw new Exception("좌석 정보를 불러오는 중 오류 발생: " + ex.Message);
            }
        }
    }
}
