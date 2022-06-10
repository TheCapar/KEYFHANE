using KeyfHane.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace KeyfHane.Controllers
{
    public class BookController : Controller
    {
        Context db = new Context();
        public IActionResult Index()
        {
            var veriler = db.Books.ToList();
            return View(veriler);
        }

        [HttpGet]
        public IActionResult NewBook()
        {
            return View();
        }

        [HttpPost]
        public IActionResult NewBook(Book book)
        {
            db.Books.Add(book);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult DeleteBook(int Id)
        {
            var book = db.Books.Find(Id);
            db.Books.Remove(book);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult FindBook(int Id)
        {
            return View(db.Books.Find(Id));
        }
        [HttpPost]
        public IActionResult UpdateBook(Book book)
        {
            var book1 = db.Books.Find(book.Id);
            book1.Name = book.Name;
            book1.Url = book.Url;
            return RedirectToAction("Index");
        }
    }
}
