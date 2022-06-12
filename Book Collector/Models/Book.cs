namespace Book_Collector.Models
{
    public class Book
    {
        public int book_id { get; set; }
        public string book_name { get; set; }
        public int book_edition { get; set; }
        public bool is_archived { get; set; }
        public string publisher { get; set; }
        public int isbn_number { get; set; }
    }
}
