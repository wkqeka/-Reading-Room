namespace Studyroom_kiosk
{
    partial class PaymentCheckUI
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cbMileageUse = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.lblSeat = new System.Windows.Forms.Label();
            this.lblPlan = new System.Windows.Forms.Label();
            this.lblAvailableMileage = new System.Windows.Forms.Label();
            this.lblRewardMileage = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lblFinalPrice = new System.Windows.Forms.Label();
            this.lblPlanPrice = new System.Windows.Forms.Label();
            this.lblReservationTimeInfo = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("맑은 고딕", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button1.Location = new System.Drawing.Point(12, 490);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(156, 59);
            this.button1.TabIndex = 0;
            this.button1.Text = "뒤로가기";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("맑은 고딕", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button2.Location = new System.Drawing.Point(316, 490);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(156, 59);
            this.button2.TabIndex = 1;
            this.button2.Text = "결제";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.btnPay_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("맑은 고딕", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(181, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 32);
            this.label1.TabIndex = 2;
            this.label1.Text = "결제 확인";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.Location = new System.Drawing.Point(18, 146);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 25);
            this.label3.TabIndex = 4;
            this.label3.Text = "좌석";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label4.Location = new System.Drawing.Point(18, 202);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 25);
            this.label4.TabIndex = 5;
            this.label4.Text = "요금제";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label5.Location = new System.Drawing.Point(18, 431);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(178, 25);
            this.label5.TabIndex = 6;
            this.label5.Text = "적립 예정 마일리지";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label6.Location = new System.Drawing.Point(18, 258);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(178, 25);
            this.label6.TabIndex = 7;
            this.label6.Text = "사용 가능 마일리지";
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button3.Location = new System.Drawing.Point(387, 313);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(85, 34);
            this.button3.TabIndex = 8;
            this.button3.Text = "사용";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.btnApplyMileage_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.Location = new System.Drawing.Point(18, 318);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(152, 25);
            this.label2.TabIndex = 9;
            this.label2.Text = "사용할 마일리지";
            // 
            // cbMileageUse
            // 
            this.cbMileageUse.FormattingEnabled = true;
            this.cbMileageUse.Location = new System.Drawing.Point(210, 323);
            this.cbMileageUse.Name = "cbMileageUse";
            this.cbMileageUse.Size = new System.Drawing.Size(121, 20);
            this.cbMileageUse.TabIndex = 10;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label7.Location = new System.Drawing.Point(84, 41);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(300, 21);
            this.label7.TabIndex = 11;
            this.label7.Text = "선택하신 자리와 요금제를 확인해주세요";
            // 
            // lblSeat
            // 
            this.lblSeat.AutoSize = true;
            this.lblSeat.Font = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblSeat.Location = new System.Drawing.Point(268, 146);
            this.lblSeat.Name = "lblSeat";
            this.lblSeat.Size = new System.Drawing.Size(72, 25);
            this.lblSeat.TabIndex = 12;
            this.lblSeat.Text = "lblSeat";
            // 
            // lblPlan
            // 
            this.lblPlan.AutoSize = true;
            this.lblPlan.Font = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblPlan.Location = new System.Drawing.Point(182, 202);
            this.lblPlan.Name = "lblPlan";
            this.lblPlan.Size = new System.Drawing.Size(73, 25);
            this.lblPlan.TabIndex = 13;
            this.lblPlan.Text = "lblPlan";
            // 
            // lblAvailableMileage
            // 
            this.lblAvailableMileage.AutoSize = true;
            this.lblAvailableMileage.Font = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblAvailableMileage.Location = new System.Drawing.Point(249, 258);
            this.lblAvailableMileage.Name = "lblAvailableMileage";
            this.lblAvailableMileage.Size = new System.Drawing.Size(184, 25);
            this.lblAvailableMileage.TabIndex = 14;
            this.lblAvailableMileage.Text = "lblAvailableMileage";
            // 
            // lblRewardMileage
            // 
            this.lblRewardMileage.AutoSize = true;
            this.lblRewardMileage.Font = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblRewardMileage.Location = new System.Drawing.Point(249, 431);
            this.lblRewardMileage.Name = "lblRewardMileage";
            this.lblRewardMileage.Size = new System.Drawing.Size(170, 25);
            this.lblRewardMileage.TabIndex = 15;
            this.lblRewardMileage.Text = "lblRewardMileage";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label12.Location = new System.Drawing.Point(18, 374);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(133, 25);
            this.label12.TabIndex = 16;
            this.label12.Text = "최종 결제금액";
            // 
            // lblFinalPrice
            // 
            this.lblFinalPrice.AutoSize = true;
            this.lblFinalPrice.Font = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblFinalPrice.Location = new System.Drawing.Point(249, 374);
            this.lblFinalPrice.Name = "lblFinalPrice";
            this.lblFinalPrice.Size = new System.Drawing.Size(119, 25);
            this.lblFinalPrice.TabIndex = 17;
            this.lblFinalPrice.Text = "lblFinalPrice";
            // 
            // lblPlanPrice
            // 
            this.lblPlanPrice.AutoSize = true;
            this.lblPlanPrice.Font = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblPlanPrice.Location = new System.Drawing.Point(268, 202);
            this.lblPlanPrice.Name = "lblPlanPrice";
            this.lblPlanPrice.Size = new System.Drawing.Size(116, 25);
            this.lblPlanPrice.TabIndex = 18;
            this.lblPlanPrice.Text = "lblPlanPrice";
            // 
            // lblReservationTimeInfo
            // 
            this.lblReservationTimeInfo.AutoSize = true;
            this.lblReservationTimeInfo.Font = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblReservationTimeInfo.Location = new System.Drawing.Point(22, 91);
            this.lblReservationTimeInfo.Name = "lblReservationTimeInfo";
            this.lblReservationTimeInfo.Size = new System.Drawing.Size(219, 25);
            this.lblReservationTimeInfo.TabIndex = 19;
            this.lblReservationTimeInfo.Text = "lblReservationTimeInfo";
            // 
            // PaymentCheckUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 561);
            this.Controls.Add(this.lblReservationTimeInfo);
            this.Controls.Add(this.lblPlanPrice);
            this.Controls.Add(this.lblFinalPrice);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.lblRewardMileage);
            this.Controls.Add(this.lblAvailableMileage);
            this.Controls.Add(this.lblPlan);
            this.Controls.Add(this.lblSeat);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cbMileageUse);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "PaymentCheckUI";
            this.Text = "PaymentCheckUI";
            this.Load += new System.EventHandler(this.PaymentCheckUI_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbMileageUse;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblSeat;
        private System.Windows.Forms.Label lblPlan;
        private System.Windows.Forms.Label lblAvailableMileage;
        private System.Windows.Forms.Label lblRewardMileage;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lblFinalPrice;
        private System.Windows.Forms.Label lblPlanPrice;
        private System.Windows.Forms.Label lblReservationTimeInfo;
    }
}