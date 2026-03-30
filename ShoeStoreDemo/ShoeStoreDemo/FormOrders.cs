using System;
using System.Drawing;
using System.Windows.Forms;
using Npgsql;

namespace ShoeStoreDemo
{
    public partial class FormOrders : Form
    {
        private readonly string connectionString =
            "Host=localhost;Port=5432;Database=demo2026;Username=postgres;Password=5696";

        private readonly UserRole currentRole;

        //  КОНСТРУКТОР 

        public FormOrders(UserRole role)
        {
            InitializeComponent();
            currentRole = role;

            // кнопка добавления — только администратор
            btnAddOrder.Visible = currentRole == UserRole.Admin;

            LoadOrders();
        }

        //  ЗАГРУЗКА ЗАКАЗОВ 

        private void LoadOrders()
        {
            flowLayoutPanelOrders.Controls.Clear();

            try
            {
                using var connection = new NpgsqlConnection(connectionString);
                connection.Open();

                string query = @"
                    SELECT 
                        o.""Order_number"",
                        s.status_name,
                        a.address,
                        o.order_date,
                        o.delivery_date
                    FROM orders o
                    JOIN status s ON o.status_fk = s.status_id
                    JOIN claim_points_addresses a ON o.collect_point_address = a.id
                    ORDER BY o.""Order_number"" DESC
                ";

                using var command = new NpgsqlCommand(query, connection);
                using var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Panel panel = CreateOrderPanel(
                        orderNumber: reader.GetInt32(0),
                        status: reader.GetString(1),
                        address: reader.GetString(2),
                        orderDate: reader.GetDateTime(3),
                        deliveryDate: reader.GetDateTime(4)
                    );

                    flowLayoutPanelOrders.Controls.Add(panel);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Ошибка загрузки заказов.\n" + ex.Message,
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        // УДАЛЕНИЕ ЗАКАЗА

        private void DeleteOrder(int orderNumber)
        {
            var result = MessageBox.Show(
                "Вы уверены, что хотите удалить заказ?\nЭто действие невозможно отменить.",
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

                using (var cmd = new NpgsqlCommand(
                    "DELETE FROM order_product WHERE order_id = @id", connection))
                {
                    cmd.Parameters.AddWithValue("@id", orderNumber);
                    cmd.ExecuteNonQuery();
                }

                using (var cmd = new NpgsqlCommand(
                    "DELETE FROM orders WHERE \"Order_number\" = @id", connection))
                {
                    cmd.Parameters.AddWithValue("@id", orderNumber);
                    cmd.ExecuteNonQuery();
                }

                LoadOrders();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Ошибка при удалении заказа.\n" + ex.Message,
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        // КАРТОЧКА ЗАКАЗА 

        private Panel CreateOrderPanel(
            int orderNumber,
            string status,
            string address,
            DateTime orderDate,
            DateTime deliveryDate)
        {
            Panel panel = new Panel
            {
                Width = 960,
                Height = 140,
                BorderStyle = BorderStyle.FixedSingle,
                Margin = new Padding(5),
                BackColor = Color.White
            };

            Label lblOrderNumber = new Label
            {
                Text = $"Заказ №{orderNumber}",
                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                Location = new Point(10, 10),
                AutoSize = true
            };

            Label lblStatus = new Label
            {
                Text = $"Статус: {status}",
                Location = new Point(10, 40),
                AutoSize = true
            };

            Label lblAddress = new Label
            {
                Text = $"Пункт выдачи: {address}",
                Location = new Point(10, 65),
                AutoSize = true
            };

            Label lblOrderDate = new Label
            {
                Text = $"Дата заказа: {orderDate:dd.MM.yyyy}",
                Location = new Point(10, 90),
                AutoSize = true
            };

            Panel datePanel = new Panel
            {
                Width = 160,
                Height = 80,
                Left = panel.Width - 180,
                Top = 30,
                BorderStyle = BorderStyle.FixedSingle,
                BackColor = ColorTranslator.FromHtml("#7FFF00")
            };

            Label lblDeliveryDate = new Label
            {
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                Text = $"Выдача:\n{deliveryDate:dd.MM.yyyy}"
            };

            datePanel.Controls.Add(lblDeliveryDate);

            panel.Controls.AddRange(new Control[]
            {
                lblOrderNumber,
                lblStatus,
                lblAddress,
                lblOrderDate,
                datePanel
            });

            // кнопки администратора 
            if (currentRole == UserRole.Admin)
            {
                Button btnEdit = new Button
                {
                    Text = "Редактировать",
                    Width = 120,
                    Height = 30,
                    Location = new Point(300, 100),
                    BackColor = ColorTranslator.FromHtml("#00FA9A"),
                    FlatStyle = FlatStyle.Flat
                };

                btnEdit.Click += (s, e) =>
                {
                    using var form = new FormEditOrder(currentRole, orderNumber);
                    form.ShowDialog();
                    LoadOrders();
                };

                Button btnDelete = new Button
                {
                    Text = "Удалить",
                    Width = 120,
                    Height = 30,
                    Location = new Point(430, 100),
                    BackColor = ColorTranslator.FromHtml("#00FA9A"),
                    FlatStyle = FlatStyle.Flat
                };

                btnDelete.Click += (s, e) => DeleteOrder(orderNumber);

                panel.Controls.Add(btnEdit);
                panel.Controls.Add(btnDelete);
            }

            return panel;
        }

        //  КНОПКИ ФОРМЫ 

        private void BtnAddOrder_Click(object sender, EventArgs e)
        {
            using var form = new FormEditOrder(currentRole);
            form.ShowDialog();
            LoadOrders();
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            Hide();
            new FormProducts(currentRole).Show();
        }
    }
}
