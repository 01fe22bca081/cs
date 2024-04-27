using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace LibraryManagementSystem
{
    public partial class MainForm : Form
    {
        private string connectionString = "YourConnectionStringHere";

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            RefreshBookList();
        }

        private void RefreshBookList()
        {
            dataGridViewBooks.Rows.Clear();
            List<Book> books = GetAllBooks();
            foreach (var book in books)
            {
                dataGridViewBooks.Rows.Add(book.Title, book.AuthorName, book.ISBN, book.Quantity);
            }
        }

        private List<Book> GetAllBooks()
        {
            List<Book> books = new List<Book>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT b.Title, a.Name AS AuthorName, b.ISBN, b.Quantity " +
                               "FROM Books b " +
                               "JOIN Authors a ON b.AuthorID = a.AuthorID";
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Book book = new Book
                    {
                        Title = reader["Title"].ToString(),
                        AuthorName = reader["AuthorName"].ToString(),
                        ISBN = reader["ISBN"].ToString(),
                        Quantity = Convert.ToInt32(reader["Quantity"])
                    };
                    books.Add(book);
                }
            }
            return books;
        }

        private void buttonAddBook_Click(object sender, EventArgs e)
        {
            string title = textBoxTitle.Text;
            string authorName = textBoxAuthor.Text;
            string isbn = textBoxISBN.Text;
            int quantity = (int)numericUpDownQuantity.Value;

            Book newBook = new Book
            {
                Title = title,
                AuthorName = authorName,
                ISBN = isbn,
                Quantity = quantity
            };

            AddNewBook(newBook);
            RefreshBookList();
        }

        private void AddNewBook(Book book)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Books (Title, AuthorID, ISBN, Quantity) " +
                               "VALUES (@Title, @AuthorID, @ISBN, @Quantity)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Title", book.Title);
                command.Parameters.AddWithValue("@AuthorID", GetAuthorIDByName(book.AuthorName)); // Implement GetAuthorIDByName method
                command.Parameters.AddWithValue("@ISBN", book.ISBN);
                command.Parameters.AddWithValue("@Quantity", book.Quantity);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        private int GetAuthorIDByName(string authorName)
        {
            // Implement this method to get author ID from the database
            throw new NotImplementedException();
        }
    }

    public class Book
    {
        public string Title { get; set; }
        public string AuthorName { get; set; }
        public string ISBN { get; set; }
        public int Quantity { get; set; }
    }
}