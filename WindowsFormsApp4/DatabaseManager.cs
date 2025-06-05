// DatabaseManager.cs
using System;
using System.Collections.Generic;
using System.Data;
using Oracle.ManagedDataAccess.Client;

namespace WindowsFormsApp4 // PlanInfo와 같은 네임스페이스
{
    public class DatabaseManager
    {
        private string connectionString;

        public DatabaseManager(string connStr)
        {
            if (string.IsNullOrWhiteSpace(connStr))
            {
                throw new ArgumentNullException(nameof(connStr), "데이터베이스 연결 문자열이 필요합니다.");
            }
            this.connectionString = connStr;
        }

        public List<PlanInfo> GetPricingPlans()
        {
            List<PlanInfo> plans = new List<PlanInfo>();
            using (OracleConnection conn = new OracleConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string sql = "SELECT plan_id, name, price, duration_min FROM PLANS ORDER BY price";
                    using (OracleCommand cmd = new OracleCommand(sql, conn))
                    {
                        using (OracleDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                plans.Add(new PlanInfo // 이제 PlanInfo를 인식해야 합니다.
                                {
                                    Id = Convert.ToInt32(reader["plan_id"]),
                                    Name = reader["name"].ToString(),
                                    Price = Convert.ToDecimal(reader["price"]),
                                    DurationMinutes = Convert.ToInt32(reader["duration_min"])
                                });
                            }
                        }
                    }
                }
                catch (OracleException ex)
                {
                    Console.WriteLine($"Oracle Error (GetPricingPlans): {ex.Message} (Number: {ex.Number})");
                    throw;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"General Error (GetPricingPlans): {ex.Message}");
                    throw;
                }
            }
            return plans;
        }

        public bool ExecuteReserveAndPayProcedure(int userId, int seatId, int planId, DateTime startTime, DateTime endTime, int mileageUsed)
        {
            using (OracleConnection conn = new OracleConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    using (OracleCommand cmd = new OracleCommand("PROC_RESERVE_AND_PAY", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("p_user_id", OracleDbType.Int32).Value = userId;
                        cmd.Parameters.Add("p_seat_id", OracleDbType.Int32).Value = seatId;
                        cmd.Parameters.Add("p_plan_id", OracleDbType.Int32).Value = planId;
                        cmd.Parameters.Add("p_start_time", OracleDbType.TimeStamp).Value = startTime;
                        cmd.Parameters.Add("p_end_time", OracleDbType.TimeStamp).Value = endTime;
                        cmd.Parameters.Add("p_mileage_use", OracleDbType.Int32).Value = mileageUsed;
                        cmd.ExecuteNonQuery();
                        return true;
                    }
                }
                catch (OracleException ex)
                {
                    Console.WriteLine($"Oracle Procedure Error (ExecuteReserveAndPayProcedure): {ex.Message} (Number: {ex.Number})");
                    throw;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"General Error (ExecuteReserveAndPayProcedure): {ex.Message}");
                    throw;
                }
            }
        }

        public Account GetAccountDetails(int userId)
        {
            Account account = null;
            using (OracleConnection conn = new OracleConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    // MILEAGE_SUMMARY 뷰가 user_id와 total_mileage를 가지고 있다고 가정
                    string sql = @"
                        SELECT u.user_id, u.name, u.phone_number, u.status, NVL(ms.total_mileage, 0) AS total_mileage
                        FROM USERS u
                        LEFT JOIN MILEAGE_SUMMARY ms ON u.user_id = ms.user_id
                        WHERE u.user_id = :p_user_id";

                    using (OracleCommand cmd = new OracleCommand(sql, conn))
                    {
                        cmd.Parameters.Add("p_user_id", OracleDbType.Int32).Value = userId;
                        using (OracleDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                account = new Account
                                {
                                    UserId = reader["user_id"].ToString(), // 또는 Convert.ToInt32(reader["user_id"])
                                    UserName = reader["name"].ToString(),
                                    PhoneNumber = reader["phone_number"].ToString(),
                                    Status = reader["status"].ToString(),
                                    UserMileage = Convert.ToDecimal(reader["total_mileage"])
                                };
                            }
                        }
                    }
                }
                catch (OracleException ex)
                {
                    Console.WriteLine($"Oracle Error (GetAccountDetails): {ex.Message}");
                    throw;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"General Error (GetAccountDetails): {ex.Message}");
                    throw;
                }
            }
            return account;
        }

        public bool UpdateUserMileage(int userId, int changeAmount, string reason)
        {
            using (OracleConnection conn = new OracleConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string sql = @"
                        INSERT INTO MILEAGE (mileage_id, user_id, change_amount, reason, created_at)
                        VALUES (SEQ_MILEAGE_ID.NEXTVAL, :p_user_id, :p_change_amount, :p_reason, SYSDATE)";
                    using (OracleCommand cmd = new OracleCommand(sql, conn))
                    {
                        cmd.Parameters.Add("p_user_id", OracleDbType.Int32).Value = userId;
                        cmd.Parameters.Add("p_change_amount", OracleDbType.Int32).Value = changeAmount;
                        cmd.Parameters.Add("p_reason", OracleDbType.Varchar2).Value = reason;
                        cmd.ExecuteNonQuery();
                        return true;
                    }
                }
                catch (OracleException ex)
                {
                    Console.WriteLine($"Oracle Error (UpdateUserMileage): {ex.Message}");
                    throw;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"General Error (UpdateUserMileage): {ex.Message}");
                    throw;
                }
            }
        }
        // ... (다른 필요한 DatabaseManager 메서드들) ...
    }
}