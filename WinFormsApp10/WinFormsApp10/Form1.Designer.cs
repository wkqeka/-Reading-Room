namespace ReadingRoomApp
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelSeats;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.flowLayoutPanelSeats = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();

            // 
            // flowLayoutPanelSeats
            // 
            this.flowLayoutPanelSeats.AutoScroll = true;
            this.flowLayoutPanelSeats.Location = new System.Drawing.Point(12, 12);
            this.flowLayoutPanelSeats.Name = "flowLayoutPanelSeats";
            this.flowLayoutPanelSeats.Size = new System.Drawing.Size(600, 400);
            this.flowLayoutPanelSeats.TabIndex = 0;

            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(624, 421);
            this.Controls.Add(this.flowLayoutPanelSeats);
            this.Name = "Form1";
            this.Text = "독서실 좌석 조회";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
        }
    }
}
