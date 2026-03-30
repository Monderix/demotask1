namespace ShoeStoreDemo
{
    partial class FormEditProduct
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.PictureBox pictureProduct;
        private System.Windows.Forms.Button btnLoadImage;

        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.TextBox txtId;

        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtName;

        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.ComboBox cmbCategory;

        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox txtDescription;

        private System.Windows.Forms.Label lblManufacturer;
        private System.Windows.Forms.ComboBox cmbManufacturer;

        private System.Windows.Forms.Label lblSupplier;
        private System.Windows.Forms.TextBox txtSupplier;

        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.TextBox txtPrice;

        private System.Windows.Forms.Label lblUnit;
        private System.Windows.Forms.TextBox txtUnit;

        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.TextBox txtQuantity;

        private System.Windows.Forms.Label lblDiscount;
        private System.Windows.Forms.TextBox txtDiscount;

        private System.Windows.Forms.Button btnSave;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormEditProduct));
            pictureProduct = new PictureBox();
            btnLoadImage = new Button();
            lblId = new Label();
            txtId = new TextBox();
            lblName = new Label();
            txtName = new TextBox();
            lblCategory = new Label();
            cmbCategory = new ComboBox();
            lblDescription = new Label();
            txtDescription = new TextBox();
            lblManufacturer = new Label();
            cmbManufacturer = new ComboBox();
            lblSupplier = new Label();
            txtSupplier = new TextBox();
            lblPrice = new Label();
            txtPrice = new TextBox();
            lblUnit = new Label();
            txtUnit = new TextBox();
            lblQuantity = new Label();
            txtQuantity = new TextBox();
            lblDiscount = new Label();
            txtDiscount = new TextBox();
            btnSave = new Button();
            btnBack = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureProduct).BeginInit();
            SuspendLayout();
            // 
            // pictureProduct
            // 
            pictureProduct.BorderStyle = BorderStyle.FixedSingle;
            pictureProduct.Location = new Point(20, 20);
            pictureProduct.Name = "pictureProduct";
            pictureProduct.Size = new Size(300, 200);
            pictureProduct.SizeMode = PictureBoxSizeMode.Zoom;
            pictureProduct.TabIndex = 0;
            pictureProduct.TabStop = false;
            // 
            // btnLoadImage
            // 
            btnLoadImage.Location = new Point(20, 230);
            btnLoadImage.Name = "btnLoadImage";
            btnLoadImage.Size = new Size(300, 30);
            btnLoadImage.TabIndex = 1;
            btnLoadImage.Text = "Загрузить изображение";
            btnLoadImage.Click += BtnLoadImage_Click;
            // 
            // lblId
            // 
            lblId.Location = new Point(350, 20);
            lblId.Name = "lblId";
            lblId.Size = new Size(100, 23);
            lblId.TabIndex = 2;
            lblId.Text = "ID товара";
            // 
            // txtId
            // 
            txtId.Location = new Point(350, 40);
            txtId.Name = "txtId";
            txtId.ReadOnly = true;
            txtId.Size = new Size(200, 23);
            txtId.TabIndex = 3;
            // 
            // lblName
            // 
            lblName.Location = new Point(350, 70);
            lblName.Name = "lblName";
            lblName.Size = new Size(100, 23);
            lblName.TabIndex = 4;
            lblName.Text = "Наименование";
            // 
            // txtName
            // 
            txtName.Location = new Point(350, 90);
            txtName.Name = "txtName";
            txtName.Size = new Size(300, 23);
            txtName.TabIndex = 5;
            // 
            // lblCategory
            // 
            lblCategory.Location = new Point(350, 120);
            lblCategory.Name = "lblCategory";
            lblCategory.Size = new Size(100, 23);
            lblCategory.TabIndex = 6;
            lblCategory.Text = "Категория";
            // 
            // cmbCategory
            // 
            cmbCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCategory.Location = new Point(350, 140);
            cmbCategory.Name = "cmbCategory";
            cmbCategory.Size = new Size(300, 23);
            cmbCategory.TabIndex = 7;
            // 
            // lblDescription
            // 
            lblDescription.Location = new Point(350, 170);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(100, 23);
            lblDescription.TabIndex = 8;
            lblDescription.Text = "Описание";
            // 
            // txtDescription
            // 
            txtDescription.Location = new Point(350, 190);
            txtDescription.Multiline = true;
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(300, 60);
            txtDescription.TabIndex = 9;
            // 
            // lblManufacturer
            // 
            lblManufacturer.Location = new Point(350, 260);
            lblManufacturer.Name = "lblManufacturer";
            lblManufacturer.Size = new Size(100, 23);
            lblManufacturer.TabIndex = 10;
            lblManufacturer.Text = "Производитель";
            // 
            // cmbManufacturer
            // 
            cmbManufacturer.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbManufacturer.Location = new Point(350, 280);
            cmbManufacturer.Name = "cmbManufacturer";
            cmbManufacturer.Size = new Size(300, 23);
            cmbManufacturer.TabIndex = 11;
            // 
            // lblSupplier
            // 
            lblSupplier.Location = new Point(350, 310);
            lblSupplier.Name = "lblSupplier";
            lblSupplier.Size = new Size(100, 23);
            lblSupplier.TabIndex = 12;
            lblSupplier.Text = "Поставщик";
            // 
            // txtSupplier
            // 
            txtSupplier.Location = new Point(350, 330);
            txtSupplier.Name = "txtSupplier";
            txtSupplier.Size = new Size(300, 23);
            txtSupplier.TabIndex = 13;
            // 
            // lblPrice
            // 
            lblPrice.Location = new Point(350, 360);
            lblPrice.Name = "lblPrice";
            lblPrice.Size = new Size(100, 23);
            lblPrice.TabIndex = 14;
            lblPrice.Text = "Цена";
            // 
            // txtPrice
            // 
            txtPrice.Location = new Point(350, 380);
            txtPrice.Name = "txtPrice";
            txtPrice.Size = new Size(140, 23);
            txtPrice.TabIndex = 15;
            // 
            // lblUnit
            // 
            lblUnit.Location = new Point(510, 360);
            lblUnit.Name = "lblUnit";
            lblUnit.Size = new Size(100, 23);
            lblUnit.TabIndex = 16;
            lblUnit.Text = "Ед. измерения";
            // 
            // txtUnit
            // 
            txtUnit.Location = new Point(510, 380);
            txtUnit.Name = "txtUnit";
            txtUnit.Size = new Size(140, 23);
            txtUnit.TabIndex = 17;
            // 
            // lblQuantity
            // 
            lblQuantity.Location = new Point(350, 410);
            lblQuantity.Name = "lblQuantity";
            lblQuantity.Size = new Size(100, 23);
            lblQuantity.TabIndex = 18;
            lblQuantity.Text = "Количество";
            // 
            // txtQuantity
            // 
            txtQuantity.Location = new Point(350, 430);
            txtQuantity.Name = "txtQuantity";
            txtQuantity.Size = new Size(140, 23);
            txtQuantity.TabIndex = 19;
            // 
            // lblDiscount
            // 
            lblDiscount.Location = new Point(510, 410);
            lblDiscount.Name = "lblDiscount";
            lblDiscount.Size = new Size(100, 23);
            lblDiscount.TabIndex = 20;
            lblDiscount.Text = "Скидка (%)";
            // 
            // txtDiscount
            // 
            txtDiscount.Location = new Point(510, 430);
            txtDiscount.Name = "txtDiscount";
            txtDiscount.Size = new Size(140, 23);
            txtDiscount.TabIndex = 21;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(0, 250, 154);
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Location = new Point(350, 480);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(150, 40);
            btnSave.TabIndex = 22;
            btnSave.Text = "Сохранить";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += BtnSave_Click;
            // 
            // btnBack
            // 
            btnBack.Location = new Point(510, 480);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(140, 40);
            btnBack.TabIndex = 23;
            btnBack.Text = "Назад";
            btnBack.Click += BtnBack_Click;
            // 
            // FormEditProduct
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.White;
            ClientSize = new Size(700, 550);
            Controls.Add(pictureProduct);
            Controls.Add(btnLoadImage);
            Controls.Add(lblId);
            Controls.Add(txtId);
            Controls.Add(lblName);
            Controls.Add(txtName);
            Controls.Add(lblCategory);
            Controls.Add(cmbCategory);
            Controls.Add(lblDescription);
            Controls.Add(txtDescription);
            Controls.Add(lblManufacturer);
            Controls.Add(cmbManufacturer);
            Controls.Add(lblSupplier);
            Controls.Add(txtSupplier);
            Controls.Add(lblPrice);
            Controls.Add(txtPrice);
            Controls.Add(lblUnit);
            Controls.Add(txtUnit);
            Controls.Add(lblQuantity);
            Controls.Add(txtQuantity);
            Controls.Add(lblDiscount);
            Controls.Add(txtDiscount);
            Controls.Add(btnSave);
            Controls.Add(btnBack);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FormEditProduct";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Добавление / редактирование товара";
            ((System.ComponentModel.ISupportInitialize)pictureProduct).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
    }
}
