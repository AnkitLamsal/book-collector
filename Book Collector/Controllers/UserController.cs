using Book_Collector.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Book_Collector.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        List<User> users = new List<User>();
        [HttpPost]
        public IActionResult Description(User u)
        {
            if (!ModelState.IsValid)
            {

            }
            // Returning Data
            ViewBag.user_name = u.user_name;
            ViewBag.user_email = u.user_email;
            ViewBag.phone = u.user_phone;
            return View();
        }
    }
}
