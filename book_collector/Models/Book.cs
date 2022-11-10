using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace book_collector.Models
{
    public class Book
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        public string bookName { get; set; }
        public int bookEdition { get; set; }
        public bool isArchived { get; set; }
        public string publisher { get; set; }
        [Required]
        public int isbnNumber { get; set; }
        public List <BookCollection> bookCollections { get; set; }
    }
}
