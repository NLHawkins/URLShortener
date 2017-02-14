using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using URLShortener.Models;

namespace URLShortener.Controllers
{
    public class BookMarkController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public static string getHash(string url)
        {
            
            byte[] byteData = Encoding.UTF8.GetBytes(url);
            Stream inputStream = new MemoryStream(byteData);
            using (SHA256 shaM = new SHA256Managed())
            {
                var result = shaM.ComputeHash(inputStream);
                string output = BitConverter.ToString(result);
                string hashLink = output.Replace("-", "").Substring(0, 5);
                return hashLink;
            }
            
        }
        public ActionResult Index()
        {
            return RedirectToAction("Index", "Home");
        }

        [Route("b/{hashlink}")]
        public ActionResult Details(string hashlink)
        {
            
            BookMark bookMark = db.BookMark.Where(h => h.HashLink == hashlink).FirstOrDefault();
            var creatorId = bookMark.OwnerId;
            var creator = db.Users.Where(i => i.Id == creatorId).FirstOrDefault();

            ViewBag.CreatorName = creator.UserName;
            if (bookMark == null)
            {
                return HttpNotFound();
            }
            bookMark.Clicks++;
            db.SaveChanges();

            ClickLog click = new ClickLog();
            click.BookMarkId = bookMark.Id;
            click.TimeLog = DateTime.Now;
            db.ClickLog.Add(click);
            db.SaveChanges();


            return View(bookMark);
        }


        
        public ActionResult Create()
        {
            var userId = User.Identity.GetUserId();
            if (userId == null)
            {
                return RedirectToAction("Login");
            }
            return View();
        }


        // POST: BookMark/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "URL,Title,Description")] BookMark bookMark)
        {
            if (ModelState.IsValid)
            {
                bookMark.Clicks = 1;
                bookMark.OwnerId = User.Identity.GetUserId();
                bookMark.HashLink = getHash(bookMark.URL);                
                db.BookMark.Add(bookMark);
        
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            
            return View(bookMark);
        }

        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookMark bookMark = db.BookMark.Find(id);
            if (bookMark == null)
            {
                return HttpNotFound();
            }

            return View(bookMark);
        }

        // POST: BookMark/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,URL,HashLink,OwnerId,Title,Description")] BookMark bookMark)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bookMark).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bookMark);
        }

        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookMark bookMark = db.BookMark.Find(id);
            if (bookMark == null)
            {
                return HttpNotFound();
            }
            return View(bookMark);
        }

        // POST: BookMark/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BookMark bookMark = db.BookMark.Find(id);
            db.BookMark.Remove(bookMark);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
