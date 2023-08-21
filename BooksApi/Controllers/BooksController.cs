using BooksApi.Context;
using BooksApi.Context.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BooksApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : Controller
    {
        private readonly BooksApiContext dbContext;

        public BooksController(BooksApiContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetBooks()
        {
            var books = await dbContext.Books.ToListAsync();
            return Ok(books);
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetBook([FromRoute] Guid id)
        {
            var book = await dbContext.Books.FindAsync(id);
            
            if (book == null)
            {
                return NotFound();
            }

            return Ok(book);

        }

        [HttpPost]
        public async Task<IActionResult> AddBook(AddBookRequest addBookRequest)
        {
            var book = new Book()
            {
                Id = Guid.NewGuid(),
                ISBN = addBookRequest.ISBN,
                Title = addBookRequest.Title,
                Author = addBookRequest.Author,
                PublishedDate = addBookRequest.PublishedDate,
                Description = addBookRequest.Description,
                Price = addBookRequest.Price,
                IsAvailable = addBookRequest.IsAvailable,
            };

            await dbContext.Books.AddAsync(book);
            await dbContext.SaveChangesAsync();
            return StatusCode(StatusCodes.Status201Created, book);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateBook([FromRoute] Guid id, UpdateBookRequest updateBookRequest)
        {
            var book = await dbContext.Books.FindAsync(id);

            if(book != null)
            {
                book.ISBN = updateBookRequest.ISBN;
                book.Title = updateBookRequest.Title;
                book.Author = updateBookRequest.Author;
                book.PublishedDate = updateBookRequest.PublishedDate;
                book.Description = updateBookRequest.Description;
                book.Price = updateBookRequest.Price;
                book.IsAvailable = updateBookRequest.IsAvailable;

                await dbContext.SaveChangesAsync();
                return Ok(book);
            }

            return NotFound();
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteBook([FromRoute] Guid id)
        {
            var book = await dbContext.Books.FindAsync(id);

            if(book != null)
            {
                dbContext.Books.Remove(book);
                await dbContext.SaveChangesAsync();
                return NoContent();
            }

            return NotFound();
        }

    }
}
