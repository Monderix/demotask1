namespace ShoeStoreDemo
{
    partial class FormEditOrder
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblOrderNumber;
        private System.Windows.Forms.TextBox txtOrderNumber;

        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ComboBox cmbStatus;

        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.ComboBox cmbAddress;

        private System.Windows.Forms.Label lblOrderDate;
        private System.Windows.Forms.DateTimePicker dtpOrderDate;

        private System.Windows.Forms.Label lblDeliveryDate;
        private System.Windows.Forms.DateTimePicker dtpDeliveryDate;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormEditOrder));
            lblOrderNumber = new Label();
            txtOrderNumber = new TextBox();
            lblStatus = new Label();
            cmbStatus = new ComboBox();
            lblAddress = new Label();
            cmbAddress = new ComboBox();
            lblOrderDate = new Label();
            dtpOrderDate = new DateTimePicker();
            lblDeliveryDate = new Label();
            dtpDeliveryDate = new DateTimePicker();
            btnSave = new Button();
            btnBack = new Button();
            SuspendLayout();
            // 
            // lblOrderNumber
            // 
            lblOrderNumber.AutoSize = true;
            lblOrderNumber.Location = new Point(30, 20);
            lblOrderNumber.Name = "lblOrderNumber";
            lblOrderNumber.Size = new Size(90, 15);
            lblOrderNumber.TabIndex = 0;
            lblOrderNumber.Text = "Артикул заказа";
            // 
            // txtOrderNumber
            // 
            txtOrderNumber.Location = new Point(30, 40);
            txtOrderNumber.Name = "txtOrderNumber";
            txtOrderNumber.ReadOnly = true;
            txtOrderNumber.Size = new Size(200, 23);
            txtOrderNumber.TabIndex = 1;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Location = new Point(30, 75);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(80, 15);
            lblStatus.TabIndex = 2;
            lblStatus.Text = "Статус заказа";
            // 
            // cmbStatus
            // 
            cmbStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbStatus.Location = new Point(30, 95);
            cmbStatus.Name = "cmbStatus";
            cmbStatus.Size = new Size(300, 23);
            cmbStatus.TabIndex = 3;
            // 
            // lblAddress
            // 
            lblAddress.AutoSize = true;
            lblAddress.Location = new Point(30, 130);
            lblAddress.Name = "lblAddress";
            lblAddress.Size = new Size(84, 15);
            lblAddress.TabIndex = 4;
            lblAddress.Text = "Пункт выдачи";
            // 
            // cmbAddress
            // 
            cmbAddress.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbAddress.Location = new Point(30, 150);
            cmbAddress.Name = "cmbAddress";
            cmbAddress.Size = new Size(300, 23);
            cmbAddress.TabIndex = 5;
            // 
            // lblOrderDate
            // 
            lblOrderDate.AutoSize = true;
            lblOrderDate.Location = new Point(30, 185);
            lblOrderDate.Name = "lblOrderDate";
            lblOrderDate.Size = new Size(69, 15);
            lblOrderDate.TabIndex = 6;
            lblOrderDate.Text = "Дата заказа";
            // 
            // dtpOrderDate
            // 
            dtpOrderDate.Format = DateTimePickerFormat.Short;
            dtpOrderDate.Location = new Point(30, 205);
            dtpOrderDate.Name = "dtpOrderDate";
            dtpOrderDate.Size = new Size(200, 23);
            dtpOrderDate.TabIndex = 7;
            // 
            // lblDeliveryDate
            // 
            lblDeliveryDate.AutoSize = true;
            lblDeliveryDate.Location = new Point(30, 240);
            lblDeliveryDate.Name = "lblDeliveryDate";
            lblDeliveryDate.Size = new Size(76, 15);
            lblDeliveryDate.TabIndex = 8;
            lblDeliveryDate.Text = "Дата выдачи";
            // 
            // dtpDeliveryDate
            // 
            dtpDeliveryDate.Format = DateTimePickerFormat.Short;
            dtpDeliveryDate.Location = new Point(30, 260);
            dtpDeliveryDate.Name = "dtpDeliveryDate";
            dtpDeliveryDate.Size = new Size(200, 23);
            dtpDeliveryDate.TabIndex = 9;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(0, 250, 154);
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnSave.Location = new Point(30, 320);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(140, 35);
            btnSave.TabIndex = 10;
            btnSave.Text = "Сохранить";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += BtnSave_Click;
            // 
            // btnBack
            // 
            btnBack.BackColor = Color.FromArgb(127, 255, 0);
            btnBack.FlatStyle = FlatStyle.Flat;
            btnBack.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnBack.Location = new Point(190, 320);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(140, 35);
            btnBack.TabIndex = 11;
            btnBack.Text = "Назад";
            btnBack.UseVisualStyleBackColor = false;
            btnBack.Click += BtnBack_Click;
            // 
            // FormEditOrder
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.White;
            ClientSize = new Size(380, 380);
            Controls.Add(lblOrderNumber);
            Controls.Add(txtOrderNumber);
            Controls.Add(lblStatus);
            Controls.Add(cmbStatus);
            Controls.Add(lblAddress);
            Controls.Add(cmbAddress);
            Controls.Add(lblOrderDate);
            Controls.Add(dtpOrderDate);
            Controls.Add(lblDeliveryDate);
            Controls.Add(dtpDeliveryDate);
            Controls.Add(btnSave);
            Controls.Add(btnBack);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FormEditOrder";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Добавление / редактирование заказа";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
    }
}
