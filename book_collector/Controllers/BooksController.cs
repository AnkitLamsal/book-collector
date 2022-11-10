using AutoMapper;
using book_collector.Interfaces;
using book_collector.Models;
using book_collector.ViewModels.BooksViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace book_collector.Controllers
{
    public class BooksController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private IMapper _mapper;

        public BooksController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        // GET: BooksController
        public ActionResult Index()
        {
            var model = _unitOfWork.Book.GetAll();
            var vm = _mapper.Map<List<BookViewModel>>(model);
            return View(vm);
        }

        // GET: BooksController/Details/5
        public ActionResult Details(string id)
        {
            var model = _unitOfWork.Book.GetById(id);
            var vm = _mapper.Map<BookViewModel>(model);
            return View(vm);
        }

        // GET: BooksController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BooksController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateBookViewModel vm)
        {
            try
            {

                var model = _mapper.Map<Book>(vm);
                _unitOfWork.Book.Insert(model);
                _unitOfWork.Save();
                return RedirectToAction("Index", "Books");

            }
            catch
            {
                return View();
            }
        }

        // GET: BooksController/Edit/5
        public ActionResult Edit(string id)
        {
            var model = _unitOfWork.Book.GetById(id);
            var vm = _mapper.Map<BookViewModel>(model);
            return View(vm);
        }

        // POST: BooksController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(BookViewModel vm)
        {//int id, IFormCollection collection
            try
            {
                var model = _mapper.Map<Book>(vm);
                _unitOfWork.Book.Update(model);
                _unitOfWork.Save();
                return RedirectToAction("Index", "Books");
            }
            catch
            {
                return View();
            }
        }

        // GET: BooksController/Delete/5
        public ActionResult Delete(string id)
        {

            var model = _unitOfWork.Book.GetById(id);
            var vm = _mapper.Map<BookViewModel>(model);
            return View(vm);
        }

        // POST: BooksController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(BookViewModel vm)
        {
            try
            {
                var model = _mapper.Map<Book>(vm);
                _unitOfWork.Book.Delete(model);
                _unitOfWork.Save();
                return RedirectToAction("Index", "Books");
            }
            catch
            {
                return View();
            }
        }
    }
}
