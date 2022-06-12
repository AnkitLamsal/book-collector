using Book_Collector.Models;
using Microsoft.AspNetCore.Mvc;

namespace Book_Collector.Controllers
{
    public class BookController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        List<Book> booklist = new List<Book>();
        [HttpPost]
        public IActionResult Create(Book b)
        {
            b.is_archived = false;
            if (!ModelState.IsValid)
            {

            }
            ViewBag.name = b.book_name;
            ViewBag.edition = b.book_edition;
            ViewBag.publisher = b.publisher;
            ViewBag.isbn = b.isbn_number;
            return View();
        }
    }
}
