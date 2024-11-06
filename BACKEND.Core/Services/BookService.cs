using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using BACKEND.Core.Models;
using BACKEND.Core.Constants;
using BACKEND.Core.Enums;
using BACKEND.Core.Interfaces.Infrastructure;
using BACKEND.Core.Interfaces.Service;

namespace BACKEND.Core.Services
{
    public class BookService : IBookService
    {
        #region Fields
        IBookRepository _bookRepository;
        ServiceResult ServiceResult;
        #endregion

        #region Constructor
        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
            ServiceResult = new ServiceResult();
        }
        #endregion

        #region Methods 
        public async Task<ServiceResult> GetAllBooks()
        {
            var books = await _bookRepository.GetAllBooks();
            Console.WriteLine($"book data {books}");
            if (books != null)
            {
                ServiceResult.IsSuccess = true;
                ServiceResult.Data = books;
            }
            else
            {
                ServiceResult.IsSuccess = false;
            }
            return ServiceResult;



        }
        public async Task<ServiceResult> GetBookById(Guid bookId)
        {
            var book = await _bookRepository.GetBookById(bookId);
            Console.WriteLine($"book data {book}");
            if (book != null)
            {
                ServiceResult.IsSuccess = true;
                ServiceResult.Data = book;
            }
            else
            {
                ServiceResult.IsSuccess = false;
            }
            return ServiceResult;
        }
        // public async Task<ServiceResult> AddBook(Book book)
        // {
        //     //
        // }
        // public async Task<ServiceResult> UpdateBook(Book book)
        // {
        //     //
        // }
        // public async Task<ServiceResult> DeleteBook(Guid bookId)
        // {
        //     //
        // }


        #endregion
    }
}