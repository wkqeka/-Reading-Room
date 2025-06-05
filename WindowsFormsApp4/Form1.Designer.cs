namespace WindowsFormsApp4
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelConfirmation1 = new System.Windows.Forms.Panel();
            this.panelConfirmation2 = new System.Windows.Forms.Panel();
            this.panelPaymentComplete = new System.Windows.Forms.Panel();
            this.panelPlanSelection = new System.Windows.Forms.Panel();
            this.lblPlanSelcetionTitle = new System.Windows.Forms.Label();
            this.btnProceedToConfirmation = new System.Windows.Forms.Button();
            this.btnBackFromPlanSelection = new System.Windows.Forms.Button();
            this.flowLayoutPanelPlans = new System.Windows.Forms.FlowLayoutPanel();
            this.lblConfirmation1Title = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblUserInfoLabel = new System.Windows.Forms.Label();
            this.lblSeatInfoLabel = new System.Windows.Forms.Label();
            this.lblPlanInfoLabel = new System.Windows.Forms.Label();
            this.lblMileageEarnLabel = new System.Windows.Forms.Label();
            this.lblTotalAmountLabel = new System.Windows.Forms.Label();
            this.lblUserInfoValue = new System.Windows.Forms.Label();
            this.lblSeatInfoValue = new System.Windows.Forms.Label();
            this.lblPlanInfoValue = new System.Windows.Forms.Label();
            this.lblMileageEarnValue = new System.Windows.Forms.Label();
            this.lblTotalAmountValue = new System.Windows.Forms.Label();
            this.btnBackToPlanSelection = new System.Windows.Forms.Button();
            this.btnProceedToPaymentMethod = new System.Windows.Forms.Button();
            this.lblConfirmation2Title = new System.Windows.Forms.Label();
            this.lblConfirmation2Subtitle = new System.Windows.Forms.Label();
            this.btnCardPayment = new System.Windows.Forms.Button();
            this.btnKakaoPay = new System.Windows.Forms.Button();
            this.btnNaverPay = new System.Windows.Forms.Button();
            this.btnBackToConfirmation1 = new System.Windows.Forms.Button();
            this.btnFinalizePayment = new System.Windows.Forms.Button();
            this.lblPaymentSuccess = new System.Windows.Forms.Label();
            this.panelConfirmation1.SuspendLayout();
            this.panelConfirmation2.SuspendLayout();
            this.panelPaymentComplete.SuspendLayout();
            this.panelPlanSelection.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelConfirmation1
            // 
            this.panelConfirmation1.Controls.Add(this.btnProceedToPaymentMethod);
            this.panelConfirmation1.Controls.Add(this.btnBackToPlanSelection);
            this.panelConfirmation1.Controls.Add(this.lblTotalAmountValue);
            this.panelConfirmation1.Controls.Add(this.lblMileageEarnValue);
            this.panelConfirmation1.Controls.Add(this.lblPlanInfoValue);
            this.panelConfirmation1.Controls.Add(this.lblSeatInfoValue);
            this.panelConfirmation1.Controls.Add(this.lblUserInfoValue);
            this.panelConfirmation1.Controls.Add(this.lblTotalAmountLabel);
            this.panelConfirmation1.Controls.Add(this.lblMileageEarnLabel);
            this.panelConfirmation1.Controls.Add(this.lblPlanInfoLabel);
            this.panelConfirmation1.Controls.Add(this.lblSeatInfoLabel);
            this.panelConfirmation1.Controls.Add(this.lblUserInfoLabel);
            this.panelConfirmation1.Controls.Add(this.label2);
            this.panelConfirmation1.Controls.Add(this.lblConfirmation1Title);
            this.panelConfirmation1.Location = new System.Drawing.Point(441, 31);
            this.panelConfirmation1.Name = "panelConfirmation1";
            this.panelConfirmation1.Size = new System.Drawing.Size(334, 416);
            this.panelConfirmation1.TabIndex = 1;
            this.panelConfirmation1.Visible = false;
            // 
            // panelConfirmation2
            // 
            this.panelConfirmation2.Controls.Add(this.btnFinalizePayment);
            this.panelConfirmation2.Controls.Add(this.btnBackToConfirmation1);
            this.panelConfirmation2.Controls.Add(this.btnNaverPay);
            this.panelConfirmation2.Controls.Add(this.btnKakaoPay);
            this.panelConfirmation2.Controls.Add(this.btnCardPayment);
            this.panelConfirmation2.Controls.Add(this.lblConfirmation2Subtitle);
            this.panelConfirmation2.Controls.Add(this.lblConfirmation2Title);
            this.panelConfirmation2.Location = new System.Drawing.Point(34, 467);
            this.panelConfirmation2.Name = "panelConfirmation2";
            this.panelConfirmation2.Size = new System.Drawing.Size(310, 467);
            this.panelConfirmation2.TabIndex = 2;
            this.panelConfirmation2.Visible = false;
            // 
            // panelPaymentComplete
            // 
            this.panelPaymentComplete.Controls.Add(this.lblPaymentSuccess);
            this.panelPaymentComplete.Location = new System.Drawing.Point(441, 467);
            this.panelPaymentComplete.Name = "panelPaymentComplete";
            this.panelPaymentComplete.Size = new System.Drawing.Size(334, 467);
            this.panelPaymentComplete.TabIndex = 3;
            this.panelPaymentComplete.Paint += new System.Windows.Forms.PaintEventHandler(this.panelPaymentComplete_Paint);
            // 
            // panelPlanSelection
            // 
            this.panelPlanSelection.Controls.Add(this.flowLayoutPanelPlans);
            this.panelPlanSelection.Controls.Add(this.btnBackFromPlanSelection);
            this.panelPlanSelection.Controls.Add(this.btnProceedToConfirmation);
            this.panelPlanSelection.Controls.Add(this.lblPlanSelcetionTitle);
            this.panelPlanSelection.Location = new System.Drawing.Point(33, 29);
            this.panelPlanSelection.Name = "panelPlanSelection";
            this.panelPlanSelection.Size = new System.Drawing.Size(311, 418);
            this.panelPlanSelection.TabIndex = 4;
            this.panelPlanSelection.Visible = false;
            this.panelPlanSelection.Paint += new System.Windows.Forms.PaintEventHandler(this.panelPlanSelection_Paint);
            // 
            // lblPlanSelcetionTitle
            // 
            this.lblPlanSelcetionTitle.AutoSize = true;
            this.lblPlanSelcetionTitle.Font = new System.Drawing.Font("굴림", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblPlanSelcetionTitle.Location = new System.Drawing.Point(96, 17);
            this.lblPlanSelcetionTitle.Name = "lblPlanSelcetionTitle";
            this.lblPlanSelcetionTitle.Size = new System.Drawing.Size(100, 29);
            this.lblPlanSelcetionTitle.TabIndex = 0;
            this.lblPlanSelcetionTitle.Text = "결제창";
            this.lblPlanSelcetionTitle.Click += new System.EventHandler(this.label1_Click);
            // 
            // btnProceedToConfirmation
            // 
            this.btnProceedToConfirmation.Location = new System.Drawing.Point(231, 362);
            this.btnProceedToConfirmation.Name = "btnProceedToConfirmation";
            this.btnProceedToConfirmation.Size = new System.Drawing.Size(64, 34);
            this.btnProceedToConfirmation.TabIndex = 1;
            this.btnProceedToConfirmation.Text = "결제하기";
            this.btnProceedToConfirmation.UseVisualStyleBackColor = true;
            // 
            // btnBackFromPlanSelection
            // 
            this.btnBackFromPlanSelection.Location = new System.Drawing.Point(17, 364);
            this.btnBackFromPlanSelection.Name = "btnBackFromPlanSelection";
            this.btnBackFromPlanSelection.Size = new System.Drawing.Size(64, 32);
            this.btnBackFromPlanSelection.TabIndex = 2;
            this.btnBackFromPlanSelection.Text = "뒤로가기";
            this.btnBackFromPlanSelection.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanelPlans
            // 
            this.flowLayoutPanelPlans.Location = new System.Drawing.Point(17, 61);
            this.flowLayoutPanelPlans.Name = "flowLayoutPanelPlans";
            this.flowLayoutPanelPlans.Size = new System.Drawing.Size(277, 289);
            this.flowLayoutPanelPlans.TabIndex = 3;
            // 
            // lblConfirmation1Title
            // 
            this.lblConfirmation1Title.AutoSize = true;
            this.lblConfirmation1Title.Font = new System.Drawing.Font("굴림", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblConfirmation1Title.Location = new System.Drawing.Point(114, 15);
            this.lblConfirmation1Title.Name = "lblConfirmation1Title";
            this.lblConfirmation1Title.Size = new System.Drawing.Size(129, 29);
            this.lblConfirmation1Title.TabIndex = 0;
            this.lblConfirmation1Title.Text = "결제확인";
            this.lblConfirmation1Title.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.Location = new System.Drawing.Point(19, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(296, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "1. 선택한 자리와 요금제를 확인해주세요";
            // 
            // lblUserInfoLabel
            // 
            this.lblUserInfoLabel.AutoSize = true;
            this.lblUserInfoLabel.Location = new System.Drawing.Point(32, 114);
            this.lblUserInfoLabel.Name = "lblUserInfoLabel";
            this.lblUserInfoLabel.Size = new System.Drawing.Size(53, 12);
            this.lblUserInfoLabel.TabIndex = 2;
            this.lblUserInfoLabel.Text = "회원정보";
            // 
            // lblSeatInfoLabel
            // 
            this.lblSeatInfoLabel.AutoSize = true;
            this.lblSeatInfoLabel.Location = new System.Drawing.Point(32, 144);
            this.lblSeatInfoLabel.Name = "lblSeatInfoLabel";
            this.lblSeatInfoLabel.Size = new System.Drawing.Size(53, 12);
            this.lblSeatInfoLabel.TabIndex = 3;
            this.lblSeatInfoLabel.Text = "좌석정보";
            // 
            // lblPlanInfoLabel
            // 
            this.lblPlanInfoLabel.AutoSize = true;
            this.lblPlanInfoLabel.Location = new System.Drawing.Point(32, 172);
            this.lblPlanInfoLabel.Name = "lblPlanInfoLabel";
            this.lblPlanInfoLabel.Size = new System.Drawing.Size(69, 12);
            this.lblPlanInfoLabel.TabIndex = 4;
            this.lblPlanInfoLabel.Text = "요금제 정보";
            // 
            // lblMileageEarnLabel
            // 
            this.lblMileageEarnLabel.AutoSize = true;
            this.lblMileageEarnLabel.Location = new System.Drawing.Point(32, 199);
            this.lblMileageEarnLabel.Name = "lblMileageEarnLabel";
            this.lblMileageEarnLabel.Size = new System.Drawing.Size(109, 12);
            this.lblMileageEarnLabel.TabIndex = 5;
            this.lblMileageEarnLabel.Text = "적립 예정 마일리지";
            // 
            // lblTotalAmountLabel
            // 
            this.lblTotalAmountLabel.AutoSize = true;
            this.lblTotalAmountLabel.Location = new System.Drawing.Point(32, 311);
            this.lblTotalAmountLabel.Name = "lblTotalAmountLabel";
            this.lblTotalAmountLabel.Size = new System.Drawing.Size(69, 12);
            this.lblTotalAmountLabel.TabIndex = 6;
            this.lblTotalAmountLabel.Text = "총 결제금액";
            // 
            // lblUserInfoValue
            // 
            this.lblUserInfoValue.AutoSize = true;
            this.lblUserInfoValue.Location = new System.Drawing.Point(205, 114);
            this.lblUserInfoValue.Name = "lblUserInfoValue";
            this.lblUserInfoValue.Size = new System.Drawing.Size(38, 12);
            this.lblUserInfoValue.TabIndex = 7;
            this.lblUserInfoValue.Text = "label7";
            // 
            // lblSeatInfoValue
            // 
            this.lblSeatInfoValue.AutoSize = true;
            this.lblSeatInfoValue.Location = new System.Drawing.Point(205, 144);
            this.lblSeatInfoValue.Name = "lblSeatInfoValue";
            this.lblSeatInfoValue.Size = new System.Drawing.Size(38, 12);
            this.lblSeatInfoValue.TabIndex = 8;
            this.lblSeatInfoValue.Text = "label8";
            // 
            // lblPlanInfoValue
            // 
            this.lblPlanInfoValue.AutoSize = true;
            this.lblPlanInfoValue.Location = new System.Drawing.Point(205, 172);
            this.lblPlanInfoValue.Name = "lblPlanInfoValue";
            this.lblPlanInfoValue.Size = new System.Drawing.Size(38, 12);
            this.lblPlanInfoValue.TabIndex = 9;
            this.lblPlanInfoValue.Text = "label9";
            // 
            // lblMileageEarnValue
            // 
            this.lblMileageEarnValue.AutoSize = true;
            this.lblMileageEarnValue.Location = new System.Drawing.Point(199, 199);
            this.lblMileageEarnValue.Name = "lblMileageEarnValue";
            this.lblMileageEarnValue.Size = new System.Drawing.Size(44, 12);
            this.lblMileageEarnValue.TabIndex = 10;
            this.lblMileageEarnValue.Text = "label10";
            // 
            // lblTotalAmountValue
            // 
            this.lblTotalAmountValue.AutoSize = true;
            this.lblTotalAmountValue.Location = new System.Drawing.Point(205, 311);
            this.lblTotalAmountValue.Name = "lblTotalAmountValue";
            this.lblTotalAmountValue.Size = new System.Drawing.Size(38, 12);
            this.lblTotalAmountValue.TabIndex = 11;
            this.lblTotalAmountValue.Text = "label1";
            // 
            // btnBackToPlanSelection
            // 
            this.btnBackToPlanSelection.Location = new System.Drawing.Point(19, 361);
            this.btnBackToPlanSelection.Name = "btnBackToPlanSelection";
            this.btnBackToPlanSelection.Size = new System.Drawing.Size(81, 32);
            this.btnBackToPlanSelection.TabIndex = 12;
            this.btnBackToPlanSelection.Text = "뒤로가기";
            this.btnBackToPlanSelection.UseVisualStyleBackColor = true;
            // 
            // btnProceedToPaymentMethod
            // 
            this.btnProceedToPaymentMethod.Location = new System.Drawing.Point(234, 360);
            this.btnProceedToPaymentMethod.Name = "btnProceedToPaymentMethod";
            this.btnProceedToPaymentMethod.Size = new System.Drawing.Size(81, 32);
            this.btnProceedToPaymentMethod.TabIndex = 13;
            this.btnProceedToPaymentMethod.Text = "다음";
            this.btnProceedToPaymentMethod.UseVisualStyleBackColor = true;
            // 
            // lblConfirmation2Title
            // 
            this.lblConfirmation2Title.AutoSize = true;
            this.lblConfirmation2Title.Font = new System.Drawing.Font("굴림", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblConfirmation2Title.Location = new System.Drawing.Point(95, 21);
            this.lblConfirmation2Title.Name = "lblConfirmation2Title";
            this.lblConfirmation2Title.Size = new System.Drawing.Size(129, 29);
            this.lblConfirmation2Title.TabIndex = 0;
            this.lblConfirmation2Title.Text = "결제방식";
            this.lblConfirmation2Title.Click += new System.EventHandler(this.lblConfirmation2Title_Click);
            // 
            // lblConfirmation2Subtitle
            // 
            this.lblConfirmation2Subtitle.AutoSize = true;
            this.lblConfirmation2Subtitle.Font = new System.Drawing.Font("굴림", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblConfirmation2Subtitle.Location = new System.Drawing.Point(14, 66);
            this.lblConfirmation2Subtitle.Name = "lblConfirmation2Subtitle";
            this.lblConfirmation2Subtitle.Size = new System.Drawing.Size(280, 21);
            this.lblConfirmation2Subtitle.TabIndex = 1;
            this.lblConfirmation2Subtitle.Text = "2. 결제방식을 선택해주세요.";
            // 
            // btnCardPayment
            // 
            this.btnCardPayment.Location = new System.Drawing.Point(27, 134);
            this.btnCardPayment.Name = "btnCardPayment";
            this.btnCardPayment.Size = new System.Drawing.Size(118, 83);
            this.btnCardPayment.TabIndex = 2;
            this.btnCardPayment.Text = "카드결제/삼성페이";
            this.btnCardPayment.UseVisualStyleBackColor = true;
            // 
            // btnKakaoPay
            // 
            this.btnKakaoPay.Location = new System.Drawing.Point(167, 134);
            this.btnKakaoPay.Name = "btnKakaoPay";
            this.btnKakaoPay.Size = new System.Drawing.Size(117, 83);
            this.btnKakaoPay.TabIndex = 3;
            this.btnKakaoPay.Text = "카카오페이";
            this.btnKakaoPay.UseVisualStyleBackColor = true;
            // 
            // btnNaverPay
            // 
            this.btnNaverPay.Location = new System.Drawing.Point(27, 259);
            this.btnNaverPay.Name = "btnNaverPay";
            this.btnNaverPay.Size = new System.Drawing.Size(118, 83);
            this.btnNaverPay.TabIndex = 4;
            this.btnNaverPay.Text = "네이버페이";
            this.btnNaverPay.UseVisualStyleBackColor = true;
            // 
            // btnBackToConfirmation1
            // 
            this.btnBackToConfirmation1.Location = new System.Drawing.Point(27, 405);
            this.btnBackToConfirmation1.Name = "btnBackToConfirmation1";
            this.btnBackToConfirmation1.Size = new System.Drawing.Size(80, 33);
            this.btnBackToConfirmation1.TabIndex = 5;
            this.btnBackToConfirmation1.Text = "뒤로가기";
            this.btnBackToConfirmation1.UseVisualStyleBackColor = true;
            // 
            // btnFinalizePayment
            // 
            this.btnFinalizePayment.Location = new System.Drawing.Point(204, 405);
            this.btnFinalizePayment.Name = "btnFinalizePayment";
            this.btnFinalizePayment.Size = new System.Drawing.Size(80, 33);
            this.btnFinalizePayment.TabIndex = 6;
            this.btnFinalizePayment.Text = "다음";
            this.btnFinalizePayment.UseVisualStyleBackColor = true;
            // 
            // lblPaymentSuccess
            // 
            this.lblPaymentSuccess.AutoSize = true;
            this.lblPaymentSuccess.Font = new System.Drawing.Font("맑은 고딕", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblPaymentSuccess.Location = new System.Drawing.Point(14, 177);
            this.lblPaymentSuccess.Name = "lblPaymentSuccess";
            this.lblPaymentSuccess.Size = new System.Drawing.Size(317, 40);
            this.lblPaymentSuccess.TabIndex = 0;
            this.lblPaymentSuccess.Text = "결제가 완료되었습니다";
            this.lblPaymentSuccess.Click += new System.EventHandler(this.lblPaymentSuccess_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(830, 946);
            this.Controls.Add(this.panelPlanSelection);
            this.Controls.Add(this.panelPaymentComplete);
            this.Controls.Add(this.panelConfirmation2);
            this.Controls.Add(this.panelConfirmation1);
            this.Name = "Form1";
            this.Text = "결제 시스템";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panelConfirmation1.ResumeLayout(false);
            this.panelConfirmation1.PerformLayout();
            this.panelConfirmation2.ResumeLayout(false);
            this.panelConfirmation2.PerformLayout();
            this.panelPaymentComplete.ResumeLayout(false);
            this.panelPaymentComplete.PerformLayout();
            this.panelPlanSelection.ResumeLayout(false);
            this.panelPlanSelection.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelConfirmation1;
        private System.Windows.Forms.Panel panelConfirmation2;
        private System.Windows.Forms.Panel panelPaymentComplete;
        private System.Windows.Forms.Panel panelPlanSelection;
        private System.Windows.Forms.Label lblPlanSelcetionTitle;
        private System.Windows.Forms.Button btnBackFromPlanSelection;
        private System.Windows.Forms.Button btnProceedToConfirmation;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelPlans;
        private System.Windows.Forms.Label lblConfirmation1Title;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblTotalAmountValue;
        private System.Windows.Forms.Label lblMileageEarnValue;
        private System.Windows.Forms.Label lblPlanInfoValue;
        private System.Windows.Forms.Label lblSeatInfoValue;
        private System.Windows.Forms.Label lblUserInfoValue;
        private System.Windows.Forms.Label lblTotalAmountLabel;
        private System.Windows.Forms.Label lblMileageEarnLabel;
        private System.Windows.Forms.Label lblPlanInfoLabel;
        private System.Windows.Forms.Label lblSeatInfoLabel;
        private System.Windows.Forms.Label lblUserInfoLabel;
        private System.Windows.Forms.Button btnProceedToPaymentMethod;
        private System.Windows.Forms.Button btnBackToPlanSelection;
        private System.Windows.Forms.Label lblConfirmation2Title;
        private System.Windows.Forms.Button btnFinalizePayment;
        private System.Windows.Forms.Button btnBackToConfirmation1;
        private System.Windows.Forms.Button btnNaverPay;
        private System.Windows.Forms.Button btnKakaoPay;
        private System.Windows.Forms.Button btnCardPayment;
        private System.Windows.Forms.Label lblConfirmation2Subtitle;
        private System.Windows.Forms.Label lblPaymentSuccess;
    }
}

