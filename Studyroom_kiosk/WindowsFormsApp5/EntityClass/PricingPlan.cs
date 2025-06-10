using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Studyroom_kiosk
{
    // ▶ [Entity 클래스] PricingPlan
    // 요금제 정보 (이름, 가격, 시간 등)를 담는 클래스
    public class PricingPlan
    {
        // ▶ 요금제 ID (PK 역할)
        public int PlanId { get; set; }

        // ▶ 요금제 이름 (ex. 1시간권, 3시간권 등)
        public string Name { get; set; }

        // ▶ 사용 가능 시간 (단위: 분)
        public int DurationMin { get; set; }

        // ▶ 요금제 가격
        public decimal Price { get; set; }

        // ▶ 요금제 설명 (ex. 프로모션 정보 등)
        public string Description { get; set; }
    }
}
