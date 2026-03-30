using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;

namespace ShoeStoreDemo
{
    public partial class FormProducts : Form
    {
        private readonly string connectionString =
            "Host=localhost;Port=5432;Database=demo2026;Username=postgres;Password=5696";

        private readonly UserRole currentRole;

        // КОНСТРУКТОР 

        public FormProducts(UserRole role)
        {
            InitializeComponent();
            currentRole = role;

            LoadSuppliers();
            LoadProducts();
            ConfigureByRole();
        }

        //  НАСТРОЙКА ПО РОЛИ

        private void ConfigureByRole()
        {
            bool isManager = currentRole == UserRole.Manager;
            bool isAdmin = currentRole == UserRole.Admin;

            bool canManage = isManager || isAdmin;



            // поиск / фильтр / сортировка 
            txtSearch.Visible = canManage;
            cmbSupplier.Visible = canManage;
            cmbSort.Visible = canManage;

            lblSearch.Visible = canManage;
            lblSupplier.Visible = canManage;
            lblSort.Visible = canManage;

            // кнопки
            btnOrders.Visible = canManage;
            btnAddProduct.Visible = isAdmin;

            // карточки товаров
            foreach (Control control in flowLayoutPanelProducts.Controls)
            {
                if (control is ProductCardControl card)
                {
                    card.SetAdminControlsVisible(isAdmin);
                }
            }

            // заголовок окна
            Text = currentRole switch
            {
                UserRole.Guest => "Каталог товаров (Гость)",
                UserRole.User => "Каталог товаров (Пользователь)",
                UserRole.Manager => "Каталог товаров (Менеджер)",
                UserRole.Admin => "Каталог товаров (Администратор)",
                _ => "Каталог товаров"
            };
        }

        // ЗАГРУЗКА ПОСТАВЩИКОВ 

