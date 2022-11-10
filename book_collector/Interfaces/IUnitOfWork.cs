namespace book_collector.Interfaces
{
    public interface IUnitOfWork
    {
        ICollection Collection { get; }
        IBook Book { get; }
        void Save();
    }
}
