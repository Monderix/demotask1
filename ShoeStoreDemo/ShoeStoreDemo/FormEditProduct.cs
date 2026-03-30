using Npgsql;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace ShoeStoreDemo
{
    public partial class FormEditProduct : Form
    {
        private readonly string connectionString =
            "Host=localhost;Port=5432;Database=demo2026;Username=postgres;Password=5696";

        private bool isEditMode;
        private string currentArticleId;
        private string oldImagePath;

        private static bool isFormOpen = false;

        //  КОНСТРУКТОРЫ=

        // Добавление товара
        public FormEditProduct()
        {
            if (isFormOpen)
            {
                MessageBox.Show(
                    "Окно добавления/редактирования уже открыто.",
                    "Ограничение",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                Close();
                return;
            }

            isFormOpen = true;
            InitializeComponent();

            isEditMode = false;
            Text = "Добавление товара";

            InitializeForm();
        }

        // Редактирование товара
        public FormEditProduct(string articleId)
        {
            if (isFormOpen)
            {
                MessageBox.Show(
                    "Окно добавления/редактирования уже открыто.",
                    "Ограничение",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                Close();
                return;
            }

            isFormOpen = true;
            InitializeComponent();

            isEditMode = true;
            currentArticleId = articleId;
            Text = "Редактирование товара";

            InitializeForm();
            LoadProduct();
        }

        //  ИНИЦИАЛИЗАЦИЯ

        private void InitializeForm()
        {
            LoadCategories();
            LoadManufacturers();

            pictureProduct.Image = Image.FromFile(
                Path.Combine(Application.StartupPath, "picture.png")
            );

            if (!isEditMode)
            {
                txtId.Visible = false;
                lblId.Visible = false;
            }
        }

        private void LoadCategories()
        {
            cmbCategory.Items.Clear();

            using var connection = new NpgsqlConnection(connectionString);
            connection.Open();

            string query = "SELECT category_pk FROM category ORDER BY category_pk";
            using var cmd = new NpgsqlCommand(query, connection);
            using var reader = cmd.ExecuteReader();

            while (reader.Read())
                cmbCategory.Items.Add(reader.GetString(0));

            if (cmbCategory.Items.Count > 0)
                cmbCategory.SelectedIndex = 0;
        }

        private void LoadManufacturers()
        {
            cmbManufacturer.Items.Clear();

            using var connection = new NpgsqlConnection(connectionString);
            connection.Open();

            string query = "SELECT proizvoditel_pk FROM proizvoditel ORDER BY proizvoditel_pk";
            using var cmd = new NpgsqlCommand(query, connection);
            using var reader = cmd.ExecuteReader();

            while (reader.Read())
                cmbManufacturer.Items.Add(reader.GetString(0));

            if (cmbManufacturer.Items.Count > 0)
                cmbManufacturer.SelectedIndex = 0;
        }

        // ЗАГРУЗКА ТОВАРА 

        private void LoadProduct()
        {
            using var connection = new NpgsqlConnection(connectionString);
            connection.Open();

            string query = @"
                SELECT 
                    t.id_article,
                    nt.name_tovar_pk,
                    c.category_pk,
                    t.opisanie,
                    pr.proizvoditel_pk,
                    ps.postavshik_pk,
                    t.sale,
                    t.edinitca_izm,
                    t.quantity,
                    t.discount,
                    t.picture
                FROM tovar t
                JOIN name_tovar nt ON t.name_tovar_fk = nt.id
                JOIN category c ON t.category_fk = c.id
                JOIN proizvoditel pr ON t.proizvoditel_fk = pr.id
                JOIN postavshik ps ON t.postavshik_fk = ps.id
                WHERE t.id_article = @id
            ";

            using var cmd = new NpgsqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@id", currentArticleId);

            using var reader = cmd.ExecuteReader();
            if (!reader.Read()) return;

            txtId.Text = reader["id_article"].ToString();
            txtName.Text = reader["name_tovar_pk"].ToString();
            cmbCategory.SelectedItem = reader["category_pk"].ToString();
            txtDescription.Text = reader["opisanie"].ToString();
            cmbManufacturer.SelectedItem = reader["proizvoditel_pk"].ToString();
            txtSupplier.Text = reader["postavshik_pk"].ToString();
            txtPrice.Text = reader["sale"].ToString();
            txtUnit.Text = reader["edinitca_izm"].ToString();
            txtQuantity.Text = reader["quantity"].ToString();
            txtDiscount.Text = reader["discount"].ToString();

            oldImagePath = reader["picture"].ToString();
            if (File.Exists(oldImagePath))
                pictureProduct.Image = Image.FromFile(oldImagePath);
        }

        //  КНОПКИ 

        private void BtnLoadImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog
            {
                Filter = "Изображения (*.png;*.jpg)|*.png;*.jpg"
            };

            if (dialog.ShowDialog() != DialogResult.OK) return;

            using var img = Image.FromFile(dialog.FileName);
            if (img.Width > 500 || img.Height > 500)
            {
                MessageBox.Show(
                    "Размер изображения не должен превышать 500x500 пикселей.",
                    "Ошибка изображения",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return;
            }

            string folder = Path.Combine(Application.StartupPath, "Images");
            Directory.CreateDirectory(folder);

            string newPath = Path.Combine(folder, Guid.NewGuid() + ".png");
            img.Save(newPath);

            if (isEditMode && File.Exists(oldImagePath))
                File.Delete(oldImagePath);

            oldImagePath = newPath;
            pictureProduct.Image = Image.FromFile(newPath);
        }
        private int GetCategoryId(NpgsqlConnection connection, string name)
        {
            string query = "SELECT id FROM category WHERE category_pk = @name";
            using var cmd = new NpgsqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@name", name);
            return Convert.ToInt32(cmd.ExecuteScalar());
        }

        private int GetManufacturerId(NpgsqlConnection connection, string name)
        {
            string query = "SELECT id FROM proizvoditel WHERE proizvoditel_pk = @name";
            using var cmd = new NpgsqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@name", name);
            return Convert.ToInt32(cmd.ExecuteScalar());
        }

        private int GetSupplierId(NpgsqlConnection connection, string name)
        {
            string query = "SELECT id FROM postavshik WHERE postavshik_pk = @name";
            using var cmd = new NpgsqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@name", name);
            return Convert.ToInt32(cmd.ExecuteScalar());
        }

        private int GetNameTovarId(NpgsqlConnection connection, string name)
        {
            // если такого названия нет — добавляем
            string select = "SELECT id FROM name_tovar WHERE name_tovar_pk = @name";
            using var selectCmd = new NpgsqlCommand(select, connection);
            selectCmd.Parameters.AddWithValue("@name", name);

            object result = selectCmd.ExecuteScalar();
            if (result != null)
                return Convert.ToInt32(result);

            string insert = "INSERT INTO name_tovar (name_tovar_pk) VALUES (@name) RETURNING id";
            using var insertCmd = new NpgsqlCommand(insert, connection);
            insertCmd.Parameters.AddWithValue("@name", name);
            return Convert.ToInt32(insertCmd.ExecuteScalar());
        }
        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateData()) return;

            using var connection = new NpgsqlConnection(connectionString);
            connection.Open();

            if (isEditMode)
                UpdateProduct(connection);
            else
                InsertProduct(connection);

            MessageBox.Show(
                "Данные успешно сохранены.",
                "Успех",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );

            Close();
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            Close();
        }

        //  INSERT / UPDATE 

        private void InsertProduct(NpgsqlConnection connection)
        {
            int nameId = GetNameTovarId(connection, txtName.Text);
            int categoryId = GetCategoryId(connection, cmbCategory.Text);
            int manufacturerId = GetManufacturerId(connection, cmbManufacturer.Text);
            int supplierId = GetSupplierId(connection, txtSupplier.Text);

            string query = @"
        INSERT INTO tovar
        (id_article, name_tovar_fk, category_fk, proizvoditel_fk, postavshik_fk,
         edinitca_izm, sale, discount, quantity, opisanie, picture)
        VALUES
        (@id, @name, @category, @manufacturer, @supplier,
         @unit, @price, @discount, @quantity, @desc, @picture)
    ";

            using var cmd = new NpgsqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@id", Guid.NewGuid().ToString());
            cmd.Parameters.AddWithValue("@name", nameId);
            cmd.Parameters.AddWithValue("@category", categoryId);
            cmd.Parameters.AddWithValue("@manufacturer", manufacturerId);
            cmd.Parameters.AddWithValue("@supplier", supplierId);
            cmd.Parameters.AddWithValue("@unit", txtUnit.Text);
            cmd.Parameters.AddWithValue("@price", decimal.Parse(txtPrice.Text));
            cmd.Parameters.AddWithValue("@discount", int.Parse(txtDiscount.Text));
            cmd.Parameters.AddWithValue("@quantity", int.Parse(txtQuantity.Text));
            cmd.Parameters.AddWithValue("@desc", txtDescription.Text);
            cmd.Parameters.AddWithValue("@picture", oldImagePath ?? "");

            cmd.ExecuteNonQuery();
        }

        private void UpdateProduct(NpgsqlConnection connection)
        {
            int nameId = GetNameTovarId(connection, txtName.Text);
            int categoryId = GetCategoryId(connection, cmbCategory.Text);
            int manufacturerId = GetManufacturerId(connection, cmbManufacturer.Text);
            int supplierId = GetSupplierId(connection, txtSupplier.Text);

            string query = @"
        UPDATE tovar SET
            name_tovar_fk = @name,
            category_fk = @category,
            proizvoditel_fk = @manufacturer,
            postavshik_fk = @supplier,
            edinitca_izm = @unit,
            sale = @price,
            discount = @discount,
            quantity = @quantity,
            opisanie = @desc,
            picture = @picture
        WHERE id_article = @id
    ";

            using var cmd = new NpgsqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@id", currentArticleId);
            cmd.Parameters.AddWithValue("@name", nameId);
            cmd.Parameters.AddWithValue("@category", categoryId);
            cmd.Parameters.AddWithValue("@manufacturer", manufacturerId);
            cmd.Parameters.AddWithValue("@supplier", supplierId);
            cmd.Parameters.AddWithValue("@unit", txtUnit.Text);
            cmd.Parameters.AddWithValue("@price", decimal.Parse(txtPrice.Text));
            cmd.Parameters.AddWithValue("@discount", int.Parse(txtDiscount.Text));
            cmd.Parameters.AddWithValue("@quantity", int.Parse(txtQuantity.Text));
            cmd.Parameters.AddWithValue("@desc", txtDescription.Text);
            cmd.Parameters.AddWithValue("@picture", oldImagePath ?? "");

            cmd.ExecuteNonQuery();
        }

        //  ВАЛИДАЦИЯ 

        private bool ValidateData()
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                ShowError("Введите наименование товара.");
                return false;
            }

            if (!decimal.TryParse(txtPrice.Text, out decimal price) || price < 0)
            {
                ShowError("Цена должна быть неотрицательным числом.");
                return false;
            }

            if (!int.TryParse(txtQuantity.Text, out int qty) || qty < 0)
            {
                ShowError("Количество не может быть отрицательным.");
                return false;
            }

            if (!int.TryParse(txtDiscount.Text, out int disc) || disc < 0 || disc > 100)
            {
                ShowError("Скидка должна быть в диапазоне 0–100.");
                return false;
            }

            return true;
        }

        private void ShowError(string message)
        {
            MessageBox.Show(
                message,
                "Ошибка ввода данных",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            );
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            isFormOpen = false;
            base.OnFormClosing(e);
        }
    }
}
