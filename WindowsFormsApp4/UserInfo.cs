// UserInfo.cs
using System;

namespace WindowsFormsApp4
{
    public class UserInfo
    {
        private DatabaseManager dbManager;

        public UserInfo(DatabaseManager dbMgr)
        {
            this.dbManager = dbMgr ?? throw new ArgumentNullException(nameof(dbMgr));
        }

        // 현재 사용자 마일리지 가져오기
        public decimal GetCurrentUserMileage(int userId)
        {
            Account currentUser = dbManager.GetAccountDetails(userId); // DatabaseManager에 구현 필요
            return currentUser?.UserMileage ?? 0; // 사용자가 없거나 마일리지가 없으면 0 반환
        }

        // 사용자 마일리지 업데이트 (예: 적립 또는 사용)
        // changeAmount: 양수면 적립, 음수면 사용
        public bool UpdateUserMileage(int userId, int changeAmount, string reason)
        {
            // DatabaseManager를 통해 DB에 마일리지 변경 내역 기록
            return dbManager.UpdateUserMileage(userId, changeAmount, reason); // DatabaseManager에 구현 필요
        }
    }
}