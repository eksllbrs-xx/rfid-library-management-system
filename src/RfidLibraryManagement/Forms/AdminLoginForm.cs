using RfidLibraryManagement.Forms;
using System;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using RfidLibraryManagement.Data;

namespace RfidLibraryManagement.Forms
{
    public class AdminLoginForm : Form
    {
        private TextBox usernameTextBox;
        private TextBox passwordTextBox;
        private Button loginButton;
        private Button cancelButton;

        public AdminLoginForm()
        {
            InitializeForm();
        }

        private void InitializeForm()
        {
            Text = "Admin / Library Staff Login";
            StartPosition = FormStartPosition.CenterScreen;
            Size = new Size(500, 350);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;

            Label titleLabel = new Label
            {
                Text = "ADMIN / LIBRARY STAFF LOGIN",
                AutoSize = true,
                Font = new Font("Segoe UI", 18, FontStyle.Bold),
                Location = new Point(105, 40)
            };

            Label usernameLabel = new Label
            {
                Text = "Username:",
                AutoSize = true,
                Location = new Point(70, 115),
                Font = new Font("Segoe UI", 11)
            };

            usernameTextBox = new TextBox
            {
                Location = new Point(180, 110),
                Width = 240,
                Font = new Font("Segoe UI", 11)
            };

            Label passwordLabel = new Label
            {
                Text = "Password:",
                AutoSize = true,
                Location = new Point(70, 165),
                Font = new Font("Segoe UI", 11)
            };

            passwordTextBox = new TextBox
            {
                Location = new Point(180, 160),
                Width = 240,
                Font = new Font("Segoe UI", 11),
                UseSystemPasswordChar = true
            };

            loginButton = new Button
            {
                Text = "LOGIN",
                Location = new Point(180, 220),
                Size = new Size(110, 40)
            };

            cancelButton = new Button
            {
                Text = "CANCEL",
                Location = new Point(310, 220),
                Size = new Size(110, 40)
            };

            loginButton.Click += LoginButton_Click;
            cancelButton.Click += CancelButton_Click;

            Controls.Add(titleLabel);
            Controls.Add(usernameLabel);
            Controls.Add(usernameTextBox);
            Controls.Add(passwordLabel);
            Controls.Add(passwordTextBox);
            Controls.Add(loginButton);
            Controls.Add(cancelButton);
        }

        private void LoginButton_Click(object? sender, EventArgs e)
        {
            string username = usernameTextBox.Text.Trim();
            string password = passwordTextBox.Text;

            if (string.IsNullOrWhiteSpace(username) ||
                string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show(
                    "Please enter your username and password.",
                    "Login Required",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            try
            {
                using MySqlConnection connection = Database.GetConnection();

                connection.Open();

                string query = @"
                    SELECT admin_id, username, full_name, role
                    FROM admin_users
                    WHERE username = @username
                    AND password_hash = @password
                    AND is_active = TRUE
                    LIMIT 1;";

                using MySqlCommand command =
                    new MySqlCommand(query, connection);

                command.Parameters.AddWithValue("@username", username);
                command.Parameters.AddWithValue("@password", password);

                using MySqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    string fullName = reader["full_name"].ToString() ?? "";
                    string role = reader["role"].ToString() ?? "";

                    MessageBox.Show(
                        $"Welcome, {fullName}!\nRole: {role}",
                        "Login Successful",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    Hide();

                    // Admin dashboard will be connected here next.
                }
                else
                {
                    MessageBox.Show(
                        "Invalid username or password.",
                        "Login Failed",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Unable to connect to the database.\n\n" +
                    "Please check your MySQL configuration.\n\n" +
                    $"Details: {ex.Message}",
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void CancelButton_Click(object? sender, EventArgs e)
        {
            Close();
        }
    }
}
