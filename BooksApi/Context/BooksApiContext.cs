using BooksApi.Context.Entities;
using Microsoft.EntityFrameworkCore;

namespace BooksApi.Context
{
    public class BooksApiContext : DbContext
    {
        public BooksApiContext(DbContextOptions<BooksApiContext> options): base(options){ }

        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            optionBuilder.UseSqlServer("Data Source=.;Initial Catalog=BooksApi;Integrated Security=True;");
        }

        // add tables
        public DbSet<Book> Books { get; set; } = null!;
    }
}
