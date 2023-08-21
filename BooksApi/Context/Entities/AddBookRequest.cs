using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BooksApi.Context.Entities
{
    public class AddBookRequest
    {
        public string ISBN { get; set; } = null!;

        public string Title { get; set; } = null!;

        public string Author { get; set; } = null!;

        public DateTime PublishedDate { get; set; }

        public string Description { get; set; } = null!;

        public decimal? Price { get; set; }

        public bool? IsAvailable { get; set; }
    }
}
