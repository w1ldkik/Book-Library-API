using BookLibrary.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary.Infrastructure
{
    public class LibraryContext : DbContext
    {
        

        public LibraryContext()
        {

        }
        public LibraryContext(DbContextOptions options) : base(options)
        {

        }


        public DbSet<Book> Books { get; set; }
    }
}
