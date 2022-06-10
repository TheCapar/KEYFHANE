using KeyfHane.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace KeyfHane.Controllers
{
    public class UserController : Controller
    {
        Context db = new Context();
        public IActionResult Index()
        {
            var veriler = db.Users.ToList();
            return View(veriler);
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(User u)
        {
            var user = db.Users.Where(x => x.Id == u.Id).FirstOrDefault();
            user = u;
            db.Users.Add(u);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult DeleteUser(int Id)
        {
            var user = db.Users.Find(Id);
            db.Users.Remove(user);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult FindUser(int Id)
        {
            return View(db.Users.Find(Id));
        }

        public IActionResult UpdateUser(User user)
        {
            var user1 = db.Users.Find(user.Id);
            user1.Number = user.Number;
            user1.Password = user.Password;
            user1.ProfileId = user.ProfileId;
            return RedirectToAction("Index");
        }
    }
}
