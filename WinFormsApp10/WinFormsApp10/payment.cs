using System;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;

namespace ReadingRoomApp
{
    public partial class PaymentForm : Form
    {
        private int seatId;
        private string connStr = "User Id=aaa;Password=1234;Data Source=localhost:1522/XEPDB1;";

        public PaymentForm(int seatId)
        {
            InitializeComponent();
            this.seatId = seatId;
        }

        private void PaymentForm_Load(object sender, EventArgs e)
        {
            lblSeatInfo.Text = $"선택한 좌석 ID: {seatId}";
        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            try
            {
                using (OracleConnection conn = new OracleConnection(connStr))
                {
                    conn.Open();

                    string sql = "UPDATE AAA.SEATS SET status = 'in_use' WHERE seat_id = :seatId";
                    OracleCommand cmd = new OracleCommand(sql, conn);
                    cmd.Parameters.Add(new OracleParameter("seatId", seatId));

                    int result = cmd.ExecuteNonQuery();
                    if (result > 0)
                    {
                        MessageBox.Show("결제가 완료되었습니다.");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("결제 실패: 좌석 상태 변경이 되지 않았습니다.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("결제 중 오류 발생: " + ex.Message);
            }
        }
    }
}
