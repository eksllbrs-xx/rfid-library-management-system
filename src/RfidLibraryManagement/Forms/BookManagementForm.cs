using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using RfidLibraryManagement.Data;

namespace RfidLibraryManagement.Forms
{
    public class BookManagementForm : Form
    {
        private TextBox titleTextBox = null!;
        private TextBox authorTextBox = null!;
        private TextBox editionTextBox = null!;
        private TextBox copiesTextBox = null!;
        private TextBox callNumberTextBox = null!;
        private TextBox accessionNumberTextBox = null!;
        private TextBox isbnTextBox = null!;
        private TextBox natureTextBox = null!;
        private TextBox locationTextBox = null!;
        private TextBox categoryTextBox = null!;
        private TextBox shelfNumberTextBox = null!;
        private TextBox priceTextBox = null!;
        private TextBox abstractTextBox = null!;

        private DateTimePicker registrationDatePicker = null!;

        private Button saveButton = null!;
        private Button updateButton = null!;
        private Button deleteButton = null!;
        private Button clearButton = null!;
        private Button closeButton = null!;

        private DataGridView booksGrid = null!;

        public BookManagementForm()
        {
            InitializeForm();
            LoadBooks();
        }

        private void InitializeForm()
        {
            Text = "Book Management";
            StartPosition = FormStartPosition.CenterScreen;
            Size = new Size(1100, 750);
            MinimumSize = new Size(1000, 650);

            Label titleLabel = new Label
            {
                Text = "BOOK MANAGEMENT",
                AutoSize = true,
                Font = new Font("Segoe UI", 20, FontStyle.Bold),
                Location = new Point(30, 25)
            };

            Controls.Add(titleLabel);

            int labelX = 30;
            int inputX = 170;
            int rowY = 85;
            int rowGap = 42;
            int inputWidth = 260;

            AddLabel("Book Title:", labelX, rowY);
            titleTextBox = AddTextBox(inputX, rowY, inputWidth);

            AddLabel("Author(s):", labelX, rowY += rowGap);
            authorTextBox = AddTextBox(inputX, rowY, inputWidth);

            AddLabel("Edition:", labelX, rowY += rowGap);
            editionTextBox = AddTextBox(inputX, rowY, inputWidth);

            AddLabel("Copies:", labelX, rowY += rowGap);
            copiesTextBox = AddTextBox(inputX, rowY, inputWidth);

            AddLabel("Call Number:", labelX, rowY += rowGap);
            callNumberTextBox = AddTextBox(inputX, rowY, inputWidth);

            AddLabel("Accession No.:", labelX, rowY += rowGap);
            accessionNumberTextBox = AddTextBox(inputX, rowY, inputWidth);

            AddLabel("ISBN:", labelX, rowY += rowGap);
            isbnTextBox = AddTextBox(inputX, rowY, inputWidth);

            int rightLabelX = 480;
            int rightInputX = 620;
            int rightY = 85;

            AddLabel("Nature of Content:", rightLabelX, rightY);
            natureTextBox = AddTextBox(rightInputX, rightY, inputWidth);

            AddLabel("Location:", rightLabelX, rightY += rowGap);
            locationTextBox = AddTextBox(rightInputX, rightY, inputWidth);

            AddLabel("Category:", rightLabelX, rightY += rowGap);
            categoryTextBox = AddTextBox(rightInputX, rightY, inputWidth);

            AddLabel("Shelf Number:", rightLabelX, rightY += rowGap);
            shelfNumberTextBox = AddTextBox(rightInputX, rightY, inputWidth);

            AddLabel("Registration Date:", rightLabelX, rightY += rowGap);

            registrationDatePicker = new DateTimePicker
            {
                Location = new Point(rightInputX, rightY),
                Width = inputWidth,
                Format = DateTimePickerFormat.Short
            };

            Controls.Add(registrationDatePicker);

            AddLabel("Price:", rightLabelX, rightY += rowGap);
            priceTextBox = AddTextBox(rightInputX, rightY, inputWidth);

            AddLabel("Abstract:", rightLabelX, rightY += rowGap);

            abstractTextBox = new TextBox
            {
                Location = new Point(rightInputX, rightY),
                Width = inputWidth,
                Height = 80,
                Multiline = true,
                ScrollBars = ScrollBars.Vertical
            };

            Controls.Add(abstractTextBox);

            saveButton = new Button
{
    Text = "SAVE BOOK",
    Location = new Point(30, 405),
    Size = new Size(120, 45)
};

updateButton = new Button
{
    Text = "UPDATE",
    Location = new Point(160, 405),
    Size = new Size(120, 45)
};

deleteButton = new Button
{
    Text = "DELETE",
    Location = new Point(290, 405),
    Size = new Size(120, 45)
};

clearButton = new Button
{
    Text = "CLEAR",
    Location = new Point(420, 405),
    Size = new Size(120, 45)
};

closeButton = new Button
{
    Text = "CLOSE",
    Location = new Point(550, 405),
    Size = new Size(120, 45)
};

            saveButton.Click += SaveButton_Click;
            updateButton.Click += UpdateButton_Click;
            deleteButton.Click += DeleteButton_Click;
            clearButton.Click += ClearButton_Click;
            closeButton.Click += CloseButton_Click;

            Controls.Add(saveButton);
            Controls.Add(updateButton);
            Controls.Add(deleteButton);
            Controls.Add(clearButton);
            Controls.Add(closeButton);

            booksGrid = new DataGridView
{
    Location = new Point(30, 475),
    Size = new Size(1010, 190),
    ReadOnly = true,
    AllowUserToAddRows = false,
    AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
    SelectionMode = DataGridViewSelectionMode.FullRowSelect,
    MultiSelect = false
};

            Controls.Add(booksGrid);
            booksGrid.CellClick += BooksGrid_CellClick;
        }

