using book_collector.Data;
using book_collector.Interfaces;
using book_collector.Models;

namespace book_collector.Repositories
{
    public class BookRepo : IBook
    {
        private readonly book_collectorContext _context;

        public BookRepo(book_collectorContext context)
        {
            _context = context;
        }

        public void Delete(Book book)
        {
            _context.Books.Remove(book);
        }

        public List<Book> GetAll()
        {
            return _context.Books.ToList();
        }

        public Book GetById(string Id)
        {
            return _context.Books.FirstOrDefault(x => x.Id == Id);
        }

        public void Insert(Book book)
        {
            _context.Books.Add(book);
        }

        public void Update(Book book)
        {
            _context.Books.Update(book);
        }
    }
}
