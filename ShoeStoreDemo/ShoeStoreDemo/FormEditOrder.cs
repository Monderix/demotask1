using System;
using System.Windows.Forms;
using Npgsql;

namespace ShoeStoreDemo
{
    public partial class FormEditOrder : Form
    {
        private readonly string connectionString =
            "Host=localhost;Port=5432;Database=demo2026;Username=postgres;Password=5696";

        private readonly UserRole currentRole;
        private readonly int? orderNumber; // null = добавление

        // КОНСТРУКТОРЫ 

        // Добавление заказа
        public FormEditOrder(UserRole role)
        {
            InitializeComponent();
            currentRole = role;
            orderNumber = null;

            Text = "Добавление заказа";

            InitializeForm();
            GenerateOrderNumber();
        }

        // Редактирование заказа
        public FormEditOrder(UserRole role, int orderNumber)
        {
            InitializeComponent();
            currentRole = role;
            this.orderNumber = orderNumber;

            Text = $"Редактирование заказа №{orderNumber}";

            InitializeForm();
            LoadOrder(orderNumber);
        }

        //ОБЩАЯ ИНИЦИАЛИЗАЦИЯ 

        private void InitializeForm()
        {
            LoadStatuses();
            LoadAddresses();
        }

        //  ЗАГРУЗКА СПРАВОЧНИКОВ 

        private void LoadStatuses()
        {
            cmbStatus.Items.Clear();

            using var connection = new NpgsqlConnection(connectionString);
            connection.Open();

            string query = "SELECT status_name FROM status ORDER BY status_id";
            using var cmd = new NpgsqlCommand(query, connection);
            using var reader = cmd.ExecuteReader();

            while (reader.Read())
                cmbStatus.Items.Add(reader.GetString(0));

            if (cmbStatus.Items.Count > 0)
                cmbStatus.SelectedIndex = 0;
        }

        private void LoadAddresses()
        {
            cmbAddress.Items.Clear();

            using var connection = new NpgsqlConnection(connectionString);
            connection.Open();

            string query = "SELECT address FROM claim_points_addresses ORDER BY id";
            using var cmd = new NpgsqlCommand(query, connection);
            using var reader = cmd.ExecuteReader();

            while (reader.Read())
                cmbAddress.Items.Add(reader.GetString(0));

            if (cmbAddress.Items.Count > 0)
                cmbAddress.SelectedIndex = 0;
        }

        // ДОБАВЛЕНИЕ 

        private void GenerateOrderNumber()
        {
            using var connection = new NpgsqlConnection(connectionString);
            connection.Open();

            string query = @"SELECT COALESCE(MAX(""Order_number""), 0) + 1 FROM orders";
            using var cmd = new NpgsqlCommand(query, connection);

            txtOrderNumber.Text = cmd.ExecuteScalar().ToString();
        }

        // РЕДАКТИРОВАНИЕ  

        private void LoadOrder(int number)
        {
            using var connection = new NpgsqlConnection(connectionString);
            connection.Open();

            string query = @"
                SELECT 
                    s.status_name,
                    a.address,
                    o.order_date,
                    o.delivery_date
                FROM orders o
                JOIN status s ON o.status_fk = s.status_id
                JOIN claim_points_addresses a ON o.collect_point_address = a.id
                WHERE o.""Order_number"" = @num
            ";

            using var cmd = new NpgsqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@num", number);

            using var reader = cmd.ExecuteReader();
            if (!reader.Read())
                return;

            txtOrderNumber.Text = number.ToString();
            cmbStatus.SelectedItem = reader.GetString(0);
            cmbAddress.SelectedItem = reader.GetString(1);
            dtpOrderDate.Value = reader.GetDateTime(2);
            dtpDeliveryDate.Value = reader.GetDateTime(3);

            txtOrderNumber.ReadOnly = true;
        }

        //  СОХРАНЕНИЕ

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateData())
                return;

            using var connection = new NpgsqlConnection(connectionString);
            connection.Open();

            if (orderNumber.HasValue)
                UpdateOrder(connection);
            else
                InsertOrder(connection);

            MessageBox.Show(
                "Данные заказа успешно сохранены.",
                "Заказы",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );

            Close();
        }

        private void InsertOrder(NpgsqlConnection connection)
        {
            int statusId = GetStatusId(connection, cmbStatus.Text);
            int addressId = GetAddressId(connection, cmbAddress.Text);

            string query = @"
                INSERT INTO orders
                (""Order_number"", status_fk, collect_point_address, order_date, delivery_date)
                VALUES
                (@num, @status, @address, @orderDate, @deliveryDate)
            ";

            using var cmd = new NpgsqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@num", int.Parse(txtOrderNumber.Text));
            cmd.Parameters.AddWithValue("@status", statusId);
            cmd.Parameters.AddWithValue("@address", addressId);
            cmd.Parameters.AddWithValue("@orderDate", dtpOrderDate.Value.Date);
            cmd.Parameters.AddWithValue("@deliveryDate", dtpDeliveryDate.Value.Date);

            cmd.ExecuteNonQuery();
        }

        private void UpdateOrder(NpgsqlConnection connection)
        {
            int statusId = GetStatusId(connection, cmbStatus.Text);
            int addressId = GetAddressId(connection, cmbAddress.Text);

            string query = @"
                UPDATE orders SET
                    status_fk = @status,
                    collect_point_address = @address,
                    order_date = @orderDate,
                    delivery_date = @deliveryDate
                WHERE ""Order_number"" = @num
            ";

            using var cmd = new NpgsqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@num", orderNumber.Value);
            cmd.Parameters.AddWithValue("@status", statusId);
            cmd.Parameters.AddWithValue("@address", addressId);
            cmd.Parameters.AddWithValue("@orderDate", dtpOrderDate.Value.Date);
            cmd.Parameters.AddWithValue("@deliveryDate", dtpDeliveryDate.Value.Date);

            cmd.ExecuteNonQuery();
        }

        // ВСПОМОГАТЕЛЬНЫЕ МЕТОДЫ

        private int GetStatusId(NpgsqlConnection connection, string statusName)
        {
            string query = "SELECT status_id FROM status WHERE status_name = @name";
            using var cmd = new NpgsqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@name", statusName);
            return Convert.ToInt32(cmd.ExecuteScalar());
        }

        private int GetAddressId(NpgsqlConnection connection, string address)
        {
            string query = "SELECT id FROM claim_points_addresses WHERE address = @addr";
            using var cmd = new NpgsqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@addr", address);
            return Convert.ToInt32(cmd.ExecuteScalar());
        }

        private bool ValidateData()
        {
            if (dtpDeliveryDate.Value.Date < dtpOrderDate.Value.Date)
            {
                MessageBox.Show(
                    "Дата выдачи не может быть раньше даты заказа.",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return false;
            }

            return true;
        }

        // НАЗАД 

        private void BtnBack_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}