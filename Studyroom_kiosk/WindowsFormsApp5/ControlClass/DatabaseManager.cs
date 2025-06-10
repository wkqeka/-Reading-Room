using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;
using Studyroom_kiosk;
using WindowsFormsApp5.EntityClass;

namespace Studyroom_kiosk
{
    // ▶ [Control 클래스] DatabaseManager
    // Oracle DB에 직접 연결하여 사용자, 좌석, 요금제, 예약, 결제 관련 데이터를 처리하는 역할 수행

    public static class DatabaseManager
    {
        // 연결 문자열은 실제 DB 환경에 맞게 수정하세요
        private static readonly string connectionString =
            "User Id=system;Password=qlalfqjsgh1;Data Source=localhost:1521/XEPDB1;";

        // ▶ 사용자 계정 조회 (ID로 검색)
        // [Control] AccountControl에서 호출
        public static Account GetAccountById(string userId)
        {
            try
            {
                using (OracleConnection conn = new OracleConnection(connectionString))
                {
                    conn.Open();

                    string sql = @"SELECT user_id, name, password, phone_number
                                   FROM USERS
                                   WHERE user_id = :id";

                    using (OracleCommand cmd = new OracleCommand(sql, conn))
                    {
                        cmd.Parameters.Add(new OracleParameter("id", userId));

                        using (OracleDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new Account(
                                    reader["user_id"].ToString(),
                                    reader["name"].ToString(),
                                    reader["password"].ToString(),
                                    reader["phone_number"].ToString()
                                );
                            }
                        }
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[DB ERROR - GetAccountById] {ex.Message}");
                return null;
            }
        }

        // ▶ 사용자 계정 등록
        // [Control] AccountControl에서 호출
        public static bool InsertAccount(Account account)
        {
            try
            {
                using (OracleConnection conn = new OracleConnection(connectionString))
                {
                    conn.Open();

                    string sql = @"INSERT INTO USERS (user_id, name, phone_number, password, status)
                                   VALUES (:id, :name, :phone, :pwd, 'active')";

                    using (OracleCommand cmd = new OracleCommand(sql, conn))
                    {
                        cmd.Parameters.Add(new OracleParameter("id", account.UserId));
                        cmd.Parameters.Add(new OracleParameter("name", account.UserName));
                        cmd.Parameters.Add(new OracleParameter("phone", account.UserPhoneNum));
                        cmd.Parameters.Add(new OracleParameter("pwd", account.UserPassword));

                        int result = cmd.ExecuteNonQuery();
                        return result > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[DB ERROR - InsertAccount] {ex.Message}");
                return false;
            }
        }
        // ▶ 요금제 전체 조회
        // [Boundary] PaymentUI 등에서 버튼 생성에 사용
        public static List<PricingPlan> GetPricingPlans()
        {
            var result = new List<PricingPlan>();
            using (var conn = new OracleConnection(connectionString))
            {
                conn.Open();
                string sql = "SELECT plan_id, name, duration_min, price, description FROM PLANS";
                using (var cmd = new OracleCommand(sql, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result.Add(new PricingPlan
                        {
                            PlanId = Convert.ToInt32(reader["plan_id"]),
                            Name = reader["name"].ToString(),
                            DurationMin = Convert.ToInt32(reader["duration_min"]),
                            Price = Convert.ToDecimal(reader["price"]),
                            Description = reader["description"].ToString()
                        });
                    }
                }
            }
            return result;
        }
        // ▶ 사용자 마일리지 조회
        // [Boundary] PaymentCheckUI에서 사용
        public static decimal GetUserMileage(string userId)
        {
            using (var conn = new OracleConnection(connectionString))
            {
                conn.Open();
                string sql = "SELECT total_mileage FROM MILEAGE_SUMMARY WHERE user_id = :id";
                using (var cmd = new OracleCommand(sql, conn))
                {
                    cmd.Parameters.Add(new OracleParameter("id", userId));
                    var result = cmd.ExecuteScalar();
                    return result != null ? Convert.ToDecimal(result) : 0;
                }
            }
        }
        // ▶ 결제 및 예약 프로시저 실행 (PROC_RESERVE_AND_PAY)
        // [Control] PaymentControl에서 호출
        public static bool ExecuteReserveAndPayProcedure(string userId, int seatId, int planId, DateTime startTime, DateTime endTime, int mileageUsed)
        {
            try
            {
                using (OracleConnection conn = new OracleConnection(connectionString))
                {
                    conn.Open();
                    using (OracleCommand cmd = new OracleCommand("PROC_RESERVE_AND_PAY", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.BindByName = true;

                        cmd.Parameters.Add("p_user_id", OracleDbType.Int32).Value = userId;
                        cmd.Parameters.Add("p_seat_id", OracleDbType.Int32).Value = seatId;
                        cmd.Parameters.Add("p_plan_id", OracleDbType.Int32).Value = planId;
                        cmd.Parameters.Add("p_start_time", OracleDbType.TimeStamp).Value = startTime;
                        cmd.Parameters.Add("p_end_time", OracleDbType.TimeStamp).Value = endTime;
                        cmd.Parameters.Add("p_mileage_use", OracleDbType.Int32).Value = mileageUsed;

                        Console.WriteLine($"[DEBUG] 호출값: userId={userId}, seatId={seatId}, planId={planId}, start={startTime}, end={endTime}, mileage={mileageUsed}");

                        cmd.ExecuteNonQuery();
                        return true;
                    }
                }
            }
            catch (OracleException ex)
            {
                MessageBox.Show($"[Oracle ERROR] {ex.Message}", "Oracle 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"[General ERROR] {ex.Message}", "일반 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        // ▶ 예약 직접 삽입 (트랜잭션 외 수동 처리 시 사용 가능)
        // [Control] 예약 로직에서 호출
        public static bool InsertReservation(Reservation reservation)
        {
            try
            {
                using (var conn = new OracleConnection(connectionString))
                {
                    conn.Open();
                    string sql = @"
                INSERT INTO RESERVATIONS 
                (reservation_id, user_id, seat_id, plan_id, reservation_time, start_time, end_time, status)
                VALUES 
                (SEQ_RESERVATION_ID.NEXTVAL, :userId, :seatId, :planId, :resTime, :startTime, :endTime, :status)";

                    using (var cmd = new OracleCommand(sql, conn))
                    {
                        cmd.Parameters.Add("userId", OracleDbType.Int32).Value = reservation.AccountId;
                        cmd.Parameters.Add("seatId", OracleDbType.Int32).Value = reservation.SeatId;
                        cmd.Parameters.Add("planId", OracleDbType.Int32).Value = reservation.PlanId;
                        cmd.Parameters.Add("resTime", OracleDbType.TimeStamp).Value = reservation.ReservationTime;
                        cmd.Parameters.Add("startTime", OracleDbType.TimeStamp).Value = reservation.StartTime;
                        cmd.Parameters.Add("endTime", OracleDbType.TimeStamp).Value = reservation.EndTime;
                        cmd.Parameters.Add("status", OracleDbType.Varchar2).Value = reservation.Status;

                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[DB ERROR - InsertReservation] {ex.Message}");
                return false;
            }
        }
        // ▶ 좌석별 예약 목록 조회
        // [Control] 좌석 상태 판단에 활용됨
        public static List<Reservation> GetReservationsBySeat(int seatId)
        {
            var reservations = new List<Reservation>();
            try
            {
                using (var conn = new OracleConnection(connectionString))
                {
                    conn.Open();
                    string sql = @"
                SELECT reservation_id, user_id, seat_id, plan_id, reservation_time, start_time, end_time, status 
                FROM RESERVATIONS 
                WHERE seat_id = :seatId";

                    using (var cmd = new OracleCommand(sql, conn))
                    {
                        cmd.Parameters.Add("seatId", OracleDbType.Int32).Value = seatId;

                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                reservations.Add(new Reservation
                                {
                                    ReservationId = Convert.ToInt32(reader["reservation_id"]),
                                    AccountId = reader["user_id"].ToString(),  // 🔴 여기 수정
                                    SeatId = Convert.ToInt32(reader["seat_id"]),
                                    PlanId = Convert.ToInt32(reader["plan_id"]),
                                    ReservationTime = Convert.ToDateTime(reader["reservation_time"]),
                                    StartTime = Convert.ToDateTime(reader["start_time"]),
                                    EndTime = Convert.ToDateTime(reader["end_time"]),
                                    Status = reader["status"].ToString()
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[DB ERROR - GetReservationsBySeat] {ex.Message}");
            }

            return reservations;
        }
        // ▶ 요금제 ID로 단일 요금제 조회
        // [Boundary] PaymentCheckUI (예약 기반 결제 시)
        public static PricingPlan GetPricingPlanById(int planId)
        {
            using (var conn = new OracleConnection(connectionString))
            {
                conn.Open();
                string sql = "SELECT plan_id, name, duration_min, price, description FROM PLANS WHERE plan_id = :id";
                using (var cmd = new OracleCommand(sql, conn))
                {
                    cmd.Parameters.Add("id", OracleDbType.Int32).Value = planId;
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new PricingPlan
                            {
                                PlanId = Convert.ToInt32(reader["plan_id"]),
                                Name = reader["name"].ToString(),
                                DurationMin = Convert.ToInt32(reader["duration_min"]),
                                Price = Convert.ToDecimal(reader["price"]),
                                Description = reader["description"].ToString()
                            };
                        }
                    }
                }
            }
            return null;
        }
        // ▶ 좌석 상태 전체 조회 (예약 및 사용중 포함)
        // [Control] SeatInquiryControl에서 호출되어 SeatInquiryUI에 사용
        public static List<Seat> GetAllSeatsWithReservationStatus()
        {
            List<Seat> seats = new List<Seat>();

            string query = @"
        SELECT s.seat_id, s.seat_number, s.seat_type,
               COALESCE((
                   SELECT
                       CASE
                           WHEN r.status = '사용중' AND CURRENT_TIMESTAMP BETWEEN r.start_time AND r.end_time THEN '사용중'
                           WHEN r.status = '예약됨' AND CURRENT_TIMESTAMP < r.start_time THEN '예약됨'
                           ELSE NULL
                       END
                   FROM RESERVATIONS r
                   WHERE r.seat_id = s.seat_id
                     AND r.status IN ('사용중', '예약됨')
                     AND CURRENT_TIMESTAMP < r.end_time
                   ORDER BY
                       CASE WHEN r.status = '사용중' THEN 1
                            WHEN r.status = '예약됨' THEN 2
                            ELSE 3
                       END
                   FETCH FIRST 1 ROWS ONLY
               ), '사용가능') AS status
        FROM SEATS s
        ORDER BY s.seat_id";

            try
            {
                using (var conn = new OracleConnection(connectionString))
                using (var cmd = new OracleCommand(query, conn))
                {
                    conn.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            seats.Add(new Seat(
                                seatId: reader.GetInt32(0),
                                seatNumber: reader.GetString(1),
                                status: reader.GetString(3),
                                seatType: reader.GetString(2)
                            ));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[DB ERROR - GetAllSeatsWithReservationStatus] {ex.Message}");
            }

            return seats;
        }
        // ▶ 전체 예약 중 '사용중' 또는 '예약됨' 상태인 항목 조회
        // [Control] SeatInquiryControl에서 상태 판별용으로 호출
        public static List<Reservation> GetAllActiveReservations()
        {
            var result = new List<Reservation>();
            try
            {
                using (var conn = new OracleConnection(connectionString))
                {
                    conn.Open();
                    string sql = @"
                SELECT reservation_id, user_id, seat_id, start_time, end_time, status, created_at
                FROM RESERVATIONS
                WHERE status IN ('사용중', '예약됨')
                  AND end_time > SYSDATE";

                    using (var cmd = new OracleCommand(sql, conn))
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            result.Add(new Reservation
                            {
                                ReservationId = Convert.ToInt32(reader["reservation_id"]),
                                AccountId = reader["user_id"].ToString(),
                                SeatId = Convert.ToInt32(reader["seat_id"]),
                                StartTime = Convert.ToDateTime(reader["start_time"]),
                                EndTime = Convert.ToDateTime(reader["end_time"]),
                                Status = reader["status"].ToString(),
                                ReservationTime = Convert.ToDateTime(reader["created_at"])
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("[DB ERROR - GetAllActiveReservations] " + ex.Message);
            }

            return result;
        }
    }
}
