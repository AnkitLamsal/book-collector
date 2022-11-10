using System.ComponentModel.DataAnnotations;

namespace book_collector.Models
{
    public class BookCollection
    {
        public string bookId { get; set; }
        public string collectionId { get; set; }
        public Book Book { get; set; }
        public Collection Collection { get; set; }

    }
}
