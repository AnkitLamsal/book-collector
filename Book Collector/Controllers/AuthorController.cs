using Book_Collector.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Book_Collector.Controllers
{
    public class AuthorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        List<Author> listauthor = new List<Author>();
        [HttpPost]
        public IActionResult Create(Author a)
        {
            if (!ModelState.IsValid)
            {
                
            }
            // Returning Data
            ViewBag.auth_name = a.author_name;
            ViewBag.auth_email = a.author_email;
            ViewBag.auth_description = a.author_description;
            return View();
        }
    }
}
