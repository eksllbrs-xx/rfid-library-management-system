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
        // ==============================
        // FORM CONTROLS
        // ==============================

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


        // ==============================
        // CONSTRUCTOR
        // ==============================

        public BookManagementForm()
        {
            InitializeForm();
            LoadBooks();
        }


        // ==============================
        // INITIALIZE FORM
        // ==============================

        private void InitializeForm()
        {
            Text = "Book Management";
            StartPosition = FormStartPosition.CenterScreen;
            Size = new Size(1100, 750);
            MinimumSize = new Size(1000, 650);

            // ------------------------------
            // TITLE
            // ------------------------------

            Label titleLabel = new Label
            {
                Text = "BOOK MANAGEMENT",
                AutoSize = true,
                Font = new Font(
                    "Segoe UI",
                    20,
                    FontStyle.Bold),
                Location = new Point(30, 25)
            };

            Controls.Add(titleLabel);


            // ------------------------------
            // LEFT SIDE FIELDS
            // ------------------------------

            int labelX = 30;
            int inputX = 170;
            int rowY = 85;
            int rowGap = 42;
            int inputWidth = 260;

            AddLabel(
                "Book Title:",
                labelX,
                rowY);

            titleTextBox =
                AddTextBox(
                    inputX,
                    rowY,
                    inputWidth);


            AddLabel(
                "Author(s):",
                labelX,
                rowY += rowGap);

            authorTextBox =
                AddTextBox(
                    inputX,
                    rowY,
                    inputWidth);


            AddLabel(
                "Edition:",
                labelX,
                rowY += rowGap);

            editionTextBox =
                AddTextBox(
                    inputX,
                    rowY,
                    inputWidth);


            AddLabel(
                "Copies:",
                labelX,
                rowY += rowGap);

            copiesTextBox =
                AddTextBox(
                    inputX,
                    rowY,
                    inputWidth);


            AddLabel(
                "Call Number:",
                labelX,
                rowY += rowGap);

            callNumberTextBox =
                AddTextBox(
                    inputX,
                    rowY,
                    inputWidth);


            AddLabel(
                "Accession No.:",
                labelX,
                rowY += rowGap);

            accessionNumberTextBox =
                AddTextBox(
                    inputX,
                    rowY,
                    inputWidth);


            AddLabel(
                "ISBN:",
                labelX,
                rowY += rowGap);

            isbnTextBox =
                AddTextBox(
                    inputX,
                    rowY,
                    inputWidth);


            // ------------------------------
            // RIGHT SIDE FIELDS
            // ------------------------------

            int rightLabelX = 480;
            int rightInputX = 620;
            int rightY = 85;


            AddLabel(
                "Nature of Content:",
                rightLabelX,
                rightY);

            natureTextBox =
                AddTextBox(
                    rightInputX,
                    rightY,
                    inputWidth);


            AddLabel(
                "Location:",
                rightLabelX,
                rightY += rowGap);

            locationTextBox =
                AddTextBox(
                    rightInputX,
                    rightY,
                    inputWidth);


            AddLabel(
                "Category:",
                rightLabelX,
                rightY += rowGap);

            categoryTextBox =
                AddTextBox(
                    rightInputX,
                    rightY,
                    inputWidth);


            AddLabel(
                "Shelf Number:",
                rightLabelX,
                rightY += rowGap);

            shelfNumberTextBox =
                AddTextBox(
                    rightInputX,
                    rightY,
                    inputWidth);


            AddLabel(
                "Registration Date:",
                rightLabelX,
                rightY += rowGap);

            registrationDatePicker =
                new DateTimePicker
                {
                    Location =
                        new Point(
                            rightInputX,
                            rightY),

                    Width = inputWidth,

                    Format =
                        DateTimePickerFormat.Short
                };

            Controls.Add(
                registrationDatePicker);


            AddLabel(
                "Price:",
                rightLabelX,
                rightY += rowGap);

            priceTextBox =
                AddTextBox(
                    rightInputX,
                    rightY,
                    inputWidth);


            AddLabel(
                "Abstract:",
                rightLabelX,
                rightY += rowGap);

            abstractTextBox =
                new TextBox
                {
                    Location =
                        new Point(
                            rightInputX,
                            rightY),

                    Width = inputWidth,

                    Height = 80,

                    Multiline = true,

                    ScrollBars =
                        ScrollBars.Vertical
                };

            Controls.Add(
                abstractTextBox);


            // ------------------------------
            // BUTTONS
            // ------------------------------

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


            // ------------------------------
            // BUTTON EVENTS
            // ------------------------------

            saveButton.Click +=
                SaveButton_Click;

            updateButton.Click +=
                UpdateButton_Click;

            deleteButton.Click +=
                DeleteButton_Click;

            clearButton.Click +=
                ClearButton_Click;

            closeButton.Click +=
                CloseButton_Click;


            // ------------------------------
            // ADD BUTTONS
            // ------------------------------

            Controls.Add(
                saveButton);

            Controls.Add(
                updateButton);

            Controls.Add(
                deleteButton);

            Controls.Add(
                clearButton);

            Controls.Add(
                closeButton);


            // ------------------------------
            // BOOK DATA GRID
            // ------------------------------

            booksGrid =
                new DataGridView
                {
                    Location =
                        new Point(30, 475),

                    Size =
                        new Size(1010, 190),

                    ReadOnly = true,

                    AllowUserToAddRows = false,

                    AutoSizeColumnsMode =
                        DataGridViewAutoSizeColumnsMode.Fill,

                    SelectionMode =
                        DataGridViewSelectionMode.FullRowSelect,

                    MultiSelect = false
                };


            booksGrid.CellClick +=
                BooksGrid_CellClick;


            Controls.Add(
                booksGrid);
        }


        // ==============================
        // ADD LABEL
        // ==============================

        private void AddLabel(
            string text,
            int x,
            int y)
        {
            Controls.Add(
                new Label
                {
                    Text = text,

                    AutoSize = true,

                    Location =
                        new Point(
                            x,
                            y + 4),

                    Font =
                        new Font(
                            "Segoe UI",
                            9)
                });
        }


        // ==============================
        // ADD TEXTBOX
        // ==============================

        private TextBox AddTextBox(
            int x,
            int y,
            int width)
        {
            TextBox textBox =
                new TextBox
                {
                    Location =
                        new Point(
                            x,
                            y),

                    Width = width
                };

            Controls.Add(
                textBox);

            return textBox;
        }


        // ==============================
        // LOAD BOOKS
        // ==============================

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
                        abstract,
                        date_registered
                    FROM books
                    ORDER BY title;";


                using MySqlCommand command =
                    new MySqlCommand(
                        query,
                        connection);


                using MySqlDataAdapter adapter =
                    new MySqlDataAdapter(
                        command);


                DataTable table =
                    new DataTable();


                adapter.Fill(
                    table);


                booksGrid.DataSource =
                    table;
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


        // ==============================
        // SAVE BOOK
        // ==============================

        private void SaveButton_Click(
            object? sender,
            EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(
                titleTextBox.Text) ||
                string.IsNullOrWhiteSpace(
                    accessionNumberTextBox.Text))
            {
                MessageBox.Show(
                    "Book Title and Accession Number are required.",
                    "Required Fields",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }


            if (!int.TryParse(
                copiesTextBox.Text,
                out int copies))
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


            if (!string.IsNullOrWhiteSpace(
                priceTextBox.Text) &&
                !decimal.TryParse(
                    priceTextBox.Text,
                    out price))
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
                    new MySqlCommand(
                        query,
                        connection);


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


                ClearForm();


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


        // ==============================
        // SELECT BOOK FROM GRID
        // ==============================

        private void BooksGrid_CellClick(
            object? sender,
            DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;


            DataGridViewRow row =
                booksGrid.Rows[e.RowIndex];


            titleTextBox.Text =
                row.Cells["title"]
                    .Value?.ToString() ?? "";


            authorTextBox.Text =
                row.Cells["author"]
                    .Value?.ToString() ?? "";


            editionTextBox.Text =
                row.Cells["edition"]
                    .Value?.ToString() ?? "";


            copiesTextBox.Text =
                row.Cells["copies"]
                    .Value?.ToString() ?? "";


            callNumberTextBox.Text =
                row.Cells["call_number"]
                    .Value?.ToString() ?? "";


            accessionNumberTextBox.Text =
                row.Cells["accession_number"]
                    .Value?.ToString() ?? "";


            isbnTextBox.Text =
                row.Cells["isbn"]
                    .Value?.ToString() ?? "";


            natureTextBox.Text =
                row.Cells["nature_of_content"]
                    .Value?.ToString() ?? "";


            locationTextBox.Text =
                row.Cells["location"]
                    .Value?.ToString() ?? "";


            categoryTextBox.Text =
                row.Cells["category"]
                    .Value?.ToString() ?? "";


            shelfNumberTextBox.Text =
                row.Cells["shelf_number"]
                    .Value?.ToString() ?? "";


            priceTextBox.Text =
                row.Cells["price"]
                    .Value?.ToString() ?? "";


            abstractTextBox.Text =
                row.Cells["abstract"]
                    .Value?.ToString() ?? "";


            if (DateTime.TryParse(
                row.Cells["date_registered"]
                    .Value?.ToString(),
                out DateTime registrationDate))
            {
                registrationDatePicker.Value =
                    registrationDate;
            }
        }


        // ==============================
        // UPDATE BOOK
        // ==============================

        private void UpdateButton_Click(
            object? sender,
            EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(
                accessionNumberTextBox.Text))
            {
                MessageBox.Show(
                    "Please select a book to update.",
                    "Update Book",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }


            if (!int.TryParse(
                copiesTextBox.Text,
                out int copies))
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

                return;
            }


            decimal price = 0;


            if (!string.IsNullOrWhiteSpace(
                priceTextBox.Text) &&
                !decimal.TryParse(
                    priceTextBox.Text,
                    out price))
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
                    UPDATE books
                    SET
                        call_number = @callNumber,
                        isbn = @isbn,
                        title = @title,
                        author = @author,
                        edition = @edition,
                        category = @category,
                        nature_of_content = @nature,
                        location = @location,
                        shelf_number = @shelfNumber,
                        copies = @copies,
                        price = @price,
                        abstract = @abstract,
                        date_registered = @dateRegistered
                    WHERE accession_number =
                        @accessionNumber;";


                using MySqlCommand command =
                    new MySqlCommand(
                        query,
                        connection);


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
                    "@price",
                    price);


                command.Parameters.AddWithValue(
                    "@abstract",
                    abstractTextBox.Text.Trim());


                command.Parameters.AddWithValue(
                    "@dateRegistered",
                    registrationDatePicker.Value.Date);


                int affectedRows =
                    command.ExecuteNonQuery();


                if (affectedRows > 0)
                {
                    MessageBox.Show(
                        "Book successfully updated.",
                        "Book Management",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);


                    LoadBooks();


                    ClearForm();
                }
                else
                {
                    MessageBox.Show(
                        "No book was updated.",
                        "Update Book",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Unable to update the book.\n\n" +
                    $"Details: {ex.Message}",
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }


        // ==============================
        // DELETE BOOK
        // ==============================

        private void DeleteButton_Click(
            object? sender,
            EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(
                accessionNumberTextBox.Text))
            {
                MessageBox.Show(
                    "Please select a book to delete.",
                    "Delete Book",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }


            DialogResult result =
                MessageBox.Show(
                    "Are you sure you want to delete this book?\n\n" +
                    $"Accession Number: " +
                    $"{accessionNumberTextBox.Text}\n" +
                    $"Title: " +
                    $"{titleTextBox.Text}",
                    "Confirm Delete",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);


            if (result != DialogResult.Yes)
                return;


            try
            {
                using MySqlConnection connection =
                    Database.GetConnection();

                connection.Open();


                string query = @"
                    DELETE FROM books
                    WHERE accession_number =
                        @accessionNumber;";


                using MySqlCommand command =
                    new MySqlCommand(
                        query,
                        connection);


                command.Parameters.AddWithValue(
                    "@accessionNumber",
                    accessionNumberTextBox.Text.Trim());


                int affectedRows =
                    command.ExecuteNonQuery();


                if (affectedRows > 0)
                {
                    MessageBox.Show(
                        "Book successfully deleted.",
                        "Book Management",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);


                    LoadBooks();


                    ClearForm();
                }
                else
                {
                    MessageBox.Show(
                        "Book was not found.",
                        "Delete Book",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(
                    "This book cannot be deleted because it may " +
                    "already be referenced by another library " +
                    "transaction.\n\n" +
                    $"Details: {ex.Message}",
                    "Delete Failed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Unable to delete the book.\n\n" +
                    $"Details: {ex.Message}",
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }


        // ==============================
        // CLEAR FORM
        // ==============================

        private void ClearButton_Click(
            object? sender,
            EventArgs e)
        {
            ClearForm();
        }


        private void ClearForm()
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

            registrationDatePicker.Value =
                DateTime.Today;

            booksGrid.ClearSelection();

            titleTextBox.Focus();
        }


        // ==============================
        // CLOSE FORM
        // ==============================

        private void CloseButton_Click(
            object? sender,
            EventArgs e)
        {
            Close();
        }
    }
}
