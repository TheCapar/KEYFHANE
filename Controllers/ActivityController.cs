using KeyfHane.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace KeyfHane.Controllers
{
    public class ActivityController : Controller
    {
        Context db = new Context();
        public IActionResult Index()
        {
            var veriler = db.Activities.ToList();
            return View(veriler);
        }

        [HttpGet]
        public IActionResult NewActivity()
        {
            return View();
        }

        [HttpPost]
        public IActionResult NewActivity(Activity activity)
        {
            db.Activities.Add(activity);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult DeleteActivity(int Id)
        {
            var activity = db.Activities.Find(Id);
            db.Activities.Remove(activity);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult FindActivity(int Id)
        {
            return View(db.Activities.Find(Id));
        }

        public IActionResult UpdateActivity(Activity activity)
        {
            var activity1 = db.Activities.Find(activity.Id);
            activity1.Name = activity.Name;
            activity1.Address = activity.Address;
            activity1.DateTime = activity.DateTime;
            return RedirectToAction("Index");
        }
    }
}
