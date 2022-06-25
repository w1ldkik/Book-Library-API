using BookLibrary.Core.Services.Interfaces;
using BookLibrary.Infrastructure.Models;
using BookLibrary.Infrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary.Core.Services
{
    public class BookService : IBookService
    {
        private readonly IUnitOfWork unitOfWork;

        public BookService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }


        public async Task<List<Book>> GetAllAsync()
        {
            return await unitOfWork.BookRepository.GetAllBooksAsync();
        }

        public async Task<Book> GetByIdAsync(int id)
        {
            return await unitOfWork.BookRepository.GetBookByIdAsync(id);
            
        }

        public async Task ValidateAndAddAsync(string name, double price)
        {
            var book = new Book 
            {
                Name = name,
                Price = price
            };
            await unitOfWork.BookRepository.AddBookAsync(book);
        }

        public async Task ValidateAndDeleteAsync(int id)
        {
           await unitOfWork.BookRepository.DeleteBookAsync(await GetByIdAsync(id));

        }

        public async Task ValidateAndUpdateAsync(Book book)
        {
            await unitOfWork.BookRepository.UpdateBookAsync(book);
        }
    }
}
