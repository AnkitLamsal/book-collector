using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace book_collector.Models
{
    public class Collection
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        [Required]
        public string collectionName { get; set; }
        public string collectionDescription { get; set; }
        public List<BookCollection> bookCollections { get; set; } = new List<BookCollection>();
    }
}
