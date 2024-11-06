using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Extensions.Configuration;
using MySqlConnector;
using BACKEND.Core.Enums;
using BACKEND.Core.Models;
using BACKEND.Core.Interfaces.Infrastructure;

namespace BACKEND.Infra.Repos
{
    public class BookRepository : IBookRepository
    {
        #region Fields
        protected string TableName = "Book";
        string _connection_string = string.Empty;
        protected IDbConnection connection = null;

        #endregion

        #region Constructor
        public BookRepository(IConfiguration configuration)
        {
            _connection_string = configuration.GetConnectionString("ConnectionString");
        }
        #endregion

        #region Methods
        public async Task<IEnumerable<Book>> GetAllBooks()
        {
            using (connection = new MySqlConnection(_connection_string))
            {
                var sql = @"SELECT 
                        Book.*, 
                        Author.*, 
                        Publisher.*,
                        Category.*
                    FROM
                        Book
                    INNER JOIN
                        Author ON Book.AuthorId = Author.AuthorId
                    INNER JOIN
                        Publisher ON Book.PublisherId = Publisher.PublisherId
                    INNER JOIN
                        Category ON Book.CategoryId = Category.CategoryId; ";
                var books = await connection.QueryAsync<Book, Author, Publisher, Category, Book>(sql, (book, author, publisher, category) =>
                {
                    book.Author = author;
                    book.Publisher = publisher;
                    book.Category = category;
                    return book;
                }, splitOn: "AuthorId,PublisherId,CategoryId");
                return books;
            }
        }

        public async Task<IEnumerable<Book>> GetBookById(Guid bookId)
        {
            using (connection = new MySqlConnection(_connection_string))
            {
                var sql = @"SELECT 
                        Book.*, 
                        Author.*, 
                        Publisher.*,
                        Category.*
                    FROM
                        Book
                    INNER JOIN
                        Author ON Book.AuthorId = Author.AuthorId
                    INNER JOIN
                        Publisher ON Book.PublisherId = Publisher.PublisherId
                    INNER JOIN
                        Category ON Book.CategoryId = Category.CategoryId
                    WHERE Book.BookId = @entityId; ";

                var parameters = new DynamicParameters();
                parameters.Add("@entityId", bookId);
                var books = await connection.QueryAsync<Book, Author, Publisher, Category, Book>(sql, (book, author, publisher, category) =>
                {
                    book.Author = author;
                    book.Publisher = publisher;
                    book.Category = category;
                    return book;
                }, parameters, splitOn: "AuthorId,PublisherId,CategoryId");
                return books;
            }
        }


        #endregion

    }
}