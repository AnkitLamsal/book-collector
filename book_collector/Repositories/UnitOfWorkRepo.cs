using book_collector.Data;
using book_collector.Interfaces;

namespace book_collector.Repositories
{
    public class UnitOfWorkRepo : IUnitOfWork
    {
        private readonly book_collectorContext _context;
        private IBook _bookRepo;
        private ICollection _collectionRepo;
        public UnitOfWorkRepo(book_collectorContext context)
        {
            _context = context;
        }

        public ICollection Collection
        {
            get
            {
                return _collectionRepo = _collectionRepo ?? new CollectionRepo(_context);
            }
        }

        public IBook Book
        {
            get
            {
                return _bookRepo = _bookRepo ?? new BookRepo(_context);
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
