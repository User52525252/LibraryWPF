using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryWPF
{
    public class LibraryManager
    {   // String połączenia z bazą danych // należy zmienić przy użyciu innej bazy
        private string _connectionString = "Data Source=DESKTOP-BA60I3I;Initial Catalog=Biblioteka?;Integrated Security=True";


        /*public LibraryManager(string connectionString)
        {
             
            _connectionString = connectionString;
        }*/

        public LibraryManager()
        {
        }

        public void AddBook(Book book)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "INSERT INTO Books (Title, Author, ISBN, Publisher, Status) VALUES (@Title, @Author, @ISBN, @Publisher, @Status)";
                    command.Parameters.AddWithValue("@Title", book.Title);
                    command.Parameters.AddWithValue("@Author", book.Author);
                    command.Parameters.AddWithValue("@ISBN", book.ISBN);
                    command.Parameters.AddWithValue("@Publisher", book.Publisher);
                    command.Parameters.AddWithValue("@Status", book.Status);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void EditBook(Book book)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "UPDATE Books SET Title = @Title, Author = @Author, ISBN = @ISBN, Publisher = @Publisher, Status = @Status WHERE ISBN = @ISBN";
                    command.Parameters.AddWithValue("@Title", book.Title);
                    command.Parameters.AddWithValue("@Author", book.Author);
                    command.Parameters.AddWithValue("@ISBN", book.ISBN);
                    command.Parameters.AddWithValue("@Publisher", book.Publisher);
                    command.Parameters.AddWithValue("@Status", book.Status);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void DeleteBook(string ISBN)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "DELETE FROM Books WHERE ISBN = @ISBN";
                    command.Parameters.AddWithValue("@ISBN", ISBN);
                    command.ExecuteNonQuery();
                }
            }
        }

        public List<Book> SearchBooks(string searchText)
        {
            var books = new List<Book>();
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT * FROM Books WHERE Title LIKE @SearchText OR Author LIKE @SearchText OR ISBN LIKE @SearchText OR Publisher LIKE @SearchText";
                    command.Parameters.AddWithValue("@SearchText", "%" + searchText + "%");
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var book = new Book
                            {
                                Title = reader["Title"].ToString(),
                                Author = reader["Author"].ToString(),
                                ISBN = reader["ISBN"].ToString(),
                                Publisher = reader["Publisher"].ToString(),
                                Status = reader["Status"].ToString()
                            };
                            books.Add(book);
                        }
                    }
                }
            }
            return books;
        }

        public void Checkin(Book book)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "UPDATE Books SET Status = 'Dostepne' WHERE ISBN = @ISBN ";
                    command.Parameters.AddWithValue("@Status", book.Status);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void Checkout(Book book)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "UPDATE Books SET Status = 'NieDostepne' WHERE ISBN = @ISBN ";
                    command.Parameters.AddWithValue("@Status", book.Status);
                    command.ExecuteNonQuery();
                }
            }
        }


    }
}
