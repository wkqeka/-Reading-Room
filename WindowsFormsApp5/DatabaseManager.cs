using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                    string sql = "SELECT seat_number, status, seat_type FROM SEATS";

                    using (var cmd = new OracleCommand(sql, conn))
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var seat = new Seat(
                                reader["seat_number"].ToString(),
                                reader["status"].ToString(),
                                reader["seat_type"].ToString(),
                                "없음",  // reserved_time은 아직 조회하지 않음
                                reader["seat_type"].ToString()
                            );
                            seats.Add(seat);
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
    }
}
