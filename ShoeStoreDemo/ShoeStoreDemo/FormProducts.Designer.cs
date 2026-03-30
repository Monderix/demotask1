namespace ShoeStoreDemo
{
    partial class FormProducts
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel panelTop;

        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.TextBox txtSearch;

        private System.Windows.Forms.Label lblSupplier;
        private System.Windows.Forms.ComboBox cmbSupplier;

        private System.Windows.Forms.Label lblSort;
        private System.Windows.Forms.ComboBox cmbSort;

        private System.Windows.Forms.Button btnAddProduct;
        private System.Windows.Forms.Button btnOrders;

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelProducts;
        private System.Windows.Forms.Button btnExit;

        private System.Windows.Forms.PictureBox pictureBoxIcon;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormProducts));
            panelTop = new Panel();
            pictureBoxIcon = new PictureBox();
            lblSearch = new Label();
            txtSearch = new TextBox();
            lblSupplier = new Label();
            cmbSupplier = new ComboBox();
            lblSort = new Label();
            cmbSort = new ComboBox();
            btnAddProduct = new Button();
            btnOrders = new Button();
            flowLayoutPanelProducts = new FlowLayoutPanel();
            btnExit = new Button();
            panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxIcon).BeginInit();
            SuspendLayout();
            // 
            // panelTop
            // 
            panelTop.BackColor = Color.White;
            panelTop.Controls.Add(pictureBoxIcon);
            panelTop.Controls.Add(lblSearch);
            panelTop.Controls.Add(txtSearch);
            panelTop.Controls.Add(lblSupplier);
            panelTop.Controls.Add(cmbSupplier);
            panelTop.Controls.Add(lblSort);
            panelTop.Controls.Add(cmbSort);
            panelTop.Controls.Add(btnAddProduct);
            panelTop.Controls.Add(btnOrders);
            panelTop.Dock = DockStyle.Top;
            panelTop.Location = new Point(0, 0);
            panelTop.Name = "panelTop";
            panelTop.Padding = new Padding(10);
            panelTop.Size = new Size(984, 90);
            panelTop.TabIndex = 1;
            // 
            // pictureBoxIcon
            // 
            pictureBoxIcon.Image = Properties.Resources.Icon;
            pictureBoxIcon.Location = new Point(940, 10);
            pictureBoxIcon.Name = "pictureBoxIcon";
            pictureBoxIcon.Size = new Size(32, 30);
            pictureBoxIcon.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxIcon.TabIndex = 0;
            pictureBoxIcon.TabStop = false;
            // 
            // lblSearch
            // 
            lblSearch.AutoSize = true;
            lblSearch.Location = new Point(10, 10);
            lblSearch.Name = "lblSearch";
            lblSearch.Size = new Size(42, 15);
            lblSearch.TabIndex = 1;
            lblSearch.Text = "Поиск";
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(10, 28);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(250, 23);
            txtSearch.TabIndex = 2;
            txtSearch.TextChanged += FiltersChanged;
            // 
            // lblSupplier
            // 
            lblSupplier.AutoSize = true;
            lblSupplier.Location = new Point(280, 10);
            lblSupplier.Name = "lblSupplier";
            lblSupplier.Size = new Size(70, 15);
            lblSupplier.TabIndex = 3;
            lblSupplier.Text = "Поставщик";
            // 
            // cmbSupplier
            // 
            cmbSupplier.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbSupplier.Location = new Point(280, 28);
            cmbSupplier.Name = "cmbSupplier";
            cmbSupplier.Size = new Size(200, 23);
            cmbSupplier.TabIndex = 4;
            cmbSupplier.SelectedIndexChanged += FiltersChanged;
            // 
            // lblSort
            // 
            lblSort.AutoSize = true;
            lblSort.Location = new Point(500, 10);
            lblSort.Name = "lblSort";
            lblSort.Size = new Size(73, 15);
            lblSort.TabIndex = 5;
            lblSort.Text = "Сортировка";
            // 
            // cmbSort
            // 
            cmbSort.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbSort.Items.AddRange(new object[] { "Без сортировки", "По количеству (возрастание)", "По количеству (убывание)" });
            cmbSort.Location = new Point(500, 28);
            cmbSort.Name = "cmbSort";
            cmbSort.Size = new Size(250, 23);
            cmbSort.TabIndex = 6;
            cmbSort.SelectedIndexChanged += FiltersChanged;
            // 
            // btnAddProduct
            // 
            btnAddProduct.BackColor = Color.FromArgb(0, 250, 154);
            btnAddProduct.FlatStyle = FlatStyle.Flat;
            btnAddProduct.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnAddProduct.Location = new Point(770, 28);
            btnAddProduct.Name = "btnAddProduct";
            btnAddProduct.Size = new Size(160, 30);
            btnAddProduct.TabIndex = 7;
            btnAddProduct.Text = "+ Добавить товар";
            btnAddProduct.UseVisualStyleBackColor = false;
            btnAddProduct.Click += BtnAddProduct_Click;
            // 
            // btnOrders
            // 
            btnOrders.BackColor = Color.FromArgb(127, 255, 0);
            btnOrders.FlatStyle = FlatStyle.Flat;
            btnOrders.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnOrders.Location = new Point(10, 57);
            btnOrders.Name = "btnOrders";
            btnOrders.Size = new Size(120, 30);
            btnOrders.TabIndex = 8;
            btnOrders.Text = "Заказы";
            btnOrders.UseVisualStyleBackColor = false;
            btnOrders.Click += BtnOrders_Click;
            // 
            // flowLayoutPanelProducts
            // 
            flowLayoutPanelProducts.AutoScroll = true;
            flowLayoutPanelProducts.BackColor = Color.White;
            flowLayoutPanelProducts.Dock = DockStyle.Fill;
            flowLayoutPanelProducts.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanelProducts.Location = new Point(0, 90);
            flowLayoutPanelProducts.Name = "flowLayoutPanelProducts";
            flowLayoutPanelProducts.Padding = new Padding(10);
            flowLayoutPanelProducts.Size = new Size(984, 521);
            flowLayoutPanelProducts.TabIndex = 0;
            flowLayoutPanelProducts.WrapContents = false;
            // 
            // btnExit
            // 
            btnExit.BackColor = Color.FromArgb(0, 250, 154);
            btnExit.Dock = DockStyle.Bottom;
            btnExit.FlatStyle = FlatStyle.Flat;
            btnExit.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnExit.Location = new Point(0, 611);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(984, 40);
            btnExit.TabIndex = 2;
            btnExit.Text = "Выйти";
            btnExit.UseVisualStyleBackColor = false;
            btnExit.Click += BtnExit_Click;
            // 
            // FormProducts
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.White;
            ClientSize = new Size(984, 651);
            Controls.Add(flowLayoutPanelProducts);
            Controls.Add(panelTop);
            Controls.Add(btnExit);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FormProducts";
            StartPosition = FormStartPosition.CenterScreen;
            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxIcon).EndInit();
            ResumeLayout(false);
        }

        #endregion
    }
}