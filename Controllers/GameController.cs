﻿using Microsoft.AspNetCore.Mvc;

namespace KeyfHane.Controllers
{
    public class GameController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
