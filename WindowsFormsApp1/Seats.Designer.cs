namespace WindowsFormsApp1
{
    partial class Seats
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
            this.btnSeat1 = new System.Windows.Forms.Button();
            this.btnSeat2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSeat3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnSeat1
            // 
            this.btnSeat1.Font = new System.Drawing.Font("맑은 고딕", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnSeat1.Location = new System.Drawing.Point(774, 224);
            this.btnSeat1.Name = "btnSeat1";
            this.btnSeat1.Size = new System.Drawing.Size(142, 83);
            this.btnSeat1.TabIndex = 0;
            this.btnSeat1.Text = "button1";
            this.btnSeat1.UseVisualStyleBackColor = true;
            // 
            // btnSeat2
            // 
            this.btnSeat2.Font = new System.Drawing.Font("맑은 고딕", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnSeat2.Location = new System.Drawing.Point(476, 224);
            this.btnSeat2.Name = "btnSeat2";
            this.btnSeat2.Size = new System.Drawing.Size(142, 83);
            this.btnSeat2.TabIndex = 1;
            this.btnSeat2.Text = "button2";
            this.btnSeat2.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("맑은 고딕", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(353, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(183, 50);
            this.label1.TabIndex = 2;
            this.label1.Text = "자리 현황";
            // 
            // btnSeat3
            // 
            this.btnSeat3.Font = new System.Drawing.Font("맑은 고딕", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnSeat3.Location = new System.Drawing.Point(328, 224);
            this.btnSeat3.Name = "btnSeat3";
            this.btnSeat3.Size = new System.Drawing.Size(142, 83);
            this.btnSeat3.TabIndex = 3;
            this.btnSeat3.Text = "button1";
            this.btnSeat3.UseVisualStyleBackColor = true;
            // 
            // Seats
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(928, 575);
            this.Controls.Add(this.btnSeat3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSeat2);
            this.Controls.Add(this.btnSeat1);
            this.Name = "Seats";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSeat1;
        private System.Windows.Forms.Button btnSeat2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSeat3;
    }
}

