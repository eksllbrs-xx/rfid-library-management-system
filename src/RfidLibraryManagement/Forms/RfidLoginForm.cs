using System;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using RfidLibraryManagement.Data;

namespace RfidLibraryManagement.Forms
{
    public class RfidLoginForm : Form
    {
        private TextBox rfidTextBox;
        private Button loginButton;
        private Button cancelButton;

        public RfidLoginForm()
        {
            InitializeForm();
        }

        private void InitializeForm()
        {
            Text = "RFID User Login";
            StartPosition = FormStartPosition.CenterScreen;
            Size = new Size(500, 320);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;

            Label titleLabel = new Label
            {
                Text = "RFID USER LOGIN",
                AutoSize = true,
                Font = new Font("Segoe UI", 20, FontStyle.Bold),
                Location = new Point(145, 45)
            };

            Label instructionLabel = new Label
            {
                Text = "Scan your RFID card or enter your RFID UID:",
                AutoSize = true,
                Font = new Font("Segoe UI", 10),
                Location = new Point(95, 105)
            };

            rfidTextBox = new TextBox
            {
                Location = new Point(95, 140),
                Width = 310,
                Font = new Font("Segoe UI", 14)
            };

            loginButton = new Button
            {
                Text = "LOGIN",
                Location = new Point(145, 200),
                Size = new Size(100, 40)
            };

            cancelButton = new Button
            {
                Text = "CANCEL",
                Location = new Point(255, 200),
                Size = new Size(100, 40)
            };

            loginButton.Click += LoginButton_Click;
            cancelButton.Click += CancelButton_Click;

            Controls.Add(titleLabel);
            Controls.Add(instructionLabel);
            Controls.Add(rfidTextBox);
            Controls.Add(loginButton);
            Controls.Add(cancelButton);

            Shown += (sender, e) => rfidTextBox.Focus();
        }

        private void LoginButton_Click(object? sender, EventArgs e)
        {
            string rfidUid = rfidTextBox.Text.Trim();

            if (string.IsNullOrWhiteSpace(rfidUid))
            {
                MessageBox.Show(
                    "Please scan or enter an RFID UID.",
                    "RFID Required",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                rfidTextBox.Focus();
                return;
            }

            try
            {
                using MySqlConnection connection = Database.GetConnection();

                connection.Open();

                string query = @"
                    SELECT
                        student_faculty_id,
                        first_name,
                        middle_name,
                        last_name,
                        user_type,
                        department,
                        course
                    FROM library_users
                    WHERE rfid_uid = @rfidUid
                    AND status = 'ACTIVE'
                    LIMIT 1;";

                using MySqlCommand command =
                    new MySqlCommand(query, connection);

                command.Parameters.AddWithValue("@rfidUid", rfidUid);

                using MySqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    string firstName = reader["first_name"].ToString() ?? "";
                    string lastName = reader["last_name"].ToString() ?? "";
                    string userType = reader["user_type"].ToString() ?? "";
                    string userId = reader["student_faculty_id"].ToString() ?? "";

                    MessageBox.Show(
                        $"Welcome, {firstName} {lastName}!\n\n" +
                        $"ID: {userId}\n" +
                        $"Type: {userType}",
                        "RFID Login Successful",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    Hide();

                    // Student/Faculty dashboard will be connected here next.
                }
                else
                {
                    MessageBox.Show(
                        "RFID card not recognized or the user is inactive.",
                        "RFID Login Failed",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);

                    rfidTextBox.SelectAll();
                    rfidTextBox.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Unable to connect to the database.\n\n" +
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
