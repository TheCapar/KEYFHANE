using KeyfHane.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace KeyfHane.Controllers
{
    public class MusicController : Controller
    {
        Context db = new Context();
        public IActionResult Index()
        {
            var veriler = db.Musics.ToList();
            return View(veriler);
        }

        [HttpPost]
        public IActionResult NewMusic(Music music)
        {
            db.Musics.Add(music);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult DeleteMusic(int Id)
        {
            var music = db.Musics.Find(Id);
            db.Musics.Remove(music);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult FindMusic(int Id)
        {
            return View(db.Musics.Find(Id));
        }
        [HttpPost]
        public IActionResult UpdateMusic(Music music)
        {
            var music1 = db.Musics.Find(music.Id);
            music1.Name = music.Name;
            music1.Url = music.Url;
            return RedirectToAction("Index");
        }
    }
}
