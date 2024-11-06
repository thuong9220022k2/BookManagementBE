using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BACKEND.Core.Models;

namespace BACKEND.Core.Interfaces.Service
{
    public interface IBookService
    {
        Task<ServiceResult> GetAllBooks();
        Task<ServiceResult> GetBookById(Guid bookId);
        // Task<ServiceResult> AddBook(Book book);
        // Task<ServiceResult> UpdateBook(Book book);
        // Task<ServiceResult> DeleteBook(Guid bookId);
    }
}