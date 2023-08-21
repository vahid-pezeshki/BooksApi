using BooksApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BooksApi.Context
{
    public class BooksApiContext : DbContext
    {
        public BooksApiContext(DbContextOptions options) : base(options)
        {
        }

        // tables
        public DbSet<BookDto> Books { get; set; }
    }
}
