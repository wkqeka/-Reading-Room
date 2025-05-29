using System;
using System.Drawing;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;

namespace ReadingRoomApp
{
    public partial class Form1 : Form
    {
        private string connStr = "User Id=aaa;Password=1234;Data Source=localhost:1522/XEPDB1;";

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadSeats();
        }

        private void LoadSeats()
        {
            flowLayoutPanelSeats.Controls.Clear();

            try
            {
                using (OracleConnection conn = new OracleConnection(connStr))
                {
                    conn.Open();

                    string sql = "SELECT seat_id, seat_number, status FROM AAA.SEATS ORDER BY seat_id";

                    OracleCommand cmd = new OracleCommand(sql, conn);
                    OracleDataReader reader = cmd.ExecuteReader();

                    int count = 0;
                    while (reader.Read())
                    {
                        count++;

                        int seatId = reader.GetInt32(0);
                        string seatNum = reader.GetString(1);
                        string status = reader.GetString(2);

                        Button seatBtn = new Button();
                        seatBtn.Text = seatNum;
                        seatBtn.Tag = new SeatInfo
                        {
                            SeatId = seatId,
                            Status = status
                        };
                        seatBtn.Width = 60;
                        seatBtn.Height = 60;
                        seatBtn.Margin = new Padding(5);
                        seatBtn.BackColor = GetSeatColor(status);
                        seatBtn.Click += SeatBtn_Click;

                        flowLayoutPanelSeats.Controls.Add(seatBtn);
                    }

                    if (count == 0)
                    {
                        MessageBox.Show("��ȸ�� �¼��� �����ϴ�.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("�ڸ� ��ȸ ����: " + ex.Message);
            }
        }

        private Color GetSeatColor(string status)
        {
            switch (status.ToLower())
            {
                case "available": return Color.LightGreen;
                case "reserved": return Color.Orange;
                case "in_use": return Color.Red;
                case "closed": return Color.Gray;
                default: return Color.White;
            }
        }

        private void SeatBtn_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            SeatInfo info = btn.Tag as SeatInfo;

            if (info.Status.ToLower() == "reserved")
            {
                MessageBox.Show("����� �¼��Դϴ�. ���� �ð� �������� ����� �����մϴ�.");
                // ��� �����ϹǷ� return ����
            }

            if (info.Status.ToLower() == "in_use" || info.Status.ToLower() == "closed")
            {
                MessageBox.Show("������ �ڸ��� ���� ����� �Ұ����մϴ�.");
                return;
            }

            PaymentForm paymentForm = new PaymentForm(info.SeatId);
            paymentForm.ShowDialog();

            LoadSeats();
        }
    }

    public class SeatInfo
    {
        public int SeatId { get; set; }
        public string Status { get; set; }
    }
}
