using KeyfHane.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace KeyfHane.Controllers
{
    public class ProfileController : Controller
    {
        Context db = new Context();
        public IActionResult Index()
        {
            var veriler = db.Profiles.ToList();
            return View(veriler);
        }
        [HttpPost]
        public IActionResult NewProfile(Profile profile)
        {
            db.Profiles.Add(profile);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult DeleteProfile(int Id)
        {
            var profile = db.Profiles.Find(Id);
            db.Profiles.Remove(profile);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult FindProfile(int Id)
        {
            return View(db.Profiles.Find(Id));
        }

        public IActionResult UpdateProfile(Profile profile)
        {
            var profile1 = db.Profiles.Find(profile.Id);
            profile1.FirstName = profile.FirstName;
            profile1.PictureUrl = profile.PictureUrl;
            profile1.City = profile.City;
            profile1.AboutMe = profile.AboutMe;
            return RedirectToAction("Index");
        }
    }
}
