namespace ShoeStoreDemo
{
    partial class FormOrders
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnAddOrder;

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelOrders;
        private System.Windows.Forms.Button btnBack;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormOrders));
            panelTop = new Panel();
            lblTitle = new Label();
            btnAddOrder = new Button();
            flowLayoutPanelOrders = new FlowLayoutPanel();
            btnBack = new Button();
            panelTop.SuspendLayout();
            SuspendLayout();
            // 
            // panelTop
            // 
            panelTop.BackColor = Color.White;
            panelTop.Controls.Add(lblTitle);
            panelTop.Controls.Add(btnAddOrder);
            panelTop.Dock = DockStyle.Top;
            panelTop.Location = new Point(0, 0);
            panelTop.Name = "panelTop";
            panelTop.Padding = new Padding(10);
            panelTop.Size = new Size(984, 60);
            panelTop.TabIndex = 1;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitle.Location = new Point(10, 15);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(78, 25);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Заказы";
            // 
            // btnAddOrder
            // 
            btnAddOrder.BackColor = Color.FromArgb(0, 250, 154);
            btnAddOrder.FlatStyle = FlatStyle.Flat;
            btnAddOrder.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnAddOrder.Location = new Point(800, 15);
            btnAddOrder.Name = "btnAddOrder";
            btnAddOrder.Size = new Size(160, 30);
            btnAddOrder.TabIndex = 1;
            btnAddOrder.Text = "+ Добавить заказ";
            btnAddOrder.UseVisualStyleBackColor = false;
            btnAddOrder.Click += BtnAddOrder_Click;
            // 
            // flowLayoutPanelOrders
            // 
            flowLayoutPanelOrders.AutoScroll = true;
            flowLayoutPanelOrders.BackColor = Color.White;
            flowLayoutPanelOrders.Dock = DockStyle.Fill;
            flowLayoutPanelOrders.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanelOrders.Location = new Point(0, 60);
            flowLayoutPanelOrders.Name = "flowLayoutPanelOrders";
            flowLayoutPanelOrders.Padding = new Padding(10);
            flowLayoutPanelOrders.Size = new Size(984, 551);
            flowLayoutPanelOrders.TabIndex = 0;
            flowLayoutPanelOrders.WrapContents = false;
            // 
            // btnBack
            // 
            btnBack.BackColor = Color.FromArgb(127, 255, 0);
            btnBack.Dock = DockStyle.Bottom;
            btnBack.FlatStyle = FlatStyle.Flat;
            btnBack.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnBack.Location = new Point(0, 611);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(984, 40);
            btnBack.TabIndex = 2;
            btnBack.Text = "Назад";
            btnBack.UseVisualStyleBackColor = false;
            btnBack.Click += BtnBack_Click;
            // 
            // FormOrders
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.White;
            ClientSize = new Size(984, 651);
            Controls.Add(flowLayoutPanelOrders);
            Controls.Add(panelTop);
            Controls.Add(btnBack);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FormOrders";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Заказы";
            WindowState = FormWindowState.Maximized;
            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
    }
}
