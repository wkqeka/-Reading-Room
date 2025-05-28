namespace WindowsFormsApp1
{
    partial class SeatStatusForm
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
            this.lblSeatId = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblPurpose = new System.Windows.Forms.Label();
            this.btnPayment = new System.Windows.Forms.Button();
            this.btnReserve = new System.Windows.Forms.Button();
            this.lblReservedTime = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblSeatId
            // 
            this.lblSeatId.AutoSize = true;
            this.lblSeatId.Font = new System.Drawing.Font("맑은 고딕", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblSeatId.Location = new System.Drawing.Point(32, 40);
            this.lblSeatId.Name = "lblSeatId";
            this.lblSeatId.Size = new System.Drawing.Size(94, 37);
            this.lblSeatId.TabIndex = 0;
            this.lblSeatId.Text = "label1";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("맑은 고딕", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblStatus.Location = new System.Drawing.Point(32, 114);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(94, 37);
            this.lblStatus.TabIndex = 1;
            this.lblStatus.Text = "label2";
            // 
            // lblPurpose
            // 
            this.lblPurpose.AutoSize = true;
            this.lblPurpose.Font = new System.Drawing.Font("맑은 고딕", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblPurpose.Location = new System.Drawing.Point(32, 202);
            this.lblPurpose.Name = "lblPurpose";
            this.lblPurpose.Size = new System.Drawing.Size(94, 37);
            this.lblPurpose.TabIndex = 2;
            this.lblPurpose.Text = "label3";
            // 
            // btnPayment
            // 
            this.btnPayment.Font = new System.Drawing.Font("맑은 고딕", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnPayment.Location = new System.Drawing.Point(12, 376);
            this.btnPayment.Name = "btnPayment";
            this.btnPayment.Size = new System.Drawing.Size(114, 62);
            this.btnPayment.TabIndex = 3;
            this.btnPayment.Text = "결제";
            this.btnPayment.UseVisualStyleBackColor = true;
            this.btnPayment.Click += new System.EventHandler(this.btnPayment_Click);
            // 
            // btnReserve
            // 
            this.btnReserve.Font = new System.Drawing.Font("맑은 고딕", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnReserve.Location = new System.Drawing.Point(239, 373);
            this.btnReserve.Name = "btnReserve";
            this.btnReserve.Size = new System.Drawing.Size(114, 62);
            this.btnReserve.TabIndex = 4;
            this.btnReserve.Text = "예약";
            this.btnReserve.UseVisualStyleBackColor = true;
            this.btnReserve.Click += new System.EventHandler(this.btnReserve_Click);
            // 
            // lblReservedTime
            // 
            this.lblReservedTime.AutoSize = true;
            this.lblReservedTime.Font = new System.Drawing.Font("맑은 고딕", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblReservedTime.Location = new System.Drawing.Point(32, 239);
            this.lblReservedTime.Name = "lblReservedTime";
            this.lblReservedTime.Size = new System.Drawing.Size(94, 37);
            this.lblReservedTime.TabIndex = 5;
            this.lblReservedTime.Text = "label3";
            // 
            // SeatStatusForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(365, 447);
            this.Controls.Add(this.lblReservedTime);
            this.Controls.Add(this.btnReserve);
            this.Controls.Add(this.btnPayment);
            this.Controls.Add(this.lblPurpose);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.lblSeatId);
            this.Name = "SeatStatusForm";
            this.Text = "Form2";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSeatId;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblPurpose;
        private System.Windows.Forms.Button btnPayment;
        private System.Windows.Forms.Button btnReserve;
        private System.Windows.Forms.Label lblReservedTime;
    }
}