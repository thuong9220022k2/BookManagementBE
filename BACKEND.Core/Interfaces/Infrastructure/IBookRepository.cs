using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BACKEND.Core.Models;

namespace BACKEND.Core.Interfaces.Infrastructure
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> GetAllBooks();
        Task<IEnumerable<Book>> GetBookById(Guid bookId);
        // Task<bool> AddBook(Book book);
        // Task<bool> UpdateBook(Book book);
        // Task<bool> DeleteBook(Guid bookId);
    }
}