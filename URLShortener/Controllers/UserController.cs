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

        public List<BookMark> getFavorites(ApplicationUser User)
        {

            var faves = db.Favorites.Where(u => u.FaverId == User.Id).ToList();
            var faveBookMarkIdList = new List<int>();
            foreach(var fave in faves)
            {
                faveBookMarkIdList.Add(fave.BookMarkId);
            }
            var faveBookMarks = new List<BookMark>();
            foreach(var id in faveBookMarkIdList)
            {
                var fave = db.BookMark.Where(i => i.Id == id).FirstOrDefault();
                faveBookMarks.Add(fave);
            }
            return faveBookMarks;

        }

        public ActionResult Details(string UserName)
        {
            var userInstance = db.Users.Where(u => u.UserName == UserName).FirstOrDefault();

            ViewBag.Faves = getFavorites(userInstance);

            return View(userInstance);
        }

        public ActionResult List()
        {
            ViewBag.AllUsers = db.Users.ToList();
            return View();
        }
    }
}