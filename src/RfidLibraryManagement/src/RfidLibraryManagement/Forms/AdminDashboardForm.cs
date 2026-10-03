using System;
using System.Drawing;
using System.Windows.Forms;

namespace RfidLibraryManagement.Forms
{
    public class AdminDashboardForm : Form
    {
        private Button bookManagementButton;
        private Button issueBookButton;
        private Button returnBookButton;
        private Button recordsButton;
        private Button searchButton;
        private Button reportsButton;
        private Button logoutButton;

        public AdminDashboardForm()
        {
            InitializeForm();
        }

        private void InitializeForm()
        {
            Text = "Library Management - Admin Dashboard";
            StartPosition = FormStartPosition.CenterScreen;
            Size = new Size(900, 600);
            MinimumSize = new Size(800, 500);

            Label titleLabel = new Label
            {
                Text = "LIBRARY MANAGEMENT SYSTEM",
                AutoSize = true,
                Font = new Font("Segoe UI", 22, FontStyle.Bold),
                Location = new Point(245, 35)
            };

            Label subtitleLabel = new Label
            {
                Text = "Administrator / Library Staff Dashboard",
                AutoSize = true,
                Font = new Font("Segoe UI", 11),
                Location = new Point(310, 80)
            };

            bookManagementButton = CreateButton(
                "BOOK MANAGEMENT",
                100,
                140);

            issueBookButton = CreateButton(
                "ISSUE BOOK",
                330,
                140);

            returnBookButton = CreateButton(
                "RETURN BOOK",
                560,
                140);

            recordsButton = CreateButton(
                "RECORDS",
                100,
                230);

            searchButton = CreateButton(
                "SEARCH",
                330,
                230);

            reportsButton = CreateButton(
                "REPORTS / PRINT PREVIEW",
                560,
                230);

            logoutButton = new Button
            {
                Text = "LOGOUT",
                Size = new Size(160, 45),
                Location = new Point(365, 390),
                Font = new Font("Segoe UI", 10, FontStyle.Bold)
            };

            bookManagementButton.Click += BookManagementButton_Click;
            issueBookButton.Click += IssueBookButton_Click;
            returnBookButton.Click += ReturnBookButton_Click;
            recordsButton.Click += RecordsButton_Click;
            searchButton.Click += SearchButton_Click;
            reportsButton.Click += ReportsButton_Click;
            logoutButton.Click += LogoutButton_Click;

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

        private Button CreateButton(
            string text,
            int x,
            int y)
        {
            return new Button
            {
                Text = text,
                Size = new Size(210, 60),
                Location = new Point(x, y),
                Font = new Font(
                    "Segoe UI",
                    10,
                    FontStyle.Bold)
            };
        }

        private void BookManagementButton_Click(
            object? sender,
            EventArgs e)
        {
            MessageBox.Show(
                "Book Management will be implemented next.",
                "Book Management",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void IssueBookButton_Click(
            object? sender,
            EventArgs e)
        {
            MessageBox.Show(
                "Issue Book will be implemented next.",
                "Issue Book",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void ReturnBookButton_Click(
            object? sender,
            EventArgs e)
        {
            MessageBox.Show(
                "Return Book will be implemented next.",
                "Return Book",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void RecordsButton_Click(
            object? sender,
            EventArgs e)
        {
            MessageBox.Show(
                "Records will be implemented next.",
                "Records",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void SearchButton_Click(
            object? sender,
            EventArgs e)
        {
            MessageBox.Show(
                "Search will be implemented next.",
                "Search",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void ReportsButton_Click(
            object? sender,
            EventArgs e)
        {
            MessageBox.Show(
                "Reports and Print Preview will be implemented next.",
                "Reports",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void LogoutButton_Click(
            object? sender,
            EventArgs e)
        {
            Close();
        }
    }
}
