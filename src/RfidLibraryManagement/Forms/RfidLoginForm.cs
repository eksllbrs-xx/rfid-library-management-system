using System;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using RfidLibraryManagement.Data;

namespace RfidLibraryManagement.Forms
{
    public class RfidLoginForm : Form
    {
        private TextBox rfidTextBox = null!;
        private Button loginButton = null!;
        private Button cancelButton = null!;

        public RfidLoginForm()
        {
            InitializeForm();
        }

        private void InitializeForm()
        {
            Text = "RFID User Login";

            StartPosition =
                FormStartPosition.CenterScreen;

            Size =
                new Size(550, 400);

            FormBorderStyle =
                FormBorderStyle.FixedDialog;

            MaximizeBox = false;

            // =====================================================
            // TITLE
            // =====================================================

            Label titleLabel = new Label
            {
                Text =
                    "RFID USER LOGIN",

                AutoSize = true,

                Font = new Font(
                    "Segoe UI",
                    20,
                    FontStyle.Bold),

                Location =
                    new Point(165, 45)
            };

            // =====================================================
            // INSTRUCTION
            // =====================================================

            Label instructionLabel = new Label
            {
                Text =
                    "Scan your RFID card or enter the RFID UID:",

                AutoSize = true,

                Font = new Font(
                    "Segoe UI",
                    11),

                Location =
                    new Point(95, 115)
            };

            // =====================================================
            // RFID INPUT
            // =====================================================

            rfidTextBox = new TextBox
            {
                Location =
                    new Point(95, 155),

                Width = 360,

                Font = new Font(
                    "Segoe UI",
                    14)
            };

            rfidTextBox.KeyDown +=
                RfidTextBox_KeyDown;

            // =====================================================
            // LOGIN BUTTON
            // =====================================================

            loginButton = new Button
            {
                Text = "LOGIN",

                Location =
                    new Point(175, 220),

                Size =
                    new Size(100, 40),

                Font = new Font(
                    "Segoe UI",
                    10,
                    FontStyle.Bold)
            };

            loginButton.Click +=
                LoginButton_Click;

            // =====================================================
            // CANCEL BUTTON
            // =====================================================

            cancelButton = new Button
            {
                Text = "CANCEL",

                Location =
                    new Point(290, 220),

                Size =
                    new Size(100, 40),

                Font = new Font(
                    "Segoe UI",
                    10,
                    FontStyle.Bold)
            };

            cancelButton.Click +=
                CancelButton_Click;

            // =====================================================
            // ADD CONTROLS
            // =====================================================

            Controls.Add(titleLabel);
            Controls.Add(instructionLabel);
            Controls.Add(rfidTextBox);
            Controls.Add(loginButton);
            Controls.Add(cancelButton);

            Shown += RfidLoginForm_Shown;
        }

        // =========================================================
        // AUTO FOCUS RFID FIELD
        // =========================================================

        private void RfidLoginForm_Shown(
            object? sender,
            EventArgs e)
        {
            rfidTextBox.Focus();
        }

        // =========================================================
        // RFID SCANNER ENTER KEY
        // =========================================================

        private void RfidTextBox_KeyDown(
            object? sender,
            KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                LoginUser();

                e.SuppressKeyPress = true;
            }
        }

        // =========================================================
        // LOGIN BUTTON
        // =========================================================

        private void LoginButton_Click(
            object? sender,
            EventArgs e)
        {
            LoginUser();
        }

        // =========================================================
        // RFID LOGIN
        // =========================================================

        private void LoginUser()
        {
            string rfidUid =
                rfidTextBox.Text.Trim();

            if (string.IsNullOrWhiteSpace(rfidUid))
            {
                MessageBox.Show(
                    "Please scan or enter your RFID UID.",
                    "RFID Required",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                rfidTextBox.Focus();

                return;
            }

            try
            {
                using MySqlConnection connection =
                    Database.GetConnection();

                connection.Open();

                string query = @"
                    SELECT
                        user_id,
                        student_faculty_id,
                        CONCAT(
                            first_name,
                            ' ',
                            middle_name,
                            ' ',
                            last_name
                        ) AS full_name,
                        user_type,
                        department,
                        course,
                        status
                    FROM library_users
                    WHERE rfid_uid = @rfidUid
                      AND status = 'ACTIVE'
                    LIMIT 1;";

                using MySqlCommand command =
                    new MySqlCommand(
                        query,
                        connection);

                command.Parameters.AddWithValue(
                    "@rfidUid",
                    rfidUid);

                using MySqlDataReader reader =
                    command.ExecuteReader();

                if (!reader.Read())
                {
                    MessageBox.Show(
                        "RFID card was not found or the user is inactive.",
                        "RFID Login Failed",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);

                    rfidTextBox.Clear();
                    rfidTextBox.Focus();

                    return;
                }

                string borrowerId =
                    reader["student_faculty_id"]
                        .ToString() ?? "";

                string borrowerName =
                    reader["full_name"]
                        .ToString() ?? "";

                string userType =
                    reader["user_type"]
                        .ToString() ?? "";

                string department =
                    reader["department"]
                        .ToString() ?? "";

                string course =
                    reader["course"]
                        .ToString() ?? "";

                // Close the reader before opening
                // the user dashboard.
                reader.Close();

                MessageBox.Show(
                    $"Welcome, {borrowerName}!\n\n" +
                    $"ID Number: {borrowerId}\n" +
                    $"User Type: {userType}\n" +
                    $"Department: {department}\n" +
                    $"Course: {course}",
                    "RFID Login Successful",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                Hide();

                using UserDashboardForm dashboard =
                    new UserDashboardForm(
                        borrowerId,
                        borrowerName);

                dashboard.ShowDialog();

                Show();

                rfidTextBox.Clear();
                rfidTextBox.Focus();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(
                    "Unable to connect to the database.\n\n" +
                    "Please check your MySQL server and database configuration.\n\n" +
                    $"Details: {ex.Message}",
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "An unexpected error occurred.\n\n" +
                    $"Details: {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // =========================================================
        // CANCEL
        // =========================================================

        private void CancelButton_Click(
            object? sender,
            EventArgs e)
        {
            Close();
        }
    }
}
