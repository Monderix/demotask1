namespace ShoeStoreDemo
{
    partial class ProductCardControl
    {
        private System.ComponentModel.IContainer components = null;

        private PictureBox pictureProduct;
        private Panel panelInfo;
        private Label lblTitle;
        private Label lblDescription;
        private Label lblManufacturer;
        private Label lblSupplier;
        private Label lblUnit;
        private Label lblQuantity;
        private Label lblPrice;
        private Label lblFinalPrice;

        private Panel panelDiscount;
        private Label lblDiscount;

        private Button btnEdit;
        private Button btnDelete;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }

        #region Component Designer generated code

        private void InitializeComponent()
        {
            pictureProduct = new PictureBox();
            panelInfo = new Panel();
            lblTitle = new Label();
            lblDescription = new Label();
            lblManufacturer = new Label();
            lblSupplier = new Label();
            lblUnit = new Label();
            lblQuantity = new Label();
            lblPrice = new Label();
            lblFinalPrice = new Label();
            btnEdit = new Button();
            btnDelete = new Button();
            panelDiscount = new Panel();
            lblDiscount = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureProduct).BeginInit();
            panelInfo.SuspendLayout();
            panelDiscount.SuspendLayout();
            SuspendLayout();
            // 
            // pictureProduct
            // 
            pictureProduct.Location = new Point(10, 20);
            pictureProduct.Name = "pictureProduct";
            pictureProduct.Size = new Size(180, 180);
            pictureProduct.SizeMode = PictureBoxSizeMode.Zoom;
            pictureProduct.TabIndex = 0;
            pictureProduct.TabStop = false;
            // 
            // panelInfo
            // 
            panelInfo.Controls.Add(lblTitle);
            panelInfo.Controls.Add(lblDescription);
            panelInfo.Controls.Add(lblManufacturer);
            panelInfo.Controls.Add(lblSupplier);
            panelInfo.Controls.Add(lblUnit);
            panelInfo.Controls.Add(lblQuantity);
            panelInfo.Controls.Add(lblPrice);
            panelInfo.Controls.Add(lblFinalPrice);
            panelInfo.Controls.Add(btnEdit);
            panelInfo.Controls.Add(btnDelete);
            panelInfo.Location = new Point(200, 10);
            panelInfo.Name = "panelInfo";
            panelInfo.Size = new Size(540, 240);
            panelInfo.TabIndex = 1;
            // 
            // lblTitle
            // 
            lblTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblTitle.Location = new Point(0, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(540, 25);
            lblTitle.TabIndex = 0;
            // 
            // lblDescription
            // 
            lblDescription.Location = new Point(0, 30);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(540, 40);
            lblDescription.TabIndex = 1;
            // 
            // lblManufacturer
            // 
            lblManufacturer.Location = new Point(0, 75);
            lblManufacturer.Name = "lblManufacturer";
            lblManufacturer.Size = new Size(540, 20);
            lblManufacturer.TabIndex = 2;
            // 
            // lblSupplier
            // 
            lblSupplier.Location = new Point(0, 95);
            lblSupplier.Name = "lblSupplier";
            lblSupplier.Size = new Size(540, 20);
            lblSupplier.TabIndex = 3;
            // 
            // lblUnit
            // 
            lblUnit.Location = new Point(0, 115);
            lblUnit.Name = "lblUnit";
            lblUnit.Size = new Size(270, 20);
            lblUnit.TabIndex = 4;
            // 
            // lblQuantity
            // 
            lblQuantity.Location = new Point(0, 172);
            lblQuantity.Name = "lblQuantity";
            lblQuantity.Size = new Size(270, 20);
            lblQuantity.TabIndex = 5;
            // 
            // lblPrice
            // 
            lblPrice.Location = new Point(0, 140);
            lblPrice.Name = "lblPrice";
            lblPrice.Size = new Size(270, 20);
            lblPrice.TabIndex = 6;
            // 
            // lblFinalPrice
            // 
            lblFinalPrice.Location = new Point(148, 140);
            lblFinalPrice.Name = "lblFinalPrice";
            lblFinalPrice.Size = new Size(270, 20);
            lblFinalPrice.TabIndex = 7;
            // 
            // btnEdit
            // 
            btnEdit.BackColor = Color.FromArgb(0, 250, 154);
            btnEdit.FlatStyle = FlatStyle.Flat;
            btnEdit.Location = new Point(0, 195);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(120, 30);
            btnEdit.TabIndex = 8;
            btnEdit.Text = "Редактировать";
            btnEdit.UseVisualStyleBackColor = false;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.FromArgb(0, 250, 154);
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Location = new Point(126, 195);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(120, 30);
            btnDelete.TabIndex = 9;
            btnDelete.Text = "Удалить";
            btnDelete.UseVisualStyleBackColor = false;
            // 
            // panelDiscount
            // 
            panelDiscount.BorderStyle = BorderStyle.FixedSingle;
            panelDiscount.Controls.Add(lblDiscount);
            panelDiscount.Location = new Point(820, 70);
            panelDiscount.Name = "panelDiscount";
            panelDiscount.Size = new Size(120, 120);
            panelDiscount.TabIndex = 2;
            // 
            // lblDiscount
            // 
            lblDiscount.Dock = DockStyle.Fill;
            lblDiscount.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblDiscount.Location = new Point(0, 0);
            lblDiscount.Name = "lblDiscount";
            lblDiscount.Size = new Size(118, 118);
            lblDiscount.TabIndex = 0;
            lblDiscount.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // ProductCardControl
            // 
            BackColor = Color.White;
            BorderStyle = BorderStyle.FixedSingle;
            Controls.Add(pictureProduct);
            Controls.Add(panelInfo);
            Controls.Add(panelDiscount);
            Margin = new Padding(5);
            Name = "ProductCardControl";
            Size = new Size(960, 260);
            ((System.ComponentModel.ISupportInitialize)pictureProduct).EndInit();
            panelInfo.ResumeLayout(false);
            panelDiscount.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
    }
}
