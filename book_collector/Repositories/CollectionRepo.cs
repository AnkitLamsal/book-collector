using book_collector.Data;
using book_collector.Interfaces;
using book_collector.Models;
using Microsoft.EntityFrameworkCore;

namespace book_collector.Repositories
{
    public class CollectionRepo : ICollection
    {
        private readonly book_collectorContext _context;

        public CollectionRepo(book_collectorContext context)
        {
            _context = context;
        }

        public void Delete(Collection collection)
        {
            _context.Collections.Remove(collection);
        }

        public List<Collection> GetAll()
        {
            return _context.Collections.ToList();
        }

        public Collection GetById(string Id)
        {
            return _context.Collections.Include("bookCollections.Book").FirstOrDefault(x => x.Id == Id);
        }

        public void Insert(Collection collection)
        {
            _context.Collections.Add(collection);
        }

        public void Update(Collection collection)
        {
            _context.Collections.Update(collection);
        }

   }
}
