﻿using book_collector.ViewModels.BooksViewModel;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace book_collector.ViewModels.CollectionsViewModel
{
    public class CreateCollectionViewModel
    {
        public string collectionName { get; set; }
        public string collectionDescription { get; set; }
        public List <SelectListItem> Books {get; set;}
        public string[] selectedBooks { get; set;}
    }
}
