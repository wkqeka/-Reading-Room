using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;
using Studyroom_kiosk;

namespace Studyroom_kiosk
{
    public static class DatabaseManager
    {
        // 연결 문자열은 실제 DB 환경에 맞게 수정하세요
        private static readonly string connectionString =
            "User Id=system;Password=qlalfqjsgh1;Data Source=localhost:1521/XEPDB1;";

        /// <summary>
        /// 사용자 ID로 계정 정보를 조회합니다.
        /// </summary>
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

        /// <summary>
        /// 새 계정을 USERS 테이블에 삽입합니다.
        /// </summary>
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

        /// <summary>
        /// SEATS 테이블에서 모든 좌석 정보를 조회합니다.
        /// </summary>
        public static List<Seat> GetAllSeats()
        {
            var seats = new List<Seat>();
            try
            {
                using (var conn = new OracleConnection(connectionString))
                {
                    conn.Open();
                    string sql = "SELECT seat_id, seat_number, status, seat_type FROM SEATS";

                    using (var cmd = new OracleCommand(sql, conn))
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            seats.Add(new Seat(
                                Convert.ToInt32(reader["seat_id"]),
                                reader["seat_number"].ToString(),
                                reader["status"].ToString(),
                                reader["seat_type"].ToString()
                            ));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[DB ERROR - GetAllSeats] {ex.Message}");
            }

            return seats;
        }

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

    }
}
