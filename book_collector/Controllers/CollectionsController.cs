using AutoMapper;
using book_collector.Data;
using book_collector.Interfaces;
using book_collector.Models;
using book_collector.ViewModels.CollectionsViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace book_collector.Controllers
{
    public class CollectionsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private IMapper _mapper;
        public book_collectorContext _context;

        public CollectionsController(IUnitOfWork unitOfWork, IMapper mapper, book_collectorContext context)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _context = context;
        }


        // GET: CollectionsController
        public ActionResult Index()
        {
            var model = _unitOfWork.Collection.GetAll();
            var vm = _mapper.Map<List<CollectionViewModel>>(model);
            return View(vm);
        }

        // GET: CollectionsController/Details/5
        public ActionResult Details(string s_id)
        {
            Console.WriteLine(s_id);
            string query = $"SELECT c.Id, c.collectionName, c.collectionDescription, b.bookName FROM dbo.Collections c INNER JOIN dbo.BookCollection bc ON bc.collectionId = c.Id INNER JOIN dbo.Books b ON b.Id = bc.bookId WHERE c.Id = '{s_id}';";
            var Data = _context.Collections.FromSqlRaw(query).ToList();
            ViewBag.Data = Data;
            foreach(var item in Data)
            {
                Console.WriteLine(item);
            }
            return View();
        }

        // GET: CollectionsController/Create
        public ActionResult Create()
        {
            var booksfromRepo = _unitOfWork.Book.GetAll();
            var selectList = new List<SelectListItem>();
            foreach(var book in booksfromRepo)
            {
                selectList.Add(new SelectListItem(book.bookName, book.Id));
            }
            var vm = new CreateCollectionViewModel()
            {
                Books = selectList
            };
            return View(vm);
        }

        // POST: CollectionsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateCollectionViewModel vm)
        {
            try
            {
                Collection collection = new Collection()
                {
                    collectionName = vm.collectionName,
                    collectionDescription = vm.collectionDescription
                };
                foreach(var book in vm.selectedBooks)
                {
                    collection.bookCollections.Add(new BookCollection()
                    {
                        bookId = book
                    });
                }
                _unitOfWork.Collection.Insert(collection);
                _unitOfWork.Save();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CollectionsController/Edit/5
        public ActionResult Edit(string id)
        {
            var collections = _unitOfWork.Collection.GetById(id);
            var books = _unitOfWork.Book.GetAll();
            var selectBooks = collections.bookCollections.Select(x => new Book()
            {
                Id = x.Book.Id,
                bookName = x.Book.bookName
            });
            var selectList = new List<SelectListItem>();
            books.ForEach(x => selectList.Add(new SelectListItem(x.bookName, x.Id, selectBooks.Select(i => i.Id).Contains(x.Id))));
            var vm = new EditCollectionViewModel()
            {
                Id = collections.Id,
                collectionName = collections.collectionName,
                collectionDescription = collections.collectionDescription,
                Books = selectList
            };
            return View(vm);
        }

        // POST: CollectionsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EditCollectionViewModel vm)
        {
            try
            {
                var collection = _unitOfWork.Collection.GetById(vm.Id);
                collection.collectionName = vm.collectionName;
                collection.collectionDescription = vm.collectionDescription;
                var selectedBooks = vm.selectedBooks;
                var existingBooks = collection.bookCollections.Select(x=> x.bookId).ToList();
                var toAdd = selectedBooks.Except(existingBooks).ToList();
                var toRemove = existingBooks.Except(selectedBooks).ToList();
                collection.bookCollections = collection.bookCollections.Where(x => !toRemove.Contains(x.bookId)).ToList();
                foreach(var book in toAdd){
                    collection.bookCollections.Add(new BookCollection()
                    {
                        bookId = book,
                        collectionId = collection.Id
                    });
                }
                _unitOfWork.Save();
                return RedirectToAction("Index","Books");
            }
            catch
            {
                return View();
            }
        }

        // GET: CollectionsController/Delete/5
        public ActionResult Delete(string id)
        {
            var collection = _unitOfWork.Collection.GetById(id);
            var vm = _mapper.Map<CollectionViewModel>(collection);
            return View(vm);
        }

        // POST: CollectionsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(CollectionViewModel vm)
        {
            try
            {
                var collection = _mapper.Map<Collection>(vm);
                _unitOfWork.Collection.Delete(collection);
                _unitOfWork.Save();
                return RedirectToAction("Index","Collections");
            }
            catch
            {
                return View();
            }
        }
    }
}
