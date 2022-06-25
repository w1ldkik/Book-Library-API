using BookLibrary.Infrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly LibraryContext libraryContext;
        private IBookRepository bookRepository;

        public UnitOfWork(LibraryContext libraryContext)
        {
            this.libraryContext = libraryContext;
        }
        public IBookRepository BookRepository 
        {
            get 
            {
                if (bookRepository == null)
                {
                    bookRepository = new BookRepository(libraryContext);
                }
                return bookRepository;
            }
        }

        
    }
}
