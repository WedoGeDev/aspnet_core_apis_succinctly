using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookRepository.Core;
using Microsoft.EntityFrameworkCore;

namespace BookRepository.Data
{
    public class BookRepoDbContext : DbContext
    {
        public BookRepoDbContext(DbContextOptions<BookRepoDbContext> options) : base(options)
        {

        }
        
        public DbSet<Book> Books { get; set; }
    }
}