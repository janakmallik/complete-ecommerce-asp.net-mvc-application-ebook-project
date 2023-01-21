using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EbookCafeProject.Data;
using EbookCafeProject.Models;
using Newtonsoft.Json.Bson;

namespace EbookCafeProject.Controllers
{
    public class BooksController : Controller
    {
        private EbookCafeProjectContext db = new EbookCafeProjectContext();


        // GET: Books
        public ActionResult Index(string BookCategory, string searchString)
        {
            var Writerlst = new List<string>();

            var WriterQry = from d in db.Books
                           orderby d.BookCategory
                            select d.BookCategory;

            Writerlst.AddRange(WriterQry.Distinct());
            ViewBag.BookCategory = new SelectList(Writerlst);

            var books = from m in db.Books
                         select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                books = books.Where(s => s.BookTitle.Contains(searchString));
            }

            if (!string.IsNullOrEmpty(BookCategory))
            {
                books = books.Where(x => x.BookCategory == BookCategory);
            }

            return View(books);
        }

        public ActionResult Home(string BookCategory, string searchString)
        {
            var Writerlst = new List<string>();

            var WriterQry = from d in db.Books
                            orderby d.BookCategory
                            select d.BookCategory;

            Writerlst.AddRange(WriterQry.Distinct());
            ViewBag.BookCategory = new SelectList(Writerlst);

            var books = from m in db.Books
                        select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                books = books.Where(s => s.BookTitle.Contains(searchString));
            }

            if (!string.IsNullOrEmpty(BookCategory))
            {
                books = books.Where(x => x.BookCategory == BookCategory);
            }

            return View(books);
        }
        public ActionResult Search(string BookCategory, string searchString)
        {
            var Writerlst = new List<string>();

            var WriterQry = from d in db.Books
                            orderby d.BookCategory
                            select d.BookCategory;

            Writerlst.AddRange(WriterQry.Distinct());
            ViewBag.BookCategory = new SelectList(Writerlst);

            var books = from m in db.Books
                        select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                books = books.Where(s => s.BookTitle.Contains(searchString));
            }

            if (!string.IsNullOrEmpty(BookCategory))
            {
                books = books.Where(x => x.BookCategory == BookCategory);
            }

            return View(books);
        }

        // GET: Books/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // GET: Books/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Books/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BookID,BookTitle,BookWriter,ReleaseDate,BookCategory,BookPrice,Discount")] Book book)
        {
            if (ModelState.IsValid)
            {
                db.Books.Add(book);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(book);
        }

        // GET: Books/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // POST: Books/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BookID,BookTitle,BookWriter,ReleaseDate,BookCategory,BookPrice,Discount")] Book book)
        {
            if (ModelState.IsValid)
            {
                db.Entry(book).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(book);
        }

        // GET: Books/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // POST: Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Book book = db.Books.Find(id);
            db.Books.Remove(book);
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
