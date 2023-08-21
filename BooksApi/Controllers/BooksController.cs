using BooksApi.Context;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult GetBooks()
        {
            var books = dbContext.Books.ToList();
            return Ok(books);
        }
    }
}
