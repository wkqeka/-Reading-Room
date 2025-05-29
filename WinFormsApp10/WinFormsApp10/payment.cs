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
            lblSeatInfo.Text = $"������ �¼� ID: {seatId}";
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
                        MessageBox.Show("������ �Ϸ�Ǿ����ϴ�.");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("���� ����: �¼� ���� ������ ���� �ʾҽ��ϴ�.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("���� �� ���� �߻�: " + ex.Message);
            }
        }
    }
}
