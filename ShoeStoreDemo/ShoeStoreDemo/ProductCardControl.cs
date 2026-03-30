using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace ShoeStoreDemo
{
    public partial class ProductCardControl : UserControl
    {
        // ИДЕНТИФИКАТОРЫ
        private string articleId;
        private string imagePath;

        // СОБЫТИЯ
        public event Action<string> EditClicked;
        public event Action<string, string> DeleteClicked;

        public ProductCardControl()
        {
            InitializeComponent();

            btnEdit.Click += BtnEdit_Click;
            btnDelete.Click += BtnDelete_Click;
        }

        // ОСНОВНОЙ МЕТОД 

        public void SetProduct(
            string articleId,
            string category,
            string name,
            string description,
            string manufacturer,
            string supplier,
            decimal price,
            int discount,
            string unit,
            int quantity,
            string imagePath)
        {
            this.articleId = articleId;
            this.imagePath = imagePath;

            //  ЗАГОЛОВОК 
            lblTitle.Text = $"{category} | {name}";
            lblDescription.Text = $"Описание: {description}";

            // ХАРАКТЕРИСТИКИ 
            lblManufacturer.Text = $"Производитель: {manufacturer}";
            lblSupplier.Text = $"Поставщик: {supplier}";
            lblUnit.Text = $"Ед. изм.: {unit}";
            lblQuantity.Text = $"На складе: {quantity}";

            // если товара нет 
            if (quantity == 0)
            {
                lblQuantity.BackColor = Color.LightBlue;
                lblQuantity.Font = new Font(lblQuantity.Font, FontStyle.Bold);
            }
            else
            {
                lblQuantity.BackColor = Color.Transparent;
                lblQuantity.Font = new Font(lblQuantity.Font, FontStyle.Regular);
            }

            // ЦЕНА 
            lblFinalPrice.Text = string.Empty;

            if (discount > 0)
            {
                decimal finalPrice = price - (price * discount / 100);

                lblPrice.Text = $"Цена: {price} ₽";
                lblPrice.ForeColor = Color.Red;
                lblPrice.Font = new Font(lblPrice.Font, FontStyle.Strikeout);

                // итоговая цена рядом
                lblFinalPrice.Text = $"{finalPrice} ₽";
                lblFinalPrice.ForeColor = Color.Black;

                lblFinalPrice.Left = lblPrice.Right + 6;
                lblFinalPrice.Top = lblPrice.Top;
            }
            else
            {
                lblPrice.Text = $"Цена: {price} ₽";
                lblPrice.ForeColor = Color.Black;
                lblPrice.Font = new Font(lblPrice.Font, FontStyle.Regular);
            }

            //  СКИДКА 
            lblDiscount.Text = discount > 0 ? $"-{discount}%" : "0%";

            if (discount > 15)
                panelDiscount.BackColor = ColorTranslator.FromHtml("#2E8B57");
            else if (discount > 0)
                panelDiscount.BackColor = ColorTranslator.FromHtml("#7FFF00");
            else
                panelDiscount.BackColor = Color.LightGray;

            // КАРТИНКА 
            LoadImage(imagePath);
        }

        // ЗАГРУЗКА КАРТИНКИ

        private void LoadImage(string path)
        {
            try
            {
                if (!string.IsNullOrEmpty(path) && File.Exists(path))
                    pictureProduct.Image = Image.FromFile(path);
                else
                    pictureProduct.Image = Properties.Resources.picture;
            }
            catch
            {
                pictureProduct.Image = Properties.Resources.picture;
            }
        }

        // КНОПКИ 

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            EditClicked?.Invoke(articleId);
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            DeleteClicked?.Invoke(articleId, imagePath);
        }

        // УПРАВЛЕНИЕ ДОСТУПОМ

        public void SetAdminControlsVisible(bool visible)
        {
            btnEdit.Visible = visible;
            btnDelete.Visible = visible;
        }
    }
}