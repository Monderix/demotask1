using System;
using System.Windows.Forms;
using Npgsql;

namespace ShoeStoreDemo
{
    public partial class FormAuth : Form
    {
        private readonly string connectionString =
            "Host=localhost;Port=5432;Database=demo2026;Username=postgres;Password=5696";

        public FormAuth()
        {
            InitializeComponent();
            txtPassword.UseSystemPasswordChar = true;
        }

        // ВХОД 

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string login = txtLogin.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show(
                    "Введите логин и пароль.",
                    "Ошибка авторизации",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            try
            {
                using var connection = new NpgsqlConnection(connectionString);
                connection.Open();

                string query = @"
                    SELECT role_fk
                    FROM users
                    WHERE ""Login"" = @login AND ""Password"" = @password
                ";

                using var command = new NpgsqlCommand(query, connection);
                command.Parameters.AddWithValue("@login", login);
                command.Parameters.AddWithValue("@password", password);

                object result = command.ExecuteScalar();

                if (result == null)
                {
                    MessageBox.Show(
                        "Неверный логин или пароль.",
                        "Ошибка авторизации",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                    return;
                }

                int roleId = Convert.ToInt32(result);
                OpenFormByRole(roleId);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Ошибка подключения к базе данных:\n" + ex.Message,
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        //  ВХОД КАК ГОСТЬ 

        private void btnGuest_Click(object sender, EventArgs e)
        {
            Hide();
            new FormProducts(UserRole.Guest).Show();
        }

        // ОТКРЫТИЕ ФОРМЫ ПО РОЛИ 

        private void OpenFormByRole(int roleId)
        {
            UserRole role;

            /*
             * roles в БД:
             * 1 — пользователь
             * 2 — менеджер
             * 3 — администратор
             */

            switch (roleId)
            {
                case 1:
                    role = UserRole.User;
                    break;

                case 2:
                    role = UserRole.Manager;
                    break;

                case 3:
                    role = UserRole.Admin;
                    break;

                default:
                    MessageBox.Show(
                        "Неизвестная роль пользователя.",
                        "Ошибка",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                    return;
            }

            Hide();
            new FormProducts(role).Show();
        }

        // СБРОС ПОЛЕЙ 

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            txtLogin.Clear();
            txtPassword.Clear();
            txtLogin.Focus();
        }
    }
}