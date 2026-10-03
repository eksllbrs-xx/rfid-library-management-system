using System;
using System.Drawing;
using System.Windows.Forms;

namespace RfidLibraryManagement.Forms
{
    public class AdminDashboardForm : Form
    {
        private Button bookManagementButton = null!;
        private Button issueBookButton = null!;
        private Button returnBookButton = null!;
        private Button recordsButton = null!;
        private Button searchButton = null!;
        private Button reportsButton = null!;
        private Button logoutButton = null!;

        public AdminDashboardForm()
        {
            InitializeForm();
        }

        private void InitializeForm()
        {
            Text = "Admin Dashboard - RFID Library Management System";
            StartPosition = FormStartPosition.CenterScreen;
            Size = new Size(750, 600);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;

            // =========================
            // TITLE
            // =========================

            Label titleLabel = new Label
            {
                Text = "RFID LIBRARY MANAGEMENT SYSTEM",
                AutoSize = true,
                Font = new Font(
                    "Segoe UI",
                    20,
                    FontStyle.Bold),
                Location = new Point(145, 35)
            };

            Label subtitleLabel = new Label
            {
                Text = "ADMIN / LIBRARY STAFF DASHBOARD",
                AutoSize = true,
                Font = new Font(
                    "Segoe UI",
                    12,
                    FontStyle.Regular),
                Location = new Point(250, 80)
            };

            // =========================
            // BOOK MANAGEMENT
            // =========================

            bookManagementButton = new Button
            {
                Text = "BOOK MANAGEMENT",
                Location = new Point(80, 140),
                Size = new Size(250, 55),
                Font = new Font(
                    "Segoe UI",
                    11,
                    FontStyle.Bold)
            };

            bookManagementButton.Click +=
                BookManagementButton_Click;

            // =========================
            // ISSUE BOOK
            // =========================

            issueBookButton = new Button
            {
                Text = "ISSUE BOOK",
                Location = new Point(370, 140),
                Size = new Size(250, 55),
                Font = new Font(
                    "Segoe UI",
                    11,
                    FontStyle.Bold)
            };

            issueBookButton.Click +=
                IssueBookButton_Click;

            // =========================
            // RETURN BOOK
            // =========================

            returnBookButton = new Button
            {
                Text = "RETURN BOOK",
                Location = new Point(80, 215),
                Size = new Size(250, 55),
                Font = new Font(
                    "Segoe UI",
                    11,
                    FontStyle.Bold)
            };

            returnBookButton.Click +=
                ReturnBookButton_Click;

            // =========================
            // RECORDS
            // =========================

            recordsButton = new Button
            {
                Text = "RECORDS",
                Location = new Point(370, 215),
                Size = new Size(250, 55),
                Font = new Font(
                    "Segoe UI",
                    11,
                    FontStyle.Bold)
            };

            recordsButton.Click +=
                RecordsButton_Click;

            // =========================
            // SEARCH
            // =========================

            searchButton = new Button
            {
                Text = "SEARCH",
                Location = new Point(80, 290),
                Size = new Size(250, 55),
                Font = new Font(
                    "Segoe UI",
                    11,
                    FontStyle.Bold)
            };

            searchButton.Click +=
                SearchButton_Click;

            // =========================
            // REPORTS / PRINT PREVIEW
            // =========================

            reportsButton = new Button
            {
                Text = "REPORTS / PRINT PREVIEW",
                Location = new Point(370, 290),
                Size = new Size(250, 55),
                Font = new Font(
                    "Segoe UI",
                    11,
                    FontStyle.Bold)
            };

            reportsButton.Click +=
                ReportsButton_Click;

            // =========================
            // LOGOUT
            // =========================

            logoutButton = new Button
            {
                Text = "LOGOUT",
                Location = new Point(275, 400),
                Size = new Size(200, 50),
                Font = new Font(
                    "Segoe UI",
                    11,
                    FontStyle.Bold)
            };

            logoutButton.Click +=
                LogoutButton_Click;

            // =========================
            // ADD CONTROLS
            // =========================

            Controls.Add(titleLabel);
            Controls.Add(subtitleLabel);

            Controls.Add(bookManagementButton);
            Controls.Add(issueBookButton);
            Controls.Add(returnBookButton);
            Controls.Add(recordsButton);
            Controls.Add(searchButton);
            Controls.Add(reportsButton);

            Controls.Add(logoutButton);
        }

        // =====================================================
        // BOOK MANAGEMENT
        // =====================================================

        private void BookManagementButton_Click(
            object? sender,
            EventArgs e)
        {
            using BookManagementForm bookManagementForm =
                new BookManagementForm();

            bookManagementForm.ShowDialog();
        }

        // =====================================================
        // ISSUE BOOK
        // =====================================================

        private void IssueBookButton_Click(
            object? sender,
            EventArgs e)
        {
            using IssueBookForm issueBookForm =
                new IssueBookForm();

            issueBookForm.ShowDialog();
        }

        // =====================================================
        // RETURN BOOK
        // =====================================================

        private void ReturnBookButton_Click(
            object? sender,
            EventArgs e)
        {
            using ReturnBookForm returnBookForm =
                new ReturnBookForm();

            returnBookForm.ShowDialog();
        }

        // =====================================================
        // RECORDS
        // =====================================================

        private void RecordsButton_Click(
            object? sender,
            EventArgs e)
        {
            MessageBox.Show(
                "Records module will be implemented next.\n\n" +
                "It will contain:\n" +
                "• Attendance\n" +
                "• Borrowed Books\n" +
                "• Returned Books\n" +
                "• Inventory\n" +
                "• Book Requests",
                "Records",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        // =====================================================
        // SEARCH
        // =====================================================

        private void SearchButton_Click(
            object? sender,
            EventArgs e)
        {
            MessageBox.Show(
                "Search module will be implemented next.",
                "Search",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        // =====================================================
        // REPORTS
        // =====================================================

        private void ReportsButton_Click(
            object? sender,
            EventArgs e)
        {
            MessageBox.Show(
                "Reports / Print Preview module will be implemented next.\n\n" +
                "The system will support PDF reports.",
                "Reports / Print Preview",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        // =====================================================
        // LOGOUT
        // =====================================================

        private void LogoutButton_Click(
            object? sender,
            EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Are you sure you want to logout?",
                "Confirm Logout",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Close();
            }
        }
    }
}
