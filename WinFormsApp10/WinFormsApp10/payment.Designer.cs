namespace ReadingRoomApp
{
    partial class PaymentForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblSeatInfo;
        private System.Windows.Forms.Button btnPay;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblSeatInfo = new System.Windows.Forms.Label();
            this.btnPay = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblSeatInfo
            // 
            this.lblSeatInfo.AutoSize = true;
            this.lblSeatInfo.Location = new System.Drawing.Point(30, 20);
            this.lblSeatInfo.Name = "lblSeatInfo";
            this.lblSeatInfo.Size = new System.Drawing.Size(120, 15);
            this.lblSeatInfo.Text = "선택한 좌석 ID:";
            // 
            // btnPay
            // 
            this.btnPay.Location = new System.Drawing.Point(30, 60);
            this.btnPay.Name = "btnPay";
            this.btnPay.Size = new System.Drawing.Size(100, 30);
            this.btnPay.Text = "결제하기";
            this.btnPay.UseVisualStyleBackColor = true;
            this.btnPay.Click += new System.EventHandler(this.btnPay_Click);
            // 
            // PaymentForm
            // 
            this.ClientSize = new System.Drawing.Size(200, 120);
            this.Controls.Add(this.lblSeatInfo);
            this.Controls.Add(this.btnPay);
            this.Name = "PaymentForm";
            this.Text = "결제";
            this.Load += new System.EventHandler(this.PaymentForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
