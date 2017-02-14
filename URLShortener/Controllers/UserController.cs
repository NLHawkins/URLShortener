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

        [Route("u/{UserName}")]
        public ActionResult Index(string username)
        {
            var userInstance = db.Users.Where(u => u.UserName == username).FirstOrDefault();
            var userId = userInstance.Id;
            ViewBag.UserBookMarks = db.BookMark.Where(u => u.OwnerId == userId).ToList().OrderByDescending(o=>o.Created);
            return View(userInstance);

        }

        
        public ActionResult Details(string UserName)
        {
            var userInstance = db.Users.Where(u => u.UserName == UserName).FirstOrDefault();
            return View(userInstance);
        }

        public ActionResult List()
        {
            ViewBag.AllUsers = db.Users.ToList();
            return View();
        }
    }
}