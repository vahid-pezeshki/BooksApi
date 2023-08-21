using BooksApi.Context.Entities;
using Microsoft.EntityFrameworkCore;

namespace BooksApi.Context
{
    public class BooksApiContext : DbContext
    {
        public BooksApiContext(DbContextOptions options) : base(options)
        {
        }

        // add tables
        public DbSet<Book> Books { get; set; }
    }
}
