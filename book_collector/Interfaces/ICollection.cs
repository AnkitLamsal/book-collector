using book_collector.Models;

namespace book_collector.Interfaces
{
    public interface ICollection
    {
        List<Collection> GetAll();
        Collection GetById(string Id);
        void Insert(Collection collection);
        void Update(Collection collection);
        void Delete(Collection collection);
    }
}
