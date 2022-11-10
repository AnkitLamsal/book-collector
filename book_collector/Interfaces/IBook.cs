using book_collector.Models;

namespace book_collector.Interfaces
{
    public interface IBook
    {
        List<Book> GetAll();
        Book GetById(string Id);
        void Insert(Book book);
        void Update(Book book);
        void Delete (Book book);
    }
}
