using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using BACKEND.Core.Models;
using BACKEND.Core.Interfaces.Infrastructure;
using BACKEND.Core.Interfaces.Service;

namespace BACKEND.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        #region Fields
        IBookService _bookService;

        #endregion

        #region Constructor
        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }
        #endregion

        [HttpGet]
        public async Task<IActionResult> GetAllBooks()
        {
            try
            {
                var result = await _bookService.GetAllBooks();
                return Ok(result);

            }
            catch (Exception ex)
            {
                return StatusCode(500, new ServiceResult(ex));
            }

        }
        [HttpGet("{bookId}")]
        public async Task<IActionResult> GetBookById(Guid bookId)
        {
            try
            {
                var result = await _bookService.GetBookById(bookId);
                return Ok(result);

            }
            catch (Exception ex)
            {
                return StatusCode(500, new ServiceResult(ex));
            }

        }


    }


}