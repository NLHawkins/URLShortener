using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using URLShortener.Models;

namespace URLShortener.Controllers
{
    
    public class UserController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            var userInstance = db.Users.Where(u => u.Id == userId).FirstOrDefault();
            ViewBag.UserBookMarks = db.BookMark.Where(u => u.OwnerId == userId).ToList();
            return View(userInstance);
        }

        [Route("U/{username}")]
        public ActionResult Detail(string username)
        {
            var userInstance = db.Users.Where(u => u.UserName == username).FirstOrDefault();
            var userId = userInstance.Id;
            ViewBag.UserBookMarks = db.BookMark.Where(u => u.OwnerId == userId).ToList();
            return View(userInstance);
        }
    }
}