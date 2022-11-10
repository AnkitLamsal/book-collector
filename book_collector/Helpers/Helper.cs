using AutoMapper;
using book_collector.Models;
using book_collector.ViewModels.BooksViewModel;
using book_collector.ViewModels.CollectionsViewModel;

namespace book_collector.Helpers
{
    public class Helper:Profile
    {
        public Helper()
        {
            CreateMap<Book,BookViewModel>().ReverseMap();
            CreateMap<CreateBookViewModel,Book>().ReverseMap();
            CreateMap<Collection,CollectionViewModel>().ReverseMap();
        }
    }
}
