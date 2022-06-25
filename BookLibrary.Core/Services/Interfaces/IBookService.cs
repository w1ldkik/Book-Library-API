using BookLibrary.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary.Core.Services.Interfaces
{
    public interface IBookService
    {
        Task ValidateAndAddAsync(string name, double price);
        Task<List<Book>> GetAllAsync();
        Task ValidateAndUpdateAsync(Book book);
        Task ValidateAndDeleteAsync(int id);
        Task<Book> GetByIdAsync(int id);


    }
}
