using BookLibrary.Infrastructure.Models;
using BookLibrary.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary.Infrastructure.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly LibraryContext libraryContext;

        public BookRepository(LibraryContext libraryContext)
        {
            this.libraryContext = libraryContext;
        }

        public async Task AddBookAsync(Book book)
        {
            await libraryContext.Books.AddAsync(book);
            await libraryContext.SaveChangesAsync();
        }

        public async Task DeleteBookAsync(Book book)
        {
            libraryContext.Books.Remove(book);
            await libraryContext.SaveChangesAsync();
        }

        public async Task<List<Book>> GetAllBooksAsync()
        {
            return await libraryContext.Books.Select(x => x).ToListAsync();
        }

        public async Task<Book> GetBookByIdAsync(int id)
        {
            return await libraryContext.Books.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        

        public async Task UpdateBookAsync(Book book)
        {
            libraryContext.Books.Update(book);
            await libraryContext.SaveChangesAsync();
        }


    }
}
