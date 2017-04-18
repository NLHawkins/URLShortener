using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using URLShortener.Models;

namespace URLShortener.Controllers
{

    public class HomeController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated == true)
            {
                var userId = User.Identity.GetUserId();
                ViewBag.User = db.Users.SingleOrDefault(u => u.Id == userId);
            }
            else
            {
                ViewBag.User = null;
            }
            ViewBag.BookMarks = db.BookMark.ToList().OrderByDescending(o=>o.Created);
            
            return View();

        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}