using System;
using System.Drawing;
using System.Windows.Forms;

namespace RfidLibraryManagement
{
    public class MainForm : Form
    {
        private Label titleLabel;
        private Label subtitleLabel;
        private Button adminButton;
        private Button rfidButton;
        private Button exitButton;

        public MainForm()
        {
            InitializeForm();
        }

        private void InitializeForm()
        {
            Text = "RFID Library Management System";
            StartPosition = FormStartPosition.CenterScreen;
            Size = new Size(900, 550);
            MinimumSize = new Size(800, 500);

            titleLabel = new Label
            {
                Text = "RFID LIBRARY MANAGEMENT SYSTEM",
                AutoSize = true,
                Font = new Font("Segoe UI", 22, FontStyle.Bold),
                Location = new Point(210, 80)
            };

            subtitleLabel = new Label
            {
                Text = "University Library Management System",
                AutoSize = true,
                Font = new Font("Segoe UI", 12),
                Location = new Point(310, 125)
            };

            adminButton = new Button
            {
                Text = "ADMIN / LIBRARY STAFF",
                Size = new Size(250, 60),
                Location = new Point(325, 200),
                Font = new Font("Segoe UI", 11, FontStyle.Bold)
            };

            rfidButton = new Button
            {
                Text = "RFID USER LOGIN",
                Size = new Size(250, 60),
                Location = new Point(325, 280),
                Font = new Font("Segoe UI", 11, FontStyle.Bold)
            };

            exitButton = new Button
            {
                Text = "EXIT",
                Size = new Size(150, 45),
                Location = new Point(375, 380),
                Font = new Font("Segoe UI", 10)
            };

            adminButton.Click += AdminButton_Click;
            rfidButton.Click += RfidButton_Click;
            exitButton.Click += ExitButton_Click;

            Controls.Add(titleLabel);
            Controls.Add(subtitleLabel);
            Controls.Add(adminButton);
            Controls.Add(rfidButton);
            Controls.Add(exitButton);
        }

        private void AdminButton_Click(object? sender, EventArgs e)
        {
            MessageBox.Show(
                "Admin / Library Staff login will be implemented next.",
                "Admin Login",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void RfidButton_Click(object? sender, EventArgs e)
        {
            MessageBox.Show(
                "RFID user login will be implemented next.",
                "RFID Login",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void ExitButton_Click(object? sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
