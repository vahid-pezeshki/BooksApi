namespace BooksApi.Models
{
    public class BookDto
    {
        public Guid? Id { get; set; }
        public string? ISBN { get; set; }
        public string? Title { get; set; }
        public string? Author { get; set; }
        public DateTime? PublishedDate { get; set; }
        public int? TotalPages { get; set; }
        public string? Description { get; set; }
        public decimal? Price { get; set; }
        public bool? IsAvailable { get; set; }
    }
}