        private void LoadSuppliers()
        {
            cmbSupplier.Items.Clear();
            cmbSupplier.Items.Add("Все поставщики");

            try
            {
                using var connection = new NpgsqlConnection(connectionString);
                connection.Open();

                string query = "SELECT postavshik_pk FROM postavshik ORDER BY postavshik_pk";
                using var command = new NpgsqlCommand(query, connection);
                using var reader = command.ExecuteReader();

                while (reader.Read())
                    cmbSupplier.Items.Add(reader.GetString(0));

                cmbSupplier.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Ошибка загрузки поставщиков.\n" + ex.Message,
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        // ЗАГРУЗКА ТОВАРОВ 

        private void LoadProducts()
        {
            flowLayoutPanelProducts.Controls.Clear();

            string searchText = txtSearch.Text.Trim().ToLower();
            string selectedSupplier = cmbSupplier.SelectedItem?.ToString();
            string selectedSort = cmbSort.SelectedItem?.ToString();

            try
            {
                using var connection = new NpgsqlConnection(connectionString);
                connection.Open();

                string query = @"
                    SELECT 
                        t.id_article,
                        nt.name_tovar_pk AS name,
                        c.category_pk AS category,
                        t.opisanie,
                        pr.proizvoditel_pk AS proizvoditel,
                        ps.postavshik_pk AS postavshik,
                        t.sale AS price,
                        t.discount,
                        t.edinitca_izm,
                        t.quantity,
                        t.picture
                    FROM tovar t
                    JOIN name_tovar nt ON t.name_tovar_fk = nt.id
                    JOIN category c ON t.category_fk = c.id
                    JOIN proizvoditel pr ON t.proizvoditel_fk = pr.id
                    JOIN postavshik ps ON t.postavshik_fk = ps.id
                    WHERE 1 = 1
                ";

                if (!string.IsNullOrEmpty(searchText) &&
                    (currentRole == UserRole.Manager || currentRole == UserRole.Admin))
                {
                    query += @"
                        AND (
                            LOWER(nt.name_tovar_pk) LIKE @search OR
                            LOWER(t.opisanie) LIKE @search OR
                            LOWER(c.category_pk) LIKE @search OR
                            LOWER(pr.proizvoditel_pk) LIKE @search OR
                            LOWER(ps.postavshik_pk) LIKE @search
                        )
                    ";
                }

                if (!string.IsNullOrEmpty(selectedSupplier) &&
                    selectedSupplier != "Все поставщики" &&
                    (currentRole == UserRole.Manager || currentRole == UserRole.Admin))
                {
                    query += " AND ps.postavshik_pk = @supplier ";
                }

                if (currentRole == UserRole.Manager || currentRole == UserRole.Admin)
                {
                    query += selectedSort switch
                    {
                        "По количеству (возрастание)" => " ORDER BY t.quantity ASC ",
                        "По количеству (убывание)" => " ORDER BY t.quantity DESC ",
                        _ => " ORDER BY nt.name_tovar_pk "
                    };
                }
                else
                {
                    query += " ORDER BY nt.name_tovar_pk ";
                }

                using var command = new NpgsqlCommand(query, connection);

                if (!string.IsNullOrEmpty(searchText) &&
                    (currentRole == UserRole.Manager || currentRole == UserRole.Admin))
                {
                    command.Parameters.AddWithValue("@search", "%" + searchText + "%");
                }

                if (!string.IsNullOrEmpty(selectedSupplier) &&
                    selectedSupplier != "Все поставщики" &&
                    (currentRole == UserRole.Manager || currentRole == UserRole.Admin))
                {
                    command.Parameters.AddWithValue("@supplier", selectedSupplier);
                }

                using var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var card = new ProductCardControl();

                    card.SetProduct(
                        articleId: reader["id_article"].ToString(),
                        category: reader["category"].ToString(),
                        name: reader["name"].ToString(),
                        description: reader["opisanie"].ToString(),
                        manufacturer: reader["proizvoditel"].ToString(),
                        supplier: reader["postavshik"].ToString(),
                        price: Convert.ToDecimal(reader["price"]),
                        discount: Convert.ToInt32(reader["discount"]),
                        unit: reader["edinitca_izm"].ToString(),
                        quantity: Convert.ToInt32(reader["quantity"]),
                        imagePath: reader["picture"].ToString()
                    );

                    card.SetAdminControlsVisible(currentRole == UserRole.Admin);

                    // --- события ---
                    card.EditClicked += articleId =>
                    {
                        using var form = new FormEditProduct(articleId);
                        form.ShowDialog();
                        LoadProducts();
                    };

                    card.DeleteClicked += (articleId, imagePath) =>
                    {
                        DeleteProduct(articleId, imagePath);
                    };

                    flowLayoutPanelProducts.Controls.Add(card);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Ошибка загрузки товаров.\n" + ex.Message,
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        //  УДАЛЕНИЕ ТОВАРА 

        private void DeleteProduct(string articleId, string imagePath)
        {
            var result = MessageBox.Show(
                "Вы уверены, что хотите удалить товар?\nЭто действие невозможно отменить.",
                "Подтверждение удаления",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (result != DialogResult.Yes)
                return;

            try
            {
                using var connection = new NpgsqlConnection(connectionString);
                connection.Open();

                string checkQuery = "SELECT COUNT(*) FROM order_product WHERE article_fk = @id";
                using (var checkCmd = new NpgsqlCommand(checkQuery, connection))
                {
                    checkCmd.Parameters.AddWithValue("@id", articleId);
                    if (Convert.ToInt32(checkCmd.ExecuteScalar()) > 0)
                    {
                        MessageBox.Show(
                            "Невозможно удалить товар, так как он используется в заказах.",
                            "Удаление запрещено",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error
                        );
                        return;
                    }
                }

                using (var deleteCmd =
                       new NpgsqlCommand("DELETE FROM tovar WHERE id_article = @id", connection))
                {
                    deleteCmd.Parameters.AddWithValue("@id", articleId);
                    deleteCmd.ExecuteNonQuery();
                }

                if (!string.IsNullOrEmpty(imagePath) && System.IO.File.Exists(imagePath))
                    System.IO.File.Delete(imagePath);

                LoadProducts();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Ошибка при удалении товара.\n" + ex.Message,
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        // СОБЫТИЯ UI 

        private void FiltersChanged(object sender, EventArgs e)
        {
            LoadProducts();
        }

        private void BtnAddProduct_Click(object sender, EventArgs e)
        {
            using var form = new FormEditProduct();
            form.ShowDialog();
            LoadProducts();
        }

        private void BtnOrders_Click(object sender, EventArgs e)
        {
            Hide();
            new FormOrders(currentRole).Show();
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            Hide();
            new FormAuth().Show();
        }
    }
}