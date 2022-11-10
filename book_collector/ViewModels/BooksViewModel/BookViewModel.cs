namespace book_collector.ViewModels.BooksViewModel
{
    public class BookViewModel
    {
        public string Id { get; set; }
        public string bookName { get; set; }
        public int bookEdition { get; set; }
        public bool isArchived { get; set; }
        public string publisher { get; set; }
        public int isbnNumber { get; set; }
    }
}
