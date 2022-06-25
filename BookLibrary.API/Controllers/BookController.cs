using BookLibrary.Core.Services.Interfaces;
using BookLibrary.Infrastructure.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookLibrary.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService bookService;

        public BookController(IBookService bookService)
        {
            this.bookService = bookService;
        }

        [HttpPost]
        public async Task<IActionResult> AddBook(string name, double price)
        {
            await bookService.ValidateAndAddAsync(name, price);
            return Ok($"The book with name '{name}' wich cost {price} has been added successfully!");

        }

        [HttpDelete]
        public async Task<IActionResult> ValidateAndDeleteAsync(int id)
        {
            await bookService.ValidateAndDeleteAsync(id);
            return Ok($"The book with id:{id} has been deleted successfully!");
        }

        [HttpGet("{id}")]
        public async Task<Book> GetBookByIdAsync(int id)
        {
            return await bookService.GetByIdAsync(id);
        }

        [HttpGet("all")]
        public async Task<List<Book>> GetAllBookAsync()
        {
            return await bookService.GetAllAsync(); 
        }

        [HttpPut]

        public async Task ValidateAndUpdateAsync(Book book)
        {
            await bookService.ValidateAndUpdateAsync(book);
            
            
        }
    }
}