        private void AddLabel(
            string text,
            int x,
            int y)
        {
            Controls.Add(new Label
            {
                Text = text,
                AutoSize = true,
                Location = new Point(x, y + 4),
                Font = new Font("Segoe UI", 9)
            });
        }

        private TextBox AddTextBox(
            int x,
            int y,
            int width)
        {
            TextBox textBox = new TextBox
            {
                Location = new Point(x, y),
                Width = width
            };

            Controls.Add(textBox);

            return textBox;
        }

        private void LoadBooks()
        {
            try
            {
                using MySqlConnection connection =
                    Database.GetConnection();

                connection.Open();

                string query = @"
                    SELECT
                        book_id,
                        accession_number,
                        call_number,
                        isbn,
                        title,
                        author,
                        edition,
                        publication_year,
                        category,
                        nature_of_content,
                        location,
                        shelf_number,
                        copies,
                        available_copies,
                        price,
                        date_registered
                    FROM books
                    ORDER BY title;";

                using MySqlCommand command =
                    new MySqlCommand(query, connection);

                using MySqlDataAdapter adapter =
                    new MySqlDataAdapter(command);

                DataTable table = new DataTable();

                adapter.Fill(table);

                booksGrid.DataSource = table;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Unable to load books.\n\n" +
                    $"Details: {ex.Message}",
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void SaveButton_Click(
    object? sender,
    EventArgs e)
{
    if (string.IsNullOrWhiteSpace(titleTextBox.Text) ||
        string.IsNullOrWhiteSpace(accessionNumberTextBox.Text))
    {
        MessageBox.Show(
            "Book Title and Accession Number are required.",
            "Required Fields",
            MessageBoxButtons.OK,
            MessageBoxIcon.Warning);

        return;
    }

    if (!int.TryParse(copiesTextBox.Text, out int copies))
    {
        MessageBox.Show(
            "Copies must be a valid whole number.",
            "Invalid Copies",
            MessageBoxButtons.OK,
            MessageBoxIcon.Warning);

        copiesTextBox.Focus();
        return;
    }

    if (copies < 1)
    {
        MessageBox.Show(
            "Copies must be at least 1.",
            "Invalid Copies",
            MessageBoxButtons.OK,
            MessageBoxIcon.Warning);

        copiesTextBox.Focus();
        return;
    }

    decimal price = 0;

    if (!string.IsNullOrWhiteSpace(priceTextBox.Text) &&
        !decimal.TryParse(priceTextBox.Text, out price))
    {
        MessageBox.Show(
            "Price must be a valid number.",
            "Invalid Price",
            MessageBoxButtons.OK,
            MessageBoxIcon.Warning);

        priceTextBox.Focus();
        return;
    }

    try
    {
        using MySqlConnection connection =
            Database.GetConnection();

        connection.Open();

        string query = @"
            INSERT INTO books
            (
                accession_number,
                call_number,
                isbn,
                title,
                author,
                edition,
                category,
                nature_of_content,
                location,
                shelf_number,
                copies,
                available_copies,
                price,
                abstract,
                date_registered
            )
            VALUES
            (
                @accessionNumber,
                @callNumber,
                @isbn,
                @title,
                @author,
                @edition,
                @category,
                @nature,
                @location,
                @shelfNumber,
                @copies,
                @availableCopies,
                @price,
                @abstract,
                @dateRegistered
            );";

        using MySqlCommand command =
            new MySqlCommand(query, connection);

        command.Parameters.AddWithValue(
            "@accessionNumber",
            accessionNumberTextBox.Text.Trim());

        command.Parameters.AddWithValue(
            "@callNumber",
            callNumberTextBox.Text.Trim());

        command.Parameters.AddWithValue(
            "@isbn",
            isbnTextBox.Text.Trim());

        command.Parameters.AddWithValue(
            "@title",
            titleTextBox.Text.Trim());

        command.Parameters.AddWithValue(
            "@author",
            authorTextBox.Text.Trim());

        command.Parameters.AddWithValue(
            "@edition",
            editionTextBox.Text.Trim());

        command.Parameters.AddWithValue(
            "@category",
            categoryTextBox.Text.Trim());

        command.Parameters.AddWithValue(
            "@nature",
            natureTextBox.Text.Trim());

        command.Parameters.AddWithValue(
            "@location",
            locationTextBox.Text.Trim());

        command.Parameters.AddWithValue(
            "@shelfNumber",
            shelfNumberTextBox.Text.Trim());

        command.Parameters.AddWithValue(
            "@copies",
            copies);

        command.Parameters.AddWithValue(
            "@availableCopies",
            copies);

        command.Parameters.AddWithValue(
            "@price",
            price);

        command.Parameters.AddWithValue(
            "@abstract",
            abstractTextBox.Text.Trim());

        command.Parameters.AddWithValue(
            "@dateRegistered",
            registrationDatePicker.Value.Date);

        command.ExecuteNonQuery();

        MessageBox.Show(
            "Book successfully added.",
            "Book Management",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information);

        ClearButton_Click(sender, e);

        LoadBooks();
    }
    catch (MySqlException ex)
    {
        if (ex.Number == 1062)
        {
            MessageBox.Show(
                "The Accession Number already exists.",
                "Duplicate Book",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
        }
        else
        {
            MessageBox.Show(
                "Unable to save the book.\n\n" +
                $"Details: {ex.Message}",
                "Database Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
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

        private void ClearButton_Click(
            object? sender,
            EventArgs e)
        {
            titleTextBox.Clear();
            authorTextBox.Clear();
            editionTextBox.Clear();
            copiesTextBox.Clear();
            callNumberTextBox.Clear();
            accessionNumberTextBox.Clear();
            isbnTextBox.Clear();
            natureTextBox.Clear();
            locationTextBox.Clear();
            categoryTextBox.Clear();
            shelfNumberTextBox.Clear();
            priceTextBox.Clear();
            abstractTextBox.Clear();

            registrationDatePicker.Value = DateTime.Today;

            titleTextBox.Focus();
        }

        private void CloseButton_Click(
            object? sender,
            EventArgs e)
        {
            Close();
        }
    }
}
